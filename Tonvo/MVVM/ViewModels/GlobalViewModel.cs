using System.Collections.ObjectModel;
using Tonvo.MVVM.Models;
using ReactiveUI.Fody.Helpers;
using ReactiveUI;

namespace Tonvo.MVVM.ViewModels
{
    class GlobalViewModel : ReactiveObject
    {
        public static GlobalViewModel Instance { get; } = new GlobalViewModel();

        public ObservableCollection<Vacancy> Vacancies { get; set; }
        public ObservableCollection<Applicant> Applicants { get; set; }

        public Applicant SelectedApplicant { get; set; }
        public Vacancy SelectedVacancy { get; set; }

        public Applicant ApplicantNewAccount { get; set; }

        [Reactive]
        public object CurrentView { get; set; }
    }
}
