using NBitcoin;
using Nethereum.Hex.HexConvertors.Extensions;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Input;

namespace CryptoWalletWPF.Models
{
    internal class AccountCreatorModel
    {
        public static string GeneratePrivateKey()
        {
            var ecKey = Nethereum.Signer.EthECKey.GenerateKey();
            var privateKey = ecKey.GetPrivateKeyAsBytes().ToHex();

            return privateKey;
        }

        public static Mnemonic GenerateMnemonic()
        {
            var mnemonic = new Mnemonic(Wordlist.English, WordCount.Twelve);

            return mnemonic; 
        }
        
        public static void CopyText(string text)
        {
            Clipboard.SetText(text);
        }
    }
}
