using ProdutosAPI.Application.Dto;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProdutosAPI.Application.Interfaces
{
    public interface IProdutoService
    {
        Task<List<ProdutoDto>> ListarAsync();
        Task<ProdutoDto> BuscarPorIdAsync(int id);
        Task AdicionarAsync(ProdutoDto produtoDto);
        Task AtualizarAsync(ProdutoDto produtoDto);
        Task RemoverAsync(int id);

    }
}
