using System.Data;
using SistemaVotaciones.DAL;

namespace SistemaVotaciones.BLL
{
    public class ReporteBLL
    {
        private ReporteDAL dal = new ReporteDAL();

        public DataTable ReporteGeneralVotos()
        {
            return dal.ReporteGeneralVotos();
        }

        public DataTable ReportePlanchaGanadora()
        {
            return dal.ReportePlanchaGanadora();
        }

        public DataTable ReporteIntegrantesPlancha()
        {
            return dal.ReporteIntegrantesPlancha();
        }

        public DataTable ReporteUsuarios()
        {
            return dal.ReporteUsuarios();
        }
    }
}