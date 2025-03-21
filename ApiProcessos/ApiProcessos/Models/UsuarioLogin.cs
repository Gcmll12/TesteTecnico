using System.ComponentModel.DataAnnotations;

namespace ApiProcessos.Models
{
    public class UsuarioLogin
    {

        [Required(ErrorMessage = "O campo {0} é obrigatório")]
        [EmailAddress(ErrorMessage = "O campo {0} está com formato errado")]
        public required string Email { get; set; }


        [Required(ErrorMessage = "O campo {0} é obrigatório")]
        [StringLength(100, ErrorMessage = "O campo {0} deve ter de {2} {1} caracteres", MinimumLength = 8)]
        public required string Senha { get; set; }


    }
}
