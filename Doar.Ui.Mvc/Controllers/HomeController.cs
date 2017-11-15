using Doar.Domain.Interfaces.Repository;
using System.Web.Mvc;

namespace Doar.Ui.Mvc.Controllers
{
    public class HomeController : BaseController
    {
        public HomeController(IUsuarioRepository usuarioRepository, IDoacaoRepository doacaoRepository): base(usuarioRepository, doacaoRepository)
        {
        }
        public ActionResult Index()
        {
            return View();
        }

        public ActionResult About()
        {
            return View();
        }  

        public ActionResult GerarBoleto(int id)
        {
            var boleto = DoacaoRepository.GerarBoleto(id);
            return Content(boleto);
        }
    }
}