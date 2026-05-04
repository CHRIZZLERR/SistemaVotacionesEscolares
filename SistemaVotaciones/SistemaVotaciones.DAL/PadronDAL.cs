using System.Data;
using System.Data.SqlClient;
using SistemaVotaciones.Entidades;

namespace SistemaVotaciones.DAL
{
    public class PadronDAL
    {
        private ConexionDB conexion = new ConexionDB();

        public bool CrearPadron(Padron padron)
        {
            using (SqlConnection conn = conexion.ObtenerConexion())
            {
                conn.Open();

                string query = @"INSERT INTO PadronesElectorales
                                (Nivel, Grado, Seccion, Modalidad, NombrePadron)
                                VALUES
                                (@Nivel, @Grado, @Seccion, @Modalidad, @NombrePadron)";

                SqlCommand cmd = new SqlCommand(query, conn);

                cmd.Parameters.AddWithValue("@Nivel", padron.Nivel);
                cmd.Parameters.AddWithValue("@Grado", padron.Grado);
                cmd.Parameters.AddWithValue("@Seccion", padron.Seccion);
                cmd.Parameters.AddWithValue("@Modalidad", padron.Modalidad);
                cmd.Parameters.AddWithValue("@NombrePadron", padron.NombrePadron);

                return cmd.ExecuteNonQuery() > 0;
            }
        }

        public DataTable ListarPadrones()
        {
            using (SqlConnection conn = conexion.ObtenerConexion())
            {
                conn.Open();

                string query = @"SELECT 
                                    IdPadron,
                                    NombrePadron,
                                    Nivel,
                                    Grado,
                                    Seccion,
                                    Modalidad
                                 FROM PadronesElectorales
                                 ORDER BY IdPadron";

                SqlDataAdapter da = new SqlDataAdapter(query, conn);
                DataTable dt = new DataTable();
                da.Fill(dt);

                return dt;
            }
        }

        public bool ExistePadron(string nombrePadron)
        {
            using (SqlConnection conn = conexion.ObtenerConexion())
            {
                conn.Open();

                string query = @"SELECT COUNT(*) 
                                 FROM PadronesElectorales
                                 WHERE NombrePadron = @NombrePadron";

                SqlCommand cmd = new SqlCommand(query, conn);
                cmd.Parameters.AddWithValue("@NombrePadron", nombrePadron);

                int cantidad = (int)cmd.ExecuteScalar();

                return cantidad > 0;
            }
        }
    }
}