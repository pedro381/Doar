using System.Data.Entity.ModelConfiguration;
using Doar.Entity.Entities;

namespace Doar.Domain.EntityConfig
{
    public class UsuarioConfig : EntityTypeConfiguration<Usuario>
    {
        public UsuarioConfig()
        {
            ToTable("Usuario");
            HasKey(u => u.UsuarioId);
            Ignore(x => x.EmailConfirmacao);
            Ignore(x => x.SenhaConfirmacao);
            HasOptional(c => c.Endereco).WithMany().HasForeignKey(c => c.EnderecoId);

            //Property(c => c.UsuarioId).HasDatabaseGeneratedOption(DatabaseGeneratedOption.Identity);   
            //Index         
            //Property(t => t.Email).HasColumnAnnotation("Email",new IndexAnnotation(new IndexAttribute("IX_Email") { IsUnique = false }));

            /*
            HasOptional(c => c.UsuarioStatus).WithMany(c => c.Usuarios).HasForeignKey(c => c.UsuarioStatusId);
            HasOptional(c => c.TipoUsuario).WithMany(c => c.Usuarios).HasForeignKey(c => c.TipoUsuarioId);
            HasOptional(c => c.Perfil).WithMany(c => c.Usuarios).HasForeignKey(c => c.PerfilId);


          

            HasMany(x => x.PermissaoIncluida)
               .WithMany(x => x.UsuariosPermissaoIncluida)
               .Map(m => {
                   m.MapLeftKey("UsuarioId");
                   m.MapRightKey("FuncionalidadeId");
                   m.ToTable("PermissaoIncluidaDoUsuario");
               });

            HasMany(x => x.PermissaoExcluidas)
               .WithMany(x => x.UsuariosPermissaoExcluida)
               .Map(m => {
                   m.MapLeftKey("UsuarioId");
                   m.MapRightKey("FuncionalidadeId");
                   m.ToTable("PermissaoExcluidaDoUsuario");
               });

            HasMany(x => x.InformesNaoExibirNovamente)
               .WithMany(x => x.UsuariosNaoExibirNovamente)
               .Map(m => {
                   m.MapLeftKey("UsuarioId");
                   m.MapRightKey("InformeDoarId");
                   m.ToTable("NaoExibirInformeNovamenteParaUsuarios");
               });
               */
        }
    }
}