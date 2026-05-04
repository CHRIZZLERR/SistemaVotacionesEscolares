using System.Data;
using System.Data.SqlClient;

namespace SistemaVotaciones.DAL
{
    public class ReporteDAL
    {
        private ConexionDB conexion = new ConexionDB();

        public DataTable ReporteGeneralVotos()
        {
            using (SqlConnection conn = conexion.ObtenerConexion())
            {
                conn.Open();

                string query = @"
                SELECT 
                    V.IdVoto,
                    U.NombreCompleto AS Votante,
                    U.Matricula,
                    PE.NombrePadron,
                    ISNULL(P.NombrePlancha, 'VOTO NULO') AS Plancha,
                    CASE WHEN V.EsNulo = 1 THEN 'Sí' ELSE 'No' END AS EsNulo,
                    V.FechaVoto
                FROM Votos V
                INNER JOIN Usuarios U ON V.IdUsuario = U.IdUsuario
                INNER JOIN PadronesElectorales PE ON U.IdPadron = PE.IdPadron
                LEFT JOIN Planchas P ON V.IdPlancha = P.IdPlancha
                ORDER BY V.FechaVoto DESC";

                SqlDataAdapter da = new SqlDataAdapter(query, conn);
                DataTable dt = new DataTable();
                da.Fill(dt);

                return dt;
            }
        }

        public DataTable ReportePlanchaGanadora()
        {
            using (SqlConnection conn = conexion.ObtenerConexion())
            {
                conn.Open();

                string query = @"
                SELECT TOP 1
                    P.NombrePlancha AS Plancha,
                    COUNT(V.IdVoto) AS Votos,
                    CAST(COUNT(V.IdVoto) * 100.0 / NULLIF((SELECT COUNT(*) FROM Votos), 0) AS DECIMAL(10,2)) AS Porcentaje
                FROM Planchas P
                INNER JOIN Votos V ON P.IdPlancha = V.IdPlancha
                WHERE V.EsNulo = 0
                GROUP BY P.NombrePlancha
                ORDER BY COUNT(V.IdVoto) DESC";

                SqlDataAdapter da = new SqlDataAdapter(query, conn);
                DataTable dt = new DataTable();
                da.Fill(dt);

                return dt;
            }
        }

        public DataTable ReporteIntegrantesPlancha()
        {
            using (SqlConnection conn = conexion.ObtenerConexion())
            {
                conn.Open();

                string query = @"
                SELECT
                    P.NombrePlancha AS Plancha,
                    C.NombreCargo AS Cargo,
                    U.NombreCompleto AS Integrante,
                    U.Matricula
                FROM IntegrantesPlancha IP
                INNER JOIN Planchas P ON IP.IdPlancha = P.IdPlancha
                INNER JOIN Cargos C ON IP.IdCargo = C.IdCargo
                INNER JOIN Usuarios U ON IP.IdUsuario = U.IdUsuario
                ORDER BY P.NombrePlancha, C.Orden";

                SqlDataAdapter da = new SqlDataAdapter(query, conn);
                DataTable dt = new DataTable();
                da.Fill(dt);

                return dt;
            }
        }

        public DataTable ReporteUsuarios()
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
                    R.NombreRol,
                    PE.NombrePadron,
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
    }
}