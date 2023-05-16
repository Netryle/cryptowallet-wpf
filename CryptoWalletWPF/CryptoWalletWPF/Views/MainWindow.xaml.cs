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
    }

    /// <summary>
    /// Логика взаимодействия для MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window, IViewer
    {
        public MainWindow()
        {
            InitializeComponent();
        }

        public void LoadView(ViewType typeView)
        {

        }
    }
}
