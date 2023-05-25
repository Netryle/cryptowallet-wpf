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
    internal class LoadAccountFromPrivateKeyViewModel : INotifyPropertyChanged
    {
        private IViewer _localViewer;
        private SharedDataModel _sharedDataModel;
        private string _privateKey;
        public string PrivateKey
        {
            get { return _privateKey; }
            set 
            {
                _privateKey = value;
                OnPropertyChanged(nameof(PrivateKey));
            }
        }
        public ICommand loadButtonCommand { get; private set; }
        public ICommand backButtonCommand { get; private set; }


        public LoadAccountFromPrivateKeyViewModel(IViewer viewer, SharedDataModel sharedDataModel)
        {
            _localViewer = viewer;
            _sharedDataModel = sharedDataModel;

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
            _sharedDataModel.PrivateKey = PrivateKey;
            _sharedDataModel.LoadType = LoadingType.PrivateKey;
            _localViewer.LoadViewAsync(ViewType.Main);
        }

        private void executeBackButtonCommand()
        {
            _localViewer.LoadViewAsync(ViewType.LoadAccount);

        }

    }
}
