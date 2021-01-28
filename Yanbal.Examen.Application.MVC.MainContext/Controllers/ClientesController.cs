using System;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using Yanbal.Examen.Application.MainContext.AppServices.Contracts;
using Yanbal.Examen.Application.MainContext.Dtos;

namespace Yanbal.Examen.MVC.MainContext.Controllers
{
    public class ClientesController : Controller
    {
        readonly IClienteAppServices _clienteAppServices;
        readonly ILogger<ClientesController> _logger;

        public ClientesController(IClienteAppServices clienteAppServices, ILogger<ClientesController> logger)
        {
            _clienteAppServices = clienteAppServices ?? throw new ArgumentNullException(nameof(clienteAppServices));
            _logger = logger ?? throw new ArgumentNullException(nameof(logger));
        }

        public async Task<IActionResult> Index()
        {
            return View(await _clienteAppServices.GetListClientes());
        }

        public IActionResult Create()
        {
            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create(ClienteDto cliente)
        {
            try
            {
                var result = await _clienteAppServices.SaveCliente(cliente);
                if (result)
                {
                    return RedirectToAction(nameof(Index));
                }
                return View(cliente);
            }
            catch (ArgumentException ex)
            {
                ModelState.AddModelError(ex.Message, ex.InnerException.Message);
                return View(cliente);
            }
            catch (Exception ex)
            {
                _logger.LogError(ex.Message, ex);
                ModelState.AddModelError("Custom", "Error desconocido");
                return View(cliente);
            }
        }

    }
}
