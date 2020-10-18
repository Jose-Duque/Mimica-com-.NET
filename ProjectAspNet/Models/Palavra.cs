using ProjectAspNet.Library.Validation;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace ProjectAspNet.Models
{
    public class Palavra
    {
        public int Id { get; set; }


        [Required(ErrorMessage = "O campo 'nome' é obrigatorio")] // Não permite que o campo fica vazio
        [MaxLength(50, ErrorMessage = "O campo 'Nome' deve conter no máximo 50 caracteres !")] // Maximo de caracteres
        [UnicoNome]
        public string Name { get; set; }

        //1- Facil 2-Medio 3-Dificil
        public byte? Nivel { get; set; }
    }
}
