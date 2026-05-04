namespace SistemaVotaciones.UI
{
    partial class FrmMenuVotante
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
            this.btnVotar = new System.Windows.Forms.Button();
            this.btnInfoVotacion = new System.Windows.Forms.Button();
            this.btnCerrarSesion = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // btnVotar
            // 
            this.btnVotar.Location = new System.Drawing.Point(126, 194);
            this.btnVotar.Name = "btnVotar";
            this.btnVotar.Size = new System.Drawing.Size(270, 81);
            this.btnVotar.TabIndex = 0;
            this.btnVotar.Text = "Votar";
            this.btnVotar.UseVisualStyleBackColor = true;
            this.btnVotar.Click += new System.EventHandler(this.btnVotar_Click);
            // 
            // btnInfoVotacion
            // 
            this.btnInfoVotacion.Location = new System.Drawing.Point(445, 194);
            this.btnInfoVotacion.Name = "btnInfoVotacion";
            this.btnInfoVotacion.Size = new System.Drawing.Size(270, 81);
            this.btnInfoVotacion.TabIndex = 1;
            this.btnInfoVotacion.Text = "Informacion de votación";
            this.btnInfoVotacion.UseVisualStyleBackColor = true;
            this.btnInfoVotacion.Click += new System.EventHandler(this.btnInfoVotacion_Click);
            // 
            // btnCerrarSesion
            // 
            this.btnCerrarSesion.Location = new System.Drawing.Point(757, 194);
            this.btnCerrarSesion.Name = "btnCerrarSesion";
            this.btnCerrarSesion.Size = new System.Drawing.Size(270, 81);
            this.btnCerrarSesion.TabIndex = 2;
            this.btnCerrarSesion.Text = "Cerrar sesion";
            this.btnCerrarSesion.UseVisualStyleBackColor = true;
            this.btnCerrarSesion.Click += new System.EventHandler(this.btnCerrarSesion_Click);
            // 
            // FrmMenuVotante
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(14F, 29F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1178, 482);
            this.Controls.Add(this.btnCerrarSesion);
            this.Controls.Add(this.btnInfoVotacion);
            this.Controls.Add(this.btnVotar);
            this.Font = new System.Drawing.Font("Glacial Indifference", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.Margin = new System.Windows.Forms.Padding(4);
            this.Name = "FrmMenuVotante";
            this.Text = "FrmMenuVotante";
            this.Load += new System.EventHandler(this.FrmMenuVotante_Load);
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Button btnVotar;
        private System.Windows.Forms.Button btnInfoVotacion;
        private System.Windows.Forms.Button btnCerrarSesion;
    }
}