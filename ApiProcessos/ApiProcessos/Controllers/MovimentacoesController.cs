using ApiProcessos.Data;
using ApiProcessos.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using ApiProcessos.DTOs;

namespace ApiProcessos.Controllers
{

    [ApiController]
    [Route("apiMovimentacoes/[controller]")]
    public class MovimentacoesController: ControllerBase
    {
        private readonly ApiProcessosDbContext _context;

        public MovimentacoesController(ApiProcessosDbContext context)

        {
            _context = context;
            
        }


        //Listar Todas Movimentações Processo

        [HttpGet]

        [ProducesResponseType(typeof(Movimentacoes), 200)]
        [ProducesResponseType(404)]
        public async Task<ActionResult<IEnumerable<Movimentacoes>>> GetMovimentacoes(string NumeroProcesso)
        {

            if (_context.Movimentacoes == null) return NotFound();

            var movimentacao = await _context.Movimentacoes.AsNoTracking().Where(m => m.NumeroProcesso == NumeroProcesso)
                .Select(m => new
                {
                    m.NumeroProcesso,
                    m.Descricao,
                    m.DataMovimentacao


                }).ToListAsync();
               

            if (!movimentacao.Any()) return NotFound("Não há movimentações no processo, ou o número está incorreto");


            return Ok(movimentacao);
        
        
        }

        //Adicionar Movimentação ao Processo

        [HttpPost]

        [ProducesResponseType(typeof(Movimentacoes), 201)]
        [ProducesResponseType(204)]
        public async Task<ActionResult<Movimentacoes>> PostMovimentacoes(MovimentacoesDto movimentacoesDto)
        {
            if (_context.Movimentacoes == null) return NotFound();
            var processo = await _context.Processo
         .FirstOrDefaultAsync(p => p.NumeroProcesso == movimentacoesDto.NumeroProcesso);

            var movimentacao = new Movimentacoes
            {
                NumeroProcesso = movimentacoesDto.NumeroProcesso,
                DataMovimentacao = movimentacoesDto.DataMovimentacao,
                Descricao = movimentacoesDto.Descricao,
                Processo = processo
            };


            _context.Movimentacoes.Add(movimentacao);
            await _context.SaveChangesAsync();


            return NoContent();
        }
    }
}
