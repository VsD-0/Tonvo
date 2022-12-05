using ReactiveUI;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Tonvo.MVVM.Models;

namespace Tonvo.MVVM.ViewModels
{
    internal class RegistrationVacancyViewModel : ReactiveObject
    {
        public GlobalViewModel Global { get; } = GlobalViewModel.Instance;

        #region Field
        private Vacancy _vacancyNewAccount = new();
        #endregion Field

        #region Property
        public Vacancy VacancyNewAccount
        {
            get => _vacancyNewAccount;
            set => this.RaiseAndSetIfChanged(ref _vacancyNewAccount, value);
        }
        #endregion Property
        public RegistrationVacancyViewModel()
        {
            Global.VacancyNewAccount = VacancyNewAccount;
        }
    }
}
