﻿#pragma checksum "..\..\Modify.xaml" "{8829d00f-11b8-4213-878b-770e8597ac16}" "4971521A1DC347D0ED39336C6C7341EFBE7B0FE8308239B63A0E265CB241A237"
//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated by a tool.
//     Runtime Version:4.0.30319.42000
//
//     Changes to this file may cause incorrect behavior and will be lost if
//     the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------

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
using Tema1_dubla3;
using Xceed.Wpf.Toolkit;
using Xceed.Wpf.Toolkit.Chromes;
using Xceed.Wpf.Toolkit.Converters;
using Xceed.Wpf.Toolkit.Core;
using Xceed.Wpf.Toolkit.Core.Converters;
using Xceed.Wpf.Toolkit.Core.Input;
using Xceed.Wpf.Toolkit.Core.Media;
using Xceed.Wpf.Toolkit.Core.Utilities;
using Xceed.Wpf.Toolkit.Mag.Converters;
using Xceed.Wpf.Toolkit.Panels;
using Xceed.Wpf.Toolkit.Primitives;
using Xceed.Wpf.Toolkit.PropertyGrid;
using Xceed.Wpf.Toolkit.PropertyGrid.Attributes;
using Xceed.Wpf.Toolkit.PropertyGrid.Commands;
using Xceed.Wpf.Toolkit.PropertyGrid.Converters;
using Xceed.Wpf.Toolkit.PropertyGrid.Editors;
using Xceed.Wpf.Toolkit.Zoombox;


namespace Tema1_dubla3 {
    
    
    /// <summary>
    /// Modify
    /// </summary>
    public partial class Modify : System.Windows.Window, System.Windows.Markup.IComponentConnector {
        
        
        #line 15 "..\..\Modify.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.Image SelectedImage;
        
        #line default
        #line hidden
        
        
        #line 16 "..\..\Modify.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.TextBox Word;
        
        #line default
        #line hidden
        
        
        #line 17 "..\..\Modify.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.TextBox Category;
        
        #line default
        #line hidden
        
        
        #line 18 "..\..\Modify.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.TextBox Image;
        
        #line default
        #line hidden
        
        
        #line 19 "..\..\Modify.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.TextBox Meaning;
        
        #line default
        #line hidden
        
        
        #line 21 "..\..\Modify.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.TextBox SearchText;
        
        #line default
        #line hidden
        
        
        #line 23 "..\..\Modify.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.ListBox ListBox;
        
        #line default
        #line hidden
        
        
        #line 24 "..\..\Modify.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.Button Save;
        
        #line default
        #line hidden
        
        
        #line 25 "..\..\Modify.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.Button Back;
        
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
            System.Uri resourceLocater = new System.Uri("/Tema1_dubla3;component/modify.xaml", System.UriKind.Relative);
            
            #line 1 "..\..\Modify.xaml"
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
            this.SelectedImage = ((System.Windows.Controls.Image)(target));
            return;
            case 2:
            this.Word = ((System.Windows.Controls.TextBox)(target));
            
            #line 16 "..\..\Modify.xaml"
            this.Word.TextChanged += new System.Windows.Controls.TextChangedEventHandler(this.Word_TextChanged);
            
            #line default
            #line hidden
            return;
            case 3:
            this.Category = ((System.Windows.Controls.TextBox)(target));
            return;
            case 4:
            this.Image = ((System.Windows.Controls.TextBox)(target));
            return;
            case 5:
            this.Meaning = ((System.Windows.Controls.TextBox)(target));
            
            #line 19 "..\..\Modify.xaml"
            this.Meaning.TextChanged += new System.Windows.Controls.TextChangedEventHandler(this.Meaning_TextChanged);
            
            #line default
            #line hidden
            return;
            case 6:
            this.SearchText = ((System.Windows.Controls.TextBox)(target));
            
            #line 21 "..\..\Modify.xaml"
            this.SearchText.TextChanged += new System.Windows.Controls.TextChangedEventHandler(this.SearchText_TextChanged);
            
            #line default
            #line hidden
            
            #line 21 "..\..\Modify.xaml"
            this.SearchText.PreviewKeyDown += new System.Windows.Input.KeyEventHandler(this.SearchText_PreviewKeyDown);
            
            #line default
            #line hidden
            return;
            case 7:
            
            #line 22 "..\..\Modify.xaml"
            ((System.Windows.Controls.Button)(target)).Click += new System.Windows.RoutedEventHandler(this.SearchButton_Click);
            
            #line default
            #line hidden
            return;
            case 8:
            this.ListBox = ((System.Windows.Controls.ListBox)(target));
            
            #line 23 "..\..\Modify.xaml"
            this.ListBox.SelectionChanged += new System.Windows.Controls.SelectionChangedEventHandler(this.ListBox_SelectionChanged_2);
            
            #line default
            #line hidden
            return;
            case 9:
            this.Save = ((System.Windows.Controls.Button)(target));
            
            #line 24 "..\..\Modify.xaml"
            this.Save.Click += new System.Windows.RoutedEventHandler(this.Save_Click);
            
            #line default
            #line hidden
            return;
            case 10:
            this.Back = ((System.Windows.Controls.Button)(target));
            
            #line 25 "..\..\Modify.xaml"
            this.Back.Click += new System.Windows.RoutedEventHandler(this.Back_Click);
            
            #line default
            #line hidden
            return;
            }
            this._contentLoaded = true;
        }
    }
}

