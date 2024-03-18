using Microsoft.EntityFrameworkCore;

namespace PanelAdministrativoPeopleContact.Data
{
    public class DataContext : DbContext
    {

        public DataContext(DbContextOptions<DataContext> options) : base(options)
        {

        }
        public DbSet<Persona> Personas { get; set; }
    }
}
