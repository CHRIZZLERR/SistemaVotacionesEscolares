using System.Data;
using SistemaVotaciones.DAL;

namespace SistemaVotaciones.BLL
{
    public class ResultadoBLL
    {
        private ResultadoDAL dal = new ResultadoDAL();

        public int TotalVotos()
        {
            return dal.TotalVotos();
        }

        public int TotalVotosNulos()
        {
            return dal.TotalVotosNulos();
        }

        public int TotalVotantes()
        {
            return dal.TotalVotantes();
        }

        public DataTable ResultadosPorPlancha()
        {
            return dal.ResultadosPorPlancha();
        }

        public string PlanchaGanadora()
        {
            return dal.PlanchaGanadora();
        }
    }
}