namespace Doar.Entity.EntitiesSearch {
    public class UsuarioResultadoPesquisa {
        public int? UsuarioId { get; set; }
        public string Id { get; set; }
        public string Codigo { get; set; }
        public string Email { get; set; }
        public string Nome { get; set; }
        public string Perfil { get; set; }
        public string Status { get; set; }
        public string DataUltimoAcesso { get; set; }
        public bool Consultor { get; set; }
        public string Cliente { get; set; }
        public string Areas { get; set; }
        public string Abrangencia { get; set; }
        public string AcoesPendentes { get; set; }
        public int? StatusId { get; set; }

        public int? TipoDeUsuarioId { get; set; }
    }
}
