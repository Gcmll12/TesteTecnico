using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GestorProcessosApi.Shared.Models
{
    public class Movimentacoes
    {
        [Key]
        public int Id { get; set; }

        public required string Descricao { get; set; }

        public required DateOnly DataMovimentacao { get; set; }

        [ForeignKey("Processos")]
        public required string NumeroProcesso{ get; set; }


       // public Processos? Processo { get; set; }


    }
}
