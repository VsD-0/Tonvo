using System;
using System.Collections.Generic;
using System.Collections.Specialized;
using System.ComponentModel;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;

namespace Tonvo
{
    internal class Vacancy : INotifyCollectionChanged
    {
        private string _title;
        private string _salary;
        private string _companyTitle;

        public Vacancy(string title, string salary, string companyTitle)
        {
            Title = title;
            Salary = salary;
            CompanyTitle = companyTitle;
        }

        public string Title
        {
            get { return _title; }
            set
            {
                _title = value;
                OnPropertyChanged("Title");
            }
        }
        public string Salary
        {
            get { return _salary; }
            set
            {
                _salary = value;
                OnPropertyChanged("Salary");
            }
        }
        public string CompanyTitle
        {
            get { return _companyTitle; }
            set
            {
                _companyTitle = value;
                OnPropertyChanged("CompanyTitle");
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
