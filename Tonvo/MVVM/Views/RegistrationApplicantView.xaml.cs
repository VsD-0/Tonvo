using System.Windows.Controls;
using Tonvo.MVVM.ViewModels;

namespace Tonvo.MVVM.Views
{
    /// <summary>
    /// Логика взаимодействия для RegistrationApplicantView.xaml
    /// </summary>
    public partial class RegistrationApplicantView : UserControl
    {
        public RegistrationApplicantView()
        {
            InitializeComponent();
            DataContext = new RegistrationApplicantViewModel();
        }
    }
}
