using Doar.Domain.Interfaces.Repository;
using SimpleInjector;
using System;
using System.Linq;
using Microsoft.AspNet.Identity;
using Doar.Domain.Repository;
using Doar.Domain.Interface;
using Doar.Domain.UoW;
using Doar.Domain.Context;

namespace Doar.CrossCutting.Ioc
{
    public class BootStrapper
    {
        public static void Register(Container container)
        {
            RegistrarColecaoDeTipos(container, typeof(Repository<>), typeof(IRepository<>));
            container.Register<IUnitOfWork, UnitOfWork>(Lifestyle.Scoped);
            container.Register<DoarContext>(Lifestyle.Scoped);
        }

        private static void RegistrarColecaoDeTipos(Container container, Type baseType, Type interfaceType)
        {
            var repositoryAssembly = baseType.Assembly;

            Func<Type, bool> predicateFilterInteraceType = c => c.GetInterfaces()
                                                                 .Any(d => d.IsGenericType &&
                                                                           d.GetGenericTypeDefinition() == interfaceType);

            var registrations = from reflectedType in repositoryAssembly.GetExportedTypes()
                                where reflectedType.GetInterfaces()
                                                    .Any(predicateFilterInteraceType) &&
                                      reflectedType != baseType
                                select new
                                {
                                    Service = reflectedType.GetInterfaces()
                                                           .First(predicateFilterInteraceType),
                                    Implementation = reflectedType
                                };

            foreach (var reg in registrations)
            {
                container.Register(reg.Service, reg.Implementation, Lifestyle.Scoped);
            }
        }
    }
}
