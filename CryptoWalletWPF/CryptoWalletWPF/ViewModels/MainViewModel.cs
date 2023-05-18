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
    class MainViewModel : INotifyPropertyChanged
    {
        private IViewer localViewer;

        public ICommand logOutButtonCommand { get; private set; }

        public MainViewModel(IViewer viewer)
        {
            localViewer = viewer;

            logOutButtonCommand = new RelayCommand(executeLogOutButtonCommand);
        }

        public event PropertyChangedEventHandler? PropertyChanged;
        public void OnPropertyChanged([CallerMemberName] string prop = "")
        {
            if (PropertyChanged != null)
            {
                PropertyChanged(this, new PropertyChangedEventArgs(prop));
            }
        }

        private void executeLogOutButtonCommand()
        {
            localViewer.LoadView(ViewType.Login);
        }
    }
}
