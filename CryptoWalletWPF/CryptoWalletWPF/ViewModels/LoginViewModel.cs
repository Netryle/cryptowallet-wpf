using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;
using CryptoWalletWPF.Models;
using CryptoWalletWPF.Utility;
using CryptoWalletWPF.Views;

namespace CryptoWalletWPF.ViewModels
{
    class LoginViewModel : INotifyPropertyChanged
    {
        private string _selectedNetwork;
        private IViewer _localViewer;
        private SharedDataModel _sharedDataModel;
        public List<string> NetworkList { get; set; } = new List<string>()
        {
            "Local",
            "Mainnet",
            "Sepolia",
            "Goerli"
        };

        public string SelectedNetwork
        {
            get { return _selectedNetwork; }
            set
            {
                _selectedNetwork = value;
                OnPropertyChanged("SelectedNetwork");
            }
        }

        public ICommand loadAccountButtonCommand { get; private set; }
        public ICommand createAccountButtonCommand { get; private set; }

        

        //Consturctor
        public LoginViewModel(IViewer viewer, SharedDataModel sharedDataModel)
        {
            _localViewer = viewer;
            _sharedDataModel = sharedDataModel;

            _selectedNetwork = NetworkList.FirstOrDefault();
            loadAccountButtonCommand = new RelayCommand(executeLoadAccountButtonCommand);
            createAccountButtonCommand = new RelayCommand(executeCreateAccountButtonCommand);
        }        

        private void executeLoadAccountButtonCommand()
        {
            _sharedDataModel.NetworkName = _selectedNetwork;
            _localViewer.LoadViewAsync(ViewType.LoadAccount);
        }

        private void executeCreateAccountButtonCommand()
        {            
            _sharedDataModel.NetworkName = _selectedNetwork;
            _localViewer.LoadViewAsync(ViewType.CreateAccount);
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
