using System;
using Doar.Domain.EntidadesIdentity;
using Microsoft.AspNet.Identity;
using Microsoft.AspNet.Identity.Owin;
using Microsoft.Owin.Security.DataProtection;

namespace Doar.Seguranca.Configuration {


    public class ApplicationUserManager:UserManager<ApplicationUser> {
        public ApplicationUserManager(IUserStore<ApplicationUser> store)
            : base(store) {
            // Configurando validator para nome de usuario
            UserValidator = new UserValidator<ApplicationUser>(this) {
                AllowOnlyAlphanumericUserNames = false,
                RequireUniqueEmail = false
            };

            // Logica de validação e complexidade de senha
            PasswordValidator = new PasswordValidator {
                RequiredLength = 6,
                RequireNonLetterOrDigit = false,
                RequireDigit = false,
                RequireLowercase = false,
                RequireUppercase = false,
            };

            // Configuração de Lockout
            UserLockoutEnabledByDefault = true;
            DefaultAccountLockoutTimeSpan = TimeSpan.FromMinutes(5);
            MaxFailedAccessAttemptsBeforeLockout = 5;

            // Providers de Two Factor Autentication
            RegisterTwoFactorProvider("Código via SMS",new PhoneNumberTokenProvider<ApplicationUser> {
                MessageFormat = "Seu código de segurança é: {0}"
            });

            RegisterTwoFactorProvider("Código via E-mail",new EmailTokenProvider<ApplicationUser> {
                Subject = "Código de Segurança",
                BodyFormat = "Seu código de segurança é: {0}"
            });
            
            // Definindo a classe de serviço de SMS
            SmsService = new SmsService();

            var provider = new DpapiDataProtectionProvider("Doar");
            var dataProtector = provider.Create("DoarIdentity");

            UserTokenProvider = new DataProtectorTokenProvider<ApplicationUser>(dataProtector) { TokenLifespan = TimeSpan.FromDays(3) };

        }
    }

}
