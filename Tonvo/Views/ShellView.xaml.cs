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
using System.Windows.Navigation;
using System.Windows.Shapes;
using Tonvo.ViewModels;

namespace Tonvo.Views
{
    /// <summary>
    /// Interaction logic for ShellView.xaml
    /// </summary>
    public partial class ShellView : Window
    {
        public ShellView()
        {
            InitializeComponent();
        }

        // Закрыть окно
        private void CloseCommand_CanExecute(object sender, CanExecuteRoutedEventArgs e) { e.CanExecute = true; }
        private void CloseCommand_Executed(object sender, ExecutedRoutedEventArgs e) { this.Close(); }

        // Свернутть окно
        private void MinCommand_CanExecute(object sender, CanExecuteRoutedEventArgs e) { e.CanExecute = true; }
        private void MinCommand_Executed(object sender, ExecutedRoutedEventArgs e) { WindowState = WindowState.Minimized;}

        // Расширить окно
        private void MaxCommand_CanExecute(object sender, CanExecuteRoutedEventArgs e) { e.CanExecute = true; }
        private void MaxCommand_Executed(object sender, ExecutedRoutedEventArgs e)
        {
            if (WindowState == WindowState.Maximized) WindowState = WindowState.Normal;
            else WindowState = WindowState.Maximized;
        }

        // Перемещение окна
        private void Grid_MouseDown(object sender, MouseButtonEventArgs e)
        {
            if (e.LeftButton == MouseButtonState.Pressed) DragMove();
        }
    }
}
