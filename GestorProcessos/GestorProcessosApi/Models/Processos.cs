﻿
using System.ComponentModel.DataAnnotations;


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

        





    }
}
