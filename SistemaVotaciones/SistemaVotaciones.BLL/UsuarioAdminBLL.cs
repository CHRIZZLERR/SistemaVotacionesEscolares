using System.Data;
using SistemaVotaciones.DAL;
using SistemaVotaciones.Entidades;

namespace SistemaVotaciones.BLL
{
    public class UsuarioAdminBLL
    {
        private UsuarioAdminDAL dal = new UsuarioAdminDAL();

        public DataTable ListarUsuarios(Usuario usuarioActual)
        {
            return dal.ListarUsuarios(usuarioActual);
        }

        public bool ActivarUsuario(int idUsuario)
        {
            return dal.CambiarEstadoUsuario(idUsuario, true);
        }

        public bool DesactivarUsuario(int idUsuario)
        {
            return dal.CambiarEstadoUsuario(idUsuario, false);
        }

        public bool ReiniciarVoto(int idUsuario)
        {
            return dal.ReiniciarVoto(idUsuario);
        }
    }
}