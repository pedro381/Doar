using System.Web.Mvc;
using Doar.Domain.Interfaces.Repository;
using Doar.Entity.Entities;
using Doar.Session;
using System.Linq;

namespace Doar.Ui.Mvc.Controllers
{
    public class UsuarioController : BaseController
    {
        public UsuarioController(IUsuarioRepository usuarioRepository, IDoacaoRepository doacaoRepository): base(usuarioRepository, doacaoRepository)
        {
        }


        [AllowAnonymous]
        public ActionResult Index()
        {
            var todos = UsuarioRepository.ObterTodos().ToList();
            return View(todos);
        }

        [AllowAnonymous]
        public ActionResult Login(string returnUrl)
        {
            ViewBag.ReturnUrl = returnUrl;
            return View();
        }

        [HttpPost]
        [AllowAnonymous]
        [ValidateAntiForgeryToken]
        public ActionResult Login(Usuario usuario, string returnUrl)
        {
            var result = UsuarioRepository.ObterUsuarioPorEmail(usuario.Email);
            if (result == null)
                return Json(new { valid = false, msg = "Email não cadastrado!" }, JsonRequestBehavior.AllowGet);
            if (Usuario.Decrypt(result.Senha) != usuario.Senha)
                return Json(new { valid = false, msg = "Login inválido!" }, JsonRequestBehavior.AllowGet);
            UsuarioSession.Usuario = result;
            return Json(new { valid = true }, JsonRequestBehavior.AllowGet);
        }

        public ActionResult LogOff()
        {
            UsuarioSession.Usuario = null;
            return RedirectToAction("Index", "Home");
        }

        [AllowAnonymous]
        public ActionResult Register()
        {
            return View();
        }

        [HttpPost]
        [AllowAnonymous]
        [ValidateAntiForgeryToken]
        public ActionResult Register(Usuario usuario)
        {
            var result = UsuarioRepository.ObterUsuarioPorEmail(usuario.Email);
            if (result != null)
                return Json(new { valid = false, msg = "Email já cadastrado!" }, JsonRequestBehavior.AllowGet);
            if (usuario.Email != usuario.EmailConfirmacao)
                return Json(new { valid = false, msg = "Email não confere!" }, JsonRequestBehavior.AllowGet);
            if (usuario.Senha != usuario.SenhaConfirmacao)
                return Json(new { valid = false, msg = "Senha não confere!" }, JsonRequestBehavior.AllowGet);
            usuario.Senha = Usuario.Encrypt(usuario.Senha);
            UsuarioRepository.Adicionar(usuario);
            UsuarioRepository.SaveChanges();
            UsuarioSession.Usuario = usuario;
            return Json(new { valid = true }, JsonRequestBehavior.AllowGet);
        }

        [AllowAnonymous]
        public ActionResult ForgotPassword()
        {
            return View();
        }

        [HttpPost]
        [AllowAnonymous]
        [ValidateAntiForgeryToken]
        public ActionResult ForgotPassword(Usuario usuario)
        {
            if (ModelState.IsValid)
            {
            }
            return View(usuario);
        }

        public ActionResult Edit(int id)
        {
            var usuario = UsuarioRepository.ObterPorId(id);
            usuario.Doacoes = DoacaoRepository.Buscar(x => x.UsuarioId == UsuarioSession.Usuario.UsuarioId).ToList();
            return View(usuario);
        }

        [HttpPost]
        [AllowAnonymous]
        [ValidateAntiForgeryToken]
        public ActionResult Edit(Usuario usuario)
        {
            UsuarioRepository.Atualizar(usuario);
            UsuarioRepository.SaveChanges();
            return null;
        }

        public ActionResult Delete(int id)
        {
            UsuarioRepository.Remover(id);
            UsuarioRepository.SaveChanges();
            return RedirectToAction("Index");
        }

        public ActionResult Buscar(string nome)
        {
            var usuarios = UsuarioRepository.Buscar(x => string.IsNullOrEmpty(nome) || x.Nome.Contains(nome));
            return PartialView("Grid", usuarios);
        }
    }
}