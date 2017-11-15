using Doar.Domain.Entities;
using Microsoft.AspNet.Identity;
using System;
using System.Configuration;
using System.Linq;
using System.Net;
using System.Security.Principal;
using System.Text;
using System.Web;
using System.Web.Mvc;

namespace Doar.Seguranca.Implementacao
{
    [AttributeUsage(AttributeTargets.Class | AttributeTargets.Method, AllowMultiple = true, Inherited = true)]
    public class AuthorizeControl : AuthorizeAttribute
    {
        private string[] _roles
        {
            get
            {
                StringBuilder sb = new StringBuilder();
                string[] rolesMeth = this.Roles.Split(',');
                foreach (string item in rolesMeth)
                {
                    sb.Append(!string.IsNullOrEmpty(ConfigurationManager.AppSettings[item]) ? ConfigurationManager.AppSettings[item].ToString() + "," : string.Empty);
                }

                return sb.ToString().Split(new[] { "," }, StringSplitOptions.RemoveEmptyEntries);
            }
        }

        protected override bool AuthorizeCore(HttpContextBase httpContext)
        {
            if (httpContext == null)
                throw new ArgumentNullException("httpContext");
            IPrincipal user = httpContext.User;
            bool accessible = false;
            _roles.ToList().ForEach(s =>
            {
                if (user.IsInRole(s))
                    accessible = true;
            });
            return user.Identity.IsAuthenticated && accessible;
        }

        protected override void HandleUnauthorizedRequest(AuthorizationContext filterContext)
        {
            if (filterContext.HttpContext.Request.IsAjaxRequest())
            {
                filterContext.HttpContext.Response.StatusCode = (int)HttpStatusCode.Forbidden;
            }
            else
            {
                if (filterContext.HttpContext.User.Identity.IsAuthenticated)
                    filterContext.Result = new RedirectResult("~/Account/Unauthorized");
                else
                    filterContext.Result = new RedirectResult("~/Account/Login");
            }            
        }

        public static bool IsAuthorized(HttpContextBase httpContext, string roleInterval)
        {
            if (httpContext == null)
                throw new ArgumentNullException("httpContext");
            IPrincipal user = httpContext.User;
            bool accessible = false;

            StringBuilder sb = new StringBuilder();
            string[] arrayRoles = roleInterval.Split(',');
            foreach (string item in arrayRoles)
            {
                sb.Append(!string.IsNullOrEmpty(ConfigurationManager.AppSettings[item]) ? ConfigurationManager.AppSettings[item].ToString() + "," : string.Empty);
            }

            arrayRoles = sb.ToString().Split(new[] { "," }, StringSplitOptions.RemoveEmptyEntries);

            arrayRoles.ToList().ForEach(s =>
            {
                if (user.IsInRole(s))
                    accessible = true;
            });
            return user.Identity.IsAuthenticated && accessible;
        }       
    }
}
