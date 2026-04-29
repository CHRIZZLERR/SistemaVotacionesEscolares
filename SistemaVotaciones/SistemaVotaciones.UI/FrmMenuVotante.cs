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

        private void btnCerrarSesion_Click(object sender, EventArgs e)
        {
            FrmLogin login = new FrmLogin();
            login.Show();
            this.Close();
        }

        private void btnInfoVotacion_Click(object sender, EventArgs e)
        {
            MessageBox.Show("Aquí se mostrará la información general de la votación.");
        }

        private void btnVotar_Click(object sender, EventArgs e)
        {
            if (usuarioActual.YaVoto)
            {
                MessageBox.Show("Ya usted realizó su voto. No puede votar nuevamente.");
                return;
            }

            MessageBox.Show("Aquí se abrirá el módulo para votar.");
        }
    }
}