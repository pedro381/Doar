using System;

namespace Doar.Entity.Entities { 

    [Serializable]
    public abstract class BaseDominio {
        public int PaginaAtual { get; set; }
        public int ItensPorPagina { get; set; }
        public DateTime? DataCadastro { get; set; }
        public DateTime? DataModificacao { get; set; }
        public string UsuarioDeCriacaoId { get; set; }
        public string UsuarioDeModificacaoId { get; set; }
        public string UsuarioLogadoId { get; set; }
    }
}
