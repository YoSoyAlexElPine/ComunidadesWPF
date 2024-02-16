using System;
using System.Collections.ObjectModel;
using System.ComponentModel;
using Comunidades.Model;
using Comunidades.DB;

namespace Comunidades.vmPortal
{
    public class PortalModelView : INotifyPropertyChanged
    {
        #region VARIABLES
        public event PropertyChangedEventHandler? PropertyChanged;

        // Modelo de la lista de registros a mostrar
        private ObservableCollection<Portal> _portales;
        private int _escaleras;
        private int _comunidadId;
        #endregion

        #region OBJETOS
        public ObservableCollection<Portal> portales
        {
            get { return _portales; }
            set
            {
                _portales = value;
                OnPropertyChange("portales");
            }
        }

        public int Escaleras
        {
            get { return _escaleras; }
            set
            {
                _escaleras = value;
                OnPropertyChange("Escaleras");
            }
        }

        public int ComunidadId
        {
            get { return _comunidadId; }
            set
            {
                _comunidadId = value;
                OnPropertyChange("ComunidadId");
            }
        }
        #endregion

        // Método que se encarga de actualizar las propiedades en cada cambio
        private void OnPropertyChange(string propertyName)
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
        }

        public void NuevoPortal()
        {
            if (portales == null || portales.Count == 0)
            {
                // Manejar el caso cuando la lista está vacía
                return;
            }

            // Obtener el último portal de la lista
            Portal ultimoPortal = portales[portales.Count - 1];
            Db.InsertarPortal(new Portal
            {
                Escaleras = ultimoPortal.Escaleras,
                ComunidadId = ultimoPortal.ComunidadId
            });
        }

        public void CargarPortales()
        {
            portales = Db.ObtenerPortales();
        }
    }
}
