﻿using CryptoWalletWPF.Utility;
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
        
        private IViewer localViewer;

        public ICommand privateKeyButtonCommand { get; private set; }
        public ICommand accountFileButtonCommand { get; private set; }
        public ICommand hdWalletButtonCommand { get; private set; }

        public LoadAccountViewModel(IViewer viewer)
        {
            localViewer = viewer;

            privateKeyButtonCommand = new RelayCommand(executePrivateKeyButtonCommand);
            accountFileButtonCommand = new RelayCommand(executeAccountFileButtonCommand);
            hdWalletButtonCommand = new RelayCommand(executeHdWalletButtonCommand);
        }

        public event PropertyChangedEventHandler? PropertyChanged;
        public void OnPropertyChanged([CallerMemberName] string prop = "")
        {
            if (PropertyChanged != null)
            {
                PropertyChanged(this, new PropertyChangedEventArgs(prop));
            }
        }

        private void executePrivateKeyButtonCommand()
        {
            localViewer.LoadView(ViewType.LoadAccountFromPrivateKey);
        }

        private void executeAccountFileButtonCommand() 
        {
            localViewer.LoadView(ViewType.LoadAccountFromFile);
        }

        private void executeHdWalletButtonCommand() 
        {
            localViewer.LoadView(ViewType.LoadAccountFromHDWallet);
        }
    }
}
