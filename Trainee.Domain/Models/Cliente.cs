using NetDevPack.Domain;

namespace Trainee.Domain.Models
{
    public class Cliente : Entity, IAggregateRoot
    {
        protected Cliente() { }
        public int Id { get; set; }
        public string Nome { get; set; }
        public bool Ativo { get; set; }
    }
}
