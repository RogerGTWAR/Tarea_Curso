using OfficeOpenXml;
using SharedModels;
using SharedModels.Dto.EmpleadosDatos;
using SharedModels.Dto.Ingresos;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Diagnostics;
using System.Drawing;
using System.Linq;
using System.Net.Http;
using System.Runtime.CompilerServices;
using System.Security.Cryptography;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Xml.Linq;
using Tarea;
using static System.Windows.Forms.VisualStyles.VisualStyleElement;
using static System.Windows.Forms.VisualStyles.VisualStyleElement.Button;

namespace WindowsForm
{
    public partial class IngresosyDeduccionesForm : Form
    {
        private readonly ApiClient _apiClient;
        private decimal _salarioMensual;
        private decimal _antiguedad;
        private decimal? _pagoHorasExtras;
        private decimal? _horasExtras;
        private decimal _salarioBruto;
        private decimal _INSS;
        private decimal _IR;
        private decimal? _OtrasDededucciones;
        private decimal? _AdelantoSalario;
        private decimal? _RiesgoLaboral;
        private decimal? _Nocturnidad;
        private decimal? _OtrosIngresos;
        private decimal _SalarioNeto;
        private int selectedIngresosID = -1;
        private List<Ingresos> _ingresos;
        private readonly Repository<Ingresos> _ingresosRepository;
        private readonly Repository<EmpleadoDatos> _empleadosRepository;
        private readonly int id;

