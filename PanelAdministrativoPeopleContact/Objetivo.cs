using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text.Json.Serialization;

namespace PanelAdministrativoPeopleContact
{
    public class Objetivo
    {

        [Key]
        public int IdObjetivo { get; set; } 
        public string Observacion { get; set; } = string.Empty;
        public string Detalle { get; set; } = string.Empty;
        public string Estado { get; set; } = string.Empty;

        [ForeignKey("Perosna")]
       
        public int IdPersona { get; set; }
        [JsonIgnore]
        public Persona Persona { get; set; } = null!;

       









    }
}
