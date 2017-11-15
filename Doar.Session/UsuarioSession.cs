using Doar.Entity.Entities;
using System.Web;

namespace Doar.Session
{
    public static class UsuarioSession
    {
        public static Usuario Usuario
        {
            get { return HttpContext.Current.Session["UsuarioSession"] == null ? null : (Usuario)HttpContext.Current.Session["UsuarioSession"]; }
            set { HttpContext.Current.Session["UsuarioSession"] = value; }
        }
    }
}
