using System.Data;
using System.Data.SqlClient;

namespace SistemaVotaciones.DAL
{
    public class InfoVotacionDAL
    {
        private ConexionDB conexion = new ConexionDB();

        public DataTable ObtenerInfoVotacionPorPadron(int idPadron)
        {
            using (SqlConnection conn = conexion.ObtenerConexion())
            {
                conn.Open();

                string query = @"
                SELECT TOP 1
                    V.IdVotacion,
                    V.NombreVotacion,
                    PE.NombrePadron,
                    V.FechaInicio,
                    V.FechaFin,
                    V.EstadoVotacion,
                    (
                        SELECT COUNT(*) 
                        FROM Planchas P 
                        WHERE P.IdPadron = V.IdPadron 
                        AND P.EstadoPlancha = 1
                    ) AS CantidadPlanchas
                FROM Votaciones V
                INNER JOIN PadronesElectorales PE ON V.IdPadron = PE.IdPadron
                WHERE V.IdPadron = @IdPadron
                ORDER BY V.IdVotacion DESC";

                SqlCommand cmd = new SqlCommand(query, conn);
                cmd.Parameters.AddWithValue("@IdPadron", idPadron);

                SqlDataAdapter da = new SqlDataAdapter(cmd);
                DataTable dt = new DataTable();
                da.Fill(dt);

                return dt;
            }
        }
    }
}