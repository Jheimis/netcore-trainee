using Microsoft.EntityFrameworkCore;
using NetDevPack.Data;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;
using System.Threading.Tasks;
using Trainee.Domain.Interfaces;
using Trainee.Domain.Models;
using Trainee.Infra.Data.Context;

namespace Trainee.Infra.Data.Repository
{
    public class ClienteRepository : IClienteRepository
    {
        public IUnitOfWork UnitOfWork => Db;
        protected readonly TraineeContext Db;
        protected readonly DbSet<Cliente> DbSet;

        public ClienteRepository(TraineeContext context)
        {
            Db = context;
            DbSet = Db.Set<Cliente>();
        }

        public async Task<ValidationResult> ActivateInactivate(int id)
        {
            try
            {
                var cliente = await DbSet.FindAsync(id);
                cliente.Ativo = !cliente.Ativo;
                DbSet.Update(cliente);
                Db.SaveChanges();
                return ValidationResult.Success;
            }
            catch (Exception e)
            {
                return new ValidationResult(e.Message);
            }
        }

        public async Task<ValidationResult> Add(Cliente cliente)
        {
            try
            {
                await DbSet.AddAsync(cliente);
                Db.SaveChanges();
                return ValidationResult.Success;
            }
            catch (Exception e)
            {

                return new ValidationResult(e.Message);
            }
        }

        public async Task<IEnumerable<Cliente>> GetAll()
        {
            return await DbSet.ToListAsync();
        }

        public async Task<Cliente> GetById(int id)
        {
            return await DbSet.FindAsync(id);
        }

        public async Task<ValidationResult> Update(Cliente cliente)
        {
            try
            {
                await Task.Run(() =>
                {
                    DbSet.Update(cliente);
                });
                Db.SaveChanges();
                return ValidationResult.Success;
            }
            catch (Exception e)
            {
                return new ValidationResult(e.Message);

            }
        }

        public void Dispose()
        {
            Db.Dispose();
        }
    }
}
