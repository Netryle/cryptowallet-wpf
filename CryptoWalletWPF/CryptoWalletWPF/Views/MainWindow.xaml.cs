using CryptoWalletWPF.Models;
using CryptoWalletWPF.NewViews;
using CryptoWalletWPF.ViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Shapes;

namespace CryptoWalletWPF.Views
{

    public interface IViewer
    {
        void LoadView(ViewType typeView);
    }

    public enum ViewType
    {
        Main,
        Login,
        LoadAccount,
        LoadAccountFromPrivateKey,
        LoadAccountFromFile,
        LoadAccountFromHDWallet,
        CreateAccount,
        AccountCreating,
        HDWalletCreating,
    }

    /// <summary>
    /// Логика взаимодействия для MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window, IViewer
    {
        private SharedDataModel _sharedDataModel;
        public MainWindow()
        {
            InitializeComponent();
            Loaded += MainWindow_Loaded;
            _sharedDataModel = new SharedDataModel();
        }        

        public void LoadView(ViewType typeView)
        {
            switch (typeView)
            {
                case ViewType.Main:
                    var mainView = new MainUC();
                    var mainViewModel = new MainViewModel(this, _sharedDataModel);

                    mainView.DataContext = mainViewModel;
                    OutputView.Content = mainView;

                    break;

                case ViewType.Login:
                    var loginView = new LoginUC();
                    var loginViewModel = new LoginViewModel(this, _sharedDataModel);

                    loginView.DataContext = loginViewModel;
                    OutputView.Content = loginView;

                    break;

                case ViewType.LoadAccount:
                    var loadAccountView = new LoadAccountUC();
                    var loadAccountViewModel = new LoadAccountViewModel(this, _sharedDataModel);

                    loadAccountView.DataContext = loadAccountViewModel;
                    OutputView.Content = loadAccountView;

                    break;

                case ViewType.LoadAccountFromPrivateKey:
                    var loadAccountFromPrivateKeyView = new LoadAccountFromPrivateKeyUC();
                    var loadAccountFromPrivateKeyViewModel = new LoadAccountFromPrivateKeyViewModel(this, _sharedDataModel);

                    loadAccountFromPrivateKeyView.DataContext = loadAccountFromPrivateKeyViewModel;
                    OutputView.Content = loadAccountFromPrivateKeyView;

                    break;

                case ViewType.LoadAccountFromFile:
                    var loadAccountFromFileView = new LoadAccountFromFileUC();
                    var loadAccountFromFileViewModel = new LoadAccountFromFileViewModel(this);

                    loadAccountFromFileView.DataContext = loadAccountFromFileViewModel;
                    OutputView.Content = loadAccountFromFileView;

                    break;

                case ViewType.LoadAccountFromHDWallet:
                    var loadAccountFromHDWalletView = new LoadAccountFromHDWalletUC();
                    var loadAccountFromHDWalletViewModel = new LoadAccountFromHDWalletViewModel(this);

                    loadAccountFromHDWalletView.DataContext = loadAccountFromHDWalletViewModel;
                    OutputView.Content = loadAccountFromHDWalletView;

                    break;

                case ViewType.CreateAccount:
                    var createAccountView = new CreateAccountUC();
                    var createAccountViewModel = new CreateAccountViewModel(this);

                    createAccountView.DataContext = createAccountViewModel;
                    OutputView.Content = createAccountView;

                    break;

                case ViewType.AccountCreating:
                    var accountCreatingView = new AccountCreatingUC();
                    var accountCreatingViewModel = new AccountCreatingViewModel(this, _sharedDataModel);

                    accountCreatingView.DataContext = accountCreatingViewModel;
                    OutputView.Content = accountCreatingView;

                    break;

                case ViewType.HDWalletCreating:
                    var hdWalletCreatingView = new HDWalletCreatingUC();
                    var hdWalletCreatingViewModel = new HDWalletCreatingViewModel(this, _sharedDataModel);

                    hdWalletCreatingView.DataContext = hdWalletCreatingViewModel;
                    OutputView.Content = hdWalletCreatingView;

                    break;

            }
        }

        private void MainWindow_Loaded(object sender, RoutedEventArgs e)
        {
            LoadView(ViewType.Login);
        }
    }
}
