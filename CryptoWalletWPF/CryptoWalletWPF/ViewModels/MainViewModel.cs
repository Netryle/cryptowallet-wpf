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
using System.Windows.Media.Media3D;

namespace CryptoWalletWPF.ViewModels
{
    class MainViewModel : INotifyPropertyChanged
    {
        private IViewer _localViewer;
        private SharedDataModel _sharedDataModel;
        private MainModel _mainModel;

        private string _networkName;
        private string _accountAddress;
        private string _accountBalance;

        public string NetworkName
        {
            get { return _networkName; }
            set
            {
                _networkName = "Network: " + value;
                OnPropertyChanged(nameof(NetworkName));
            }
        }

        public string AccountAddress
        {
            get { return _accountAddress; }
            set
            {
                _accountAddress = value;
                OnPropertyChanged(nameof(AccountAddress));
            }
        }

        public string AccountBalance
        {
            get { return _accountBalance; }
            set
            {
                _accountBalance = value + " ETH";
                OnPropertyChanged(nameof(AccountBalance));
            }
        }

        public ICommand SendTransactionButtonCommand { get; private set; }
        public ICommand SendTokenButtonCommand { get; private set; }
        public ICommand TransactionsButtonCommand { get; private set; }
        public ICommand LogOutButtonCommand { get; private set; }

        private MainViewModel(IViewer viewer, SharedDataModel sharedDataModel)
        {
            _localViewer = viewer;
            _sharedDataModel = sharedDataModel;
            _mainModel = new MainModel(_sharedDataModel);
        }

        public static async Task<MainViewModel> CreateAsync(IViewer viewer, SharedDataModel sharedDataModel)
        {
            var viewModel = new MainViewModel(viewer, sharedDataModel);
            await viewModel.InitializeAsync();
            
            return viewModel;
        }

        private async Task InitializeAsync()
        {
            NetworkName = _sharedDataModel.NetworkName;
            AccountAddress = _mainModel.AccountAddress;

            await RefreshBalance();

            LogOutButtonCommand = new RelayCommand(executeLogOutButtonCommand);
            SendTransactionButtonCommand = new RelayCommand(executeSendTransactionButtonCommand);
            SendTokenButtonCommand = new RelayCommand(executeSendTokenButtonCommand);
        }       

        private async void executeSendTransactionButtonCommand()
        {
            await _mainModel.SendTransaction();

            await RefreshBalance();
        }

        private async void executeSendTokenButtonCommand() 
        {
            await _mainModel.SendToken();
        }

        private void executeTransactionsButtonCommand() 
        {
            
        }

        private void executeLogOutButtonCommand()
        {
            _localViewer.LoadViewAsync(ViewType.Login);
        }

        private async Task RefreshBalance()
        {
            await _mainModel.GetAccountBalanceInEth();
            var balance = _mainModel.Balance;
            AccountBalance = balance;
            _sharedDataModel.AccountBalance = balance;
        }

        public event PropertyChangedEventHandler? PropertyChanged;
        public void OnPropertyChanged([CallerMemberName] string prop = "")
        {
            if (PropertyChanged != null)
            {
                PropertyChanged(this, new PropertyChangedEventArgs(prop));
            }
        }        
    }
}

/*
        public MainViewModel(IViewer viewer, SharedDataModel sharedDataModel)
        {
            _localViewer = viewer;
            _sharedDataModel = sharedDataModel;
            _mainModel = new MainModel(
                               _sharedDataModel.PrivateKey,
                               _sharedDataModel.RpcUrl
                               );

            NetworkName = _sharedDataModel.NetworkName;
            AccountAddress = _mainModel.GetAccountAddress;

            GetBalanceAsync();
            AccountBalance = _mainModel.GetBalance;

            logOutButtonCommand = new RelayCommand(executeLogOutButtonCommand);
        }
        */
