﻿using CryptoWalletWPF.Utility;
using Nethereum.HdWallet;
using Nethereum.Web3;
using Nethereum.Web3.Accounts;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CryptoWalletWPF.Models
{
    internal class MainModel
    {
        private SharedDataModel _sharedDataModel;
        private Web3 _web3;
        private Account _account;
        private string _balance;
        private string _rpc;

        public string GetAccountAddress => _account.Address;
        public string GetBalance
        {
            get { return _balance; }
            private set { _balance = value; }
        }

        public MainModel(SharedDataModel sharedDataModel)
        {
            _sharedDataModel = sharedDataModel;
            _rpc = _sharedDataModel.RpcUrl;

            LoadAccount();
        }

        private void LoadAccount()
        {
            switch (_sharedDataModel.LoadType)
            {
                case LoadingType.PrivateKey:
                    var privateKey = _sharedDataModel.PrivateKey;

                    _account = new Account(privateKey);
                    _web3 = new Web3(_account, _rpc);

                    break;

                case LoadingType.HDWallet:
                    var mnemonic = _sharedDataModel.Mnemonic.ToString();
                    var userPassword = _sharedDataModel.Password;
                    var wallet = new Wallet(mnemonic, userPassword);

                    _account = wallet.GetAccount(0);
                    _web3 = new Web3 (_account, _rpc);

                    break;

                case LoadingType.File: 
                    break;
            }
        }

        public async Task GetAccountBalanceInEth()
        {
            var balance = await _web3.Eth.GetBalance.SendRequestAsync(GetAccountAddress);
            decimal etherBalance = Web3.Convert.FromWei(balance.Value);
            _balance = etherBalance.ToString();           
        }

        public void SendTransaction()
        {

        }

        public void SendToken()
        {

        }

        public void GetTransactions()
        {

        }        
    }
}
