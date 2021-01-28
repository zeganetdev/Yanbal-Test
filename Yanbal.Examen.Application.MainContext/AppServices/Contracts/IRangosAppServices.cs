using System.Collections.Generic;

namespace Yanbal.Examen.Application.MainContext.AppServices.Contracts
{
    public interface IRangosAppServices
    {
        /// <summary>
        /// Completa los numeros faltantes y los ordena.
        /// </summary>
        /// <param name="rangoNumero">
        /// Lista de numeros en cualquier orden.
        /// </param>
        /// <returns>
        /// Retorna una secuencia de numeros ordenados.
        /// </returns>
        IEnumerable<int> CompletarRango(IEnumerable<int> rangoNumero);
    }
}
