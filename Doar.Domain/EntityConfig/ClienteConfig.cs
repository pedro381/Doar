using Doar.Entity.Entities;
using System.Data.Entity.ModelConfiguration;

namespace Doar.Domain.EntityConfig
{
    public class ClienteConfig : EntityTypeConfiguration<Cliente>
    {
        public ClienteConfig()
        {
            ToTable("Cliente");
            HasKey(u => u.ClienteId);
        }
    }
}
