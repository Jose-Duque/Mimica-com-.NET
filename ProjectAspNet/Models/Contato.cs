using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations; // Validador de dados

namespace ProjectAspNet.Models
{
    public class Contato
    {
        [Required(ErrorMessage = "O campo 'nome' é obrigatorio")] // Não permite que o campo fica vazio
        [MaxLength(50, ErrorMessage ="O campo 'Nome' deve conter no máximo 50 caracteres !" )] // Maximo de caracteres
        public string Name { get; set; }

        [Required(ErrorMessage = "O campo 'email' é obrigatorio")] // Não permite que o campo fica vazio
        [MaxLength(70, ErrorMessage = "O campo 'Email' deve conter no máximo 70 caracteres !")]
        [EmailAddress]
        public string Email { get; set; }

        [Required(ErrorMessage = "O campo 'assunto' é obrigatorio")]
        [MaxLength(70, ErrorMessage = "O campo 'Assunto' deve conter no máximo 70 caracteres !")]
        public string Assunto { get; set; }

        [Required(ErrorMessage = "O campo 'mensagem' é obrigatorio")]
        [MaxLength(2000, ErrorMessage = "O campo 'Mensagem' deve conter no máximo 20000 caracteres !")]
        public string Msg { get; set; }
    }
}
