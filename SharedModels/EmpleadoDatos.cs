using System.ComponentModel.DataAnnotations;

namespace SharedModels
{
    public class EmpleadoDatos
    {
        [Key]
        public int Empleado_Id { get; set; }
        public string? PrimerNombre { get; set; }
        public string? SegundoNombre { get; set; }
        public string? PrimerApellido { get; set; }
        public string? SegundoApellido { get; set; }
        public int NumeroCedula { get; set; }
        public DateTime FechaNacimiento { get; set; }
        public string Genero { get; set; }
        public string? EstadoCivil { get; set; }
        public string? Direccion { get; set; }
        public int Telefono { get; set; }
        public int Celular { get; set; }
        public decimal SalarioMensual { get; set; }
        public decimal? HorasExtras { get; set; }
        public string Estado {  get; set; }
        public int NumeroINSS {  get; set; }
        public int NumeroRuc {  get; set; }
        public DateTime Inicio_Contrato { get; set; }
        public DateTime Fin_Contrato { get; set; }
        public bool Registered { get; set; }
    }
}