        public IngresosyDeduccionesForm(HttpClient _httpClient)
        {
            InitializeComponent();
            _apiClient = new ApiClient();
            _empleadosRepository = new Repository<EmpleadoDatos>(_httpClient, "Empleados");
            _ingresosRepository = new Repository<Ingresos>(_httpClient, "Ingresos");
            RefreshData();
        }
        private async void RefreshData()
        {
            try
            {
                var ingresos = await _ingresosRepository.GetAllAsync();
                _ingresos = ingresos.ToList();

                dgvIngresos.DataSource = _ingresos.Select(d => new
                {
                    Id = d.Ingresos_Id,
                    EmpleadoId = d.Empleado_Id,
                    d.SalarioMensual,
                    d.PrimerNombre,
                    d.PrimerApellido,
                    d.Antiguedad,
                    d.PagoHorasExtras,
                    d.RiesgoLaboral,
                    d.Nocturnidad,
                    d.OtrosIngresos,
                    d.SalarioBruto,
                    d.Inss,
                    d.Ir,
                    d.Otras_Deducciones,
                    d.Adelanto_Salario,
                    d.SalarioNeto,
                    InicioPeriodo = d.Inicio_Periodo,
                    FinPeriodo = d.Fin_Periodo,
                }).ToList();
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Error cargando deducciones: {ex.Message}", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
        private async void CbEmpleados_Id_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (int.TryParse(CbEmpleados_Id.SelectedItem?.ToString(), out int employeeNumber))
            {
                var employee = await GetEmployeeByIdAsync(employeeNumber);
                if (employee != null)
                {
                    MostrarDetallesEmpleado(employee);
                }
                else
                {
                    LimpiarDetalleEmpleados();
                }
            }
            else
            {
                LimpiarDetalleEmpleados();
            }
        }
        private async Task<EmpleadoDatos> GetEmployeeByIdAsync(int employeeNumber)
        {
            try
            {
                return await _empleadosRepository.GetByIdAsync(employeeNumber);
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Error al obtener el empleado: {ex.Message}", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return null;
            }
        }
        private void LimpiarDetalleEmpleados()
        {
            TxtNombre.Clear();
            TxtApellido.Clear();
            TxtSalarioMensual.Clear();
            TxtNombre.Clear();
            TxtApellido.Clear();
            TxtAntiguedad.Clear();
            TxtHorasExtras.Clear();
            TxtOtrosIngresos.Clear();
            TxtSalarioBruto.Clear();
            TxtINSS.Clear();
            TxtIR.Clear();
            TxtOtrasDeducciones.Clear();
            TxtAnticipoSalarial.Clear();
            TxtNoctabilidad.Clear();
            TxtRiesgoLaboral.Clear();
            _salarioMensual = 0;
            _antiguedad = 0;
            _pagoHorasExtras = 0;
            _horasExtras = 0;
            _OtrosIngresos = 0;
            _salarioBruto = 0;
            _INSS = 0;
            _IR = 0;
            _OtrasDededucciones = 0;
            _AdelantoSalario = 0;
            _RiesgoLaboral = 0;
            _Nocturnidad = 0;
            dtpInicio.Value = DateTime.Now;
            dtpFin.Value = DateTime.Now;
        }
        private async void MostrarDetallesEmpleado(EmpleadoDatos employee)
        {
            TxtNombre.Text = employee.PrimerNombre;
            TxtApellido.Text = employee.PrimerApellido;
            TxtSalarioMensual.Text = employee.SalarioMensual.ToString("F2");
            TxtHorasExtras.Text = (employee.HorasExtras ?? 0).ToString("F2");

            //Calculos para el salario bruto
            _salarioMensual = employee.SalarioMensual;
            _horasExtras = employee.HorasExtras;
            _antiguedad = CalcularAntiguedad(employee.Inicio_Contrato, employee.Fin_Contrato);
            TxtAntiguedad.Text = _antiguedad.ToString("F2");
            _pagoHorasExtras = CalcularHorasExtras(_horasExtras);
            _salarioBruto = CalcularSalarioBruto();
            TxtSalarioBruto.Text = _salarioBruto.ToString("F2");
            TxtPagoHorasExtras.Text = _pagoHorasExtras?.ToString("F2") ?? "0.00";

            //Calculo INSS
            _INSS = _salarioBruto * 0.07M;
            TxtINSS.Text = _INSS.ToString("F2");

            //Calculo IR
            _IR = CalculoIR(_salarioBruto);
            TxtIR.Text = _IR.ToString("F2");

            //SalarioNeto
            _SalarioNeto = CalculoSalarioNeto(_SalarioNeto);
            TxtSalarioNeto.Text = _SalarioNeto.ToString("F2");
        }
        private decimal CalculoSalarioNeto(decimal salarioNeto)
        {
            salarioNeto = _salarioBruto - (_INSS + _IR + (_OtrasDededucciones ?? 0) + (_AdelantoSalario ?? 0));
            return salarioNeto;
        }
        private decimal? CalcularRiesgoLaborar(decimal salarioMensual)
        {
            if (salarioMensual != 0)
            {
                return salarioMensual * 0.20M;
            }
            else
            {
                return null;
            }
        }
        private decimal? CalcularNocturnidad(decimal salarioMensual)
        {
            if (salarioMensual != 0)
            {
                return salarioMensual * 0.20M;
            }
            else
            {
                return null;
            }
        }
        private decimal CalculoIR(decimal salarioBruto)
        {
            decimal salarioBrutoAnual = salarioBruto * 12M;
            decimal inss = CalcularINSS(salarioBruto);
            decimal salarioGravable = salarioBrutoAnual - inss;
            decimal ir = 0M;

            // Calcular IR
            if (salarioGravable <= 100000M)
            {
                ir = 0M;
            }
            else if (salarioGravable <= 200000M)
            {
                ir = ((salarioGravable - 100000M) * 0.15M) + 0M;
            }
            else if (salarioGravable <= 350000M)
            {
                ir = ((salarioGravable - 200000M) * 0.20M) + 15000M;
            }
            else if (salarioGravable <= 500000M)
            {
                ir = ((salarioGravable - 350000M) * 0.25M) + 45000M;
            }
            else
            {
                ir = ((salarioGravable - 500000M) * 0.30M) + 82500M;
            }

            return ir / 12M;
        }
        private decimal CalcularINSS(decimal salarioBruto)
        {
            decimal salarioBrutoAnual = salarioBruto * 12M;
            decimal inss = salarioBrutoAnual * 0.07M;
            return inss;
        }
        private decimal CalcularSalarioBruto()
        {
            decimal salarioBruto = _salarioMensual + (_pagoHorasExtras ?? 0) + _antiguedad + (_Nocturnidad ?? 0) + (_RiesgoLaboral ?? 0) + (_OtrosIngresos ?? 0);
            return salarioBruto;
        }
        private decimal CalcularAntiguedad(DateTime inicio_Contrato, DateTime fin_Contrato)
        {
            int yearsOfService = fin_Contrato.Year - inicio_Contrato.Year;
            if (fin_Contrato < inicio_Contrato.AddYears(yearsOfService))
            {
                yearsOfService--;
            }
            decimal porcentajeAntiguedad = 0.05m;
            return _salarioMensual * yearsOfService * porcentajeAntiguedad;
        }
        private decimal? CalcularHorasExtras(decimal? horasExtras)
        {
            if (horasExtras.HasValue)
            {
                decimal pagoPorHora = _salarioMensual / 240;
                return horasExtras * pagoPorHora * 2;
            }
            else
            {
                return null;
            }
        }
        private async void IngresosForm_Load(object sender, EventArgs e)
        {
            await CargarEmpleado_IdAsync();
        }
        private async Task CargarEmpleado_IdAsync()
        {
            try
            {
                var employees = await _apiClient.Empleados.GetAllAsync();
                var employeeNumbers = employees.Select(emp => emp.Empleado_Id).ToList();
                CbEmpleados_Id.DataSource = employeeNumbers;
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Error loading employee numbers: {ex.Message}");
            }
        }
        private async void btnAgregar_Click(object sender, EventArgs e)
        {
            try
            {
                if (!rdSi.Checked && !rdNo.Checked)
                {
                    MessageBox.Show("Seleccione si existe o no el Riesgo Laboral.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    return;
                }

                if (!rbSi.Checked && !rbNo.Checked)
                {
                    MessageBox.Show("Seleccione si existe o no la Nocturnidad.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    return;
                }

                if (rdSi.Checked)
                {
                    if (decimal.TryParse(TxtRiesgoLaboral.Text, out decimal riesgoLaboral))
                    {
                        _RiesgoLaboral = riesgoLaboral;
                    }
                    else
                    {
                        _RiesgoLaboral = 0.00M;
                        _RiesgoLaboral = riesgoLaboral;
                    }
                }
                else
                {
                    _RiesgoLaboral = 0.00M;
                }

                if (rbSi.Checked)
                {
                    if (decimal.TryParse(TxtNoctabilidad.Text, out decimal nocturnidad))
                    {
                        _Nocturnidad = nocturnidad;
                    }
                    else
                    {
                        _Nocturnidad = 0.00M;
                        _Nocturnidad = nocturnidad;
                    }
                }
                else
                {
                    _Nocturnidad = 0.00M;
                }

                if (decimal.TryParse(TxtOtrosIngresos.Text, out decimal otrosIngresos))
                {
                    _OtrosIngresos = otrosIngresos;
                }
                else
                {
                    _OtrosIngresos = 0.00M;
                    _OtrosIngresos = otrosIngresos;
                }

                if (decimal.TryParse(TxtAnticipoSalarial.Text, out decimal anticipoSalarial))
                {
                    _AdelantoSalario = anticipoSalarial;
                }
                else
                {
                    _AdelantoSalario = 0.00M;
                    _AdelantoSalario = anticipoSalarial;
                }

                if (decimal.TryParse(TxtOtrasDeducciones.Text, out decimal otrosDeducciones))
                {
                    _OtrasDededucciones = otrosDeducciones;
                }
                else
                {
                    _OtrasDededucciones = 0.00M;
                    _OtrasDededucciones = otrosDeducciones;
                }

                ActualizarSalarioBruto();
                var ingreso = new Ingresos
                {
                    Empleado_Id = int.Parse(CbEmpleados_Id.SelectedItem.ToString()),
                    PrimerNombre = TxtNombre.Text,
                    PrimerApellido = TxtApellido.Text,
                    SalarioMensual = _salarioMensual,
                    Inicio_Periodo = dtpInicio.Value,
                    Fin_Periodo = dtpFin.Value,
                    PagoHorasExtras = CalcularHorasExtras(_horasExtras),
                    Antiguedad = (int)_antiguedad,
                    RiesgoLaboral = _RiesgoLaboral,
                    Nocturnidad = _Nocturnidad,
                    OtrosIngresos = _OtrosIngresos,
                    SalarioBruto = CalcularSalarioBruto(),
                    Inss = _INSS,
                    Ir = _IR,
                    Otras_Deducciones = _OtrasDededucciones,
                    Adelanto_Salario = _AdelantoSalario,
                    SalarioNeto = _SalarioNeto,
                };

                if (selectedIngresosID == -1)
                {
                    await _ingresosRepository.CreateAsync(ingreso);
                    MessageBox.Show("Ingreso guardado exitosamente", "Éxito", MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
                else
                {
                    await _ingresosRepository.UpdateAsync(selectedIngresosID, ingreso);
                    MessageBox.Show("Ingreso actualizado exitosamente", "Éxito", MessageBoxButtons.OK, MessageBoxIcon.Information);
                }


                RefreshData();
                LimpiarDetalleEmpleados();
                selectedIngresosID = -1;
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Error al guardar el ingreso: {ex.Message}", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
        private async void btnEliminar_Click(object sender, EventArgs e)
        {
            if (dgvIngresos.SelectedRows.Count == 0)
            {
                MessageBox.Show("Por favor seleccione un ingreso para eliminar.", "Eliminar Ingreso", MessageBoxButtons.OK, MessageBoxIcon.Information);
                return;
            }

            DialogResult result = MessageBox.Show("¿Está seguro de que desea eliminar este ingreso?", "Confirmar Eliminación", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
            if (result == DialogResult.Yes)
            {
                try
                {
                    DataGridViewRow selectedRow = dgvIngresos.SelectedRows[0];
                    selectedIngresosID = Convert.ToInt32(selectedRow.Cells["Id"].Value);

                    await _ingresosRepository.DeleteAsync(selectedIngresosID);
                    MessageBox.Show("Ingreso eliminado exitosamente", "Eliminar Ingreso", MessageBoxButtons.OK, MessageBoxIcon.Information);

                    RefreshData();
                    LimpiarDetalleEmpleados();
                    selectedIngresosID = -1;
                }
                catch (Exception ex)
                {
                    MessageBox.Show($"Error al intentar eliminar el ingreso: {ex.Message}", "Eliminar Ingreso", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
        }
        private async void btnActualizar_Click(object sender, EventArgs e)
        {
            if (dgvIngresos.SelectedRows.Count == 0)
            {
                MessageBox.Show("Por favor seleccione un ingreso para actualizar.", "Actualizar Ingreso", MessageBoxButtons.OK, MessageBoxIcon.Information);
                return;
            }

            try
            {
                // Obtener el ID del ingreso seleccionado
                int selectedIngresoId = Convert.ToInt32(dgvIngresos.SelectedRows[0].Cells["Id"].Value);

                // Obtener los datos actuales del ingreso desde el repositorio
                var ingresoUpdateDto = new IngresosUpdateDto
                {
                    Ingresos_Id = selectedIngresoId,
                    Empleado_Id = Convert.ToInt32(CbEmpleados_Id.SelectedItem),
                    PrimerNombre = TxtNombre.Text.Trim(),
                    PrimerApellido = TxtApellido.Text.Trim(),
                    SalarioMensual = Convert.ToDecimal(TxtSalarioMensual.Text),
                    Inicio_Periodo = dtpInicio.Value,
                    Fin_Periodo = dtpFin.Value,
                    PagoHorasExtras = string.IsNullOrWhiteSpace(TxtHorasExtras.Text) ? (decimal?)null : Convert.ToDecimal(TxtHorasExtras.Text),
                    Antiguedad = Convert.ToDecimal(TxtAntiguedad.Text),
                    RiesgoLaboral = rdSi.Checked ? Convert.ToDecimal(TxtRiesgoLaboral.Text) : (decimal?)null,
                    Nocturnidad = rbSi.Checked ? Convert.ToDecimal(TxtNoctabilidad.Text) : (decimal?)null,
                    OtrosIngresos = string.IsNullOrWhiteSpace(TxtOtrosIngresos.Text) ? (decimal?)null : Convert.ToDecimal(TxtOtrosIngresos.Text),
                    Adelanto_Salario = string.IsNullOrWhiteSpace(TxtAnticipoSalarial.Text) ? (decimal?)null : Convert.ToDecimal(TxtAnticipoSalarial.Text),
                    Otras_Deducciones = string.IsNullOrWhiteSpace(TxtOtrasDeducciones.Text) ? (decimal?)null : Convert.ToDecimal(TxtOtrasDeducciones.Text),
                    // Calcular valores adicionales si es necesario
                    SalarioBruto = 0, // Calcula esto según tu lógica
                    Inss = 0, // Calcula esto según tu lógica
                    Ir = 0, // Calcula esto según tu lógica
                    SalarioNeto = 0 // Calcula esto según tu lógica
                    
                };
                ActualizarINSS();
                ActualizarIR();
                ActualizarSalarioBruto();
                ActualizarSalarioNeto();
                RefreshData();
                await _ingresosRepository.IngresosUpdateAsync(ingresoUpdateDto);

            MessageBox.Show("Ingreso actualizado correctamente.", "Actualizar Ingreso", MessageBoxButtons.OK, MessageBoxIcon.Information);

            await CargarEmpleado_IdAsync();
            LimpiarDetalleEmpleados();
             }
             catch (Exception ex)
            {
             MessageBox.Show($"Error al actualizar el ingreso: {ex.Message}", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
             }
         }
         private void dgvIngresos_CellContentClick(object sender, DataGridViewCellEventArgs e)
         {
         }
        private void rdSi_CheckedChanged(object sender, EventArgs e)
        {
            if (rdSi.Checked)
            {
                TxtRiesgoLaboral.Text = CalcularRiesgoLaborar(_salarioMensual)?.ToString("F2");
                if (decimal.TryParse(TxtRiesgoLaboral.Text, out decimal riesgo))
                {
                    _RiesgoLaboral = riesgo;
                }
                else
                {
                    _RiesgoLaboral = 0.00M;
                }
                TxtRiesgoLaboral.Visible = true;
                ActualizarSalarioBruto();
            }
            else
            {
                _RiesgoLaboral = 0.00M;
                TxtRiesgoLaboral.Enabled = false;
                TxtRiesgoLaboral.Text = "";
                ActualizarSalarioBruto();
            }
        }
        private void rdNo_CheckedChanged(object sender, EventArgs e)
        {
            if (rdNo.Checked)
            {
                _RiesgoLaboral = 0.00M;
                TxtRiesgoLaboral.Enabled = false;
                TxtRiesgoLaboral.Text = "0.00";
                ActualizarSalarioBruto();
            }
        }
        private void rbSi_CheckedChanged(object sender, EventArgs e)
        {
            if (rbSi.Checked)
            {
                TxtNoctabilidad.Text = CalcularNocturnidad(_salarioMensual)?.ToString("F2");
                if (decimal.TryParse(TxtNoctabilidad.Text, out decimal nocturnidad))
                {
                    _Nocturnidad = nocturnidad;
                }
                else
                {
                    _Nocturnidad = 0.00M;
                }
                TxtNoctabilidad.Visible = true;
                ActualizarSalarioBruto();
            }
            else
            {
                _Nocturnidad = 0.00M;
                TxtNoctabilidad.Enabled = false;
                TxtNoctabilidad.Text = "";
                ActualizarSalarioBruto();
            }
        }
        private void rbNo_CheckedChanged_1(object sender, EventArgs e)
        {
            if (rbNo.Checked)
            {
                _Nocturnidad = 0.00M;
                TxtNoctabilidad.Enabled = false;
                TxtNoctabilidad.Text = "0.00";
                ActualizarSalarioBruto();
            }
        }
        private void TxtOtrosIngresos_TextChanged(object sender, EventArgs e)
        {
            if (decimal.TryParse(TxtOtrosIngresos.Text, out decimal otrosIngresos))
            {
                _OtrosIngresos = otrosIngresos;
            }
            else
            {
                _OtrosIngresos = 0.00M;
                _OtrosIngresos = otrosIngresos;
            }
            ActualizarSalarioBruto();

        }
        private void ActualizarSalarioBruto()
        {
            _salarioBruto = CalcularSalarioBruto();
            TxtSalarioBruto.Text = _salarioBruto.ToString("F2");

            ActualizarINSS();
            ActualizarIR();
            ActualizarSalarioNeto();
        }
        private void ActualizarSalarioNeto()
        {
            _SalarioNeto = _salarioBruto - (_INSS + _IR + (_OtrasDededucciones ?? 0) + (_AdelantoSalario ?? 0));
            TxtSalarioNeto.Text = _SalarioNeto.ToString("F2");
        }
        private void ActualizarIR()
        {
            _IR = CalculoIR(_salarioBruto);
            TxtIR.Text = _IR.ToString("F2");
        }
        private void ActualizarINSS()
        {
            _INSS = _salarioBruto * 0.07M;
            TxtINSS.Text = _INSS.ToString("F2");
        }
        private void TxtOtrasDeducciones_TextChanged(object sender, EventArgs e)
        {
            if (decimal.TryParse(TxtOtrasDeducciones.Text, out decimal otrasdeducciones))
            {
                _OtrasDededucciones = otrasdeducciones;
            }
            else
            {
                _OtrasDededucciones = 0.00M;
                _OtrasDededucciones = otrasdeducciones;
            }
            ActualizarSalarioNeto();
        }
        private void TxtAnticipoSalarial_TextChanged(object sender, EventArgs e)
        {
            if (decimal.TryParse(TxtAnticipoSalarial.Text, out decimal anticipo))
            {
                _AdelantoSalario = anticipo;
            }
            else
            {
                _AdelantoSalario = 0.00M;
                _AdelantoSalario = anticipo;
            }
            ActualizarSalarioNeto();
        }

        private async void btnExcel_Click(object sender, EventArgs e)
        {
            try
            {
                var ingresos = await _ingresosRepository.GetAllAsync();
                using (var package = new ExcelPackage())
                {
                    var worksheet = package.Workbook.Worksheets.Add("Ingresos");

                    worksheet.Cells[1, 2].Value = "ID";
                    worksheet.Cells[1, 3].Value = "Salario Mensual";
                    worksheet.Cells[1, 4].Value = "Antigüedad";
                    worksheet.Cells[1, 5].Value = "Pago Horas Extras";
                    worksheet.Cells[1, 6].Value = "Otros Ingresos";
                    worksheet.Cells[1, 7].Value = "Nocturnidad";
                    worksheet.Cells[1, 8].Value = "Riesgo Laboral";
                    worksheet.Cells[1, 9].Value = "Salario Bruto";
                    worksheet.Cells[1, 10].Value = "INSS";
                    worksheet.Cells[1, 11].Value = "IR";
                    worksheet.Cells[1, 12].Value = "Otras Deducciones";
                    worksheet.Cells[1, 13].Value = "Adelanto Salario";
                    worksheet.Cells[1, 14].Value = "Otros Ingresos";
                    worksheet.Cells[1, 15].Value = "Salario Neto";

                    int row = 2;
                    foreach (var ingreso in ingresos)
                    {
                        worksheet.Cells[row, 2].Value = ingreso.Empleado_Id;
                        worksheet.Cells[row, 3].Value = ingreso.SalarioMensual;
                        worksheet.Cells[row, 4].Value = ingreso.Antiguedad;
                        worksheet.Cells[row, 5].Value = ingreso.PagoHorasExtras;
                        worksheet.Cells[row, 6].Value = ingreso.OtrosIngresos;
                        worksheet.Cells[row, 7].Value = ingreso.Nocturnidad;
                        worksheet.Cells[row, 8].Value = ingreso.RiesgoLaboral;
                        worksheet.Cells[row, 9].Value = ingreso.SalarioBruto;
                        worksheet.Cells[row, 10].Value = ingreso.Inss;
                        worksheet.Cells[row, 11].Value = ingreso.Ir;
                        worksheet.Cells[row, 12].Value = ingreso.Otras_Deducciones;
                        worksheet.Cells[row, 13].Value = ingreso.Adelanto_Salario;
                        worksheet.Cells[row, 14].Value = ingreso.OtrosIngresos;
                        worksheet.Cells[row, 15].Value = ingreso.SalarioNeto;
                        row++;
                    }
                    worksheet.Cells.AutoFitColumns();
                    using (var saveFileDialog = new SaveFileDialog { Filter = "Excel files (*.xlsx)|*.xlsx", FileName = $"Ingresos-{DateTime.Now:yyyyMMdd}.xlsx" })
                    {
                        if (saveFileDialog.ShowDialog() == DialogResult.OK)
                        {
                            var file = new FileInfo(saveFileDialog.FileName);
                            package.SaveAs(file);
                            Process.Start(new ProcessStartInfo(file.FullName) { UseShellExecute = true });
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Error al exportar los datos: {ex.Message}", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void dtpInicio_ValueChanged(object sender, EventArgs e)
        {

        }
    }

}