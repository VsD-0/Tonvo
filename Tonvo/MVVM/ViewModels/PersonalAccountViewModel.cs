using ReactiveUI.Fody.Helpers;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using Tonvo.Core;
using Tonvo.MVVM.Models;
using Tonvo.Services;

namespace Tonvo.MVVM.ViewModels
{
    internal class PersonalAccountViewModel
    {
        private RelayCommand _backToHome;
        private RelayCommand _saveEdit;
        private RelayCommand _canselEdit;

        [Reactive]
        public Applicant UserApplicant { get; set; }
        public Vacancy UserVacancy { get; set; }

        public RootViewModel RootVM { get; set; }

        public RelayCommand SaveEdit
        {
            get 
            {
                return _saveEdit ??= new RelayCommand(obj =>
                {
                    DataStorage.AccountChange(UserApplicant);
                });
            }
        }

        public RelayCommand CanselEdit
        {
            get
            {
                return _canselEdit ??= new RelayCommand(obj =>
                {
                    foreach (var item in DataStorage.ReadApplicantsJson())
                    {
                        if (item.Id.Equals(UserApplicant.Id))
                        {
                            UserApplicant = item;
                        }
                    }
                });
            }
        }

        public RelayCommand BackToHome
        {
            get
            {
                return _backToHome ??= new RelayCommand(obj =>
                {
                    RootVM = new RootViewModel();
                    GlobalViewModel.CurrentView = RootVM;
                });
            }
        }

        public PersonalAccountViewModel()
        {
            UserApplicant = GlobalViewModel.UserApplicant;
            UserVacancy = GlobalViewModel.UserVacancy;

            if (UserApplicant != null) { }
            if (UserVacancy != null) { }
        }
    }
}
