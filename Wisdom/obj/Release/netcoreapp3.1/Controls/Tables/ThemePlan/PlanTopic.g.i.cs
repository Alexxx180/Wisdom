﻿#pragma checksum "..\..\..\..\..\..\Controls\Tables\ThemePlan\PlanTopic.xaml" "{ff1816ec-aa5e-4d10-87f7-6f4963833460}" "DBD70B366488FCE8ED00ECD27378941A43D3DE0F"
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
using Wisdom.Controls.Tables.ThemePlan.Themes;


namespace Wisdom.Controls.Tables.ThemePlan {
    
    
    /// <summary>
    /// PlanTopic
    /// </summary>
    public partial class PlanTopic : System.Windows.Controls.UserControl, System.Windows.Markup.IComponentConnector {
        
        
        #line 9 "..\..\..\..\..\..\Controls\Tables\ThemePlan\PlanTopic.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal Wisdom.Controls.Tables.ThemePlan.PlanTopic This;
        
        #line default
        #line hidden
        
        
        #line 88 "..\..\..\..\..\..\Controls\Tables\ThemePlan\PlanTopic.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal Wisdom.Controls.Tables.ThemePlan.Themes.PlanThemeAdditor ThemeAdditor;
        
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
            System.Uri resourceLocater = new System.Uri("/Wisdom;component/controls/tables/themeplan/plantopic.xaml", System.UriKind.Relative);
            
            #line 1 "..\..\..\..\..\..\Controls\Tables\ThemePlan\PlanTopic.xaml"
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
            this.This = ((Wisdom.Controls.Tables.ThemePlan.PlanTopic)(target));
            return;
            case 2:
            
            #line 25 "..\..\..\..\..\..\Controls\Tables\ThemePlan\PlanTopic.xaml"
            ((System.Windows.Controls.Button)(target)).Click += new System.Windows.RoutedEventHandler(this.DropTopic);
            
            #line default
            #line hidden
            return;
            case 3:
            this.ThemeAdditor = ((Wisdom.Controls.Tables.ThemePlan.Themes.PlanThemeAdditor)(target));
            return;
            }
            this._contentLoaded = true;
        }
    }
}

