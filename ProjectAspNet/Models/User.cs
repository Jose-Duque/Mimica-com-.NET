using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace ProjectAspNet.Models
{
    public class User
    {
        [Required(ErrorMessage = "O campo 'E-mail' é obrigatorio")] // Não permite que o campo fica vazio
        [EmailAddress]
        public string Email { get; set; }
        
        [Required(ErrorMessage = "O campo 'Senha' é obrigatorio")] // Não permite que o campo fica vazio
        public string Password { get; set; }
    }
}
