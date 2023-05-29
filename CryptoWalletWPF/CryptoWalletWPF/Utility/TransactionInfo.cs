using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CryptoWalletWPF.Utility
{
    internal class TransactionInfo
    {
        public string ToAddress { get; set; }
        public string GasPrice { get; set; }
        public string GasLimit { get; set; }
        public string Amount { get; set; }
    }
}
