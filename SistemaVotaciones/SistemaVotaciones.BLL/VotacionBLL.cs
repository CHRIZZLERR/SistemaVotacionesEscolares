using System.Data;
using SistemaVotaciones.DAL;
using SistemaVotaciones.Entidades;

namespace SistemaVotaciones.BLL
{
    public class VotacionBLL
    {
        private VotacionDAL dal = new VotacionDAL();

        public bool Crear(Votacion votacion)
        {
            return dal.CrearVotacion(votacion);
        }

        public DataTable Listar()
        {
            return dal.ListarVotaciones();
        }

        public DataTable ListarPadrones()
        {
            return dal.ListarPadrones();
        }
    }
}