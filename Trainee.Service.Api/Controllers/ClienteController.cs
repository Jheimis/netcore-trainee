using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Trainee.Application.Interfaces;
using Trainee.Application.ViewModels;

namespace Trainee.Service.Api.Controllers
{
    public class ClienteController : ApiController
    {
        private readonly IClienteAppService _clienteAppService;

        public ClienteController(IClienteAppService clienteAppService)
        {
            this._clienteAppService = clienteAppService;
        }


        [HttpGet("api/cliente")]
        public async Task<IEnumerable<ClienteViewModel>> Get()
        {
            return await _clienteAppService.GetAll();
        }

        [HttpGet("api/cliente/{id}")]
        public async Task<ClienteViewModel> Get(int id)
        {
            return await _clienteAppService.GetById(id);
        }

        [HttpPost("api/cliente")]
        public async Task<IActionResult> Post([FromBody] ClienteViewModel clienteViewModel)
        {

            return !ModelState.IsValid ? CustomResponse(ModelState) : CustomResponse(await _clienteAppService.Register(clienteViewModel));
        }

        [HttpPut("api/cliente/{id}")]
        public async Task<IActionResult> Put([FromBody] ClienteViewModel clienteViewModel)
        {

            return !ModelState.IsValid ? CustomResponse(ModelState) : CustomResponse(await _clienteAppService.Update(clienteViewModel));
        }

        [HttpPatch("api/cliente/{id}")]
        public async Task<IActionResult> ActivateInactivate(int id)
        {

            return !ModelState.IsValid ? CustomResponse(ModelState) : CustomResponse(await _clienteAppService.ActivateInactivate(id));
        }
    }
}
