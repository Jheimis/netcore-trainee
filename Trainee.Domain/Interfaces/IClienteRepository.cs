using NetDevPack.Data;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Threading.Tasks;
using Trainee.Domain.Models;

namespace Trainee.Domain.Interfaces
{
    public interface IClienteRepository : IRepository<Cliente>
    {
        Task<Cliente> GetById(int id);
        Task<IEnumerable<Cliente>> GetAll();

        Task<ValidationResult> Add(Cliente cliente);
        Task<ValidationResult> Update(Cliente cliente);
        Task<ValidationResult> ActivateInactivate(int id);
    }
}
