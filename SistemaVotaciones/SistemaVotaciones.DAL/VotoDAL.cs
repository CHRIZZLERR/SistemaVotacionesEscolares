using System;
using System.Data;
using System.Data.SqlClient;
using SistemaVotaciones.Entidades;

namespace SistemaVotaciones.DAL
{
    public class VotoDAL
    {
        private ConexionDB conexion = new ConexionDB();

        public DataTable ObtenerVotacionAbiertaPorPadron(int idPadron)
        {
            using (SqlConnection conn = conexion.ObtenerConexion())
            {
                conn.Open();

                string query = @"SELECT TOP 1 
                                IdVotacion,
                                NombreVotacion,
                                IdPadron,
                                FechaInicio,
                                FechaFin,
                                EstadoVotacion
                                FROM Votaciones
                                WHERE IdPadron = @IdPadron
                                AND EstadoVotacion = 'Abierta'
                                AND GETDATE() BETWEEN FechaInicio AND FechaFin
                                ORDER BY IdVotacion DESC";

                SqlCommand cmd = new SqlCommand(query, conn);
                cmd.Parameters.AddWithValue("@IdPadron", idPadron);

                SqlDataAdapter da = new SqlDataAdapter(cmd);
                DataTable dt = new DataTable();
                da.Fill(dt);

                return dt;
            }
        }

        public DataTable ListarPlanchasPorPadron(int idPadron)
        {
            using (SqlConnection conn = conexion.ObtenerConexion())
            {
                conn.Open();

                string query = @"SELECT IdPlancha, NombrePlancha
                                 FROM Planchas
                                 WHERE IdPadron = @IdPadron
                                 AND EstadoPlancha = 1";

                SqlCommand cmd = new SqlCommand(query, conn);
                cmd.Parameters.AddWithValue("@IdPadron", idPadron);

                SqlDataAdapter da = new SqlDataAdapter(cmd);
                DataTable dt = new DataTable();
                da.Fill(dt);

                return dt;
            }
        }

        public DataTable ListarIntegrantesPorPlancha(int idPlancha)
        {
            using (SqlConnection conn = conexion.ObtenerConexion())
            {
                conn.Open();

                string query = @"SELECT 
                                C.NombreCargo AS Cargo,
                                U.NombreCompleto AS Integrante
                                FROM IntegrantesPlancha IP
                                INNER JOIN Cargos C ON IP.IdCargo = C.IdCargo
                                INNER JOIN Usuarios U ON IP.IdUsuario = U.IdUsuario
                                WHERE IP.IdPlancha = @IdPlancha
                                ORDER BY C.Orden";

                SqlCommand cmd = new SqlCommand(query, conn);
                cmd.Parameters.AddWithValue("@IdPlancha", idPlancha);

                SqlDataAdapter da = new SqlDataAdapter(cmd);
                DataTable dt = new DataTable();
                da.Fill(dt);

                return dt;
            }
        }

        public bool RegistrarVoto(Voto voto)
        {
            using (SqlConnection conn = conexion.ObtenerConexion())
            {
                conn.Open();

                SqlTransaction transaccion = conn.BeginTransaction();

                try
                {
                    string queryVoto = @"INSERT INTO Votos
                    (IdUsuario, IdVotacion, IdPlancha, EsNulo, FechaVoto)
                    VALUES
                    (@IdUsuario, @IdVotacion, @IdPlancha, @EsNulo, @FechaVoto)";

                    SqlCommand cmdVoto = new SqlCommand(queryVoto, conn, transaccion);

                    cmdVoto.Parameters.AddWithValue("@IdUsuario", voto.IdUsuario);
                    cmdVoto.Parameters.AddWithValue("@IdVotacion", voto.IdVotacion);

                    if (voto.IdPlancha.HasValue)
                        cmdVoto.Parameters.AddWithValue("@IdPlancha", voto.IdPlancha.Value);
                    else
                        cmdVoto.Parameters.AddWithValue("@IdPlancha", DBNull.Value);

                    cmdVoto.Parameters.AddWithValue("@EsNulo", voto.EsNulo);
                    cmdVoto.Parameters.AddWithValue("@FechaVoto", voto.FechaVoto);

                    cmdVoto.ExecuteNonQuery();

                    string queryUsuario = @"UPDATE Usuarios
                                            SET YaVoto = 1
                                            WHERE IdUsuario = @IdUsuario";

                    SqlCommand cmdUsuario = new SqlCommand(queryUsuario, conn, transaccion);
                    cmdUsuario.Parameters.AddWithValue("@IdUsuario", voto.IdUsuario);

                    cmdUsuario.ExecuteNonQuery();

                    transaccion.Commit();
                    return true;
                }
                catch
                {
                    transaccion.Rollback();
                    return false;
                }
            }
        }
    }
}