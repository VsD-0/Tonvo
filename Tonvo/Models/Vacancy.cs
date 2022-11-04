using ReactiveUI.Fody.Helpers;
using System.Collections.Specialized;
using System.ComponentModel;
using System.Runtime.CompilerServices;

namespace Tonvo.Models
{
    internal class Vacancy : INotifyPropertyChanged
    {
        public Vacancy(string vacancyName, string vacancySalary, string companyName)
        {
            VacancyName = vacancyName;
            VacancySalary = vacancySalary;
            CompanyName = companyName;
        }

        [Reactive]
        public string VacancyName { get; set; }

        [Reactive]
        public string VacancySalary { get; set; }

        [Reactive]
        public string CompanyName { get; set; }

        public event PropertyChangedEventHandler PropertyChanged;
    }
}
