namespace SistemaVotaciones.Entidades
{
    public class Usuario
    {
        public int IdUsuario { get; set; }
        public string Username { get; set; }
        public string Password { get; set; }
        public int IdRol { get; set; }
        public int IdPadron { get; set; }
        public bool EstadoUsuario { get; set; }
        public bool YaVoto { get; set; }
    }
}