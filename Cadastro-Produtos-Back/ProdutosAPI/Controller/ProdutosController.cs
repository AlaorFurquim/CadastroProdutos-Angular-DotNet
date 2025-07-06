using Microsoft.AspNetCore.Mvc;
using ProdutosAPI.Application.Dto;
using ProdutosAPI.Application.Interfaces;

[Route("api/[controller]")]
[ApiController]
public class ProdutosController : ControllerBase
{
    private readonly IProdutoService _service;
    public ProdutosController(IProdutoService service)
    {
        _service = service;
    }

    [HttpGet]
    public async Task<List<ProdutoDto>> ListarAsync()
    {
        try {
            var produtos = await _service.ListarAsync();

            return produtos.Select(p => new ProdutoDto
            {
                Id = p.Id,
                Nome = p.Nome,
                Preco = p.Preco
            }).ToList();
        }
        catch (Exception ex)
        {
            {  throw ex; }
        } 
    }
    [HttpGet("{id}")]

    public async Task<ProdutoDto> BuscarPorId(int id)
    {
        var produto = await _service.BuscarPorIdAsync(id);

        if (produto == null) return null;

        return new ProdutoDto
        {
            Id = produto.Id,
            Nome = produto.Nome,
            Preco = produto.Preco
        };
    }

    [HttpPost]
    public async Task<IActionResult> Post([FromBody] ProdutoDto dto)
    {
        await _service.AdicionarAsync(dto);
        return Ok();
    }

    [HttpPut("{id}")]
    public async Task<IActionResult> Put(int id, [FromBody] ProdutoDto dto)
    {
        if (id != dto.Id) return BadRequest();
        await _service.AtualizarAsync(dto);
        return NoContent();
    }

    [HttpDelete("{id}")]
    public async Task<IActionResult> Delete(int id)
    {
        await _service.RemoverAsync(id);
        return NoContent();
    }
}
