using System.ComponentModel;

namespace Comunidades.Model
{
    public class Planta : INotifyPropertyChanged
    {
        #region VARIABLES
        public event PropertyChangedEventHandler? PropertyChanged;
        private int _plantaId;
        private int _escaleraId;
        private int _numero;
        #endregion

        #region OBJETOS
        public int PlantaId
        {
            get { return _plantaId; }
            set
            {
                _plantaId = value;
                OnPropertyChange("PlantaId");
            }
        }

        public int EscaleraId
        {
            get { return _escaleraId; }
            set
            {
                _escaleraId = value;
                OnPropertyChange("EscaleraId");
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
    }
}
