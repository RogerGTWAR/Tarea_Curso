using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace WindowsForm
{
    public partial class LoginForm : Form
    {
        private readonly ApiClient _apiClient;
        public LoginForm()
        {
            InitializeComponent();
            _apiClient = new ApiClient();
        }

        private async void btnCargar_Click(object sender, EventArgs e)
        {
            await LoginAsync();
        }

        private async Task LoginAsync()
        {
            string username = txtxUserName.Text;
            string password = txtPassword.Text;

            try
            {
                var token = await _apiClient.LoginUsers.AuthenticateUserAsync(username, password);

                if (!string.IsNullOrEmpty(token))
                {
                    MessageBox.Show("¡Inicio de sesión exitoso!");
                    _apiClient.SetAuthToken(token);
                    Hide();
                    var mainForm = new MenuForm(_apiClient);
                    mainForm.Show();
                }
                else
                {
                    MessageBox.Show("Acceso fallido. Por favor revisar usuario y contraseña.");
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Error al intentar iniciar sesión: {ex.Message}", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void btnMinimizar_Click(object sender, EventArgs e)
        {
            this.WindowState = FormWindowState.Minimized;
        }

        private void btnMaximizar_Click(object sender, EventArgs e)
        {
            this.WindowState = FormWindowState.Maximized;
            btnMaximizar.Visible = false;
            btnRestaurar.Visible = true;
        }

        private void btnRestaurar_Click(object sender, EventArgs e)
        {
            this.WindowState = FormWindowState.Normal;
            btnRestaurar.Visible = false;
            btnMaximizar.Visible = true;
        }

        private void btnCerrar_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }

        private void LoginForm_Load(object sender, EventArgs e)
        {

        }
    }
}