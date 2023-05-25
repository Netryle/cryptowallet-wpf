using CryptoWalletWPF.Models;
using CryptoWalletWPF.Utility;
using CryptoWalletWPF.Views;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;

namespace CryptoWalletWPF.ViewModels
{
    class LoadAccountViewModel : INotifyPropertyChanged
    {
        
        private IViewer _localViewer;
        private SharedDataModel _sharedDataModel;

        public ICommand privateKeyButtonCommand { get; private set; }
        public ICommand accountFileButtonCommand { get; private set; }
        public ICommand hdWalletButtonCommand { get; private set; }
        public ICommand backButtonCommand { get; private set; }

        public LoadAccountViewModel(IViewer viewer, SharedDataModel sharedDataModel)
        {
            _localViewer = viewer;
            _sharedDataModel = sharedDataModel;

            privateKeyButtonCommand = new RelayCommand(executePrivateKeyButtonCommand);
            accountFileButtonCommand = new RelayCommand(executeAccountFileButtonCommand);
            hdWalletButtonCommand = new RelayCommand(executeHdWalletButtonCommand);
            backButtonCommand = new RelayCommand(executeBackButtonCommand);

        }        

        private void executePrivateKeyButtonCommand()
        {
            _localViewer.LoadViewAsync(ViewType.LoadAccountFromPrivateKey);
        }

        private void executeAccountFileButtonCommand() 
        {
            _localViewer.LoadViewAsync(ViewType.LoadAccountFromFile);
        }

        private void executeHdWalletButtonCommand() 
        {
            _localViewer.LoadViewAsync(ViewType.LoadAccountFromHDWallet);
        }

        private void executeBackButtonCommand()
        {
            _localViewer.LoadViewAsync(ViewType.Login);
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
