using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Trainee.Application.Interfaces;
using Trainee.Application.ViewModels;

namespace Trainee.Web.Controllers
{
    public class ProdutoController : Controller
    {
        private readonly IProdutoAppService _produtoAppService;
        public ProdutoController(IProdutoAppService produtoAppService)
        {
            this._produtoAppService = produtoAppService;
        }

        [HttpGet("produto")]
        public async Task<IActionResult> Index()
        {
            return View(await _produtoAppService.GetAll());
        }

        [HttpGet("produto/adicionar")]
        public IActionResult Create()
        {
            
            return View();
        }

        [HttpPost("produto/adicionar")]
        public async Task<IActionResult> Create(ProdutoViewModel produtoViewModel)
        {
            if (!ModelState.IsValid) return View(produtoViewModel);

            var result = await _produtoAppService.Register(produtoViewModel);

            if (result != null)
                return View(produtoViewModel);

            ViewBag.Sucesso = "Produto cadastrado com sucesso!";

            return RedirectToAction("Index");
        }

        [HttpGet("produto/atualizar/{id}")]
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null) return NotFound();

            var produtoViewModel = await _produtoAppService.GetById(id.Value);

            if (produtoViewModel == null) return NotFound();

            return View(produtoViewModel);
        }

        [HttpPost("produto/atualizar")]
        public async Task<IActionResult> Edit(ProdutoViewModel produtoViewModel)
        {
            if (!ModelState.IsValid) return View(produtoViewModel);

            var result = await _produtoAppService.Update(produtoViewModel);

            if (result != null)
                return View(produtoViewModel);

            ViewBag.Sucesso = "Produto cadastrado com sucesso!";

            return RedirectToAction("Index");
        }

        [HttpGet("produto/ativar-inativar/{id}")]
        public async Task<IActionResult> ActivateInactivate(int? id)
        {
            if (id == null) return NotFound();

            var produtoViewModel = await _produtoAppService.ActivateInactivate(id.Value);

            return RedirectToAction("Index");
        }
    }
}
