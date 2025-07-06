using Microsoft.EntityFrameworkCore;
using ProdutosAPI.Domain.Entities;
using ProdutosAPI.Domain.Interfaces;
using ProdutosAPI.Infrastructure.Context;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProdutosAPI.Infrastructure
{
    public class ProdutoRepository : Iproduto
    {
        private readonly AppDbContext _context;

        public ProdutoRepository(AppDbContext appContext)
        {
            _context = appContext;
        }
        public async Task AdicionarAsync(Produto produto)
        {
            _context.Produtos.Add(produto);
            await _context.SaveChangesAsync();
        }

        public async Task AtualizarAsync(Produto produto)
        {
            _context.Entry(produto).State = EntityState.Modified;
            await _context.SaveChangesAsync();
        }

        public async Task<Produto> BuscarPorId(int id)
        {
           return await _context.Produtos.FindAsync(id); 
        }

        public Task<List<Produto>> ListarAsync()
        {
            return _context.Produtos.ToListAsync();
        }

        public async Task RemoverAsync(int id)
        {
            var prod = await _context.Produtos.FindAsync(id);
            if (prod != null)
            {
                _context.Produtos.Remove(prod);
                await _context.SaveChangesAsync();
            }
        }
    }
}
