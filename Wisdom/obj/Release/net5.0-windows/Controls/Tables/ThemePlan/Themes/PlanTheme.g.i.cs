// Updated by XamlIntelliSenseFileGenerator 07.08.2022 19:21:21
#pragma checksum "..\..\..\..\..\..\..\Controls\Tables\ThemePlan\Themes\PlanTheme.xaml" "{ff1816ec-aa5e-4d10-87f7-6f4963833460}" "5B4EA38C5E98C4E82B8CFAE1F94D9617B77D2148"
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
using Wisdom.Binds.Converters;
using Wisdom.Controls.Tables.ThemePlan.Themes.Works;


namespace Wisdom.Controls.Tables.ThemePlan.Themes
{


    /// <summary>
    /// PlanTheme
    /// </summary>
    public partial class PlanTheme : System.Windows.Controls.UserControl, System.Windows.Markup.IComponentConnector
    {

#line default
#line hidden

        private bool _contentLoaded;

        /// <summary>
        /// InitializeComponent
        /// </summary>
        [System.Diagnostics.DebuggerNonUserCodeAttribute()]
        [System.CodeDom.Compiler.GeneratedCodeAttribute("PresentationBuildTasks", "5.0.15.0")]
        public void InitializeComponent()
        {
            if (_contentLoaded)
            {
                return;
            }
            _contentLoaded = true;
            System.Uri resourceLocater = new System.Uri("/Wisdom;component/controls/tables/themeplan/themes/plantheme.xaml", System.UriKind.Relative);

#line 1 "..\..\..\..\..\..\..\Controls\Tables\ThemePlan\Themes\PlanTheme.xaml"
            System.Windows.Application.LoadComponent(this, resourceLocater);

#line default
#line hidden
        }

        [System.Diagnostics.DebuggerNonUserCodeAttribute()]
        [System.CodeDom.Compiler.GeneratedCodeAttribute("PresentationBuildTasks", "5.0.15.0")]
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Design", "CA1033:InterfaceMethodsShouldBeCallableByChildTypes")]
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Maintainability", "CA1502:AvoidExcessiveComplexity")]
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1800:DoNotCastUnnecessarily")]
        void System.Windows.Markup.IComponentConnector.Connect(int connectionId, object target)
        {
            switch (connectionId)
            {
                case 1:
                    this.This = ((Wisdom.Controls.Tables.ThemePlan.Themes.PlanTheme)(target));
                    return;
                case 2:

#line 38 "..\..\..\..\..\..\..\Controls\Tables\ThemePlan\Themes\PlanTheme.xaml"
                    ((System.Windows.Controls.Button)(target)).Click += new System.Windows.RoutedEventHandler(this.DropTheme);

#line default
#line hidden
                    return;
            }
            this._contentLoaded = true;
        }

        internal System.Windows.Controls.UserControl This;
    }
}

