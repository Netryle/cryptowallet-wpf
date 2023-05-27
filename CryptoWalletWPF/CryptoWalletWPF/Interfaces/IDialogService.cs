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
        public static void ShowDialog(object content, object viewModel)
        {
            Window dialog = new Window
            {
                Content = content,
                DataContext = viewModel,
                Owner = Application.Current.MainWindow
            };

            dialog.ShowDialog();
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
    }
}
