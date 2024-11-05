using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SharedModels.Dto.EmpleadosDatos
{
    public class EmpleadosCreateDto
    {
        [StringLength(50)]
        public string? PrimerNombre { get; set; }

        [StringLength(50)]
        public string? SegundoNombre { get; set; }

        [StringLength(50)]
        public string? PrimerApellido { get; set; }

        [StringLength(50)]
        public string? SegundoApellido { get; set; }

        [Required]
        public int NumeroCedula { get; set; }

        [Required]
        public DateTime FechaNacimiento { get; set; }

        [Required]
        [StringLength(10)]
        public string Genero { get; set; }

        [StringLength(50)]
        public string? EstadoCivil { get; set; }

        [StringLength(100)]
        public string? Direccion { get; set; }

        [Required]
        public int Telefono { get; set; }

        [Required]
        public int Celular { get; set; }
        [Range(0, double.MaxValue, ErrorMessage = "Salario debe ser un valor positivo.")]
        public decimal SalarioMensual { get; set; }
        [Range(0, double.MaxValue, ErrorMessage = "Las horas extras debe ser un valor positivo")]
        public decimal? HorasExtras { get; set; }
        [Required]
        public string Estado { get; set; }
        public DateTime Inicio_Contrato { get; set; }
        public DateTime Fin_Contrato { get; set; }
        public int NumeroINSS { get; set; }
        public int NumeroRuc { get; set; }
        public bool Registered { get; set; }

    }
}
