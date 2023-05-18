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
    internal class AccountCreatingViewModel : INotifyPropertyChanged
    {
        private IViewer localViewer;

        public ICommand createButtonCommand { get; private set; }
        public ICommand backButtonCommand { get; private set; }
        public ICommand copyButtonCommand { get; private set; }



        public AccountCreatingViewModel(IViewer viewer)
        {
            localViewer = viewer;

            createButtonCommand = new RelayCommand(executeCreateButtonCommand);
            backButtonCommand = new RelayCommand(executeBackButtonCommand);
            copyButtonCommand = new RelayCommand(executeCopyButtonCommand);
        }

        public event PropertyChangedEventHandler? PropertyChanged;
        public void OnPropertyChanged([CallerMemberName] string prop = "")
        {
            if (PropertyChanged != null)
            {
                PropertyChanged(this, new PropertyChangedEventArgs(prop));
            }
        }

        private void executeCreateButtonCommand()
        {
            localViewer.LoadView(ViewType.Main);
        }

        private void executeBackButtonCommand() 
        {
            localViewer.LoadView(ViewType.CreateAccount);
        }

        private void executeCopyButtonCommand() 
        {
            //stub
        }
    }
}
