﻿#pragma checksum "..\..\localizador.xaml" "{406ea660-64cf-4c82-b6f0-42d48172a799}" "6E3CD9B3F17597A891EC2CC5685366AA"
//------------------------------------------------------------------------------
// <auto-generated>
//     Este código fue generado por una herramienta.
//     Versión de runtime:4.0.30319.42000
//
//     Los cambios en este archivo podrían causar un comportamiento incorrecto y se perderán si
//     se vuelve a generar el código.
// </auto-generated>
//------------------------------------------------------------------------------

using Microsoft.Reporting.WinForms;
using Microsoft.Windows.Controls;
using System;
using System.Diagnostics;
using System.Globalization;
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


namespace Reservas {
    
    
    /// <summary>
    /// localizador
    /// </summary>
    public partial class localizador : System.Windows.Controls.Page, System.Windows.Markup.IComponentConnector {
        
        
        #line 32 "..\..\localizador.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.TextBox txtNroReserva1;
        
        #line default
        #line hidden
        
        
        #line 33 "..\..\localizador.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.TextBox txtCliente1;
        
        #line default
        #line hidden
        
        
        #line 34 "..\..\localizador.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.DataGrid dtgReservas1;
        
        #line default
        #line hidden
        
        
        #line 129 "..\..\localizador.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.DatePicker dpfecha1;
        
        #line default
        #line hidden
        
        
        #line 131 "..\..\localizador.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.TextBox txtNroContrato1;
        
        #line default
        #line hidden
        
        
        #line 133 "..\..\localizador.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.DataGrid dtgdetalle;
        
        #line default
        #line hidden
        
        
        #line 180 "..\..\localizador.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.Button btnGuardalocalizador;
        
        #line default
        #line hidden
        
        
        #line 185 "..\..\localizador.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.Button btnConfirmacion;
        
        #line default
        #line hidden
        
        
        #line 191 "..\..\localizador.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.TextBox txtObservacion;
        
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
            System.Uri resourceLocater = new System.Uri("/Reservas;component/localizador.xaml", System.UriKind.Relative);
            
            #line 1 "..\..\localizador.xaml"
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
            
            #line 10 "..\..\localizador.xaml"
            ((Reservas.localizador)(target)).Loaded += new System.Windows.RoutedEventHandler(this.Page_Loaded);
            
            #line default
            #line hidden
            return;
            case 2:
            this.txtNroReserva1 = ((System.Windows.Controls.TextBox)(target));
            
            #line 32 "..\..\localizador.xaml"
            this.txtNroReserva1.KeyUp += new System.Windows.Input.KeyEventHandler(this.txtNroReserva1_KeyUp);
            
            #line default
            #line hidden
            
            #line 32 "..\..\localizador.xaml"
            this.txtNroReserva1.TextChanged += new System.Windows.Controls.TextChangedEventHandler(this.txtNroReserva1_TextChanged);
            
            #line default
            #line hidden
            
            #line 32 "..\..\localizador.xaml"
            this.txtNroReserva1.KeyDown += new System.Windows.Input.KeyEventHandler(this.txtNroReserva1_KeyDown);
            
            #line default
            #line hidden
            return;
            case 3:
            this.txtCliente1 = ((System.Windows.Controls.TextBox)(target));
            
            #line 33 "..\..\localizador.xaml"
            this.txtCliente1.KeyUp += new System.Windows.Input.KeyEventHandler(this.txtCliente1_KeyUp);
            
            #line default
            #line hidden
            return;
            case 4:
            this.dtgReservas1 = ((System.Windows.Controls.DataGrid)(target));
            
            #line 34 "..\..\localizador.xaml"
            this.dtgReservas1.MouseDoubleClick += new System.Windows.Input.MouseButtonEventHandler(this.dtgReservas1_MouseDoubleClick);
            
            #line default
            #line hidden
            
            #line 34 "..\..\localizador.xaml"
            this.dtgReservas1.SelectionChanged += new System.Windows.Controls.SelectionChangedEventHandler(this.dtgReservas1_SelectionChanged);
            
            #line default
            #line hidden
            return;
            case 5:
            this.dpfecha1 = ((System.Windows.Controls.DatePicker)(target));
            
            #line 129 "..\..\localizador.xaml"
            this.dpfecha1.SelectedDateChanged += new System.EventHandler<System.Windows.Controls.SelectionChangedEventArgs>(this.dpfecha1_SelectedDateChanged);
            
            #line default
            #line hidden
            return;
            case 6:
            this.txtNroContrato1 = ((System.Windows.Controls.TextBox)(target));
            
            #line 131 "..\..\localizador.xaml"
            this.txtNroContrato1.KeyUp += new System.Windows.Input.KeyEventHandler(this.txtNroContrato1_KeyUp);
            
            #line default
            #line hidden
            
            #line 131 "..\..\localizador.xaml"
            this.txtNroContrato1.KeyDown += new System.Windows.Input.KeyEventHandler(this.txtNroContrato1_KeyDown);
            
            #line default
            #line hidden
            return;
            case 7:
            this.dtgdetalle = ((System.Windows.Controls.DataGrid)(target));
            return;
            case 8:
            this.btnGuardalocalizador = ((System.Windows.Controls.Button)(target));
            
            #line 180 "..\..\localizador.xaml"
            this.btnGuardalocalizador.Click += new System.Windows.RoutedEventHandler(this.btnGuardalocalizador_Click);
            
            #line default
            #line hidden
            return;
            case 9:
            this.btnConfirmacion = ((System.Windows.Controls.Button)(target));
            
            #line 185 "..\..\localizador.xaml"
            this.btnConfirmacion.Click += new System.Windows.RoutedEventHandler(this.btnConfirmacion_Click);
            
            #line default
            #line hidden
            return;
            case 10:
            this.txtObservacion = ((System.Windows.Controls.TextBox)(target));
            return;
            }
            this._contentLoaded = true;
        }
    }
}

