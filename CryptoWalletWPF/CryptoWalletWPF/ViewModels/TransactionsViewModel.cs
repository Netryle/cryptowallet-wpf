using CryptoWalletWPF.Models;
using CryptoWalletWPF.Utility;
using CryptoWalletWPF.Views;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;

namespace CryptoWalletWPF.ViewModels
{
    class TransactionsViewModel : INotifyPropertyChanged
    {
        private SharedDataModel _sharedDataModel;
        private IViewer _viewer;
        private TransactionsModel _transactionsModel;

        private IEnumerable<Transaction> _transactions;
        private int _blockNumber;

        public IEnumerable<Transaction> Transactions
        {
            get { return _transactions; }
            set 
            { 
                _transactions = value;
                OnPropertyChanged(nameof(Transactions));
            }
        }

        public int BlockNumber
        {
            get { return _blockNumber; }
            set
            {
                _blockNumber = value; 
                OnPropertyChanged(nameof(BlockNumber));
            }
        }

        public ICommand AmountOfBlockChangedCommand { get; set; }
        public ICommand BackButtonCommand { get; set; }

        private TransactionsViewModel(IViewer viewer, SharedDataModel sharedDataModel)
        {
            _viewer = viewer;
            _sharedDataModel = sharedDataModel;
            _transactionsModel = new TransactionsModel(_sharedDataModel);
        }

        public static async Task<TransactionsViewModel> CreateAsync(IViewer viewer, SharedDataModel sharedDataModel)
        {
            var transactionViewModel = new TransactionsViewModel(viewer, sharedDataModel);
            await transactionViewModel.InitializeAsync();

            return transactionViewModel;
        }

        private async Task InitializeAsync()
        {
            AmountOfBlockChangedCommand = new RelayCommand(executeAmountOfBlockChangedCommand);
            BackButtonCommand = new RelayCommand(executeBackButtonCommand);

            BlockNumber = 10;
            await refreshTransactions();
        }

        public event PropertyChangedEventHandler? PropertyChanged;
        public void OnPropertyChanged([CallerMemberName] string prop = "")
        {
            if (PropertyChanged != null)
            {
                PropertyChanged(this, new PropertyChangedEventArgs(prop));
            }
        }

        private async void executeAmountOfBlockChangedCommand()
        {
            await refreshTransactions();
        }

        private void executeBackButtonCommand()
        {
            _viewer.LoadViewAsync(ViewType.Main);
        }

        private async Task refreshTransactions()
        {
            _transactionsModel.BlockRange = BlockNumber;
            await _transactionsModel.GetTransactionHistory();
            Transactions = _transactionsModel.Transactions;
        }
    }
}
