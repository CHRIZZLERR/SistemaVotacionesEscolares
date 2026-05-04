using System.Data;
using SistemaVotaciones.DAL;
using SistemaVotaciones.Entidades;

namespace SistemaVotaciones.BLL
{
    public class VotoBLL
    {
        private VotoDAL dal = new VotoDAL();

        public DataTable ObtenerVotacionAbiertaPorPadron(int idPadron)
        {
            return dal.ObtenerVotacionAbiertaPorPadron(idPadron);
        }

        public DataTable ListarPlanchasPorPadron(int idPadron)
        {
            return dal.ListarPlanchasPorPadron(idPadron);
        }

        public DataTable ListarIntegrantesPorPlancha(int idPlancha)
        {
            return dal.ListarIntegrantesPorPlancha(idPlancha);
        }

        public bool RegistrarVoto(Voto voto)
        {
            return dal.RegistrarVoto(voto);
        }
    }
}