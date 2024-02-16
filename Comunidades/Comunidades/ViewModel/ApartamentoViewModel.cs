using System;
using System.Collections.ObjectModel;
using System.ComponentModel;
using Comunidades.Model;
using Comunidades.DB;

namespace Comunidades.vmEscalera
{
    public class ApartamentoViewModel : INotifyPropertyChanged
    {
        #region VARIABLES
        public event PropertyChangedEventHandler? PropertyChanged;

        // Modelo de la lista de registros a mostrar
        private ObservableCollection<Apartamento> _apartamentos;
        private int _garajeId;
        private int _trasteroId;
        private int _plantaId;
        private string _letra = "";
        #endregion

        #region OBJETOS
        public ObservableCollection<Apartamento> Apartamentos
        {
            get { return _apartamentos; }
            set
            {
                _apartamentos = value;
                OnPropertyChange("Apartamentos");
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

        public void NuevoApartamento()
        {
            if (Apartamentos == null || Apartamentos.Count == 0)
            {
                // Manejar el caso cuando la lista está vacía
                return;
            }

            // Obtener el último apartamento de la lista
            Apartamento ultimoApartamento = Apartamentos[Apartamentos.Count - 1];
            Db.InsertarApartamento(new Apartamento
            {
                GarajeId = ultimoApartamento.GarajeId,
                TrasteroId = ultimoApartamento.TrasteroId,
                PlantaId = ultimoApartamento.PlantaId,
                Letra = ultimoApartamento.Letra
            });
        }

        public void CargarApartamentos()
        {
            Apartamentos = Db.ObtenerApartamentos();
        }
    }
}
