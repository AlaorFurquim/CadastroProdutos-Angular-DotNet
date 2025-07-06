using ProdutosAPI.Application.Dto;
using ProdutosAPI.Domain.Entities;
using ProdutosAPI.Domain.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Linq;
using System.Threading.Tasks;



namespace ProdutosAPI.Application.Interfaces
{
    public class ProdutoService : IProdutoService
    {
        private readonly Iproduto _service;

        public ProdutoService(Iproduto produtoService)
        {
            _service = produtoService;
        }
        public async Task AdicionarAsync(ProdutoDto produtoDto)
        {
            if (produtoDto == null) { 
             throw new ArgumentNullException(nameof(produtoDto));
            }
            else
            {
                await _service.AdicionarAsync(new Produto
                {
                    Nome = produtoDto.Nome,
                    Preco = produtoDto.Preco
                });


            }
        }

        public async Task AtualizarAsync(ProdutoDto produtoDto)
        {
            if (produtoDto == null) { 
                throw new AbandonedMutexException(nameof(produtoDto));
            }
            else
            {
                await _service.AtualizarAsync(new Produto
                {
                    Id = produtoDto.Id,
                    Nome = produtoDto.Nome,
                    Preco = produtoDto.Preco
                });
            }
        }

        public async Task<ProdutoDto> BuscarPorIdAsync(int id)
        {
            var produto = await _service.BuscarPorId(id);
            if (produto == null) return null;

            return new ProdutoDto
            {
                Id = produto.Id,
                Nome = produto.Nome,
                Preco = produto.Preco
            };
        }


        public async Task<List<ProdutoDto>> ListarAsync()
        {
            var produtos = await _service.ListarAsync();

            return produtos.Select(p => new ProdutoDto
            {
                Id = p.Id,
                Nome = p.Nome,
                Preco = p.Preco
            }).ToList();
        }

        public async Task RemoverAsync(int id)
        {
            await _service.RemoverAsync(id);
        }
    }
}
