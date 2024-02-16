using Comunidades.Model;
using MySql.Data.MySqlClient;
using System.Collections.ObjectModel;
using System.Windows;

namespace Comunidades.DB
{
    class Db
    {
        public static string connectionString = "Server=localhost;Database=comunidades;Uid=root;Pwd=1234;";

        public static void InsertarComunidad(Comunidad comunidad)
        {
            using (MySqlConnection connection = new MySqlConnection(connectionString))
            {
                try
                {
                    connection.Open();

                    string sqlQuery = "INSERT INTO Comunidades (Nombre, Direccion, FechaCreacion, MetrosCuadrados, TienePiscina, PisoPortero, DuchasBano, ParqueInfantil, MaquinasEjercicio, SalaReuniones, PistaTenis, PistaPadel) " +
                                      "VALUES (@Nombre, @Direccion, @FechaCreacion, @MetrosCuadrados, @TienePiscina, @PisoPortero, @DuchasBano, @ParqueInfantil, @MaquinasEjercicio, @SalaReuniones, @PistaTenis, @PistaPadel)";

                    MySqlCommand cmd = new MySqlCommand(sqlQuery, connection);

                    cmd.Parameters.AddWithValue("@Nombre", comunidad.Nombre);
                    cmd.Parameters.AddWithValue("@Direccion", comunidad.Direccion);
                    cmd.Parameters.AddWithValue("@FechaCreacion", comunidad.Fecha);
                    cmd.Parameters.AddWithValue("@MetrosCuadrados", comunidad.Metros);
                    cmd.Parameters.AddWithValue("@TienePiscina", comunidad.Piscina);
                    cmd.Parameters.AddWithValue("@PisoPortero", comunidad.Portero);
                    cmd.Parameters.AddWithValue("@DuchasBano", comunidad.Shower);
                    cmd.Parameters.AddWithValue("@ParqueInfantil", comunidad.Play);
                    cmd.Parameters.AddWithValue("@MaquinasEjercicio", comunidad.Exercise);
                    cmd.Parameters.AddWithValue("@SalaReuniones", comunidad.Meeting);
                    cmd.Parameters.AddWithValue("@PistaTenis", comunidad.Tenis);
                    cmd.Parameters.AddWithValue("@PistaPadel", comunidad.Padel);

                    cmd.ExecuteNonQuery();

                    MessageBox.Show(comunidad.Nombre + " agregado");

                }
                catch (Exception ex)
                {
                    MessageBox.Show(ex.Message);


                }
            }
        }
        public static ObservableCollection<Escalera> ObtenerEscaleras()
        {
            ObservableCollection<Escalera> escaleras = new ObservableCollection<Escalera>();

            try
            {
                using (MySqlConnection connection = new MySqlConnection(connectionString))
                {
                    connection.Open();

                    string query = "SELECT * FROM Escalera";

                    using (MySqlCommand command = new MySqlCommand(query, connection))
                    {
                        using (MySqlDataReader reader = command.ExecuteReader())
                        {
                            while (reader.Read())
                            {
                                Escalera escalera = new Escalera
                                {
                                    EscaleraId = Convert.ToInt32(reader["EscaleraId"]),
                                    PortalId = Convert.ToInt32(reader["PortalId"]),
                                    Numero = Convert.ToInt32(reader["Numero"])
                                };

                                escaleras.Add(escalera);
                            }
                        }
                    }
                }
            }
            catch (Exception)
            {
                //MessageBox.Show(ex.Message);
            }

            return escaleras;
        }

        public static ObservableCollection<Portal> ObtenerPortales()
        {
            ObservableCollection<Portal> portales = new ObservableCollection<Portal>();

            try
            {
                using (MySqlConnection connection = new MySqlConnection(connectionString))
                {
                    connection.Open();

                    string query = "SELECT * FROM Portal";

                    using (MySqlCommand command = new MySqlCommand(query, connection))
                    {
                        using (MySqlDataReader reader = command.ExecuteReader())
                        {
                            while (reader.Read())
                            {
                                Portal portal = new Portal
                                {
                                    PortalId = Convert.ToInt32(reader["PortalId"]),
                                    Escaleras = Convert.ToInt32(reader["Escaleras"]),
                                    ComunidadId = Convert.ToInt32(reader["ComunidadId"])
                                };

                                portales.Add(portal);
                            }
                        }
                    }
                }
            }
            catch (Exception)
            {
                //MessageBox.Show(ex.Message);
            }

            return portales;
        }

