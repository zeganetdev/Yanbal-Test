using System.Collections.Generic;
using System.Threading.Tasks;
using Yanbal.Examen.Domain.Core;

namespace Yanbal.Examen.Domain.MainContext.Aggregates.ClienteAgg
{
    public interface IClienteRepository: IRepository<Cliente>
    {
        Task<IEnumerable<Cliente>> GetListClientes();
        Task<bool> SaveCliente(Cliente cliente);
        Task<Cliente> GetClienteByCorreo(string correo);
    }
}
