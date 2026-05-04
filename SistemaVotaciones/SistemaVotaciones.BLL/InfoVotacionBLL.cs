using System.Data;
using SistemaVotaciones.DAL;

namespace SistemaVotaciones.BLL
{
    public class InfoVotacionBLL
    {
        private InfoVotacionDAL dal = new InfoVotacionDAL();

        public DataTable ObtenerInfoVotacionPorPadron(int idPadron)
        {
            return dal.ObtenerInfoVotacionPorPadron(idPadron);
        }
    }
}