        public static void InsertarPropietario(Propietario propietario, int pisoId)
        {
            using (MySqlConnection connection = new MySqlConnection(connectionString))
            {
                try
                {
                    connection.Open();

                    // Insertar el propietario en la tabla Propietario
                    string insertPropietarioQuery = "INSERT INTO Propietario (dni, nombre, apellidos, localidad, direccion, cp, provincia) " +
                                                    "VALUES (@dni, @nombre, @apellidos, @localidad, @direccion, @cp, @provincia);";

                    MySqlCommand insertPropietarioCommand = new MySqlCommand(insertPropietarioQuery, connection);
                    insertPropietarioCommand.Parameters.AddWithValue("@dni", propietario.Dni);
                    insertPropietarioCommand.Parameters.AddWithValue("@nombre", propietario.Nombre);
                    insertPropietarioCommand.Parameters.AddWithValue("@apellidos", propietario.Apellidos);
                    insertPropietarioCommand.Parameters.AddWithValue("@localidad", propietario.Localidad);
                    insertPropietarioCommand.Parameters.AddWithValue("@direccion", propietario.Direccion);
                    insertPropietarioCommand.Parameters.AddWithValue("@cp", propietario.Cp);
                    insertPropietarioCommand.Parameters.AddWithValue("@provincia", propietario.Provincia);

                    insertPropietarioCommand.ExecuteNonQuery();

                    // Obtener el PropietarioId recién insertado
                    string obtenerPropietarioIdQuery = "SELECT LAST_INSERT_ID();";
                    MySqlCommand obtenerPropietarioIdCommand = new MySqlCommand(obtenerPropietarioIdQuery, connection);

                    int propietarioId = Convert.ToInt32(obtenerPropietarioIdCommand.ExecuteScalar());

                    // Insertar la relación en la tabla Propietario_piso
                    string insertRelacionQuery = "INSERT INTO Propietario_piso (PisoId, PropietarioId) VALUES (@pisoId, @propietarioId);";
                    MySqlCommand insertRelacionCommand = new MySqlCommand(insertRelacionQuery, connection);
                    insertRelacionCommand.Parameters.AddWithValue("@pisoId", pisoId);
                    insertRelacionCommand.Parameters.AddWithValue("@propietarioId", propietarioId);

                    insertRelacionCommand.ExecuteNonQuery();

                    MessageBox.Show("Propietario y relación con piso insertados correctamente.");
                }
                catch (Exception ex)
                {
                    MessageBox.Show(ex.Message);
                }
            }
        }


        public static void InsertarPortal(Portal portal)
        {
            using (MySqlConnection connection = new MySqlConnection(connectionString))
            {
                try
                {
                    connection.Open();

                    string sqlQuery = "INSERT INTO Portales (Escaleras, ComunidadId) VALUES (@Escaleras, @ComunidadId)";

                    MySqlCommand cmd = new MySqlCommand(sqlQuery, connection);

                    cmd.Parameters.AddWithValue("@Escaleras", portal.Escaleras);
                    cmd.Parameters.AddWithValue("@ComunidadId", portal.ComunidadId);

                    cmd.ExecuteNonQuery();

                    MessageBox.Show("Portal agregado");
                }
                catch (Exception ex)
                {
                    MessageBox.Show(ex.Message);
                }
            }
        }

        public static void InsertarEscalera(Escalera escalera)
        {
            using (MySqlConnection connection = new MySqlConnection(connectionString))
            {
                try
                {
                    connection.Open();

                    string sqlQuery = "INSERT INTO Escaleras (PortalId, numeroPlantas) VALUES (@PortalId, @numeroPlantas)";

                    MySqlCommand cmd = new MySqlCommand(sqlQuery, connection);

                    cmd.Parameters.AddWithValue("@PortalId", escalera.PortalId);
                    cmd.Parameters.AddWithValue("@numeroPlantas", escalera.Numero);

                    cmd.ExecuteNonQuery();

                    MessageBox.Show("Escalera agregada");
                }
                catch (Exception ex)
                {
                    MessageBox.Show(ex.Message);
                }
            }
        }

