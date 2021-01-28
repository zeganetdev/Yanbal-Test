using System.Threading.Tasks;
using Yanbal.Examen.Domain.Core;

namespace Yanbal.Examen.Infra.Data.MainContext.Context
{
    public class UnitOfWork : IUnitOfWork
    {
        private readonly AppDbContext _context;

        public UnitOfWork(AppDbContext context)
        {
            _context = context;
        }

        public int Commit()
        {
            return _context.SaveChanges();
        }
        public async Task<int> CommitAsync()
        {
            return await _context.SaveChangesAsync();
        }
    }
}
