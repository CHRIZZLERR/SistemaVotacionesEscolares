using System;
using System.Data;
using System.Drawing;
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

        private Panel panelPrincipal;
        private Label lblTituloNuevo;
        private Label lblSubtituloNuevo;

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
            AplicarDiseno();
            CrearTablaTemporal();
            CargarCombos();
            CargarIntegrantesGuardados();
            ConfigurarPermisos();
        }

        private void AplicarDiseno()
        {
            OcultarTitulosViejos();

            this.Text = "Integrantes de Plancha - Sistema de Votaciones";
            this.StartPosition = FormStartPosition.CenterScreen;
            this.Size = new Size(1180, 700);
            this.FormBorderStyle = FormBorderStyle.FixedSingle;
            this.MaximizeBox = false;
            this.BackColor = Color.FromArgb(8, 18, 55);

            CrearPanelPrincipal();
            CrearEncabezado();
            ConfigurarCampos();
            ConfigurarTabla();
            ConfigurarBotones();
        }

        private void OcultarTitulosViejos()
        {
            foreach (Control control in this.Controls)
            {
                if (control is Label label)
                {
                    label.Visible = false;
                }
            }
        }

        private void CrearPanelPrincipal()
        {
            panelPrincipal = new Panel();
            panelPrincipal.BackColor = Color.FromArgb(245, 248, 255);
            panelPrincipal.Location = new Point(35, 30);
            panelPrincipal.Size = new Size(1095, 600);
            panelPrincipal.BorderStyle = BorderStyle.None;
            this.Controls.Add(panelPrincipal);
            panelPrincipal.BringToFront();
        }

        private void CrearEncabezado()
        {
            Panel panelHeader = new Panel();
            panelHeader.BackColor = Color.FromArgb(10, 38, 95);
            panelHeader.Location = new Point(0, 0);
            panelHeader.Size = new Size(1095, 105);
            panelPrincipal.Controls.Add(panelHeader);

            lblTituloNuevo = new Label();
            lblTituloNuevo.Text = "Gestión de Integrantes";
            lblTituloNuevo.Font = new Font("Segoe UI", 25, FontStyle.Bold);
            lblTituloNuevo.ForeColor = Color.White;
            lblTituloNuevo.BackColor = Color.Transparent;
            lblTituloNuevo.TextAlign = ContentAlignment.MiddleCenter;
            lblTituloNuevo.AutoSize = false;
            lblTituloNuevo.Location = new Point(20, 20);
            lblTituloNuevo.Size = new Size(1055, 45);
            panelHeader.Controls.Add(lblTituloNuevo);

            lblSubtituloNuevo = new Label();
            lblSubtituloNuevo.Text = "Asigna los cargos e integrantes correspondientes a cada plancha";
            lblSubtituloNuevo.Font = new Font("Segoe UI", 10, FontStyle.Bold);
            lblSubtituloNuevo.ForeColor = Color.FromArgb(255, 215, 90);
            lblSubtituloNuevo.BackColor = Color.Transparent;
            lblSubtituloNuevo.TextAlign = ContentAlignment.MiddleCenter;
            lblSubtituloNuevo.AutoSize = false;
            lblSubtituloNuevo.Location = new Point(20, 65);
            lblSubtituloNuevo.Size = new Size(1055, 25);
            panelHeader.Controls.Add(lblSubtituloNuevo);
        }

        private void ConfigurarCampos()
        {
            panelPrincipal.Controls.Add(lblPlancha);
            panelPrincipal.Controls.Add(cmbPlancha);

            panelPrincipal.Controls.Add(lblCargo);
            panelPrincipal.Controls.Add(cmbCargo);

            panelPrincipal.Controls.Add(lblUsuario);
            panelPrincipal.Controls.Add(cmbUsuario);

            lblPlancha.Visible = true;
            cmbPlancha.Visible = true;

            lblCargo.Visible = true;
            cmbCargo.Visible = true;

            lblUsuario.Visible = true;
            cmbUsuario.Visible = true;

            int xLabel = 45;
            int xInput = 45;
            int y = 145;
            int espacio = 85;

            ConfigurarLabel(lblPlancha, "Plancha");
            lblPlancha.Location = new Point(xLabel, y);
            lblPlancha.Size = new Size(280, 25);

            cmbPlancha.Location = new Point(xInput, y + 30);
            cmbPlancha.Size = new Size(315, 30);
            ConfigurarComboBox(cmbPlancha);

            ConfigurarLabel(lblCargo, "Cargo");
            lblCargo.Location = new Point(xLabel, y + espacio);
            lblCargo.Size = new Size(280, 25);

            cmbCargo.Location = new Point(xInput, y + espacio + 30);
            cmbCargo.Size = new Size(315, 30);
            ConfigurarComboBox(cmbCargo);

            ConfigurarLabel(lblUsuario, "Usuario candidato");
            lblUsuario.Location = new Point(xLabel, y + espacio * 2);
            lblUsuario.Size = new Size(280, 25);

            cmbUsuario.Location = new Point(xInput, y + espacio * 2 + 30);
            cmbUsuario.Size = new Size(315, 30);
            ConfigurarComboBox(cmbUsuario);
        }

        private void ConfigurarTabla()
        {
            panelPrincipal.Controls.Add(dgvIntegrantes);

            dgvIntegrantes.Visible = true;
            dgvIntegrantes.Location = new Point(405, 145);
            dgvIntegrantes.Size = new Size(645, 355);
            dgvIntegrantes.BackgroundColor = Color.White;
            dgvIntegrantes.BorderStyle = BorderStyle.FixedSingle;

            dgvIntegrantes.EnableHeadersVisualStyles = false;
            dgvIntegrantes.ColumnHeadersDefaultCellStyle.BackColor = Color.FromArgb(10, 38, 95);
            dgvIntegrantes.ColumnHeadersDefaultCellStyle.ForeColor = Color.White;
            dgvIntegrantes.ColumnHeadersDefaultCellStyle.Font = new Font("Segoe UI", 10, FontStyle.Bold);

            dgvIntegrantes.DefaultCellStyle.Font = new Font("Segoe UI", 10, FontStyle.Regular);
            dgvIntegrantes.DefaultCellStyle.SelectionBackColor = Color.FromArgb(21, 101, 192);
            dgvIntegrantes.DefaultCellStyle.SelectionForeColor = Color.White;

            dgvIntegrantes.RowHeadersDefaultCellStyle.BackColor = Color.FromArgb(10, 38, 95);
            dgvIntegrantes.RowHeadersDefaultCellStyle.ForeColor = Color.White;

            dgvIntegrantes.AllowUserToAddRows = false;
            dgvIntegrantes.ReadOnly = true;
            dgvIntegrantes.SelectionMode = DataGridViewSelectionMode.FullRowSelect;
            dgvIntegrantes.MultiSelect = false;
            dgvIntegrantes.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.None;
        }

        private void ConfigurarBotones()
        {
            panelPrincipal.Controls.Add(btnAgregar);
            panelPrincipal.Controls.Add(btnGuardar);
            panelPrincipal.Controls.Add(btnCerrar);

            btnAgregar.Visible = true;
            btnGuardar.Visible = true;
            btnCerrar.Visible = true;

            btnAgregar.Text = "Agregar integrante";
            btnGuardar.Text = "Guardar integrantes";
            btnCerrar.Text = "Cerrar";

            btnAgregar.Location = new Point(45, 430);
            btnAgregar.Size = new Size(315, 45);

            btnGuardar.Location = new Point(405, 525);
            btnGuardar.Size = new Size(260, 45);

            btnCerrar.Location = new Point(830, 525);
            btnCerrar.Size = new Size(220, 45);

            EstiloBoton(btnAgregar);
            EstiloBoton(btnGuardar);
            EstiloBotonCerrar(btnCerrar);

            btnAgregar.BringToFront();
            btnGuardar.BringToFront();
            btnCerrar.BringToFront();
        }

        private void ConfigurarLabel(Label label, string texto)
        {
            label.Text = texto;
            label.Font = new Font("Segoe UI", 10, FontStyle.Bold);
            label.ForeColor = Color.FromArgb(10, 38, 95);
            label.BackColor = Color.Transparent;
        }

        private void ConfigurarComboBox(ComboBox comboBox)
        {
            comboBox.Font = new Font("Segoe UI", 10, FontStyle.Regular);
            comboBox.BackColor = Color.White;
            comboBox.ForeColor = Color.Black;
            comboBox.DropDownStyle = ComboBoxStyle.DropDownList;
        }

        private void EstiloBoton(Button boton)
        {
            boton.FlatStyle = FlatStyle.Flat;
            boton.FlatAppearance.BorderSize = 0;
            boton.BackColor = Color.FromArgb(21, 101, 192);
            boton.ForeColor = Color.White;
            boton.Font = new Font("Segoe UI", 10, FontStyle.Bold);
            boton.Cursor = Cursors.Hand;

            boton.MouseEnter += (s, e) =>
            {
                if (boton.Enabled)
                    boton.BackColor = Color.FromArgb(25, 118, 210);
            };

            boton.MouseLeave += (s, e) =>
            {
                if (boton.Enabled)
                    boton.BackColor = Color.FromArgb(21, 101, 192);
            };
        }

        private void EstiloBotonCerrar(Button boton)
        {
            boton.FlatStyle = FlatStyle.Flat;
            boton.FlatAppearance.BorderSize = 0;
            boton.BackColor = Color.FromArgb(185, 28, 28);
            boton.ForeColor = Color.White;
            boton.Font = new Font("Segoe UI", 10, FontStyle.Bold);
            boton.Cursor = Cursors.Hand;

            boton.MouseEnter += (s, e) =>
            {
                boton.BackColor = Color.FromArgb(220, 38, 38);
            };

            boton.MouseLeave += (s, e) =>
            {
                boton.BackColor = Color.FromArgb(185, 28, 28);
            };
        }

        private void ConfigurarPermisos()
        {
            if (usuarioActual != null && usuarioActual.IdRol == 3)
            {
                lblTituloNuevo.Text = "Integrantes de mi Plancha";
                lblSubtituloNuevo.Text = "Administra únicamente los integrantes de la plancha asignada a tu usuario.";

                cmbPlancha.Enabled = false;
                btnAgregar.Enabled = true;
                btnGuardar.Enabled = true;
            }
            else
            {
                lblTituloNuevo.Text = "Gestión de Integrantes";
                lblSubtituloNuevo.Text = "Asigna los cargos e integrantes correspondientes a cada plancha.";

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
                dgvIntegrantes.Columns["NombrePlancha"].Width = 190;

            if (dgvIntegrantes.Columns.Contains("NombreCompleto"))
                dgvIntegrantes.Columns["NombreCompleto"].Width = 220;

            if (dgvIntegrantes.Columns.Contains("NombreCargo"))
                dgvIntegrantes.Columns["NombreCargo"].Width = 170;

            if (dgvIntegrantes.Columns.Contains("Plancha"))
                dgvIntegrantes.Columns["Plancha"].Width = 190;

            if (dgvIntegrantes.Columns.Contains("Cargo"))
                dgvIntegrantes.Columns["Cargo"].Width = 170;

            if (dgvIntegrantes.Columns.Contains("Usuario"))
                dgvIntegrantes.Columns["Usuario"].Width = 220;
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