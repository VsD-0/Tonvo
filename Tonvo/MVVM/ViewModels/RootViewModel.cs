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
using static System.Windows.Forms.VisualStyles.VisualStyleElement.StartPanel;

namespace Tonvo.ViewModels
{
    internal class RootViewModel : ReactiveObject
    {
        // TODO: Перенести некоторый функционал на новосозданные ViewModel
        // TODO: Добавить функционал для двух других классов
        // TODO: Изменить EventName у PasswordBox и DataPicker
        #region Fields
        private Applicant _selectedApplicant;
        private Vacancy _selectedVacancy;

        private Applicant _applicantNewAccount = new Applicant();
        private Vacancy _vacancyNewAccount = new Vacancy
        {
            VacancyName = "",
            VacancySalary = "",
            CompanyName = ""
        };

        private RelayCommand _addVacancyCommand;
        private RelayCommand _removeVacancyCommand;
        private RelayCommand _addApplicantCommand;
        private RelayCommand _removeApplicantCommand;
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


        public ObservableCollection<Vacancy> Vacancies { get; set; }
        public ObservableCollection<Applicant> Applicants { get; set; }
        #endregion Properties

        public RootViewModel()
        {
            DataStorage.Init();
            Vacancies = DataStorage.ReadVacancyJson();
            Applicants = DataStorage.ReadApplicantsJson();
        }

        #region Command

        // команда добавления нового соискателя
        public RelayCommand AddApplicantCommand
        {
            get
            {// TODO: Вызов методов проверки при нажатии кнопки "Зарегистрироваться"
                return _addApplicantCommand ??= new RelayCommand(obj =>
                {
                    //EventManager.OnValidated();
                    Applicant applicant = _applicantNewAccount;
                    if (!applicant.HasErrors)
                    {
                        applicant.Id = Applicants.Count != 0 ? Applicants.Last<Applicant>().Id + 1 : 0; // TODO: Id не прибавляется
                        DataStorage.Init();
                        DataStorage.Add(applicant);
                        Applicants.Insert(0, applicant);
                        SelectedApplicant = applicant;
                    }
                });
            }
        }

        // команда удаления соискателя
        public RelayCommand RemoveApplicantCommand
        {
            get
            {
                return _removeApplicantCommand ??= new RelayCommand(obj =>
                {
                    Applicant applicant = obj as Applicant;
                    DataStorage.Remove(applicant);
                    if (applicant != null)
                        Applicants.Remove(applicant);
                },
                 (obj) => Applicants.Count > 0);
            }
        }

        // команда добавления новой вакансии
        public RelayCommand AddVacancyCommand
        {
            get
            {
                return _addVacancyCommand ??= new RelayCommand(obj =>
                {
                    Vacancy vacancy = _vacancyNewAccount;
                    vacancy.Id = Vacancies.Count != 0 ? Vacancies.Last<Vacancy>().Id + 1 : 0;
                    DataStorage.Init();
                    DataStorage.Add(vacancy);
                    Vacancies.Insert(0, vacancy);
                    SelectedVacancy = vacancy;
                });
            }
        }

        // команда удаления вакансии
        public RelayCommand RemoveVacancyCommand
        {
            get
            {
                return _removeVacancyCommand ??= new RelayCommand(obj =>
                  {
                      Vacancy vacancy = obj as Vacancy;
                      DataStorage.Remove(vacancy);
                      if (vacancy != null)
                          Vacancies.Remove(vacancy);
                  },
                 (obj) => Vacancies.Count > 0);
            }
        }
        #endregion Commands
    }
}
