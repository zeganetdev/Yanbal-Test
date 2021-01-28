using System.Collections.Generic;
using Yanbal.Examen.Application.MainContext.Dtos;

namespace Yanbal.Examen.Application.MainContext.AppServices.Contracts
{
    public interface IOrdenarListaAppServices
    {
        /// <summary>
        /// Ordena una lista de objetos Usuario.
        /// </summary>
        /// <param name="usuarioOrderDtos">
        /// Lista de usuarios.
        /// </param>
        /// <returns>
        /// Retorna una lista de objetos Usuario ordenada por nombre.
        /// </returns>
        List<UsuarioOrderDto> OrdenarPorNombre(List<UsuarioOrderDto> usuarioOrderDtos);

        /// <summary>
        /// Ordena una lista de objetos Usuario.
        /// </summary>
        /// <param name="usuarioOrderDtos">
        /// Lista de usuarios.
        /// </param>
        /// <returns>
        /// Retorna una lista de objetos Usuario ordenada por nombre y apellido.
        /// </returns>
        List<UsuarioOrderDto> OrdenarPorNombreApellido(List<UsuarioOrderDto> usuarioOrderDtos);
    }
}
