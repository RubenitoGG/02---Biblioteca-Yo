﻿#pragma checksum "..\..\VentanaSocio.xaml" "{ff1816ec-aa5e-4d10-87f7-6f4963833460}" "BFFDC2FA7961E6759BAE0DC1571ECD138F2786CB"
//------------------------------------------------------------------------------
// <auto-generated>
//     Este código fue generado por una herramienta.
//     Versión de runtime:4.0.30319.42000
//
//     Los cambios en este archivo podrían causar un comportamiento incorrecto y se perderán si
//     se vuelve a generar el código.
// </auto-generated>
//------------------------------------------------------------------------------

using Biblioteca;
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


namespace Biblioteca {
    
    
    /// <summary>
    /// VentanaSocio
    /// </summary>
    public partial class VentanaSocio : System.Windows.Window, System.Windows.Markup.IComponentConnector {
        
        
        #line 11 "..\..\VentanaSocio.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.TextBox txt_codigo;
        
        #line default
        #line hidden
        
        
        #line 14 "..\..\VentanaSocio.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.TextBox txt_dni;
        
        #line default
        #line hidden
        
        
        #line 16 "..\..\VentanaSocio.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.TextBox txt_nombre;
        
        #line default
        #line hidden
        
        
        #line 18 "..\..\VentanaSocio.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.TextBox txt_apellido;
        
        #line default
        #line hidden
        
        
        #line 20 "..\..\VentanaSocio.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.TextBox txt_direccion;
        
        #line default
        #line hidden
        
        
        #line 22 "..\..\VentanaSocio.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.TextBox txt_correo;
        
        #line default
        #line hidden
        
        
        #line 24 "..\..\VentanaSocio.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.TextBox txt_telefono;
        
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
            System.Uri resourceLocater = new System.Uri("/Biblioteca;component/ventanasocio.xaml", System.UriKind.Relative);
            
            #line 1 "..\..\VentanaSocio.xaml"
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
            this.txt_codigo = ((System.Windows.Controls.TextBox)(target));
            return;
            case 2:
            this.txt_dni = ((System.Windows.Controls.TextBox)(target));
            return;
            case 3:
            this.txt_nombre = ((System.Windows.Controls.TextBox)(target));
            return;
            case 4:
            this.txt_apellido = ((System.Windows.Controls.TextBox)(target));
            return;
            case 5:
            this.txt_direccion = ((System.Windows.Controls.TextBox)(target));
            return;
            case 6:
            this.txt_correo = ((System.Windows.Controls.TextBox)(target));
            return;
            case 7:
            this.txt_telefono = ((System.Windows.Controls.TextBox)(target));
            return;
            case 8:
            
            #line 25 "..\..\VentanaSocio.xaml"
            ((System.Windows.Controls.Button)(target)).Click += new System.Windows.RoutedEventHandler(this.Button_Click);
            
            #line default
            #line hidden
            return;
            }
            this._contentLoaded = true;
        }
    }
}

