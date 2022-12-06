using ReactiveUI;
using ReactiveUI.Fody.Helpers;
using System.Collections.ObjectModel;
using System.Linq;
using Tonvo.Core;
using Tonvo.MVVM.Models;
using Tonvo.Services;

namespace Tonvo.MVVM.ViewModels
{
    class RegistrationViewModel : ReactiveObject
    {
        public GlobalViewModel Global { get; } = GlobalViewModel.Instance;

        #region Field
        private Applicant _applicantNewAccount;
        private Vacancy _vacancyNewAccount;

        private Applicant _selectedApplicant;
        private Vacancy _selectedVacancy;

        private RelayCommand _signUp;

        private RelayCommand _addApplicantCommand;
        private RelayCommand _removeApplicantCommand;

        private RelayCommand _addVacancyCommand;
        private RelayCommand _removeVacancyCommand;

        private RelayCommand _changeRegistrationToVacancy;
        private RelayCommand _changeRegistrationToApplicant;
        #endregion Field

        #region Property
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

        public ObservableCollection<Vacancy> Vacancies { get; set; }
        public ObservableCollection<Applicant> Applicants { get; set; }

        public RegistrationApplicantViewModel RegistrationApplicantVM { get; set; }
        public RegistrationVacancyViewModel RegistrationVacancyVM { get; set; }
        public PersonalAccountViewModel PersonalAccountVM { get; set; }

        [Reactive]
        public object CurrentRegistrationPanelView { get; set; }
        
        // 0 = applicant, 1 = company, 2 = vacancy
        private int _modeRegistration = 0;

        #endregion Property

        public RegistrationViewModel()
        {
            Applicants = Global.Applicants;
            Vacancies = Global.Vacancies;

            SelectedApplicant = Global.SelectedApplicant;
            SelectedVacancy= Global.SelectedVacancy;

            RegistrationApplicantVM = new RegistrationApplicantViewModel();
            CurrentRegistrationPanelView = RegistrationApplicantVM;
        }

        #region Command
        public RelayCommand SignUp
        {
            get
            {
                return _signUp ??= new RelayCommand(obj =>
                {
                    if (_modeRegistration == 0) AddApplicantCommand();
                    else AddVacancyCommand();
                });
            }
        }

        // Изменение регистрации на регистрацию вакансии
        public RelayCommand ChangeRegistrationToVacancy
        {
            get 
            { 
                return _changeRegistrationToVacancy ??= new RelayCommand(obj => 
                {
                    _modeRegistration = 2;
                    RegistrationVacancyVM = new RegistrationVacancyViewModel(); 
                    CurrentRegistrationPanelView = RegistrationVacancyVM; 
                }); 
            }
        }
        // Изменение регистрации на регистрацию соискателя
        public RelayCommand ChangeRegistrationToApplicant
        {
            get 
            { return _changeRegistrationToApplicant ??= new RelayCommand(obj => 
                {
                    _modeRegistration = 0;
                    CurrentRegistrationPanelView = RegistrationApplicantVM; 
                }); 
            }
        }

        public void AddApplicantCommand()
        {
            ApplicantNewAccount = Global.ApplicantNewAccount;
            Core.EventManager.OnValidated();
            if (!_applicantNewAccount.HasErrors)
            {
                _applicantNewAccount.Id = Applicants.Count != 0 ? Applicants.First().Id + 1 : 0;
                DataStorage.AddApplicant(_applicantNewAccount);
                Global.Applicants.Insert(0, _applicantNewAccount);
                SelectedApplicant = _applicantNewAccount;
                PersonalAccountVM = new PersonalAccountViewModel();
                GlobalViewModel.CurrentView = PersonalAccountVM;
                GlobalViewModel.UserApplicant = _applicantNewAccount;
            }
        }
        public void AddVacancyCommand()
        {
            VacancyNewAccount = Global.VacancyNewAccount;
            //Core.EventManager.OnValidated();
            if (!_vacancyNewAccount.HasErrors || true)
            {
                _vacancyNewAccount.Id = Vacancies.Count != 0 ? Vacancies.First().Id + 1 : 0;
                DataStorage.AddVacancy(_vacancyNewAccount);
                Global.Vacancies.Insert(0, _vacancyNewAccount);
                SelectedVacancy = _vacancyNewAccount;
                PersonalAccountVM = new PersonalAccountViewModel();
                GlobalViewModel.CurrentView = PersonalAccountVM;
                GlobalViewModel.UserVacancy = _vacancyNewAccount;
            }
        }

        // команда добавления нового соискателя
        //public RelayCommand AddApplicantCommand
        //{
        //    get
        //    {
        //        return _addApplicantCommand ??= new RelayCommand(obj =>
        //        {
        //            ApplicantNewAccount = Global.ApplicantNewAccount;
        //            Core.EventManager.OnValidated();
        //            if (!_applicantNewAccount.HasErrors)
        //            {
        //                _applicantNewAccount.Id = Applicants.Count != 0 ? Applicants.First().Id + 1 : 0;
        //                DataStorage.Add(_applicantNewAccount);
        //                Global.Applicants.Insert(0, _applicantNewAccount);
        //                SelectedApplicant = _applicantNewAccount;
        //                PersonalAccountVM = new PersonalAccountViewModel();
        //                GlobalViewModel.CurrentView = PersonalAccountVM;
        //                GlobalViewModel.UserApplicant = _applicantNewAccount;
        //            }
        //        });
        //    }

        //}
        // команда удаления соискателя
        public RelayCommand RemoveApplicantCommand
        {
            get
            {
                return _removeApplicantCommand ??= new RelayCommand(obj =>
                {
                    Applicant applicant = _selectedApplicant;
                    DataStorage.Remove(applicant);
                    if (applicant != null)
                        Applicants.Remove(applicant);
                }, (obj) => Applicants.Count > 0);
            }
        }

        // команда добавления новой вакансии
        //public RelayCommand AddVacancyCommand
        //{
        //    get
        //    {
        //        return _addVacancyCommand ??= new RelayCommand(obj =>
        //        {
        //            VacancyNewAccount = Global.VacancyNewAccount;
        //            //Core.EventManager.OnValidated();
        //            if (!_vacancyNewAccount.HasErrors || true)
        //            {
        //                _vacancyNewAccount.Id = Vacancies.Count != 0 ? Vacancies.First().Id + 1 : 0;
        //                DataStorage.Add(_vacancyNewAccount);
        //                Global.Vacancies.Insert(0, _vacancyNewAccount);
        //                SelectedVacancy = _vacancyNewAccount;
        //                PersonalAccountVM = new PersonalAccountViewModel();
        //                GlobalViewModel.CurrentView = PersonalAccountVM;
        //                GlobalViewModel.UserVacancy = _vacancyNewAccount;
        //            }
        //        });
        //    }
        //}
        // команда удаления вакансии
        public RelayCommand RemoveVacancyCommand
        {
            get
            {
                return _removeVacancyCommand ??= new RelayCommand(obj =>
                {
                    Applicant applicant = _selectedApplicant;
                    DataStorage.Remove(applicant);
                    if (applicant != null)
                        Applicants.Remove(applicant);
                }, (obj) => Vacancies.Count > 0);
            }
        }
        #endregion Command
    }
}
