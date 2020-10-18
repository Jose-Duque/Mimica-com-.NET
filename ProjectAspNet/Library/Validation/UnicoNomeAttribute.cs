using ProjectAspNet.Database;
using ProjectAspNet.Models;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Linq.Expressions;
using System.Threading.Tasks;

namespace ProjectAspNet.Library.Validation
{
    public class UnicoNomeAttribute : ValidationAttribute
    {
        protected override ValidationResult IsValid(object value, ValidationContext validationContext)
        {
            Palavra palavra = validationContext.ObjectInstance as Palavra;
            var _db = (DatabaseContext)validationContext.GetService(typeof(DatabaseContext));

            // Verificar se já existe no banco de dados 1 registro que tenha oo mesmo nome
            // Verifica se o ID é o mesmo
            var palavraBanco = _db.Palavras.Where(a => a.Name == palavra.Name && a.Id != palavra.Id).FirstOrDefault();

            if (palavraBanco == null )
            {
                return ValidationResult.Success;
            }
            else
            {
                return new ValidationResult("A palavra '" + palavra.Name + "' já utilizada");
            }
        }

    }
}