        public static void InsertarPlanta(Planta planta)
        {
            using (MySqlConnection connection = new MySqlConnection(connectionString))
            {
                try
                {
                    connection.Open();

                    string sqlQuery = "INSERT INTO Plantas (EscaleraId, NumeroApartamentos) VALUES (@EscaleraId, @Numero)";

                    MySqlCommand cmd = new MySqlCommand(sqlQuery, connection);

                    cmd.Parameters.AddWithValue("@EscaleraId", planta.EscaleraId);
                    cmd.Parameters.AddWithValue("@Numero", planta.Numero);

                    cmd.ExecuteNonQuery();

                    MessageBox.Show("Planta agregada");
                }
                catch (Exception ex)
                {
                    MessageBox.Show(ex.Message);

                }
            }
        }

        public static int[] ObtenerEscalerasId(int portalId)
        {
            string query = "SELECT EscaleraId FROM Escaleras WHERE PortalId = @portalId";

            using (MySqlConnection connection = new MySqlConnection(connectionString))
            {
                connection.Open();

                using (MySqlCommand command = new MySqlCommand(query, connection))
                {
                    // Agrega los parámetros a la consulta
                    command.Parameters.AddWithValue("@portalId", portalId);

                    using (MySqlDataReader reader = command.ExecuteReader())
                    {
                        List<int> escaleraIds = new List<int>();

                        while (reader.Read())
                        {
                            int escaleraId = reader.GetInt32("EscaleraId");
                            escaleraIds.Add(escaleraId);
                        }

                        // Convertir la lista de escaleraIds a un array de int
                        return escaleraIds.ToArray();
                    }
                }
            }
        }


