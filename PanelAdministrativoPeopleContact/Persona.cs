    using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace PanelAdministrativoPeopleContact
{
    public class Persona
    {
        [Key]
        public int IdPersona { get; set; }
        public string Usuario { get; set; } = string.Empty;
        public string Nombres { get; set; } = string.Empty;
        public string Apellido { get; set; } = string.Empty;
        public int Documento { get; set; }
        public string Genero { get; set; } = string.Empty;

        [ForeignKey("Rol")]
        public int IdRol { get; set; }
        public   Rol Rol { get; set; } = null!;

        [ForeignKey("Cargo")]
        public int IdCargo { get; set; }
        public Cargo Cargo { get; set; } = null!;

        [ForeignKey("Area")]
        public int IdArea { get; set; }
        public Area Area { get; set; } = null!;

        public ICollection<Objetivo> Objetivos { get; set; } = new List<Objetivo>();



    }
}
