using NetDevPack.Domain;
using System;
using System.Collections.Generic;
using System.Text;

namespace Trainee.Domain.Models
{
    public class Produto : Entity, IAggregateRoot
    {
        protected Produto() { }
        public int Id { get; set; }
        public string Nome { get; set; }
        public decimal Valor { get; set; }
        public bool Ativo { get; set; }

    }
}
