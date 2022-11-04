using System;
using System.Collections.Generic;
using System.Text;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;
using Tonvo.ViewModels;

namespace Tonvo.Views
{
    /// <summary>
    /// Логика взаимодействия для RootView.xaml
    /// </summary>
    public partial class RootView : Page
    {
        public RootView()
        {
            InitializeComponent();
            DataContext = new RootViewModel();
        }
    }
}
