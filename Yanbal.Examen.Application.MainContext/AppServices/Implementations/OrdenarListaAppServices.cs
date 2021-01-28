using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Yanbal.Examen.Application.MainContext.AppServices.Contracts;
using Yanbal.Examen.Application.MainContext.Dtos;

namespace Yanbal.Examen.Application.MainContext.AppServices.Implementations
{
    public class OrdenarListaAppServices : IOrdenarListaAppServices
    {

        public List<UsuarioOrderDto> OrdenarPorNombre(List<UsuarioOrderDto> usuarioOrderDtos) => usuarioOrderDtos.OrderBy(x => x.Nombre).ToList();

        public List<UsuarioOrderDto> OrdenarPorNombreApellido(List<UsuarioOrderDto> usuarioOrderDtos) => usuarioOrderDtos.OrderBy(x => x.Nombre).ThenBy(x => x.Apellido).ToList();

    }
}
