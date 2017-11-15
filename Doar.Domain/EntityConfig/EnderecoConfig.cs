using System.Data.Entity.ModelConfiguration;

namespace Doar.Domain.EntityConfig
{
    public class EnderecoDomainConfig : EntityTypeConfiguration<Entity.Entities.Endereco>
    {
        public EnderecoDomainConfig()
        {
            ToTable("Endereco");
            HasKey(u => u.EnderecoId);
        }
    }
}
