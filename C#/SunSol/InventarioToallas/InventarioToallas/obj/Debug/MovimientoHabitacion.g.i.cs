﻿#pragma checksum "..\..\MovimientoHabitacion.xaml" "{406ea660-64cf-4c82-b6f0-42d48172a799}" "A071D0F7957B6D3124C86CCDFF571FB0"
//------------------------------------------------------------------------------
// <auto-generated>
//     Este código fue generado por una herramienta.
//     Versión de runtime:4.0.30319.18444
//
//     Los cambios en este archivo podrían causar un comportamiento incorrecto y se perderán si
//     se vuelve a generar el código.
// </auto-generated>
//------------------------------------------------------------------------------

using MahApps.Metro.Controls;
using System;
using System.Diagnostics;
using System.Globalization;
using System.Windows;
using System.Windows.Automation;
using System.Windows.Controls;
using System.Windows.Controls.Primitives;
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


namespace InventarioToallas {
    
    
    /// <summary>
    /// MovimientoHabitacion
    /// </summary>
    public partial class MovimientoHabitacion : MahApps.Metro.Controls.MetroWindow, System.Windows.Markup.IComponentConnector, System.Windows.Markup.IStyleConnector {
        
        
        #line 28 "..\..\MovimientoHabitacion.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.TextBox txtBuscarSup;
        
        #line default
        #line hidden
        
        
        #line 33 "..\..\MovimientoHabitacion.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.TextBox txtBuscarCam;
        
        #line default
        #line hidden
        
        
        #line 38 "..\..\MovimientoHabitacion.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.TextBox txtBuscarHab;
        
        #line default
        #line hidden
        
        
        #line 43 "..\..\MovimientoHabitacion.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.DataGrid dtgrdsup;
        
        #line default
        #line hidden
        
        
        #line 81 "..\..\MovimientoHabitacion.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.DataGrid dtgrdcam;
        
        #line default
        #line hidden
        
        
        #line 161 "..\..\MovimientoHabitacion.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.DataGrid dtgrdhab;
        
        #line default
        #line hidden
        
        
        #line 215 "..\..\MovimientoHabitacion.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal MahApps.Metro.Controls.Tile btnSeleccionar;
        
        #line default
        #line hidden
        
        
        #line 221 "..\..\MovimientoHabitacion.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.DataGrid dtgrdhabsel;
        
        #line default
        #line hidden
        
        
        #line 282 "..\..\MovimientoHabitacion.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal MahApps.Metro.Controls.Tile tlGuardar;
        
        #line default
        #line hidden
        
        
        #line 288 "..\..\MovimientoHabitacion.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal MahApps.Metro.Controls.Tile tlCancelar;
        
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
            System.Uri resourceLocater = new System.Uri("/InventarioToallas;component/movimientohabitacion.xaml", System.UriKind.Relative);
            
            #line 1 "..\..\MovimientoHabitacion.xaml"
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
            
            #line 7 "..\..\MovimientoHabitacion.xaml"
            ((InventarioToallas.MovimientoHabitacion)(target)).Loaded += new System.Windows.RoutedEventHandler(this.MetroWindow_Loaded);
            
            #line default
            #line hidden
            return;
            case 2:
            this.txtBuscarSup = ((System.Windows.Controls.TextBox)(target));
            
            #line 31 "..\..\MovimientoHabitacion.xaml"
            this.txtBuscarSup.KeyUp += new System.Windows.Input.KeyEventHandler(this.txtBuscarSup_KeyUp);
            
            #line default
            #line hidden
            return;
            case 3:
            this.txtBuscarCam = ((System.Windows.Controls.TextBox)(target));
            
            #line 36 "..\..\MovimientoHabitacion.xaml"
            this.txtBuscarCam.KeyUp += new System.Windows.Input.KeyEventHandler(this.txtBuscarCam_KeyUp);
            
            #line default
            #line hidden
            return;
            case 4:
            this.txtBuscarHab = ((System.Windows.Controls.TextBox)(target));
            
            #line 41 "..\..\MovimientoHabitacion.xaml"
            this.txtBuscarHab.KeyUp += new System.Windows.Input.KeyEventHandler(this.txtBuscarHab_KeyUp);
            
            #line default
            #line hidden
            return;
            case 5:
            this.dtgrdsup = ((System.Windows.Controls.DataGrid)(target));
            return;
            case 6:
            this.dtgrdcam = ((System.Windows.Controls.DataGrid)(target));
            return;
            case 7:
            this.dtgrdhab = ((System.Windows.Controls.DataGrid)(target));
            return;
            case 9:
            this.btnSeleccionar = ((MahApps.Metro.Controls.Tile)(target));
            
            #line 215 "..\..\MovimientoHabitacion.xaml"
            this.btnSeleccionar.Click += new System.Windows.RoutedEventHandler(this.btnSeleccionar_Click);
            
            #line default
            #line hidden
            return;
            case 10:
            this.dtgrdhabsel = ((System.Windows.Controls.DataGrid)(target));
            return;
            case 11:
            
            #line 268 "..\..\MovimientoHabitacion.xaml"
            ((System.Windows.Controls.MenuItem)(target)).Click += new System.Windows.RoutedEventHandler(this.MenuItem_Click);
            
            #line default
            #line hidden
            return;
            case 12:
            this.tlGuardar = ((MahApps.Metro.Controls.Tile)(target));
            
            #line 282 "..\..\MovimientoHabitacion.xaml"
            this.tlGuardar.Click += new System.Windows.RoutedEventHandler(this.tlGuardar_Click);
            
            #line default
            #line hidden
            return;
            case 13:
            this.tlCancelar = ((MahApps.Metro.Controls.Tile)(target));
            
            #line 288 "..\..\MovimientoHabitacion.xaml"
            this.tlCancelar.Click += new System.Windows.RoutedEventHandler(this.tlCancelar_Click);
            
            #line default
            #line hidden
            return;
            }
            this._contentLoaded = true;
        }
        
        [System.Diagnostics.DebuggerNonUserCodeAttribute()]
        [System.CodeDom.Compiler.GeneratedCodeAttribute("PresentationBuildTasks", "4.0.0.0")]
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Design", "CA1033:InterfaceMethodsShouldBeCallableByChildTypes")]
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1800:DoNotCastUnnecessarily")]
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Maintainability", "CA1502:AvoidExcessiveComplexity")]
        void System.Windows.Markup.IStyleConnector.Connect(int connectionId, object target) {
            System.Windows.EventSetter eventSetter;
            switch (connectionId)
            {
            case 8:
            eventSetter = new System.Windows.EventSetter();
            eventSetter.Event = System.Windows.Controls.Primitives.ToggleButton.CheckedEvent;
            
            #line 205 "..\..\MovimientoHabitacion.xaml"
            eventSetter.Handler = new System.Windows.RoutedEventHandler(this.OnChecked);
            
            #line default
            #line hidden
            ((System.Windows.Style)(target)).Setters.Add(eventSetter);
            break;
            }
        }
    }
}
