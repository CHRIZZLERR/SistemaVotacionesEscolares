using System.Data.SqlClient;

namespace SistemaVotaciones.DAL
{
    public class ConexionDB
    {
        private string cadena = "Server = MSI\\SQLEXPRESS;Database=SistemaVotacionesDB;Integrated Security = True; TrustServerCertificate=True;";

        public SqlConnection ObtenerConexion()
        {
            return new SqlConnection(cadena);
        }
    }
}