using ReactiveUI.Fody.Helpers;
using System.Collections.Generic;
using System;
using System.ComponentModel;
using Tonvo.Core;
using System.Runtime.CompilerServices;
using System.Collections;
using System.Linq;
using System.Reactive.Linq;
using Tonvo.MVVM.Models;
using Tonvo.Services;

namespace Tonvo.MVVM.ViewModels
{
    internal class SignInViewModel : INotifyDataErrorInfo
    {
        private RelayCommand _signIn_OnClick;
        private RelayCommand _validationSignInEmail;
        private Applicant _applicant = new() { Password = ""};
        private Vacancy _vacancy = new() { Password = "" };

        public PersonalAccountViewModel PersonalAccountVM { get; set; }

        [Reactive]
        public object CurrentView { get; set; }
        [Reactive]
        public object Email { get; set; }
        [Reactive]
        public object Password { get; set; } = "";

        // Переход в личный кабинет
        public RelayCommand SignIn_OnClick
        {
            get
            {
                return _signIn_OnClick ??= new RelayCommand(obj =>
                {
                    PersonalAccountVM = new PersonalAccountViewModel();
                    GlobalViewModel.CurrentView = PersonalAccountVM;
                }, (obj) => 
                {
                    return !HasErrors && (_applicant.Password.Equals(Password) || _vacancy.Password.Equals(Password));
                });
            }
        }

        public SignInViewModel()
        {
        }

        public RelayCommand ValidationSignInEmail
        {
            get
            {
                return _validationSignInEmail ??= new RelayCommand(obj =>
                {
                    ClearErrors(nameof(Email));
                    foreach (Applicant item in DataStorage.ReadApplicantsJson())
                    {
                        if (!Email.Equals(item.Email)) AddError(nameof(Email), "Несуществующая почта");
                        else
                        {
                            ClearErrors(nameof(Email));
                            _applicant = item;
                            return;
                        }
                    }
                    foreach (Vacancy item in DataStorage.ReadVacancyJson())
                    {
                        if (!Email.Equals(item.Email)) AddError(nameof(Email), "Несуществующая почта");
                        else
                        {
                            ClearErrors(nameof(Email));
                            _vacancy = item;
                            return;
                        }
                    }

                });
            }
        }

        #region INotifyDataErrorInfo
        protected readonly Dictionary<string, List<string>> _errorsByPropertyName = new();

        public bool HasErrors => _errorsByPropertyName.Any();

        public event EventHandler<DataErrorsChangedEventArgs> ErrorsChanged;

        public IEnumerable GetErrors(string propertyName)
        {
            return _errorsByPropertyName.ContainsKey(propertyName) ?
            _errorsByPropertyName[propertyName] : null;
        }

        protected void OnErrorsChanged(string propertyName)
        {
            ErrorsChanged?.Invoke(this, new DataErrorsChangedEventArgs(propertyName));
        }

        protected void AddError(string propertyName, string error)
        {
            if (!_errorsByPropertyName.ContainsKey(propertyName))
                _errorsByPropertyName[propertyName] = new List<string>();

            if (!_errorsByPropertyName[propertyName].Contains(error))
            {
                _errorsByPropertyName[propertyName].Add(error);
                OnErrorsChanged(propertyName);
            }
        }

        protected void ClearErrors(string propertyName)
        {
            if (_errorsByPropertyName.ContainsKey(propertyName))
            {
                _errorsByPropertyName.Remove(propertyName);
                OnErrorsChanged(propertyName);
            }
        }
        #endregion INotifyDataErrorInfo
    }
}
