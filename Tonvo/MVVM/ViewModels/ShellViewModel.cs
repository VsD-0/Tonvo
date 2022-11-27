using System.Windows;
using Tonvo.Core;
using System.Runtime.InteropServices;
using System.Windows.Interop;
using System;
using ReactiveUI.Fody.Helpers;

namespace Tonvo.MVVM.ViewModels
{
    internal partial class ShellViewModel : ObservableObject
    {
        // TODO: Добавить команды управления окном
        public RelayCommand MoveWindowCommand { get; set; }
        public RelayCommand ShutdownWindowCommand { get; set; }
        public RelayCommand MaximizeWindowCommand { get; set; }
        public RelayCommand MinimizeWindowCommand { get; set; }
        public RelayCommand ControlBarMouseEnter { get; set; }

        [Reactive]
        public object CurrentView { get; set; }

        [LibraryImport("user32.dll", EntryPoint = "SendMessageA")]
        public static partial IntPtr SendMessage(IntPtr hWin, int wMsg, IntPtr wParam, IntPtr lParam);

        public ShellViewModel() 
        {
            Application.Current.MainWindow.MaxHeight = SystemParameters.MaximizedPrimaryScreenHeight;


            MoveWindowCommand = new RelayCommand(o => 
            {
                WindowInteropHelper helper = new(Application.Current.MainWindow);
                SendMessage(helper.Handle, 161, 2, 0);
            });
            ControlBarMouseEnter = new RelayCommand(o => { Application.Current.MainWindow.MaxHeight = SystemParameters.MaximizedPrimaryScreenHeight; });
            ShutdownWindowCommand = new RelayCommand(o => { Application.Current.Shutdown(); });
            MaximizeWindowCommand = new RelayCommand(o => 
            {
                {
                    if (Application.Current.MainWindow.WindowState == WindowState.Maximized) 
                        Application.Current.MainWindow.WindowState = WindowState.Normal;
                    else Application.Current.MainWindow.WindowState = WindowState.Maximized;
                }
            });
            MinimizeWindowCommand= new RelayCommand(o => { Application.Current.MainWindow.WindowState=WindowState.Minimized; });
        }
    }
}
