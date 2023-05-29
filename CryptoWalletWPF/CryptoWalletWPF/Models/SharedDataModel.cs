using CryptoWalletWPF.Utility;
using NBitcoin;
using Nethereum.Web3;
using Nethereum.Web3.Accounts;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CryptoWalletWPF.Models
{
    class SharedDataModel
    {
        private Dictionary<string, string> _networkDictionary = new Dictionary<string, string>() 
        {
            {"Local", "HTTP://127.0.0.1:7545"},
            {"Mainnet", "https://mainnet.infura.io/v3/81aca5ab22cf457d82be413e5949fa7d"},
            {"Sepolia", "https://sepolia.infura.io/v3/81aca5ab22cf457d82be413e5949fa7d"},
            {"Goerli", "https://goerli.infura.io/v3/81aca5ab22cf457d82be413e5949fa7d"},
        };

        public Mnemonic Mnemonic { get; set; }
        public Web3 Web3 { get; set; }
        public Account Account { get; set; }

        public LoadingType LoadType { get; set; }

        public string NetworkName { get; set; }
        public string PrivateKey {  get; set; }
        public string Password { get; set; }        
        public string AccountBalance { get; set; }
        public string RpcUrl 
        { 
            get { return _networkDictionary[NetworkName]; }              
        }

    }
}
