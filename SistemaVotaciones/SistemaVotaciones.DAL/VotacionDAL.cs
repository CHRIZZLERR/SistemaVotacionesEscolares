using System.Data;
using System.Data.SqlClient;
using SistemaVotaciones.Entidades;

namespace SistemaVotaciones.DAL
{
    public class VotacionDAL
    {
        private ConexionDB conexion = new ConexionDB();

        public bool CrearVotacion(Votacion votacion)
        {
            using (SqlConnection conn = conexion.ObtenerConexion())
            {
                conn.Open();

                string query = @"INSERT INTO Votaciones
                (NombreVotacion, IdPadron, FechaInicio, FechaFin, EstadoVotacion)
                VALUES (@nombre, @padron, @inicio, @fin, @estado)";

                SqlCommand cmd = new SqlCommand(query, conn);
                cmd.Parameters.AddWithValue("@nombre", votacion.NombreVotacion);
                cmd.Parameters.AddWithValue("@padron", votacion.IdPadron);
                cmd.Parameters.AddWithValue("@inicio", votacion.FechaInicio);
                cmd.Parameters.AddWithValue("@fin", votacion.FechaFin);
                cmd.Parameters.AddWithValue("@estado", votacion.EstadoVotacion);

                return cmd.ExecuteNonQuery() > 0;
            }
        }

        public DataTable ListarVotaciones()
        {
            using (SqlConnection conn = conexion.ObtenerConexion())
            {
                conn.Open();

                string query = @"SELECT 
                                V.IdVotacion,
                                V.NombreVotacion,
                                P.NombrePadron,
                                V.FechaInicio,
                                V.FechaFin,
                                V.EstadoVotacion
                                FROM Votaciones V
                                INNER JOIN PadronesElectorales P
                                ON V.IdPadron = P.IdPadron";

                SqlDataAdapter da = new SqlDataAdapter(query, conn);
                DataTable dt = new DataTable();
                da.Fill(dt);

                return dt;
            }
        }

        public DataTable ListarPadrones()
        {
            using (SqlConnection conn = conexion.ObtenerConexion())
            {
                conn.Open();

                string query = "SELECT IdPadron, NombrePadron FROM PadronesElectorales";

                SqlDataAdapter da = new SqlDataAdapter(query, conn);
                DataTable dt = new DataTable();
                da.Fill(dt);

                return dt;
            }
        }
    }
}