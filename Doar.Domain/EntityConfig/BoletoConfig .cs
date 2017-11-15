using BoletoNet;
using System.Data.Entity.ModelConfiguration;

namespace Doar.Domain.EntityConfig
{
    public class BoletoDomainConfig : EntityTypeConfiguration<Boleto>
    {
        public BoletoDomainConfig()
        {
            ToTable("Boleto");
            HasKey(u => u.BoletoId);
        }
    }
}
