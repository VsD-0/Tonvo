using System;
using System.Linq;
using System.Reactive.Linq;
using System.ComponentModel.DataAnnotations;
using ReactiveUI.Fody.Helpers;
using Tonvo.Core;
using Tonvo.Services;
using System.Collections.ObjectModel;

namespace Tonvo.MVVM.Models
{
    internal class Applicant : AbstractModelBase, IModel
    {
        #region Fields
        private RelayCommand _validateApplicantProfessionName;
        private RelayCommand _validateApplicantSalary;
        private RelayCommand _validateApplicantWorkExperience;
        private RelayCommand _validateApplicantName;
        private RelayCommand _validateApplicantSecondName;
        private RelayCommand _validateApplicantBirthday;
        private RelayCommand _validateApplicantEmail;
        private RelayCommand _validateApplicantPassword;
        #endregion Fields

        #region Properties
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
        #endregion Properties

        public Applicant()
        {
            // ValidateApplicantProfessionName = new TargetRelayCommand(OnValidateApplicantProfessionName, CanValidateApplicantProfessionName);
            // ValidateApplicantSalary = new TargetRelayCommand(OnValidateApplicantSalary, CanValidateApplicantSalary);
            // ValidateApplicantWorkExperience = new TargetRelayCommand(OnValidateApplicantWorkExperience, CanValidateApplicantWorkExperience);
            //ValidateApplicantName = new TargetRelayCommand(OnValidateApplicantName, CanValidateApplicantName);
            //ValidateApplicantSecondName = new TargetRelayCommand(OnValidateApplicantSecondName, CanValidateApplicantSecondName);
            //ValidateApplicantBirthday = new TargetRelayCommand(OnValidateApplicantBirthday, CanValidateApplicantBirthday);
            //ValidateApplicantEmail = new TargetRelayCommand(OnValidateApplicantEmail, CanValidateApplicantEmail);
            //ValidateApplicantPassword = new TargetRelayCommand(OnValidateApplicantPassword, CanValidateApplicantPassword);

            // EventManager.Validated += OnValidateApplicantProfessionName;
            // EventManager.Validated += OnValidateApplicantSalary;
            // EventManager.Validated += OnValidateApplicantWorkExperience;
            // EventManager.Validated += OnValidateApplicantName;
            //EventManager.Validated += OnValidateApplicantSecondName;
            //EventManager.Validated += OnValidateApplicantBirthday;
            //EventManager.Validated += OnValidateApplicantEmail;
            //EventManager.Validated += OnValidateApplicantPassword;
        }

        #region Validation
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

                    if (!int.TryParse(WorkExperience, out _))
                    {
                        AddError(nameof(WorkExperience), "Опыт работы должен содержать только цифры");
                    }
                });
            }
        }

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
                    if (DateTime.Parse(Birthday).AddYears(14) > DateTime.Today)
                    {
                        AddError(nameof(Birthday), "Для регистрации вам должно быть больше 14 лет");
                    }
                });
            }
        }

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
                        return;
                    }
                    foreach (Applicant item in DataStorage.ReadApplicantsJson())
                    {
                        if (Email.Equals(item.Email))
                        {
                            AddError(nameof(Email), "Эта почта уже занята. Попробуйте другую");
                        }
                    }
                });
            }
        }

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
        //public TargetRelayCommand ValidateApplicantProfessionName { get; set; }
        //private void OnValidateApplicantProfessionName()
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
        //private bool CanValidateApplicantProfessionName() { return true; }

        //public TargetRelayCommand ValidateApplicantSalary { get; set; }
        //private void OnValidateApplicantSalary()
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
        //private bool CanValidateApplicantSalary() { return true; }

        //public TargetRelayCommand ValidateApplicantWorkExperience { get; set; }
        //private void OnValidateApplicantWorkExperience()
        //{
        //    ClearErrors(nameof(WorkExperience));
        //    if (string.IsNullOrWhiteSpace(WorkExperience)){
        //        AddError(nameof(WorkExperience), "Поле не может быть пустым");
        //        return;
        //    }

        //    if (!int.TryParse(WorkExperience, out _)){
        //        AddError(nameof(WorkExperience), "Опыт работы должен содержать только цифры");
        //    }
        //}
        //private bool CanValidateApplicantWorkExperience() { return true; }

        //public TargetRelayCommand ValidateApplicantName { get; set; }
        //private void OnValidateApplicantName()
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
        //private bool CanValidateApplicantName() { return true; }

        //public TargetRelayCommand ValidateApplicantSecondName { get; set; }   
        //private void OnValidateApplicantSecondName()
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
        //private bool CanValidateApplicantSecondName() { return true; }

        //public TargetRelayCommand ValidateApplicantBirthday { get; set; }
        //private void OnValidateApplicantBirthday()
        //{
        //    ClearErrors(nameof(Birthday));
        //    if (string.IsNullOrWhiteSpace(Birthday)){
        //        AddError(nameof(Birthday), "Поле не может быть пустым");
        //        return;
        //    }
        //    if (DateTime.Parse(Birthday) > DateTime.Today){
        //        AddError(nameof(Birthday), "Укажите настоящую дату рождения");
        //        return;
        //    }
        //    if (DateTime.Parse(Birthday).AddYears(14) > DateTime.Today){
        //        AddError(nameof(Birthday), "Для регистрации вам должно быть больше 14 лет");
        //    }
        //}
        //private bool CanValidateApplicantBirthday() { return true; }

        //public TargetRelayCommand ValidateApplicantEmail { get; set; }
        //private void OnValidateApplicantEmail()
        //{
        //    ClearErrors(nameof(Email));
        //    if (string.IsNullOrWhiteSpace(Email)){
        //        AddError(nameof(Email), "E-mail не может быть пустым");
        //        return;
        //    }
        //    if (!new EmailAddressAttribute().IsValid(Email ?? throw new ArgumentNullException())){
        //        AddError(nameof(Email), "Некоректная электронная почта");
        //        return;
        //    }
        //    foreach (Applicant item in DataStorage.ReadApplicantsJson())
        //    {
        //        if (Email.Equals(item.Email))
        //        {
        //            AddError(nameof(Email), "Эта почта уже занята. Попробуйте другую");
        //        }
        //    }

        //}
        //private bool CanValidateApplicantEmail() { return true; }

        //public TargetRelayCommand ValidateApplicantPassword { get; set; }
        //private void OnValidateApplicantPassword()
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
        //    if (!Password.Any(char.IsLetter)){
        //        AddError(nameof(Password), "Пароль должен содержать буквы");
        //        return;
        //    }
        //    if (!Password.Any(char.IsUpper)){
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
        //private bool CanValidateApplicantPassword() { return true; }
        #endregion Validation
    }
}
