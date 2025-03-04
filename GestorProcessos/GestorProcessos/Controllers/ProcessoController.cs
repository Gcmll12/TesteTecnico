
using Microsoft.AspNetCore.Mvc;
using GestorProcessos.Data;
using Microsoft.EntityFrameworkCore;

using GestorProcessosApi.Shared.Models;

namespace GestorProcessos.Controllers
{
    [ApiController]
    [Route("(api/[controller])")]
    public class ProcessoController : ControllerBase

    { private readonly ApiProcessoDbContext _context;

        public ProcessoController(ApiProcessoDbContext context)
        {
            _context = context;

        }



        //Listar Todos Processos
        [HttpGet]
        public async Task<ActionResult<IEnumerable<Processos>>> GetProcessos()
        {
            if (_context.Processos == null)
            {
                return NotFound();
            }

            return await _context.Processos.AsNoTracking().ToListAsync();
        }

        //Retornar Processo por Numero
        [HttpGet("{NumeroProcesso}")]

        public async Task<ActionResult<Processos>> GetProcesso(string NumeroProcesso)
        {
            if (_context.Processos == null)
            {
                return NotFound();
            }
            var processo = await _context.Processos.AsNoTracking().FirstOrDefaultAsync(p => p.NumeroProcesso == NumeroProcesso);

            if (processo == null)
            {
                return NotFound();
            }
            return processo;
        }

        //Adicionar Novo Processo
        [HttpPost]
        public async Task<ActionResult<Processos>> PostProcesso(Processos processo)

        {
            if (_context.Processos == null)
            {
                return Problem("Erro ao criar processo, contate o suporte");
            
            }
            
            if (!ModelState.IsValid) 
            {
                return BadRequest(ModelState);
            
            
            }
            _context.Processos.Add(processo);
            await _context.SaveChangesAsync();

            return CreatedAtAction(nameof(GetProcesso), new { numeroprocesso = processo.NumeroProcesso }, processo);
        
        }

        //Alterar Informações Processo
        [HttpPut("{NumeroProcesso}")]

        public async Task<ActionResult<Processos>> PutProcesso(string NumeroProcesso, Processos processo)
        {
            if (NumeroProcesso != processo.NumeroProcesso) return BadRequest();

            if (!ModelState.IsValid) return ValidationProblem(ModelState);

            var processoExistente = await _context.Processos.FirstOrDefaultAsync(p => p.NumeroProcesso == NumeroProcesso);

            if (processoExistente == null)
            {
                return NotFound();
            
            
            }
            processoExistente.Autor = processo.Autor;
            processoExistente.Reu = processo.Reu;
            processoExistente.DataCadastro = processo.DataCadastro;

            _context.Processos.Update(processoExistente);
            await _context.SaveChangesAsync();

            return NoContent();
        
        
        }

        //Deletar Processo

        [HttpDelete("{NumeroProcesso}")]

        public async Task<ActionResult> DeleteProcesso(string NumeroProcesso)
        {
            var processo = await _context.Processos.FirstOrDefaultAsync (p => p.NumeroProcesso == NumeroProcesso);

            if (processo == null)
            {
                return NotFound(); 
            }

            _context.Processos.Remove(processo);
            await _context.SaveChangesAsync();

            return NoContent();


        }
    }


    }
           
    
        

    
    
            
    
    
    
    
        


    

