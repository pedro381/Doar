using System.Web.Mvc;
using Doar.Domain.Interfaces.Repository;
using Doar.Entity.Entities;
using System.Linq;

namespace Doar.Ui.Mvc.Controllers
{
    public class ClienteController : BaseController
    {
        private readonly IClienteRepository _clienteRepository;

        public ClienteController(IClienteRepository clienteRepository, IUsuarioRepository usuarioRepository, IDoacaoRepository doacaoRepository) : base(usuarioRepository, doacaoRepository)
        {
            _clienteRepository = clienteRepository;
        }

        [AllowAnonymous]
        public ActionResult Index()
        {
            var clientes = _clienteRepository.ObterTodos().ToList();
            if (clientes.Any())
                return View(clientes.First());
            return View();
        }

        [HttpPost]
        [AllowAnonymous]
        [ValidateAntiForgeryToken]
        public ActionResult Edit(Cliente cliente)
        {
            if (cliente.ClienteId != 0)
                _clienteRepository.Atualizar(cliente);
            else
                _clienteRepository.Adicionar(cliente);
            _clienteRepository.SaveChanges();
            return null;
        }
    }
}