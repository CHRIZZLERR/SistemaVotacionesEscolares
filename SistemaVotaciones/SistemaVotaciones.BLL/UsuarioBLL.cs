using SistemaVotaciones.DAL;
using SistemaVotaciones.Entidades;

namespace SistemaVotaciones.BLL
{
    public class UsuarioBLL
    {
        private UsuarioDAL usuarioDAL = new UsuarioDAL();

        public Usuario Login(string username, string password)
        {
            Usuario usuario = usuarioDAL.ObtenerUsuario(username, password);

            if (usuario == null)
                return null;

            if (!usuario.EstadoUsuario)
                return null;

            return usuario;
        }

        public bool ExisteUsuario(string username, string matricula)
        {
            return usuarioDAL.ExisteUsuario(username, matricula);
        }

        public int ObtenerIdPadron(string nivel, string grado, string seccion, string modalidad)
        {
            return usuarioDAL.ObtenerIdPadron(nivel, grado, seccion, modalidad);
        }

        public bool RegistrarUsuario(Usuario usuario)
        {
            return usuarioDAL.RegistrarUsuario(usuario);
        }
    }
}