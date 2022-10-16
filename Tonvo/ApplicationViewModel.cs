using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Security.Policy;
using System.Text;
using System.Threading.Tasks;

namespace Tonvo
{
    internal class ApplicationViewModel : INotifyPropertyChanged
    {
        private Vacancy _selectedVacancy;

        public ObservableCollection<Vacancy> Vacancies { get; set; }
        public Vacancy SelectedVacancy
        {
            get { return _selectedVacancy; }
            set
            {
                _selectedVacancy = value;
                OnPropertyChanged("SelectedPhone");
            }
        }

        public ApplicationViewModel()
        {
            Vacancies = new ObservableCollection<Vacancy>
            {
                new Vacancy { Title="V1", Salary="1000$", CompanyTitle="V1Company" },
                new Vacancy { Title="V2", Salary="1200$", CompanyTitle="V2Company" },
                new Vacancy { Title="V3", Salary="900$", CompanyTitle="V3Company" },
                new Vacancy { Title="V4", Salary="1500$", CompanyTitle="V4Company" }
            };
        }

        public event PropertyChangedEventHandler PropertyChanged;
        public void OnPropertyChanged([CallerMemberName] string prop = "")
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(prop));
        }
    }
}
