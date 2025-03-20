using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace ApiProcessos.Models
{
    public class Processo
    {
        [Key]
        public int Id { get; set; }

        [MaxLength(20)]
       
        public required string NumeroProcesso { get; set; }

        public required string Autor { get; set; }

        public required string Reu { get; set; }

        public required DateOnly DataCadastro { get; set; }

        public ICollection<Movimentacoes>? Movimentacoes { get; set; } = new List<Movimentacoes>();
    }


    public class Movimentacoes
    {
        [Key]
        public int Id { get; set; }

        public required string Descricao { get; set; }

        public required DateOnly DataMovimentacao { get; set; }

        [ForeignKey("Processo")]
        public  int ProcessoId { get; set; }

        [MaxLength(20)]
        public required string NumeroProcesso { get; set; }

        public required Processo Processo { get; set; }





    }
}


