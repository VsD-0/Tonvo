using System;
using System.Collections.Generic;
using System.Collections.Specialized;
using System.ComponentModel;
using System.Runtime.CompilerServices;
using System.Text;

namespace Tonvo.Models
{
    internal class Applicant
    {
        private string _professionName;
        private string _applicantSalary;
        private string _workExperience;

        public Applicant(string professionName, string applicantSalary, string workExperience)
        {
            ProfessionName = professionName;
            ApplicantSalary = applicantSalary;
            WorkExperience = workExperience;
        }

        public string ProfessionName
        {
            get { return _professionName; }
            set
            {
                _professionName = value;
                OnPropertyChanged("ProfessionName");
            }
        }
        public string ApplicantSalary
        {
            get { return _applicantSalary; }
            set
            {
                _applicantSalary = value;
                OnPropertyChanged("ApplicantSalary");
            }
        }
        public string WorkExperience
        {
            get { return _workExperience; }
            set
            {
                _workExperience = value;
                OnPropertyChanged("WorkExperience");
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
