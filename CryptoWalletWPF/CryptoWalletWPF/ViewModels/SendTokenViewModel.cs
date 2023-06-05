using CryptoWalletWPF.Models;
using CryptoWalletWPF.Utility;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Input;

namespace CryptoWalletWPF.ViewModels
{
    internal class SendTokenViewModel : INotifyPropertyChanged
    {

        private SharedDataModel _sharedDataModel;
        private Window _window;

        private string _contractAddress;
        private string _toAddress;
        private string _tokenAmount;
        private string _gasPrice;
        private string _gasLimit;

        public string ContractAddress
        {
            get { return _contractAddress; }
            set
            {
                _contractAddress = value;
                OnPropertyChanged(nameof(ContractAddress));
            }
        }
        public string ToAddress
        {
            get { return _toAddress; }
            set
            {
                _toAddress = value;
                OnPropertyChanged(nameof(ToAddress));
            }
        }

        public string TokenAmount
        {
            get { return _tokenAmount; }
            set
            {
                _tokenAmount = value;
                OnPropertyChanged(nameof(TokenAmount));
            }
        }

        public string GasPrice
        {
            get { return _gasPrice; }
            set
            {
                _gasPrice = value;
                OnPropertyChanged(nameof(GasPrice));
            }
        }

        public string GasLimit
        {
            get { return _gasLimit; }
            set
            {
                _gasLimit = value;
                OnPropertyChanged(nameof(GasLimit));
            }
        }

        public ICommand sendButtonCommand { get; set; }

        private SendTokenViewModel(SharedDataModel sharedDataModel)
        {
            _sharedDataModel = sharedDataModel;
        }

        public static async Task<SendTokenViewModel> CreateAsync(SharedDataModel sharedDataModel)
        {
            var viewModel = new SendTokenViewModel(sharedDataModel);
            await viewModel.InitializeAsync();

            return viewModel;
        }

        private async Task InitializeAsync()
        {
            
        }

        public event PropertyChangedEventHandler? PropertyChanged;
        public void OnPropertyChanged([CallerMemberName] string prop = "")
        {
            if (PropertyChanged != null)
            {
                PropertyChanged(this, new PropertyChangedEventArgs(prop));
            }
        }

        private async void executeSendButtonCommand()
        {

        }

        private void CloseWindow()
        {
            _window.Close();
        }

        public void SetWindowLink(Window window)
        {
            _window = window;
        }
    }
}
