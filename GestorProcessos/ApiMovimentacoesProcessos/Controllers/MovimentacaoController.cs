using ApiMovimentacoesProcessos.Data;

using GestorProcessosApi.Shared.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace ApiMovimentacoesProcessos.Controllers
{


    [ApiController]
    [Route("api/[controller]")]
    public class MovimentacaoController : ControllerBase
    {

        private readonly ApiMovimentacoesDbContext _context;

        public MovimentacaoController(ApiMovimentacoesDbContext context)

        {

            _context = context;

        }



        //Listar Todas Movimentações Processo

        [HttpGet]

        public async Task<ActionResult<IEnumerable<Movimentacoes>>> GetMovimentacoes(string NumeroProcesso)
        
        
        {
            if (_context.Movimentacoes == null)
            {
                return NotFound();
            }

            var movimentacao = await _context.Movimentacoes.AsNoTracking().Where(m => m.NumeroProcesso == NumeroProcesso).ToListAsync();

            if (movimentacao == null)
            {
                return NotFound();

            
            }
            return Ok (movimentacao);

        }




        //Adicionar Movimentação Processo
        [HttpPost]

        public async Task<ActionResult<Movimentacoes>> PostMovimentacoes(Movimentacoes movimentacoes)
        {
            if (_context.Movimentacoes == null)
            {
                return NotFound();


            }

            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);


            }

            _context.Movimentacoes.Add(movimentacoes);
            await _context.SaveChangesAsync();
            return NoContent();

        }



    }
}
