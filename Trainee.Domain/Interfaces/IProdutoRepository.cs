using NetDevPack.Data;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;
using System.Threading.Tasks;
using Trainee.Domain.Models;

namespace Trainee.Domain.Interfaces
{
    public interface IProdutoRepository : IRepository<Produto>
    {
        Task<Produto> GetById(int id);
        Task<IEnumerable<Produto>> GetAll();

        Task<ValidationResult> Add(Produto produto);
        Task<ValidationResult> Update(Produto produto);
        Task<ValidationResult> ActivateInactivate(int id);
    }
}
