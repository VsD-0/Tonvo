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
using System.Windows.Controls;

namespace Tonvo.Models
{
    internal class Applicant : AbstractModelBase, IModel
    {
        //TODO: Создать отдельный класс для валидации
        private List<bool> _valid = new List<bool>();

        //TODO: Добавить метод каждому свойству
        [Reactive]
        public int Id { get; set; }
        [Reactive]
        public string ProfessionName { get; set; }
        [Reactive]
        public string ApplicantSalary { get; set; }
        [Reactive]
        public string WorkExperience { get; set; }
        [Reactive]
        public string Name { get; set; }
        [Reactive]
        public string SecondName { get; set; }
        [Reactive]
        public string ApplicantDescription { get; set; }
        [Reactive]
        public string Birthday { get; set; }
        [Reactive]
        public string Email { get; set; }
        [Reactive]
        public string Password { get; set; }

        //public bool ValidateApplicant()
        //{
        //    _valid.Clear();
        //    if (!ValidateApplicantProfessionName()) _valid.Add(false);
        //    if (!ValidateApplicantSalary()) _valid.Add(false);
        //    if (!ValidateApplicantWorkExperience()) _valid.Add(false);
        //    if (!ValidateApplicantName()) _valid.Add(false);
        //    if (!ValidateApplicantSecondName()) _valid.Add(false);
        //    if (!ValidateApplicantEmail()) _valid.Add(false);
        //    if (!ValidateApplicantBirthday()) _valid.Add(false);
        //    if (!ValidateApplicantPassword()) _valid.Add(false);
        //    if (!_valid.Any()) return true;
        //    return false;
        //}

        public Applicant()
        {
            //EventManager.Validated += ValidateApplicantProfessionName;
            //EventManager.Validated += ValidateApplicantSalary;
            //EventManager.Validated += ValidateApplicantWorkExperience;
            //EventManager.Validated += ValidateApplicantName;
            //EventManager.Validated += ValidateApplicantSecondName;
            //EventManager.Validated += ValidateApplicantBirthday;
            //EventManager.Validated += ValidateApplicantEmail;
            //EventManager.Validated += ValidateApplicantPassword;
        }

        private RelayCommand _validateApplicantProfessionName;
        public RelayCommand ValidateApplicantProfessionName
        {
            get
            {
                return _validateApplicantProfessionName ??= new RelayCommand(obj =>
                {
                    ClearErrors(nameof(ProfessionName));
                    if (string.IsNullOrWhiteSpace(ProfessionName))
                    {
                        AddError(nameof(ProfessionName), "Поле не может быть пустым");
                        return;
                    }
                    if (!ProfessionName.All(char.IsLetter))
                    {
                        AddError(nameof(ProfessionName), "Название профессии должно содержать только буквы");
                    }
                });
            }
        }

        private RelayCommand _validateApplicantSalary;
        public RelayCommand ValidateApplicantSalary
        {
            get
            {
                return _validateApplicantSalary ??= new RelayCommand(obj =>
                {
                    ClearErrors(nameof(ApplicantSalary));
                    if (string.IsNullOrWhiteSpace(ApplicantSalary))
                    {
                        AddError(nameof(ApplicantSalary), "Поле не может быть пустым");
                        return;
                    }
                    if (!int.TryParse(ApplicantSalary, out _))
                    {
                        AddError(nameof(ApplicantSalary), "Желаемая заработная плата должно содержать только цифры");
                    }
                });
            }
        }

        private RelayCommand _validateApplicantWorkExperience;
        public RelayCommand ValidateApplicantWorkExperience
        {
            get
            {
                return _validateApplicantWorkExperience ??= new RelayCommand(obj =>
                {
                    ClearErrors(nameof(WorkExperience));
                    if (string.IsNullOrWhiteSpace(WorkExperience))
                    {
                        AddError(nameof(WorkExperience), "Поле не может быть пустым");
                        return;
                    }
                    if (!int.TryParse(WorkExperience, out var number))
                    {
                        AddError(nameof(WorkExperience), "Опыт работы должен содержать только цифры");
                    }
                });
            }
        }

