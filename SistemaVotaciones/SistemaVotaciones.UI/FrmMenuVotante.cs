using System;
using System.Windows.Forms;
using SistemaVotaciones.Entidades;

namespace SistemaVotaciones.UI
{
    public partial class FrmMenuVotante : Form
    {
        private Usuario usuarioActual;

        public FrmMenuVotante(Usuario usuario)
        {
            InitializeComponent();
            usuarioActual = usuario;
        }

        private void FrmMenuVotante_Load(object sender, EventArgs e)
        {

        }

        private void btnVotar_Click(object sender, EventArgs e)
        {
            if (usuarioActual == null)
            {
                MessageBox.Show("No se recibió información del usuario.");
                return;
            }

            if (usuarioActual.YaVoto)
            {
                MessageBox.Show("Ya usted realizó su voto. No puede votar nuevamente.");
                return;
            }

            FrmVotar frm = new FrmVotar(usuarioActual);
            frm.ShowDialog();

            if (usuarioActual.YaVoto)
            {
                MessageBox.Show("Su estado de votación fue actualizado. Ya no podrá votar nuevamente.");
            }
        }

        private void btnInfoVotacion_Click(object sender, EventArgs e)
        {
            if (usuarioActual == null)
            {
                MessageBox.Show("No se recibió información del usuario.");
                return;
            }

            FrmInfoVotacion frm = new FrmInfoVotacion(usuarioActual);
            frm.ShowDialog();
        }

        private void btnCerrarSesion_Click(object sender, EventArgs e)
        {
            FrmLogin login = new FrmLogin();
            login.Show();
            this.Close();
        }
    }
}