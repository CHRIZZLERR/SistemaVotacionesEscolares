using System.Data;
using System.Data.SqlClient;

namespace SistemaVotaciones.DAL
{
    public class UsuarioAdminDAL
    {
        private ConexionDB conexion = new ConexionDB();

        public DataTable ListarUsuarios()
        {
            using (SqlConnection conn = conexion.ObtenerConexion())
            {
                conn.Open();

                string query = @"
                SELECT
                    U.IdUsuario,
                    U.Matricula,
                    U.NombreCompleto,
                    U.Username,
                    R.NombreRol AS Rol,
                    PE.NombrePadron AS Padron,
                    CASE WHEN U.EstadoUsuario = 1 THEN 'Activo' ELSE 'Inactivo' END AS Estado,
                    CASE WHEN U.YaVoto = 1 THEN 'Sí' ELSE 'No' END AS YaVoto
                FROM Usuarios U
                INNER JOIN Roles R ON U.IdRol = R.IdRol
                INNER JOIN PadronesElectorales PE ON U.IdPadron = PE.IdPadron
                ORDER BY U.IdUsuario";

                SqlDataAdapter da = new SqlDataAdapter(query, conn);
                DataTable dt = new DataTable();
                da.Fill(dt);

                return dt;
            }
        }

        public bool CambiarEstadoUsuario(int idUsuario, bool estado)
        {
            using (SqlConnection conn = conexion.ObtenerConexion())
            {
                conn.Open();

                string query = @"
                UPDATE Usuarios
                SET EstadoUsuario = @EstadoUsuario
                WHERE IdUsuario = @IdUsuario";

                SqlCommand cmd = new SqlCommand(query, conn);
                cmd.Parameters.AddWithValue("@EstadoUsuario", estado);
                cmd.Parameters.AddWithValue("@IdUsuario", idUsuario);

                return cmd.ExecuteNonQuery() > 0;
            }
        }

        public bool ReiniciarVoto(int idUsuario)
        {
            using (SqlConnection conn = conexion.ObtenerConexion())
            {
                conn.Open();

                string query = @"
                UPDATE Usuarios
                SET YaVoto = 0
                WHERE IdUsuario = @IdUsuario";

                SqlCommand cmd = new SqlCommand(query, conn);
                cmd.Parameters.AddWithValue("@IdUsuario", idUsuario);

                return cmd.ExecuteNonQuery() > 0;
            }
        }
    }
}