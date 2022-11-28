using System.Windows;
using Tonvo.Core;
using System.Runtime.InteropServices;
using System.Windows.Interop;
using System;
using ReactiveUI.Fody.Helpers;
using ReactiveUI;
using System.Collections.ObjectModel;
using Tonvo.Models;
using Tonvo.Services;
using System.Linq;

namespace Tonvo.MVVM.ViewModels
{
    internal partial class ShellViewModel : ReactiveObject
    {
        //
        public GlobalViewModel Global { get; } = GlobalViewModel.Instance;

        #region Fields
        private Applicant _selectedApplicant;
        private Vacancy _selectedVacancy;

        private Applicant _applicantNewAccount = new();
        private Vacancy _vacancyNewAccount = new();
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

        //
        public ObservableCollection<Vacancy> Vacancies { get; set; }
        public ObservableCollection<Applicant> Applicants { get; set; }
        #endregion Properties
        //
        #region Commands
        public RelayCommand MoveWindowCommand { get; set; }
        public RelayCommand ShutdownWindowCommand { get; set; }
        public RelayCommand MaximizeWindowCommand { get; set; }
        public RelayCommand MinimizeWindowCommand { get; set; }
        public RelayCommand ControlBarMouseEnter { get; set; }

        [Reactive]
        public object CurrentListView { get; set; }
        [Reactive]
        public object CurrentControlButtonView { get; set; }
        [Reactive]
        public object CurrentRegistrationView { get; set; }

        #endregion Commands

        [LibraryImport("user32.dll", EntryPoint = "SendMessageA")]
        public static partial IntPtr SendMessage(IntPtr hWin, int wMsg, IntPtr wParam, IntPtr lParam);

        public ListViewModel ListVM { get; set; }
        public ControlButtonsViewModel ControlButtonsVM { get; set; }
        public RegistrationApplicantViewModel RegistrationApplicantVM { get; set; }

        public ShellViewModel() 
        {
            //
            DataStorage.Init();
            
            Vacancies = DataStorage.ReadVacancyJson();
            Applicants = DataStorage.ReadApplicantsJson();
            
            Global.Vacancies = Vacancies;
            Global.Applicants = Applicants;
            Global.SelectedApplicant = SelectedApplicant;
            Global.SelectedVacancy = SelectedVacancy;

            AddApplicantCommand = new TargetRelayCommand(OnAddApplicant, CanAddApplicant);
            RemoveApplicantCommand = new TargetRelayCommand(OnRemoveApplicant, CanRemoveApplicant);

            AddVacancyCommand = new TargetRelayCommand(OnAddVacancy, CanAddVacancy);
            RemoveVacancyCommand = new TargetRelayCommand(OnRemoveVacancy, CanRemoveVacancy);
            //

            ListVM = new ListViewModel();
            CurrentListView = ListVM;

            ControlButtonsVM = new ControlButtonsViewModel();
            CurrentControlButtonView = ControlButtonsVM;

            RegistrationApplicantVM = new RegistrationApplicantViewModel();
            CurrentRegistrationView = RegistrationApplicantVM;

            Application.Current.MainWindow.MaxHeight = SystemParameters.MaximizedPrimaryScreenHeight;

            MoveWindowCommand = new RelayCommand(o => 
            {
                WindowInteropHelper helper = new(Application.Current.MainWindow);
                SendMessage(helper.Handle, 161, 2, 0);
            });
            ControlBarMouseEnter = new RelayCommand(o => { Application.Current.MainWindow.MaxHeight = SystemParameters.MaximizedPrimaryScreenHeight; });
            ShutdownWindowCommand = new RelayCommand(o => { Application.Current.Shutdown(); });
            MaximizeWindowCommand = new RelayCommand(o => 
            {
                {
                    if (Application.Current.MainWindow.WindowState == WindowState.Maximized) 
                        Application.Current.MainWindow.WindowState = WindowState.Normal;
                    else Application.Current.MainWindow.WindowState = WindowState.Maximized;
                }
            });
            MinimizeWindowCommand= new RelayCommand(o => { Application.Current.MainWindow.WindowState=WindowState.Minimized; });
        }
        #region Commands
        private void OnAddApplicant()
        {
            Core.EventManager.OnValidated();
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
            Core.EventManager.OnValidated();
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
