using System;
using System.Collections.ObjectModel;
using System.ComponentModel;
using Comunidades.Model;
using Comunidades.DB;

namespace Comunidades.vmEscalera
{
    public class EscaleraViewModel : INotifyPropertyChanged
    {
        #region VARIABLES
        public event PropertyChangedEventHandler? PropertyChanged;

        // Modelo de la lista de registros a mostrar
        private ObservableCollection<Escalera> _escaleras;
        private int _portalId;
        private int _numero;
        #endregion

        #region OBJETOS
        public ObservableCollection<Escalera> Escaleras
        {
            get { return _escaleras; }
            set
            {
                _escaleras = value;
                OnPropertyChange("Escaleras");
            }
        }

        public int PortalId
        {
            get { return _portalId; }
            set
            {
                _portalId = value;
                OnPropertyChange("PortalId");
            }
        }

        public int Numero
        {
            get { return _numero; }
            set
            {
                _numero = value;
                OnPropertyChange("Numero");
            }
        }
        #endregion

        // Método que se encarga de actualizar las propiedades en cada cambio
        private void OnPropertyChange(string propertyName)
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
        }

        public void NuevaEscalera()
        {
            if (Escaleras == null || Escaleras.Count == 0)
            {
                // Manejar el caso cuando la lista está vacía
                return;
            }

            // Obtener la última escalera de la lista
            Escalera ultimaEscalera = Escaleras[Escaleras.Count - 1];
            Db.InsertarEscalera(new Escalera
            {
                PortalId = ultimaEscalera.PortalId,
                Numero = ultimaEscalera.Numero
            });
        }

        public void CargarEscaleras()
        {
            Escaleras = Db.ObtenerEscaleras();
        }
    }
}
