﻿#pragma checksum "..\..\..\pages\coupon.xaml" "{8829d00f-11b8-4213-878b-770e8597ac16}" "C765FBDABBA517AC734B90FAB4F732DA1869BD00582CEEB0965767EC13DA488C"
//------------------------------------------------------------------------------
// <auto-generated>
//     Этот код создан программой.
//     Исполняемая версия:4.0.30319.42000
//
//     Изменения в этом файле могут привести к неправильной работе и будут потеряны в случае
//     повторной генерации кода.
// </auto-generated>
//------------------------------------------------------------------------------

using MaterialDesignThemes.Wpf;
using MaterialDesignThemes.Wpf.Converters;
using MaterialDesignThemes.Wpf.Transitions;
using RestaurantBooking.pages;
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


namespace RestaurantBooking.pages {
    
    
    /// <summary>
    /// coupon
    /// </summary>
    public partial class coupon : System.Windows.Controls.Page, System.Windows.Markup.IComponentConnector {
        
        
        #line 16 "..\..\..\pages\coupon.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.DataGrid dgCoupon;
        
        #line default
        #line hidden
        
        
        #line 31 "..\..\..\pages\coupon.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.MenuItem miAdd;
        
        #line default
        #line hidden
        
        
        #line 32 "..\..\..\pages\coupon.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.MenuItem miEdit;
        
        #line default
        #line hidden
        
        
        #line 33 "..\..\..\pages\coupon.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.MenuItem miDelete;
        
        #line default
        #line hidden
        
        
        #line 39 "..\..\..\pages\coupon.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.RadioButton rbId;
        
        #line default
        #line hidden
        
        
        #line 40 "..\..\..\pages\coupon.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.RadioButton rbName;
        
        #line default
        #line hidden
        
        
        #line 42 "..\..\..\pages\coupon.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.TextBox tbSearch;
        
        #line default
        #line hidden
        
        
        #line 44 "..\..\..\pages\coupon.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.Slider slider;
        
        #line default
        #line hidden
        
        
        #line 45 "..\..\..\pages\coupon.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.Label lbSlider;
        
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
            System.Uri resourceLocater = new System.Uri("/RestaurantBooking;component/pages/coupon.xaml", System.UriKind.Relative);
            
            #line 1 "..\..\..\pages\coupon.xaml"
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
            this.dgCoupon = ((System.Windows.Controls.DataGrid)(target));
            return;
            case 2:
            this.miAdd = ((System.Windows.Controls.MenuItem)(target));
            
            #line 31 "..\..\..\pages\coupon.xaml"
            this.miAdd.Click += new System.Windows.RoutedEventHandler(this.miAdd_Click);
            
            #line default
            #line hidden
            return;
            case 3:
            this.miEdit = ((System.Windows.Controls.MenuItem)(target));
            
            #line 32 "..\..\..\pages\coupon.xaml"
            this.miEdit.Click += new System.Windows.RoutedEventHandler(this.miEdit_Click);
            
            #line default
            #line hidden
            return;
            case 4:
            this.miDelete = ((System.Windows.Controls.MenuItem)(target));
            
            #line 33 "..\..\..\pages\coupon.xaml"
            this.miDelete.Click += new System.Windows.RoutedEventHandler(this.miDelete_Click);
            
            #line default
            #line hidden
            return;
            case 5:
            this.rbId = ((System.Windows.Controls.RadioButton)(target));
            return;
            case 6:
            this.rbName = ((System.Windows.Controls.RadioButton)(target));
            return;
            case 7:
            this.tbSearch = ((System.Windows.Controls.TextBox)(target));
            
            #line 42 "..\..\..\pages\coupon.xaml"
            this.tbSearch.TextChanged += new System.Windows.Controls.TextChangedEventHandler(this.tbSearch_TextChanged);
            
            #line default
            #line hidden
            return;
            case 8:
            this.slider = ((System.Windows.Controls.Slider)(target));
            
            #line 44 "..\..\..\pages\coupon.xaml"
            this.slider.ValueChanged += new System.Windows.RoutedPropertyChangedEventHandler<double>(this.slider_ValueChanged);
            
            #line default
            #line hidden
            return;
            case 9:
            this.lbSlider = ((System.Windows.Controls.Label)(target));
            return;
            }
            this._contentLoaded = true;
        }
    }
}

