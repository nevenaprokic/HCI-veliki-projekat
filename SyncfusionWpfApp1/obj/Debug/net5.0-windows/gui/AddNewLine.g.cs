﻿#pragma checksum "..\..\..\..\gui\AddNewLine.xaml" "{ff1816ec-aa5e-4d10-87f7-6f4963833460}" "206C81C8FF9D1F50523AB950C43F690B84380F35"
//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated by a tool.
//     Runtime Version:4.0.30319.42000
//
//     Changes to this file may cause incorrect behavior and will be lost if
//     the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------

using Microsoft.Maps.MapControl.WPF;
using SyncfusionWpfApp1.gui;
using SyncfusionWpfApp1.help;
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


namespace SyncfusionWpfApp1.gui {
    
    
    /// <summary>
    /// AddNewLine
    /// </summary>
    public partial class AddNewLine : System.Windows.Window, System.Windows.Markup.IComponentConnector {
        
        
        #line 69 "..\..\..\..\gui\AddNewLine.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.Button helpButton;
        
        #line default
        #line hidden
        
        
        #line 72 "..\..\..\..\gui\AddNewLine.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.Image helpIcon;
        
        #line default
        #line hidden
        
        
        #line 78 "..\..\..\..\gui\AddNewLine.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.Button videoButton;
        
        #line default
        #line hidden
        
        
        #line 86 "..\..\..\..\gui\AddNewLine.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.Grid LayoutRoot;
        
        #line default
        #line hidden
        
        
        #line 87 "..\..\..\..\gui\AddNewLine.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal Microsoft.Maps.MapControl.WPF.Map MainMap;
        
        #line default
        #line hidden
        
        
        #line 91 "..\..\..\..\gui\AddNewLine.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.ProgressBar LoadingBar;
        
        #line default
        #line hidden
        
        
        #line 115 "..\..\..\..\gui\AddNewLine.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.ComboBox comboLines;
        
        #line default
        #line hidden
        
        
        #line 126 "..\..\..\..\gui\AddNewLine.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.Button Yes;
        
        #line default
        #line hidden
        
        
        #line 140 "..\..\..\..\gui\AddNewLine.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.Button No;
        
        #line default
        #line hidden
        
        
        #line 158 "..\..\..\..\gui\AddNewLine.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.Image img1;
        
        #line default
        #line hidden
        
        private bool _contentLoaded;
        
        /// <summary>
        /// InitializeComponent
        /// </summary>
        [System.Diagnostics.DebuggerNonUserCodeAttribute()]
        [System.CodeDom.Compiler.GeneratedCodeAttribute("PresentationBuildTasks", "5.0.2.0")]
        public void InitializeComponent() {
            if (_contentLoaded) {
                return;
            }
            _contentLoaded = true;
            System.Uri resourceLocater = new System.Uri("/SyncfusionWpfApp1;component/gui/addnewline.xaml", System.UriKind.Relative);
            
            #line 1 "..\..\..\..\gui\AddNewLine.xaml"
            System.Windows.Application.LoadComponent(this, resourceLocater);
            
            #line default
            #line hidden
        }
        
        [System.Diagnostics.DebuggerNonUserCodeAttribute()]
        [System.CodeDom.Compiler.GeneratedCodeAttribute("PresentationBuildTasks", "5.0.2.0")]
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1811:AvoidUncalledPrivateCode")]
        internal System.Delegate _CreateDelegate(System.Type delegateType, string handler) {
            return System.Delegate.CreateDelegate(delegateType, this, handler);
        }
        
        [System.Diagnostics.DebuggerNonUserCodeAttribute()]
        [System.CodeDom.Compiler.GeneratedCodeAttribute("PresentationBuildTasks", "5.0.2.0")]
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Design", "CA1033:InterfaceMethodsShouldBeCallableByChildTypes")]
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Maintainability", "CA1502:AvoidExcessiveComplexity")]
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1800:DoNotCastUnnecessarily")]
        void System.Windows.Markup.IComponentConnector.Connect(int connectionId, object target) {
            switch (connectionId)
            {
            case 1:
            
            #line 20 "..\..\..\..\gui\AddNewLine.xaml"
            ((System.Windows.Input.CommandBinding)(target)).Executed += new System.Windows.Input.ExecutedRoutedEventHandler(this.CommandBinding_Executed);
            
            #line default
            #line hidden
            return;
            case 2:
            this.helpButton = ((System.Windows.Controls.Button)(target));
            return;
            case 3:
            this.helpIcon = ((System.Windows.Controls.Image)(target));
            return;
            case 4:
            this.videoButton = ((System.Windows.Controls.Button)(target));
            
            #line 78 "..\..\..\..\gui\AddNewLine.xaml"
            this.videoButton.Click += new System.Windows.RoutedEventHandler(this.playVideoHandler);
            
            #line default
            #line hidden
            return;
            case 5:
            this.LayoutRoot = ((System.Windows.Controls.Grid)(target));
            return;
            case 6:
            this.MainMap = ((Microsoft.Maps.MapControl.WPF.Map)(target));
            
            #line 87 "..\..\..\..\gui\AddNewLine.xaml"
            this.MainMap.DragEnter += new System.Windows.DragEventHandler(this.ListView_DragEnter);
            
            #line default
            #line hidden
            
            #line 87 "..\..\..\..\gui\AddNewLine.xaml"
            this.MainMap.Drop += new System.Windows.DragEventHandler(this.ListView_Drop);
            
            #line default
            #line hidden
            return;
            case 7:
            this.LoadingBar = ((System.Windows.Controls.ProgressBar)(target));
            return;
            case 8:
            this.comboLines = ((System.Windows.Controls.ComboBox)(target));
            return;
            case 9:
            this.Yes = ((System.Windows.Controls.Button)(target));
            
            #line 126 "..\..\..\..\gui\AddNewLine.xaml"
            this.Yes.Click += new System.Windows.RoutedEventHandler(this.Save_Handler);
            
            #line default
            #line hidden
            return;
            case 10:
            this.No = ((System.Windows.Controls.Button)(target));
            
            #line 140 "..\..\..\..\gui\AddNewLine.xaml"
            this.No.Click += new System.Windows.RoutedEventHandler(this.GoBack_Handler);
            
            #line default
            #line hidden
            return;
            case 11:
            this.img1 = ((System.Windows.Controls.Image)(target));
            
            #line 158 "..\..\..\..\gui\AddNewLine.xaml"
            this.img1.PreviewMouseLeftButtonDown += new System.Windows.Input.MouseButtonEventHandler(this.ListView_PreviewMouseLeftButtonDown);
            
            #line default
            #line hidden
            
            #line 158 "..\..\..\..\gui\AddNewLine.xaml"
            this.img1.MouseMove += new System.Windows.Input.MouseEventHandler(this.Image_MouseMove);
            
            #line default
            #line hidden
            return;
            }
            this._contentLoaded = true;
        }
    }
}

