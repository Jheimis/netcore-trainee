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
    public class ProdutoAppService : IProdutoAppService
    {
        private IMapper _mapper;
        private IProdutoRepository _produtoRepository;
        public ProdutoAppService(IMapper mapper,
                                 IProdutoRepository produtoRepository)
        {
            this._mapper = mapper;
            this._produtoRepository = produtoRepository;
        }
        public async Task<ValidationResult> ActivateInactivate(int id)
        {
            return await _produtoRepository.ActivateInactivate(id);
        }

        public void Dispose()
        {
            GC.SuppressFinalize(this);
        }

        public async Task<IEnumerable<ProdutoViewModel>> GetAll()
        {
            return _mapper.Map<IEnumerable<ProdutoViewModel>>(await _produtoRepository.GetAll());
        }

        public async Task<ProdutoViewModel> GetById(int id)
        {
            return _mapper.Map<ProdutoViewModel>(await _produtoRepository.GetById(id));
        }

        public async Task<ValidationResult> Register(ProdutoViewModel produtoViewModel)
        {
            return await _produtoRepository.Add(_mapper.Map<Produto>(produtoViewModel));
        }

        public async Task<ValidationResult> Update(ProdutoViewModel produtoViewModel)
        {
            return await _produtoRepository.Update(_mapper.Map<Produto>(produtoViewModel));
        }
    }
}
