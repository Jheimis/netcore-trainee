using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;
using System.Threading.Tasks;
using Trainee.Application.ViewModels;

namespace Trainee.Application.Interfaces
{
    public interface IProdutoAppService : IDisposable
    {
        Task<IEnumerable<ProdutoViewModel>> GetAll();
        Task<ProdutoViewModel> GetById(int id);

        Task<ValidationResult> Register(ProdutoViewModel produtoViewModel);
        Task<ValidationResult> Update(ProdutoViewModel produtoViewModel);
        Task<ValidationResult> ActivateInactivate(int id);

    }
}