        private RelayCommand _validateApplicantName;
        public RelayCommand ValidateApplicantName
        {
            get
            {
                return _validateApplicantName ??= new RelayCommand(obj =>
                {
                    ClearErrors(nameof(Name));
                    if (string.IsNullOrWhiteSpace(Name))
                    {
                        AddError(nameof(Name), "Поле не может быть пустым");
                        return;
                    }
                    if (!Name.All(char.IsLetter))
                    {
                        AddError(nameof(Name), "Имя должно содержать только буквы");
                    }
                });
            }
        }

        private RelayCommand _validateApplicantSecondName;
        public RelayCommand ValidateApplicantSecondName
        {
            get
            {
                return _validateApplicantSecondName ??= new RelayCommand(obj =>
                {
                    ClearErrors(nameof(SecondName));
                    if (string.IsNullOrWhiteSpace(SecondName))
                    {
                        AddError(nameof(SecondName), "Поле не может быть пустым");
                        return;
                    }
                    if (!SecondName.All(char.IsLetter))
                    {
                        AddError(nameof(SecondName), "Фамилия должна содержать только буквы");
                    }
                });
            }
        }

        private RelayCommand _validateApplicantBirthday;
        public RelayCommand ValidateApplicantBirthday
        {
            get
            {
                return _validateApplicantBirthday ??= new RelayCommand(obj =>
                {
                    ClearErrors(nameof(Birthday));
                    if (string.IsNullOrWhiteSpace(Birthday))
                    {
                        AddError(nameof(Birthday), "Поле не может быть пустым");
                        return;
                    }
                    if (DateTime.Parse(Birthday) > DateTime.Today)
                    {
                        AddError(nameof(Birthday), "Укажите настоящую дату рождения");
                        return;
                    }
                    if (DateTime.Parse(Birthday).AddYears(18) > DateTime.Today)
                    {
                        AddError(nameof(Birthday), "Для регистрации вам должно быть больше 18 лет");
                    }
                });
            }
        }

        private RelayCommand _validateApplicantEmail;
        public RelayCommand ValidateApplicantEmail
        {
            get
            {
                return _validateApplicantEmail ??= new RelayCommand(obj =>
                {
                    ClearErrors(nameof(Email));
                    if (string.IsNullOrWhiteSpace(Email))
                    {
                        AddError(nameof(Email), "E-mail не может быть пустым");
                        return;
                    }
                    if (!new EmailAddressAttribute().IsValid(Email ?? throw new ArgumentNullException()))
                    {
                        AddError(nameof(Email), "Некоректная электронная почта");
                    }
                });
            }
        }

        private RelayCommand _validateApplicantPassword;
        public RelayCommand ValidateApplicantPassword
        {
            get
            {
                return _validateApplicantPassword ??= new RelayCommand(obj =>
                {
                    ClearErrors(nameof(Password));
                    if (string.IsNullOrWhiteSpace(Password))
                    {
                        AddError(nameof(Password), "Пароль не может быть пустым");
                        return;
                    }
                    if (!Password.Any(char.IsPunctuation))
                    {
                        AddError(nameof(Password), "Пароль должен содержать спецсимволы");
                        return;
                    }
                    if (!Password.Any(char.IsDigit))
                    {
                        AddError(nameof(Password), "Пароль должен содержать цифры");
                        return;
                    }
                    if (!Password.Any(char.IsLetter))
                    {
                        AddError(nameof(Password), "Пароль должен содержать буквы");
                        return;
                    }
                    if (!Password.Any(char.IsUpper))
                    {
                        AddError(nameof(Password), "Пароль должен содержать прописные буквы");
                        return;
                    }
                    if (!Password.Any(char.IsLower))
                    {
                        AddError(nameof(Password), "Пароль должен содержать строчные буквы");
                        return;
                    }
                    if (Password == null || Password?.Length <= 7)
                    {
                        AddError(nameof(Password), "Пароль должен быть больше 8 символов");
                    }
                });
            }
        }

        //private void ValidateApplicantProfessionName()
        //{
        //    ClearErrors(nameof(ProfessionName));
        //    if (string.IsNullOrWhiteSpace(ProfessionName)){
        //        AddError(nameof(ProfessionName), "Поле не может быть пустым");
        //        return;
        //    }
        //    if (!ProfessionName.All(char.IsLetter)){
        //        AddError(nameof(ProfessionName), "Название профессии должно содержать только буквы");
        //    }
        //}

