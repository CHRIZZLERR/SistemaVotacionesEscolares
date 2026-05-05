namespace SistemaVotaciones.UI
{
    partial class FrmPlanchas
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
            this.lblNombrePlancha = new System.Windows.Forms.Label();
            this.lblColor = new System.Windows.Forms.Label();
            this.lblPadron = new System.Windows.Forms.Label();
            this.lblAdminPlancha = new System.Windows.Forms.Label();
            this.lblLema = new System.Windows.Forms.Label();
            this.txtNombrePlancha = new System.Windows.Forms.TextBox();
            this.txtColor = new System.Windows.Forms.TextBox();
            this.txtLema = new System.Windows.Forms.TextBox();
            this.cmbPadron = new System.Windows.Forms.ComboBox();
            this.cmbAdminPlancha = new System.Windows.Forms.ComboBox();
            this.dgvPlanchas = new System.Windows.Forms.DataGridView();
            this.btnCrearPlancha = new System.Windows.Forms.Button();
            this.lblTitulo = new System.Windows.Forms.Label();
            this.btnCerrar = new System.Windows.Forms.Button();
            ((System.ComponentModel.ISupportInitialize)(this.dgvPlanchas)).BeginInit();
            this.SuspendLayout();
            // 
            // lblNombrePlancha
            // 
            this.lblNombrePlancha.AutoSize = true;
            this.lblNombrePlancha.Font = new System.Drawing.Font("Glacial Indifference", 16F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblNombrePlancha.Location = new System.Drawing.Point(10, 196);
            this.lblNombrePlancha.Name = "lblNombrePlancha";
            this.lblNombrePlancha.Size = new System.Drawing.Size(329, 38);
            this.lblNombrePlancha.TabIndex = 0;
            this.lblNombrePlancha.Text = "Nombre de la plancha:";
            this.lblNombrePlancha.Click += new System.EventHandler(this.lblNombrePlancha_Click);
            // 
            // lblColor
            // 
            this.lblColor.AutoSize = true;
            this.lblColor.Font = new System.Drawing.Font("Glacial Indifference", 16F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblColor.Location = new System.Drawing.Point(10, 259);
            this.lblColor.Name = "lblColor";
            this.lblColor.Size = new System.Drawing.Size(102, 38);
            this.lblColor.TabIndex = 1;
            this.lblColor.Text = "Color:";
            this.lblColor.Click += new System.EventHandler(this.lblColor_Click);
            // 
            // lblPadron
            // 
            this.lblPadron.AutoSize = true;
            this.lblPadron.Font = new System.Drawing.Font("Glacial Indifference", 16F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblPadron.Location = new System.Drawing.Point(10, 400);
            this.lblPadron.Name = "lblPadron";
            this.lblPadron.Size = new System.Drawing.Size(123, 38);
            this.lblPadron.TabIndex = 2;
            this.lblPadron.Text = "Padron:";
            this.lblPadron.Click += new System.EventHandler(this.lblPadron_Click);
            // 
            // lblAdminPlancha
            // 
            this.lblAdminPlancha.AutoSize = true;
            this.lblAdminPlancha.Font = new System.Drawing.Font("Glacial Indifference", 16F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblAdminPlancha.Location = new System.Drawing.Point(10, 463);
            this.lblAdminPlancha.Name = "lblAdminPlancha";
            this.lblAdminPlancha.Size = new System.Drawing.Size(379, 38);
            this.lblAdminPlancha.TabIndex = 3;
            this.lblAdminPlancha.Text = "Administrador de plancha:";
            this.lblAdminPlancha.Click += new System.EventHandler(this.lblAdminPlancha_Click);
            // 
            // lblLema
            // 
            this.lblLema.AutoSize = true;
            this.lblLema.Font = new System.Drawing.Font("Glacial Indifference", 16F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblLema.Location = new System.Drawing.Point(10, 325);
            this.lblLema.Name = "lblLema";
            this.lblLema.Size = new System.Drawing.Size(98, 38);
            this.lblLema.TabIndex = 4;
            this.lblLema.Text = "Lema:";
            this.lblLema.Click += new System.EventHandler(this.lblLema_Click);
            // 
            // txtNombrePlancha
            // 
            this.txtNombrePlancha.Location = new System.Drawing.Point(346, 196);
            this.txtNombrePlancha.Multiline = true;
            this.txtNombrePlancha.Name = "txtNombrePlancha";
            this.txtNombrePlancha.Size = new System.Drawing.Size(233, 38);
            this.txtNombrePlancha.TabIndex = 5;
            this.txtNombrePlancha.TextChanged += new System.EventHandler(this.txtNombrePlancha_TextChanged);
            // 
            // txtColor
            // 
            this.txtColor.Location = new System.Drawing.Point(118, 270);
            this.txtColor.Multiline = true;
            this.txtColor.Name = "txtColor";
            this.txtColor.Size = new System.Drawing.Size(461, 38);
            this.txtColor.TabIndex = 6;
            this.txtColor.TextChanged += new System.EventHandler(this.txtColor_TextChanged);
            // 
            // txtLema
            // 
            this.txtLema.Location = new System.Drawing.Point(118, 325);
            this.txtLema.Multiline = true;
            this.txtLema.Name = "txtLema";
            this.txtLema.Size = new System.Drawing.Size(461, 38);
            this.txtLema.TabIndex = 7;
            this.txtLema.TextChanged += new System.EventHandler(this.txtLema_TextChanged);
            // 
            // cmbPadron
            // 
            this.cmbPadron.FormattingEnabled = true;
            this.cmbPadron.Location = new System.Drawing.Point(140, 409);
            this.cmbPadron.Name = "cmbPadron";
            this.cmbPadron.Size = new System.Drawing.Size(439, 28);
            this.cmbPadron.TabIndex = 8;
            this.cmbPadron.SelectedIndexChanged += new System.EventHandler(this.cmbPadron_SelectedIndexChanged);
            // 
            // cmbAdminPlancha
            // 
            this.cmbAdminPlancha.FormattingEnabled = true;
            this.cmbAdminPlancha.Location = new System.Drawing.Point(395, 473);
            this.cmbAdminPlancha.Name = "cmbAdminPlancha";
            this.cmbAdminPlancha.Size = new System.Drawing.Size(184, 28);
            this.cmbAdminPlancha.TabIndex = 9;
            this.cmbAdminPlancha.SelectedIndexChanged += new System.EventHandler(this.cmbAdminPlancha_SelectedIndexChanged);
            // 
            // dgvPlanchas
            // 
            this.dgvPlanchas.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvPlanchas.Location = new System.Drawing.Point(606, 196);
            this.dgvPlanchas.Name = "dgvPlanchas";
            this.dgvPlanchas.RowHeadersWidth = 62;
            this.dgvPlanchas.RowTemplate.Height = 28;
            this.dgvPlanchas.Size = new System.Drawing.Size(1137, 242);
            this.dgvPlanchas.TabIndex = 10;
            this.dgvPlanchas.CellContentClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.dgvPlanchas_CellContentClick);
            // 
            // btnCrearPlancha
            // 
            this.btnCrearPlancha.Font = new System.Drawing.Font("Glacial Indifference", 14F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnCrearPlancha.Location = new System.Drawing.Point(606, 456);
            this.btnCrearPlancha.Name = "btnCrearPlancha";
            this.btnCrearPlancha.Size = new System.Drawing.Size(446, 45);
            this.btnCrearPlancha.TabIndex = 11;
            this.btnCrearPlancha.Text = "Crear";
            this.btnCrearPlancha.UseVisualStyleBackColor = true;
            this.btnCrearPlancha.Click += new System.EventHandler(this.btnCrearPlancha_Click);
            // 
            // lblTitulo
            // 
            this.lblTitulo.AutoSize = true;
            this.lblTitulo.Font = new System.Drawing.Font("Glacial Indifference", 28F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblTitulo.Location = new System.Drawing.Point(633, 22);
            this.lblTitulo.Name = "lblTitulo";
            this.lblTitulo.Size = new System.Drawing.Size(263, 67);
            this.lblTitulo.TabIndex = 19;
            this.lblTitulo.Text = "Planchas";
            // 
            // btnCerrar
            // 
            this.btnCerrar.Font = new System.Drawing.Font("Glacial Indifference", 14F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnCerrar.Location = new System.Drawing.Point(1499, 473);
            this.btnCerrar.Name = "btnCerrar";
            this.btnCerrar.Size = new System.Drawing.Size(244, 45);
            this.btnCerrar.TabIndex = 20;
            this.btnCerrar.Text = "Cerrar";
            this.btnCerrar.UseVisualStyleBackColor = true;
            this.btnCerrar.Click += new System.EventHandler(this.btnCerrar_Click);
            // 
            // FrmPlanchas
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(9F, 20F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1949, 551);
            this.Controls.Add(this.btnCerrar);
            this.Controls.Add(this.lblTitulo);
            this.Controls.Add(this.btnCrearPlancha);
            this.Controls.Add(this.dgvPlanchas);
            this.Controls.Add(this.cmbAdminPlancha);
            this.Controls.Add(this.cmbPadron);
            this.Controls.Add(this.txtLema);
            this.Controls.Add(this.txtColor);
            this.Controls.Add(this.txtNombrePlancha);
            this.Controls.Add(this.lblLema);
            this.Controls.Add(this.lblAdminPlancha);
            this.Controls.Add(this.lblPadron);
            this.Controls.Add(this.lblColor);
            this.Controls.Add(this.lblNombrePlancha);
            this.Name = "FrmPlanchas";
            this.Text = "FrmPlanchas";
            this.Load += new System.EventHandler(this.FrmPlanchas_Load);
            ((System.ComponentModel.ISupportInitialize)(this.dgvPlanchas)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label lblNombrePlancha;
        private System.Windows.Forms.Label lblColor;
        private System.Windows.Forms.Label lblPadron;
        private System.Windows.Forms.Label lblAdminPlancha;
        private System.Windows.Forms.Label lblLema;
        private System.Windows.Forms.TextBox txtNombrePlancha;
        private System.Windows.Forms.TextBox txtColor;
        private System.Windows.Forms.TextBox txtLema;
        private System.Windows.Forms.ComboBox cmbPadron;
        private System.Windows.Forms.ComboBox cmbAdminPlancha;
        private System.Windows.Forms.DataGridView dgvPlanchas;
        private System.Windows.Forms.Button btnCrearPlancha;
        private System.Windows.Forms.Label lblTitulo;
        private System.Windows.Forms.Button btnCerrar;
    }
}