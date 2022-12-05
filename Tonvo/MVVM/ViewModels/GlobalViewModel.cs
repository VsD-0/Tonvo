using System.Collections.ObjectModel;
using Tonvo.MVVM.Models;
using ReactiveUI.Fody.Helpers;
using ReactiveUI;
using System;
using System.Collections.Generic;

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
        public Vacancy VacancyNewAccount { get; set; }

        static object _currentView = new();
        public static object CurrentView { get => _currentView; set {
                _currentView = value;
                onViewUpdate.ForEach((item) => item.DynamicInvoke());
            } }

        public static List<Delegate> onViewUpdate = new();

        public static Applicant UserApplicant { get; set; }
        public static Vacancy UserVacancy { get; set; }

    }
}
