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

        public DataTable ListarPlanchasPorAdmin(int idAdminPlancha)
        {
            return dal.ListarPlanchasPorAdmin(idAdminPlancha);
        }

        public DataTable ListarCargos()
        {
            return dal.ListarCargos();
        }

        public DataTable ListarUsuarios()
        {
            return dal.ListarUsuarios();
        }

        public DataTable ListarUsuariosPorPlanchaAdmin(int idAdminPlancha)
        {
            return dal.ListarUsuariosPorPlanchaAdmin(idAdminPlancha);
        }

        public bool GuardarIntegrante(IntegrantePlancha integrante)
        {
            return dal.GuardarIntegrante(integrante);
        }

        public bool EliminarIntegrantesPorPlancha(int idPlancha)
        {
            return dal.EliminarIntegrantesPorPlancha(idPlancha);
        }

        public DataTable ListarIntegrantesGuardados()
        {
            return dal.ListarIntegrantesGuardados();
        }

        public DataTable ListarIntegrantesGuardadosPorAdmin(int idAdminPlancha)
        {
            return dal.ListarIntegrantesGuardadosPorAdmin(idAdminPlancha);
        }
    }
}