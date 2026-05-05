using System.Data;
using System.Data.SqlClient;
using SistemaVotaciones.Entidades;

namespace SistemaVotaciones.DAL
{
    public class UsuarioAdminDAL
    {
        private ConexionDB conexion = new ConexionDB();

        public DataTable ListarUsuarios(Usuario usuarioActual)
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
                    ISNULL(P.NombrePlancha, 'N/A') AS Plancha,
                    ISNULL(C.NombreCargo, 'N/A') AS Cargo,
                    CASE WHEN U.EstadoUsuario = 1 THEN 'Activo' ELSE 'Inactivo' END AS Estado,
                    CASE WHEN U.YaVoto = 1 THEN 'Sí' ELSE 'No' END AS YaVoto
                FROM Usuarios U
                INNER JOIN Roles R ON U.IdRol = R.IdRol
                INNER JOIN PadronesElectorales PE ON U.IdPadron = PE.IdPadron
                LEFT JOIN IntegrantesPlancha IP ON U.IdUsuario = IP.IdUsuario
                LEFT JOIN Planchas P ON IP.IdPlancha = P.IdPlancha
                LEFT JOIN Cargos C ON IP.IdCargo = C.IdCargo
                WHERE
                    @IdRol = 1
                    OR
                    (
                        @IdRol = 3
                        AND
                        (
                            U.IdUsuario = @IdUsuario
                            OR U.IdUsuario IN (
                                SELECT IP2.IdUsuario
                                FROM IntegrantesPlancha IP2
                                INNER JOIN Planchas P2 ON IP2.IdPlancha = P2.IdPlancha
                                WHERE P2.IdAdminPlancha = @IdUsuario
                            )
                        )
                    )
                ORDER BY U.IdUsuario";

                SqlCommand cmd = new SqlCommand(query, conn);
                cmd.Parameters.AddWithValue("@IdRol", usuarioActual.IdRol);
                cmd.Parameters.AddWithValue("@IdUsuario", usuarioActual.IdUsuario);

                SqlDataAdapter da = new SqlDataAdapter(cmd);
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