#pragma checksum "..\..\..\..\gui\CreatePoint.xaml" "{ff1816ec-aa5e-4d10-87f7-6f4963833460}" "DB6296DB7DC5FC08E044CCC9F0B104352CA245E3"
//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated by a tool.
//     Runtime Version:4.0.30319.42000
//
//     Changes to this file may cause incorrect behavior and will be lost if
//     the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------

using SyncfusionWpfApp1.gui;
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
    /// CreatePoint
    /// </summary>
    public partial class CreatePoint : System.Windows.Window, System.Windows.Markup.IComponentConnector {
        
        
        #line 60 "..\..\..\..\gui\CreatePoint.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.TextBlock headline;
        
        #line default
        #line hidden
        
        
        #line 67 "..\..\..\..\gui\CreatePoint.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.Label addressLabel;
        
        #line default
        #line hidden
        
        
        #line 71 "..\..\..\..\gui\CreatePoint.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.Label priceLbl;
        
        #line default
        #line hidden
        
        
        #line 74 "..\..\..\..\gui\CreatePoint.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.TextBox price;
        
        #line default
        #line hidden
        
        
        #line 81 "..\..\..\..\gui\CreatePoint.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.Label priceValidationLabel;
        
        #line default
        #line hidden
        
        
        #line 84 "..\..\..\..\gui\CreatePoint.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.Label intervalLbl;
        
        #line default
        #line hidden
        
        
        #line 88 "..\..\..\..\gui\CreatePoint.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.TextBox intervalTextBox;
        
        #line default
        #line hidden
        
        
        #line 97 "..\..\..\..\gui\CreatePoint.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.Label intervalValidationLabel;
        
        #line default
        #line hidden
        
        
        #line 102 "..\..\..\..\gui\CreatePoint.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.Button Yes;
        
        #line default
        #line hidden
        
        
        #line 113 "..\..\..\..\gui\CreatePoint.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.Button No;
        
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
            System.Uri resourceLocater = new System.Uri("/SyncfusionWpfApp1;component/gui/createpoint.xaml", System.UriKind.Relative);
            
            #line 1 "..\..\..\..\gui\CreatePoint.xaml"
            System.Windows.Application.LoadComponent(this, resourceLocater);
            
            #line default
            #line hidden
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
            this.headline = ((System.Windows.Controls.TextBlock)(target));
            return;
            case 2:
            this.addressLabel = ((System.Windows.Controls.Label)(target));
            return;
            case 3:
            this.priceLbl = ((System.Windows.Controls.Label)(target));
            return;
            case 4:
            this.price = ((System.Windows.Controls.TextBox)(target));
            
            #line 74 "..\..\..\..\gui\CreatePoint.xaml"
            this.price.PreviewTextInput += new System.Windows.Input.TextCompositionEventHandler(this.NumberValidationTextBox);
            
            #line default
            #line hidden
            return;
            case 5:
            this.priceValidationLabel = ((System.Windows.Controls.Label)(target));
            return;
            case 6:
            this.intervalLbl = ((System.Windows.Controls.Label)(target));
            return;
            case 7:
            this.intervalTextBox = ((System.Windows.Controls.TextBox)(target));
            
            #line 88 "..\..\..\..\gui\CreatePoint.xaml"
            this.intervalTextBox.PreviewTextInput += new System.Windows.Input.TextCompositionEventHandler(this.NumberValidationTextBox);
            
            #line default
            #line hidden
            return;
            case 8:
            this.intervalValidationLabel = ((System.Windows.Controls.Label)(target));
            return;
            case 9:
            this.Yes = ((System.Windows.Controls.Button)(target));
            
            #line 102 "..\..\..\..\gui\CreatePoint.xaml"
            this.Yes.Click += new System.Windows.RoutedEventHandler(this.Save_Handler);
            
            #line default
            #line hidden
            return;
            case 10:
            this.No = ((System.Windows.Controls.Button)(target));
            
            #line 113 "..\..\..\..\gui\CreatePoint.xaml"
            this.No.Click += new System.Windows.RoutedEventHandler(this.GoBack_Handler);
            
            #line default
            #line hidden
            return;
            }
            this._contentLoaded = true;
        }
    }
}

