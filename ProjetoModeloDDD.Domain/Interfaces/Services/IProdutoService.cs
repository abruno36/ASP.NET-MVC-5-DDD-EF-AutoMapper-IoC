using ProjetoModeloDDD.Domain.Entities;
using System.Collections.Generic;
namespace ProjetoModeloDDD.Domain.Interfaces.Services
{
    public interface IProdutoService : IServiceBase<Produto>
    {
        IEnumerable<Produto> BuscarPorNome(string nome);

    }
}

