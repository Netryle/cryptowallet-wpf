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
    class CreateAccountViewModel : INotifyPropertyChanged
    {
        private IViewer localViewer;

        public ICommand accountButtonCommand { get; private set; }
        public ICommand hdWalletButtonCommand { get; private set; }
        public ICommand backButtonCommand { get; private set; }


        public CreateAccountViewModel(IViewer viewer)
        {
            localViewer = viewer;

            accountButtonCommand = new RelayCommand(executeAccountButtonCommand);
            hdWalletButtonCommand = new RelayCommand(executeHDWalletButtonCommand);
            backButtonCommand = new RelayCommand(executeBackButtonCommand);
        }

        public event PropertyChangedEventHandler? PropertyChanged;
        public void OnPropertyChanged([CallerMemberName] string prop = "")
        {
            if (PropertyChanged != null)
            {
                PropertyChanged(this, new PropertyChangedEventArgs(prop));
            }
        }

        private void executeAccountButtonCommand()
        {
            localViewer.LoadViewAsync(ViewType.AccountCreating);
        }

        private void executeHDWalletButtonCommand()
        {
            localViewer.LoadViewAsync(ViewType.HDWalletCreating);

        }

        private void executeBackButtonCommand()
        {
            localViewer.LoadViewAsync(ViewType.Login);
        }
    }
}
