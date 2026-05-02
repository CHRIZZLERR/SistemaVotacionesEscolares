using System.Data;
using SistemaVotaciones.DAL;
using SistemaVotaciones.Entidades;

namespace SistemaVotaciones.BLL
{
    public class PlanchaBLL
    {
        private PlanchaDAL dal = new PlanchaDAL();

        public bool Crear(Plancha plancha)
        {
            return dal.CrearPlancha(plancha);
        }

        public DataTable Listar()
        {
            return dal.ListarPlanchas();
        }

        public DataTable ListarPadrones()
        {
            return dal.ListarPadrones();
        }

        public DataTable ListarAdminsPlancha()
        {
            return dal.ListarAdminsPlancha();
        }
    }
}