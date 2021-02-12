using AutoMapper;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;
using System.Threading.Tasks;
using Trainee.Application.Interfaces;
using Trainee.Application.ViewModels;
using Trainee.Domain.Interfaces;
using Trainee.Domain.Models;

namespace Trainee.Application.Services
{
    public class ClienteAppService : IClienteAppService
    {
        private IMapper _mapper;
        private IClienteRepository _clienteRepository;
        public ClienteAppService(IMapper mapper,
                                 IClienteRepository clienteRepository)
        {
            this._mapper = mapper;
            this._clienteRepository = clienteRepository;
        }
        public async Task<ValidationResult> ActivateInactivate(int id)
        {
            return await _clienteRepository.ActivateInactivate(id);
        }

        public void Dispose()
        {
            GC.SuppressFinalize(this);
        }

        public async Task<IEnumerable<ClienteViewModel>> GetAll()
        {
            return _mapper.Map<IEnumerable<ClienteViewModel>>(await _clienteRepository.GetAll());
        }

        public async Task<ClienteViewModel> GetById(int id)
        {
            return _mapper.Map<ClienteViewModel>(await _clienteRepository.GetById(id));
        }

        public async Task<ValidationResult> Register(ClienteViewModel clienteViewModel)
        {
            return await _clienteRepository.Add(_mapper.Map<Cliente>(clienteViewModel));
        }


        public async Task<ValidationResult> Update(ClienteViewModel clienteViewModel)
        {
            return await _clienteRepository.Update(_mapper.Map<Cliente>(clienteViewModel));
        }

    }
}
