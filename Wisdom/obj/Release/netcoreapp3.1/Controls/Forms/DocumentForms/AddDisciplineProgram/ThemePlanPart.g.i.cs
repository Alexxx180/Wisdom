﻿#pragma checksum "..\..\..\..\..\..\..\Controls\Forms\DocumentForms\AddDisciplineProgram\ThemePlanPart.xaml" "{ff1816ec-aa5e-4d10-87f7-6f4963833460}" "1E701CC0D20B47656F16E4294EDD35E4F2C815AA"
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
using Wisdom.Binds.Converters;
using Wisdom.Binds.Converters.Extractors;
using Wisdom.Controls.Forms;
using Wisdom.Controls.Tables;
using Wisdom.Controls.Tables.EducationLevels;
using Wisdom.Controls.Tables.ThemePlan;
using Wisdom.ViewModel;


namespace Wisdom.Controls.Forms.DocumentForms.AddDisciplineProgram {
    
    
    /// <summary>
    /// ThemePlanPart
    /// </summary>
    public partial class ThemePlanPart : System.Windows.Controls.UserControl, System.Windows.Markup.IComponentConnector {
        
        
        #line 22 "..\..\..\..\..\..\..\Controls\Forms\DocumentForms\AddDisciplineProgram\ThemePlanPart.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.Grid TreeContext;
        
        #line default
        #line hidden
        
        
        #line 48 "..\..\..\..\..\..\..\Controls\Forms\DocumentForms\AddDisciplineProgram\ThemePlanPart.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal Wisdom.ViewModel.SwitchGroup ThemePlanGroup;
        
        #line default
        #line hidden
        
        
        #line 87 "..\..\..\..\..\..\..\Controls\Forms\DocumentForms\AddDisciplineProgram\ThemePlanPart.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.Grid Plan;
        
        #line default
        #line hidden
        
        
        #line 167 "..\..\..\..\..\..\..\Controls\Forms\DocumentForms\AddDisciplineProgram\ThemePlanPart.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.Grid Levels;
        
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
            System.Uri resourceLocater = new System.Uri("/Wisdom;component/controls/forms/documentforms/adddisciplineprogram/themeplanpart" +
                    ".xaml", System.UriKind.Relative);
            
            #line 1 "..\..\..\..\..\..\..\Controls\Forms\DocumentForms\AddDisciplineProgram\ThemePlanPart.xaml"
            System.Windows.Application.LoadComponent(this, resourceLocater);
            
            #line default
            #line hidden
        }
        
        [System.Diagnostics.DebuggerNonUserCodeAttribute()]
        [System.CodeDom.Compiler.GeneratedCodeAttribute("PresentationBuildTasks", "5.0.6.0")]
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1811:AvoidUncalledPrivateCode")]
        internal System.Delegate _CreateDelegate(System.Type delegateType, string handler) {
            return System.Delegate.CreateDelegate(delegateType, this, handler);
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
            this.TreeContext = ((System.Windows.Controls.Grid)(target));
            return;
            case 2:
            this.ThemePlanGroup = ((Wisdom.ViewModel.SwitchGroup)(target));
            return;
            case 3:
            this.Plan = ((System.Windows.Controls.Grid)(target));
            return;
            case 4:
            this.Levels = ((System.Windows.Controls.Grid)(target));
            return;
            }
            this._contentLoaded = true;
        }
    }
}

