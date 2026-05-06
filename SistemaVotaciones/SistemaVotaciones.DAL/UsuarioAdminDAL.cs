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

        public DataTable ListarPadrones()
        {
            using (SqlConnection conn = conexion.ObtenerConexion())
            {
                conn.Open();

                string query = @"
                SELECT IdPadron, NombrePadron
                FROM PadronesElectorales
                ORDER BY NombrePadron";

                SqlDataAdapter da = new SqlDataAdapter(query, conn);
                DataTable dt = new DataTable();
                da.Fill(dt);

                return dt;
            }
        }

        public bool ExisteUsuarioOMatricula(string username, string matricula)
        {
            using (SqlConnection conn = conexion.ObtenerConexion())
            {
                conn.Open();

                string query = @"
                SELECT COUNT(*)
                FROM Usuarios
                WHERE Username = @Username
                OR Matricula = @Matricula";

                SqlCommand cmd = new SqlCommand(query, conn);
                cmd.Parameters.AddWithValue("@Username", username);
                cmd.Parameters.AddWithValue("@Matricula", matricula);

                int cantidad = (int)cmd.ExecuteScalar();

                return cantidad > 0;
            }
        }

        public bool CrearAdministradorPlancha(Usuario usuario)
        {
            using (SqlConnection conn = conexion.ObtenerConexion())
            {
                conn.Open();

                string query = @"
                INSERT INTO Usuarios
                (
                    Matricula,
                    NombreCompleto,
                    Nivel,
                    Grado,
                    Seccion,
                    Modalidad,
                    Username,
                    Password,
                    IdRol,
                    IdPadron,
                    EstadoUsuario,
                    YaVoto
                )
                VALUES
                (
                    @Matricula,
                    @NombreCompleto,
                    @Nivel,
                    @Grado,
                    @Seccion,
                    @Modalidad,
                    @Username,
                    @Password,
                    3,
                    @IdPadron,
                    1,
                    0
                )";

                SqlCommand cmd = new SqlCommand(query, conn);

                cmd.Parameters.AddWithValue("@Matricula", usuario.Matricula);
                cmd.Parameters.AddWithValue("@NombreCompleto", usuario.NombreCompleto);
                cmd.Parameters.AddWithValue("@Nivel", usuario.Nivel);
                cmd.Parameters.AddWithValue("@Grado", usuario.Grado);
                cmd.Parameters.AddWithValue("@Seccion", usuario.Seccion);
                cmd.Parameters.AddWithValue("@Modalidad", usuario.Modalidad);
                cmd.Parameters.AddWithValue("@Username", usuario.Username);
                cmd.Parameters.AddWithValue("@Password", usuario.Password);
                cmd.Parameters.AddWithValue("@IdPadron", usuario.IdPadron);

                return cmd.ExecuteNonQuery() > 0;
            }
        }
    }
}