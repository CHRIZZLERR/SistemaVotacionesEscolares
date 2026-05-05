using System;
using System.Windows.Forms;
using SistemaVotaciones.BLL;
using SistemaVotaciones.Entidades;

namespace SistemaVotaciones.UI
{
    public partial class FrmVotaciones : Form
    {
        private VotacionBLL bll = new VotacionBLL();

        public FrmVotaciones()
        {
            InitializeComponent();
        }

        private void FrmVotaciones_Load(object sender, EventArgs e)
        {
            CargarEstados();
            CargarPadrones();
            CargarVotaciones();
        }

        private void CargarEstados()
        {
            cmbEstado.Items.Clear();
            cmbEstado.Items.Add("Pendiente");
            cmbEstado.Items.Add("Abierta");
            cmbEstado.Items.Add("Cerrada");
            cmbEstado.SelectedIndex = 0;
        }

        private void CargarPadrones()
        {
            cmbPadron.DataSource = bll.ListarPadrones();
            cmbPadron.DisplayMember = "NombrePadron";
            cmbPadron.ValueMember = "IdPadron";
        }

        private void CargarVotaciones()
        {
            dgvVotaciones.DataSource = bll.Listar();
        }

        private void CrearVotacion()
        {
            if (string.IsNullOrWhiteSpace(txtNombre.Text) ||
                cmbPadron.SelectedValue == null ||
                string.IsNullOrWhiteSpace(cmbEstado.Text))
            {
                MessageBox.Show("Debe completar todos los campos.");
                return;
            }

            if (dtFin.Value <= dtInicio.Value)
            {
                MessageBox.Show("La fecha final debe ser mayor que la fecha inicial.");
                return;
            }

            Votacion votacion = new Votacion
            {
                NombreVotacion = txtNombre.Text.Trim(),
                IdPadron = Convert.ToInt32(cmbPadron.SelectedValue),
                FechaInicio = dtInicio.Value,
                FechaFin = dtFin.Value,
                EstadoVotacion = cmbEstado.Text
            };

            if (bll.Crear(votacion))
            {
                MessageBox.Show("Votación creada correctamente.");
                txtNombre.Clear();
                CargarVotaciones();
            }
            else
            {
                MessageBox.Show("Error al crear votación.");
            }
        }

        private void btnCrear_Click(object sender, EventArgs e)
        {
            CrearVotacion();
        }

        private void btnCrear_Click_1(object sender, EventArgs e)
        {
            CrearVotacion();
        }

        private void lblNombre_Click(object sender, EventArgs e) { }

        private void dgvVotaciones_CellContentClick(object sender, DataGridViewCellEventArgs e) { }

        private void cmbEstado_SelectedIndexChanged(object sender, EventArgs e) { }

        private void dtFin_ValueChanged(object sender, EventArgs e) { }

        private void dtInicio_ValueChanged(object sender, EventArgs e) { }

        private void cmbPadron_SelectedIndexChanged(object sender, EventArgs e) { }

        private void txtNombre_TextChanged(object sender, EventArgs e) { }

        private void lblEstado_Click(object sender, EventArgs e) { }

        private void lblFin_Click(object sender, EventArgs e) { }

        private void lblInicio_Click(object sender, EventArgs e) { }

        private void lblPadron_Click(object sender, EventArgs e) { }

        private void btnCerrar_Click(object sender, EventArgs e)
        {
            this.Close();
        }
    }
}