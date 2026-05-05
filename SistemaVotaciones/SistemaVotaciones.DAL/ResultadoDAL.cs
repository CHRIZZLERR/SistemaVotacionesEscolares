using System.Data;
using System.Data.SqlClient;
using SistemaVotaciones.Entidades;

namespace SistemaVotaciones.DAL
{
    public class ResultadoDAL
    {
        private ConexionDB conexion = new ConexionDB();

        public int TotalVotos(Usuario usuarioActual)
        {
            using (SqlConnection conn = conexion.ObtenerConexion())
            {
                conn.Open();

                string query;

                if (usuarioActual != null && usuarioActual.IdRol == 3)
                {
                    query = @"
                    SELECT COUNT(*)
                    FROM Votos V
                    INNER JOIN Planchas P ON V.IdPlancha = P.IdPlancha
                    WHERE P.IdAdminPlancha = @IdAdminPlancha";
                }
                else
                {
                    query = "SELECT COUNT(*) FROM Votos";
                }

                SqlCommand cmd = new SqlCommand(query, conn);

                if (usuarioActual != null && usuarioActual.IdRol == 3)
                {
                    cmd.Parameters.AddWithValue("@IdAdminPlancha", usuarioActual.IdUsuario);
                }

                return (int)cmd.ExecuteScalar();
            }
        }

        public int TotalVotosNulos(Usuario usuarioActual)
        {
            using (SqlConnection conn = conexion.ObtenerConexion())
            {
                conn.Open();

                string query;

                if (usuarioActual != null && usuarioActual.IdRol == 3)
                {
                    query = @"
                    SELECT COUNT(*)
                    FROM Votos V
                    INNER JOIN Planchas P ON V.IdPlancha = P.IdPlancha
                    WHERE V.EsNulo = 1
                    AND P.IdAdminPlancha = @IdAdminPlancha";
                }
                else
                {
                    query = "SELECT COUNT(*) FROM Votos WHERE EsNulo = 1";
                }

                SqlCommand cmd = new SqlCommand(query, conn);

                if (usuarioActual != null && usuarioActual.IdRol == 3)
                {
                    cmd.Parameters.AddWithValue("@IdAdminPlancha", usuarioActual.IdUsuario);
                }

                return (int)cmd.ExecuteScalar();
            }
        }

        public int TotalVotantes()
        {
            using (SqlConnection conn = conexion.ObtenerConexion())
            {
                conn.Open();

                string query = @"
                SELECT COUNT(*)
                FROM Usuarios
                WHERE IdRol = 2
                AND EstadoUsuario = 1";

                SqlCommand cmd = new SqlCommand(query, conn);

                return (int)cmd.ExecuteScalar();
            }
        }

        public DataTable ResultadosPorPlancha(Usuario usuarioActual)
        {
            using (SqlConnection conn = conexion.ObtenerConexion())
            {
                conn.Open();

                string query;

                if (usuarioActual != null && usuarioActual.IdRol == 3)
                {
                    query = @"
                    SELECT 
                        P.NombrePlancha AS Plancha,
                        COUNT(V.IdVoto) AS Votos,
                        CAST(
                            COUNT(V.IdVoto) * 100.0 / 
                            NULLIF((
                                SELECT COUNT(*) 
                                FROM Votos V2
                                INNER JOIN Planchas P2 ON V2.IdPlancha = P2.IdPlancha
                                WHERE V2.EsNulo = 0
                                AND P2.IdAdminPlancha = @IdAdminPlancha
                            ), 0)
                            AS DECIMAL(10,2)
                        ) AS Porcentaje
                    FROM Planchas P
                    LEFT JOIN Votos V ON P.IdPlancha = V.IdPlancha AND V.EsNulo = 0
                    WHERE P.IdAdminPlancha = @IdAdminPlancha
                    GROUP BY P.NombrePlancha
                    ORDER BY Votos DESC";
                }
                else
                {
                    query = @"
                    SELECT 
                        P.NombrePlancha AS Plancha,
                        COUNT(V.IdVoto) AS Votos,
                        CAST(
                            COUNT(V.IdVoto) * 100.0 / 
                            NULLIF((SELECT COUNT(*) FROM Votos WHERE EsNulo = 0), 0)
                            AS DECIMAL(10,2)
                        ) AS Porcentaje
                    FROM Planchas P
                    LEFT JOIN Votos V ON P.IdPlancha = V.IdPlancha AND V.EsNulo = 0
                    GROUP BY P.NombrePlancha
                    ORDER BY Votos DESC";
                }

                SqlCommand cmd = new SqlCommand(query, conn);

                if (usuarioActual != null && usuarioActual.IdRol == 3)
                {
                    cmd.Parameters.AddWithValue("@IdAdminPlancha", usuarioActual.IdUsuario);
                }

                SqlDataAdapter da = new SqlDataAdapter(cmd);
                DataTable dt = new DataTable();
                da.Fill(dt);

                return dt;
            }
        }

        public string PlanchaGanadora(Usuario usuarioActual)
        {
            using (SqlConnection conn = conexion.ObtenerConexion())
            {
                conn.Open();

                string query;

                if (usuarioActual != null && usuarioActual.IdRol == 3)
                {
                    query = @"
                    SELECT TOP 1 
                        P.NombrePlancha
                    FROM Planchas P
                    INNER JOIN Votos V ON P.IdPlancha = V.IdPlancha
                    WHERE V.EsNulo = 0
                    AND P.IdAdminPlancha = @IdAdminPlancha
                    GROUP BY P.NombrePlancha
                    ORDER BY COUNT(V.IdVoto) DESC";
                }
                else
                {
                    query = @"
                    SELECT TOP 1 
                        P.NombrePlancha
                    FROM Planchas P
                    INNER JOIN Votos V ON P.IdPlancha = V.IdPlancha
                    WHERE V.EsNulo = 0
                    GROUP BY P.NombrePlancha
                    ORDER BY COUNT(V.IdVoto) DESC";
                }

                SqlCommand cmd = new SqlCommand(query, conn);

                if (usuarioActual != null && usuarioActual.IdRol == 3)
                {
                    cmd.Parameters.AddWithValue("@IdAdminPlancha", usuarioActual.IdUsuario);
                }

                object result = cmd.ExecuteScalar();

                if (result == null)
                    return "Ninguna";

                return result.ToString();
            }
        }
    }
}