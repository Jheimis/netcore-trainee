using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;
using System.Threading.Tasks;
using Trainee.Application.Interfaces;
using Trainee.Application.ViewModels;

namespace Trainee.Service.Api.Controllers
{
    public class ProdutoController : ApiController
    {

        private readonly IProdutoAppService _produtoAppService;

        public ProdutoController(IProdutoAppService produtoAppService)
        {
            this._produtoAppService = produtoAppService;
        }

        
        [HttpGet("api/produto")]
        public async Task<IEnumerable<ProdutoViewModel>> Get()
        {
            return await _produtoAppService.GetAll();
        }

        [HttpGet("api/produto/{id}")]
        public async Task<ProdutoViewModel> Get(int id)
        {
            return await _produtoAppService.GetById(id);
        }

        [HttpPost("api/produto")]
        public async Task<IActionResult> Post([FromBody] ProdutoViewModel produtoViewModel)
        {

            return !ModelState.IsValid ? CustomResponse(ModelState) : CustomResponse(await _produtoAppService.Register(produtoViewModel));
        }

        [HttpPut("api/produto/{id}")]
        public async Task<IActionResult> Put([FromBody] ProdutoViewModel produtoViewModel)
        {

            return !ModelState.IsValid ? CustomResponse(ModelState) : CustomResponse(await _produtoAppService.Update(produtoViewModel));
        }

        [HttpPatch("api/produto/{id}")]
        public async Task<IActionResult> ActivateInactivate(int id)
        {

            return !ModelState.IsValid ? CustomResponse(ModelState) : CustomResponse(await _produtoAppService.ActivateInactivate(id));
        }
    }
}
