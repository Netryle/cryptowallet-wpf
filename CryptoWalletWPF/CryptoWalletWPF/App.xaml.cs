using Autofac;
using CryptoWalletWPF.Models;
using CryptoWalletWPF.ViewModels;
using CryptoWalletWPF.Views;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Linq;
using System.Threading.Tasks;
using System.Windows;

namespace CryptoWalletWPF
{
    /// <summary>
    /// Interaction logic for App.xaml
    /// </summary>
    public partial class App : Application
    {
    //    protected override void OnStartup(StartupEventArgs e)
    //    {
    //        base.OnStartup(e);

    //        var containerBuilder = new ContainerBuilder();
    //        containerBuilder.RegisterType<SharedDataModel>().SingleInstance();
    //        containerBuilder.RegisterType<LoginViewModel>();
    //        containerBuilder.RegisterType<CreateAccountViewModel>();
    //        var container = containerBuilder.Build();

    //        var mainWindow = container.Resolve<MainWindow>();
    //        mainWindow.Show();
    //    }
    }
}
