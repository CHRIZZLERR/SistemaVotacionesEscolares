namespace SistemaVotaciones.UI
{
    partial class FrmInfoVotacion
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
            this.lblNombreVotacion = new System.Windows.Forms.Label();
            this.lblPadron = new System.Windows.Forms.Label();
            this.lblEstado = new System.Windows.Forms.Label();
            this.lblFechaInicio = new System.Windows.Forms.Label();
            this.lblFechaFin = new System.Windows.Forms.Label();
            this.lblTiempoRestante = new System.Windows.Forms.Label();
            this.lblCantidadPlanchas = new System.Windows.Forms.Label();
            this.lblEstadoVoto = new System.Windows.Forms.Label();
            this.btnCerrar = new System.Windows.Forms.Button();
            this.lblValorVotacion = new System.Windows.Forms.Label();
            this.lblValorPadron = new System.Windows.Forms.Label();
            this.lblValorEstado = new System.Windows.Forms.Label();
            this.lblValorFechaInicio = new System.Windows.Forms.Label();
            this.lblValorFechaFin = new System.Windows.Forms.Label();
            this.lblValorTiempoRestante = new System.Windows.Forms.Label();
            this.lblValorCantidadPlanchas = new System.Windows.Forms.Label();
            this.lblValorEstadoVoto = new System.Windows.Forms.Label();
            this.SuspendLayout();
            // 
            // lblTitulo
            // 
            this.lblTitulo.AutoSize = true;
            this.lblTitulo.Font = new System.Drawing.Font("Glacial Indifference", 28F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblTitulo.Location = new System.Drawing.Point(217, 23);
            this.lblTitulo.Name = "lblTitulo";
            this.lblTitulo.Size = new System.Drawing.Size(662, 67);
            this.lblTitulo.TabIndex = 16;
            this.lblTitulo.Text = "Información de Votación";
            this.lblTitulo.Click += new System.EventHandler(this.lblTitulo_Click);
            // 
            // lblNombreVotacion
            // 
            this.lblNombreVotacion.AutoSize = true;
            this.lblNombreVotacion.Font = new System.Drawing.Font("Glacial Indifference", 16F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblNombreVotacion.Location = new System.Drawing.Point(26, 151);
            this.lblNombreVotacion.Name = "lblNombreVotacion";
            this.lblNombreVotacion.Size = new System.Drawing.Size(362, 38);
            this.lblNombreVotacion.TabIndex = 17;
            this.lblNombreVotacion.Text = "Nombre de la votación:";
            this.lblNombreVotacion.Click += new System.EventHandler(this.lblNombreVotacion_Click);
            // 
            // lblPadron
            // 
            this.lblPadron.AutoSize = true;
            this.lblPadron.Font = new System.Drawing.Font("Glacial Indifference", 16F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblPadron.Location = new System.Drawing.Point(26, 223);
            this.lblPadron.Name = "lblPadron";
            this.lblPadron.Size = new System.Drawing.Size(306, 38);
            this.lblPadron.TabIndex = 18;
            this.lblPadron.Text = "Padrón del usuario:";
            this.lblPadron.Click += new System.EventHandler(this.lblPadron_Click);
            // 
            // lblEstado
            // 
            this.lblEstado.AutoSize = true;
            this.lblEstado.Font = new System.Drawing.Font("Glacial Indifference", 16F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblEstado.Location = new System.Drawing.Point(26, 299);
            this.lblEstado.Name = "lblEstado";
            this.lblEstado.Size = new System.Drawing.Size(347, 38);
            this.lblEstado.TabIndex = 19;
            this.lblEstado.Text = "Estado de la votación:";
            this.lblEstado.Click += new System.EventHandler(this.lblEstado_Click);
            // 
            // lblFechaInicio
            // 
            this.lblFechaInicio.AutoSize = true;
            this.lblFechaInicio.Font = new System.Drawing.Font("Glacial Indifference", 16F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblFechaInicio.Location = new System.Drawing.Point(26, 364);
            this.lblFechaInicio.Name = "lblFechaInicio";
            this.lblFechaInicio.Size = new System.Drawing.Size(252, 38);
            this.lblFechaInicio.TabIndex = 20;
            this.lblFechaInicio.Text = "Fecha de inicio:";
            this.lblFechaInicio.Click += new System.EventHandler(this.lblFechaInicio_Click);
            // 
            // lblFechaFin
            // 
            this.lblFechaFin.AutoSize = true;
            this.lblFechaFin.Font = new System.Drawing.Font("Glacial Indifference", 16F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblFechaFin.Location = new System.Drawing.Point(26, 427);
            this.lblFechaFin.Name = "lblFechaFin";
            this.lblFechaFin.Size = new System.Drawing.Size(210, 38);
            this.lblFechaFin.TabIndex = 21;
            this.lblFechaFin.Text = "Fecha de fin:";
            this.lblFechaFin.Click += new System.EventHandler(this.lblFechaFin_Click);
            // 
            // lblTiempoRestante
            // 
            this.lblTiempoRestante.AutoSize = true;
            this.lblTiempoRestante.Font = new System.Drawing.Font("Glacial Indifference", 16F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblTiempoRestante.Location = new System.Drawing.Point(26, 493);
            this.lblTiempoRestante.Name = "lblTiempoRestante";
            this.lblTiempoRestante.Size = new System.Drawing.Size(269, 38);
            this.lblTiempoRestante.TabIndex = 22;
            this.lblTiempoRestante.Text = "Tiempo restante:";
            this.lblTiempoRestante.Click += new System.EventHandler(this.lblTiempoRestante_Click);
            // 
            // lblCantidadPlanchas
            // 
            this.lblCantidadPlanchas.AutoSize = true;
            this.lblCantidadPlanchas.Font = new System.Drawing.Font("Glacial Indifference", 16F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblCantidadPlanchas.Location = new System.Drawing.Point(26, 563);
            this.lblCantidadPlanchas.Name = "lblCantidadPlanchas";
            this.lblCantidadPlanchas.Size = new System.Drawing.Size(344, 38);
            this.lblCantidadPlanchas.TabIndex = 23;
            this.lblCantidadPlanchas.Text = "Planchas disponibles:";
            this.lblCantidadPlanchas.Click += new System.EventHandler(this.lblCantidadPlanchas_Click);
            // 
            // lblEstadoVoto
            // 
            this.lblEstadoVoto.AutoSize = true;
            this.lblEstadoVoto.Font = new System.Drawing.Font("Glacial Indifference", 16F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblEstadoVoto.Location = new System.Drawing.Point(26, 636);
            this.lblEstadoVoto.Name = "lblEstadoVoto";
            this.lblEstadoVoto.Size = new System.Drawing.Size(245, 38);
            this.lblEstadoVoto.TabIndex = 24;
            this.lblEstadoVoto.Text = "Estado de voto:";
            this.lblEstadoVoto.Click += new System.EventHandler(this.lblEstadoVoto_Click);
            // 
            // btnCerrar
            // 
            this.btnCerrar.Font = new System.Drawing.Font("Glacial Indifference", 14F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnCerrar.Location = new System.Drawing.Point(12, 728);
            this.btnCerrar.Name = "btnCerrar";
            this.btnCerrar.Size = new System.Drawing.Size(244, 45);
            this.btnCerrar.TabIndex = 26;
            this.btnCerrar.Text = "Cerrar";
            this.btnCerrar.UseVisualStyleBackColor = true;
            this.btnCerrar.Click += new System.EventHandler(this.btnCerrar_Click);
            // 
            // lblValorVotacion
            // 
            this.lblValorVotacion.AutoSize = true;
            this.lblValorVotacion.Font = new System.Drawing.Font("Glacial Indifference", 16F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblValorVotacion.Location = new System.Drawing.Point(413, 151);
            this.lblValorVotacion.Name = "lblValorVotacion";
            this.lblValorVotacion.Size = new System.Drawing.Size(31, 38);
            this.lblValorVotacion.TabIndex = 27;
            this.lblValorVotacion.Text = "x";
            this.lblValorVotacion.Click += new System.EventHandler(this.lblValorVotacion_Click);
            // 
            // lblValorPadron
            // 
            this.lblValorPadron.AutoSize = true;
            this.lblValorPadron.Font = new System.Drawing.Font("Glacial Indifference", 16F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblValorPadron.Location = new System.Drawing.Point(357, 223);
            this.lblValorPadron.Name = "lblValorPadron";
            this.lblValorPadron.Size = new System.Drawing.Size(31, 38);
            this.lblValorPadron.TabIndex = 28;
            this.lblValorPadron.Text = "x";
            this.lblValorPadron.Click += new System.EventHandler(this.lblValorPadron_Click);
            // 
            // lblValorEstado
            // 
            this.lblValorEstado.AutoSize = true;
            this.lblValorEstado.Font = new System.Drawing.Font("Glacial Indifference", 16F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblValorEstado.Location = new System.Drawing.Point(385, 299);
            this.lblValorEstado.Name = "lblValorEstado";
            this.lblValorEstado.Size = new System.Drawing.Size(31, 38);
            this.lblValorEstado.TabIndex = 29;
            this.lblValorEstado.Text = "x";
            this.lblValorEstado.Click += new System.EventHandler(this.lblValorEstado_Click);
            // 
            // lblValorFechaInicio
            // 
            this.lblValorFechaInicio.AutoSize = true;
            this.lblValorFechaInicio.Font = new System.Drawing.Font("Glacial Indifference", 16F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblValorFechaInicio.Location = new System.Drawing.Point(297, 364);
            this.lblValorFechaInicio.Name = "lblValorFechaInicio";
            this.lblValorFechaInicio.Size = new System.Drawing.Size(31, 38);
            this.lblValorFechaInicio.TabIndex = 30;
            this.lblValorFechaInicio.Text = "x";
            this.lblValorFechaInicio.Click += new System.EventHandler(this.lblValorFechaInicio_Click);
            // 
            // lblValorFechaFin
            // 
            this.lblValorFechaFin.AutoSize = true;
            this.lblValorFechaFin.Font = new System.Drawing.Font("Glacial Indifference", 16F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblValorFechaFin.Location = new System.Drawing.Point(261, 427);
            this.lblValorFechaFin.Name = "lblValorFechaFin";
            this.lblValorFechaFin.Size = new System.Drawing.Size(31, 38);
            this.lblValorFechaFin.TabIndex = 31;
            this.lblValorFechaFin.Text = "x";
            this.lblValorFechaFin.Click += new System.EventHandler(this.lblValorFechaFin_Click);
            // 
            // lblValorTiempoRestante
            // 
            this.lblValorTiempoRestante.AutoSize = true;
            this.lblValorTiempoRestante.Font = new System.Drawing.Font("Glacial Indifference", 16F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblValorTiempoRestante.Location = new System.Drawing.Point(320, 493);
            this.lblValorTiempoRestante.Name = "lblValorTiempoRestante";
            this.lblValorTiempoRestante.Size = new System.Drawing.Size(31, 38);
            this.lblValorTiempoRestante.TabIndex = 32;
            this.lblValorTiempoRestante.Text = "x";
            this.lblValorTiempoRestante.Click += new System.EventHandler(this.lblValorTiempoRestante_Click);
            // 
            // lblValorCantidadPlanchas
            // 
            this.lblValorCantidadPlanchas.AutoSize = true;
            this.lblValorCantidadPlanchas.Font = new System.Drawing.Font("Glacial Indifference", 16F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblValorCantidadPlanchas.Location = new System.Drawing.Point(385, 563);
            this.lblValorCantidadPlanchas.Name = "lblValorCantidadPlanchas";
            this.lblValorCantidadPlanchas.Size = new System.Drawing.Size(31, 38);
            this.lblValorCantidadPlanchas.TabIndex = 33;
            this.lblValorCantidadPlanchas.Text = "x";
            this.lblValorCantidadPlanchas.Click += new System.EventHandler(this.lblValorCantidadPlanchas_Click);
            // 
            // lblValorEstadoVoto
            // 
            this.lblValorEstadoVoto.AutoSize = true;
            this.lblValorEstadoVoto.Font = new System.Drawing.Font("Glacial Indifference", 16F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblValorEstadoVoto.Location = new System.Drawing.Point(287, 636);
            this.lblValorEstadoVoto.Name = "lblValorEstadoVoto";
            this.lblValorEstadoVoto.Size = new System.Drawing.Size(31, 38);
            this.lblValorEstadoVoto.TabIndex = 34;
            this.lblValorEstadoVoto.Text = "x";
            this.lblValorEstadoVoto.Click += new System.EventHandler(this.lblValorEstadoVoto_Click);
            // 
            // FrmInfoVotacion
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(9F, 20F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1124, 785);
            this.Controls.Add(this.lblValorEstadoVoto);
            this.Controls.Add(this.lblValorCantidadPlanchas);
            this.Controls.Add(this.lblValorTiempoRestante);
            this.Controls.Add(this.lblValorFechaFin);
            this.Controls.Add(this.lblValorFechaInicio);
            this.Controls.Add(this.lblValorEstado);
            this.Controls.Add(this.lblValorPadron);
            this.Controls.Add(this.lblValorVotacion);
            this.Controls.Add(this.btnCerrar);
            this.Controls.Add(this.lblEstadoVoto);
            this.Controls.Add(this.lblCantidadPlanchas);
            this.Controls.Add(this.lblTiempoRestante);
            this.Controls.Add(this.lblFechaFin);
            this.Controls.Add(this.lblFechaInicio);
            this.Controls.Add(this.lblEstado);
            this.Controls.Add(this.lblPadron);
            this.Controls.Add(this.lblNombreVotacion);
            this.Controls.Add(this.lblTitulo);
            this.Name = "FrmInfoVotacion";
            this.Text = "FrmInfoVotacion";
            this.Load += new System.EventHandler(this.FrmInfoVotacion_Load);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label lblTitulo;
        private System.Windows.Forms.Label lblNombreVotacion;
        private System.Windows.Forms.Label lblPadron;
        private System.Windows.Forms.Label lblEstado;
        private System.Windows.Forms.Label lblFechaInicio;
        private System.Windows.Forms.Label lblFechaFin;
        private System.Windows.Forms.Label lblTiempoRestante;
        private System.Windows.Forms.Label lblCantidadPlanchas;
        private System.Windows.Forms.Label lblEstadoVoto;
        private System.Windows.Forms.Button btnCerrar;
        private System.Windows.Forms.Label lblValorVotacion;
        private System.Windows.Forms.Label lblValorPadron;
        private System.Windows.Forms.Label lblValorEstado;
        private System.Windows.Forms.Label lblValorFechaInicio;
        private System.Windows.Forms.Label lblValorFechaFin;
        private System.Windows.Forms.Label lblValorTiempoRestante;
        private System.Windows.Forms.Label lblValorCantidadPlanchas;
        private System.Windows.Forms.Label lblValorEstadoVoto;
    }
}