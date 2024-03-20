using System.ComponentModel.DataAnnotations;

namespace PanelAdministrativoPeopleContact
{
    public class Area
    {
        [Key]
        public int IdArea { get; set; }
        public string Nombre { get; set; } = string.Empty;
        public string Responsable { get; set; } = string.Empty;
        public string Descripcion { get; set;} = string.Empty;

    }
}

