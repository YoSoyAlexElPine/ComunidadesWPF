using System;
using System.ComponentModel;

namespace Comunidades.Model
{
    public class Propietario : INotifyPropertyChanged
    {
        #region VARIABLES
        public event PropertyChangedEventHandler? PropertyChanged;
        private string _dni = "";
        private string _nombre = "";
        private string _apellidos = "";
        private string _localidad = "";
        private string _direccion = "";
        private string _cp = "";
        private string _provincia = "";
        #endregion

        #region OBJETOS
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
            if (PropertyChanged != null) PropertyChanged(this, new PropertyChangedEventArgs(propertyName));
        }
    }
}
