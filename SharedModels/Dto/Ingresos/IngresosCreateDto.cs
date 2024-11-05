using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SharedModels.Dto.Ingresos
{
    public class IngresosCreateDto
    {
        //[Required]
        public int Empleado_Id { get; set; }
        public string? PrimerNombre { get; set; }
        public string? PrimerApellido { get; set; }
        [Range(0, double.MaxValue, ErrorMessage = "El salario mensual debe ser un valor positivo")]
        public decimal SalarioMensual { get; set; }
        public decimal Antiguedad { get; set; }
        [Range(0, double.MaxValue, ErrorMessage = "Las horas extras debe ser un valor positivo")]
        public decimal? PagoHorasExtras { get; set; }
        [Range(0, double.MaxValue, ErrorMessage = "El riesgo laboral debe ser un valor positivo")]
        public decimal? RiesgoLaboral { get; set; }
        [Range(0, double.MaxValue, ErrorMessage = "La nocturnidad debe ser un valor positivo")]
        public decimal? Nocturnidad { get; set; }
        [Range(0, double.MaxValue, ErrorMessage = "Los otros ingresos debe ser un valor positivo")]
        public decimal? OtrosIngresos { get; set; }
        [Range(0, double.MaxValue, ErrorMessage = "El salario bruto debe ser un valor positivo")]
        public decimal SalarioBruto { get; set; }
        [Range(0, double.MaxValue, ErrorMessage = "El INSS debe ser un valor positivo")]
        public decimal Inss { get; set; }
        [Range(0, double.MaxValue, ErrorMessage = "El impuesto sobre la renta debe ser un valor positivo")]
        public decimal Ir { get; set; }
        [Range(0, double.MaxValue, ErrorMessage = "Las otras deducciones debe ser un valor positivo")]
        public decimal? Otras_Deducciones { get; set; }
        [Range(0, double.MaxValue, ErrorMessage = "El adelanto de salario debe ser un valor positivo")]
        public decimal? Adelanto_Salario { get; set; }
        [Range(0, double.MaxValue, ErrorMessage = "El salario neto debe ser un valor positivo")]
        public decimal SalarioNeto { get; set; }
        public DateTime Inicio_Periodo { get; set; }
        public DateTime Fin_Periodo { get; set; }

    }
}
