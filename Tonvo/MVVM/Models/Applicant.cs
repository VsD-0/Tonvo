using System;
using Tonvo.Core;
using System.Collections.Generic;
using System.Collections.Specialized;
using System.ComponentModel;
using System.Runtime.CompilerServices;
using System.Text;
using Tonvo.MVVM.Models;
using System.ComponentModel.DataAnnotations;
using ReactiveUI.Fody.Helpers;
using static System.Windows.Forms.VisualStyles.VisualStyleElement.StartPanel;
using System.Collections;
using ReactiveUI;
using System.Linq;
using System.Reactive.Linq;
using System.Net;

namespace Tonvo.Models
{
    internal class Applicant : ObservableObject, IModel, INotifyDataErrorInfo
    {
        //TODO: Создать отдельный класс для валидации
        private readonly Dictionary<string, List<string>> _errorsByPropertyName = new Dictionary<string, List<string>>();
        private List<bool> _valid = new List<bool>();

        [Reactive]
        public int Id { get; set; }
        [Reactive]
        public string ProfessionName { get; set; }
        [Reactive]
        public int ApplicantSalary { get; set; }
        [Reactive]
        public int WorkExperience { get; set; }
        [Reactive]
        public string Name { get; set; }
        [Reactive]
        public string SecondName { get; set; }
        [Reactive]
        public string ApplicantDescription { get; set; }
        [Reactive]
        public int Age { get; set; }
        [Reactive]
        public string Email { get; set; }
        [Reactive]
        public string Password { get; set; }

        public bool HasErrors => _errorsByPropertyName.Any();

        public event EventHandler<DataErrorsChangedEventArgs> ErrorsChanged;

        public IEnumerable GetErrors(string propertyName)
        {
            return _errorsByPropertyName.ContainsKey(propertyName) ?
            _errorsByPropertyName[propertyName] : null;
        }

        private void OnErrorsChanged(string propertyName)
        {
            ErrorsChanged?.Invoke(this, new DataErrorsChangedEventArgs(propertyName));
        }

        public bool ValidateApplicant()
        {
            // TODO: Доработай
            if(!ValidateApplicantPassword()) _valid.Add(false);
            if(!ValidateApplicantEmail()) _valid.Add(false);
            if(!ValidateApplicantAge()) _valid.Add(false);
            if (!_valid.Any()) return true;
            return false;
        }

        private bool ValidateApplicantProfessionName()
        {
            ClearErrors(nameof(ProfessionName));
            if (string.IsNullOrWhiteSpace(ProfessionName))
            {
                AddError(nameof(ProfessionName), "Поле не может быть пустым");
                return false;
            }
            if (!SecondName.All(char.IsLetter))
            {
                AddError(nameof(ProfessionName), "Название профессии должно содержать только буквы");
                return false;
            }
            return true;
        }

        private bool ValidateApplicantName()
        {
            ClearErrors(nameof(SecondName));
            if (string.IsNullOrWhiteSpace(SecondName))
            {
                AddError(nameof(Name), "Поле не может быть пустым");
                return false;
            }
            if (!SecondName.All(char.IsLetter))
            {
                AddError(nameof(SecondName), "Имя должно содержать только буквы");
                return false;
            }
            return true;
        }

        private bool ValidateApplicantSecondName()
        {
            ClearErrors(nameof(SecondName));
            if (string.IsNullOrWhiteSpace(SecondName))
            {
                AddError(nameof(SecondName), "Поле не может быть пустым");
                return false;
            }
            if (!SecondName.All(char.IsLetter))
            {
                AddError(nameof(SecondName), "Фамилия должна содержать только буквы");
                return false;
            }
            return true;
        }

        private bool ValidateApplicantAge()
        {
            ClearErrors(nameof(Age));
            if (Age <= 18 && Age >= 120)
            {
                AddError(nameof(Age), "Для регистрации вы должны быть старше 18 лет");
                return false;
            }
            return true;
        }

        private bool ValidateApplicantEmail()
        {
            ClearErrors(nameof(Email));
            if (string.IsNullOrWhiteSpace(Email))
            {
                AddError(nameof(Email), "E-mail не может быть пустым");
                return false;
            }
            if (!new EmailAddressAttribute().IsValid(Email ?? throw new ArgumentNullException()))
            {
                AddError(nameof(Email), "Некоректная электронная почта");
                return false;
            }
            return true;
        }

        private bool ValidateApplicantPassword()
        {
            ClearErrors(nameof(Password));
            if (string.IsNullOrWhiteSpace(Password)){
                AddError(nameof(Password), "Пароль не может быть пустым");
                return false;
            }
            if (!Password.Any(char.IsPunctuation)){
                AddError(nameof(Password), "Пароль должен содержать спецсимволы");
                return false;
            }
            if (!Password.Any(char.IsDigit)){
                AddError(nameof(Password), "Пароль должен содержать цифры");
                return false;
            }
            if (!Password.Any(char.IsLetter)) {
                AddError(nameof(Password), "Пароль должен содержать буквы");
                return false;
            }
            if (!Password.Any(char.IsUpper)) {
                AddError(nameof(Password), "Пароль должен содержать прописные буквы");
                return false;
            }
            if (!Password.Any(char.IsLower)){
                AddError(nameof(Password), "Пароль должен содержать строчные буквы");
                return false;
            }
            if (Password == null || Password?.Length <= 7){
                AddError(nameof(Password), "Пароль должен быть больше 8 символов");
                return false;
            }
            return true;
        }

        private void AddError(string propertyName, string error)
        {
            if (!_errorsByPropertyName.ContainsKey(propertyName))
                _errorsByPropertyName[propertyName] = new List<string>();

            if (!_errorsByPropertyName[propertyName].Contains(error))
            {
                _errorsByPropertyName[propertyName].Add(error);
                OnErrorsChanged(propertyName);
            }
        }

        private void ClearErrors(string propertyName)
        {
            if (_errorsByPropertyName.ContainsKey(propertyName))
            {
                _errorsByPropertyName.Remove(propertyName);
                OnErrorsChanged(propertyName);
            }
        }
    }
}
