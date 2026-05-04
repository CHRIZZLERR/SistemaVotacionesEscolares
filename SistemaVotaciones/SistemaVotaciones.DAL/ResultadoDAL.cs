using System;
using System.Data;
using System.Data.SqlClient;

namespace SistemaVotaciones.DAL
{
    public class ResultadoDAL
    {
        private ConexionDB conexion = new ConexionDB();

        public int TotalVotos()
        {
            using (SqlConnection conn = conexion.ObtenerConexion())
            {
                conn.Open();

                string query = "SELECT COUNT(*) FROM Votos";

                SqlCommand cmd = new SqlCommand(query, conn);

                return (int)cmd.ExecuteScalar();
            }
        }

        public int TotalVotosNulos()
        {
            using (SqlConnection conn = conexion.ObtenerConexion())
            {
                conn.Open();

                string query = "SELECT COUNT(*) FROM Votos WHERE EsNulo = 1";

                SqlCommand cmd = new SqlCommand(query, conn);

                return (int)cmd.ExecuteScalar();
            }
        }

        public int TotalVotantes()
        {
            using (SqlConnection conn = conexion.ObtenerConexion())
            {
                conn.Open();

                string query = "SELECT COUNT(*) FROM Usuarios WHERE IdRol = 2 AND EstadoUsuario = 1";

                SqlCommand cmd = new SqlCommand(query, conn);

                return (int)cmd.ExecuteScalar();
            }
        }

        public DataTable ResultadosPorPlancha()
        {
            using (SqlConnection conn = conexion.ObtenerConexion())
            {
                conn.Open();

                string query = @"
                SELECT 
                    P.NombrePlancha AS Plancha,
                    COUNT(V.IdVoto) AS Votos,
                    CAST(
                        COUNT(V.IdVoto) * 100.0 / 
                        NULLIF((SELECT COUNT(*) FROM Votos), 0)
                        AS DECIMAL(10,2)
                    ) AS Porcentaje
                FROM Planchas P
                LEFT JOIN Votos V ON P.IdPlancha = V.IdPlancha AND V.EsNulo = 0
                GROUP BY P.NombrePlancha
                ORDER BY Votos DESC";

                SqlDataAdapter da = new SqlDataAdapter(query, conn);
                DataTable dt = new DataTable();
                da.Fill(dt);

                return dt;
            }
        }

        public string PlanchaGanadora()
        {
            using (SqlConnection conn = conexion.ObtenerConexion())
            {
                conn.Open();

                string query = @"
                SELECT TOP 1 
                    P.NombrePlancha
                FROM Planchas P
                INNER JOIN Votos V ON P.IdPlancha = V.IdPlancha
                WHERE V.EsNulo = 0
                GROUP BY P.NombrePlancha
                ORDER BY COUNT(V.IdVoto) DESC";

                SqlCommand cmd = new SqlCommand(query, conn);

                object result = cmd.ExecuteScalar();

                if (result == null)
                    return "Ninguna";

                return result.ToString();
            }
        }
    }
}