using Comunidades.Model;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Input;
using Comunidades.DB;
using Comunidades.vmPropietario;
using Comunidades.vmEscalera;
using Comunidades.vmPortal;
using Comunidades.ViewModel;

namespace Comunidades
{

    public partial class MainWindow : Window
    {

        private PropietarioModelView vmPropietario = new PropietarioModelView();
        private PortalModelView vmPortal = new PortalModelView();
        private EscaleraViewModel vmEscalera = new EscaleraViewModel();
        private PlantaViewModel vmPlanta = new PlantaViewModel();
        private ApartamentoViewModel vmApartamento = new ApartamentoViewModel();
        private ComunidadViewModel vmComunidad = new ComunidadViewModel();

        DateTime fechaSeleccionada;

        public MainWindow()
        {
            InitializeComponent();
        }

        private void b_next_Click_1(object sender, RoutedEventArgs e)
        {
            grid_1.Visibility = Visibility.Collapsed;
            grid_2.Visibility = Visibility.Visible;
        }
        private void b_previus_Click_2(object sender, RoutedEventArgs e)
        {
            grid_1.Visibility = Visibility.Visible;
            grid_2.Visibility = Visibility.Collapsed;
        }
        private void b_next_Click_2(object sender, RoutedEventArgs e)
        {
            String comunidad = tb_name.Text;

            Comunidad c = new Comunidad
            {
                Nombre = tb_name.Text,
                Direccion = tb_adress.Text,
                Fecha = fechaSeleccionada,
                Metros = int.Parse(tb_meters.Text),
                Padel = Toggle_padel.IsChecked == true,
                Tenis = Toggle_tenis.IsChecked == true,
                Meeting = Toggle_meeting.IsChecked == true,
                Exercise = Toggle_exercise.IsChecked == true,
                Play = Toggle_play.IsChecked == true,
                Shower = Toggle_shower.IsChecked == true,
                Portero = Toggle_gatekeeper.IsChecked == true,
                Piscina = Toggle_piscina.IsChecked == true
            };


            if (vmComunidad.Comunidades == null)
                vmComunidad.CargarComunidades();

            vmComunidad.Comunidades.Add(new Comunidad
            {
                Nombre = tb_name.Text,
                Direccion = tb_adress.Text,
                Fecha = fechaSeleccionada,
                Metros = int.Parse(tb_meters.Text),
                Padel = Toggle_padel.IsChecked == true,
                Tenis = Toggle_tenis.IsChecked == true,
                Meeting = Toggle_meeting.IsChecked == true,
                Exercise = Toggle_exercise.IsChecked == true,
                Play = Toggle_play.IsChecked == true,
                Shower = Toggle_shower.IsChecked == true,
                Portero = Toggle_gatekeeper.IsChecked == true,
                Piscina = Toggle_piscina.IsChecked == true
            });

            vmComunidad.NuevaComunidad();

            tb_name.Text = "";
            tb_adress.Text = "";
            tb_meters.Text = "";
            Toggle_padel.IsChecked = false;
            Toggle_tenis.IsChecked = false;
            Toggle_meeting.IsChecked = false;
            Toggle_exercise.IsChecked = false;
            Toggle_play.IsChecked = false;
            Toggle_shower.IsChecked = false;
            Toggle_gatekeeper.IsChecked = false;
            Toggle_piscina.IsChecked = false;

            grid_1.Visibility = Visibility.Visible;
        }

        public void Solo_Numeros(object sender, TextCompositionEventArgs e)
        {

            // Usar una expresión regular para permitir solo números
            if (!System.Text.RegularExpressions.Regex.IsMatch(e.Text, "^[0-9]+$"))
            {
                e.Handled = true; // No permitir la entrada de letras
            }
        }

        public void Solo_Palabras(object sender, TextCompositionEventArgs e)
        {
            // Usar una expresión regular para permitir solo palabras (letras)
            if (!System.Text.RegularExpressions.Regex.IsMatch(e.Text, "^[a-zA-Z]+$"))
            {
                e.Handled = true; // No permitir la entrada de números
            }
        }


