using System.Data.SqlClient;
using SistemaVotaciones.Entidades;

namespace SistemaVotaciones.DAL
{
    public class UsuarioDAL
    {
        private ConexionDB conexion = new ConexionDB();

        public Usuario ObtenerUsuario(string username, string password)
        {
            using (SqlConnection conn = conexion.ObtenerConexion())
            {
                conn.Open();

                string query = "SELECT * FROM Usuarios WHERE Username=@user AND Password=@pass";

                SqlCommand cmd = new SqlCommand(query, conn);
                cmd.Parameters.AddWithValue("@user", username);
                cmd.Parameters.AddWithValue("@pass", password);

                SqlDataReader reader = cmd.ExecuteReader();

                if (reader.Read())
                {
                    return new Usuario
                    {
                        IdUsuario = (int)reader["IdUsuario"],
                        Username = reader["Username"].ToString(),
                        Password = reader["Password"].ToString(),
                        IdRol = (int)reader["IdRol"],
                        IdPadron = (int)reader["IdPadron"],
                        EstadoUsuario = (bool)reader["EstadoUsuario"],
                        YaVoto = (bool)reader["YaVoto"]
                    };
                }

                return null;
            }
        }
    }
}