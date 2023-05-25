using CryptoWalletWPF.Models;
using CryptoWalletWPF.Utility;
using CryptoWalletWPF.Views;
using NBitcoin;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Security;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;

namespace CryptoWalletWPF.ViewModels
{
    internal class HDWalletCreatingViewModel : INotifyPropertyChanged
    {
        private IViewer _localViewer;
        private SharedDataModel _sharedDataModel;
        private string _password;
        private string _confirmPassword;
        private string _mnemonicString;
        private Mnemonic _mnemonic;                    

        public string Password 
        {
            get { return _password; } 
            set
            {
                _password = value;
                OnPropertyChanged(nameof(Password));
            }
        }
        public string ConfirmPassword
        {
            get { return _confirmPassword; }
            set
            {
                _confirmPassword = value;
                OnPropertyChanged(nameof(ConfirmPassword));
            }
        }
        public string MnemonicString 
        { 
            get {return _mnemonicString; } 
            set
            {
                _mnemonicString = value;
                OnPropertyChanged(nameof(MnemonicString));
            }
        }

        public ICommand createButtonCommand { get; private set; }
        public ICommand backButtonCommand { get; private set; }
        public ICommand copyButtonCommand { get; private set; }

        public HDWalletCreatingViewModel(IViewer viewer, SharedDataModel sharedDataModel)
        {
            _localViewer = viewer;
            _sharedDataModel = sharedDataModel;

            _mnemonic = AccountCreatorModel.GenerateMnemonic();
            MnemonicString = MnemonicWordListToString(_mnemonic.Words);

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
            if (Password == ConfirmPassword)
            {                
                _sharedDataModel.Mnemonic = _mnemonic;
                _sharedDataModel.Password = _password;

                _localViewer.LoadViewAsync(ViewType.Main);
            }
        }

        private void executeBackButtonCommand()
        {
            _localViewer.LoadViewAsync(ViewType.CreateAccount);
        }

        private void executeCopyButtonCommand()
        {
            //stub
        }

        private string MnemonicWordListToString(string[] wordList)
        {
            var stringBuilder = new StringBuilder();

            for (var i = 0; i < wordList.Length; i++)
            {
                stringBuilder.Append($"{wordList[i]} ");

                if ((i + 1) % 3 == 0)
                {
                    stringBuilder.Append("\r");
                }
            }

            return stringBuilder.ToString();
        }
    }
}
