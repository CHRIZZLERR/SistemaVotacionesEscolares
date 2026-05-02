using System;
using System.Windows.Forms;
using SistemaVotaciones.BLL;
using SistemaVotaciones.Entidades;

namespace SistemaVotaciones.UI
{
    public partial class FrmPlanchas : Form
    {
        private PlanchaBLL bll = new PlanchaBLL();

        public FrmPlanchas()
        {
            InitializeComponent();

            CargarPadrones();
            CargarAdminsPlancha();
            CargarPlanchas();
        }

        private void CargarPadrones()
        {
            cmbPadron.DataSource = bll.ListarPadrones();
            cmbPadron.DisplayMember = "NombrePadron";
            cmbPadron.ValueMember = "IdPadron";
        }

        private void CargarAdminsPlancha()
        {
            cmbAdminPlancha.DataSource = bll.ListarAdminsPlancha();
            cmbAdminPlancha.DisplayMember = "NombreCompleto";
            cmbAdminPlancha.ValueMember = "IdUsuario";
        }

        private void CargarPlanchas()
        {
            dgvPlanchas.DataSource = bll.Listar();
        }

        private void btnCrearPlancha_Click(object sender, EventArgs e)
        {
            if (string.IsNullOrWhiteSpace(txtNombrePlancha.Text) ||
                string.IsNullOrWhiteSpace(txtColor.Text) ||
                string.IsNullOrWhiteSpace(txtLema.Text) ||
                cmbPadron.SelectedValue == null ||
                cmbAdminPlancha.SelectedValue == null)
            {
                MessageBox.Show("Debe completar todos los campos.");
                return;
            }

            Plancha plancha = new Plancha
            {
                NombrePlancha = txtNombrePlancha.Text.Trim(),
                Color = txtColor.Text.Trim(),
                Lema = txtLema.Text.Trim(),
                IdPadron = Convert.ToInt32(cmbPadron.SelectedValue),
                IdAdminPlancha = Convert.ToInt32(cmbAdminPlancha.SelectedValue),
                EstadoPlancha = true
            };

            if (bll.Crear(plancha))
            {
                MessageBox.Show("Plancha creada correctamente.");

                txtNombrePlancha.Clear();
                txtColor.Clear();
                txtLema.Clear();

                CargarPlanchas();
            }
            else
            {
                MessageBox.Show("Error al crear plancha.");
            }
        }

        private void dgvPlanchas_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }

        private void cmbAdminPlancha_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

        private void cmbPadron_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

        private void txtLema_TextChanged(object sender, EventArgs e)
        {

        }

        private void txtColor_TextChanged(object sender, EventArgs e)
        {

        }

        private void txtNombrePlancha_TextChanged(object sender, EventArgs e)
        {

        }

        private void lblLema_Click(object sender, EventArgs e)
        {

        }

        private void lblAdminPlancha_Click(object sender, EventArgs e)
        {

        }

        private void lblPadron_Click(object sender, EventArgs e)
        {

        }

        private void lblColor_Click(object sender, EventArgs e)
        {

        }

        private void lblNombrePlancha_Click(object sender, EventArgs e)
        {

        }
    }
}