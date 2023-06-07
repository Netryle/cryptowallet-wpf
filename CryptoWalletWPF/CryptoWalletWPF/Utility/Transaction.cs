using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CryptoWalletWPF.Utility
{
    internal class Transaction
    {
        public string From { get;  set; }
        public string To { get;  set; }
        public string Amount { get;  set; }
        public string Gas { get; set; }
        public string BlockHash { get; set; }
        public string TransactionHash { get; set; }
        public string Data { get; set; }
        public string Status { get; set; }

        public Transaction(string from, string to, string amount, string gas, string blockHash, string transactionHash, string data, string status)
        {
            From = from;
            To = to;
            Amount = amount;
            Gas = gas;
            BlockHash = blockHash;
            TransactionHash = transactionHash;
            Data = data;
            Status = status;
        }
    }
}
