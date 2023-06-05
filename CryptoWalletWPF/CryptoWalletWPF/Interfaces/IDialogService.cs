using CryptoWalletWPF.Models;
using CryptoWalletWPF.ViewModels;
using CryptoWalletWPF.Views;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;

namespace CryptoWalletWPF.Interfaces
{
    internal interface IDialogService
    {
        public static async Task ShowSendTransactionDialog(SharedDataModel sharedDataModel)
        {
            var sendTransactionViewModel = await SendTransactionViewModel.CreateAsync(sharedDataModel);
            SendTransactionWindow sendTransactionWindow = new SendTransactionWindow();
            sendTransactionWindow.DataContext = sendTransactionViewModel;
            sendTransactionWindow.Owner = Application.Current.MainWindow;

            sendTransactionViewModel.SetWindowLink(sendTransactionWindow);
            sendTransactionWindow.ShowDialog();
        }

        public static async Task ShowSendTokenDialog(SharedDataModel sharedDataModel)
        {
            var sendTokenViewModel = await SendTokenViewModel.CreateAsync(sharedDataModel);
            SendTokenWindow sendTokenWindow = new SendTokenWindow();
            sendTokenWindow.DataContext = sendTokenViewModel;
            sendTokenWindow.Owner = Application.Current.MainWindow;

            sendTokenViewModel.SetWindowLink(sendTokenWindow);
            sendTokenWindow.ShowDialog();
        }

        public static bool? ShowDialogWithResult(object content, object viewModel)
        {
            Window dialog = new Window
            {
                Content = content,
                DataContext = viewModel,
                Owner = Application.Current.MainWindow
            };
            return dialog.ShowDialog();
        }

        public static void ShowWarning(string message)
        {
            MessageBox.Show(message, "Warning", MessageBoxButton.OK, MessageBoxImage.Warning);
        }

        public static void ShowMessage(string message, string title)
        {
            MessageBox.Show(message, title, MessageBoxButton.OK, MessageBoxImage.Information);
        }
    }
}
