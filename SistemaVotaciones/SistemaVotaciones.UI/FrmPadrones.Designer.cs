namespace SistemaVotaciones.UI
{
    partial class FrmPadrones
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
            this.txtNombrePadron = new System.Windows.Forms.TextBox();
            this.lblNombrePadron = new System.Windows.Forms.Label();
            this.lblNivel = new System.Windows.Forms.Label();
            this.lblGrado = new System.Windows.Forms.Label();
            this.lblSeccion = new System.Windows.Forms.Label();
            this.lblModalidad = new System.Windows.Forms.Label();
            this.txtGrado = new System.Windows.Forms.TextBox();
            this.txtSeccion = new System.Windows.Forms.TextBox();
            this.txtModalidad = new System.Windows.Forms.TextBox();
            this.cmbNivel = new System.Windows.Forms.ComboBox();
            this.btnCrear = new System.Windows.Forms.Button();
            this.btnCerrar = new System.Windows.Forms.Button();
            this.dgvPadrones = new System.Windows.Forms.DataGridView();
            this.lblTituloPadrones = new System.Windows.Forms.Label();
            ((System.ComponentModel.ISupportInitialize)(this.dgvPadrones)).BeginInit();
            this.SuspendLayout();
            // 
            // txtNombrePadron
            // 
            this.txtNombrePadron.Location = new System.Drawing.Point(282, 188);
            this.txtNombrePadron.Multiline = true;
            this.txtNombrePadron.Name = "txtNombrePadron";
            this.txtNombrePadron.Size = new System.Drawing.Size(285, 38);
            this.txtNombrePadron.TabIndex = 7;
            this.txtNombrePadron.TextChanged += new System.EventHandler(this.txtNombrePadron_TextChanged);
            // 
            // lblNombrePadron
            // 
            this.lblNombrePadron.AutoSize = true;
            this.lblNombrePadron.Font = new System.Drawing.Font("Glacial Indifference", 16F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblNombrePadron.Location = new System.Drawing.Point(28, 188);
            this.lblNombrePadron.Name = "lblNombrePadron";
            this.lblNombrePadron.Size = new System.Drawing.Size(239, 38);
            this.lblNombrePadron.TabIndex = 6;
            this.lblNombrePadron.Text = "Nombre padron:";
            this.lblNombrePadron.Click += new System.EventHandler(this.lblNombrePadron_Click);
            // 
            // lblNivel
            // 
            this.lblNivel.AutoSize = true;
            this.lblNivel.Font = new System.Drawing.Font("Glacial Indifference", 16F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblNivel.Location = new System.Drawing.Point(28, 282);
            this.lblNivel.Name = "lblNivel";
            this.lblNivel.Size = new System.Drawing.Size(90, 38);
            this.lblNivel.TabIndex = 8;
            this.lblNivel.Text = "Nivel:";
            this.lblNivel.Click += new System.EventHandler(this.lblNivel_Click);
            // 
            // lblGrado
            // 
            this.lblGrado.AutoSize = true;
            this.lblGrado.Font = new System.Drawing.Font("Glacial Indifference", 16F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblGrado.Location = new System.Drawing.Point(28, 377);
            this.lblGrado.Name = "lblGrado";
            this.lblGrado.Size = new System.Drawing.Size(115, 38);
            this.lblGrado.TabIndex = 9;
            this.lblGrado.Text = "Grado:";
            this.lblGrado.Click += new System.EventHandler(this.lblGrado_Click);
            // 
            // lblSeccion
            // 
            this.lblSeccion.AutoSize = true;
            this.lblSeccion.Font = new System.Drawing.Font("Glacial Indifference", 16F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblSeccion.Location = new System.Drawing.Point(28, 470);
            this.lblSeccion.Name = "lblSeccion";
            this.lblSeccion.Size = new System.Drawing.Size(136, 38);
            this.lblSeccion.TabIndex = 10;
            this.lblSeccion.Text = "Seccion:";
            this.lblSeccion.Click += new System.EventHandler(this.lblSeccion_Click);
            // 
            // lblModalidad
            // 
            this.lblModalidad.AutoSize = true;
            this.lblModalidad.Font = new System.Drawing.Font("Glacial Indifference", 16F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblModalidad.Location = new System.Drawing.Point(28, 567);
            this.lblModalidad.Name = "lblModalidad";
            this.lblModalidad.Size = new System.Drawing.Size(173, 38);
            this.lblModalidad.TabIndex = 11;
            this.lblModalidad.Text = "Modalidad:";
            this.lblModalidad.Click += new System.EventHandler(this.lblModalidad_Click);
            // 
            // txtGrado
            // 
            this.txtGrado.Location = new System.Drawing.Point(158, 377);
            this.txtGrado.Multiline = true;
            this.txtGrado.Name = "txtGrado";
            this.txtGrado.Size = new System.Drawing.Size(409, 38);
            this.txtGrado.TabIndex = 13;
            this.txtGrado.TextChanged += new System.EventHandler(this.txtGrado_TextChanged);
            // 
            // txtSeccion
            // 
            this.txtSeccion.Location = new System.Drawing.Point(169, 470);
            this.txtSeccion.Multiline = true;
            this.txtSeccion.Name = "txtSeccion";
            this.txtSeccion.Size = new System.Drawing.Size(398, 38);
            this.txtSeccion.TabIndex = 14;
            this.txtSeccion.TextChanged += new System.EventHandler(this.txtSeccion_TextChanged);
            // 
            // txtModalidad
            // 
            this.txtModalidad.Location = new System.Drawing.Point(207, 567);
            this.txtModalidad.Multiline = true;
            this.txtModalidad.Name = "txtModalidad";
            this.txtModalidad.Size = new System.Drawing.Size(360, 38);
            this.txtModalidad.TabIndex = 15;
            this.txtModalidad.TextChanged += new System.EventHandler(this.txtModalidad_TextChanged);
            // 
            // cmbNivel
            // 
            this.cmbNivel.FormattingEnabled = true;
            this.cmbNivel.Location = new System.Drawing.Point(133, 292);
            this.cmbNivel.Name = "cmbNivel";
            this.cmbNivel.Size = new System.Drawing.Size(434, 28);
            this.cmbNivel.TabIndex = 16;
            this.cmbNivel.SelectedIndexChanged += new System.EventHandler(this.cmbNivel_SelectedIndexChanged);
            // 
            // btnCrear
            // 
            this.btnCrear.Font = new System.Drawing.Font("Glacial Indifference", 14F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnCrear.Location = new System.Drawing.Point(642, 567);
            this.btnCrear.Name = "btnCrear";
            this.btnCrear.Size = new System.Drawing.Size(244, 45);
            this.btnCrear.TabIndex = 17;
            this.btnCrear.Text = "Crear";
            this.btnCrear.UseVisualStyleBackColor = true;
            this.btnCrear.Click += new System.EventHandler(this.btnCrear_Click);
            // 
            // btnCerrar
            // 
            this.btnCerrar.Font = new System.Drawing.Font("Glacial Indifference", 14F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnCerrar.Location = new System.Drawing.Point(1374, 565);
            this.btnCerrar.Name = "btnCerrar";
            this.btnCerrar.Size = new System.Drawing.Size(244, 45);
            this.btnCerrar.TabIndex = 18;
            this.btnCerrar.Text = "Cerrar";
            this.btnCerrar.UseVisualStyleBackColor = true;
            this.btnCerrar.Click += new System.EventHandler(this.btnCerrar_Click);
            // 
            // dgvPadrones
            // 
            this.dgvPadrones.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvPadrones.Location = new System.Drawing.Point(642, 188);
            this.dgvPadrones.Name = "dgvPadrones";
            this.dgvPadrones.RowHeadersWidth = 62;
            this.dgvPadrones.RowTemplate.Height = 28;
            this.dgvPadrones.Size = new System.Drawing.Size(976, 355);
            this.dgvPadrones.TabIndex = 19;
            this.dgvPadrones.CellContentClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.dgvPadrones_CellContentClick);
            // 
            // lblTituloPadrones
            // 
            this.lblTituloPadrones.AutoSize = true;
            this.lblTituloPadrones.Font = new System.Drawing.Font("Glacial Indifference", 20F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblTituloPadrones.Location = new System.Drawing.Point(791, 9);
            this.lblTituloPadrones.Name = "lblTituloPadrones";
            this.lblTituloPadrones.Size = new System.Drawing.Size(195, 48);
            this.lblTituloPadrones.TabIndex = 20;
            this.lblTituloPadrones.Text = "Padrones";
            this.lblTituloPadrones.Click += new System.EventHandler(this.lblTituloPadrones_Click);
            // 
            // FrmPadrones
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(9F, 20F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1726, 723);
            this.Controls.Add(this.lblTituloPadrones);
            this.Controls.Add(this.dgvPadrones);
            this.Controls.Add(this.btnCerrar);
            this.Controls.Add(this.btnCrear);
            this.Controls.Add(this.cmbNivel);
            this.Controls.Add(this.txtModalidad);
            this.Controls.Add(this.txtSeccion);
            this.Controls.Add(this.txtGrado);
            this.Controls.Add(this.lblModalidad);
            this.Controls.Add(this.lblSeccion);
            this.Controls.Add(this.lblGrado);
            this.Controls.Add(this.lblNivel);
            this.Controls.Add(this.txtNombrePadron);
            this.Controls.Add(this.lblNombrePadron);
            this.Name = "FrmPadrones";
            this.Text = "FrmPadrones";
            this.Load += new System.EventHandler(this.FrmPadrones_Load);
            ((System.ComponentModel.ISupportInitialize)(this.dgvPadrones)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.TextBox txtNombrePadron;
        private System.Windows.Forms.Label lblNombrePadron;
        private System.Windows.Forms.Label lblNivel;
        private System.Windows.Forms.Label lblGrado;
        private System.Windows.Forms.Label lblSeccion;
        private System.Windows.Forms.Label lblModalidad;
        private System.Windows.Forms.TextBox txtGrado;
        private System.Windows.Forms.TextBox txtSeccion;
        private System.Windows.Forms.TextBox txtModalidad;
        private System.Windows.Forms.ComboBox cmbNivel;
        private System.Windows.Forms.Button btnCrear;
        private System.Windows.Forms.Button btnCerrar;
        private System.Windows.Forms.DataGridView dgvPadrones;
        private System.Windows.Forms.Label lblTituloPadrones;
    }
}