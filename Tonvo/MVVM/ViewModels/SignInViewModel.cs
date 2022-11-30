using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using Tonvo.Core;

namespace Tonvo.MVVM.ViewModels
{
    class SignInViewModel
    {
        public GlobalViewModel Global { get; } = GlobalViewModel.Instance;

        private RelayCommand _moveToPersonalAccount;

        public PersonalAreaViewModel PersonalAreaVM { get; set;  }

        public SignInViewModel()
        {
        }

        // Переход в личный кабинет
        public RelayCommand MoveToPersonalAccount
        {
            get
            {
                return _moveToPersonalAccount ??= new RelayCommand(obj =>
                {
                    PersonalAreaVM = new PersonalAreaViewModel();
                    MessageBox.Show(Global.CurrentView.ToString());
                    Global.CurrentView = PersonalAreaVM;
                    MessageBox.Show(Global.CurrentView.ToString());
                });
            }
        }
    }
}
