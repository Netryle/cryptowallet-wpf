using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;
using CryptoWalletWPF.Utility;

namespace CryptoWalletWPF.ViewModels
{
    class LoginViewModel : INotifyPropertyChanged
    {
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

        public ICommand loadAccountButtonCommand { get; private set; }
        public ICommand createAccountButtonCommand { get; private set; }

        private string? selectedNetwork;

        
        //Consturctor
        public LoginViewModel()
        {
            selectedNetwork = NetworkList.FirstOrDefault();
            loadAccountButtonCommand = new RelayCommand(executeLoadAccountButtonCommand);
            createAccountButtonCommand = new RelayCommand(executeCreateAccountButtonCommand);
        }

        public event PropertyChangedEventHandler? PropertyChanged;
        public void OnPropertyChanged([CallerMemberName] string prop = "")
        {
            if (PropertyChanged != null)
            {
                PropertyChanged(this, new PropertyChangedEventArgs(prop));
            }
        }

        private void executeLoadAccountButtonCommand()
        {
            var loadAccountWindow = new LoadAccountWindow();

            loadAccountWindow.Show();
            
        }

        private void executeCreateAccountButtonCommand()
        {

        }
    }
}
