using System.Data.Entity.Migrations;
using Doar.Domain.Context;
using System.Reflection;
using System;
using System.IO;

namespace Doar.Domain.Migrations
{
    internal sealed class Configuration : DbMigrationsConfiguration<DoarContext>
    {
        public Configuration()
        {
            AutomaticMigrationsEnabled = true;
        }
        protected override void Seed(DoarContext context)
        {
            var codeBase = Assembly.GetExecutingAssembly().CodeBase;
            var uri = new UriBuilder(codeBase);
            var path = Uri.UnescapeDataString(uri.Path);
            
            //var listaViewCommandSql = Directory.GetFiles(Path.GetDirectoryName(path) + "\\Migrations");
            //foreach (string viewCommandSql in listaViewCommandSql)
            //    context.Database.ExecuteSqlCommand(File.ReadAllText(viewCommandSql));
        }
    }
}
