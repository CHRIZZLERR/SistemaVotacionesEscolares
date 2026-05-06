using System.Data.SqlClient;

namespace SistemaVotaciones.DAL
{
    public class ConexionDB
    {
        private string cadena = @"Data Source=MSI\SQLEXPRESS;Initial Catalog=SistemaVotacionesDB;Integrated Security=True;TrustServerCertificate=True;";

        public SqlConnection ObtenerConexion()
        {
            return new SqlConnection(cadena);
        }
    }
}