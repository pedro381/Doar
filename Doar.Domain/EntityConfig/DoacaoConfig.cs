using Doar.Entity.Entities;
using System.Data.Entity.ModelConfiguration;

namespace Doar.Domain.EntityConfig
{
    public class DoacaoConfig : EntityTypeConfiguration<Doacao>
    {
        public DoacaoConfig()
        {
            ToTable("Doacao");
            HasKey(u => u.DoacaoId);
        }
    }
}