        //private void ValidateApplicantSalary()
        //{
        //    ClearErrors(nameof(ApplicantSalary));
        //    if (string.IsNullOrWhiteSpace(ApplicantSalary)){
        //        AddError(nameof(ApplicantSalary), "Поле не может быть пустым");
        //        return;
        //    }
        //    if (!int.TryParse(ApplicantSalary, out _)){
        //        AddError(nameof(ApplicantSalary), "Желаемая заработная плата должно содержать только цифры");
        //    }
        //}

        //private void ValidateApplicantWorkExperience()
        //{
        //    ClearErrors(nameof(WorkExperience));
        //    if (string.IsNullOrWhiteSpace(WorkExperience)){
        //        AddError(nameof(WorkExperience), "Поле не может быть пустым");
        //        return;
        //    }
        //    if (!int.TryParse(WorkExperience, out var number)){
        //        AddError(nameof(WorkExperience), "Опыт работы должен содержать только цифры");
        //    }
        //}

        //private void ValidateApplicantName()
        //{
        //    ClearErrors(nameof(Name));
        //    if (string.IsNullOrWhiteSpace(Name)){
        //        AddError(nameof(Name), "Поле не может быть пустым");
        //        return;
        //    }
        //    if (!Name.All(char.IsLetter)){
        //        AddError(nameof(Name), "Имя должно содержать только буквы");
        //    }
        //}

        //private void ValidateApplicantSecondName()
        //{
        //    ClearErrors(nameof(SecondName));
        //    if (string.IsNullOrWhiteSpace(SecondName)){
        //        AddError(nameof(SecondName), "Поле не может быть пустым");
        //        return;
        //    }
        //    if (!SecondName.All(char.IsLetter)){
        //        AddError(nameof(SecondName), "Фамилия должна содержать только буквы");
        //    }
        //}

        //private void ValidateApplicantBirthday()
        //{
        //    ClearErrors(nameof(Birthday));
        //    if (string.IsNullOrWhiteSpace(Birthday)){
        //        AddError(nameof(Birthday), "Поле не может быть пустым");
        //        return;
        //    }
        //    if(DateTime.Parse(Birthday) > DateTime.Today){
        //        AddError(nameof(Birthday), "Укажите настоящую дату рождения");
        //        return;
        //    }
        //    if (DateTime.Parse(Birthday).AddYears(18) > DateTime.Today){
        //        AddError(nameof(Birthday), "Для регистрации вам должно быть больше 18 лет");
        //    }
        //}

        //private void ValidateApplicantEmail()
        //{
        //    ClearErrors(nameof(Email));
        //    if (string.IsNullOrWhiteSpace(Email)){
        //        AddError(nameof(Email), "E-mail не может быть пустым");
        //        return;
        //    }
        //    if (!new EmailAddressAttribute().IsValid(Email ?? throw new ArgumentNullException())){
        //        AddError(nameof(Email), "Некоректная электронная почта");
        //    }
        //}

        //private void ValidateApplicantPassword()
        //{
        //    ClearErrors(nameof(Password));
        //    if (string.IsNullOrWhiteSpace(Password)){
        //        AddError(nameof(Password), "Пароль не может быть пустым");
        //        return;
        //    }
        //    if (!Password.Any(char.IsPunctuation)){
        //        AddError(nameof(Password), "Пароль должен содержать спецсимволы");
        //        return;
        //    }
        //    if (!Password.Any(char.IsDigit)){
        //        AddError(nameof(Password), "Пароль должен содержать цифры");
        //        return;
        //    }
        //    if (!Password.Any(char.IsLetter)) {
        //        AddError(nameof(Password), "Пароль должен содержать буквы");
        //        return;
        //    }
        //    if (!Password.Any(char.IsUpper)) {
        //        AddError(nameof(Password), "Пароль должен содержать прописные буквы");
        //        return;
        //    }
        //    if (!Password.Any(char.IsLower)){
        //        AddError(nameof(Password), "Пароль должен содержать строчные буквы");
        //        return;
        //    }
        //    if (Password == null || Password?.Length <= 7){
        //        AddError(nameof(Password), "Пароль должен быть больше 8 символов");
        //    }
        //}
    }
}
