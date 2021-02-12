using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Trainee.Application.Interfaces;
using Trainee.Application.ViewModels;

namespace Trainee.Web.Controllers
{
    public class ClienteController : Controller
    {
        private readonly IClienteAppService _clienteAppService;
        public ClienteController(IClienteAppService clienteAppService)
        {
            this._clienteAppService = clienteAppService;
        }

        [HttpGet("cliente")]
        public async Task<IActionResult> Index()
        {
            return View(await _clienteAppService.GetAll());
        }

        [HttpGet("cliente/adicionar")]
        public IActionResult Create()
        {

            return View();
        }

        [HttpPost("cliente/adicionar")]
        public async Task<IActionResult> Create(ClienteViewModel clienteViewModel)
        {
            if (!ModelState.IsValid) return View(clienteViewModel);

            var result = await _clienteAppService.Register(clienteViewModel);

            if (result != null)
                return View(clienteViewModel);


            return RedirectToAction("Index");
        }

        [HttpGet("cliente/atualizar/{id}")]
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null) return NotFound();

            var clienteViewModel = await _clienteAppService.GetById(id.Value);

            if (clienteViewModel == null) return NotFound();

            return View(clienteViewModel);
        }

        [HttpPost("cliente/atualizar")]
        public async Task<IActionResult> Edit(ClienteViewModel clienteViewModel)
        {
            if (!ModelState.IsValid) return View(clienteViewModel);

            var result = await _clienteAppService.Update(clienteViewModel);

            if (result != null)
                return View(clienteViewModel);

            ViewBag.Sucesso = "Produto cadastrado com sucesso!";

            return RedirectToAction("Index");
        }

        [HttpGet("produto/ativar-inativar/{id}")]
        public async Task<IActionResult> ActivateInactivate(int? id)
        {
            if (id == null) return NotFound();

            var produtoViewModel = await _clienteAppService.ActivateInactivate(id.Value);

            return RedirectToAction("Index");
        }
    }
}
}
