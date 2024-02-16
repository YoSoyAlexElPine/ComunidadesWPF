using System.Collections.ObjectModel;
using System.ComponentModel;
using Comunidades.Model;
using Comunidades.DB;

namespace Comunidades.ViewModel
{
    public class PlantaViewModel : INotifyPropertyChanged
    {
        #region VARIABLES
        public event PropertyChangedEventHandler? PropertyChanged;

        // Modelo de la lista de registros a mostrar
        private ObservableCollection<Planta> _plantas;
        private int _escaleraId;
        private int _numero;
        #endregion

        #region OBJETOS
        public ObservableCollection<Planta> Plantas
        {
            get { return _plantas; }
            set
            {
                _plantas = value;
                OnPropertyChange("Plantas");
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

        public void NuevaPlanta()
        {
            if (Plantas == null || Plantas.Count == 0)
            {
                // Manejar el caso cuando la lista está vacía
                return;
            }

            // Obtener la última planta de la lista
            Planta ultimaPlanta = Plantas[Plantas.Count - 1];
            Db.InsertarPlanta(new Planta
            {
                EscaleraId = ultimaPlanta.EscaleraId,
                Numero = ultimaPlanta.Numero
            });
        }

        public void CargarPlantas()
        {
            Plantas = Db.ObtenerPlantas();
        }
    }
}
