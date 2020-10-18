using Microsoft.EntityFrameworkCore;
using ProjectAspNet.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ProjectAspNet.Database
{
    public class DatabaseContext : DbContext
    {
        public DbSet<Palavra> Palavras { get; set; } //Criar tabela

        public DatabaseContext(DbContextOptions<DatabaseContext> options) : base(options)  
        {
            // EF - Garantir que o banco seja criado pelo EF
            Database.EnsureCreated();
        }
    }
}
