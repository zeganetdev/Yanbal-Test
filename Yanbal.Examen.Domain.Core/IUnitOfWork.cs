using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace Yanbal.Examen.Domain.Core
{

    public interface IUnitOfWork
    {
        int Commit();
        Task<int> CommitAsync();
    }
}
