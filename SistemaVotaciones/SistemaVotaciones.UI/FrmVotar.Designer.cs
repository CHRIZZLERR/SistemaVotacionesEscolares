namespace SistemaVotaciones.UI
{
    partial class FrmVotar
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
            this.lblTitulo = new System.Windows.Forms.Label();
            this.lblEstado = new System.Windows.Forms.Label();
            this.lblPlancha = new System.Windows.Forms.Label();
            this.cmbPlanchas = new System.Windows.Forms.ComboBox();
            this.btnVotar = new System.Windows.Forms.Button();
            this.btnVotoNulo = new System.Windows.Forms.Button();
            this.btnCerrar = new System.Windows.Forms.Button();
            this.dgvIntegrantes = new System.Windows.Forms.DataGridView();
            this.lblEstadoVotacion = new System.Windows.Forms.Label();
            ((System.ComponentModel.ISupportInitialize)(this.dgvIntegrantes)).BeginInit();
            this.SuspendLayout();
            // 
            // lblTitulo
            // 
            this.lblTitulo.AutoSize = true;
            this.lblTitulo.Font = new System.Drawing.Font("Glacial Indifference", 18F, ((System.Drawing.FontStyle)((System.Drawing.FontStyle.Bold | System.Drawing.FontStyle.Italic))), System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblTitulo.Location = new System.Drawing.Point(235, 9);
            this.lblTitulo.Name = "lblTitulo";
            this.lblTitulo.Size = new System.Drawing.Size(362, 43);
            this.lblTitulo.TabIndex = 1;
            this.lblTitulo.Text = "Votacion  Estudiantil";
            this.lblTitulo.Click += new System.EventHandler(this.lblTitulo_Click);
            // 
            // lblEstado
            // 
            this.lblEstado.AutoSize = true;
            this.lblEstado.Font = new System.Drawing.Font("Glacial Indifference", 18F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblEstado.Location = new System.Drawing.Point(30, 127);
            this.lblEstado.Name = "lblEstado";
            this.lblEstado.Size = new System.Drawing.Size(137, 43);
            this.lblEstado.TabIndex = 2;
            this.lblEstado.Text = "Estado:";
            this.lblEstado.Click += new System.EventHandler(this.lblEstado_Click);
            // 
            // lblPlancha
            // 
            this.lblPlancha.AutoSize = true;
            this.lblPlancha.Font = new System.Drawing.Font("Glacial Indifference", 18F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblPlancha.Location = new System.Drawing.Point(30, 195);
            this.lblPlancha.Name = "lblPlancha";
            this.lblPlancha.Size = new System.Drawing.Size(405, 43);
            this.lblPlancha.TabIndex = 3;
            this.lblPlancha.Text = "Seleccione una plancha:";
            this.lblPlancha.Click += new System.EventHandler(this.lblPlancha_Click);
            // 
            // cmbPlanchas
            // 
            this.cmbPlanchas.FormattingEnabled = true;
            this.cmbPlanchas.Location = new System.Drawing.Point(442, 209);
            this.cmbPlanchas.Name = "cmbPlanchas";
            this.cmbPlanchas.Size = new System.Drawing.Size(233, 28);
            this.cmbPlanchas.TabIndex = 4;
            this.cmbPlanchas.SelectedIndexChanged += new System.EventHandler(this.cmbPlanchas_SelectedIndexChanged);
            // 
            // btnVotar
            // 
            this.btnVotar.Font = new System.Drawing.Font("Glacial Indifference", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnVotar.Location = new System.Drawing.Point(38, 549);
            this.btnVotar.Name = "btnVotar";
            this.btnVotar.Size = new System.Drawing.Size(304, 41);
            this.btnVotar.TabIndex = 7;
            this.btnVotar.Text = "Votar por plancha";
            this.btnVotar.UseVisualStyleBackColor = true;
            this.btnVotar.Click += new System.EventHandler(this.btnVotar_Click);
            // 
            // btnVotoNulo
            // 
            this.btnVotoNulo.Font = new System.Drawing.Font("Glacial Indifference", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnVotoNulo.Location = new System.Drawing.Point(361, 549);
            this.btnVotoNulo.Name = "btnVotoNulo";
            this.btnVotoNulo.Size = new System.Drawing.Size(174, 41);
            this.btnVotoNulo.TabIndex = 8;
            this.btnVotoNulo.Text = "Voto nulo";
            this.btnVotoNulo.UseVisualStyleBackColor = true;
            this.btnVotoNulo.Click += new System.EventHandler(this.btnVotoNulo_Click);
            // 
            // btnCerrar
            // 
            this.btnCerrar.Font = new System.Drawing.Font("Glacial Indifference", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnCerrar.Location = new System.Drawing.Point(559, 549);
            this.btnCerrar.Name = "btnCerrar";
            this.btnCerrar.Size = new System.Drawing.Size(116, 37);
            this.btnCerrar.TabIndex = 9;
            this.btnCerrar.Text = "Cerrar";
            this.btnCerrar.TextAlign = System.Drawing.ContentAlignment.TopCenter;
            this.btnCerrar.UseVisualStyleBackColor = true;
            this.btnCerrar.Click += new System.EventHandler(this.btnCerrar_Click);
            // 
            // dgvIntegrantes
            // 
            this.dgvIntegrantes.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvIntegrantes.Location = new System.Drawing.Point(38, 259);
            this.dgvIntegrantes.Name = "dgvIntegrantes";
            this.dgvIntegrantes.RowHeadersWidth = 62;
            this.dgvIntegrantes.RowTemplate.Height = 28;
            this.dgvIntegrantes.Size = new System.Drawing.Size(637, 253);
            this.dgvIntegrantes.TabIndex = 10;
            this.dgvIntegrantes.CellContentClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.dgvIntegrantes_CellContentClick);
            // 
            // lblEstadoVotacion
            // 
            this.lblEstadoVotacion.AutoSize = true;
            this.lblEstadoVotacion.Font = new System.Drawing.Font("Glacial Indifference", 18F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblEstadoVotacion.Location = new System.Drawing.Point(173, 127);
            this.lblEstadoVotacion.Name = "lblEstadoVotacion";
            this.lblEstadoVotacion.Size = new System.Drawing.Size(0, 43);
            this.lblEstadoVotacion.TabIndex = 11;
            this.lblEstadoVotacion.Click += new System.EventHandler(this.lblEstadoVotacion_Click);
            // 
            // FrmVotar
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(9F, 20F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(807, 731);
            this.Controls.Add(this.lblEstadoVotacion);
            this.Controls.Add(this.dgvIntegrantes);
            this.Controls.Add(this.btnCerrar);
            this.Controls.Add(this.btnVotoNulo);
            this.Controls.Add(this.btnVotar);
            this.Controls.Add(this.cmbPlanchas);
            this.Controls.Add(this.lblPlancha);
            this.Controls.Add(this.lblEstado);
            this.Controls.Add(this.lblTitulo);
            this.Name = "FrmVotar";
            this.Text = "FrmVotar";
            ((System.ComponentModel.ISupportInitialize)(this.dgvIntegrantes)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label lblTitulo;
        private System.Windows.Forms.Label lblEstado;
        private System.Windows.Forms.Label lblPlancha;
        private System.Windows.Forms.ComboBox cmbPlanchas;
        private System.Windows.Forms.Button btnVotar;
        private System.Windows.Forms.Button btnVotoNulo;
        private System.Windows.Forms.Button btnCerrar;
        private System.Windows.Forms.DataGridView dgvIntegrantes;
        private System.Windows.Forms.Label lblEstadoVotacion;
    }
}