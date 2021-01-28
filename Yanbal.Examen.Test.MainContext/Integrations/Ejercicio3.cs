using AutoMapper;
using Moq;
using NUnit.Framework;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Yanbal.Examen.Application.MainContext.AppServices.Contracts;
using Yanbal.Examen.Application.MainContext.AppServices.Implementations;
using Yanbal.Examen.Application.MainContext.Dtos;
using Yanbal.Examen.Domain.Core;
using Yanbal.Examen.Domain.MainContext.Aggregates.ClienteAgg;

namespace Yanbal.Examen.Test.MainContext.Integrations
{
    [TestFixture]
    public class Ejercicio3
    {
        IClienteAppServices clienteAppServices;
        Mock<IUnitOfWork> unitOfWork;
        Mock<IClienteRepository> clienteRepository;
        IMapper mapper;

        #region privates
        IEnumerable<Cliente> GetlistaClientes()
        {
            List<Cliente> listaClientes = new List<Cliente>()
            {
                new Cliente { Id = 1, Nombres = "Carlos", Apellidos = "Alcantara", Correo = "carlos@dominio.com", FechaNacimiento = null, FechaRegistro = DateTime.Now, Activo = true },
                new Cliente { Id = 2, Nombres = "Luis", Apellidos = "Reyes", Correo = "luis@dominio.com", FechaNacimiento = null, FechaRegistro = DateTime.Now, Activo = true },
                new Cliente { Id = 3, Nombres = "Marcos", Apellidos = "Pinillos", Correo = "marcos1@dominio.com", FechaNacimiento = null, FechaRegistro = DateTime.Now, Activo = true },
                new Cliente { Id = 4, Nombres = "Marcos", Apellidos = "Buis", Correo = "marcos2@dominio.com", FechaNacimiento = null, FechaRegistro = DateTime.Now, Activo = true },
                new Cliente { Id = 5, Nombres = "Alberto", Apellidos = "Coronel", Correo = "alberto@dominio.com", FechaNacimiento = null, FechaRegistro = DateTime.Now, Activo = true }
            };
            return listaClientes.AsEnumerable();
        }
        IEnumerable<ClienteDto> GetlistaClientesAssert()
        {
            List<ClienteDto> listaClientes = new List<ClienteDto>()
            {
                new ClienteDto { Id = 1, Nombres = "Carlos", Apellidos = "Alcantara", Correo = "carlos@dominio.com", FechaNacimiento = null, FechaRegistro = DateTime.Now, Activo = true },
                new ClienteDto { Id = 2, Nombres = "Luis", Apellidos = "Reyes", Correo = "luis@dominio.com", FechaNacimiento = null, FechaRegistro = DateTime.Now, Activo = true },
                new ClienteDto { Id = 3, Nombres = "Marcos", Apellidos = "Pinillos", Correo = "marcos1@dominio.com", FechaNacimiento = null, FechaRegistro = DateTime.Now, Activo = true },
                new ClienteDto { Id = 4, Nombres = "Marcos", Apellidos = "Buis", Correo = "marcos2@dominio.com", FechaNacimiento = null, FechaRegistro = DateTime.Now, Activo = true },
                new ClienteDto { Id = 5, Nombres = "Alberto", Apellidos = "Coronel", Correo = "alberto@dominio.com", FechaNacimiento = null, FechaRegistro = DateTime.Now, Activo = true }
            };
            return listaClientes.AsEnumerable();
        }
        ClienteDto GetClienteDto()
        {
            return new ClienteDto { Id = 1, Nombres = "Carlos", Apellidos = "Alcantara", Correo = "carlos@dominio.com", FechaNacimiento = null, FechaRegistro = DateTime.Now, Activo = true };
        }
        Cliente GetCliente()
        {
            return new Cliente { Id = 1, Nombres = "Carlos", Apellidos = "Alcantara", Correo = "carlos@dominio.com", FechaNacimiento = null, FechaRegistro = DateTime.Now, Activo = true };
        }
        #endregion

        [SetUp]
        public void SetUp()
        {
            unitOfWork = new Mock<IUnitOfWork>();
            unitOfWork.Setup(sp => sp.CommitAsync()).Returns(Task.FromResult(1));

            clienteRepository = new Mock<IClienteRepository>();
            clienteRepository.Setup(sp => sp.GetListClientes()).Returns(Task.FromResult(GetlistaClientes()));

            var mapperConfig = new MapperConfiguration(cfg =>
            cfg.CreateMap<Cliente, ClienteDto>().ReverseMap());

            mapper = mapperConfig.CreateMapper();
        }

        [Test]
        public void T301_EJERCICIO_3_LISTA_DE_CLIENTES()
        {
            //Arrange
            IEnumerable<ClienteDto> expected = GetlistaClientesAssert();
            clienteAppServices = new ClienteAppServices(unitOfWork.Object, clienteRepository.Object, mapper);

            //Act
            Task<IEnumerable<ClienteDto>> result = clienteAppServices.GetListClientes();

            //Assert
            CollectionAssert.AreEqual(expected, result.Result);
        }


        [Test]
        public void T302_EJERCICIO_3_GUARDAR_CLIENTE_OK()
        {
            //Arrange
            var clienteRepository = new Mock<IClienteRepository>();
            clienteRepository.Setup(sp => sp.GetClienteByCorreo(It.IsAny<string>()));
            clienteRepository.Setup(sp => sp.SaveCliente(It.IsAny<Cliente>())).Returns(Task.FromResult(true));
            clienteAppServices = new ClienteAppServices(unitOfWork.Object, clienteRepository.Object, mapper);

            //Act
            Task<bool> result = clienteAppServices.SaveCliente(GetClienteDto());

            //Assert
            Assert.AreEqual(true, result.Result);
        }

        [Test]
        public void T303_EJERCICIO_3_GUARDAR_CLIENTE_CORREO_EXISTE()
        {
            //Arrange
            var clienteRepository = new Mock<IClienteRepository>();
            clienteRepository.Setup(sp => sp.GetClienteByCorreo(It.IsAny<string>())).Returns(Task.FromResult(GetCliente()));
            clienteRepository.Setup(sp => sp.SaveCliente(It.IsAny<Cliente>())).Returns(Task.FromResult(true));
            clienteAppServices = new ClienteAppServices(unitOfWork.Object, clienteRepository.Object, mapper);

            //Act
            Task<bool> result = clienteAppServices.SaveCliente(GetClienteDto());

            //Assert
            Assert.Throws<ArgumentException>(delegate { throw new ArgumentException("Correo", new Exception("Ya existe un cliente con este correo"));});
        }

    }
}
