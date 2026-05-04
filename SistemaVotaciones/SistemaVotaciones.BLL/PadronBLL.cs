using System.Data;
using SistemaVotaciones.DAL;
using SistemaVotaciones.Entidades;

namespace SistemaVotaciones.BLL
{
    public class PadronBLL
    {
        private PadronDAL dal = new PadronDAL();

        public bool Crear(Padron padron)
        {
            if (dal.ExistePadron(padron.NombrePadron))
            {
                return false;
            }

            return dal.CrearPadron(padron);
        }

        public DataTable Listar()
        {
            return dal.ListarPadrones();
        }
    }
}