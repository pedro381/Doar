using Doar.Entity.Entities;
using System.Data.Entity.ModelConfiguration;


namespace Doar.Domain.EntityConfig {
    public  class BaseEntityMap<T>:EntityTypeConfiguration<T> where T : BaseDominio {
        public BaseEntityMap() {
            
            Ignore(c => c.PaginaAtual);
            Ignore(c => c.ItensPorPagina);

            Property(c => c.DataCadastro).IsOptional();
            Property(c => c.DataModificacao).IsOptional();
            Property(c => c.UsuarioDeCriacaoId).IsOptional();
            Property(c => c.UsuarioDeModificacaoId).IsOptional();

            Ignore(c => c.UsuarioLogadoId);
        }
    }
}
