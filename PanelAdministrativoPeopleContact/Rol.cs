using Microsoft.Extensions.Hosting;
using System.ComponentModel.DataAnnotations;
using System.Text.Json.Serialization;

namespace PanelAdministrativoPeopleContact
{
    public class Rol
    {
        [Key]
        public int IdRol { get; set; }
        public string NombreRol { get; set; } = string.Empty;
        public string Descripcion { get; set; } = string.Empty;

        [JsonIgnore]
        public ICollection<Persona> Personas { get; set; } = new List<Persona>();


    }
}
