using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;

namespace CryptoWalletWPF.ViewModels
{
    class LoginViewModel : INotifyPropertyChanged
    {
        private string selectedNetwork;

        public List<string> NetworkList { get; set; } = new List<string>()
        {
            "Local",
            "Mainnet",
            "Sepolia",
            "Goerli"
        };

        public string SelectedNetwork
        {
            get { return selectedNetwork; }
            set
            {
                selectedNetwork = value;
                OnPropertyChanged("SelectedNetwork");
            }
        } 

        public LoginViewModel()
        {
            selectedNetwork = NetworkList.FirstOrDefault();
        }

        public event PropertyChangedEventHandler? PropertyChanged;
        public void OnPropertyChanged([CallerMemberName] string prop = "")
        {
            if (PropertyChanged != null)
            {
                PropertyChanged(this, new PropertyChangedEventArgs(prop));
            }
        }
    }
}
