﻿#pragma checksum "..\..\..\..\Windows\MainWindow.xaml" "{8829d00f-11b8-4213-878b-770e8597ac16}" "206DB915A81D4DD20A8323BF3B6B2340A48EE04114C10B39A10E1E07A397DE47"
//------------------------------------------------------------------------------
// <auto-generated>
//     此代码由工具生成。
//     运行时版本:4.0.30319.42000
//
//     对此文件的更改可能会导致不正确的行为，并且如果
//     重新生成代码，这些更改将会丢失。
// </auto-generated>
//------------------------------------------------------------------------------

using DDLM;
using MaterialDesignThemes.Wpf;
using MaterialDesignThemes.Wpf.Converters;
using MaterialDesignThemes.Wpf.Transitions;
using System;
using System.Diagnostics;
using System.Windows;
using System.Windows.Automation;
using System.Windows.Controls;
using System.Windows.Controls.Primitives;
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


namespace DDLM {
    
    
    /// <summary>
    /// MainWindow
    /// </summary>
    public partial class MainWindow : System.Windows.Window, System.Windows.Markup.IComponentConnector {
        
        
        #line 22 "..\..\..\..\Windows\MainWindow.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.Frame MainFrame;
        
        #line default
        #line hidden
        
        
        #line 31 "..\..\..\..\Windows\MainWindow.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.RadioButton DdlPageBtn;
        
        #line default
        #line hidden
        
        
        #line 43 "..\..\..\..\Windows\MainWindow.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal MaterialDesignThemes.Wpf.PackIcon DdlsIcon;
        
        #line default
        #line hidden
        
        
        #line 56 "..\..\..\..\Windows\MainWindow.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.TextBlock DdlsTextBlock;
        
        #line default
        #line hidden
        
        
        #line 70 "..\..\..\..\Windows\MainWindow.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.RadioButton SettingPageBtn;
        
        #line default
        #line hidden
        
        
        #line 81 "..\..\..\..\Windows\MainWindow.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal MaterialDesignThemes.Wpf.PackIcon SettingIcon;
        
        #line default
        #line hidden
        
        
        #line 94 "..\..\..\..\Windows\MainWindow.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.TextBlock SettingTextBlock;
        
        #line default
        #line hidden
        
        
        #line 107 "..\..\..\..\Windows\MainWindow.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.RadioButton InfoPageBtn;
        
        #line default
        #line hidden
        
        
        #line 118 "..\..\..\..\Windows\MainWindow.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal MaterialDesignThemes.Wpf.PackIcon InfoIcon;
        
        #line default
        #line hidden
        
        
        #line 131 "..\..\..\..\Windows\MainWindow.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.TextBlock InfoTextBlock;
        
        #line default
        #line hidden
        
        private bool _contentLoaded;
        
        /// <summary>
        /// InitializeComponent
        /// </summary>
        [System.Diagnostics.DebuggerNonUserCodeAttribute()]
        [System.CodeDom.Compiler.GeneratedCodeAttribute("PresentationBuildTasks", "4.0.0.0")]
        public void InitializeComponent() {
            if (_contentLoaded) {
                return;
            }
            _contentLoaded = true;
            System.Uri resourceLocater = new System.Uri("/DDLM;component/windows/mainwindow.xaml", System.UriKind.Relative);
            
            #line 1 "..\..\..\..\Windows\MainWindow.xaml"
            System.Windows.Application.LoadComponent(this, resourceLocater);
            
            #line default
            #line hidden
        }
        
        [System.Diagnostics.DebuggerNonUserCodeAttribute()]
        [System.CodeDom.Compiler.GeneratedCodeAttribute("PresentationBuildTasks", "4.0.0.0")]
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Design", "CA1033:InterfaceMethodsShouldBeCallableByChildTypes")]
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Maintainability", "CA1502:AvoidExcessiveComplexity")]
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1800:DoNotCastUnnecessarily")]
        void System.Windows.Markup.IComponentConnector.Connect(int connectionId, object target) {
            switch (connectionId)
            {
            case 1:
            this.MainFrame = ((System.Windows.Controls.Frame)(target));
            return;
            case 2:
            this.DdlPageBtn = ((System.Windows.Controls.RadioButton)(target));
            
            #line 34 "..\..\..\..\Windows\MainWindow.xaml"
            this.DdlPageBtn.Checked += new System.Windows.RoutedEventHandler(this.DdlPageBtn_Checked);
            
            #line default
            #line hidden
            
            #line 35 "..\..\..\..\Windows\MainWindow.xaml"
            this.DdlPageBtn.Unchecked += new System.Windows.RoutedEventHandler(this.DdlPageBtn_Unchecked);
            
            #line default
            #line hidden
            return;
            case 3:
            this.DdlsIcon = ((MaterialDesignThemes.Wpf.PackIcon)(target));
            return;
            case 4:
            this.DdlsTextBlock = ((System.Windows.Controls.TextBlock)(target));
            return;
            case 5:
            this.SettingPageBtn = ((System.Windows.Controls.RadioButton)(target));
            
            #line 72 "..\..\..\..\Windows\MainWindow.xaml"
            this.SettingPageBtn.Checked += new System.Windows.RoutedEventHandler(this.SettingPageBtn_Checked);
            
            #line default
            #line hidden
            
            #line 73 "..\..\..\..\Windows\MainWindow.xaml"
            this.SettingPageBtn.Unchecked += new System.Windows.RoutedEventHandler(this.SettingPageBtn_Unchecked);
            
            #line default
            #line hidden
            return;
            case 6:
            this.SettingIcon = ((MaterialDesignThemes.Wpf.PackIcon)(target));
            return;
            case 7:
            this.SettingTextBlock = ((System.Windows.Controls.TextBlock)(target));
            return;
            case 8:
            this.InfoPageBtn = ((System.Windows.Controls.RadioButton)(target));
            
            #line 109 "..\..\..\..\Windows\MainWindow.xaml"
            this.InfoPageBtn.Checked += new System.Windows.RoutedEventHandler(this.InfoPageBtn_Checked);
            
            #line default
            #line hidden
            
            #line 110 "..\..\..\..\Windows\MainWindow.xaml"
            this.InfoPageBtn.Unchecked += new System.Windows.RoutedEventHandler(this.InfoPageBtn_Unchecked);
            
            #line default
            #line hidden
            return;
            case 9:
            this.InfoIcon = ((MaterialDesignThemes.Wpf.PackIcon)(target));
            return;
            case 10:
            this.InfoTextBlock = ((System.Windows.Controls.TextBlock)(target));
            return;
            }
            this._contentLoaded = true;
        }
    }
}
