using Microsoft.EntityFrameworkCore;
using System.Reflection.Emit;

namespace PanelAdministrativoPeopleContact.Data
{
    public class DataContext : DbContext
    {

        public DataContext(DbContextOptions<DataContext> options) : base(options)
        {
           

        }
   

        public DbSet<Persona> Personas { get; set; }
        public DbSet<Rol> Roles { get; set; }
        public DbSet<Cargo> Cargos { get; set; }
        public DbSet<Area> Areas { get; set; }
        public DbSet<Objetivo> Objetivos { get; set; }
    }
}
