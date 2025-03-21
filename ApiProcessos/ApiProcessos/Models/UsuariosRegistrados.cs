using Microsoft.EntityFrameworkCore.Storage.ValueConversion.Internal;
using System.ComponentModel.DataAnnotations;

namespace ApiProcessos.Models
{
    public class UsuariosRegistrados
    {
        [Required(ErrorMessage ="O campo {0} é obrigatório")]
        [EmailAddress(ErrorMessage ="O campo {0} está com formato errado")]
        public   string Email { get; set; }

        [Required(ErrorMessage = "O campo {0} é obrigatório")]
        [StringLength(100, ErrorMessage = "O campo {0} deve ter de {2} {1} caracteres", MinimumLength =8)]
        public  string Senha { get; set; }


        [Compare("Senha", ErrorMessage ="As senhas estão diferentes")]

        public string ConfirmeSenha { get; set; }

    }

 
}
