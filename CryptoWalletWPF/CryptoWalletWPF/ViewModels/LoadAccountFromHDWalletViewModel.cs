using CryptoWalletWPF.Views;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CryptoWalletWPF.ViewModels
{
    internal class LoadAccountFromHDWalletViewModel : INotifyPropertyChanged
    {
        private IViewer localViewer;

        public LoadAccountFromHDWalletViewModel(IViewer viewer)
        {
            localViewer = viewer;
        }

        public event PropertyChangedEventHandler? PropertyChanged;
    }
}
