using System;

namespace SistemaVotaciones.Entidades
{
    public class Votacion
    {
        public int IdVotacion { get; set; }
        public string NombreVotacion { get; set; }
        public int IdPadron { get; set; }
        public DateTime FechaInicio { get; set; }
        public DateTime FechaFin { get; set; }
        public string EstadoVotacion { get; set; }
    }
}