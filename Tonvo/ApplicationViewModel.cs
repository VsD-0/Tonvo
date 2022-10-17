using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Runtime.CompilerServices;
using System.Windows.Data;

namespace Tonvo
{
    internal class ApplicationViewModel : INotifyPropertyChanged
    {
        private Vacancy _selectedVacancy;
        public ObservableCollection<Vacancy> Vacancies { get; set; }

        private Applicant _selectedApplicant;
        public ObservableCollection<Applicant> Applicants { get; set; }

        private RelayCommand _addVacancyCommand;
        private RelayCommand _removeVacancyCommand;

        // команда добавления нового объекта
        public RelayCommand AddVacancyCommand
        {
            get
            {
                return _addVacancyCommand ??= new RelayCommand(obj =>
                  {
                      Vacancy vacancy = new Vacancy("", "", "");
                      Vacancies.Insert(0, vacancy);
                      SelectedVacancy = vacancy;
                  });
            }
        }

        // команда удаления
        public RelayCommand RemoveVacancyCommand
        {
            get
            {
                return _removeVacancyCommand ??= new RelayCommand(obj =>
                  {
                      Vacancy vacancy = obj as Vacancy;
                      if (vacancy != null)
                      {
                          Vacancies.Remove(vacancy);
                      }
                  },
                 (obj) => Vacancies.Count > 0);
            }
        }

        public Vacancy SelectedVacancy
        {
            get { return _selectedVacancy; }
            set
            {
                _selectedVacancy = value;
                OnPropertyChanged("SelectedVacancy");
            }
        }

        public Applicant SelectedApplicant
        {
            get { return _selectedApplicant; }
            set
            {
                _selectedApplicant = value;
                OnPropertyChanged("SelectedApplicant");
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
            Applicants = new ObservableCollection<Applicant>
            {
                new Applicant("A1", "1300$", "WE" ),
                new Applicant("A2", "1500$", "WE" ),
                new Applicant("A3", "1200$", "WE" ),
                new Applicant("A4", "1400$", "WE" ),
            };
        }

        public event PropertyChangedEventHandler PropertyChanged;
        public void OnPropertyChanged([CallerMemberName] string prop = "")
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(prop));
        }
    }
}
