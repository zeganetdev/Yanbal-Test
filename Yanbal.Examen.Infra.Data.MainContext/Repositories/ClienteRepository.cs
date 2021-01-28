using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Yanbal.Examen.Domain.MainContext.Aggregates.ClienteAgg;
using Yanbal.Examen.Infra.Data.Core;
using Yanbal.Examen.Infra.Data.MainContext.Context;

namespace Yanbal.Examen.Infra.Data.MainContext.Repositories
{
    public class ClienteRepository: Repository<Cliente>, IClienteRepository
    {
        readonly AppDbContext _context;
        public ClienteRepository(AppDbContext dbContext) : base(dbContext)
        {
            _context = dbContext as AppDbContext;
        }

        public async Task<Cliente> GetClienteByCorreo(string correo)
        {
            return await (from s in _context.Clientes
                          where s.Activo && s.Correo.Equals(correo)
                          select s).FirstOrDefaultAsync();
        }

        public async Task<IEnumerable<Cliente>> GetListClientes()
        {
            return await (from s in _context.Clientes
                          where s.Activo
                          select s).ToListAsync();
        }

        public async Task<bool> SaveCliente(Cliente cliente)
        {
            await _context.AddAsync(cliente);
            return true;
        }

    }
}
