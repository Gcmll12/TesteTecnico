using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion.Internal;
using System.ComponentModel.DataAnnotations;

namespace GestorProcessos.Models
{
    public class Processos
    {

        [Key]
        public int Id { get; set; }
        public  required int NumeroProcesso { get; set; }
        
        public required string Autor { get; set; }
       
        public required string Reu { get; set; }
        
        public DateOnly DataCadastro { get; set; }




    }
}
