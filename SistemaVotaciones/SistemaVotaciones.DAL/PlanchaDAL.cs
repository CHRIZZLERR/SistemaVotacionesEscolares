using System.Data;
using System.Data.SqlClient;
using SistemaVotaciones.Entidades;

namespace SistemaVotaciones.DAL
{
    public class PlanchaDAL
    {
        private ConexionDB conexion = new ConexionDB();

        public bool CrearPlancha(Plancha plancha)
        {
            using (SqlConnection conn = conexion.ObtenerConexion())
            {
                conn.Open();

                string query = @"INSERT INTO Planchas
                (NombrePlancha, Color, Lema, IdPadron, EstadoPlancha, IdAdminPlancha)
                VALUES
                (@NombrePlancha, @Color, @Lema, @IdPadron, @EstadoPlancha, @IdAdminPlancha)";

                SqlCommand cmd = new SqlCommand(query, conn);

                cmd.Parameters.AddWithValue("@NombrePlancha", plancha.NombrePlancha);
                cmd.Parameters.AddWithValue("@Color", plancha.Color);
                cmd.Parameters.AddWithValue("@Lema", plancha.Lema);
                cmd.Parameters.AddWithValue("@IdPadron", plancha.IdPadron);
                cmd.Parameters.AddWithValue("@EstadoPlancha", true);
                cmd.Parameters.AddWithValue("@IdAdminPlancha", plancha.IdAdminPlancha);

                return cmd.ExecuteNonQuery() > 0;
            }
        }

        public DataTable ListarPlanchas()
        {
            using (SqlConnection conn = conexion.ObtenerConexion())
            {
                conn.Open();

                string query = @"SELECT 
                                P.IdPlancha,
                                P.NombrePlancha,
                                P.Color,
                                P.Lema,
                                PE.NombrePadron,
                                U.NombreCompleto AS AdminPlancha,
                                P.EstadoPlancha
                                FROM Planchas P
                                INNER JOIN PadronesElectorales PE ON P.IdPadron = PE.IdPadron
                                LEFT JOIN Usuarios U ON P.IdAdminPlancha = U.IdUsuario";

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

        public DataTable ListarAdminsPlancha()
        {
            using (SqlConnection conn = conexion.ObtenerConexion())
            {
                conn.Open();

                string query = @"SELECT IdUsuario, NombreCompleto
                                 FROM Usuarios
                                 WHERE IdRol = 3 AND EstadoUsuario = 1";

                SqlDataAdapter da = new SqlDataAdapter(query, conn);
                DataTable dt = new DataTable();
                da.Fill(dt);

                return dt;
            }
        }
    }
}