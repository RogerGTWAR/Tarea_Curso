namespace WindowsForm
{
    partial class LoginForm
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
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
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(LoginForm));
            txtxUserName = new TextBox();
            txtPassword = new TextBox();
            label1 = new Label();
            label2 = new Label();
            btnCargar = new Button();
            btnCerrar = new PictureBox();
            btnMaximizar = new PictureBox();
            btnMinimizar = new PictureBox();
            btnRestaurar = new PictureBox();
            ((System.ComponentModel.ISupportInitialize)btnCerrar).BeginInit();
            ((System.ComponentModel.ISupportInitialize)btnMaximizar).BeginInit();
            ((System.ComponentModel.ISupportInitialize)btnMinimizar).BeginInit();
            ((System.ComponentModel.ISupportInitialize)btnRestaurar).BeginInit();
            SuspendLayout();
            // 
            // txtxUserName
            // 
            txtxUserName.Location = new Point(348, 73);
            txtxUserName.Name = "txtxUserName";
            txtxUserName.Size = new Size(202, 27);
            txtxUserName.TabIndex = 0;
            // 
            // txtPassword
            // 
            txtPassword.Location = new Point(348, 163);
            txtPassword.Name = "txtPassword";
            txtPassword.Size = new Size(202, 27);
            txtPassword.TabIndex = 1;
            // 
            // label1
            // 
            label1.AutoSize = true;
            label1.BackColor = Color.FromArgb(49, 66, 82);
            label1.Font = new Font("Century Gothic", 13.8F, FontStyle.Bold, GraphicsUnit.Point, 0);
            label1.ForeColor = Color.White;
            label1.Location = new Point(130, 73);
            label1.Name = "label1";
            label1.Size = new Size(94, 27);
            label1.TabIndex = 3;
            label1.Text = "Usuario";
            // 
            // label2
            // 
            label2.AutoSize = true;
            label2.BackColor = Color.FromArgb(49, 66, 82);
            label2.Font = new Font("Century Gothic", 13.8F, FontStyle.Bold, GraphicsUnit.Point, 0);
            label2.ForeColor = Color.White;
            label2.Location = new Point(100, 163);
            label2.Name = "label2";
            label2.Size = new Size(142, 27);
            label2.TabIndex = 4;
            label2.Text = "Contraseña";
            // 
            // btnCargar
            // 
            btnCargar.BackColor = Color.SeaGreen;
            btnCargar.FlatStyle = FlatStyle.Popup;
            btnCargar.Font = new Font("Century Gothic", 13.8F, FontStyle.Bold, GraphicsUnit.Point, 0);
            btnCargar.ForeColor = Color.Black;
            btnCargar.Location = new Point(249, 251);
            btnCargar.Name = "btnCargar";
            btnCargar.Size = new Size(147, 50);
            btnCargar.TabIndex = 5;
            btnCargar.Text = "Acceder";
            btnCargar.UseVisualStyleBackColor = false;
            btnCargar.Click += btnCargar_Click;
            // 
            // btnCerrar
            // 
            btnCerrar.Image = (Image)resources.GetObject("btnCerrar.Image");
            btnCerrar.Location = new Point(672, 3);
            btnCerrar.Name = "btnCerrar";
            btnCerrar.Size = new Size(32, 34);
            btnCerrar.SizeMode = PictureBoxSizeMode.Zoom;
            btnCerrar.TabIndex = 6;
            btnCerrar.TabStop = false;
            btnCerrar.Click += btnCerrar_Click;
            // 
            // btnMaximizar
            // 
            btnMaximizar.Image = (Image)resources.GetObject("btnMaximizar.Image");
            btnMaximizar.Location = new Point(634, 3);
            btnMaximizar.Name = "btnMaximizar";
            btnMaximizar.Size = new Size(32, 34);
            btnMaximizar.SizeMode = PictureBoxSizeMode.Zoom;
            btnMaximizar.TabIndex = 7;
            btnMaximizar.TabStop = false;
            btnMaximizar.Click += btnMaximizar_Click;
            // 
            // btnMinimizar
            // 
            btnMinimizar.Image = (Image)resources.GetObject("btnMinimizar.Image");
            btnMinimizar.Location = new Point(596, 3);
            btnMinimizar.Name = "btnMinimizar";
            btnMinimizar.Size = new Size(32, 34);
            btnMinimizar.SizeMode = PictureBoxSizeMode.Zoom;
            btnMinimizar.TabIndex = 8;
            btnMinimizar.TabStop = false;
            btnMinimizar.Click += btnMinimizar_Click;
            // 
            // btnRestaurar
            // 
            btnRestaurar.Image = (Image)resources.GetObject("btnRestaurar.Image");
            btnRestaurar.Location = new Point(634, 3);
            btnRestaurar.Name = "btnRestaurar";
            btnRestaurar.Size = new Size(32, 34);
            btnRestaurar.SizeMode = PictureBoxSizeMode.Zoom;
            btnRestaurar.TabIndex = 9;
            btnRestaurar.TabStop = false;
            btnRestaurar.Visible = false;
            btnRestaurar.Click += btnRestaurar_Click;
            // 
            // LoginForm
            // 
            AutoScaleDimensions = new SizeF(8F, 20F);
            AutoScaleMode = AutoScaleMode.Font;
            BackColor = Color.FromArgb(49, 66, 82);
            ClientSize = new Size(704, 367);
            Controls.Add(btnRestaurar);
            Controls.Add(btnMinimizar);
            Controls.Add(btnMaximizar);
            Controls.Add(btnCerrar);
            Controls.Add(btnCargar);
            Controls.Add(label2);
            Controls.Add(label1);
            Controls.Add(txtPassword);
            Controls.Add(txtxUserName);
            FormBorderStyle = FormBorderStyle.None;
            Name = "LoginForm";
            StartPosition = FormStartPosition.CenterScreen;
            Text = "LoginForm";
            Load += LoginForm_Load;
            ((System.ComponentModel.ISupportInitialize)btnCerrar).EndInit();
            ((System.ComponentModel.ISupportInitialize)btnMaximizar).EndInit();
            ((System.ComponentModel.ISupportInitialize)btnMinimizar).EndInit();
            ((System.ComponentModel.ISupportInitialize)btnRestaurar).EndInit();
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private TextBox txtxUserName;
        private TextBox txtPassword;
        private Label label1;
        private Label label2;
        private Button btnCargar;
        private PictureBox btnCerrar;
        private PictureBox btnMaximizar;
        private PictureBox btnMinimizar;
        private PictureBox btnRestaurar;
    }
}