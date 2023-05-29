using CryptoWalletWPF.Interfaces;
using CryptoWalletWPF.Models;
using CryptoWalletWPF.Utility;
using CryptoWalletWPF.Views;
using Nethereum.Hex.HexTypes;
using Nethereum.RPC.Eth.DTOs;
using Nethereum.Util;
using Nethereum.Web3;
using Nethereum.Web3.Accounts;
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
    internal class SendTransactionViewModel : INotifyPropertyChanged
    {
        private SharedDataModel _sharedDataModel;
        private Window _window;

        private string _toAddress;
        private string _amount;
        private string _gasPrice;
        private string _gasLimit;

        public event EventHandler CloseWindowRequested;

        public string ToAddress
        {
            get { return _toAddress; }
            set
            {
                _toAddress = value;
                OnPropertyChanged(nameof(ToAddress));
            }
        }

        public string Amount
        {
            get { return _amount; }
            set 
            {
                _amount = value;
                OnPropertyChanged(nameof(Amount));
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
        public ICommand cancelButtonCommand { get; set; }

        private SendTransactionViewModel(SharedDataModel sharedDataModel)
        {
            _sharedDataModel = sharedDataModel;
        }

        public static async Task<SendTransactionViewModel> CreateAsync(SharedDataModel sharedDataModel)
        {
            var viewModel = new SendTransactionViewModel(sharedDataModel);
            await viewModel.InitializeAsync();

            return viewModel;
        }

        private async Task InitializeAsync()
        {
            GasPrice = await SendTransactionModel.GetRecommendedGasPriceAsync(_sharedDataModel);
            GasLimit = await SendTransactionModel.GetRecommendedGasLimitAsync(_sharedDataModel);

            sendButtonCommand = new RelayCommand(executeSendButtonCommand);
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
            var isEnough = false;
            var isParamsNotNull = IsParametersNotNull();

            if (!isParamsNotNull)
            {
                IDialogService.ShowWarning("Not all fields are filled");
                return;
            }
            else
            {
                isEnough = SendTransactionModel
                    .IsBalanceEnoughForSending(_sharedDataModel.AccountBalance, Amount);
            }
            

            if (isEnough && isParamsNotNull)
            {
                var transactionInfo = new TransactionInfo()
                {
                    ToAddress = this.ToAddress,
                    Amount = this.Amount,
                    GasPrice = this.GasPrice,
                    GasLimit = this.GasLimit,
                };

                var result = await SendTransactionModel.SendTransactionAsync(transactionInfo, _sharedDataModel);

                if (!result)
                {
                    IDialogService.ShowWarning("The transaction failed. Possibly wrong address");
                }
                else
                {
                    CloseWindow();
                    IDialogService.ShowMessage("Transaction was successful", "Success");
                }
            }
            else
            {
                IDialogService.ShowWarning("Not enough balance for transaction");
            }

        }

        private bool IsParametersNotNull()
        {
            return !string.IsNullOrEmpty(ToAddress) &&
                   !string.IsNullOrEmpty(GasPrice) &&
                   !string.IsNullOrEmpty(GasLimit) &&
                   !string.IsNullOrEmpty(Amount);
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
