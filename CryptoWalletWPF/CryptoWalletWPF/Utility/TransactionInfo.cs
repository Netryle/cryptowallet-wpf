using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CryptoWalletWPF.Utility
{
    internal class TransactionInfo
    {
        public string ContractAddress { get; private set; }

        public string ToAddress { get; private set; }
        public string GasPrice { get; private set; }
        public string GasLimit { get; private set; }
        public string Amount { get; private set; }

        public TransactionInfo(string toAddress, string gasPrice, string gasLimit, string amount)
        {
            ToAddress = toAddress;
            GasPrice = gasPrice;
            GasLimit = gasLimit;
            Amount = amount;
        }

        public TransactionInfo(string contractAddress,string toAddress,string amount)
        {
            ContractAddress = contractAddress;
            ToAddress = toAddress;
            Amount = amount;
        }
    }
}
