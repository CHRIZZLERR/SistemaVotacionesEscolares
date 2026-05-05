using System.Data;
using SistemaVotaciones.DAL;
using SistemaVotaciones.Entidades;

namespace SistemaVotaciones.BLL
{
    public class ResultadoBLL
    {
        private ResultadoDAL dal = new ResultadoDAL();

        public int TotalVotos(Usuario usuarioActual)
        {
            return dal.TotalVotos(usuarioActual);
        }

        public int TotalVotosNulos(Usuario usuarioActual)
        {
            return dal.TotalVotosNulos(usuarioActual);
        }

        public int TotalVotantes()
        {
            return dal.TotalVotantes();
        }

        public DataTable ResultadosPorPlancha(Usuario usuarioActual)
        {
            return dal.ResultadosPorPlancha(usuarioActual);
        }

        public string PlanchaGanadora(Usuario usuarioActual)
        {
            return dal.PlanchaGanadora(usuarioActual);
        }
    }
}