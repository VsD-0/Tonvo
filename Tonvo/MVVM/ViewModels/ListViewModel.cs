using ReactiveUI;
using System.Collections.ObjectModel;
using Tonvo.Models;

namespace Tonvo.MVVM.ViewModels
{
    internal class ListViewModel :  ReactiveObject
    {
        public GlobalViewModel Global { get; } = GlobalViewModel.Instance;

        public Applicant SelectedApplicant { get; set; }
        public Vacancy SelectedVacancy { get; set; }

        public ObservableCollection<Vacancy> Vacancies { get; set; }
        public ObservableCollection<Applicant> Applicants { get; set; }

        public ListViewModel()
        {
            Vacancies = Global.Vacancies;
            Applicants = Global.Applicants;

            SelectedVacancy = Global.SelectedVacancy;
            SelectedApplicant = Global.SelectedApplicant;
        }
    }
}
