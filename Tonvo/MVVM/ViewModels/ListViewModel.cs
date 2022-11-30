using ReactiveUI;
using System.Collections.ObjectModel;
using Tonvo.Models;
using Tonvo.Services;

namespace Tonvo.MVVM.ViewModels
{
    internal class ListViewModel :  ReactiveObject
    {
        public GlobalViewModel Global { get; } = GlobalViewModel.Instance;

        private Applicant _selectedApplicant;
        private Vacancy _selectedVacancy;

        public Applicant SelectedApplicant
        {
            get => _selectedApplicant;
            set => this.RaiseAndSetIfChanged(ref _selectedApplicant, value);
        }
        public Vacancy SelectedVacancy
        {
            get => _selectedVacancy;
            set => this.RaiseAndSetIfChanged(ref _selectedVacancy, value);
        }

        public ObservableCollection<Vacancy> Vacancies { get; set; }
        public ObservableCollection<Applicant> Applicants { get; set; }

        public ListViewModel()
        {
            DataStorage.Init();

            Vacancies = DataStorage.ReadVacancyJson();
            Applicants = DataStorage.ReadApplicantsJson();

            Global.SelectedApplicant = SelectedApplicant;
            Global.SelectedVacancy = SelectedVacancy;

            Global.Applicants = Applicants;
            Global.Vacancies = Vacancies;
        }
    }
}
