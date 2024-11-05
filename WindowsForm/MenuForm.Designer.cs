namespace WindowsForm
{
    partial class MenuForm
    {
        /// <summary>
        ///  Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        ///  Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        ///  Required method for Designer support - do not modify
        ///  the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(MenuForm));
            panelContenedor = new Panel();
            btnMaximizar = new PictureBox();
            btnRestaurar = new PictureBox();
            btnRegistro = new Button();
            panelTitulo = new Panel();
            btnMinimizar = new PictureBox();
            btnCerrar = new PictureBox();
            panel2 = new Panel();
            btnIngresos = new Button();
            ((System.ComponentModel.ISupportInitialize)btnMaximizar).BeginInit();
            ((System.ComponentModel.ISupportInitialize)btnRestaurar).BeginInit();
            panelTitulo.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)btnMinimizar).BeginInit();
            ((System.ComponentModel.ISupportInitialize)btnCerrar).BeginInit();
            panel2.SuspendLayout();
            SuspendLayout();
            // 
            // panelContenedor
            // 
            panelContenedor.BackColor = Color.FromArgb(49, 66, 82);
            panelContenedor.Dock = DockStyle.Fill;
            panelContenedor.Location = new Point(0, 0);
            panelContenedor.Name = "panelContenedor";
            panelContenedor.Size = new Size(1919, 948);
            panelContenedor.TabIndex = 0;
            // 
            // btnMaximizar
            // 
            btnMaximizar.Anchor = AnchorStyles.Top | AnchorStyles.Right;
            btnMaximizar.Image = (Image)resources.GetObject("btnMaximizar.Image");
            btnMaximizar.Location = new Point(1822, 6);
            btnMaximizar.Name = "btnMaximizar";
            btnMaximizar.Size = new Size(40, 36);
            btnMaximizar.SizeMode = PictureBoxSizeMode.Zoom;
            btnMaximizar.TabIndex = 3;
            btnMaximizar.TabStop = false;
            btnMaximizar.Visible = false;
            btnMaximizar.Click += btnMaximizar_Click_1;
            // 
            // btnRestaurar
            // 
            btnRestaurar.Anchor = AnchorStyles.Top | AnchorStyles.Right;
            btnRestaurar.Image = (Image)resources.GetObject("btnRestaurar.Image");
            btnRestaurar.Location = new Point(1828, 6);
            btnRestaurar.Name = "btnRestaurar";
            btnRestaurar.Size = new Size(34, 36);
            btnRestaurar.SizeMode = PictureBoxSizeMode.Zoom;
            btnRestaurar.TabIndex = 3;
            btnRestaurar.TabStop = false;
            btnRestaurar.Click += btnRestaurar_Click_1;
            // 
            // btnRegistro
            // 
            btnRegistro.BackColor = Color.FromArgb(26, 32, 40);
            btnRegistro.FlatAppearance.BorderSize = 0;
            btnRegistro.FlatAppearance.MouseOverBackColor = Color.FromArgb(0, 80, 200);
            btnRegistro.FlatStyle = FlatStyle.Flat;
            btnRegistro.Font = new Font("Century Gothic", 13.8F, FontStyle.Bold, GraphicsUnit.Point, 0);
            btnRegistro.ForeColor = Color.White;
            btnRegistro.Image = (Image)resources.GetObject("btnRegistro.Image");
            btnRegistro.ImageAlign = ContentAlignment.MiddleLeft;
            btnRegistro.Location = new Point(12, 38);
            btnRegistro.Name = "btnRegistro";
            btnRegistro.Size = new Size(253, 40);
            btnRegistro.TabIndex = 0;
            btnRegistro.Text = "  Registrar";
            btnRegistro.UseVisualStyleBackColor = false;
            btnRegistro.Click += btnRegistro_Click;
            // 
            // panelTitulo
            // 
            panelTitulo.BackColor = Color.FromArgb(0, 80, 200);
            panelTitulo.Controls.Add(btnMaximizar);
            panelTitulo.Controls.Add(btnMinimizar);
            panelTitulo.Controls.Add(btnRestaurar);
            panelTitulo.Controls.Add(btnCerrar);
            panelTitulo.Dock = DockStyle.Top;
            panelTitulo.Location = new Point(0, 0);
            panelTitulo.Name = "panelTitulo";
            panelTitulo.Size = new Size(1919, 42);
            panelTitulo.TabIndex = 5;
            // 
            // btnMinimizar
            // 
            btnMinimizar.Anchor = AnchorStyles.Top | AnchorStyles.Right;
            btnMinimizar.Image = (Image)resources.GetObject("btnMinimizar.Image");
            btnMinimizar.Location = new Point(1775, 6);
            btnMinimizar.Name = "btnMinimizar";
            btnMinimizar.Size = new Size(34, 36);
            btnMinimizar.SizeMode = PictureBoxSizeMode.Zoom;
            btnMinimizar.TabIndex = 2;
            btnMinimizar.TabStop = false;
            btnMinimizar.Click += btnMinimizar_Click;
            // 
            // btnCerrar
            // 
            btnCerrar.Anchor = AnchorStyles.Top | AnchorStyles.Right;
            btnCerrar.Image = (Image)resources.GetObject("btnCerrar.Image");
            btnCerrar.Location = new Point(1882, 6);
            btnCerrar.Name = "btnCerrar";
            btnCerrar.Size = new Size(34, 36);
            btnCerrar.SizeMode = PictureBoxSizeMode.Zoom;
            btnCerrar.TabIndex = 0;
            btnCerrar.TabStop = false;
            btnCerrar.Click += btnCerrar_Click;
            // 
            // panel2
            // 
            panel2.BackColor = Color.FromArgb(26, 32, 40);
            panel2.Controls.Add(btnIngresos);
            panel2.Controls.Add(btnRegistro);
            panel2.Dock = DockStyle.Left;
            panel2.Location = new Point(0, 42);
            panel2.Name = "panel2";
            panel2.Size = new Size(262, 906);
            panel2.TabIndex = 6;
            // 
            // btnIngresos
            // 
            btnIngresos.BackColor = Color.FromArgb(26, 32, 40);
            btnIngresos.FlatAppearance.BorderSize = 0;
            btnIngresos.FlatAppearance.MouseOverBackColor = Color.FromArgb(0, 80, 200);
            btnIngresos.FlatStyle = FlatStyle.Flat;
            btnIngresos.Font = new Font("Century Gothic", 13.8F, FontStyle.Bold, GraphicsUnit.Point, 0);
            btnIngresos.ForeColor = Color.White;
            btnIngresos.Image = (Image)resources.GetObject("btnIngresos.Image");
            btnIngresos.ImageAlign = ContentAlignment.MiddleLeft;
            btnIngresos.Location = new Point(12, 96);
            btnIngresos.Name = "btnIngresos";
            btnIngresos.Size = new Size(270, 69);
            btnIngresos.TabIndex = 5;
            btnIngresos.Text = "Ingresos y Deducciones";
            btnIngresos.UseVisualStyleBackColor = false;
            btnIngresos.Click += btnIngresos_Click;
            // 
            // MenuForm
            // 
            AutoScaleDimensions = new SizeF(8F, 20F);
            AutoScaleMode = AutoScaleMode.Font;
            BackColor = SystemColors.HighlightText;
            ClientSize = new Size(1919, 948);
            Controls.Add(panel2);
            Controls.Add(panelTitulo);
            Controls.Add(panelContenedor);
            FormBorderStyle = FormBorderStyle.None;
            Name = "MenuForm";
            StartPosition = FormStartPosition.CenterScreen;
            Text = "Menu";
            ((System.ComponentModel.ISupportInitialize)btnMaximizar).EndInit();
            ((System.ComponentModel.ISupportInitialize)btnRestaurar).EndInit();
            panelTitulo.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)btnMinimizar).EndInit();
            ((System.ComponentModel.ISupportInitialize)btnCerrar).EndInit();
            panel2.ResumeLayout(false);
            ResumeLayout(false);
        }

        #endregion

        private Panel panelContenedor;
        private Button btnRegistro;
        private Button btnSalir;
        private Panel panelTitulo;
        private Panel panel2;
        private PictureBox btnMaximizar;
        private PictureBox btnMinimizar;
        private PictureBox btnCerrar;
        private PictureBox btnRestaurar;
        private Button btnIngresos;
    }
}
