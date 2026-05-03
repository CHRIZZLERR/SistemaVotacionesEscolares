using System.Data;
using SistemaVotaciones.DAL;
using SistemaVotaciones.Entidades;

namespace SistemaVotaciones.BLL
{
    public class IntegrantePlanchaBLL
    {
        private IntegrantePlanchaDAL dal = new IntegrantePlanchaDAL();

        public DataTable ListarPlanchas()
        {
            return dal.ListarPlanchas();
        }

        public DataTable ListarCargos()
        {
            return dal.ListarCargos();
        }

        public DataTable ListarUsuarios()
        {
            return dal.ListarUsuarios();
        }

        public bool GuardarIntegrante(IntegrantePlancha integrante)
        {
            return dal.GuardarIntegrante(integrante);
        }

        public DataTable ListarIntegrantesGuardados()
        {
            return dal.ListarIntegrantesGuardados();
        }
    }
}