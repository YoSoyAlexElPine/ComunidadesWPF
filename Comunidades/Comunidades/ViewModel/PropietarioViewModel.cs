using System;
using System.Collections.ObjectModel;
using System.ComponentModel;
using Comunidades.Model;  // Asegúrate de tener el using correcto para el modelo Propietario
using Comunidades.DB;

namespace Comunidades.vmPropietario
{
    public class PropietarioModelView : INotifyPropertyChanged
    {
        #region VARIABLES
        public event PropertyChangedEventHandler? PropertyChanged;

        // Modelo de la lista de registros a mostrar
        private ObservableCollection<Propietario> _propietarios;
        private string _dni = "";
        private string _nombre = "";
        private string _apellidos = "";
        private string _localidad = "";
        private string _direccion = "";
        private string _cp = "";
        private string _provincia = "";
        #endregion

        #region OBJETOS
        public ObservableCollection<Propietario> propietarios
        {
            get { return _propietarios; }
            set
            {
                _propietarios = value;
                OnPropertyChange("propietarios");
            }
        }
        public string Dni
        {
            get { return _dni; }
            set
            {
                _dni = value;
                OnPropertyChange("Dni");
            }
        }
        public string Nombre
        {
            get { return _nombre; }
            set
            {
                _nombre = value;
                OnPropertyChange("Nombre");
            }
        }
        public string Apellidos
        {
            get { return _apellidos; }
            set
            {
                _apellidos = value;
                OnPropertyChange("Apellidos");
            }
        }
        public string Localidad
        {
            get { return _localidad; }
            set
            {
                _localidad = value;
                OnPropertyChange("Localidad");
            }
        }
        public string Direccion
        {
            get { return _direccion; }
            set
            {
                _direccion = value;
                OnPropertyChange("Direccion");
            }
        }
        public string Cp
        {
            get { return _cp; }
            set
            {
                _cp = value;
                OnPropertyChange("Cp");
            }
        }
        public string Provincia
        {
            get { return _provincia; }
            set
            {
                _provincia = value;
                OnPropertyChange("Provincia");
            }
        }
        #endregion

        // Método que se encarga de actualizar las propiedades en cada cambio
        private void OnPropertyChange(string propertyName)
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
        }

        public void NewPropietario(int id)
        {
            if (propietarios == null || propietarios.Count == 0)
            {
                // Manejar el caso cuando la lista está vacía
                return;
            }

            // Obtener el último propietario de la lista
            Propietario ultimoPropietario = propietarios[propietarios.Count - 1];
            Db.InsertarPropietario(new Propietario
            {
                Dni = ultimoPropietario.Dni,
                Nombre = ultimoPropietario.Nombre,
                Apellidos = ultimoPropietario.Apellidos,
                Localidad = ultimoPropietario.Localidad,
                Direccion = ultimoPropietario.Direccion,
                Cp = ultimoPropietario.Cp,
                Provincia = ultimoPropietario.Provincia
            }, id);
        }


        public void LoadPropietarios()
        {
            propietarios = Db.ObtenerPropietarios();
        }
    }
}
