﻿#pragma checksum "..\..\..\..\..\MVVM\Views\RootView.xaml" "{ff1816ec-aa5e-4d10-87f7-6f4963833460}" "A3CF4767F4D3FF57FB9B9CA5A4F67240E2791650"
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
using Microsoft.Xaml.Behaviors;
using Microsoft.Xaml.Behaviors.Core;
using Microsoft.Xaml.Behaviors.Input;
using Microsoft.Xaml.Behaviors.Layout;
using Microsoft.Xaml.Behaviors.Media;
using System;
using System.Diagnostics;
using System.Windows;
using System.Windows.Automation;
using System.Windows.Controls;
using System.Windows.Controls.Primitives;
using System.Windows.Controls.Ribbon;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Forms.Integration;
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
using Tonvo.MVVM.Models;
using Tonvo.ViewModels;


namespace Tonvo.Views {
    
    
    /// <summary>
    /// RootView
    /// </summary>
    public partial class RootView : System.Windows.Controls.Page, System.Windows.Markup.IComponentConnector {
        
        
        #line 32 "..\..\..\..\..\MVVM\Views\RootView.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.TextBlock titleList;
        
        #line default
        #line hidden
        
        
        #line 36 "..\..\..\..\..\MVVM\Views\RootView.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.ListView ListVacancies;
        
        #line default
        #line hidden
        
        
        #line 54 "..\..\..\..\..\MVVM\Views\RootView.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.ComboBox listSelection;
        
        #line default
        #line hidden
        
        
        #line 62 "..\..\..\..\..\MVVM\Views\RootView.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.ComboBoxItem cbVacancy;
        
        #line default
        #line hidden
        
        
        #line 63 "..\..\..\..\..\MVVM\Views\RootView.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.ComboBoxItem cbApplicant;
        
        #line default
        #line hidden
        
        
        #line 71 "..\..\..\..\..\MVVM\Views\RootView.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal MaterialDesignThemes.Wpf.DialogHost dialogHost;
        
        #line default
        #line hidden
        
        
        #line 79 "..\..\..\..\..\MVVM\Views\RootView.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.Button btnRegistration;
        
        #line default
        #line hidden
        
        
        #line 92 "..\..\..\..\..\MVVM\Views\RootView.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.ComboBoxItem cbApplicantDh;
        
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
            System.Uri resourceLocater = new System.Uri("/Tonvo;component/mvvm/views/rootview.xaml", System.UriKind.Relative);
            
            #line 1 "..\..\..\..\..\MVVM\Views\RootView.xaml"
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
            this.titleList = ((System.Windows.Controls.TextBlock)(target));
            return;
            case 2:
            this.ListVacancies = ((System.Windows.Controls.ListView)(target));
            return;
            case 3:
            this.listSelection = ((System.Windows.Controls.ComboBox)(target));
            return;
            case 4:
            this.cbVacancy = ((System.Windows.Controls.ComboBoxItem)(target));
            return;
            case 5:
            this.cbApplicant = ((System.Windows.Controls.ComboBoxItem)(target));
            return;
            case 6:
            this.dialogHost = ((MaterialDesignThemes.Wpf.DialogHost)(target));
            return;
            case 7:
            this.btnRegistration = ((System.Windows.Controls.Button)(target));
            return;
            case 8:
            this.cbApplicantDh = ((System.Windows.Controls.ComboBoxItem)(target));
            return;
            }
            this._contentLoaded = true;
        }
    }
}

