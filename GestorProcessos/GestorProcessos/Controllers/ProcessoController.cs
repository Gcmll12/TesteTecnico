using GestorProcessos.Models;
using Microsoft.AspNetCore.Mvc;
using GestorProcessos.Data;
using Microsoft.EntityFrameworkCore;
using System.Reflection.Metadata.Ecma335;

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

            return await _context.Processos.ToListAsync();
        }

        //Retornar Processo por Numero
        [HttpGet("{NumeroProcesso}")]

        public async Task<ActionResult<Processos>> GetProcesso(int NumeroProcesso)
        {
            var processo = await _context.Processos.FindAsync(NumeroProcesso);

            return processo;
        }

        //Adicionar Novo Processo
        [HttpPost]
        public async Task<ActionResult<Processos>> PostProcesso(Processos processo)
        {
            _context.Processos.Add(processo);
            await _context.SaveChangesAsync();

            return CreatedAtAction(nameof(GetProcesso), new { numeroprocesso = processo.NumeroProcesso }, processo);
        
        }

        //Alterar Informações Processo
        [HttpPut("{NumeroProcesso}")]

        public async Task<ActionResult<Processos>> PutProcesso(int NumeroProcesso, Processos processo)
        {
            _context.Processos.Update(processo);
            await _context.SaveChangesAsync();

            return NoContent();
        
        
        }

        //Deletar Processo

        [HttpDelete("{NumeroProcesso}")]

        public async Task<ActionResult> DeleteProcesso(int NumeroProcesso)
        {
            var processo = await _context.Processos.FindAsync(NumeroProcesso);

            _context.Processos.Remove(processo);
            await _context.SaveChangesAsync();

            return NoContent();


        }
    }


    }
           
    
        

    
    
            
    
    
    
    
        


    

