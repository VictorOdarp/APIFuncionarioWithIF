using APIFuncionariosIF.Models;
using Microsoft.EntityFrameworkCore;

namespace APIFuncionariosIF.DataContext
{
    public class APIFuncionariosIFContext : DbContext
    {
        public APIFuncionariosIFContext(DbContextOptions<APIFuncionariosIFContext> options) : base(options)
        {
            
        }

        public DbSet<FuncionarioModel> Funcionario { get; set; }
        
    }
}
