using System.Windows.Controls;
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
