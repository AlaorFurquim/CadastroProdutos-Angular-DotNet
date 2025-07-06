using ProdutosAPI.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProdutosAPI.Domain.Interfaces
{
    public interface Iproduto
    {
        Task<List<Produto>> ListarAsync();
        Task<Produto> BuscarPorId(int id);

        Task AdicionarAsync(Produto produto);

        Task AtualizarAsync(Produto produto);

        Task RemoverAsync(int id);
    }
}
