﻿#pragma checksum "..\..\..\Views\SignUpWindow.xaml" "{8829d00f-11b8-4213-878b-770e8597ac16}" "3C21817BB105A1AE6857D4DC08887279F8AA207DF50D5949B2C6F86D4B5BA9F8"
//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated by a tool.
//     Runtime Version:4.0.30319.42000
//
//     Changes to this file may cause incorrect behavior and will be lost if
//     the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------

using EmployeesSoftware.Views;
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


namespace EmployeesSoftware.Views {
    
    
    /// <summary>
    /// SignUpWindow
    /// </summary>
    public partial class SignUpWindow : System.Windows.Window, System.Windows.Markup.IComponentConnector {
        
        
        #line 11 "..\..\..\Views\SignUpWindow.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.Button btn_connexion_signup;
        
        #line default
        #line hidden
        
        
        #line 13 "..\..\..\Views\SignUpWindow.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.TextBox txt_inscription_code;
        
        #line default
        #line hidden
        
        
        #line 16 "..\..\..\Views\SignUpWindow.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.PasswordBox txt_password;
        
        #line default
        #line hidden
        
        
        #line 29 "..\..\..\Views\SignUpWindow.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.MenuItem menu_connexion_signup;
        
        #line default
        #line hidden
        
        
        #line 31 "..\..\..\Views\SignUpWindow.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.MenuItem menu_quitter_signup;
        
        #line default
        #line hidden
        
        
        #line 35 "..\..\..\Views\SignUpWindow.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.TextBox txt_username;
        
        #line default
        #line hidden
        
        
        #line 38 "..\..\..\Views\SignUpWindow.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.TextBox txt_name;
        
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
            System.Uri resourceLocater = new System.Uri("/EmployeesSoftware;component/views/signupwindow.xaml", System.UriKind.Relative);
            
            #line 1 "..\..\..\Views\SignUpWindow.xaml"
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
            this.btn_connexion_signup = ((System.Windows.Controls.Button)(target));
            
            #line 11 "..\..\..\Views\SignUpWindow.xaml"
            this.btn_connexion_signup.Click += new System.Windows.RoutedEventHandler(this.btn_connexion_signup_Click);
            
            #line default
            #line hidden
            return;
            case 2:
            this.txt_inscription_code = ((System.Windows.Controls.TextBox)(target));
            return;
            case 3:
            this.txt_password = ((System.Windows.Controls.PasswordBox)(target));
            return;
            case 4:
            this.menu_connexion_signup = ((System.Windows.Controls.MenuItem)(target));
            
            #line 29 "..\..\..\Views\SignUpWindow.xaml"
            this.menu_connexion_signup.Click += new System.Windows.RoutedEventHandler(this.menu_connexion_signup_Click);
            
            #line default
            #line hidden
            return;
            case 5:
            this.menu_quitter_signup = ((System.Windows.Controls.MenuItem)(target));
            
            #line 31 "..\..\..\Views\SignUpWindow.xaml"
            this.menu_quitter_signup.Click += new System.Windows.RoutedEventHandler(this.menu_quitter_signup_Click);
            
            #line default
            #line hidden
            return;
            case 6:
            this.txt_username = ((System.Windows.Controls.TextBox)(target));
            return;
            case 7:
            this.txt_name = ((System.Windows.Controls.TextBox)(target));
            return;
            }
            this._contentLoaded = true;
        }
    }
}

