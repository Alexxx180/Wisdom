﻿#pragma checksum "..\..\..\..\Controls\PlanThemeAdditor.xaml" "{ff1816ec-aa5e-4d10-87f7-6f4963833460}" "B2F56517CB5977AA0AAC01A153D1161C8AC9730C"
//------------------------------------------------------------------------------
// <auto-generated>
//     Этот код создан программой.
//     Исполняемая версия:4.0.30319.42000
//
//     Изменения в этом файле могут привести к неправильной работе и будут потеряны в случае
//     повторной генерации кода.
// </auto-generated>
//------------------------------------------------------------------------------

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
using Wisdom.Controls;


namespace Wisdom.Controls {
    
    
    /// <summary>
    /// PlanThemeAdditor
    /// </summary>
    public partial class PlanThemeAdditor : System.Windows.Controls.UserControl, System.Windows.Markup.IComponentConnector {
        
        
        #line 21 "..\..\..\..\Controls\PlanThemeAdditor.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.TextBlock ThemeNo;
        
        #line default
        #line hidden
        
        
        #line 23 "..\..\..\..\Controls\PlanThemeAdditor.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.TextBox ThemeName;
        
        #line default
        #line hidden
        
        
        #line 24 "..\..\..\..\Controls\PlanThemeAdditor.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.TextBox ThemeHours;
        
        #line default
        #line hidden
        
        
        #line 31 "..\..\..\..\Controls\PlanThemeAdditor.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.TextBox ThemeCompetetions;
        
        #line default
        #line hidden
        
        
        #line 32 "..\..\..\..\Controls\PlanThemeAdditor.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.ComboBox ThemeLevel;
        
        #line default
        #line hidden
        
        private bool _contentLoaded;
        
        /// <summary>
        /// InitializeComponent
        /// </summary>
        [System.Diagnostics.DebuggerNonUserCodeAttribute()]
        [System.CodeDom.Compiler.GeneratedCodeAttribute("PresentationBuildTasks", "5.0.6.0")]
        public void InitializeComponent() {
            if (_contentLoaded) {
                return;
            }
            _contentLoaded = true;
            System.Uri resourceLocater = new System.Uri("/Wisdom;component/controls/planthemeadditor.xaml", System.UriKind.Relative);
            
            #line 1 "..\..\..\..\Controls\PlanThemeAdditor.xaml"
            System.Windows.Application.LoadComponent(this, resourceLocater);
            
            #line default
            #line hidden
        }
        
        [System.Diagnostics.DebuggerNonUserCodeAttribute()]
        [System.CodeDom.Compiler.GeneratedCodeAttribute("PresentationBuildTasks", "5.0.6.0")]
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Design", "CA1033:InterfaceMethodsShouldBeCallableByChildTypes")]
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Maintainability", "CA1502:AvoidExcessiveComplexity")]
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1800:DoNotCastUnnecessarily")]
        void System.Windows.Markup.IComponentConnector.Connect(int connectionId, object target) {
            switch (connectionId)
            {
            case 1:
            
            #line 19 "..\..\..\..\Controls\PlanThemeAdditor.xaml"
            ((System.Windows.Controls.Button)(target)).Click += new System.Windows.RoutedEventHandler(this.AddTheme);
            
            #line default
            #line hidden
            return;
            case 2:
            this.ThemeNo = ((System.Windows.Controls.TextBlock)(target));
            return;
            case 3:
            this.ThemeName = ((System.Windows.Controls.TextBox)(target));
            return;
            case 4:
            this.ThemeHours = ((System.Windows.Controls.TextBox)(target));
            
            #line 24 "..\..\..\..\Controls\PlanThemeAdditor.xaml"
            this.ThemeHours.AddHandler(System.Windows.DataObject.PastingEvent, new System.Windows.DataObjectPastingEventHandler(this.PastingHours));
            
            #line default
            #line hidden
            
            #line 24 "..\..\..\..\Controls\PlanThemeAdditor.xaml"
            this.ThemeHours.PreviewTextInput += new System.Windows.Input.TextCompositionEventHandler(this.Hours);
            
            #line default
            #line hidden
            return;
            case 5:
            this.ThemeCompetetions = ((System.Windows.Controls.TextBox)(target));
            return;
            case 6:
            this.ThemeLevel = ((System.Windows.Controls.ComboBox)(target));
            return;
            }
            this._contentLoaded = true;
        }
    }
}

