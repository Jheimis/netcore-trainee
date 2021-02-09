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
    public class ProdutoRepository : IProdutoRepository
    {
        protected readonly TraineeContext Db;
        protected readonly DbSet<Produto> DbSet;

        public ProdutoRepository(TraineeContext context)
        {
            Db = context;
            DbSet = Db.Set<Produto>();
        }
        public IUnitOfWork UnitOfWork => Db;

        public async Task<ValidationResult> ActivateInactivate(int id)
        {
            try
            {
                var produto = await DbSet.FindAsync(id);
                produto.Ativo = !produto.Ativo;
                DbSet.Update(produto);
                Db.SaveChanges();
                return ValidationResult.Success;
            }
            catch (Exception e)
            {
                return new ValidationResult(e.Message);
            }
        }

        public async Task<ValidationResult> Add(Produto produto)
        {
            try
            {
                await DbSet.AddAsync(produto);
                Db.SaveChanges();
                return ValidationResult.Success;
            }
            catch (Exception e)
            {

                return new ValidationResult(e.Message);
            }           
        }

        public async Task<IEnumerable<Produto>> GetAll()
        {
            return await DbSet.ToListAsync();
        }

        public async Task<Produto> GetById(int id)
        {
            return await DbSet.FindAsync(id);
        }

        public async Task<ValidationResult> Update(Produto produto)
        {
            try
            {
                await Task.Run(() =>
                {
                    DbSet.Update(produto);
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
