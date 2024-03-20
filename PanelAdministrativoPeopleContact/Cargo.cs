using System.ComponentModel.DataAnnotations;

namespace PanelAdministrativoPeopleContact
{
    public class Cargo
    {
        [Key]
        public int IdCargo { get; set; }
        public string Nombre { get; set; } = string.Empty;
        public string Descripcion { get; set; } = string.Empty;
        public string Estado { get; set; } = string.Empty;
    }
}
