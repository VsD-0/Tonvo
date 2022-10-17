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
        private Vacancy? _selectedVacancy;
        public ObservableCollection<Vacancy> Vacancies { get; set; }

        private RelayCommand _addCommand;
        private RelayCommand _removeCommand;

        // команда добавления нового объекта
        public RelayCommand AddCommand
        {
            get
            {
                return _addCommand ??
                  (_addCommand = new RelayCommand(obj =>
                  {
                      Vacancy vacancy = new Vacancy("", "", "");
                      Vacancies.Insert(0, vacancy);
                      SelectedVacancy = vacancy;
                  }));
            }
        }

        // команда удаления
        public RelayCommand RemoveCommand
        {
            get
            {
                return _removeCommand ??
                  (_removeCommand = new RelayCommand(obj =>
                  {
                      Vacancy vacancy = obj as Vacancy;
                      if (vacancy != null)
                      {
                          Vacancies.Remove(vacancy);
                      }
                  },
                 (obj) => Vacancies.Count > 0));
            }
        }

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
                new Vacancy("V1", "1900$", "V1Company" ),
                new Vacancy("V2", "1000$", "V2Company" ),
                new Vacancy("V3", "1200$", "V3Company" ),
                new Vacancy("V4", "1500$", "V4Company" ),
            };
        }

        public event PropertyChangedEventHandler PropertyChanged;
        public void OnPropertyChanged([CallerMemberName] string prop = "")
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(prop));
        }
    }
}
