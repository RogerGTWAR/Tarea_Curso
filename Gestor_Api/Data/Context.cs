using Microsoft.EntityFrameworkCore;
using SharedModels;

namespace Gestor_Api.Data
{
    public class Context : DbContext
    {
        public Context(DbContextOptions<Context> options) :
             base(options)
        {

        }
        public DbSet<User> Users { get; set; }
        public DbSet<EmpleadoDatos> EmpleadosDatos { get; set; }
        public DbSet<Ingresos> EmpleadosIngresos { get; set; }

    }
}
