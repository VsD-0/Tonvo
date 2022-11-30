using ReactiveUI;
using ReactiveUI.Fody.Helpers;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Tonvo.Core;
using Tonvo.MVVM.Models;

namespace Tonvo.MVVM.ViewModels
{
    internal class RegistrationApplicantViewModel : ReactiveObject
    {
        public GlobalViewModel Global { get; } = GlobalViewModel.Instance;

        #region Field
        private Applicant _applicantNewAccount = new();
        #endregion Field

        #region Property
        public Applicant ApplicantNewAccount 
        {
            get => _applicantNewAccount;
            set => this.RaiseAndSetIfChanged(ref _applicantNewAccount, value);
        }
        #endregion Property

        public RegistrationApplicantViewModel()
        {
            Global.ApplicantNewAccount = ApplicantNewAccount;
        }
    }
}
