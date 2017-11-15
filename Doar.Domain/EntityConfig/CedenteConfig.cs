using System.Data.Entity.ModelConfiguration;
using BoletoNet;

namespace Doar.Domain.EntityConfig
{
    public class CedenteConfig : EntityTypeConfiguration<Cedente>
    {
        public CedenteConfig()
        {
            ToTable("Cedente");
            HasKey(u => u.CedenteId);
        }
    }
}
