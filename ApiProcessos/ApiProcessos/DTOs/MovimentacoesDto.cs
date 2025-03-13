namespace ApiProcessos.DTOs
{
    public class MovimentacoesDto
    {
        public string NumeroProcesso { get; set; }
        public DateOnly DataMovimentacao { get; set; }
        public string Descricao { get; set; }
    }
}
