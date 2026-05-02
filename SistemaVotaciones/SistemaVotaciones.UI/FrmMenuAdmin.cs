using System;
using System.Windows.Forms;
using SistemaVotaciones.Entidades;

namespace SistemaVotaciones.UI
{
    public partial class FrmMenuAdmin : Form
    {
        private Usuario usuarioActual;

        public FrmMenuAdmin(Usuario usuario)
        {
            InitializeComponent();
            usuarioActual = usuario;
        }

        private void btnPlanchas_Click(object sender, EventArgs e)
        {
            MessageBox.Show("Aquí se abrirá el módulo de planchas.");
        }

        private void btnCerrarSesion_Click(object sender, EventArgs e)
        {
            FrmLogin login = new FrmLogin();
            login.Show();
            this.Close();
        }

        private void btnReportes_Click(object sender, EventArgs e)
        {
            MessageBox.Show("Aquí se abrirá el módulo de reportes.");
        }

        private void btnResultados_Click(object sender, EventArgs e)
        {
            MessageBox.Show("Aquí se abrirá el módulo de resultados.");
        }

        private void btnVotaciones_Click(object sender, EventArgs e)
        {
            FrmVotaciones frm = new FrmVotaciones();
            frm.ShowDialog();
        }

        private void btnPadrones_Click(object sender, EventArgs e)
        {
            MessageBox.Show("Aquí se abrirá el módulo de padrones.");
        }

        private void btnUsuarios_Click(object sender, EventArgs e)
        {
            MessageBox.Show("Aquí se abrirá el módulo de usuarios.");
        }
    }
}