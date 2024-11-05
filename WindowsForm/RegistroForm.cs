using SharedModels.Dto.EmpleadosDatos;
using WindowsForm;
using SharedModels;
using System.Xml.Linq;

namespace Tarea
{
    public partial class RegistroForm : Form
    {
        private readonly ApiClient _apiClient;
        private int selectedEmpleadoId = -1;
        public RegistroForm(HttpClient _httpClient)
        {
            InitializeComponent();
            _apiClient = new ApiClient();
        }
        private async void RegistroForm_Load(object sender, EventArgs e)
        {
            CargarComboBox();
            await CargarEmpleadosAsycn();
        }

        private async Task CargarEmpleadosAsycn()
        {
            try
            {
                var empleados = await _apiClient.Empleados.GetAllAsync();
                dgvRegistro.DataSource = empleados.ToList();
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Error al cargar empleados: {ex.Message}", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
        private void CargarComboBox()
        {
            CbGenero.Items.AddRange(new object[] { "Hombre", "Mujer" });
            CbEstadoCivil.Items.AddRange(new object[] { "Solter@", "Casad@", "Viud@", "Divorciad@" });
            CbEstado.Items.AddRange(new object[] { "Activo", "Inactivo@" });
            CbGenero.SelectedIndex = 0;
            CbEstado.SelectedIndex = 0;
            CbEstadoCivil.SelectedIndex = 0;
        }
        private void LimpiarCampos()
        {
            txtPrimerNombre.Clear();
            txtSegundoNombre.Clear();
            txtPrimerApellido.Clear();
            txtSegundoApellido.Clear();
            txtNumeroCedula.Clear();
            txtTelefono.Clear();
            txtCelular.Clear();
            TxtNumeroRuc.Clear();
            TXTNumeroINSS.Clear();
            TxtSalarioMensual.Clear();
            TxtHorasExtras.Clear();
            txtDireccion.Clear();
            dtpInicio.Value = DateTime.Now;
            dtpFin.Value = DateTime.Now;
            dtpFechaNacimiento.Value = DateTime.Now;
            CbGenero.SelectedIndex = 0;
            CbEstadoCivil.SelectedIndex = 0;
            CbEstado.SelectedIndex = 0;
            chkRegistrado.Checked = false;
            selectedEmpleadoId = -1;
        }
        private async void btnAgregar_Click(object sender, EventArgs e)
        {
            var nuevoEmpleado = new EmpleadoDatos
            {
                PrimerNombre = txtPrimerNombre.Text,
                SegundoNombre = txtSegundoNombre.Text,
                PrimerApellido = txtPrimerApellido.Text,
                SegundoApellido = txtSegundoApellido.Text,
                Direccion = txtDireccion.Text,
                Telefono = int.TryParse(txtTelefono.Text, out int telefono) ? telefono : throw new Exception("Teléfono inválido"),
                Celular = int.TryParse(txtCelular.Text, out int celular) ? celular : throw new Exception("Celular inválido"),
                NumeroINSS = int.TryParse(TXTNumeroINSS.Text, out int numeroINSS) ? numeroINSS : throw new Exception("Número INSS inválido"),
                NumeroRuc = int.TryParse(TxtNumeroRuc.Text, out int numeroRuc) ? numeroRuc : throw new Exception("Número RUC inválido"),
                NumeroCedula = int.TryParse(txtNumeroCedula.Text, out int numeroCedula) ? numeroCedula : throw new Exception("Número de cédula inválido"),
                FechaNacimiento = dtpFechaNacimiento.Value,
                Inicio_Contrato = dtpInicio.Value,
                Fin_Contrato = dtpFin.Value,
                Genero = CbGenero.SelectedItem.ToString(),
                EstadoCivil = CbEstadoCivil.SelectedItem.ToString(),
                Estado = CbEstado.SelectedItem.ToString(),
                SalarioMensual = decimal.TryParse(TxtSalarioMensual.Text, out decimal salarioMensual) ? salarioMensual : throw new Exception("Salario mensual inválido"),
                HorasExtras = decimal.TryParse(TxtHorasExtras.Text, out decimal horasExtras) ? horasExtras : throw new Exception("Horas extras inválidas"),
                Registered = chkRegistrado.Checked
            };
            var success = await _apiClient.Empleados.CreateAsync(nuevoEmpleado);
            try
            {
                MessageBox.Show("¡Estudiante agregado exitosamente!", "Éxito",
                MessageBoxButtons.OK, MessageBoxIcon.Information);
                LimpiarCampos();
                await CargarEmpleadosAsycn();

            }
            catch (Exception ex)
            {
                MessageBox.Show($"Error al guardar empleado: {ex.Message}", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }


        private void dgvRegistro_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            try
            {
                if (e.RowIndex >= 0)
                {
                    var empleado = (EmpleadosDto)dgvRegistro.Rows[e.RowIndex].DataBoundItem;
                    selectedEmpleadoId = empleado.Empleado_Id;
                    txtPrimerNombre.Text = empleado.PrimerNombre;
                    txtSegundoNombre.Text = empleado.SegundoNombre;
                    txtPrimerApellido.Text = empleado.PrimerApellido;
                    txtSegundoApellido.Text = empleado.SegundoApellido;
                    txtNumeroCedula.Text = empleado.NumeroCedula.ToString();
                    txtTelefono.Text = empleado.Telefono.ToString();
                    txtCelular.Text = empleado.Celular.ToString();
                    TxtNumeroRuc.Text = empleado.NumeroRuc.ToString();
                    TXTNumeroINSS.Text = empleado.NumeroINSS.ToString();
                    txtDireccion.Text = empleado.Direccion;
                    dtpFechaNacimiento.Value = empleado.FechaNacimiento;
                    dtpInicio.Value = empleado.Inicio_Contrato;
                    dtpFin.Value = empleado.Fin_Contrato;
                    CbGenero.SelectedItem = empleado.Genero;
                    CbEstadoCivil.SelectedItem = empleado.EstadoCivil;
                    TxtSalarioMensual.Text = empleado.SalarioMensual.ToString();
                    TxtHorasExtras.Text = empleado.HorasExtras.ToString();
                    CbEstado.SelectedItem = empleado.Estado;
                    chkRegistrado.Checked = empleado.Registered;
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Error al seleccionar empleado: {ex.Message}", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
        private async void btnActualizar_Click(object sender, EventArgs e)
        {
            if (selectedEmpleadoId != -1)
            {
                try
                {
                    var empleadoActualizado = new EmpleadoDatos
                    {
                        Empleado_Id = selectedEmpleadoId,
                        PrimerNombre = txtPrimerNombre.Text,
                        SegundoNombre = txtSegundoNombre.Text,
                        PrimerApellido = txtPrimerApellido.Text,
                        SegundoApellido = txtSegundoApellido.Text,
                        Direccion = txtDireccion.Text,
                        Telefono = int.TryParse(txtTelefono.Text, out int telefono) ? telefono : throw new Exception("Teléfono inválido"),
                        Celular = int.TryParse(txtCelular.Text, out int celular) ? celular : throw new Exception("Celular inválido"),
                        NumeroINSS = int.TryParse(TXTNumeroINSS.Text, out int numeroINSS) ? numeroINSS : throw new Exception("Número INSS inválido"),
                        NumeroRuc = int.TryParse(TxtNumeroRuc.Text, out int numeroRuc) ? numeroRuc : throw new Exception("Número RUC inválido"),
                        NumeroCedula = int.TryParse(txtNumeroCedula.Text, out int numeroCedula) ? numeroCedula : throw new Exception("Número de cédula inválido"),
                        FechaNacimiento = dtpFechaNacimiento.Value,
                        Inicio_Contrato = dtpInicio.Value,
                        Fin_Contrato = dtpFin.Value,
                        Genero = CbGenero.SelectedItem.ToString(),
                        EstadoCivil = CbEstadoCivil.SelectedItem.ToString(),
                        Estado = CbEstado.SelectedItem.ToString(),
                        SalarioMensual = decimal.TryParse(TxtSalarioMensual.Text, out decimal salarioMensual) ? salarioMensual : throw new Exception("Salario mensual inválido"),
                        HorasExtras = decimal.TryParse(TxtHorasExtras.Text, out decimal horasExtras) ? horasExtras : throw new Exception("Horas extras inválidas"),
                        Registered = chkRegistrado.Checked
                    };

                    var success = await _apiClient.Empleados.UpdateAsync(selectedEmpleadoId, empleadoActualizado);

                    if (success)
                    {
                        MessageBox.Show("¡Empleado actualizado exitosamente!", "Éxito", MessageBoxButtons.OK, MessageBoxIcon.Information);
                        LimpiarCampos();
                        await CargarEmpleadosAsycn();
                    }
                    else
                    {
                        MessageBox.Show("Error al actualizar empleado.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    }
                }
                catch (Exception ex)
                {
                    MessageBox.Show($"Error al actualizar empleado: {ex.Message}", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
            else
            {
                MessageBox.Show("Seleccione un empleado para actualizar.", "Advertencia", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
        }
        private async void btnEliminar_Click_1(object sender, EventArgs e)
        {
            await EliminarEmpleados();
        }

        private async Task EliminarEmpleados()
        {
            try
            {
                if (selectedEmpleadoId != -1)
                {
                    var confirmResult = MessageBox.Show("¿Está seguro de que desea eliminar este empleado?", "Confirmar Eliminación",
                                            MessageBoxButtons.YesNo, MessageBoxIcon.Warning);
                    if (confirmResult == DialogResult.Yes)
                    {
                        var success = await _apiClient.Empleados.DeleteAsync(selectedEmpleadoId);
                        if (success)
                        {
                            MessageBox.Show("Empleado eliminado correctamente.", "Éxito", MessageBoxButtons.OK, MessageBoxIcon.Information);
                            LimpiarCampos();
                            selectedEmpleadoId = -1;
                            await CargarEmpleadosAsycn();
                        }
                        else
                        {
                            MessageBox.Show("Error al eliminar empleado.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                        }
                    }
                }
                else
                {
                    MessageBox.Show("Seleccione un empleado para eliminar.", "Advertencia", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Error al eliminar empleado: {ex.Message}", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
        DateTime fechaNacimientoMin;
        DateTime fechaNacimiento;
        DateTime fechaNacimientoPredeterminada;
        DateTime ultimafecha;
        DateTime fechaContrato;
        DateTime fechaContratoMin;
        private void dtpFechaNacimiento_ValueChanged(object sender, EventArgs e)
        {
            fechaNacimiento = dtpFechaNacimiento.Value;
            DateTime fechaHoy = DateTime.Today;
            int edad = fechaHoy.Year - fechaNacimiento.Year;
            fechaNacimientoMin = fechaHoy.AddYears(-18);

            if (fechaNacimiento > fechaNacimientoMin)
            {
                MessageBox.Show("La edad no puede ser menor de 18 años.", "Information", MessageBoxButtons.OK, MessageBoxIcon.Information);
                dtpFechaNacimiento.Value = fechaNacimientoMin;
            }
            else if (fechaNacimiento < fechaNacimientoPredeterminada)
            {
                MessageBox.Show("La edad no puede ser mayor de 80 años.", "Information", MessageBoxButtons.OK, MessageBoxIcon.Information);
                dtpFechaNacimiento.Value = fechaHoy.AddYears(-80);
            }
        }

        private void dtpInicio_ValueChanged(object sender, EventArgs e)
        {


        }

        private void dtpFin_ValueChanged(object sender, EventArgs e)
        {

        }

        private void txtNumeroCedula_TextChanged(object sender, EventArgs e)
        {
        }

        private void txtTelefono_TextChanged(object sender, EventArgs e)
        {
            if (txtTelefono.Text.Length > 8)
            {
                txtTelefono.Text = txtTelefono.Text.Substring(0, 8);
            }
        }
        private void TXTNumeroINSS_TextChanged(object sender, EventArgs e)
        {

            if (TXTNumeroINSS.Text.Length > 10)
            {
                TXTNumeroINSS.Text = TXTNumeroINSS.Text.Substring(0, 10);
            }
        }

        private void txtDireccion_TextChanged(object sender, EventArgs e)
        {
        }

        private void TxtSalarioMensual_TextChanged(object sender, EventArgs e)
        {
        }
    }
}