        public static int[] ObtenerPortalesPorComunidadId(int comunidadId)
        {
            List<int> portalIds = new List<int>();

            try
            {
                using (MySqlConnection connection = new MySqlConnection(connectionString))
                {
                    connection.Open();

                    string query = "SELECT PortalId FROM portales WHERE ComunidadId = @comunidadId";

                    using (MySqlCommand command = new MySqlCommand(query, connection))
                    {
                        command.Parameters.AddWithValue("@comunidadId", comunidadId);

                        using (MySqlDataReader reader = command.ExecuteReader())
                        {
                            while (reader.Read())
                            {
                                int portalId = reader.GetInt32("PortalId");
                                portalIds.Add(portalId);
                            }
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }

            return portalIds.ToArray();
        }


        public static void InsertarApartamento(Apartamento apartamento)
        {
            using (MySqlConnection connection = new MySqlConnection(connectionString))
            {
                try
                {
                    connection.Open();

                    // Insertar el Apartamento y obtener su ID
                    string insertApartamentoQuery = "INSERT INTO Apartamentos (PlantaId, Letra) VALUES (@PlantaId, @Letra); SELECT LAST_INSERT_ID();";

                    using (MySqlCommand cmd = new MySqlCommand(insertApartamentoQuery, connection))
                    {
                        cmd.Parameters.AddWithValue("@PlantaId", apartamento.PlantaId);
                        cmd.Parameters.AddWithValue("@Letra", apartamento.Letra);

                        int apartamentoId = Convert.ToInt32(cmd.ExecuteScalar());

                        // Insertar el Trastero
                        string insertTrasteroQuery = "INSERT INTO Trasteros (ApartamentoId) VALUES (@ApartamentoId);";
                        using (MySqlCommand trasteroCmd = new MySqlCommand(insertTrasteroQuery, connection))
                        {
                            trasteroCmd.Parameters.AddWithValue("@ApartamentoId", apartamentoId);
                            trasteroCmd.ExecuteNonQuery();
                        }

                        // Insertar el Garaje
                        string insertGarajeQuery = "INSERT INTO Garaje (ApartamentoId) VALUES (@ApartamentoId);";
                        using (MySqlCommand garajeCmd = new MySqlCommand(insertGarajeQuery, connection))
                        {
                            garajeCmd.Parameters.AddWithValue("@ApartamentoId", apartamentoId);
                            garajeCmd.ExecuteNonQuery();
                        }

                        MessageBox.Show("Apartamento, Trastero y Garaje agregados con éxito.");
                    }
                }
                catch (Exception ex)
                {
                    MessageBox.Show(ex.Message);

                }
            }
        }



        public static int ObtenerComunidadId(String nombre)
        {
            string query = "SELECT ComunidadId FROM Comunidades WHERE Nombre = @nombreComunidad";

            using (MySqlConnection connection = new MySqlConnection(connectionString))
            {
                connection.Open();

                using (MySqlCommand command = new MySqlCommand(query, connection))
                {
                    // Agrega el parámetro del nombre de la comunidad
                    command.Parameters.AddWithValue("@nombreComunidad", nombre);

                    using (MySqlDataReader reader = command.ExecuteReader())
                    {
                        if (reader.Read())
                        {
                            // Obtiene el valor de ComunidadId
                            int comunidadId = reader.GetInt32("ComunidadId");
                            Console.WriteLine($"El valor de ComunidadId para {nombre} es: {comunidadId}");
                            return comunidadId;
                        }
                        else
                        {
                            Console.WriteLine($"No se encontraron resultados para {nombre}.");
                            return -1;
                        }
                    }
                }
            }
        }

        public static int[] ObtenerApartamentosIdPorPlanta(int plantaId)
        {
            List<int> apartamentosIds = new List<int>();

            using (MySqlConnection connection = new MySqlConnection(connectionString))
            {
                try
                {
                    connection.Open();

                    string query = "SELECT ApartamentoId FROM Apartamentos WHERE PlantaId = @PlantaId";

                    using (MySqlCommand command = new MySqlCommand(query, connection))
                    {
                        command.Parameters.AddWithValue("@PlantaId", plantaId);

                        using (MySqlDataReader reader = command.ExecuteReader())
                        {
                            while (reader.Read())
                            {
                                int apartamentoId = reader.GetInt32("ApartamentoId");
                                apartamentosIds.Add(apartamentoId);
                            }
                        }
                    }
                }
                catch (Exception ex)
                {
                    MessageBox.Show(ex.Message);
                }
            }

            return apartamentosIds.ToArray();
        }

        public static int[] ObtenerPlantasId(int escaleraId)
        {
            string query = "SELECT PlantaId FROM Plantas WHERE EscaleraId = @escaleraId";

            using (MySqlConnection connection = new MySqlConnection(connectionString))
            {
                connection.Open();

                using (MySqlCommand command = new MySqlCommand(query, connection))
                {
                    // Agrega el parámetro a la consulta
                    command.Parameters.AddWithValue("@escaleraId", escaleraId);

                    using (MySqlDataReader reader = command.ExecuteReader())
                    {
                        List<int> plantaIds = new List<int>();

                        while (reader.Read())
                        {
                            int plantaId = reader.GetInt32("PlantaId");
                            plantaIds.Add(plantaId);
                        }

                        // Convertir la lista de plantaIds a un array de int
                        return plantaIds.ToArray();
                    }
                }
            }
        }


        public static Comunidad[] ObtenerComunidades()
        {
            List<Comunidad> comunidades = new List<Comunidad>();

            using (MySqlConnection connection = new MySqlConnection(connectionString))
            {
                connection.Open();

                string query = "SELECT * FROM Comunidades";

                using (MySqlCommand command = new MySqlCommand(query, connection))
                {
                    using (MySqlDataReader reader = command.ExecuteReader())
                    {
                        while (reader.Read())
                        {
                            Comunidad comunidad = new Comunidad {
                                Nombre = reader["Nombre"].ToString(),
                                Direccion = reader["Direccion"].ToString(),
                                Fecha = Convert.ToDateTime(reader["FechaCreacion"]),
                                Metros = Convert.ToInt32(reader["MetrosCuadrados"]),
                                Piscina = Convert.ToBoolean(reader["TienePiscina"]),
                                Portero = Convert.ToBoolean(reader["PisoPortero"]),
                                Shower = Convert.ToBoolean(reader["DuchasBano"]),
                                Play = Convert.ToBoolean(reader["ParqueInfantil"]),
                                Exercise = Convert.ToBoolean(reader["MaquinasEjercicio"]),
                                Meeting = Convert.ToBoolean(reader["SalaReuniones"]),
                                Tenis = Convert.ToBoolean(reader["PistaTenis"]),
                                Padel = Convert.ToBoolean(reader["PistaPadel"])
                            };

                            comunidades.Add(comunidad);
                        }
                    }
                }
            }

            return comunidades.ToArray();
        }


        public static ObservableCollection<Propietario> ObtenerPropietarios()
        {
            ObservableCollection<Propietario> propietarios = new ObservableCollection<Propietario>();

            try
            {
                using (MySqlConnection connection = new MySqlConnection(connectionString))
                {
                    connection.Open();

                    string query = "SELECT * FROM Propietario";
                    using (MySqlCommand command = new MySqlCommand(query, connection))
                    {
                        using (MySqlDataReader reader = command.ExecuteReader())
                        {
                            while (reader.Read())
                            {
                                Propietario propietario = new Propietario
                                {
                                    Dni = reader["dni"].ToString(),
                                    Nombre = reader["nombre"].ToString(),
                                    Apellidos = reader["apellidos"].ToString(),
                                    Localidad = reader["localidad"].ToString(),
                                    Direccion = reader["direccion"].ToString(),
                                    Cp = reader["cp"].ToString(),
                                    Provincia = reader["provincia"].ToString()
                                };

                                propietarios.Add(propietario);
                            }
                        }
                    }
                }
            }
            catch (Exception ex) 
            {
                //MessageBox.Show(ex.Message);
            }

            return propietarios;
        }

        public static ObservableCollection<Planta> ObtenerPlantas()
        {
            ObservableCollection<Planta> plantas = new ObservableCollection<Planta>();

            try
            {
                using (MySqlConnection connection = new MySqlConnection(connectionString))
                {
                    connection.Open();

                    string query = "SELECT * FROM Planta";

                    using (MySqlCommand command = new MySqlCommand(query, connection))
                    {
                        using (MySqlDataReader reader = command.ExecuteReader())
                        {
                            while (reader.Read())
                            {
                                Planta planta = new Planta
                                {
                                    PlantaId = Convert.ToInt32(reader["PlantaId"]),
                                    EscaleraId = Convert.ToInt32(reader["EscaleraId"]),
                                    Numero = Convert.ToInt32(reader["Numero"])
                                };

                                plantas.Add(planta);
                            }
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                //MessageBox.Show(ex.Message);
            }

            return plantas;
        }

        public static ObservableCollection<Apartamento> ObtenerApartamentos()
        {
            ObservableCollection<Apartamento> apartamentos = new ObservableCollection<Apartamento>();

            try
            {
                using (MySqlConnection connection = new MySqlConnection(connectionString))
                {
                    connection.Open();

                    string query = "SELECT * FROM Apartamento";

                    using (MySqlCommand command = new MySqlCommand(query, connection))
                    {
                        using (MySqlDataReader reader = command.ExecuteReader())
                        {
                            while (reader.Read())
                            {
                                Apartamento apartamento = new Apartamento
                                {
                                    ApartamentoId = Convert.ToInt32(reader["ApartamentoId"]),
                                    GarajeId = Convert.ToInt32(reader["GarajeId"]),
                                    TrasteroId = Convert.ToInt32(reader["TrasteroId"]),
                                    PlantaId = Convert.ToInt32(reader["PlantaId"]),
                                    Letra = Convert.ToString(reader["Letra"])
                                };

                                apartamentos.Add(apartamento);
                            }
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                //MessageBox.Show(ex.Message);
            }

            return apartamentos;
        }
        public static ObservableCollection<Comunidad> ObtenerComunidadesOC()
        {
            ObservableCollection<Comunidad> comunidades = new ObservableCollection<Comunidad>();

            try
            {
                using (MySqlConnection connection = new MySqlConnection(connectionString))
                {
                    connection.Open();

                    string query = "SELECT * FROM Comunidad";

                    using (MySqlCommand command = new MySqlCommand(query, connection))
                    {
                        using (MySqlDataReader reader = command.ExecuteReader())
                        {
                            while (reader.Read())
                            {
                                Comunidad comunidad = new Comunidad
                                {
                                    Nombre = Convert.ToString(reader["Nombre"]),
                                    Direccion = Convert.ToString(reader["Direccion"]),
                                    Fecha = Convert.ToDateTime(reader["Fecha"]),
                                    Metros = Convert.ToInt32(reader["Metros"]),
                                    Padel = Convert.ToBoolean(reader["Padel"]),
                                    Tenis = Convert.ToBoolean(reader["Tenis"]),
                                    Meeting = Convert.ToBoolean(reader["Meeting"]),
                                    Exercise = Convert.ToBoolean(reader["Exercise"]),
                                    Play = Convert.ToBoolean(reader["Play"]),
                                    Shower = Convert.ToBoolean(reader["Shower"]),
                                    Portero = Convert.ToBoolean(reader["Portero"]),
                                    Piscina = Convert.ToBoolean(reader["Piscina"])
                                };

                                comunidades.Add(comunidad);
                            }
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                // Manejar la excepción de alguna manera (mostrar mensaje, registrarla, etc.)
                Console.WriteLine("Error al obtener comunidades: " + ex.Message);
            }

            return comunidades;
        }


    }
}
