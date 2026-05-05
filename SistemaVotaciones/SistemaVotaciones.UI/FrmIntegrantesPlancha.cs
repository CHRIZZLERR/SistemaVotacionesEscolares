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
        private Usuario usuarioActual;

        public FrmIntegrantesPlancha()
        {
            InitializeComponent();
        }

        public FrmIntegrantesPlancha(Usuario usuario)
        {
            InitializeComponent();
            usuarioActual = usuario;
        }

        private void FrmIntegrantesPlancha_Load(object sender, EventArgs e)
        {
            CrearTablaTemporal();
            CargarCombos();
            CargarIntegrantesGuardados();
            ConfigurarPermisos();
        }

        private void ConfigurarPermisos()
        {
            if (usuarioActual != null && usuarioActual.IdRol == 3)
            {
                lblTitulo.Text = "Integrantes de mi Plancha";
                cmbPlancha.Enabled = false;
                btnAgregar.Enabled = true;
                btnGuardar.Enabled = true;
            }
            else
            {
                lblTitulo.Text = "Integrantes Planchas";
                cmbPlancha.Enabled = true;
                btnAgregar.Enabled = true;
                btnGuardar.Enabled = true;
            }
        }

        private void CargarCombos()
        {
            if (usuarioActual != null && usuarioActual.IdRol == 3)
            {
                cmbPlancha.DataSource = bll.ListarPlanchasPorAdmin(usuarioActual.IdUsuario);
                cmbPlancha.DisplayMember = "NombrePlancha";
                cmbPlancha.ValueMember = "IdPlancha";
            }
            else
            {
                cmbPlancha.DataSource = bll.ListarPlanchas();
                cmbPlancha.DisplayMember = "NombrePlancha";
                cmbPlancha.ValueMember = "IdPlancha";
            }

            cmbCargo.DataSource = bll.ListarCargos();
            cmbCargo.DisplayMember = "NombreCargo";
            cmbCargo.ValueMember = "IdCargo";

            cmbUsuario.DataSource = bll.ListarUsuarios();
            cmbUsuario.DisplayMember = "NombreCompleto";
            cmbUsuario.ValueMember = "IdUsuario";
        }

        private void CrearTablaTemporal()
        {
            tablaTemporal.Columns.Clear();
            tablaTemporal.Columns.Add("IdPlancha", typeof(int));
            tablaTemporal.Columns.Add("Plancha", typeof(string));
            tablaTemporal.Columns.Add("IdCargo", typeof(int));
            tablaTemporal.Columns.Add("Cargo", typeof(string));
            tablaTemporal.Columns.Add("IdUsuario", typeof(int));
            tablaTemporal.Columns.Add("Usuario", typeof(string));
        }

        private void CargarIntegrantesGuardados()
        {
            try
            {
                if (usuarioActual != null && usuarioActual.IdRol == 3)
                {
                    dgvIntegrantes.DataSource = bll.ListarIntegrantesGuardadosPorAdmin(usuarioActual.IdUsuario);
                }
                else
                {
                    dgvIntegrantes.DataSource = bll.ListarIntegrantesGuardados();
                }

                dgvIntegrantes.AllowUserToAddRows = false;
                dgvIntegrantes.ReadOnly = true;
                dgvIntegrantes.SelectionMode = DataGridViewSelectionMode.FullRowSelect;
                dgvIntegrantes.MultiSelect = false;
                dgvIntegrantes.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.None;

                AjustarColumnas();
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error al cargar integrantes:\n" + ex.Message);
            }
        }

        private void MostrarTablaTemporal()
        {
            dgvIntegrantes.DataSource = tablaTemporal;
            dgvIntegrantes.AllowUserToAddRows = false;
            dgvIntegrantes.ReadOnly = true;
            dgvIntegrantes.SelectionMode = DataGridViewSelectionMode.FullRowSelect;
            dgvIntegrantes.MultiSelect = false;
            dgvIntegrantes.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.None;

            AjustarColumnas();
        }

        private void AjustarColumnas()
        {
            if (dgvIntegrantes.Columns.Count == 0)
                return;

            if (dgvIntegrantes.Columns.Contains("IdIntegrante"))
                dgvIntegrantes.Columns["IdIntegrante"].Width = 90;

            if (dgvIntegrantes.Columns.Contains("NombrePlancha"))
                dgvIntegrantes.Columns["NombrePlancha"].Width = 180;

            if (dgvIntegrantes.Columns.Contains("NombreCompleto"))
                dgvIntegrantes.Columns["NombreCompleto"].Width = 200;

            if (dgvIntegrantes.Columns.Contains("NombreCargo"))
                dgvIntegrantes.Columns["NombreCargo"].Width = 160;

            if (dgvIntegrantes.Columns.Contains("Plancha"))
                dgvIntegrantes.Columns["Plancha"].Width = 180;

            if (dgvIntegrantes.Columns.Contains("Cargo"))
                dgvIntegrantes.Columns["Cargo"].Width = 160;

            if (dgvIntegrantes.Columns.Contains("Usuario"))
                dgvIntegrantes.Columns["Usuario"].Width = 200;
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

            if (cmbPlancha.SelectedValue is DataRowView ||
                cmbCargo.SelectedValue is DataRowView ||
                cmbUsuario.SelectedValue is DataRowView)
            {
                return;
            }

            int idPlancha = Convert.ToInt32(cmbPlancha.SelectedValue);
            int idCargo = Convert.ToInt32(cmbCargo.SelectedValue);
            int idUsuario = Convert.ToInt32(cmbUsuario.SelectedValue);

            if (tablaTemporal.Rows.Count == 0)
            {
                MostrarTablaTemporal();
            }

            foreach (DataRow row in tablaTemporal.Rows)
            {
                if (Convert.ToInt32(row["IdPlancha"]) != idPlancha)
                {
                    MessageBox.Show("Solo puede agregar integrantes de una misma plancha a la vez.");
                    return;
                }

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

            int idPlancha = Convert.ToInt32(tablaTemporal.Rows[0]["IdPlancha"]);

            DialogResult respuesta = MessageBox.Show(
                "¿Desea reemplazar los integrantes actuales de esta plancha por los nuevos?",
                "Confirmar guardado",
                MessageBoxButtons.YesNo,
                MessageBoxIcon.Question
            );

            if (respuesta != DialogResult.Yes)
                return;

            bll.EliminarIntegrantesPorPlancha(idPlancha);

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
                CargarIntegrantesGuardados();
            }
            else
            {
                MessageBox.Show("Ocurrió un error al guardar algunos integrantes.");
            }
        }

        private void btnCerrar_Click(object sender, EventArgs e)
        {
            this.Close();
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