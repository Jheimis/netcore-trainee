namespace Application.Interfaces
{
    public interface IProdutoService : IDisposable
    {
        Task<IEnumerable<ProdutoViewModel>> obterTodos();
        Task<ProdutoViewModel> ObterId(int id);
        Task<bool> Adicionar(ProdutoViewModel modelo);
        Task<bool> Atualizar(ProdutoViewModel modelo);
        Task<bool> AtivarDesativar(int id);
         
    }
}