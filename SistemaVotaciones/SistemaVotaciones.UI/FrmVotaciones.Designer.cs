namespace SistemaVotaciones.UI
{
    partial class FrmVotaciones
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
            this.lblNombre = new System.Windows.Forms.Label();
            this.lblPadron = new System.Windows.Forms.Label();
            this.lblInicio = new System.Windows.Forms.Label();
            this.lblFin = new System.Windows.Forms.Label();
            this.lblEstado = new System.Windows.Forms.Label();
            this.txtNombre = new System.Windows.Forms.TextBox();
            this.cmbPadron = new System.Windows.Forms.ComboBox();
            this.dtInicio = new System.Windows.Forms.DateTimePicker();
            this.dtFin = new System.Windows.Forms.DateTimePicker();
            this.cmbEstado = new System.Windows.Forms.ComboBox();
            this.dgvVotaciones = new System.Windows.Forms.DataGridView();
            this.btnCrear = new System.Windows.Forms.Button();
            ((System.ComponentModel.ISupportInitialize)(this.dgvVotaciones)).BeginInit();
            this.SuspendLayout();
            // 
            // lblNombre
            // 
            this.lblNombre.AutoSize = true;
            this.lblNombre.Font = new System.Drawing.Font("Glacial Indifference", 16F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblNombre.Location = new System.Drawing.Point(21, 50);
            this.lblNombre.Name = "lblNombre";
            this.lblNombre.Size = new System.Drawing.Size(132, 38);
            this.lblNombre.TabIndex = 0;
            this.lblNombre.Text = "Nombre:";
            this.lblNombre.Click += new System.EventHandler(this.lblNombre_Click);
            // 
            // lblPadron
            // 
            this.lblPadron.AutoSize = true;
            this.lblPadron.Font = new System.Drawing.Font("Glacial Indifference", 16F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblPadron.Location = new System.Drawing.Point(21, 127);
            this.lblPadron.Name = "lblPadron";
            this.lblPadron.Size = new System.Drawing.Size(123, 38);
            this.lblPadron.TabIndex = 1;
            this.lblPadron.Text = "Padron:";
            this.lblPadron.Click += new System.EventHandler(this.lblPadron_Click);
            // 
            // lblInicio
            // 
            this.lblInicio.AutoSize = true;
            this.lblInicio.Font = new System.Drawing.Font("Glacial Indifference", 16F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblInicio.Location = new System.Drawing.Point(21, 202);
            this.lblInicio.Name = "lblInicio";
            this.lblInicio.Size = new System.Drawing.Size(98, 38);
            this.lblInicio.TabIndex = 2;
            this.lblInicio.Text = "Inicio:";
            this.lblInicio.Click += new System.EventHandler(this.lblInicio_Click);
            // 
            // lblFin
            // 
            this.lblFin.AutoSize = true;
            this.lblFin.Font = new System.Drawing.Font("Glacial Indifference", 16F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblFin.Location = new System.Drawing.Point(19, 277);
            this.lblFin.Name = "lblFin";
            this.lblFin.Size = new System.Drawing.Size(65, 38);
            this.lblFin.TabIndex = 3;
            this.lblFin.Text = "Fin:";
            this.lblFin.Click += new System.EventHandler(this.lblFin_Click);
            // 
            // lblEstado
            // 
            this.lblEstado.AutoSize = true;
            this.lblEstado.Font = new System.Drawing.Font("Glacial Indifference", 16F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblEstado.Location = new System.Drawing.Point(19, 355);
            this.lblEstado.Name = "lblEstado";
            this.lblEstado.Size = new System.Drawing.Size(122, 38);
            this.lblEstado.TabIndex = 4;
            this.lblEstado.Text = "Estado:";
            this.lblEstado.Click += new System.EventHandler(this.lblEstado_Click);
            // 
            // txtNombre
            // 
            this.txtNombre.Location = new System.Drawing.Point(150, 50);
            this.txtNombre.Multiline = true;
            this.txtNombre.Name = "txtNombre";
            this.txtNombre.Size = new System.Drawing.Size(200, 37);
            this.txtNombre.TabIndex = 5;
            this.txtNombre.TextChanged += new System.EventHandler(this.txtNombre_TextChanged);
            // 
            // cmbPadron
            // 
            this.cmbPadron.FormattingEnabled = true;
            this.cmbPadron.Location = new System.Drawing.Point(150, 137);
            this.cmbPadron.Name = "cmbPadron";
            this.cmbPadron.Size = new System.Drawing.Size(200, 28);
            this.cmbPadron.TabIndex = 6;
            this.cmbPadron.SelectedIndexChanged += new System.EventHandler(this.cmbPadron_SelectedIndexChanged);
            // 
            // dtInicio
            // 
            this.dtInicio.Location = new System.Drawing.Point(117, 213);
            this.dtInicio.Name = "dtInicio";
            this.dtInicio.Size = new System.Drawing.Size(220, 26);
            this.dtInicio.TabIndex = 7;
            this.dtInicio.ValueChanged += new System.EventHandler(this.dtInicio_ValueChanged);
            // 
            // dtFin
            // 
            this.dtFin.Location = new System.Drawing.Point(90, 289);
            this.dtFin.Name = "dtFin";
            this.dtFin.Size = new System.Drawing.Size(247, 26);
            this.dtFin.TabIndex = 8;
            this.dtFin.ValueChanged += new System.EventHandler(this.dtFin_ValueChanged);
            // 
            // cmbEstado
            // 
            this.cmbEstado.FormattingEnabled = true;
            this.cmbEstado.Location = new System.Drawing.Point(137, 364);
            this.cmbEstado.Name = "cmbEstado";
            this.cmbEstado.Size = new System.Drawing.Size(200, 28);
            this.cmbEstado.TabIndex = 9;
            this.cmbEstado.SelectedIndexChanged += new System.EventHandler(this.cmbEstado_SelectedIndexChanged);
            // 
            // dgvVotaciones
            // 
            this.dgvVotaciones.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvVotaciones.Location = new System.Drawing.Point(388, 51);
            this.dgvVotaciones.Name = "dgvVotaciones";
            this.dgvVotaciones.RowHeadersWidth = 62;
            this.dgvVotaciones.RowTemplate.Height = 28;
            this.dgvVotaciones.Size = new System.Drawing.Size(993, 343);
            this.dgvVotaciones.TabIndex = 10;
            this.dgvVotaciones.CellContentClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.dgvVotaciones_CellContentClick);
            // 
            // btnCrear
            // 
            this.btnCrear.Font = new System.Drawing.Font("Glacial Indifference", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnCrear.Location = new System.Drawing.Point(388, 415);
            this.btnCrear.Name = "btnCrear";
            this.btnCrear.Size = new System.Drawing.Size(993, 36);
            this.btnCrear.TabIndex = 11;
            this.btnCrear.Text = "Crear";
            this.btnCrear.UseVisualStyleBackColor = true;
            this.btnCrear.Click += new System.EventHandler(this.btnCrear_Click_1);
            // 
            // FrmVotaciones
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(9F, 20F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1410, 485);
            this.Controls.Add(this.btnCrear);
            this.Controls.Add(this.dgvVotaciones);
            this.Controls.Add(this.cmbEstado);
            this.Controls.Add(this.dtFin);
            this.Controls.Add(this.dtInicio);
            this.Controls.Add(this.cmbPadron);
            this.Controls.Add(this.txtNombre);
            this.Controls.Add(this.lblEstado);
            this.Controls.Add(this.lblFin);
            this.Controls.Add(this.lblInicio);
            this.Controls.Add(this.lblPadron);
            this.Controls.Add(this.lblNombre);
            this.Name = "FrmVotaciones";
            this.Text = "FrmVotaciones";
            this.Load += new System.EventHandler(this.FrmVotaciones_Load);
            ((System.ComponentModel.ISupportInitialize)(this.dgvVotaciones)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label lblNombre;
        private System.Windows.Forms.Label lblPadron;
        private System.Windows.Forms.Label lblInicio;
        private System.Windows.Forms.Label lblFin;
        private System.Windows.Forms.Label lblEstado;
        private System.Windows.Forms.TextBox txtNombre;
        private System.Windows.Forms.ComboBox cmbPadron;
        private System.Windows.Forms.DateTimePicker dtInicio;
        private System.Windows.Forms.DateTimePicker dtFin;
        private System.Windows.Forms.ComboBox cmbEstado;
        private System.Windows.Forms.DataGridView dgvVotaciones;
        private System.Windows.Forms.Button btnCrear;
    }
}