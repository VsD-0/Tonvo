using ReactiveUI.Fody.Helpers;
using System;
using System.Collections.Generic;
using System.Collections.Specialized;
using System.ComponentModel;
using System.Runtime.CompilerServices;
using System.Text;

namespace Tonvo.Models
{
    internal class Applicant : INotifyPropertyChanged
    {
        public Applicant(string professionName, string applicantSalary, string workExperience)
        {
            ProfessionName = professionName;
            ApplicantSalary = applicantSalary;
            WorkExperience = workExperience;
        }

        [Reactive]
        public string ProfessionName { get; set; }

        [Reactive]
        public string ApplicantSalary { get; set; }

        [Reactive]
        public string WorkExperience { get; set; }

        public event PropertyChangedEventHandler PropertyChanged;
    }
}
