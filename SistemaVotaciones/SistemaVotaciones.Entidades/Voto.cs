using System;

namespace SistemaVotaciones.Entidades
{
    public class Voto
    {
        public int IdVoto { get; set; }
        public int IdUsuario { get; set; }
        public int IdVotacion { get; set; }
        public int? IdPlancha { get; set; }
        public bool EsNulo { get; set; }
        public DateTime FechaVoto { get; set; }
    }
}