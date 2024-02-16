using System;
using System.ComponentModel;

namespace Comunidades.Model
{
    public class Portal : INotifyPropertyChanged
    {
        #region VARIABLES
        public event PropertyChangedEventHandler? PropertyChanged;
        private int _portalId;
        private int _escaleras;
        private int _comunidadId;
        #endregion

        #region OBJETOS
        public int PortalId
        {
            get { return _portalId; }
            set
            {
                _portalId = value;
                OnPropertyChange("PortalId");
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
            if (PropertyChanged != null) PropertyChanged(this, new PropertyChangedEventArgs(propertyName));
        }
    }
}
