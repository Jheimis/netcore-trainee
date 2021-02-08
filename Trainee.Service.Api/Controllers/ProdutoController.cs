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
    public class ProdutoController : ApiController
    {

        private readonly IProdutoAppService _produtoAppService;

        public ProdutoController(IProdutoAppService produtoAppService)
        {
            this._produtoAppService = produtoAppService;
        }

        
        [HttpGet("produto")]
        public async Task<IEnumerable<ProdutoViewModel>> Get()
        {
            return await _produtoAppService.GetAll();
        }
    }
}
