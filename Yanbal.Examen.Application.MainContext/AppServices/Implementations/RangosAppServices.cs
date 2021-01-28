using System.Collections.Generic;
using System.Linq;
using Yanbal.Examen.Application.MainContext.AppServices.Contracts;

namespace Yanbal.Examen.Application.MainContext.AppServices.Implementations
{
    public class RangosAppServices : IRangosAppServices
    {
        public IEnumerable<int> CompletarRango(IEnumerable<int> rangoNumero) => Enumerable.Range(rangoNumero.Min(), (rangoNumero.Max() - rangoNumero.Min()) + 1);
    }
}
