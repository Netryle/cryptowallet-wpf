﻿using CryptoWalletWPF.Interfaces;
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

        private string _tokenBalance;
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

        public string TokenBalance
        {
            get { return _tokenBalance; }
            set
            {
                _tokenBalance = value;
                OnPropertyChanged(nameof(TokenBalance));
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
        public ICommand contractAddressTextBoxChanged { get; set; }

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
            sendButtonCommand = new RelayCommand(executeSendButtonCommand);
            contractAddressTextBoxChanged = new RelayCommand(executeContractAddressTextBoxChanged);
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
                isEnough = SendTokenModel.IsTokenBalanceEnough(TokenBalance, TokenAmount);
            }


            if (isEnough && isParamsNotNull)
            {
                var transactionInfo = new TransactionInfo
                (
                    ContractAddress,
                    ToAddress,
                    TokenAmount,
                    GasPrice,
                    GasLimit
                );

                var result = await SendTokenModel.SendTokenAsync(transactionInfo, _sharedDataModel);

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

        private async void executeContractAddressTextBoxChanged()
        {
            try
            {
                var balance = await SendTokenModel.GetTokenBalanceAsync(_sharedDataModel, ContractAddress);
                TokenBalance = balance.ToString();
            }
            catch (Exception ex)
            {
                IDialogService.ShowWarning("Wrong contract address");
            }
        }

        private bool IsParametersNotNull()
        {
            return !string.IsNullOrEmpty(ToAddress) &&
                   !string.IsNullOrEmpty(GasPrice) &&
                   !string.IsNullOrEmpty(GasLimit) &&
                   !string.IsNullOrEmpty(TokenAmount) &&
                   !string.IsNullOrEmpty(ContractAddress);
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
