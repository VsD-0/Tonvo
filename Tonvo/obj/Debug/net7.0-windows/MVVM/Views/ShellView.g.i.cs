﻿#pragma checksum "..\..\..\..\..\MVVM\Views\ShellView.xaml" "{ff1816ec-aa5e-4d10-87f7-6f4963833460}" "D152F80CF1B40309490E9CF1EAE10B2AB2AAA415"
//------------------------------------------------------------------------------
// <auto-generated>
//     Этот код создан программой.
//     Исполняемая версия:4.0.30319.42000
//
//     Изменения в этом файле могут привести к неправильной работе и будут потеряны в случае
//     повторной генерации кода.
// </auto-generated>
//------------------------------------------------------------------------------

using MaterialDesignThemes.Wpf;
using MaterialDesignThemes.Wpf.Converters;
using MaterialDesignThemes.Wpf.Transitions;
using System;
using System.Diagnostics;
using System.Windows;
using System.Windows.Automation;
using System.Windows.Controls;
using System.Windows.Controls.Primitives;
using System.Windows.Controls.Ribbon;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Ink;
using System.Windows.Input;
using System.Windows.Markup;
using System.Windows.Media;
using System.Windows.Media.Animation;
using System.Windows.Media.Effects;
using System.Windows.Media.Imaging;
using System.Windows.Media.Media3D;
using System.Windows.Media.TextFormatting;
using System.Windows.Navigation;
using System.Windows.Shapes;
using System.Windows.Shell;
using Tonvo;


namespace Tonvo.MVVM.Views {
    
    
    /// <summary>
    /// ShellView
    /// </summary>
    public partial class ShellView : System.Windows.Window, System.Windows.Markup.IComponentConnector {
        
        
        #line 21 "..\..\..\..\..\MVVM\Views\ShellView.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Input.CommandBinding CloseCommand;
        
        #line default
        #line hidden
        
        
        #line 25 "..\..\..\..\..\MVVM\Views\ShellView.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Input.CommandBinding MinCommand;
        
        #line default
        #line hidden
        
        
        #line 29 "..\..\..\..\..\MVVM\Views\ShellView.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Input.CommandBinding MaxCommand;
        
        #line default
        #line hidden
        
        private bool _contentLoaded;
        
        /// <summary>
        /// InitializeComponent
        /// </summary>
        [System.Diagnostics.DebuggerNonUserCodeAttribute()]
        [System.CodeDom.Compiler.GeneratedCodeAttribute("PresentationBuildTasks", "7.0.0.0")]
        public void InitializeComponent() {
            if (_contentLoaded) {
                return;
            }
            _contentLoaded = true;
            System.Uri resourceLocater = new System.Uri("/Tonvo;V1.0.0.0;component/mvvm/views/shellview.xaml", System.UriKind.Relative);
            
            #line 1 "..\..\..\..\..\MVVM\Views\ShellView.xaml"
            System.Windows.Application.LoadComponent(this, resourceLocater);
            
            #line default
            #line hidden
        }
        
        [System.Diagnostics.DebuggerNonUserCodeAttribute()]
        [System.CodeDom.Compiler.GeneratedCodeAttribute("PresentationBuildTasks", "7.0.0.0")]
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Design", "CA1033:InterfaceMethodsShouldBeCallableByChildTypes")]
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Maintainability", "CA1502:AvoidExcessiveComplexity")]
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1800:DoNotCastUnnecessarily")]
        void System.Windows.Markup.IComponentConnector.Connect(int connectionId, object target) {
            switch (connectionId)
            {
            case 1:
            this.CloseCommand = ((System.Windows.Input.CommandBinding)(target));
            
            #line 23 "..\..\..\..\..\MVVM\Views\ShellView.xaml"
            this.CloseCommand.CanExecute += new System.Windows.Input.CanExecuteRoutedEventHandler(this.CloseCommand_CanExecute);
            
            #line default
            #line hidden
            
            #line 24 "..\..\..\..\..\MVVM\Views\ShellView.xaml"
            this.CloseCommand.Executed += new System.Windows.Input.ExecutedRoutedEventHandler(this.CloseCommand_Executed);
            
            #line default
            #line hidden
            return;
            case 2:
            this.MinCommand = ((System.Windows.Input.CommandBinding)(target));
            
            #line 27 "..\..\..\..\..\MVVM\Views\ShellView.xaml"
            this.MinCommand.CanExecute += new System.Windows.Input.CanExecuteRoutedEventHandler(this.MinCommand_CanExecute);
            
            #line default
            #line hidden
            
            #line 28 "..\..\..\..\..\MVVM\Views\ShellView.xaml"
            this.MinCommand.Executed += new System.Windows.Input.ExecutedRoutedEventHandler(this.MinCommand_Executed);
            
            #line default
            #line hidden
            return;
            case 3:
            this.MaxCommand = ((System.Windows.Input.CommandBinding)(target));
            
            #line 31 "..\..\..\..\..\MVVM\Views\ShellView.xaml"
            this.MaxCommand.CanExecute += new System.Windows.Input.CanExecuteRoutedEventHandler(this.MaxCommand_CanExecute);
            
            #line default
            #line hidden
            
            #line 32 "..\..\..\..\..\MVVM\Views\ShellView.xaml"
            this.MaxCommand.Executed += new System.Windows.Input.ExecutedRoutedEventHandler(this.MaxCommand_Executed);
            
            #line default
            #line hidden
            return;
            case 4:
            
            #line 44 "..\..\..\..\..\MVVM\Views\ShellView.xaml"
            ((System.Windows.Controls.Border)(target)).MouseDown += new System.Windows.Input.MouseButtonEventHandler(this.Grid_MouseDown);
            
            #line default
            #line hidden
            return;
            }
            this._contentLoaded = true;
        }
    }
}

