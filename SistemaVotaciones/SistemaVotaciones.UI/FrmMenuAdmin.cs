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
            FrmPlanchas frm = new FrmPlanchas();
            frm.ShowDialog();
        }

        private void btnCerrarSesion_Click(object sender, EventArgs e)
        {
            FrmLogin login = new FrmLogin();
            login.Show();
            this.Close();
        }

        private void btnReportes_Click(object sender, EventArgs e)
        {
            FrmReportes frm = new FrmReportes();
            frm.ShowDialog();
        }

        private void btnResultados_Click(object sender, EventArgs e)
        {
            FrmResultados frm = new FrmResultados();
            frm.ShowDialog();
        }

        private void btnVotaciones_Click(object sender, EventArgs e)
        {
            FrmVotaciones frm = new FrmVotaciones();
            frm.ShowDialog();
        }

        private void btnPadrones_Click(object sender, EventArgs e)
        {
            FrmPadrones frm = new FrmPadrones();
            frm.ShowDialog();
        }

        private void btnUsuarios_Click(object sender, EventArgs e)
        {
            FrmUsuarios frm = new FrmUsuarios();
            frm.ShowDialog();
        }

        private void btnIntegrantesPlancha_Click(object sender, EventArgs e)
        {
            FrmIntegrantesPlancha frm = new FrmIntegrantesPlancha();
            frm.ShowDialog();
        }

        private void FrmMenuAdmin_Load(object sender, EventArgs e)
        {

        }

        private void lblManuAdmin_Click(object sender, EventArgs e)
        {

        }
    }
}