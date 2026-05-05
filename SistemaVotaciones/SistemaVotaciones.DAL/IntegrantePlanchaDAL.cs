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

                string query = @"
                SELECT IdPlancha, NombrePlancha
                FROM Planchas
                WHERE EstadoPlancha = 1
                ORDER BY NombrePlancha";

                SqlDataAdapter da = new SqlDataAdapter(query, conn);
                DataTable dt = new DataTable();
                da.Fill(dt);

                return dt;
            }
        }

        public DataTable ListarPlanchasPorAdmin(int idAdminPlancha)
        {
            using (SqlConnection conn = conexion.ObtenerConexion())
            {
                conn.Open();

                string query = @"
                SELECT IdPlancha, NombrePlancha
                FROM Planchas
                WHERE EstadoPlancha = 1
                AND IdAdminPlancha = @IdAdminPlancha
                ORDER BY NombrePlancha";

                SqlCommand cmd = new SqlCommand(query, conn);
                cmd.Parameters.AddWithValue("@IdAdminPlancha", idAdminPlancha);

                SqlDataAdapter da = new SqlDataAdapter(cmd);
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

                string query = @"
                SELECT IdCargo, NombreCargo
                FROM Cargos
                ORDER BY Orden";

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

                string query = @"
                SELECT 
                    IdUsuario, 
                    NombreCompleto
                FROM Usuarios
                WHERE EstadoUsuario = 1
                AND IdRol = 4
                ORDER BY NombreCompleto";

                SqlDataAdapter da = new SqlDataAdapter(query, conn);
                DataTable dt = new DataTable();
                da.Fill(dt);

                return dt;
            }
        }

        public DataTable ListarUsuariosPorPlanchaAdmin(int idAdminPlancha)
        {
            using (SqlConnection conn = conexion.ObtenerConexion())
            {
                conn.Open();

                string query = @"
                SELECT 
                    U.IdUsuario,
                    U.NombreCompleto
                FROM Usuarios U
                INNER JOIN IntegrantesPlancha IP ON U.IdUsuario = IP.IdUsuario
                INNER JOIN Planchas P ON IP.IdPlancha = P.IdPlancha
                WHERE P.IdAdminPlancha = @IdAdminPlancha
                AND U.EstadoUsuario = 1
                ORDER BY U.NombreCompleto";

                SqlCommand cmd = new SqlCommand(query, conn);
                cmd.Parameters.AddWithValue("@IdAdminPlancha", idAdminPlancha);

                SqlDataAdapter da = new SqlDataAdapter(cmd);
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

                string query = @"
                INSERT INTO IntegrantesPlancha
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

        public bool EliminarIntegrantesPorPlancha(int idPlancha)
        {
            using (SqlConnection conn = conexion.ObtenerConexion())
            {
                conn.Open();

                string query = @"
                DELETE FROM IntegrantesPlancha
                WHERE IdPlancha = @IdPlancha";

                SqlCommand cmd = new SqlCommand(query, conn);
                cmd.Parameters.AddWithValue("@IdPlancha", idPlancha);

                cmd.ExecuteNonQuery();
                return true;
            }
        }

        public DataTable ListarIntegrantesGuardados()
        {
            using (SqlConnection conn = conexion.ObtenerConexion())
            {
                conn.Open();

                string query = @"
                SELECT 
                    IP.IdIntegrante,
                    P.NombrePlancha,
                    U.NombreCompleto,
                    C.NombreCargo
                FROM IntegrantesPlancha IP
                INNER JOIN Planchas P ON IP.IdPlancha = P.IdPlancha
                INNER JOIN Usuarios U ON IP.IdUsuario = U.IdUsuario
                INNER JOIN Cargos C ON IP.IdCargo = C.IdCargo
                ORDER BY P.NombrePlancha, C.Orden";

                SqlDataAdapter da = new SqlDataAdapter(query, conn);
                DataTable dt = new DataTable();
                da.Fill(dt);

                return dt;
            }
        }

        public DataTable ListarIntegrantesGuardadosPorAdmin(int idAdminPlancha)
        {
            using (SqlConnection conn = conexion.ObtenerConexion())
            {
                conn.Open();

                string query = @"
                SELECT 
                    IP.IdIntegrante,
                    P.NombrePlancha,
                    U.NombreCompleto,
                    C.NombreCargo
                FROM IntegrantesPlancha IP
                INNER JOIN Planchas P ON IP.IdPlancha = P.IdPlancha
                INNER JOIN Usuarios U ON IP.IdUsuario = U.IdUsuario
                INNER JOIN Cargos C ON IP.IdCargo = C.IdCargo
                WHERE P.IdAdminPlancha = @IdAdminPlancha
                ORDER BY P.NombrePlancha, C.Orden";

                SqlCommand cmd = new SqlCommand(query, conn);
                cmd.Parameters.AddWithValue("@IdAdminPlancha", idAdminPlancha);

                SqlDataAdapter da = new SqlDataAdapter(cmd);
                DataTable dt = new DataTable();
                da.Fill(dt);

                return dt;
            }
        }
    }
}