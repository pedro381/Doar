using Doar.Domain.Context;
using Microsoft.AspNet.Identity;
using Microsoft.AspNet.Identity.EntityFramework;
using Microsoft.AspNet.Identity.Owin;
using Microsoft.Owin;

namespace Doar.Seguranca.Configuration {
    public class ApplicationRoleManager:RoleManager<IdentityRole> {
        public ApplicationRoleManager(IRoleStore<IdentityRole,string> roleStore)
            : base(roleStore) {

        }

        public static ApplicationRoleManager Create(IdentityFactoryOptions<ApplicationRoleManager> options,IOwinContext context) {
            return new ApplicationRoleManager(new RoleStore<IdentityRole>(context.Get<DoarContext>()));
        }
    }
}
