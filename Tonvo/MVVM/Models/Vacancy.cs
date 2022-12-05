using System;
using System.ComponentModel.DataAnnotations;
using ReactiveUI.Fody.Helpers;
using Tonvo.Core;
using Tonvo.MVVM.Models;


namespace Tonvo.MVVM.Models
{
    public class Vacancy : AbstractModelBase, IModel
    {
        //TODO: Добавить валидацию свойств в класс
        #region Properties
        [Reactive]
        public int Id { get; set; }
        [Reactive]
        public int IdCompany { get; set; }
        [Reactive]
        public string VacancyName { get; set; }
        [Reactive]
        public string VacancySalary { get; set; }
        [Reactive]
        public string CompanyName { get; set; }
        [Reactive]
        public string RequiredExperience { get; set; }
        [Reactive]
        public string AddressCompany { get; set; }
        [Reactive]
        public string VacancyDescription { get; set; }
        [Reactive]
        public string Email { get; set; }
        // TODO: Убрать после добавления аккаунта компании
        [Reactive]
        public string Password { get; set; }
        #endregion Properties

        public Vacancy()
        {
            ValidateVacancyEmail = new TargetRelayCommand(OnValidateApplicantEmail, CanValidateApplicantEmail);

            EventManager.Validated += OnValidateApplicantEmail;
        }

        #region Validation
        public TargetRelayCommand ValidateVacancyEmail { get; set; }
        private void OnValidateApplicantEmail()
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
        }
        private bool CanValidateApplicantEmail() { return true; }
        #endregion Validation
    }
}
