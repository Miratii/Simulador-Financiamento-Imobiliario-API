using Microsoft.AspNetCore.Mvc;
using ProjetoFinanciamentoImobiliario.Data;
using ProjetoFinanciamentoImobiliario.Models;

namespace ProjetoFinanciamentoImobiliario.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class ImoveisController : ControllerBase
    {
        private readonly AppDbContext _appDbContext;

        public ImoveisController(AppDbContext appDbContext)
        {
            _appDbContext = appDbContext;
        }

       
        [HttpGet]
        public IActionResult GetAll()
        {
            var imoveis = _appDbContext.Imoveis.ToList();
            return Ok(imoveis);
        }

        
        [HttpPost]
public IActionResult Create([FromBody] Imovel imovel)
{
    if (imovel == null)
        return BadRequest("Dados inválidos");

    if (string.IsNullOrWhiteSpace(imovel.Nome))
        return BadRequest("O nome do imóvel é obrigatório");

    try
    {
        _appDbContext.Imoveis.Add(imovel);
        _appDbContext.SaveChanges();

        return CreatedAtAction(nameof(GetAll), new { id = imovel.Id }, imovel);
    }
    catch (Exception ex)
    {
        return BadRequest($"Erro ao salvar: {ex.Message}");
    }
}
    }
}