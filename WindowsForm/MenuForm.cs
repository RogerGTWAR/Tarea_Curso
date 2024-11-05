using SharedModels;
using System.Net.Http;
using Tarea;

namespace WindowsForm
{
    public partial class MenuForm : Form
    {
        private RegistroForm registroForm;
        private IngresosyDeduccionesForm ingresosForm;
        private readonly HttpClient _httpClient;
        private List<Ingresos> _ingresos;
        public MenuForm(ApiClient _apiClient)
        {
            InitializeComponent();
            _httpClient = new HttpClient
            {
                BaseAddress = new Uri("https://localhost:7069/api/")
            };
        }

        private void btnSalir_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }
        private void LimpiarPanelPrincipal()
        {
            panelContenedor.Controls.Clear();
        }

        private void btnRegistro_Click(object sender, EventArgs e)
        {
            MostrarRegistroForm();
        }

        private void MostrarRegistroForm()
        {
            LimpiarPanelPrincipal();
            registroForm = new RegistroForm(_httpClient);
            registroForm.TopLevel = false;
            registroForm.FormBorderStyle = FormBorderStyle.None;
            registroForm.Dock = DockStyle.Fill;
            panelContenedor.Controls.Add(registroForm);
            registroForm.Show();
        }
        private void btnMaximizar_Click_1(object sender, EventArgs e)
        {
            this.WindowState = FormWindowState.Maximized;
            btnMaximizar.Visible = false;
            btnRestaurar.Visible = true;
        }

        private void btnMinimizar_Click(object sender, EventArgs e)
        {
            this.WindowState = FormWindowState.Minimized;
        }

        private void btnRestaurar_Click_1(object sender, EventArgs e)
        {
            this.WindowState = FormWindowState.Normal;
            btnRestaurar.Visible = false;
            btnMaximizar.Visible = true;
        }

        private void btnCerrar_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }

        private void btnIngresos_Click(object sender, EventArgs e)
        {
            LimpiarPanelPrincipal();
            ingresosForm = new IngresosyDeduccionesForm(_httpClient);
            ingresosForm.TopLevel = false;
            ingresosForm.FormBorderStyle = FormBorderStyle.None;
            ingresosForm.Dock = DockStyle.Fill;
            panelContenedor.Controls.Add(ingresosForm);
            ingresosForm.Show();
        }

        private void btnNomina_Click(object sender, EventArgs e)
        {

        }

        private void btnEmpresa_Click(object sender, EventArgs e)
        {
        }
    }
}
