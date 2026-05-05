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

        private void FrmMenuAdmin_Load(object sender, EventArgs e)
        {
            ConfigurarMenuPorRol();
        }

        private void ConfigurarMenuPorRol()
        {
            if (usuarioActual == null)
                return;

            if (usuarioActual.IdRol == 1)
            {
                lblManuAdmin.Text = "Admin Menu";

                btnUsuarios.Visible = true;
                btnPadrones.Visible = true;
                btnVotaciones.Visible = true;
                btnPlanchas.Visible = true;
                btnResultados.Visible = true;
                btnReportes.Visible = true;
                btnIntegrantesPlancha.Visible = true;
            }
            else if (usuarioActual.IdRol == 3)
            {
                lblManuAdmin.Text = "Panel Admin Plancha";

                btnUsuarios.Visible = true;
                btnResultados.Visible = true;
                btnIntegrantesPlancha.Visible = true;

                btnPadrones.Visible = false;
                btnVotaciones.Visible = false;
                btnPlanchas.Visible = false;
                btnReportes.Visible = false;
            }
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
            FrmUsuarios frm = new FrmUsuarios(usuarioActual);
            frm.ShowDialog();
        }

        private void btnIntegrantesPlancha_Click(object sender, EventArgs e)
        {
            FrmIntegrantesPlancha frm = new FrmIntegrantesPlancha(usuarioActual);
            frm.ShowDialog();
        }

        private void lblManuAdmin_Click(object sender, EventArgs e)
        {

        }
    }
}