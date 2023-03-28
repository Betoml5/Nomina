﻿using GalaSoft.MvvmLight.Command;
using Nomina.CRUD;
using Nomina.Models;
using Nomina.Views;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;

namespace Nomina.ViewModels
{
    public class EmpleadoViewModel:INotifyPropertyChanged
    {

        EmpleadoCRUD EmpleadoCRUD = new();
        CategoriaCRUD CategoriaCRUD = new();


        public ObservableCollection<Empleado> Empleados { get; set; }  = new();
        public ObservableCollection<Categoria> Categorias { get; set; } = new();

        private Vistas vistas = Vistas.VerEmpleados;
        public Vistas Vista
        {
            get { return vistas; }
            set {
                vistas = value;
                PropertyChange();
            }
        }

        public Empleado Empleado { get; set; }   
        public ICommand CrearCommand { get; set; }
        public ICommand VerCrearCommand { get; set; }
        public ICommand BorrarCommand { get; set; }
        public ICommand VerBorrarCommand { get; set; }
        public ICommand ActualizarCommand { get; set; }
        public ICommand VerActualizarCommand { get; set; }
        public ICommand CancelarCommand { get; set; }
        public ICommand CambiarVistaCommand { get; set; }


        public EmpleadoViewModel()
        {
            CrearCommand = new RelayCommand(Crear);
            BorrarCommand = new RelayCommand(Eliminar);
            ActualizarCommand = new RelayCommand(Actualizar);

            CancelarCommand = new RelayCommand(Cancelar);

            VerCrearCommand = new RelayCommand(VerCrear);
            VerBorrarCommand = new RelayCommand<Empleado>(VerBorrar);
            VerActualizarCommand = new RelayCommand<Empleado>(VerActualizar);



            CambiarVistaCommand = new RelayCommand<Vistas>(CambiarVista);

            ActualizarBD();
            PropertyChange();
        }

        private void CambiarVista(Vistas Vista)
        {
            this.Vista = Vista;
        }

        private void Crear()
        {
            EmpleadoCRUD.Crear(Empleado);
            CambiarVista(Vistas.VerEmpleados);
        }

        private void Eliminar()
        {
            EmpleadoCRUD.Eliminar(Empleado);
            CambiarVista(Vistas.VerEmpleados);
        }

        private void Actualizar()
        {
            EmpleadoCRUD.Actualizar(Empleado);
            CambiarVista(Vistas.VerEmpleados);
        }
        private void VerActualizar(Empleado Empleado)
        {
            this.Empleado = Empleado;
            CambiarVista(Vistas.VerActualizarEmpleado);
        }
        private void VerCrear()
        {
            this.Empleado = new();
            CambiarVista(Vistas.VerCrearEmpleado);
        }
        private void VerBorrar(Empleado Empleado)
        {
            this.Empleado = Empleado;
            CambiarVista(Vistas.VerEliminarEmpleado);
        }
        private void Cancelar()
        {
            this.Empleado = null;
            CambiarVista(Vistas.VerEmpleados);
        }

        

        public void ActualizarBD()
        {
            Empleados.Clear();
            Categorias.Clear();
            foreach (var item in EmpleadoCRUD.Obtener())
            {
                Empleados.Add(item);
            }

            foreach (var item in CategoriaCRUD.Obtener())
            {
                Categorias.Add(item);
            }
        }

        void PropertyChange(string? prop = null)
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(prop));
        }

        public event PropertyChangedEventHandler? PropertyChanged;

    }
}
