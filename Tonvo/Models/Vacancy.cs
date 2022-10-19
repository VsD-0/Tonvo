using System.Collections.Specialized;
using System.ComponentModel;
using System.Runtime.CompilerServices;

namespace Tonvo.Models
{
    internal class Vacancy : INotifyCollectionChanged
    {
        private string _vacancyName;
        private string _vacancySalary;
        private string _companyName;

        public Vacancy(string vacancyName, string vacancySalary, string companyName)
        {
            VacancyName = vacancyName;
            VacancySalary = vacancySalary;
            CompanyName = companyName;
        }

        public string VacancyName
        {
            get { return _vacancyName; }
            set
            {
                _vacancyName = value;
                OnPropertyChanged("VacancyName");
            }
        }
        public string VacancySalary
        {
            get { return _vacancySalary; }
            set
            {
                _vacancySalary = value;
                OnPropertyChanged("VacancySalary");
            }
        }
        public string CompanyName
        {
            get { return _companyName; }
            set
            {
                _companyName = value;
                OnPropertyChanged("CompanyName");
            }
        }

        public event PropertyChangedEventHandler PropertyChanged;
        public event NotifyCollectionChangedEventHandler CollectionChanged;

        public void OnPropertyChanged([CallerMemberName] string prop = "")
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(prop));
        }
    }
}
