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
        private Web3 _web3;
        private Account _account;

        public string GetAccountAddress => _account.Address;        

        public MainModel(string privateKey, string rpc)
        {
            _account = new Account(privateKey);
            _web3 = new Web3(_account, rpc);            
        }

        public async Task<string> GetAccountBalanceInEth()
        {
            var balance = await _web3.Eth.GetBalance.SendRequestAsync(GetAccountAddress);
            decimal etherBalance = Web3.Convert.FromWei(balance.Value);      
            
            return etherBalance.ToString();
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
