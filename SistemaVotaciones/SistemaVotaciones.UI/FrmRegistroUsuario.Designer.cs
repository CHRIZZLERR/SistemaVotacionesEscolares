namespace SistemaVotaciones.UI
{
    partial class FrmRegistroUsuario
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
            this.txtMatricula = new System.Windows.Forms.TextBox();
            this.txtNombre = new System.Windows.Forms.TextBox();
            this.txtUsuario = new System.Windows.Forms.TextBox();
            this.txtPassword = new System.Windows.Forms.TextBox();
            this.lblMatricula = new System.Windows.Forms.Label();
            this.lblNombre = new System.Windows.Forms.Label();
            this.lblUsuario = new System.Windows.Forms.Label();
            this.lblPassword = new System.Windows.Forms.Label();
            this.cmbNivel = new System.Windows.Forms.ComboBox();
            this.cmbGrado = new System.Windows.Forms.ComboBox();
            this.cmbSeccion = new System.Windows.Forms.ComboBox();
            this.cmbModalidad = new System.Windows.Forms.ComboBox();
            this.btnRegistrar = new System.Windows.Forms.Button();
            this.lblNivel = new System.Windows.Forms.Label();
            this.lblGrado = new System.Windows.Forms.Label();
            this.lblSeccion = new System.Windows.Forms.Label();
            this.lblModalidad = new System.Windows.Forms.Label();
            this.btnRegresar = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // txtMatricula
            // 
            this.txtMatricula.Font = new System.Drawing.Font("Glacial Indifference", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtMatricula.Location = new System.Drawing.Point(203, 66);
            this.txtMatricula.Multiline = true;
            this.txtMatricula.Name = "txtMatricula";
            this.txtMatricula.Size = new System.Drawing.Size(171, 47);
            this.txtMatricula.TabIndex = 0;
            this.txtMatricula.TextChanged += new System.EventHandler(this.txtMatricula_TextChanged);
            // 
            // txtNombre
            // 
            this.txtNombre.Font = new System.Drawing.Font("Glacial Indifference", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtNombre.Location = new System.Drawing.Point(203, 190);
            this.txtNombre.Multiline = true;
            this.txtNombre.Name = "txtNombre";
            this.txtNombre.Size = new System.Drawing.Size(171, 47);
            this.txtNombre.TabIndex = 1;
            this.txtNombre.TextChanged += new System.EventHandler(this.txtNombre_TextChanged);
            // 
            // txtUsuario
            // 
            this.txtUsuario.Font = new System.Drawing.Font("Glacial Indifference", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtUsuario.Location = new System.Drawing.Point(203, 304);
            this.txtUsuario.Multiline = true;
            this.txtUsuario.Name = "txtUsuario";
            this.txtUsuario.Size = new System.Drawing.Size(171, 47);
            this.txtUsuario.TabIndex = 2;
            this.txtUsuario.TextChanged += new System.EventHandler(this.textBox3_TextChanged);
            // 
            // txtPassword
            // 
            this.txtPassword.Font = new System.Drawing.Font("Glacial Indifference", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtPassword.Location = new System.Drawing.Point(203, 408);
            this.txtPassword.Multiline = true;
            this.txtPassword.Name = "txtPassword";
            this.txtPassword.Size = new System.Drawing.Size(171, 47);
            this.txtPassword.TabIndex = 3;
            this.txtPassword.TextChanged += new System.EventHandler(this.textBox4_TextChanged);
            // 
            // lblMatricula
            // 
            this.lblMatricula.AutoSize = true;
            this.lblMatricula.Font = new System.Drawing.Font("Glacial Indifference", 14F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblMatricula.Location = new System.Drawing.Point(2, 84);
            this.lblMatricula.Name = "lblMatricula";
            this.lblMatricula.Size = new System.Drawing.Size(135, 34);
            this.lblMatricula.TabIndex = 4;
            this.lblMatricula.Text = "Matricula:";
            this.lblMatricula.Click += new System.EventHandler(this.lblMatricula_Click);
            // 
            // lblNombre
            // 
            this.lblNombre.AutoSize = true;
            this.lblNombre.Font = new System.Drawing.Font("Glacial Indifference", 14F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblNombre.Location = new System.Drawing.Point(2, 208);
            this.lblNombre.Name = "lblNombre";
            this.lblNombre.Size = new System.Drawing.Size(115, 34);
            this.lblNombre.TabIndex = 5;
            this.lblNombre.Text = "Nombre:";
            this.lblNombre.Click += new System.EventHandler(this.lblNombre_Click);
            // 
            // lblUsuario
            // 
            this.lblUsuario.AutoSize = true;
            this.lblUsuario.Font = new System.Drawing.Font("Glacial Indifference", 14F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblUsuario.Location = new System.Drawing.Point(2, 322);
            this.lblUsuario.Name = "lblUsuario";
            this.lblUsuario.Size = new System.Drawing.Size(111, 34);
            this.lblUsuario.TabIndex = 6;
            this.lblUsuario.Text = "Usuario:";
            this.lblUsuario.Click += new System.EventHandler(this.lblUsuario_Click);
            // 
            // lblPassword
            // 
            this.lblPassword.AutoSize = true;
            this.lblPassword.Font = new System.Drawing.Font("Glacial Indifference", 14F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblPassword.Location = new System.Drawing.Point(2, 426);
            this.lblPassword.Name = "lblPassword";
            this.lblPassword.Size = new System.Drawing.Size(135, 34);
            this.lblPassword.TabIndex = 7;
            this.lblPassword.Text = "Password:";
            this.lblPassword.Click += new System.EventHandler(this.lblPassword_Click);
            // 
            // cmbNivel
            // 
            this.cmbNivel.Font = new System.Drawing.Font("Glacial Indifference", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.cmbNivel.FormattingEnabled = true;
            this.cmbNivel.Location = new System.Drawing.Point(96, 32);
            this.cmbNivel.Name = "cmbNivel";
            this.cmbNivel.Size = new System.Drawing.Size(278, 37);
            this.cmbNivel.TabIndex = 8;
            this.cmbNivel.SelectedIndexChanged += new System.EventHandler(this.cmbNivel_SelectedIndexChanged);
            // 
            // cmbGrado
            // 
            this.cmbGrado.Font = new System.Drawing.Font("Glacial Indifference", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.cmbGrado.FormattingEnabled = true;
            this.cmbGrado.Location = new System.Drawing.Point(104, 156);
            this.cmbGrado.Name = "cmbGrado";
            this.cmbGrado.Size = new System.Drawing.Size(270, 37);
            this.cmbGrado.TabIndex = 9;
            this.cmbGrado.SelectedIndexChanged += new System.EventHandler(this.cmbGrado_SelectedIndexChanged);
            // 
            // cmbSeccion
            // 
            this.cmbSeccion.Font = new System.Drawing.Font("Glacial Indifference", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.cmbSeccion.FormattingEnabled = true;
            this.cmbSeccion.Location = new System.Drawing.Point(124, 270);
            this.cmbSeccion.Name = "cmbSeccion";
            this.cmbSeccion.Size = new System.Drawing.Size(250, 37);
            this.cmbSeccion.TabIndex = 10;
            this.cmbSeccion.SelectedIndexChanged += new System.EventHandler(this.cmbSeccion_SelectedIndexChanged);
            // 
            // cmbModalidad
            // 
            this.cmbModalidad.Font = new System.Drawing.Font("Glacial Indifference", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.cmbModalidad.FormattingEnabled = true;
            this.cmbModalidad.Location = new System.Drawing.Point(157, 374);
            this.cmbModalidad.Name = "cmbModalidad";
            this.cmbModalidad.Size = new System.Drawing.Size(217, 37);
            this.cmbModalidad.TabIndex = 11;
            this.cmbModalidad.SelectedIndexChanged += new System.EventHandler(this.cmbModalidad_SelectedIndexChanged);
            // 
            // btnRegistrar
            // 
            this.btnRegistrar.Font = new System.Drawing.Font("Glacial Indifference", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnRegistrar.Location = new System.Drawing.Point(8, 499);
            this.btnRegistrar.Name = "btnRegistrar";
            this.btnRegistrar.Size = new System.Drawing.Size(158, 56);
            this.btnRegistrar.TabIndex = 12;
            this.btnRegistrar.Text = "Registrar";
            this.btnRegistrar.UseVisualStyleBackColor = true;
            this.btnRegistrar.Click += new System.EventHandler(this.btnRegistrar_Click);
            // 
            // lblNivel
            // 
            this.lblNivel.AutoSize = true;
            this.lblNivel.Font = new System.Drawing.Font("Glacial Indifference", 14F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblNivel.Location = new System.Drawing.Point(2, 31);
            this.lblNivel.Name = "lblNivel";
            this.lblNivel.Size = new System.Drawing.Size(88, 34);
            this.lblNivel.TabIndex = 13;
            this.lblNivel.Text = "Nivel:";
            this.lblNivel.Click += new System.EventHandler(this.lblNivel_Click);
            // 
            // lblGrado
            // 
            this.lblGrado.AutoSize = true;
            this.lblGrado.BackColor = System.Drawing.Color.Transparent;
            this.lblGrado.Font = new System.Drawing.Font("Glacial Indifference", 14F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblGrado.Location = new System.Drawing.Point(2, 161);
            this.lblGrado.Name = "lblGrado";
            this.lblGrado.Size = new System.Drawing.Size(107, 34);
            this.lblGrado.TabIndex = 14;
            this.lblGrado.Text = "Grado:";
            this.lblGrado.Click += new System.EventHandler(this.lblGrado_Click);
            // 
            // lblSeccion
            // 
            this.lblSeccion.AutoSize = true;
            this.lblSeccion.Font = new System.Drawing.Font("Glacial Indifference", 14F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblSeccion.Location = new System.Drawing.Point(2, 275);
            this.lblSeccion.Name = "lblSeccion";
            this.lblSeccion.Size = new System.Drawing.Size(128, 34);
            this.lblSeccion.TabIndex = 15;
            this.lblSeccion.Text = "Seccion:";
            this.lblSeccion.Click += new System.EventHandler(this.lblSeccion_Click);
            // 
            // lblModalidad
            // 
            this.lblModalidad.AutoSize = true;
            this.lblModalidad.Font = new System.Drawing.Font("Glacial Indifference", 14F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblModalidad.Location = new System.Drawing.Point(-1, 379);
            this.lblModalidad.Name = "lblModalidad";
            this.lblModalidad.Size = new System.Drawing.Size(167, 34);
            this.lblModalidad.TabIndex = 16;
            this.lblModalidad.Text = "Modalidad:";
            this.lblModalidad.Click += new System.EventHandler(this.lblModalidad_Click);
            // 
            // btnRegresar
            // 
            this.btnRegresar.Font = new System.Drawing.Font("Glacial Indifference", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnRegresar.Location = new System.Drawing.Point(203, 499);
            this.btnRegresar.Name = "btnRegresar";
            this.btnRegresar.Size = new System.Drawing.Size(171, 56);
            this.btnRegresar.TabIndex = 17;
            this.btnRegresar.Text = "Regresar";
            this.btnRegresar.UseVisualStyleBackColor = true;
            this.btnRegresar.Click += new System.EventHandler(this.btnRegresar_Click);
            // 
            // FrmRegistroUsuario
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(9F, 20F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(577, 567);
            this.Controls.Add(this.btnRegresar);
            this.Controls.Add(this.cmbModalidad);
            this.Controls.Add(this.cmbSeccion);
            this.Controls.Add(this.cmbGrado);
            this.Controls.Add(this.lblModalidad);
            this.Controls.Add(this.lblSeccion);
            this.Controls.Add(this.lblGrado);
            this.Controls.Add(this.lblNivel);
            this.Controls.Add(this.btnRegistrar);
            this.Controls.Add(this.cmbNivel);
            this.Controls.Add(this.lblPassword);
            this.Controls.Add(this.lblUsuario);
            this.Controls.Add(this.lblNombre);
            this.Controls.Add(this.lblMatricula);
            this.Controls.Add(this.txtPassword);
            this.Controls.Add(this.txtUsuario);
            this.Controls.Add(this.txtNombre);
            this.Controls.Add(this.txtMatricula);
            this.Name = "FrmRegistroUsuario";
            this.Text = "FrmRegistroUsuario";
            this.Load += new System.EventHandler(this.FrmRegistroUsuario_Load);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.TextBox txtMatricula;
        private System.Windows.Forms.TextBox txtNombre;
        private System.Windows.Forms.TextBox txtUsuario;
        private System.Windows.Forms.TextBox txtPassword;
        private System.Windows.Forms.Label lblMatricula;
        private System.Windows.Forms.Label lblNombre;
        private System.Windows.Forms.Label lblUsuario;
        private System.Windows.Forms.Label lblPassword;
        private System.Windows.Forms.ComboBox cmbNivel;
        private System.Windows.Forms.ComboBox cmbGrado;
        private System.Windows.Forms.ComboBox cmbSeccion;
        private System.Windows.Forms.ComboBox cmbModalidad;
        private System.Windows.Forms.Button btnRegistrar;
        private System.Windows.Forms.Label lblNivel;
        private System.Windows.Forms.Label lblGrado;
        private System.Windows.Forms.Label lblSeccion;
        private System.Windows.Forms.Label lblModalidad;
        private System.Windows.Forms.Button btnRegresar;
    }
}