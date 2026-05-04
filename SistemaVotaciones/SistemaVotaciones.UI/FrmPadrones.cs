using System;
using System.Windows.Forms;
using SistemaVotaciones.BLL;
using SistemaVotaciones.Entidades;

namespace SistemaVotaciones.UI
{
    public partial class FrmPadrones : Form
    {
        private PadronBLL bll = new PadronBLL();

        public FrmPadrones()
        {
            InitializeComponent();
        }

        private void FrmPadrones_Load(object sender, EventArgs e)
        {
            CargarNiveles();
            CargarPadrones();
        }

        private void CargarNiveles()
        {
            cmbNivel.Items.Clear();
            cmbNivel.Items.Add("Primaria");
            cmbNivel.Items.Add("Secundaria");

            if (cmbNivel.Items.Count > 0)
            {
                cmbNivel.SelectedIndex = 0;
            }
        }

        private void CargarPadrones()
        {
            dgvPadrones.DataSource = bll.Listar();
            dgvPadrones.AllowUserToAddRows = false;
        }

        private void LimpiarCampos()
        {
            txtNombrePadron.Clear();
            txtGrado.Clear();
            txtSeccion.Clear();
            txtModalidad.Clear();

            if (cmbNivel.Items.Count > 0)
            {
                cmbNivel.SelectedIndex = 0;
            }

            txtNombrePadron.Focus();
        }

        private void btnCrear_Click(object sender, EventArgs e)
        {
            if (string.IsNullOrWhiteSpace(txtNombrePadron.Text) ||
                string.IsNullOrWhiteSpace(cmbNivel.Text) ||
                string.IsNullOrWhiteSpace(txtGrado.Text) ||
                string.IsNullOrWhiteSpace(txtSeccion.Text) ||
                string.IsNullOrWhiteSpace(txtModalidad.Text))
            {
                MessageBox.Show("Debe completar todos los campos.");
                return;
            }

            Padron padron = new Padron
            {
                NombrePadron = txtNombrePadron.Text.Trim(),
                Nivel = cmbNivel.Text.Trim(),
                Grado = txtGrado.Text.Trim(),
                Seccion = txtSeccion.Text.Trim(),
                Modalidad = txtModalidad.Text.Trim()
            };

            bool creado = bll.Crear(padron);

            if (creado)
            {
                MessageBox.Show("Padrón creado correctamente.");
                LimpiarCampos();
                CargarPadrones();
            }
            else
            {
                MessageBox.Show("No se pudo crear el padrón. Puede que ya exista un padrón con ese nombre.");
            }
        }

        private void btnCerrar_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void dgvPadrones_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }

        private void cmbNivel_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

        private void txtModalidad_TextChanged(object sender, EventArgs e)
        {

        }

        private void txtSeccion_TextChanged(object sender, EventArgs e)
        {

        }

        private void txtGrado_TextChanged(object sender, EventArgs e)
        {

        }

        private void lblModalidad_Click(object sender, EventArgs e)
        {

        }

        private void lblSeccion_Click(object sender, EventArgs e)
        {

        }

        private void lblGrado_Click(object sender, EventArgs e)
        {

        }

        private void lblNivel_Click(object sender, EventArgs e)
        {

        }

        private void txtNombrePadron_TextChanged(object sender, EventArgs e)
        {

        }

        private void lblNombrePadron_Click(object sender, EventArgs e)
        {

        }

        private void lblTituloPadrones_Click(object sender, EventArgs e)
        {

        }
    }
}