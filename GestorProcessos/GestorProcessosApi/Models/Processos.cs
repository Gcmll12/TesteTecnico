using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GestorProcessosApi.Shared.Models
{
    public class Processos
    {

        [Key]
        public int Id { get; set; }

        public required string NumeroProcesso { get; set; }

        public required string Autor { get; set; }

        public required string Reu { get; set; }

        public required DateOnly DataCadastro { get; set; }

        public ICollection<Movimentacoes>? Movimentacoes { get; set; }




    }
}
