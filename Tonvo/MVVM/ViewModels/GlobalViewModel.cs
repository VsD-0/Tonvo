using ReactiveUI.Fody.Helpers;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Tonvo.Models;

namespace Tonvo.MVVM.ViewModels
{
    class GlobalViewModel
    {
        public static GlobalViewModel Instance { get; } = new GlobalViewModel();

        public ObservableCollection<Vacancy> Vacancies { get; set; }
        public ObservableCollection<Applicant> Applicants { get; set; }

        public Applicant SelectedApplicant { get; set; }
        public Vacancy SelectedVacancy { get; set; }
    }
}
