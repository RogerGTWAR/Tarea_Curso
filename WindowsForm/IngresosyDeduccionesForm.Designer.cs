namespace WindowsForm
{
    partial class IngresosyDeduccionesForm
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
            label1 = new Label();
            TxtNombre = new TextBox();
            TxtApellido = new TextBox();
            CbEmpleados_Id = new ComboBox();
            label4 = new Label();
            label8 = new Label();
            label9 = new Label();
            TxtSalarioBruto = new TextBox();
            label10 = new Label();
            label11 = new Label();
            dtpInicio = new DateTimePicker();
            dtpFin = new DateTimePicker();
            btnEliminar = new Button();
            dgvIngresos = new DataGridView();
            btnActualizar = new Button();
            label13 = new Label();
            TxtSalarioMensual = new TextBox();
            label15 = new Label();
            TxtAntiguedad = new TextBox();
            label16 = new Label();
            TxtHorasExtras = new TextBox();
            TxtPagoHorasExtras = new TextBox();
            label2 = new Label();
            label5 = new Label();
            label6 = new Label();
            btnAgregar = new Button();
            label3 = new Label();
            TxtAnticipoSalarial = new TextBox();
            TxtOtrasDeducciones = new TextBox();
            TxtIR = new TextBox();
            TxtINSS = new TextBox();
            TxtSalarioNeto = new TextBox();
            label7 = new Label();
            label12 = new Label();
            label14 = new Label();
            label17 = new Label();
            label18 = new Label();
            TxtRiesgoLaboral = new TextBox();
            TxtNoctabilidad = new TextBox();
            rdSi = new RadioButton();
            groupBox1 = new GroupBox();
            rdNo = new RadioButton();
            groupBox2 = new GroupBox();
            rbNo = new RadioButton();
            rbSi = new RadioButton();
            TxtOtrosIngresos = new TextBox();
            label19 = new Label();
            btnExcel = new Button();
            ((System.ComponentModel.ISupportInitialize)dgvIngresos).BeginInit();
            groupBox1.SuspendLayout();
            groupBox2.SuspendLayout();
            SuspendLayout();
            // 
            // label1
            // 
            label1.AutoSize = true;
            label1.BackColor = Color.FromArgb(49, 66, 82);
            label1.Font = new Font("Century Gothic", 13.8F, FontStyle.Bold, GraphicsUnit.Point, 0);
            label1.ForeColor = Color.White;
            label1.Location = new Point(662, 136);
            label1.Name = "label1";
            label1.Size = new Size(198, 27);
            label1.TabIndex = 2;
            label1.Text = "ID Del Empleado";
            // 
            // TxtNombre
            // 
            TxtNombre.Enabled = false;
            TxtNombre.Font = new Font("Century Gothic", 10.2F, FontStyle.Regular, GraphicsUnit.Point, 0);
            TxtNombre.Location = new Point(1225, 131);
            TxtNombre.Name = "TxtNombre";
            TxtNombre.Size = new Size(141, 28);
            TxtNombre.TabIndex = 4;
            // 
            // TxtApellido
            // 
            TxtApellido.Enabled = false;
            TxtApellido.Font = new Font("Century Gothic", 10.2F, FontStyle.Regular, GraphicsUnit.Point, 0);
            TxtApellido.Location = new Point(1589, 130);
            TxtApellido.Name = "TxtApellido";
            TxtApellido.Size = new Size(141, 28);
            TxtApellido.TabIndex = 5;
            // 
            // CbEmpleados_Id
            // 
            CbEmpleados_Id.Font = new Font("Century Gothic", 10.2F, FontStyle.Regular, GraphicsUnit.Point, 0);
            CbEmpleados_Id.FormattingEnabled = true;
            CbEmpleados_Id.Location = new Point(882, 135);
            CbEmpleados_Id.Name = "CbEmpleados_Id";
            CbEmpleados_Id.Size = new Size(141, 29);
            CbEmpleados_Id.TabIndex = 8;
            CbEmpleados_Id.SelectedIndexChanged += CbEmpleados_Id_SelectedIndexChanged;
            // 
            // label4
            // 
            label4.AutoSize = true;
            label4.BackColor = Color.FromArgb(49, 66, 82);
            label4.Font = new Font("Century Gothic", 13.8F, FontStyle.Bold, GraphicsUnit.Point, 0);
            label4.ForeColor = Color.White;
            label4.Location = new Point(675, 515);
            label4.Name = "label4";
            label4.Size = new Size(150, 27);
            label4.TabIndex = 10;
            label4.Text = "Salario Bruto";
            // 
            // label8
            // 
            label8.AutoSize = true;
            label8.BackColor = Color.FromArgb(49, 66, 82);
            label8.Font = new Font("Century Gothic", 13.8F, FontStyle.Bold, GraphicsUnit.Point, 0);
            label8.ForeColor = Color.White;
            label8.Location = new Point(1400, 131);
            label8.Name = "label8";
            label8.Size = new Size(183, 27);
            label8.TabIndex = 14;
            label8.Text = "Primer Apellido";
            // 
            // label9
            // 
            label9.AutoSize = true;
            label9.BackColor = Color.FromArgb(49, 66, 82);
            label9.Font = new Font("Century Gothic", 13.8F, FontStyle.Bold, GraphicsUnit.Point, 0);
            label9.ForeColor = Color.White;
            label9.Location = new Point(1046, 137);
            label9.Name = "label9";
            label9.Size = new Size(179, 27);
            label9.TabIndex = 15;
            label9.Text = "Primer Nombre";
            // 
            // TxtSalarioBruto
            // 
            TxtSalarioBruto.Enabled = false;
            TxtSalarioBruto.Font = new Font("Century Gothic", 10.2F, FontStyle.Regular, GraphicsUnit.Point, 0);
            TxtSalarioBruto.Location = new Point(662, 554);
            TxtSalarioBruto.Name = "TxtSalarioBruto";
            TxtSalarioBruto.Size = new Size(177, 28);
            TxtSalarioBruto.TabIndex = 18;
            // 
            // label10
            // 
            label10.AutoSize = true;
            label10.BackColor = Color.FromArgb(49, 66, 82);
            label10.Font = new Font("Century Gothic", 13.8F, FontStyle.Bold, GraphicsUnit.Point, 0);
            label10.ForeColor = Color.White;
            label10.Location = new Point(1198, 191);
            label10.Name = "label10";
            label10.Size = new Size(177, 27);
            label10.TabIndex = 25;
            label10.Text = "Fin del Periodo";
            // 
            // label11
            // 
            label11.AutoSize = true;
            label11.BackColor = Color.FromArgb(49, 66, 82);
            label11.Font = new Font("Century Gothic", 13.8F, FontStyle.Bold, GraphicsUnit.Point, 0);
            label11.ForeColor = Color.White;
            label11.Location = new Point(781, 195);
            label11.Name = "label11";
            label11.Size = new Size(208, 27);
            label11.TabIndex = 26;
            label11.Text = "Inicio del Periodo";
            // 
            // dtpInicio
            // 
            dtpInicio.Font = new Font("Century Gothic", 10.2F, FontStyle.Bold, GraphicsUnit.Point, 0);
            dtpInicio.Format = DateTimePickerFormat.Short;
            dtpInicio.Location = new Point(999, 195);
            dtpInicio.Name = "dtpInicio";
            dtpInicio.Size = new Size(150, 28);
            dtpInicio.TabIndex = 27;
            dtpInicio.ValueChanged += dtpInicio_ValueChanged;
            // 
            // dtpFin
            // 
            dtpFin.Font = new Font("Century Gothic", 10.2F, FontStyle.Bold, GraphicsUnit.Point, 0);
            dtpFin.Format = DateTimePickerFormat.Short;
            dtpFin.Location = new Point(1391, 190);
            dtpFin.Name = "dtpFin";
            dtpFin.Size = new Size(150, 28);
            dtpFin.TabIndex = 28;
            // 
            // btnEliminar
            // 
            btnEliminar.BackColor = Color.SeaGreen;
            btnEliminar.FlatStyle = FlatStyle.Popup;
            btnEliminar.Font = new Font("Segoe UI", 14.25F, FontStyle.Bold, GraphicsUnit.Point, 0);
            btnEliminar.Location = new Point(1055, 642);
            btnEliminar.Margin = new Padding(3, 4, 3, 4);
            btnEliminar.Name = "btnEliminar";
            btnEliminar.Size = new Size(121, 45);
            btnEliminar.TabIndex = 29;
            btnEliminar.Text = "Eliminar";
            btnEliminar.UseVisualStyleBackColor = false;
            btnEliminar.Click += btnEliminar_Click;
            // 
            // dgvIngresos
            // 
            dgvIngresos.BackgroundColor = SystemColors.ControlLightLight;
            dgvIngresos.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            dgvIngresos.Location = new Point(295, 694);
            dgvIngresos.Name = "dgvIngresos";
            dgvIngresos.ReadOnly = true;
            dgvIngresos.RowHeadersWidth = 51;
            dgvIngresos.SelectionMode = DataGridViewSelectionMode.FullRowSelect;
            dgvIngresos.Size = new Size(1610, 219);
            dgvIngresos.TabIndex = 30;
            dgvIngresos.CellContentClick += dgvIngresos_CellContentClick;
            // 
            // btnActualizar
            // 
            btnActualizar.BackColor = Color.SeaGreen;
            btnActualizar.FlatStyle = FlatStyle.Popup;
            btnActualizar.Font = new Font("Segoe UI", 14.25F, FontStyle.Bold, GraphicsUnit.Point, 0);
            btnActualizar.Location = new Point(1491, 642);
            btnActualizar.Margin = new Padding(3, 4, 3, 4);
            btnActualizar.Name = "btnActualizar";
            btnActualizar.Size = new Size(150, 45);
            btnActualizar.TabIndex = 32;
            btnActualizar.Text = "Actualizar";
            btnActualizar.UseVisualStyleBackColor = false;
            btnActualizar.Click += btnActualizar_Click;
            // 
            // label13
            // 
            label13.AutoSize = true;
            label13.BackColor = Color.FromArgb(49, 66, 82);
            label13.Font = new Font("Century Gothic", 13.8F, FontStyle.Bold, GraphicsUnit.Point, 0);
            label13.ForeColor = Color.White;
            label13.Location = new Point(295, 316);
            label13.Name = "label13";
            label13.Size = new Size(189, 27);
            label13.TabIndex = 34;
            label13.Text = "Salario Mensual";
            // 
            // TxtSalarioMensual
            // 
            TxtSalarioMensual.Enabled = false;
            TxtSalarioMensual.Font = new Font("Century Gothic", 10.2F, FontStyle.Regular, GraphicsUnit.Point, 0);
            TxtSalarioMensual.Location = new Point(506, 311);
            TxtSalarioMensual.Name = "TxtSalarioMensual";
            TxtSalarioMensual.Size = new Size(177, 28);
            TxtSalarioMensual.TabIndex = 35;
            // 
            // label15
            // 
            label15.AutoSize = true;
            label15.BackColor = Color.FromArgb(49, 66, 82);
            label15.Font = new Font("Century Gothic", 13.8F, FontStyle.Bold, GraphicsUnit.Point, 0);
            label15.ForeColor = Color.White;
            label15.Location = new Point(325, 370);
            label15.Name = "label15";
            label15.Size = new Size(145, 27);
            label15.TabIndex = 37;
            label15.Text = "Antiguedad";
            // 
            // TxtAntiguedad
            // 
            TxtAntiguedad.Enabled = false;
            TxtAntiguedad.Font = new Font("Century Gothic", 10.2F, FontStyle.Regular, GraphicsUnit.Point, 0);
            TxtAntiguedad.Location = new Point(506, 372);
            TxtAntiguedad.Name = "TxtAntiguedad";
            TxtAntiguedad.Size = new Size(177, 28);
            TxtAntiguedad.TabIndex = 38;
            // 
            // label16
            // 
            label16.AutoSize = true;
            label16.BackColor = Color.FromArgb(49, 66, 82);
            label16.Font = new Font("Century Gothic", 13.8F, FontStyle.Bold, GraphicsUnit.Point, 0);
            label16.ForeColor = Color.White;
            label16.Location = new Point(749, 311);
            label16.Name = "label16";
            label16.Size = new Size(145, 27);
            label16.TabIndex = 39;
            label16.Text = "Horas Extras";
            // 
            // TxtHorasExtras
            // 
            TxtHorasExtras.Enabled = false;
            TxtHorasExtras.Font = new Font("Century Gothic", 10.2F, FontStyle.Regular, GraphicsUnit.Point, 0);
            TxtHorasExtras.Location = new Point(959, 311);
            TxtHorasExtras.Name = "TxtHorasExtras";
            TxtHorasExtras.Size = new Size(177, 28);
            TxtHorasExtras.TabIndex = 40;
            // 
            // TxtPagoHorasExtras
            // 
            TxtPagoHorasExtras.Enabled = false;
            TxtPagoHorasExtras.Font = new Font("Century Gothic", 10.2F, FontStyle.Regular, GraphicsUnit.Point, 0);
            TxtPagoHorasExtras.Location = new Point(959, 370);
            TxtPagoHorasExtras.Name = "TxtPagoHorasExtras";
            TxtPagoHorasExtras.Size = new Size(177, 28);
            TxtPagoHorasExtras.TabIndex = 41;
            // 
            // label2
            // 
            label2.AutoSize = true;
            label2.BackColor = Color.FromArgb(49, 66, 82);
            label2.Font = new Font("Century Gothic", 13.8F, FontStyle.Bold, GraphicsUnit.Point, 0);
            label2.ForeColor = Color.White;
            label2.Location = new Point(708, 372);
            label2.Name = "label2";
            label2.Size = new Size(245, 27);
            label2.TabIndex = 42;
            label2.Text = "Pago de Horas Extras";
            // 
            // label5
            // 
            label5.AutoSize = true;
            label5.BackColor = Color.FromArgb(49, 66, 82);
            label5.Font = new Font("Century Gothic", 16.2F, FontStyle.Bold, GraphicsUnit.Point, 0);
            label5.ForeColor = Color.White;
            label5.Location = new Point(675, 250);
            label5.Name = "label5";
            label5.Size = new Size(127, 34);
            label5.TabIndex = 43;
            label5.Text = "Ingresos";
            // 
            // label6
            // 
            label6.AutoSize = true;
            label6.BackColor = Color.FromArgb(49, 66, 82);
            label6.Font = new Font("Century Gothic", 16.2F, FontStyle.Bold, GraphicsUnit.Point, 0);
            label6.ForeColor = Color.White;
            label6.Location = new Point(1072, 78);
            label6.Name = "label6";
            label6.Size = new Size(153, 34);
            label6.TabIndex = 44;
            label6.Text = "Empleado";
            // 
            // btnAgregar
            // 
            btnAgregar.BackColor = Color.SeaGreen;
            btnAgregar.FlatStyle = FlatStyle.Popup;
            btnAgregar.Font = new Font("Segoe UI", 14.25F, FontStyle.Bold, GraphicsUnit.Point, 0);
            btnAgregar.Location = new Point(623, 642);
            btnAgregar.Margin = new Padding(3, 4, 3, 4);
            btnAgregar.Name = "btnAgregar";
            btnAgregar.Size = new Size(121, 45);
            btnAgregar.TabIndex = 49;
            btnAgregar.Text = "Agregar";
            btnAgregar.UseVisualStyleBackColor = false;
            btnAgregar.Click += btnAgregar_Click;
            // 
            // label3
            // 
            label3.AutoSize = true;
            label3.BackColor = Color.FromArgb(49, 66, 82);
            label3.Font = new Font("Century Gothic", 16.2F, FontStyle.Bold, GraphicsUnit.Point, 0);
            label3.ForeColor = Color.White;
            label3.Location = new Point(1387, 250);
            label3.Name = "label3";
            label3.Size = new Size(196, 34);
            label3.TabIndex = 51;
            label3.Text = "Deducciones";
            // 
            // TxtAnticipoSalarial
            // 
            TxtAnticipoSalarial.Font = new Font("Century Gothic", 10.2F, FontStyle.Regular, GraphicsUnit.Point, 0);
            TxtAnticipoSalarial.Location = new Point(1728, 362);
            TxtAnticipoSalarial.Name = "TxtAnticipoSalarial";
            TxtAnticipoSalarial.Size = new Size(177, 28);
            TxtAnticipoSalarial.TabIndex = 52;
            TxtAnticipoSalarial.TextChanged += TxtAnticipoSalarial_TextChanged;
            // 
            // TxtOtrasDeducciones
            // 
            TxtOtrasDeducciones.Font = new Font("Century Gothic", 10.2F, FontStyle.Regular, GraphicsUnit.Point, 0);
            TxtOtrasDeducciones.Location = new Point(1728, 303);
            TxtOtrasDeducciones.Name = "TxtOtrasDeducciones";
            TxtOtrasDeducciones.Size = new Size(177, 28);
            TxtOtrasDeducciones.TabIndex = 53;
            TxtOtrasDeducciones.TextChanged += TxtOtrasDeducciones_TextChanged;
            // 
            // TxtIR
            // 
            TxtIR.Enabled = false;
            TxtIR.Font = new Font("Century Gothic", 10.2F, FontStyle.Regular, GraphicsUnit.Point, 0);
            TxtIR.Location = new Point(1273, 367);
            TxtIR.Name = "TxtIR";
            TxtIR.Size = new Size(177, 28);
            TxtIR.TabIndex = 54;
            // 
            // TxtINSS
            // 
            TxtINSS.Enabled = false;
            TxtINSS.Font = new Font("Century Gothic", 10.2F, FontStyle.Regular, GraphicsUnit.Point, 0);
            TxtINSS.Location = new Point(1273, 306);
            TxtINSS.Name = "TxtINSS";
            TxtINSS.Size = new Size(177, 28);
            TxtINSS.TabIndex = 55;
            // 
            // TxtSalarioNeto
            // 
            TxtSalarioNeto.Enabled = false;
            TxtSalarioNeto.Font = new Font("Century Gothic", 10.2F, FontStyle.Regular, GraphicsUnit.Point, 0);
            TxtSalarioNeto.Location = new Point(1495, 470);
            TxtSalarioNeto.Name = "TxtSalarioNeto";
            TxtSalarioNeto.Size = new Size(177, 28);
            TxtSalarioNeto.TabIndex = 56;
            // 
            // label7
            // 
            label7.AutoSize = true;
            label7.BackColor = Color.FromArgb(49, 66, 82);
            label7.Font = new Font("Century Gothic", 13.8F, FontStyle.Bold, GraphicsUnit.Point, 0);
            label7.ForeColor = Color.White;
            label7.Location = new Point(1491, 304);
            label7.Name = "label7";
            label7.Size = new Size(226, 27);
            label7.TabIndex = 57;
            label7.Text = "Otras Deducciones";
            // 
            // label12
            // 
            label12.AutoSize = true;
            label12.BackColor = Color.FromArgb(49, 66, 82);
            label12.Font = new Font("Century Gothic", 13.8F, FontStyle.Bold, GraphicsUnit.Point, 0);
            label12.ForeColor = Color.White;
            label12.Location = new Point(1212, 367);
            label12.Name = "label12";
            label12.Size = new Size(31, 27);
            label12.TabIndex = 58;
            label12.Text = "IR";
            // 
            // label14
            // 
            label14.AutoSize = true;
            label14.BackColor = Color.FromArgb(49, 66, 82);
            label14.Font = new Font("Century Gothic", 13.8F, FontStyle.Bold, GraphicsUnit.Point, 0);
            label14.ForeColor = Color.White;
            label14.Location = new Point(1198, 305);
            label14.Name = "label14";
            label14.Size = new Size(59, 27);
            label14.TabIndex = 59;
            label14.Text = "INSS";
            // 
            // label17
            // 
            label17.AutoSize = true;
            label17.BackColor = Color.FromArgb(49, 66, 82);
            label17.Font = new Font("Century Gothic", 13.8F, FontStyle.Bold, GraphicsUnit.Point, 0);
            label17.ForeColor = Color.White;
            label17.Location = new Point(1341, 471);
            label17.Name = "label17";
            label17.Size = new Size(148, 27);
            label17.TabIndex = 60;
            label17.Text = "Salario Neto";
            // 
            // label18
            // 
            label18.AutoSize = true;
            label18.BackColor = Color.FromArgb(49, 66, 82);
            label18.Font = new Font("Century Gothic", 13.8F, FontStyle.Bold, GraphicsUnit.Point, 0);
            label18.ForeColor = Color.White;
            label18.Location = new Point(1501, 368);
            label18.Name = "label18";
            label18.Size = new Size(195, 27);
            label18.TabIndex = 61;
            label18.Text = "Anticipo Salarial";
            // 
            // TxtRiesgoLaboral
            // 
            TxtRiesgoLaboral.Enabled = false;
            TxtRiesgoLaboral.Font = new Font("Century Gothic", 10.2F, FontStyle.Regular, GraphicsUnit.Point, 0);
            TxtRiesgoLaboral.Location = new Point(51, 71);
            TxtRiesgoLaboral.Name = "TxtRiesgoLaboral";
            TxtRiesgoLaboral.Size = new Size(177, 28);
            TxtRiesgoLaboral.TabIndex = 64;
            // 
            // TxtNoctabilidad
            // 
            TxtNoctabilidad.Enabled = false;
            TxtNoctabilidad.Font = new Font("Century Gothic", 10.2F, FontStyle.Regular, GraphicsUnit.Point, 0);
            TxtNoctabilidad.Location = new Point(49, 72);
            TxtNoctabilidad.Name = "TxtNoctabilidad";
            TxtNoctabilidad.Size = new Size(177, 28);
            TxtNoctabilidad.TabIndex = 69;
            // 
            // rdSi
            // 
            rdSi.AutoSize = true;
            rdSi.Font = new Font("Century Gothic", 12F, FontStyle.Bold, GraphicsUnit.Point, 0);
            rdSi.ForeColor = Color.White;
            rdSi.Location = new Point(63, 38);
            rdSi.Name = "rdSi";
            rdSi.Size = new Size(46, 27);
            rdSi.TabIndex = 70;
            rdSi.TabStop = true;
            rdSi.Text = "Si";
            rdSi.UseVisualStyleBackColor = true;
            rdSi.CheckedChanged += rdSi_CheckedChanged;
            // 
            // groupBox1
            // 
            groupBox1.Controls.Add(rdNo);
            groupBox1.Controls.Add(rdSi);
            groupBox1.Controls.Add(TxtRiesgoLaboral);
            groupBox1.Font = new Font("Century Gothic", 13.8F, FontStyle.Bold, GraphicsUnit.Point, 0);
            groupBox1.ForeColor = Color.White;
            groupBox1.Location = new Point(295, 433);
            groupBox1.Name = "groupBox1";
            groupBox1.Size = new Size(310, 125);
            groupBox1.TabIndex = 71;
            groupBox1.TabStop = false;
            groupBox1.Text = "Seguro de Riesgo Laboral";
            // 
            // rdNo
            // 
            rdNo.AutoSize = true;
            rdNo.Font = new Font("Century Gothic", 12F, FontStyle.Bold, GraphicsUnit.Point, 0);
            rdNo.ForeColor = Color.White;
            rdNo.Location = new Point(154, 39);
            rdNo.Name = "rdNo";
            rdNo.Size = new Size(59, 27);
            rdNo.TabIndex = 71;
            rdNo.TabStop = true;
            rdNo.Text = "No";
            rdNo.UseVisualStyleBackColor = true;
            rdNo.CheckedChanged += rdNo_CheckedChanged;
            // 
            // groupBox2
            // 
            groupBox2.Controls.Add(rbNo);
            groupBox2.Controls.Add(rbSi);
            groupBox2.Controls.Add(TxtNoctabilidad);
            groupBox2.Font = new Font("Century Gothic", 13.8F, FontStyle.Bold, GraphicsUnit.Point, 0);
            groupBox2.ForeColor = Color.White;
            groupBox2.Location = new Point(879, 433);
            groupBox2.Name = "groupBox2";
            groupBox2.Size = new Size(270, 125);
            groupBox2.TabIndex = 72;
            groupBox2.TabStop = false;
            groupBox2.Text = "Turno de Nocturnidad";
            // 
            // rbNo
            // 
            rbNo.AutoSize = true;
            rbNo.Font = new Font("Century Gothic", 12F, FontStyle.Bold, GraphicsUnit.Point, 0);
            rbNo.ForeColor = Color.White;
            rbNo.Location = new Point(142, 39);
            rbNo.Name = "rbNo";
            rbNo.Size = new Size(59, 27);
            rbNo.TabIndex = 72;
            rbNo.TabStop = true;
            rbNo.Text = "No";
            rbNo.UseVisualStyleBackColor = true;
            rbNo.CheckedChanged += rbNo_CheckedChanged_1;
            // 
            // rbSi
            // 
            rbSi.AutoSize = true;
            rbSi.Font = new Font("Century Gothic", 12F, FontStyle.Bold, GraphicsUnit.Point, 0);
            rbSi.ForeColor = Color.White;
            rbSi.Location = new Point(67, 39);
            rbSi.Name = "rbSi";
            rbSi.Size = new Size(46, 27);
            rbSi.TabIndex = 70;
            rbSi.TabStop = true;
            rbSi.Text = "Si";
            rbSi.UseVisualStyleBackColor = true;
            rbSi.CheckedChanged += rbSi_CheckedChanged;
            // 
            // TxtOtrosIngresos
            // 
            TxtOtrosIngresos.Font = new Font("Century Gothic", 10.2F, FontStyle.Regular, GraphicsUnit.Point, 0);
            TxtOtrosIngresos.Location = new Point(662, 470);
            TxtOtrosIngresos.Name = "TxtOtrosIngresos";
            TxtOtrosIngresos.Size = new Size(177, 28);
            TxtOtrosIngresos.TabIndex = 73;
            TxtOtrosIngresos.TextChanged += TxtOtrosIngresos_TextChanged;
            // 
            // label19
            // 
            label19.AutoSize = true;
            label19.BackColor = Color.FromArgb(49, 66, 82);
            label19.Font = new Font("Century Gothic", 13.8F, FontStyle.Bold, GraphicsUnit.Point, 0);
            label19.ForeColor = Color.White;
            label19.Location = new Point(662, 440);
            label19.Name = "label19";
            label19.Size = new Size(168, 27);
            label19.TabIndex = 74;
            label19.Text = "Otros Ingresos";
            // 
            // btnExcel
            // 
            btnExcel.BackColor = Color.SeaGreen;
            btnExcel.FlatStyle = FlatStyle.Popup;
            btnExcel.Font = new Font("Segoe UI", 14.25F, FontStyle.Bold, GraphicsUnit.Point, 0);
            btnExcel.Location = new Point(295, 642);
            btnExcel.Margin = new Padding(3, 4, 3, 4);
            btnExcel.Name = "btnExcel";
            btnExcel.Size = new Size(121, 45);
            btnExcel.TabIndex = 75;
            btnExcel.Text = "Excel";
            btnExcel.UseVisualStyleBackColor = false;
            btnExcel.Click += btnExcel_Click;
            // 
            // IngresosyDeduccionesForm
            // 
            AutoScaleDimensions = new SizeF(8F, 20F);
            AutoScaleMode = AutoScaleMode.Font;
            BackColor = Color.FromArgb(49, 66, 82);
            ClientSize = new Size(1919, 1005);
            Controls.Add(btnExcel);
            Controls.Add(label19);
            Controls.Add(TxtOtrosIngresos);
            Controls.Add(groupBox2);
            Controls.Add(groupBox1);
            Controls.Add(label18);
            Controls.Add(label17);
            Controls.Add(label14);
            Controls.Add(label12);
            Controls.Add(label7);
            Controls.Add(TxtSalarioNeto);
            Controls.Add(TxtINSS);
            Controls.Add(TxtIR);
            Controls.Add(TxtOtrasDeducciones);
            Controls.Add(TxtAnticipoSalarial);
            Controls.Add(label3);
            Controls.Add(btnAgregar);
            Controls.Add(label6);
            Controls.Add(label5);
            Controls.Add(label2);
            Controls.Add(TxtPagoHorasExtras);
            Controls.Add(TxtHorasExtras);
            Controls.Add(label16);
            Controls.Add(TxtAntiguedad);
            Controls.Add(label15);
            Controls.Add(TxtSalarioMensual);
            Controls.Add(label13);
            Controls.Add(btnActualizar);
            Controls.Add(dgvIngresos);
            Controls.Add(btnEliminar);
            Controls.Add(dtpFin);
            Controls.Add(dtpInicio);
            Controls.Add(label11);
            Controls.Add(label10);
            Controls.Add(TxtSalarioBruto);
            Controls.Add(label9);
            Controls.Add(label8);
            Controls.Add(label4);
            Controls.Add(CbEmpleados_Id);
            Controls.Add(TxtApellido);
            Controls.Add(TxtNombre);
            Controls.Add(label1);
            Name = "IngresosyDeduccionesForm";
            StartPosition = FormStartPosition.CenterParent;
            Text = "Deducciones";
            Load += IngresosForm_Load;
            ((System.ComponentModel.ISupportInitialize)dgvIngresos).EndInit();
            groupBox1.ResumeLayout(false);
            groupBox1.PerformLayout();
            groupBox2.ResumeLayout(false);
            groupBox2.PerformLayout();
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion
        private Label label1;
        private TextBox TxtNombre;
        private TextBox TxtApellido;
        private ComboBox CbEmpleados_Id;
        private Label label4;
        private Label label8;
        private Label label9;
        private TextBox TxtSalarioBruto;
        private Label label10;
        private Label label11;
        private DateTimePicker dtpInicio;
        private DateTimePicker dtpFin;
        private Button btnEliminar;
        private DataGridView dgvIngresos;
        private Button btnActualizar;
        private Label label13;
        private TextBox TxtSalarioMensual;
        private Label label15;
        private TextBox TxtAntiguedad;
        private Label label16;
        private TextBox TxtHorasExtras;
        private TextBox TxtPagoHorasExtras;
        private Label label2;
        private Label label5;
        private Label label6;
        private Button btnAgregar;
        private Label label3;
        private TextBox TxtAnticipoSalarial;
        private TextBox TxtOtrasDeducciones;
        private TextBox TxtIR;
        private TextBox TxtINSS;
        private TextBox TxtSalarioNeto;
        private Label label7;
        private Label label12;
        private Label label14;
        private Label label17;
        private Label label18;
        private TextBox TxtRiesgoLaboral;
        private Label label20;
        private CheckBox chknoNoctabilidad;
        private CheckBox chkSiNoctabilidad;
        private TextBox TxtNoctabilidad;
        private RadioButton rdSi;
        private GroupBox groupBox1;
        private RadioButton rdNo;
        private GroupBox groupBox2;
        private RadioButton radioButton1;
        private RadioButton rbSi;
        private TextBox TxtOtrosIngresos;
        private RadioButton rbNo;
        private Label label19;
        private Button btnExcel;
    }
}