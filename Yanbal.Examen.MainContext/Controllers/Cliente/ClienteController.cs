using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using Yanbal.Examen.Application.MainContext.AppServices.Contracts;
using Yanbal.Examen.Application.MainContext.Dtos;

namespace Yanbal.Examen.MainContext.Controllers.Cliente
{
    [Route("api/[controller]")]
    [ApiController]
    public class ClienteController : ControllerBase
    {
        readonly IClienteAppServices _clienteAppServices;
        readonly ILogger<ClienteController> _logger;

        public ClienteController(IClienteAppServices clienteAppServices, ILogger<ClienteController> logger)
        {
            _clienteAppServices = clienteAppServices ?? throw new ArgumentNullException("clienteAppServices");
            _logger = logger ?? throw new ArgumentNullException("logger");
        }


        [HttpGet]
        public async Task<IActionResult> Get()
        {
            try
            {
                return Ok(await _clienteAppServices.GetListClientes());
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, ex.Message);
                return Problem(ex.Message);
            }
        }

        [HttpPost]
        public void Post([FromBody] string value)
        {
        }

    }
}
