namespace SistemaVotaciones.UI
{
    partial class FrmResultados
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
            this.lblTotalVotos = new System.Windows.Forms.Label();
            this.lblVotosNulos = new System.Windows.Forms.Label();
            this.lblParticipacion = new System.Windows.Forms.Label();
            this.lblGanadora = new System.Windows.Forms.Label();
            this.dgvResultados = new System.Windows.Forms.DataGridView();
            this.btnActualizar = new System.Windows.Forms.Button();
            this.btnCerrar = new System.Windows.Forms.Button();
            this.lblTitutuloResultados = new System.Windows.Forms.Label();
            ((System.ComponentModel.ISupportInitialize)(this.dgvResultados)).BeginInit();
            this.SuspendLayout();
            // 
            // lblTotalVotos
            // 
            this.lblTotalVotos.AutoSize = true;
            this.lblTotalVotos.Font = new System.Drawing.Font("Glacial Indifference", 18F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblTotalVotos.Location = new System.Drawing.Point(40, 146);
            this.lblTotalVotos.Name = "lblTotalVotos";
            this.lblTotalVotos.Size = new System.Drawing.Size(274, 43);
            this.lblTotalVotos.TabIndex = 3;
            this.lblTotalVotos.Text = "Total de votos: 0";
            this.lblTotalVotos.Click += new System.EventHandler(this.lblTotalVotos_Click);
            // 
            // lblVotosNulos
            // 
            this.lblVotosNulos.AutoSize = true;
            this.lblVotosNulos.Font = new System.Drawing.Font("Glacial Indifference", 18F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblVotosNulos.Location = new System.Drawing.Point(40, 216);
            this.lblVotosNulos.Name = "lblVotosNulos";
            this.lblVotosNulos.Size = new System.Drawing.Size(232, 43);
            this.lblVotosNulos.TabIndex = 4;
            this.lblVotosNulos.Text = "Votos nulos: 0";
            this.lblVotosNulos.Click += new System.EventHandler(this.lblVotosNulos_Click);
            // 
            // lblParticipacion
            // 
            this.lblParticipacion.AutoSize = true;
            this.lblParticipacion.Font = new System.Drawing.Font("Glacial Indifference", 18F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblParticipacion.Location = new System.Drawing.Point(40, 281);
            this.lblParticipacion.Name = "lblParticipacion";
            this.lblParticipacion.Size = new System.Drawing.Size(290, 43);
            this.lblParticipacion.TabIndex = 5;
            this.lblParticipacion.Text = "Participación: 0%";
            this.lblParticipacion.Click += new System.EventHandler(this.lblParticipacion_Click);
            // 
            // lblGanadora
            // 
            this.lblGanadora.AutoSize = true;
            this.lblGanadora.Font = new System.Drawing.Font("Glacial Indifference", 18F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblGanadora.Location = new System.Drawing.Point(40, 348);
            this.lblGanadora.Name = "lblGanadora";
            this.lblGanadora.Size = new System.Drawing.Size(453, 43);
            this.lblGanadora.TabIndex = 6;
            this.lblGanadora.Text = "Plancha ganadora: Ninguna";
            this.lblGanadora.Click += new System.EventHandler(this.lblGanadora_Click);
            // 
            // dgvResultados
            // 
            this.dgvResultados.AllowUserToAddRows = false;
            this.dgvResultados.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvResultados.Location = new System.Drawing.Point(22, 424);
            this.dgvResultados.Name = "dgvResultados";
            this.dgvResultados.RowHeadersWidth = 62;
            this.dgvResultados.RowTemplate.Height = 28;
            this.dgvResultados.Size = new System.Drawing.Size(666, 259);
            this.dgvResultados.TabIndex = 7;
            this.dgvResultados.CellContentClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.dgvResultados_CellContentClick);
            // 
            // btnActualizar
            // 
            this.btnActualizar.Font = new System.Drawing.Font("Glacial Indifference", 14F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnActualizar.Location = new System.Drawing.Point(22, 729);
            this.btnActualizar.Name = "btnActualizar";
            this.btnActualizar.Size = new System.Drawing.Size(176, 45);
            this.btnActualizar.TabIndex = 12;
            this.btnActualizar.Text = "Actualizar";
            this.btnActualizar.UseVisualStyleBackColor = true;
            this.btnActualizar.Click += new System.EventHandler(this.btnActualizar_Click);
            // 
            // btnCerrar
            // 
            this.btnCerrar.Font = new System.Drawing.Font("Glacial Indifference", 14F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnCerrar.Location = new System.Drawing.Point(502, 729);
            this.btnCerrar.Name = "btnCerrar";
            this.btnCerrar.Size = new System.Drawing.Size(176, 45);
            this.btnCerrar.TabIndex = 13;
            this.btnCerrar.Text = "Cerrar";
            this.btnCerrar.UseVisualStyleBackColor = true;
            this.btnCerrar.Click += new System.EventHandler(this.btnCerrar_Click);
            // 
            // lblTitutuloResultados
            // 
            this.lblTitutuloResultados.AutoSize = true;
            this.lblTitutuloResultados.Font = new System.Drawing.Font("Glacial Indifference", 26F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblTitutuloResultados.Location = new System.Drawing.Point(479, 9);
            this.lblTitutuloResultados.Name = "lblTitutuloResultados";
            this.lblTitutuloResultados.Size = new System.Drawing.Size(293, 62);
            this.lblTitutuloResultados.TabIndex = 14;
            this.lblTitutuloResultados.Text = "Resultados";
            // 
            // FrmResultados
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(9F, 20F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1177, 788);
            this.Controls.Add(this.lblTitutuloResultados);
            this.Controls.Add(this.btnCerrar);
            this.Controls.Add(this.btnActualizar);
            this.Controls.Add(this.dgvResultados);
            this.Controls.Add(this.lblGanadora);
            this.Controls.Add(this.lblParticipacion);
            this.Controls.Add(this.lblVotosNulos);
            this.Controls.Add(this.lblTotalVotos);
            this.Name = "FrmResultados";
            this.Text = "FrmResultados";
            ((System.ComponentModel.ISupportInitialize)(this.dgvResultados)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label lblTotalVotos;
        private System.Windows.Forms.Label lblVotosNulos;
        private System.Windows.Forms.Label lblParticipacion;
        private System.Windows.Forms.Label lblGanadora;
        private System.Windows.Forms.DataGridView dgvResultados;
        private System.Windows.Forms.Button btnActualizar;
        private System.Windows.Forms.Button btnCerrar;
        private System.Windows.Forms.Label lblTitutuloResultados;
    }
}