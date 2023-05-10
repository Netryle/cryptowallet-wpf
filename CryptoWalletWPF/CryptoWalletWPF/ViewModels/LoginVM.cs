using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;

namespace CryptoWalletWPF.ViewModels
{
    class LoginVM : INotifyPropertyChanged
    {
        public List<string> NetworkList = new List<string>()
        {
            "Local",
            "Mainnet",
            "Sepolia",
            "Goerli"
        };

        public event PropertyChangedEventHandler? PropertyChanged;
        public void OnPropertyChanged([CallerMemberName] string prop = "")
        {
            if (PropertyChanged != null)
                PropertyChanged(this, new PropertyChangedEventArgs(prop));
        }
    }
}
