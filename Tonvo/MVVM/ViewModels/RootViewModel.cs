using Newtonsoft.Json;
using ReactiveUI.Fody.Helpers;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Reactive.Linq;
using System.Runtime.CompilerServices;
using System.Windows.Data;
using Tonvo.Core;
using Tonvo.Models;
using Tonvo.MVVM.Models;
using Tonvo.Services;
using System.IO;
using Tonvo.MVVM.ViewModels;
using System.Collections;
using ReactiveUI;

namespace Tonvo.ViewModels
{
    public class RootViewModel : ReactiveObject
    {
        // TODO: Перенести некоторый функционал на новосозданные ViewModel
        // TODO: Добавить функционал для двух других классов
        #region Fields
        private Applicant _selectedApplicant;
        private Vacancy _selectedVacancy;

        private Applicant _applicantNewAccount = new();
        private Vacancy _vacancyNewAccount = new ();
        #endregion Fields

        #region Properties
        public Applicant ApplicantNewAccount
        {
            get => _applicantNewAccount;
            set => this.RaiseAndSetIfChanged(ref _applicantNewAccount, value);
        }
        public Vacancy VacancyNewAccount
        {
            get => _vacancyNewAccount;
            set => this.RaiseAndSetIfChanged(ref _vacancyNewAccount, value);
        }


        public Applicant SelectedApplicant
        {
            get => _selectedApplicant;
            set => this.RaiseAndSetIfChanged(ref _selectedApplicant, value);
        }
        public Vacancy SelectedVacancy
        {
            get => _selectedVacancy;
            set => this.RaiseAndSetIfChanged(ref _selectedVacancy, value);
        }

        // команда добавления нового соискателя
        public TargetRelayCommand AddApplicantCommand { get; set; }
        // команда удаления соискателя
        public TargetRelayCommand RemoveApplicantCommand { get; set; }

        // команда добавления новой вакансии
        public TargetRelayCommand AddVacancyCommand { get; set; }
        // команда удаления вакансии
        public TargetRelayCommand RemoveVacancyCommand { get; set; }

        public ObservableCollection<Vacancy> Vacancies { get; set; }
        public ObservableCollection<Applicant> Applicants { get; set; }
        #endregion Properties

        public RootViewModel()
        {
            DataStorage.Init();

            Vacancies = DataStorage.ReadVacancyJson();
            Applicants = DataStorage.ReadApplicantsJson();

            AddApplicantCommand = new TargetRelayCommand(OnAddApplicant, CanAddApplicant);
            RemoveApplicantCommand = new TargetRelayCommand(OnRemoveApplicant, CanRemoveApplicant);

            AddVacancyCommand = new TargetRelayCommand(OnAddVacancy, CanAddVacancy);
            RemoveVacancyCommand = new TargetRelayCommand(OnRemoveVacancy, CanRemoveVacancy);
        }

        #region Commands
        private void OnAddApplicant()
        {
            EventManager.OnValidated();
            if (!_applicantNewAccount.HasErrors)
            {
                _applicantNewAccount.Id = Applicants.Count != 0 ? Applicants.First().Id + 1 : 0;
                DataStorage.Add(_applicantNewAccount);          
                Applicants.Insert(0, _applicantNewAccount);
                SelectedApplicant = _applicantNewAccount;
                ApplicantNewAccount = new Applicant();
            }
        } 
        private bool CanAddApplicant() { return true; }

        private void OnRemoveApplicant()
        {
            Applicant applicant = _selectedApplicant;
            DataStorage.Remove(applicant);
            if (applicant != null)
                Applicants.Remove(applicant);
        }
        private bool CanRemoveApplicant() { return Applicants.Count > 0; }


        private void OnAddVacancy()
        {
            EventManager.OnValidated();
            if (!_applicantNewAccount.HasErrors)
            {
                _applicantNewAccount.Id = Applicants.Count != 0 ? Applicants.First().Id + 1 : 0;
                DataStorage.Add(_applicantNewAccount);
                Applicants.Insert(0, _applicantNewAccount);
                SelectedApplicant = _applicantNewAccount;
                ApplicantNewAccount = new Applicant();

                Vacancy vacancy = _vacancyNewAccount;
                vacancy.Id = Vacancies.Count != 0 ? Vacancies.Last<Vacancy>().Id + 1 : 0;
                DataStorage.Init();
                DataStorage.Add(vacancy);
                Vacancies.Insert(0, vacancy);
                SelectedVacancy = vacancy;
            }
        }
        private bool CanAddVacancy() { return true; }

        private void OnRemoveVacancy() 
        {
            Vacancy vacancy = _selectedVacancy;
            DataStorage.Remove(vacancy);
            if (vacancy != null)
                Vacancies.Remove(vacancy);
        }
        private bool CanRemoveVacancy() { return Vacancies.Count > 0; }
        #endregion Commands
    }
}
