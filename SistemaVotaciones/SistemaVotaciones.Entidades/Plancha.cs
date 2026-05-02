namespace SistemaVotaciones.Entidades
{
    public class Plancha
    {
        public int IdPlancha { get; set; }
        public string NombrePlancha { get; set; }
        public string Color { get; set; }
        public string Lema { get; set; }
        public int IdPadron { get; set; }
        public bool EstadoPlancha { get; set; }
        public int? IdAdminPlancha { get; set; }
    }
}