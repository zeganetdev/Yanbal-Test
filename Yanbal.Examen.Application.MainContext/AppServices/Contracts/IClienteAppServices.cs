using System.Collections.Generic;
using System.Threading.Tasks;
using Yanbal.Examen.Application.MainContext.Dtos;

namespace Yanbal.Examen.Application.MainContext.AppServices.Contracts
{
    public interface IClienteAppServices
    {
        /// <summary>
        /// Obtiene una lista de Cliente.
        /// </summary>
        Task<IEnumerable<ClienteDto>> GetListClientes();
        /// <summary>
        /// Registra un cliente.
        /// </summary>
        Task<bool> SaveCliente(ClienteDto clienteDto);
    }
}
