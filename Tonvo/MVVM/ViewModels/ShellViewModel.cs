using System.Windows;
using Tonvo.Core;
using System.Runtime.InteropServices;
using System.Windows.Interop;
using System;
using ReactiveUI;
using ReactiveUI.Fody.Helpers;
using Tonvo.MVVM.ViewModels;

namespace Tonvo.MVVM.ViewModels
{
    internal partial class ShellViewModel : ReactiveObject
    {
        public GlobalViewModel Global { get; } = GlobalViewModel.Instance;

        [LibraryImport("user32.dll", EntryPoint = "SendMessageA")]
        public static partial IntPtr SendMessage(IntPtr hWin, int wMsg, IntPtr wParam, IntPtr lParam);

        private object _currentView;

        #region Properties
        public RelayCommand MoveWindowCommand { get; set; }
        public RelayCommand ShutdownWindowCommand { get; set; }
        public RelayCommand MaximizeWindowCommand { get; set; }
        public RelayCommand MinimizeWindowCommand { get; set; }
        public RelayCommand ControlBarMouseEnter { get; set; }

        public ListViewModel ListVM { get; set; }
        public RootViewModel RootVM { get; set; }
        [Reactive]
        public object CurrentView { get; set; }

        #endregion Properties

        public ShellViewModel()
        {
            RootVM = new RootViewModel();
            Global.CurrentView = RootVM;
            CurrentView = Global.CurrentView;

            // Приложение не перекрывает панель задач
            Application.Current.MainWindow.MaxHeight = SystemParameters.MaximizedPrimaryScreenHeight;

            // Перемещение окна
            MoveWindowCommand = new RelayCommand(o =>
            {
                WindowInteropHelper helper = new(Application.Current.MainWindow);
                SendMessage(helper.Handle, 161, 2, 0);
            });
            // Для нормальной работы на компьютерах с несколькими мониторами
            ControlBarMouseEnter = new RelayCommand(o => { Application.Current.MainWindow.MaxHeight = SystemParameters.MaximizedPrimaryScreenHeight; });
            // Завершение работы приложения
            ShutdownWindowCommand = new RelayCommand(o => { Application.Current.Shutdown(); });
            // Приложение на весь экран
            MaximizeWindowCommand = new RelayCommand(o =>
            {
                {
                    MessageBox.Show(CurrentView.ToString());
                    if (Application.Current.MainWindow.WindowState == WindowState.Maximized)
                        Application.Current.MainWindow.WindowState = WindowState.Normal;
                    else Application.Current.MainWindow.WindowState = WindowState.Maximized;
                }
            });
            // Свернуть приложение в панель задач
            MinimizeWindowCommand = new RelayCommand(o => { Application.Current.MainWindow.WindowState = WindowState.Minimized; });
        }
    }
}