        private void DatePicker_SelectedDateChanged(object sender, System.Windows.Controls.SelectionChangedEventArgs e)
        {
            // Obtener la fecha seleccionada del DatePicker
            fechaSeleccionada = dp_fecha.SelectedDate ?? DateTime.Now;
        }

        private void TB_Cambio(object sender, RoutedEventArgs e)
        {
            try
            {

                if (tb_adress.Text.Length > 0 && tb_meters.Text.Length > 0 && tb_name.Text.Length > 0)
                {
                    b_next_1.IsEnabled = true;
                }
                else
                {
                    b_next_1.IsEnabled = false;
                }


            }
            catch (Exception ex) { }
        }


        private void tabItem2_MouseDown(object sender, MouseButtonEventArgs e)
        {
            if (tabControl.SelectedItem != tabItem2)
            {
                dg_comunidades.Items.Clear();
                tabControl.SelectedItem = tabItem2;
                //MessageBox.Show(DB.db.ObtenerComunidades().Length.ToString());

                foreach (Comunidad p in Db.ObtenerComunidades())
                {
                    dg_comunidades.Items.Add(p);
                }
            }

        }

        private void tabItem_portals_MouseDown(object sender, MouseButtonEventArgs e)
        {
            if (tabControl.SelectedItem != tabItem_portals)
            {
                cb_comunidades_portals.Items.Clear();
                tabControl.SelectedItem = tabItem_portals;
                //MessageBox.Show(DB.db.ObtenerComunidades().Length.ToString());

                foreach (Comunidad p in Db.ObtenerComunidades())
                {
                    cb_comunidades_portals.Items.Add(p.Nombre);
                }
            }

        }

        private void tabItem_stairs_MouseDown(object sender, MouseButtonEventArgs e)
        {
            if (tabControl.SelectedItem != tabItem_stairs)
            {
                cb_comunidades_stairs.Items.Clear();
                tabControl.SelectedItem = tabItem_stairs;
                //MessageBox.Show(DB.db.ObtenerComunidades().Length.ToString());

                foreach (Comunidad p in Db.ObtenerComunidades())
                {
                    cb_comunidades_stairs.Items.Add(p.Nombre);
                }

            }

        }

        private void b_refresh_1_Click(object sender, RoutedEventArgs e)
        {

        }

        private void b_save_portals_Click(object sender, RoutedEventArgs e)
        {

            if (!string.IsNullOrEmpty(tb_stairs_portals.Text) && !string.IsNullOrEmpty(cb_comunidades_portals.Text))
            {
                int escaleras = int.Parse(tb_stairs_portals.Text);
                int comunidadid = Db.ObtenerComunidadId(cb_comunidades_portals.Text);

                if (vmPortal.portales == null) vmPortal.CargarPortales();

                vmPortal.portales.Add(new Portal
                {
                    Escaleras = escaleras,
                    ComunidadId = comunidadid
                });


                vmPortal.NuevoPortal();
            } else
            {
                MessageBox.Show("Rellena todos los campos");
            }

        }

        private void b_save_stairs_Click(object sender, RoutedEventArgs e)
        {

            if (cb_portales_stairs.SelectedItem != null && !string.IsNullOrEmpty(cb_portales_stairs.SelectedItem.ToString()) && !string.IsNullOrEmpty(tb_floors_stairs.Text))
            {
                int portalId = int.Parse(cb_portales_stairs.SelectedItem.ToString());
                int plantas = int.Parse(tb_floors_stairs.Text);

                if (vmEscalera.Escaleras == null)
                    vmEscalera.CargarEscaleras();

                vmEscalera.Escaleras.Add(new Escalera
                {
                    PortalId = portalId,
                    Numero = plantas
                });

                vmEscalera.NuevaEscalera();
            }
            else
            {
                MessageBox.Show("Rellena todos los campos");
            }



        }
        private void tabItem_floor_PreviewMouseDown(object sender, MouseButtonEventArgs e)
        {
            if (tabControl.SelectedItem != tabItem_floor)
            {
                cb_comunidades_floor.Items.Clear();
                cb_escaleras_floor.Items.Clear();
                tabControl.SelectedItem = tabItem_floor;
                //MessageBox.Show(DB.db.ObtenerComunidades().Length.ToString());

                foreach (Comunidad p in Db.ObtenerComunidades())
                {
                    cb_comunidades_floor.Items.Add(p.Nombre);
                }

            }
        }
        private void cb_comunidades_stairs_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            int id = 0;

