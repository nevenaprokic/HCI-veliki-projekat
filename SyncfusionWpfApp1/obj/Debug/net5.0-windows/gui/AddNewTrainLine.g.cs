﻿#pragma checksum "..\..\..\..\gui\AddNewTrainLine.xaml" "{ff1816ec-aa5e-4d10-87f7-6f4963833460}" "76785EC32307F318EDE36F50F19681BA8AD01DD3"
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
    /// AddNewTrainLine
    /// </summary>
    public partial class AddNewTrainLine : System.Windows.Controls.Page, System.Windows.Markup.IComponentConnector {
        
        
        #line 58 "..\..\..\..\gui\AddNewTrainLine.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.Button helpButton;
        
        #line default
        #line hidden
        
        
        #line 61 "..\..\..\..\gui\AddNewTrainLine.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.Image helpIcon;
        
        #line default
        #line hidden
        
        
        #line 67 "..\..\..\..\gui\AddNewTrainLine.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.Button videoButton;
        
        #line default
        #line hidden
        
        
        #line 75 "..\..\..\..\gui\AddNewTrainLine.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.Grid LayoutRoot;
        
        #line default
        #line hidden
        
        
        #line 76 "..\..\..\..\gui\AddNewTrainLine.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal Microsoft.Maps.MapControl.WPF.Map MainMap;
        
        #line default
        #line hidden
        
        
        #line 80 "..\..\..\..\gui\AddNewTrainLine.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.ProgressBar LoadingBar;
        
        #line default
        #line hidden
        
        
        #line 145 "..\..\..\..\gui\AddNewTrainLine.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.Button Yes;
        
        #line default
        #line hidden
        
        
        #line 160 "..\..\..\..\gui\AddNewTrainLine.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.Button No;
        
        #line default
        #line hidden
        
        
        #line 178 "..\..\..\..\gui\AddNewTrainLine.xaml"
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
            System.Uri resourceLocater = new System.Uri("/SyncfusionWpfApp1;component/gui/addnewtrainline.xaml", System.UriKind.Relative);
            
            #line 1 "..\..\..\..\gui\AddNewTrainLine.xaml"
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
            this.helpButton = ((System.Windows.Controls.Button)(target));
            return;
            case 2:
            this.helpIcon = ((System.Windows.Controls.Image)(target));
            return;
            case 3:
            this.videoButton = ((System.Windows.Controls.Button)(target));
            
            #line 67 "..\..\..\..\gui\AddNewTrainLine.xaml"
            this.videoButton.Click += new System.Windows.RoutedEventHandler(this.playVideoHandler);
            
            #line default
            #line hidden
            return;
            case 4:
            this.LayoutRoot = ((System.Windows.Controls.Grid)(target));
            return;
            case 5:
            this.MainMap = ((Microsoft.Maps.MapControl.WPF.Map)(target));
            
            #line 76 "..\..\..\..\gui\AddNewTrainLine.xaml"
            this.MainMap.DragEnter += new System.Windows.DragEventHandler(this.ListView_DragEnter);
            
            #line default
            #line hidden
            
            #line 76 "..\..\..\..\gui\AddNewTrainLine.xaml"
            this.MainMap.Drop += new System.Windows.DragEventHandler(this.ListView_Drop);
            
            #line default
            #line hidden
            return;
            case 6:
            this.LoadingBar = ((System.Windows.Controls.ProgressBar)(target));
            return;
            case 7:
            
            #line 102 "..\..\..\..\gui\AddNewTrainLine.xaml"
            ((System.Windows.Controls.Button)(target)).Click += new System.Windows.RoutedEventHandler(this.CalculateRouteBtn_Clicked);
            
            #line default
            #line hidden
            return;
            case 8:
            
            #line 116 "..\..\..\..\gui\AddNewTrainLine.xaml"
            ((System.Windows.Controls.Button)(target)).Click += new System.Windows.RoutedEventHandler(this.AddTrain_Handler);
            
            #line default
            #line hidden
            return;
            case 9:
            
            #line 130 "..\..\..\..\gui\AddNewTrainLine.xaml"
            ((System.Windows.Controls.Button)(target)).Click += new System.Windows.RoutedEventHandler(this.CreateSchedule_Handler);
            
            #line default
            #line hidden
            return;
            case 10:
            this.Yes = ((System.Windows.Controls.Button)(target));
            
            #line 145 "..\..\..\..\gui\AddNewTrainLine.xaml"
            this.Yes.Click += new System.Windows.RoutedEventHandler(this.Save_Handler);
            
            #line default
            #line hidden
            return;
            case 11:
            this.No = ((System.Windows.Controls.Button)(target));
            
            #line 160 "..\..\..\..\gui\AddNewTrainLine.xaml"
            this.No.Click += new System.Windows.RoutedEventHandler(this.GoBack_Handler);
            
            #line default
            #line hidden
            return;
            case 12:
            this.img1 = ((System.Windows.Controls.Image)(target));
            
            #line 178 "..\..\..\..\gui\AddNewTrainLine.xaml"
            this.img1.PreviewMouseLeftButtonDown += new System.Windows.Input.MouseButtonEventHandler(this.ListView_PreviewMouseLeftButtonDown);
            
            #line default
            #line hidden
            
            #line 178 "..\..\..\..\gui\AddNewTrainLine.xaml"
            this.img1.MouseMove += new System.Windows.Input.MouseEventHandler(this.Image_MouseMove);
            
            #line default
            #line hidden
            return;
            }
            this._contentLoaded = true;
        }
    }
}

