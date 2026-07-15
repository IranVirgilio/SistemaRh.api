using Microsoft.EntityFrameworkCore;
using SistemaRh.api.Models;

namespace SistemaRh.api.Data
{
    public class AppDbContext : DbContext
        {
        // construtor para realizar conxão com o banco
        public AppDbContext (DbContextOptions <AppDbContext> options) : base(options)
        {
        }

        //Transformando as Classes em Tabelas de Banco de Dados
         public DbSet <Funcionario> Funcionario { get; set; }
         public DbSet <Cargo> Cargo { get; set; }
         public DbSet <Ferias> Ferias { get; set; }
         public DbSet <HistoricoAlteracao> HistoricoAlteracao { get; set; }


     }  
}
