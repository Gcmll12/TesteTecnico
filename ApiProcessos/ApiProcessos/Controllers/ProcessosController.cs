using Microsoft.AspNetCore.Mvc;
using ApiProcessos.Models;
using ApiProcessos.Data;
using Microsoft.EntityFrameworkCore;
using ApiProcessos.DTOs;

namespace ApiProcessos.Controllers
{
    [ApiController]
    [Route("apiProcessos/[controller]")]
    public class ProcessosController : ControllerBase
    {
        private readonly ApiProcessosDbContext _context;

        public ProcessosController(ApiProcessosDbContext context)
        {
            _context = context;


        }

        //Listar Todos Processos

        [HttpGet]

        [ProducesResponseType(typeof(Processo),200)]
        [ProducesResponseType(404)]
        public async Task<ActionResult<IEnumerable<Processo>>> GetProcessos()
        {
            if (_context.Processo == null) return NotFound();

            var processos = await _context.Processo
       .AsNoTracking()
       .Select(p => new
       {
           p.Id,
           p.NumeroProcesso,
           p.Autor,
           p.Reu,
           p.DataCadastro
       })
       .ToListAsync();

            return Ok(processos);




        }


        //Listar Processos por Numero de Processo

        [HttpGet("{NumeroProcesso}")]

        [ProducesResponseType(typeof(Processo), 200)]
        [ProducesResponseType(404)]
        public async Task<ActionResult<Processo>> GetProcesso(string NumeroProcesso)
        {
            if (_context.Processo == null) return NotFound();

            var processo = await _context.Processo.AsNoTracking().Where(p=> p.NumeroProcesso == NumeroProcesso)
                .Select(p => new
                {
                    p.Autor,
                    p.Reu,
                    p.NumeroProcesso,
                    p.DataCadastro

                }).FirstOrDefaultAsync();




            if (processo == null) return NotFound("Processo inexistente, ou número não encontrado");




            return Ok(processo);



        }

        //Adicionar Novo Processo
        [HttpPost]

        [ProducesResponseType(typeof(Processo), 201)]
        [ProducesResponseType(400)]
        [ProducesResponseType(409)]

        public async Task<ActionResult<Processo>> PostProcesso(ProcessosDto processoDto)
        {
            if (_context.Processo == null) return Problem("Erro ao criar processo, contate o suporte");

            var processoExistente = await _context.Processo
      .FirstOrDefaultAsync(p => p.NumeroProcesso == processoDto.NumeroProcesso);

            if (processoExistente != null)
            {
                return Conflict("Processo com esse número já existe.");
            }

            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);

            }

            var processo = new Processo
            {
                NumeroProcesso = processoDto.NumeroProcesso,
                Autor = processoDto.Autor,
                Reu = processoDto.Reu,
                DataCadastro = processoDto.DataCadastro



            };


            _context.Processo.Add(processo);
            await _context.SaveChangesAsync();

            return CreatedAtAction(nameof(GetProcesso), new {numeroprocesso = processo.NumeroProcesso},processo);


        }


        //Alterar Informações Processo
        [HttpPut("{NumeroProcesso}")]

        [ProducesResponseType(204)]
        [ProducesResponseType(400)]
        [ProducesResponseType(404)]
        public async Task<ActionResult<Processo>> PutProcesso(string NumeroProcesso, ProcessosDto processoDto)
        {
            if (NumeroProcesso != processoDto.NumeroProcesso) return BadRequest();
            if (!ModelState.IsValid) return ValidationProblem(ModelState);
            var processoExistente = await _context.Processo.FirstOrDefaultAsync(p => p.NumeroProcesso == NumeroProcesso);

            if (processoExistente == null) return NotFound("Processo não encontrado.");

            // Atualiza apenas os campos necessários
            processoExistente.Autor = processoDto.Autor;
            processoExistente.Reu = processoDto.Reu;
            processoExistente.DataCadastro = processoDto.DataCadastro;

            _context.Processo.Update(processoExistente);
            await _context.SaveChangesAsync();




            return NoContent();


        }

        //Deletar Processo

        [HttpDelete("{NumeroProcesso}")]

        [ProducesResponseType(204)]
        [ProducesResponseType(404)]

        public async Task<ActionResult> DeleteProcesso(string NumeroProcesso)

        {
            var processo = await _context.Processo
                .Include(p=> p.Movimentacoes)
                .FirstOrDefaultAsync(p => p.NumeroProcesso == NumeroProcesso);

            if (processo == null) return NotFound("Processo não encontrado");

            _context.Movimentacoes.RemoveRange(processo.Movimentacoes);

            _context.Processo.Remove(processo);

            await _context.SaveChangesAsync();

            return NoContent();





        }
    }

}
