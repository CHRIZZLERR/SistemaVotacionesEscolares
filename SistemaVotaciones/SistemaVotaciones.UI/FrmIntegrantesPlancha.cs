using System;
using System.Data;
using System.Windows.Forms;
using SistemaVotaciones.BLL;
using SistemaVotaciones.Entidades;

namespace SistemaVotaciones.UI
{
    public partial class FrmIntegrantesPlancha : Form
    {
        private IntegrantePlanchaBLL bll = new IntegrantePlanchaBLL();
        private DataTable tablaTemporal = new DataTable();

        public FrmIntegrantesPlancha()
        {
            InitializeComponent();
        }

        private void FrmIntegrantesPlancha_Load(object sender, EventArgs e)
        {
            CargarCombos();
            CrearTablaTemporal();
        }

        private void CargarCombos()
        {
            cmbPlancha.DataSource = bll.ListarPlanchas();
            cmbPlancha.DisplayMember = "NombrePlancha";
            cmbPlancha.ValueMember = "IdPlancha";

            cmbCargo.DataSource = bll.ListarCargos();
            cmbCargo.DisplayMember = "NombreCargo";
            cmbCargo.ValueMember = "IdCargo";

            cmbUsuario.DataSource = bll.ListarUsuarios();
            cmbUsuario.DisplayMember = "NombreCompleto";
            cmbUsuario.ValueMember = "IdUsuario";
        }

        private void CrearTablaTemporal()
        {
            tablaTemporal.Columns.Add("IdPlancha", typeof(int));
            tablaTemporal.Columns.Add("Plancha", typeof(string));
            tablaTemporal.Columns.Add("IdCargo", typeof(int));
            tablaTemporal.Columns.Add("Cargo", typeof(string));
            tablaTemporal.Columns.Add("IdUsuario", typeof(int));
            tablaTemporal.Columns.Add("Usuario", typeof(string));

            dgvIntegrantes.DataSource = tablaTemporal;
        }

        private void btnAgregar_Click(object sender, EventArgs e)
        {
            if (cmbPlancha.SelectedValue == null ||
                cmbCargo.SelectedValue == null ||
                cmbUsuario.SelectedValue == null)
            {
                MessageBox.Show("Debe seleccionar plancha, cargo y usuario.");
                return;
            }

            int idPlancha = Convert.ToInt32(cmbPlancha.SelectedValue);
            int idCargo = Convert.ToInt32(cmbCargo.SelectedValue);
            int idUsuario = Convert.ToInt32(cmbUsuario.SelectedValue);

            foreach (DataRow row in tablaTemporal.Rows)
            {
                if (Convert.ToInt32(row["IdCargo"]) == idCargo)
                {
                    MessageBox.Show("Ese cargo ya fue asignado en esta plancha.");
                    return;
                }

                if (Convert.ToInt32(row["IdUsuario"]) == idUsuario)
                {
                    MessageBox.Show("Ese usuario ya fue agregado a esta plancha.");
                    return;
                }
            }

            if (tablaTemporal.Rows.Count >= 9)
            {
                MessageBox.Show("Una plancha solo puede tener 9 integrantes.");
                return;
            }

            tablaTemporal.Rows.Add(
                idPlancha,
                cmbPlancha.Text,
                idCargo,
                cmbCargo.Text,
                idUsuario,
                cmbUsuario.Text
            );
        }

        private void btnGuardar_Click(object sender, EventArgs e)
        {
            if (tablaTemporal.Rows.Count != 9)
            {
                MessageBox.Show("Debe agregar exactamente 9 integrantes antes de guardar.");
                return;
            }

            bool todoGuardado = true;

            foreach (DataRow row in tablaTemporal.Rows)
            {
                IntegrantePlancha integrante = new IntegrantePlancha
                {
                    IdPlancha = Convert.ToInt32(row["IdPlancha"]),
                    IdCargo = Convert.ToInt32(row["IdCargo"]),
                    IdUsuario = Convert.ToInt32(row["IdUsuario"])
                };

                if (!bll.GuardarIntegrante(integrante))
                {
                    todoGuardado = false;
                }
            }

            if (todoGuardado)
            {
                MessageBox.Show("Integrantes guardados correctamente.");
                tablaTemporal.Clear();
            }
            else
            {
                MessageBox.Show("Ocurrió un error al guardar algunos integrantes.");
            }
        }

        private void lblUsuario_Click(object sender, EventArgs e) { }

        private void lblCargo_Click(object sender, EventArgs e) { }

        private void lblPlancha_Click(object sender, EventArgs e) { }

        private void dgvIntegrantes_CellContentClick(object sender, DataGridViewCellEventArgs e) { }

        private void cmbUsuario_SelectedIndexChanged(object sender, EventArgs e) { }

        private void cmbCargo_SelectedIndexChanged(object sender, EventArgs e) { }

        private void cmbPlancha_SelectedIndexChanged(object sender, EventArgs e) { }
    }
}