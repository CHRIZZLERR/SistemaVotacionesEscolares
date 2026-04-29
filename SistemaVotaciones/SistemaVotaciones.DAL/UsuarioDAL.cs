using System;
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
                        Matricula = reader["Matricula"].ToString(),
                        NombreCompleto = reader["NombreCompleto"].ToString(),
                        Nivel = reader["Nivel"].ToString(),
                        Grado = reader["Grado"].ToString(),
                        Seccion = reader["Seccion"].ToString(),
                        Modalidad = reader["Modalidad"].ToString(),
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

        public int ObtenerIdPadron(string nivel, string grado, string seccion, string modalidad)
        {
            using (SqlConnection conn = conexion.ObtenerConexion())
            {
                conn.Open();

                string query = @"SELECT IdPadron 
                                 FROM PadronesElectorales
                                 WHERE Nivel=@nivel 
                                 AND Grado=@grado 
                                 AND Seccion=@seccion 
                                 AND Modalidad=@modalidad";

                SqlCommand cmd = new SqlCommand(query, conn);
                cmd.Parameters.AddWithValue("@nivel", nivel);
                cmd.Parameters.AddWithValue("@grado", grado);
                cmd.Parameters.AddWithValue("@seccion", seccion);
                cmd.Parameters.AddWithValue("@modalidad", modalidad);

                object result = cmd.ExecuteScalar();

                if (result != null)
                    return Convert.ToInt32(result);

                return 0;
            }
        }

        public bool RegistrarUsuario(Usuario usuario)
        {
            using (SqlConnection conn = conexion.ObtenerConexion())
            {
                conn.Open();

                string query = @"INSERT INTO Usuarios
                (Matricula, NombreCompleto, Nivel, Grado, Seccion, Modalidad,
                 Username, Password, IdRol, IdPadron, EstadoUsuario, YaVoto)
                VALUES
                (@Matricula, @NombreCompleto, @Nivel, @Grado, @Seccion, @Modalidad,
                 @Username, @Password, @IdRol, @IdPadron, @EstadoUsuario, @YaVoto)";

                SqlCommand cmd = new SqlCommand(query, conn);

                cmd.Parameters.AddWithValue("@Matricula", usuario.Matricula);
                cmd.Parameters.AddWithValue("@NombreCompleto", usuario.NombreCompleto);
                cmd.Parameters.AddWithValue("@Nivel", usuario.Nivel);
                cmd.Parameters.AddWithValue("@Grado", usuario.Grado);
                cmd.Parameters.AddWithValue("@Seccion", usuario.Seccion);
                cmd.Parameters.AddWithValue("@Modalidad", usuario.Modalidad);
                cmd.Parameters.AddWithValue("@Username", usuario.Username);
                cmd.Parameters.AddWithValue("@Password", usuario.Password);

                cmd.Parameters.AddWithValue("@IdRol", 2);
                cmd.Parameters.AddWithValue("@IdPadron", usuario.IdPadron);
                cmd.Parameters.AddWithValue("@EstadoUsuario", true);
                cmd.Parameters.AddWithValue("@YaVoto", false);

                return cmd.ExecuteNonQuery() > 0;
            }
        }
    }
}