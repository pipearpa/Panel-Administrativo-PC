namespace PanelAdministrativoPeopleContact
{
    public class Persona
    {
        public int Id { get; set; }
        public string Usuario { get; set; } = string.Empty;
        public string Nombres { get; set; } = string.Empty;
        public string Apellido { get; set; } = string.Empty;
        public int Documento { get; set; }
        public string Genero { get; set; } = string.Empty;

    }
}
