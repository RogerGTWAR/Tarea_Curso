using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SharedModels
{
    public class Ingresos
    {
        [Key]
        public int Ingresos_Id { get; set; }
        public int Empleado_Id { get; set; }
        public string PrimerNombre { get; set; }
        public string PrimerApellido { get; set; }
        public decimal SalarioMensual { get; set; }
        public decimal Antiguedad { get; set; }
        public decimal? PagoHorasExtras { get; set; }
        public decimal? RiesgoLaboral { get; set; }
        public decimal? Nocturnidad { get; set; }
        public decimal? OtrosIngresos { get; set; }
        public decimal SalarioBruto { get; set; }
        public decimal Inss { get; set; }
        public decimal Ir { get; set; }
        public decimal? Otras_Deducciones { get; set; }
        public decimal? Adelanto_Salario { get; set; }
        public decimal SalarioNeto { get; set; }
        public DateTime Inicio_Periodo { get; set; }
        public DateTime Fin_Periodo { get; set; }

    }
}
