using AutoMapper;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using Yanbal.Examen.Application.MainContext.AppServices.Contracts;
using Yanbal.Examen.Application.MainContext.Dtos;
using Yanbal.Examen.Domain.Core;
using Yanbal.Examen.Domain.MainContext.Aggregates.ClienteAgg;

namespace Yanbal.Examen.Application.MainContext.AppServices.Implementations
{
    public class ClienteAppServices : IClienteAppServices
    {
        readonly IUnitOfWork _unitOfWork;
        readonly IClienteRepository _clienteRepository;
        readonly IMapper _mapper;

        public ClienteAppServices(IUnitOfWork unitOfWork, IClienteRepository clienteRepository, IMapper mapper)
        {
            _unitOfWork = unitOfWork ?? throw new ArgumentNullException(nameof(unitOfWork));
            _clienteRepository = clienteRepository ?? throw new ArgumentNullException(nameof(clienteRepository));
            _mapper = mapper ?? throw new ArgumentNullException(nameof(mapper));
        }

        public async Task<IEnumerable<ClienteDto>> GetListClientes()
        {
            var result = await _clienteRepository.GetListClientes();
            return _mapper.Map<IEnumerable<Cliente>, IEnumerable<ClienteDto>>(result);
        }

        public async Task<bool> SaveCliente(ClienteDto clienteDto)
        {
            var cliente = await _clienteRepository.GetClienteByCorreo(clienteDto.Correo);
            cliente?.ValidaCorreo(clienteDto.Correo);

            clienteDto.Activo = true;
            clienteDto.FechaRegistro = DateTime.Now;
            await _clienteRepository.SaveCliente(_mapper.Map<ClienteDto, Cliente>(clienteDto));
            await _unitOfWork.CommitAsync();
            return true;
        }
    }
}
