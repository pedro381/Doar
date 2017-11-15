using System;
using Doar.Entity.Entities;
using Doar.Session;
using System.Web.Mvc;
using Doar.Domain.Interfaces.Repository;

namespace Doar.Ui.Mvc.Controllers
{
    public class BaseController : Controller
    {
        protected readonly IUsuarioRepository UsuarioRepository;
        protected readonly IDoacaoRepository DoacaoRepository;

        public BaseController(IUsuarioRepository usuarioRepository, IDoacaoRepository doacaoRepository)
        {
            UsuarioRepository = usuarioRepository;
            DoacaoRepository = doacaoRepository;
        }

        public ActionResult RedirectToLocal(string returnUrl)
        {
            if (Url.IsLocalUrl(returnUrl))
            {
                return Redirect(returnUrl);
            }
            return RedirectToAction("Index", "Home");
        }

        public ActionResult Boleto(Doacao doacao)
        {
            doacao.UsuarioId = UsuarioSession.Usuario.UsuarioId;
            doacao.Vencimento = DateTime.Now.AddDays(1);
            var retorno = DoacaoRepository.Adicionar(doacao);
            DoacaoRepository.SaveChanges();
            return Json(retorno.DoacaoId, JsonRequestBehavior.AllowGet);
        }
    }
}