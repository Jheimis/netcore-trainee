using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;
using System.Threading.Tasks;
using Trainee.Application.ViewModels;

namespace Trainee.Application.Interfaces
{
    public interface IClienteAppService : IDisposable
    {
        Task<IEnumerable<ClienteViewModel>> GetAll();
        Task<ClienteViewModel> GetById(int id);

        Task<ValidationResult> Register(ClienteViewModel clienteViewModel);
        Task<ValidationResult> Update(ClienteViewModel clienteViewModel);
        Task<ValidationResult> ActivateInactivate(int id);
    }
}
