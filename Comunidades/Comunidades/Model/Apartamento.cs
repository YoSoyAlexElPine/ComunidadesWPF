using System;
using System.ComponentModel;

namespace Comunidades.Model
{
    public class Apartamento : INotifyPropertyChanged
    {
        #region VARIABLES
        public event PropertyChangedEventHandler? PropertyChanged;
        private int _apartamentoId;
        private int _garajeId;
        private int _trasteroId;
        private int _plantaId;
        private string _letra;
        #endregion

        #region OBJETOS
        public int ApartamentoId
        {
            get { return _apartamentoId; }
            set
            {
                _apartamentoId = value;
                OnPropertyChange("ApartamentoId");
            }
        }

        public int GarajeId
        {
            get { return _garajeId; }
            set
            {
                _garajeId = value;
                OnPropertyChange("GarajeId");
            }
        }

        public int TrasteroId
        {
            get { return _trasteroId; }
            set
            {
                _trasteroId = value;
                OnPropertyChange("TrasteroId");
            }
        }

        public int PlantaId
        {
            get { return _plantaId; }
            set
            {
                _plantaId = value;
                OnPropertyChange("PlantaId");
            }
        }

        public string Letra
        {
            get { return _letra; }
            set
            {
                _letra = value;
                OnPropertyChange("Letra");
            }
        }
        #endregion

        // Método que se encarga de actualizar las propiedades en cada cambio
        private void OnPropertyChange(string propertyName)
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
        }
    }
}
