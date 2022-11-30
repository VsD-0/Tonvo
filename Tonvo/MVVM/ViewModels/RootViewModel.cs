using ReactiveUI.Fody.Helpers;
using Tonvo.MVVM.ViewModels;
using ReactiveUI;

namespace Tonvo.ViewModels
{
    internal class RootViewModel : ReactiveObject
    {
        public GlobalViewModel Global { get; } = GlobalViewModel.Instance;

        #region Properties
        public ListViewModel ListVM { get; set; }
        public RegistrationViewModel RegistrationVM { get; set; }
        public SignInViewModel SignInVM { get; set; }
        public ControlPanelViewModel ControlPanelVM { get; set; }

        [Reactive]
        public object CurrentListView { get; set; }
        [Reactive]
        public object CurrentRegistrationView { get; set; }
        [Reactive]
        public object CurrentSignInView { get; set; }
        [Reactive]
        public object CurrentControlPanelView { get; set; }
        #endregion Properties

        public RootViewModel()
        {
            #region UserControl
            ListVM = new ListViewModel();
            CurrentListView = ListVM;

            RegistrationVM = new RegistrationViewModel();
            CurrentRegistrationView = RegistrationVM;

            SignInVM = new SignInViewModel();
            CurrentSignInView = SignInVM;

            ControlPanelVM = new ControlPanelViewModel();
            CurrentControlPanelView = ControlPanelVM;
            #endregion UserControl
        }
    }
}
