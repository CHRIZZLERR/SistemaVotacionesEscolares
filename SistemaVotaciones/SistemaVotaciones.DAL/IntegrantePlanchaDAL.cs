using System.Data;
using System.Data.SqlClient;
using SistemaVotaciones.Entidades;

namespace SistemaVotaciones.DAL
{
    public class IntegrantePlanchaDAL
    {
        private ConexionDB conexion = new ConexionDB();

        public DataTable ListarPlanchas()
        {
            using (SqlConnection conn = conexion.ObtenerConexion())
            {
                conn.Open();

                string query = "SELECT IdPlancha, NombrePlancha FROM Planchas WHERE EstadoPlancha = 1";

                SqlDataAdapter da = new SqlDataAdapter(query, conn);
                DataTable dt = new DataTable();
                da.Fill(dt);

                return dt;
            }
        }

        public DataTable ListarCargos()
        {
            using (SqlConnection conn = conexion.ObtenerConexion())
            {
                conn.Open();

                string query = "SELECT IdCargo, NombreCargo FROM Cargos ORDER BY Orden";

                SqlDataAdapter da = new SqlDataAdapter(query, conn);
                DataTable dt = new DataTable();
                da.Fill(dt);

                return dt;
            }
        }

        public DataTable ListarUsuarios()
        {
            using (SqlConnection conn = conexion.ObtenerConexion())
            {
                conn.Open();

                string query = @"SELECT IdUsuario, NombreCompleto 
                         FROM Usuarios 
                         WHERE EstadoUsuario = 1 
                         AND IdRol = 2";

                SqlDataAdapter da = new SqlDataAdapter(query, conn);
                DataTable dt = new DataTable();
                da.Fill(dt);

                return dt;
            }
        }

        public bool GuardarIntegrante(IntegrantePlancha integrante)
        {
            using (SqlConnection conn = conexion.ObtenerConexion())
            {
                conn.Open();

                string query = @"INSERT INTO IntegrantesPlancha
                                (IdPlancha, IdUsuario, IdCargo)
                                VALUES
                                (@IdPlancha, @IdUsuario, @IdCargo)";

                SqlCommand cmd = new SqlCommand(query, conn);

                cmd.Parameters.AddWithValue("@IdPlancha", integrante.IdPlancha);
                cmd.Parameters.AddWithValue("@IdUsuario", integrante.IdUsuario);
                cmd.Parameters.AddWithValue("@IdCargo", integrante.IdCargo);

                return cmd.ExecuteNonQuery() > 0;
            }
        }

        public DataTable ListarIntegrantesGuardados()
        {
            using (SqlConnection conn = conexion.ObtenerConexion())
            {
                conn.Open();

                string query = @"SELECT 
                                IP.IdIntegrante,
                                P.NombrePlancha,
                                U.NombreCompleto,
                                C.NombreCargo
                                FROM IntegrantesPlancha IP
                                INNER JOIN Planchas P ON IP.IdPlancha = P.IdPlancha
                                INNER JOIN Usuarios U ON IP.IdUsuario = U.IdUsuario
                                INNER JOIN Cargos C ON IP.IdCargo = C.IdCargo";

                SqlDataAdapter da = new SqlDataAdapter(query, conn);
                DataTable dt = new DataTable();
                da.Fill(dt);

                return dt;
            }
        }
    }
}