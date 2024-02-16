using System;
using System.Collections.ObjectModel;
using System.ComponentModel;
using Comunidades.Model;
using Comunidades.DB;

namespace Comunidades.vmEscalera
{
    public class ComunidadViewModel : INotifyPropertyChanged
    {
        #region VARIABLES
        public event PropertyChangedEventHandler? PropertyChanged;

        // Modelo de la lista de registros a mostrar
        private ObservableCollection<Comunidad> _comunidades;
        private string _nombre = "";
        private string _direccion = "";
        private DateTime _fecha;
        private int _metros;
        private bool _padel;
        private bool _tenis;
        private bool _meeting;
        private bool _exercise;
        private bool _play;
        private bool _shower;
        private bool _portero;
        private bool _piscina;
        #endregion

        #region OBJETOS
        public ObservableCollection<Comunidad> Comunidades
        {
            get { return _comunidades; }
            set
            {
                _comunidades = value;
                OnPropertyChange("Comunidades");
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

        public string Direccion
        {
            get { return _direccion; }
            set
            {
                _direccion = value;
                OnPropertyChange("Direccion");
            }
        }

        public DateTime Fecha
        {
            get { return _fecha; }
            set
            {
                _fecha = value;
                OnPropertyChange("Fecha");
            }
        }

        public int Metros
        {
            get { return _metros; }
            set
            {
                _metros = value;
                OnPropertyChange("Metros");
            }
        }

        public bool Padel
        {
            get { return _padel; }
            set
            {
                _padel = value;
                OnPropertyChange("Padel");
            }
        }

        public bool Tenis
        {
            get { return _tenis; }
            set
            {
                _tenis = value;
                OnPropertyChange("Tenis");
            }
        }

        public bool Meeting
        {
            get { return _meeting; }
            set
            {
                _meeting = value;
                OnPropertyChange("Meeting");
            }
        }

        public bool Exercise
        {
            get { return _exercise; }
            set
            {
                _exercise = value;
                OnPropertyChange("Exercise");
            }
        }

        public bool Play
        {
            get { return _play; }
            set
            {
                _play = value;
                OnPropertyChange("Play");
            }
        }

        public bool Shower
        {
            get { return _shower; }
            set
            {
                _shower = value;
                OnPropertyChange("Shower");
            }
        }

        public bool Portero
        {
            get { return _portero; }
            set
            {
                _portero = value;
                OnPropertyChange("Portero");
            }
        }

        public bool Piscina
        {
            get { return _piscina; }
            set
            {
                _piscina = value;
                OnPropertyChange("Piscina");
            }
        }
        #endregion

        // Método que se encarga de actualizar las propiedades en cada cambio
        private void OnPropertyChange(string propertyName)
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
        }

        public void NuevaComunidad()
        {
            if (Comunidades == null || Comunidades.Count == 0)
            {
                // Manejar el caso cuando la lista está vacía
                return;
            }

            // Obtener la última comunidad de la lista
            Comunidad ultimaComunidad = Comunidades[Comunidades.Count - 1];
            Db.InsertarComunidad(new Comunidad
            {
                Nombre = ultimaComunidad.Nombre,
                Direccion = ultimaComunidad.Direccion,
                Fecha = ultimaComunidad.Fecha,
                Metros = ultimaComunidad.Metros,
                Padel = ultimaComunidad.Padel,
                Tenis = ultimaComunidad.Tenis,
                Meeting = ultimaComunidad.Meeting,
                Exercise = ultimaComunidad.Exercise,
                Play = ultimaComunidad.Play,
                Shower = ultimaComunidad.Shower,
                Portero = ultimaComunidad.Portero,
                Piscina = ultimaComunidad.Piscina
            });
        }

        public void CargarComunidades()
        {
            Comunidades = Db.ObtenerComunidadesOC();
        }
    }
}
