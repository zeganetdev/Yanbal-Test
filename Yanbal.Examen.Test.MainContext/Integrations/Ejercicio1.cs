using NUnit.Framework;
using System.Collections.Generic;
using Yanbal.Examen.Application.MainContext.AppServices.Contracts;
using Yanbal.Examen.Application.MainContext.AppServices.Implementations;
using Yanbal.Examen.Application.MainContext.Dtos;

namespace Yanbal.Examen.Test.MainContext.Integrations
{
    [TestFixture]
    public class Ejercicio1
    {
        IOrdenarListaAppServices ordenarLista;
        List<UsuarioOrderDto> usuarioOrderDtos;
        List<UsuarioOrderDto> usuarioOrderDtosAssert;

        #region "Privates"

        private List<UsuarioOrderDto> GetListUsers()
        {
            usuarioOrderDtos.Add(new UsuarioOrderDto { Nombre = "Carlos", Apellido = "Alcantara" });
            usuarioOrderDtos.Add(new UsuarioOrderDto { Nombre = "Luis", Apellido = "Reyes" });
            usuarioOrderDtos.Add(new UsuarioOrderDto { Nombre = "Marcos", Apellido = "Pinillos" });
            usuarioOrderDtos.Add(new UsuarioOrderDto { Nombre = "Marcos", Apellido = "Buis" });
            usuarioOrderDtos.Add(new UsuarioOrderDto { Nombre = "Alberto", Apellido = "Coronel" });
            return usuarioOrderDtos;
        }

        private List<UsuarioOrderDto> GetListUsersOrderNombreAssert()
        {
            usuarioOrderDtosAssert.Add(new UsuarioOrderDto { Nombre = "Alberto", Apellido = "Coronel" });
            usuarioOrderDtosAssert.Add(new UsuarioOrderDto { Nombre = "Carlos", Apellido = "Alcantara" });
            usuarioOrderDtosAssert.Add(new UsuarioOrderDto { Nombre = "Luis", Apellido = "Reyes" });
            usuarioOrderDtosAssert.Add(new UsuarioOrderDto { Nombre = "Marcos", Apellido = "Pinillos" });
            usuarioOrderDtosAssert.Add(new UsuarioOrderDto { Nombre = "Marcos", Apellido = "Buis" });
            return usuarioOrderDtosAssert;
        }

        private List<UsuarioOrderDto> GetListUsersOrderNombreApellidoAssert()
        {
            usuarioOrderDtosAssert.Add(new UsuarioOrderDto { Nombre = "Alberto", Apellido = "Coronel" });
            usuarioOrderDtosAssert.Add(new UsuarioOrderDto { Nombre = "Carlos", Apellido = "Alcantara" });
            usuarioOrderDtosAssert.Add(new UsuarioOrderDto { Nombre = "Luis", Apellido = "Reyes" });
            usuarioOrderDtosAssert.Add(new UsuarioOrderDto { Nombre = "Marcos", Apellido = "Buis" });
            usuarioOrderDtosAssert.Add(new UsuarioOrderDto { Nombre = "Marcos", Apellido = "Pinillos" });
            return usuarioOrderDtosAssert;
        }

        #endregion

        [SetUp]
        public void SetUp()
        {
            ordenarLista = new OrdenarListaAppServices();
            usuarioOrderDtos = new List<UsuarioOrderDto>();
            usuarioOrderDtosAssert = new List<UsuarioOrderDto>();
        }

        [Test]
        public void T101_EJERCICIO_1_ORDENAR_NOMBRE()
        {
            //Arrange
            List<UsuarioOrderDto> expected = GetListUsersOrderNombreAssert();

            //Act
            List<UsuarioOrderDto> result = ordenarLista.OrdenarPorNombre(GetListUsers());

            //Assert
            CollectionAssert.AreEqual(expected, result, "Lista de usuarios no ordenada");
        }

        [Test]
        public void T102_EJERCICIO_1_ORDENAR_NOMBRE_APELLIDO()
        {
            //Arrange
            List<UsuarioOrderDto> expected = GetListUsersOrderNombreApellidoAssert();

            //Act
            List<UsuarioOrderDto> result = ordenarLista.OrdenarPorNombreApellido(GetListUsers());

            //Assert
            CollectionAssert.AreEqual(expected, result, "Lista de usuarios no ordenada");
        }

    }
}
