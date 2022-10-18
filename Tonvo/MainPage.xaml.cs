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

namespace Tonvo
{
    /// <summary>
    /// Логика взаимодействия для MainPage.xaml
    /// </summary>
    public partial class MainPage : Page
    {
        public MainPage()
        {
            InitializeComponent();

            DataContext = new ApplicationViewModel();
        }
        private void ComboBoxVacancy_Selected(object sender, RoutedEventArgs e)
        {
            ListVacancies.Visibility = Visibility.Visible;
            ListApplicants.Visibility = Visibility.Hidden;
            titleList.Text = "Вакансии";
        }

        private void ComboBoxApplicant_Selected(object sender, RoutedEventArgs e)
        {
            ListVacancies.Visibility = Visibility.Hidden;
            ListApplicants.Visibility = Visibility.Visible;
            titleList.Text = "Резюме";
        }
    }
}
