using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Linq;
using System.Threading.Tasks;
using System.Windows;
using Tonvo.MVVM.Views;
using Tonvo.Services;

namespace Tonvo
{
    /// <summary>
    /// Interaction logic for App.xaml
    /// </summary>
    public partial class App : Application
    {
        protected void ApplicationStart(object sender, StartupEventArgs e)
        {
            var shellView = new ShellView();
            shellView.Show();

            DataStorage.Init();
        }
    }
}
