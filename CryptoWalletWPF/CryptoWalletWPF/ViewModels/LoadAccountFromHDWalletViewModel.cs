using CryptoWalletWPF.Models;
using CryptoWalletWPF.Utility;
using CryptoWalletWPF.Views;
using NBitcoin;
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
    internal class LoadAccountFromHDWalletViewModel : INotifyPropertyChanged
    {
        private IViewer _localViewer;
        private SharedDataModel _sharedDataModel;
        private string _phraseString;
        private string _password;


        public string PhraseString
        {
            get { return _phraseString; }
            set 
            {
                _phraseString = value;
                OnPropertyChanged(nameof(PhraseString));
            }
        }

        public string Password
        {
            get { return _password; }
            set
            {
                _password = value;
                OnPropertyChanged(nameof(Password));
            }
        }

        public ICommand loadButtonCommand { get; private set; }
        public ICommand backButtonCommand { get; private set; }

        public LoadAccountFromHDWalletViewModel(IViewer viewer, SharedDataModel sharedDataModel)
        {
            _localViewer = viewer;
            _sharedDataModel = sharedDataModel;
        }

        private void executeLoadButtonCommand()
        {
            _sharedDataModel.Mnemonic = new Mnemonic(PhraseString);
            _sharedDataModel.Password = _password;
            _sharedDataModel.LoadType = LoadingType.HDWallet;

            _localViewer.LoadViewAsync(ViewType.Main);

        }

        private void executeBackButtonCommand()
        {
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
