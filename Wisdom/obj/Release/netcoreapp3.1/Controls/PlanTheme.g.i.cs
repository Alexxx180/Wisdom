﻿#pragma checksum "..\..\..\..\Controls\PlanTheme.xaml" "{ff1816ec-aa5e-4d10-87f7-6f4963833460}" "95BB62923017CB8A0132393904BE64C608B6BE61"
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
    /// PlanTheme
    /// </summary>
    public partial class PlanTheme : System.Windows.Controls.UserControl, System.Windows.Markup.IComponentConnector {
        
        
        #line 26 "..\..\..\..\Controls\PlanTheme.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.TextBlock ThemeNo;
        
        #line default
        #line hidden
        
        
        #line 28 "..\..\..\..\Controls\PlanTheme.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.TextBox ThemeName;
        
        #line default
        #line hidden
        
        
        #line 29 "..\..\..\..\Controls\PlanTheme.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.TextBox ThemeHours;
        
        #line default
        #line hidden
        
        
        #line 36 "..\..\..\..\Controls\PlanTheme.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.TextBox ThemeCompetetions;
        
        #line default
        #line hidden
        
        
        #line 37 "..\..\..\..\Controls\PlanTheme.xaml"
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
            System.Uri resourceLocater = new System.Uri("/Wisdom;component/controls/plantheme.xaml", System.UriKind.Relative);
            
            #line 1 "..\..\..\..\Controls\PlanTheme.xaml"
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
            
            #line 24 "..\..\..\..\Controls\PlanTheme.xaml"
            ((System.Windows.Controls.Button)(target)).Click += new System.Windows.RoutedEventHandler(this.DropTheme);
            
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
            
            #line 29 "..\..\..\..\Controls\PlanTheme.xaml"
            this.ThemeHours.AddHandler(System.Windows.DataObject.PastingEvent, new System.Windows.DataObjectPastingEventHandler(this.PastingHours));
            
            #line default
            #line hidden
            
            #line 29 "..\..\..\..\Controls\PlanTheme.xaml"
            this.ThemeHours.PreviewTextInput += new System.Windows.Input.TextCompositionEventHandler(this.Hours);
            
            #line default
            #line hidden
            return;
            case 5:
            this.ThemeCompetetions = ((System.Windows.Controls.TextBox)(target));
            return;
            case 6:
            this.ThemeLevel = ((System.Windows.Controls.ComboBox)(target));
            
            #line 37 "..\..\..\..\Controls\PlanTheme.xaml"
            this.ThemeLevel.SelectionChanged += new System.Windows.Controls.SelectionChangedEventHandler(this.Levels_SelectionChanged);
            
            #line default
            #line hidden
            return;
            }
            this._contentLoaded = true;
        }
    }
}

