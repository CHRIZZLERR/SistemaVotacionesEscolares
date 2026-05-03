namespace SistemaVotaciones.UI
{
    partial class FrmIntegrantesPlancha
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
            this.lblPlancha = new System.Windows.Forms.Label();
            this.lblCargo = new System.Windows.Forms.Label();
            this.lblUsuario = new System.Windows.Forms.Label();
            this.cmbPlancha = new System.Windows.Forms.ComboBox();
            this.cmbCargo = new System.Windows.Forms.ComboBox();
            this.cmbUsuario = new System.Windows.Forms.ComboBox();
            this.btnAgregar = new System.Windows.Forms.Button();
            this.dgvIntegrantes = new System.Windows.Forms.DataGridView();
            this.btnGuardar = new System.Windows.Forms.Button();
            ((System.ComponentModel.ISupportInitialize)(this.dgvIntegrantes)).BeginInit();
            this.SuspendLayout();
            // 
            // lblPlancha
            // 
            this.lblPlancha.AutoSize = true;
            this.lblPlancha.Font = new System.Drawing.Font("Glacial Indifference", 18F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblPlancha.Location = new System.Drawing.Point(26, 81);
            this.lblPlancha.Name = "lblPlancha";
            this.lblPlancha.Size = new System.Drawing.Size(153, 43);
            this.lblPlancha.TabIndex = 0;
            this.lblPlancha.Text = "Plancha:";
            this.lblPlancha.Click += new System.EventHandler(this.lblPlancha_Click);
            // 
            // lblCargo
            // 
            this.lblCargo.AutoSize = true;
            this.lblCargo.Font = new System.Drawing.Font("Glacial Indifference", 18F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblCargo.Location = new System.Drawing.Point(26, 170);
            this.lblCargo.Name = "lblCargo";
            this.lblCargo.Size = new System.Drawing.Size(128, 43);
            this.lblCargo.TabIndex = 1;
            this.lblCargo.Text = "Cargo:";
            this.lblCargo.Click += new System.EventHandler(this.lblCargo_Click);
            // 
            // lblUsuario
            // 
            this.lblUsuario.AutoSize = true;
            this.lblUsuario.Font = new System.Drawing.Font("Glacial Indifference", 18F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblUsuario.Location = new System.Drawing.Point(26, 264);
            this.lblUsuario.Name = "lblUsuario";
            this.lblUsuario.Size = new System.Drawing.Size(144, 43);
            this.lblUsuario.TabIndex = 2;
            this.lblUsuario.Text = "Usuario:";
            this.lblUsuario.Click += new System.EventHandler(this.lblUsuario_Click);
            // 
            // cmbPlancha
            // 
            this.cmbPlancha.FormattingEnabled = true;
            this.cmbPlancha.Location = new System.Drawing.Point(177, 96);
            this.cmbPlancha.Name = "cmbPlancha";
            this.cmbPlancha.Size = new System.Drawing.Size(199, 28);
            this.cmbPlancha.TabIndex = 3;
            this.cmbPlancha.SelectedIndexChanged += new System.EventHandler(this.cmbPlancha_SelectedIndexChanged);
            // 
            // cmbCargo
            // 
            this.cmbCargo.FormattingEnabled = true;
            this.cmbCargo.Location = new System.Drawing.Point(151, 185);
            this.cmbCargo.Name = "cmbCargo";
            this.cmbCargo.Size = new System.Drawing.Size(225, 28);
            this.cmbCargo.TabIndex = 4;
            this.cmbCargo.SelectedIndexChanged += new System.EventHandler(this.cmbCargo_SelectedIndexChanged);
            // 
            // cmbUsuario
            // 
            this.cmbUsuario.FormattingEnabled = true;
            this.cmbUsuario.Location = new System.Drawing.Point(166, 279);
            this.cmbUsuario.Name = "cmbUsuario";
            this.cmbUsuario.Size = new System.Drawing.Size(210, 28);
            this.cmbUsuario.TabIndex = 5;
            this.cmbUsuario.SelectedIndexChanged += new System.EventHandler(this.cmbUsuario_SelectedIndexChanged);
            // 
            // btnAgregar
            // 
            this.btnAgregar.Font = new System.Drawing.Font("Glacial Indifference", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnAgregar.Location = new System.Drawing.Point(34, 348);
            this.btnAgregar.Name = "btnAgregar";
            this.btnAgregar.Size = new System.Drawing.Size(344, 41);
            this.btnAgregar.TabIndex = 6;
            this.btnAgregar.Text = "Agregar";
            this.btnAgregar.UseVisualStyleBackColor = true;
            this.btnAgregar.Click += new System.EventHandler(this.btnAgregar_Click);
            // 
            // dgvIntegrantes
            // 
            this.dgvIntegrantes.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvIntegrantes.Location = new System.Drawing.Point(444, 96);
            this.dgvIntegrantes.Name = "dgvIntegrantes";
            this.dgvIntegrantes.RowHeadersWidth = 62;
            this.dgvIntegrantes.RowTemplate.Height = 28;
            this.dgvIntegrantes.Size = new System.Drawing.Size(936, 211);
            this.dgvIntegrantes.TabIndex = 7;
            this.dgvIntegrantes.CellContentClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.dgvIntegrantes_CellContentClick);
            // 
            // btnGuardar
            // 
            this.btnGuardar.Font = new System.Drawing.Font("Glacial Indifference", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnGuardar.Location = new System.Drawing.Point(444, 348);
            this.btnGuardar.Name = "btnGuardar";
            this.btnGuardar.Size = new System.Drawing.Size(936, 41);
            this.btnGuardar.TabIndex = 8;
            this.btnGuardar.Text = "Guardar Integrantes";
            this.btnGuardar.UseVisualStyleBackColor = true;
            this.btnGuardar.Click += new System.EventHandler(this.btnGuardar_Click);
            // 
            // FrmIntegrantesPlancha
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(9F, 20F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1569, 450);
            this.Controls.Add(this.btnGuardar);
            this.Controls.Add(this.dgvIntegrantes);
            this.Controls.Add(this.btnAgregar);
            this.Controls.Add(this.cmbUsuario);
            this.Controls.Add(this.cmbCargo);
            this.Controls.Add(this.cmbPlancha);
            this.Controls.Add(this.lblUsuario);
            this.Controls.Add(this.lblCargo);
            this.Controls.Add(this.lblPlancha);
            this.Name = "FrmIntegrantesPlancha";
            this.Text = "FrmIntegrantesPlancha";
            this.Load += new System.EventHandler(this.FrmIntegrantesPlancha_Load);
            ((System.ComponentModel.ISupportInitialize)(this.dgvIntegrantes)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label lblPlancha;
        private System.Windows.Forms.Label lblCargo;
        private System.Windows.Forms.Label lblUsuario;
        private System.Windows.Forms.ComboBox cmbPlancha;
        private System.Windows.Forms.ComboBox cmbCargo;
        private System.Windows.Forms.ComboBox cmbUsuario;
        private System.Windows.Forms.Button btnAgregar;
        private System.Windows.Forms.DataGridView dgvIntegrantes;
        private System.Windows.Forms.Button btnGuardar;
    }
}