            if (cb_comunidades_stairs.SelectedItem != null)
            {
                id = Db.ObtenerComunidadId((String)cb_comunidades_stairs.SelectedItem);

            }

            int[] idPortales = Db.ObtenerPortalesPorComunidadId(id);

            cb_portales_stairs.Items.Clear();
            foreach (int i in idPortales)
            {
                cb_portales_stairs.Items.Add(i);
            }


        }

        private void cb_comunidades_floor_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {

            int id = 0;

            if (cb_comunidades_floor.SelectedItem != null)
            {
                id = Db.ObtenerComunidadId(cb_comunidades_floor.SelectedItem.ToString());

            }

            int[] idPortales = Db.ObtenerPortalesPorComunidadId(id);

            cb_portales_floor.Items.Clear();
            foreach (int i in idPortales)
            {
                cb_portales_floor.Items.Add(i);
            }
        }

        private void cb_escaleras_floor_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            if (cb_portales_floor.SelectedItem != null)
            {


                // Obtén el valor seleccionado del ComboBox
                int selectedPortalId = (int)cb_portales_floor.SelectedItem;

                // Obtén los IDs de las escaleras utilizando el valor seleccionado
                int[] idEscaleras = Db.ObtenerEscalerasId(selectedPortalId);

                // Limpia los elementos actuales en el ComboBox de escaleras
                cb_escaleras_floor.Items.Clear();

                // Agrega los nuevos elementos al ComboBox de escaleras
                foreach (int id in idEscaleras)
                {
                    cb_escaleras_floor.Items.Add(id);
                }
            }
        }

        private void b_save_floor(object sender, RoutedEventArgs e)
        {

            if (!string.IsNullOrEmpty(cb_escaleras_floor.Text) && !string.IsNullOrEmpty(tb_apartamentos_floor.Text))
            {


                int a = int.Parse(cb_escaleras_floor.Text);
                int b = int.Parse(tb_apartamentos_floor.Text);

                if (vmPlanta.Plantas == null)
                    vmPlanta.CargarPlantas();

                vmPlanta.Plantas.Add(new Planta
                {
                    EscaleraId = a,
                    Numero = b
                });

                vmPlanta.NuevaPlanta();

            } else
            {
                MessageBox.Show("Rellena todos los campops");
            }


        } 

        private void tabItem_MouseDown_apartamento(object sender, MouseButtonEventArgs e)
        {
            if (tabControl.SelectedItem != tabItem_apartamento)
            {
                cb_comunidades_apartamento.Items.Clear();
                cb_escaleras_apartamento.Items.Clear();
                cb_planta_apartamento.Items.Clear();

                tabControl.SelectedItem = tabItem_apartamento;
                //MessageBox.Show(DB.db.ObtenerComunidades().Length.ToString());

                foreach (Comunidad p in Db.ObtenerComunidades())
                {
                    cb_comunidades_apartamento.Items.Add(p.Nombre);
                }

            }

        }
        private void cb_portales_apartamento_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            // Obtén el valor seleccionado del ComboBox
            if (cb_portales_apartamento.SelectedItem != null)
            {


                int selectedPortalId = (int)cb_portales_apartamento.SelectedItem;

                // Obtén los IDs de las escaleras utilizando el valor seleccionado
                int[] idEscaleras = Db.ObtenerEscalerasId(selectedPortalId);

                // Limpia los elementos actuales en el ComboBox de escaleras
                cb_escaleras_apartamento.Items.Clear();

                // Agrega los nuevos elementos al ComboBox de escaleras
                foreach (int id in idEscaleras)
                {
                    cb_escaleras_apartamento.Items.Add(id);
                }
            }
        }

        private void cb_comunidades_apartamento_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            int id = 0;

            if (cb_comunidades_apartamento.SelectedItem != null)
            {
                id = Db.ObtenerComunidadId((String)cb_comunidades_apartamento.SelectedItem);

            }

            int[] idPortales = Db.ObtenerPortalesPorComunidadId(id);

            cb_portales_apartamento.Items.Clear();
            foreach (int i in idPortales)
            {
                cb_portales_apartamento.Items.Add(i);
            }
        }

        private void cb_escaleras_apartamento_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            int[] ids;

            if (cb_comunidades_apartamento.SelectedItem != null)
            {
                ids = Db.ObtenerPlantasId((int)cb_escaleras_apartamento.SelectedItem);

                cb_planta_apartamento.Items.Clear();
                foreach (int i in ids)
                {
                    cb_planta_apartamento.Items.Add(i);
                }
            }


        }
        private void b_save_apartamento_Click(object sender, RoutedEventArgs e)
        {
            // Verificar que los ComboBox no estén vacíos antes de realizar la acción
            if (!string.IsNullOrWhiteSpace(cb_comunidades_apartamento.Text) &&
                !string.IsNullOrWhiteSpace(cb_portales_apartamento.Text) &&
                !string.IsNullOrWhiteSpace(cb_escaleras_apartamento.Text) &&
                !string.IsNullOrWhiteSpace(cb_planta_apartamento.Text) &&
                !string.IsNullOrWhiteSpace(tb_letra_apartamento.Text))
            {
                // Realizar la acción 

                int plantaSeleccionada = int.Parse(cb_planta_apartamento.Text);
                string letra = tb_letra_apartamento.Text.Trim();

                //Apartamento a = new Apartamento(plantaSeleccionada,letra);


                if (vmApartamento.Apartamentos == null)
                    vmApartamento.CargarApartamentos();

                vmApartamento.Apartamentos.Add(new Apartamento
                {
                    PlantaId = plantaSeleccionada,
                    Letra = letra
                });

                vmApartamento.NuevoApartamento();
            }
            else
            {
                // Mostrar un mensaje o realizar alguna acción si hay ComboBox vacíos
                MessageBox.Show("Por favor, selecciona valores en todos campos.");
            }
        }
        private void tabItem_MouseDown_propietario(object sender, MouseButtonEventArgs e)
        {
            if (tabControl.SelectedItem != tabItem_propietario)
            {
                cb_comunidades_propietario.Items.Clear();
                cb_escaleras_propietario.Items.Clear();
                cb_planta_propietario.Items.Clear();
                cb_apartamento_propietario.Items.Clear();

                tabControl.SelectedItem = tabItem_propietario;
                //MessageBox.Show(DB.db.ObtenerComunidades().Length.ToString());

                foreach (Comunidad p in Db.ObtenerComunidades())
                {
                    cb_comunidades_propietario.Items.Add(p.Nombre);
                }

            }

        }
        private void cb_portales_propietario_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            // Obtén el valor seleccionado del ComboBox
            if (cb_portales_propietario.SelectedItem != null)
            {
                int selectedPortalId = (int)cb_portales_propietario.SelectedItem;

                // Obtén los IDs de las escaleras utilizando el valor seleccionado
                int[] idEscaleras = Db.ObtenerEscalerasId(selectedPortalId);

                // Limpia los elementos actuales en el ComboBox de escaleras
                cb_escaleras_propietario.Items.Clear();

                // Agrega los nuevos elementos al ComboBox de escaleras
                foreach (int id in idEscaleras)
                {
                    cb_escaleras_propietario.Items.Add(id);
                }
            }

        }

        private void cb_comunidades_propietario_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            int id = 0;

            if (cb_comunidades_propietario.SelectedItem != null)
            {
                id = Db.ObtenerComunidadId((String)cb_comunidades_propietario.SelectedItem);

            }

            int[] idPortales = Db.ObtenerPortalesPorComunidadId(id);

            cb_portales_propietario.Items.Clear();
            foreach (int i in idPortales)
            {
                cb_portales_propietario.Items.Add(i);
            }
        }

        private void cb_escaleras_propietario_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            int[] ids;

            if (cb_comunidades_propietario.SelectedItem != null)
            {
                ids = Db.ObtenerPlantasId((int)cb_escaleras_propietario.SelectedItem);

                cb_planta_propietario.Items.Clear();
                foreach (int i in ids)
                {
                    cb_planta_propietario.Items.Add(i);
                }
            }


        }
        private void cb_apartamento_propietario_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            int[] ids;

            if (cb_planta_propietario.SelectedItem != null)
            {
                ids = Db.ObtenerApartamentosIdPorPlanta((int)cb_planta_propietario.SelectedItem);

                cb_apartamento_propietario.Items.Clear();
                foreach (int i in ids)
                {
                    cb_apartamento_propietario.Items.Add(i);
                }
            }


        }
        private void b_save_propietario_Click(object sender, RoutedEventArgs e)
        {
            // Verificar que ningún campo esté vacío
            if (string.IsNullOrWhiteSpace(tb_dni.Text) ||
                string.IsNullOrWhiteSpace(tb_nombre.Text) ||
                string.IsNullOrWhiteSpace(tb_apellido.Text) ||
                string.IsNullOrWhiteSpace(tb_localidad.Text) ||
                string.IsNullOrWhiteSpace(tb_direccion.Text) ||
                string.IsNullOrWhiteSpace(tb_cp.Text) ||
                string.IsNullOrWhiteSpace(tb_provincia.Text))
            {
                MessageBox.Show("Por favor, complete todos los campos antes de insertar el propietario.");
                return; // Salir de la función si hay campos vacíos
            }

            // Crear un objeto Propietario con los datos ingresados
            Propietario nuevoPropietario = new Propietario
            {
                Dni = tb_dni.Text,
                Nombre = tb_nombre.Text,
                Apellidos = tb_apellido.Text,
                Localidad = tb_localidad.Text,
                Direccion = tb_direccion.Text,
                Cp = tb_cp.Text,
                Provincia = tb_provincia.Text
            };

            int id = int.Parse(cb_apartamento_propietario.Text);

            if (vmPropietario.propietarios == null)
                vmPropietario.LoadPropietarios();

            if (vmPropietario.propietarios.Where(x => x.Dni == nuevoPropietario.Dni).FirstOrDefault() == null)
            {

                vmPropietario.propietarios.Add(new Propietario
                {
                    Dni = nuevoPropietario.Dni,
                    Nombre = nuevoPropietario.Nombre,
                    Apellidos = nuevoPropietario.Apellidos,
                    Localidad = nuevoPropietario.Localidad,
                    Direccion = nuevoPropietario.Direccion,
                    Cp = nuevoPropietario.Cp,
                    Provincia = nuevoPropietario.Provincia
                });

                vmPropietario.NewPropietario(id);
            }

        }


        private void b_next_propietario_Click(object sender, RoutedEventArgs e)
        {
            g_propietario_1.Visibility = Visibility.Collapsed;
            g_propietario_2.Visibility = Visibility.Visible;
        }

        private void b_previus_propietario_Copiar_Click(object sender, RoutedEventArgs e)
        {
            g_propietario_1.Visibility = Visibility.Visible;
            g_propietario_2.Visibility = Visibility.Collapsed;
        }

        private void cb_apartamento_propietario_SelectionChanged_1(object sender, SelectionChangedEventArgs e)
        {

            b_next_propietario.IsEnabled = cb_planta_propietario.SelectedItem != null;

        }
    }


}

