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
    internal class LoadAccountFromPrivateKeyViewModel : INotifyPropertyChanged
    {
        private IViewer localViewer;

        public ICommand loadButtonCommand { get; private set; }
        public ICommand backButtonCommand { get; private set; }


        public LoadAccountFromPrivateKeyViewModel(IViewer viewer)
        {
            localViewer = viewer;

            loadButtonCommand = new RelayCommand(executeLoadButtonCommand);
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

        private void executeLoadButtonCommand()
        {
            localViewer.LoadView(ViewType.Main);
        }

        private void executeBackButtonCommand()
        {
            localViewer.LoadView(ViewType.LoadAccount);

        }

    }
}
