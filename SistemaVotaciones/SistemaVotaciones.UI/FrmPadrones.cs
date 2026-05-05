using System;
using System.Drawing;
using System.Windows.Forms;
using SistemaVotaciones.BLL;
using SistemaVotaciones.Entidades;

namespace SistemaVotaciones.UI
{
    public partial class FrmPadrones : Form
    {
        private PadronBLL bll = new PadronBLL();

        private Panel panelPrincipal;
        private Label lblTituloNuevo;
        private Label lblSubtituloNuevo;

        public FrmPadrones()
        {
            InitializeComponent();
        }

        private void FrmPadrones_Load(object sender, EventArgs e)
        {
            AplicarDiseno();
            CargarCombos();
            CargarPadrones();
        }

        private void AplicarDiseno()
        {
            OcultarTitulosViejos();

            this.Text = "Padrones - Sistema de Votaciones";
            this.StartPosition = FormStartPosition.CenterScreen;
            this.Size = new Size(1120, 680);
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
            panelPrincipal.Size = new Size(1040, 590);
            panelPrincipal.BorderStyle = BorderStyle.None;
            this.Controls.Add(panelPrincipal);
            panelPrincipal.BringToFront();
        }

        private void CrearEncabezado()
        {
            Panel panelHeader = new Panel();
            panelHeader.BackColor = Color.FromArgb(10, 38, 95);
            panelHeader.Location = new Point(0, 0);
            panelHeader.Size = new Size(1040, 105);
            panelPrincipal.Controls.Add(panelHeader);

            lblTituloNuevo = new Label();
            lblTituloNuevo.Text = "Gestión de Padrones";
            lblTituloNuevo.Font = new Font("Segoe UI", 25, FontStyle.Bold);
            lblTituloNuevo.ForeColor = Color.White;
            lblTituloNuevo.BackColor = Color.Transparent;
            lblTituloNuevo.TextAlign = ContentAlignment.MiddleCenter;
            lblTituloNuevo.AutoSize = false;
            lblTituloNuevo.Location = new Point(20, 20);
            lblTituloNuevo.Size = new Size(1000, 45);
            panelHeader.Controls.Add(lblTituloNuevo);

            lblSubtituloNuevo = new Label();
            lblSubtituloNuevo.Text = "Crea y consulta los padrones electorales del sistema";
            lblSubtituloNuevo.Font = new Font("Segoe UI", 10, FontStyle.Bold);
            lblSubtituloNuevo.ForeColor = Color.FromArgb(255, 215, 90);
            lblSubtituloNuevo.BackColor = Color.Transparent;
            lblSubtituloNuevo.TextAlign = ContentAlignment.MiddleCenter;
            lblSubtituloNuevo.AutoSize = false;
            lblSubtituloNuevo.Location = new Point(20, 65);
            lblSubtituloNuevo.Size = new Size(1000, 25);
            panelHeader.Controls.Add(lblSubtituloNuevo);
        }

        private void ConfigurarCampos()
        {
            panelPrincipal.Controls.Add(lblNombrePadron);
            panelPrincipal.Controls.Add(txtNombrePadron);

            panelPrincipal.Controls.Add(lblNivel);
            panelPrincipal.Controls.Add(cmbNivel);

            panelPrincipal.Controls.Add(lblGrado);
            panelPrincipal.Controls.Add(cmbGrado);

            panelPrincipal.Controls.Add(lblSeccion);
            panelPrincipal.Controls.Add(cmbSeccion);

            panelPrincipal.Controls.Add(lblModalidad);
            panelPrincipal.Controls.Add(cmbModalidad);

            lblNombrePadron.Visible = true;
            txtNombrePadron.Visible = true;

            lblNivel.Visible = true;
            cmbNivel.Visible = true;

            lblGrado.Visible = true;
            cmbGrado.Visible = true;

            lblSeccion.Visible = true;
            cmbSeccion.Visible = true;

            lblModalidad.Visible = true;
            cmbModalidad.Visible = true;

            int xLabel = 45;
            int xInput = 45;
            int y = 135;
            int espacio = 70;

            ConfigurarLabel(lblNombrePadron, "Nombre del padrón");
            lblNombrePadron.Location = new Point(xLabel, y);
            lblNombrePadron.Size = new Size(250, 25);

            txtNombrePadron.Location = new Point(xInput, y + 28);
            txtNombrePadron.Size = new Size(300, 30);
            ConfigurarTextBox(txtNombrePadron);

            ConfigurarLabel(lblNivel, "Nivel");
            lblNivel.Location = new Point(xLabel, y + espacio);
            lblNivel.Size = new Size(250, 25);

            cmbNivel.Location = new Point(xInput, y + espacio + 28);
            cmbNivel.Size = new Size(300, 30);
            ConfigurarComboBox(cmbNivel);

            ConfigurarLabel(lblGrado, "Grado");
            lblGrado.Location = new Point(xLabel, y + espacio * 2);
            lblGrado.Size = new Size(250, 25);

            cmbGrado.Location = new Point(xInput, y + espacio * 2 + 28);
            cmbGrado.Size = new Size(300, 30);
            ConfigurarComboBox(cmbGrado);

            ConfigurarLabel(lblSeccion, "Sección");
            lblSeccion.Location = new Point(xLabel, y + espacio * 3);
            lblSeccion.Size = new Size(250, 25);

            cmbSeccion.Location = new Point(xInput, y + espacio * 3 + 28);
            cmbSeccion.Size = new Size(300, 30);
            ConfigurarComboBox(cmbSeccion);

            ConfigurarLabel(lblModalidad, "Modalidad");
            lblModalidad.Location = new Point(xLabel, y + espacio * 4);
            lblModalidad.Size = new Size(250, 25);

            cmbModalidad.Location = new Point(xInput, y + espacio * 4 + 28);
            cmbModalidad.Size = new Size(300, 30);
            ConfigurarComboBox(cmbModalidad);
        }

        private void ConfigurarTabla()
        {
            panelPrincipal.Controls.Add(dgvPadrones);

            dgvPadrones.Visible = true;
            dgvPadrones.Location = new Point(390, 135);
            dgvPadrones.Size = new Size(610, 365);
            dgvPadrones.BackgroundColor = Color.White;
            dgvPadrones.BorderStyle = BorderStyle.FixedSingle;

            dgvPadrones.EnableHeadersVisualStyles = false;
            dgvPadrones.ColumnHeadersDefaultCellStyle.BackColor = Color.FromArgb(10, 38, 95);
            dgvPadrones.ColumnHeadersDefaultCellStyle.ForeColor = Color.White;
            dgvPadrones.ColumnHeadersDefaultCellStyle.Font = new Font("Segoe UI", 10, FontStyle.Bold);

            dgvPadrones.DefaultCellStyle.Font = new Font("Segoe UI", 10, FontStyle.Regular);
            dgvPadrones.DefaultCellStyle.SelectionBackColor = Color.FromArgb(21, 101, 192);
            dgvPadrones.DefaultCellStyle.SelectionForeColor = Color.White;

            dgvPadrones.RowHeadersDefaultCellStyle.BackColor = Color.FromArgb(10, 38, 95);
            dgvPadrones.RowHeadersDefaultCellStyle.ForeColor = Color.White;

            dgvPadrones.AllowUserToAddRows = false;
            dgvPadrones.ReadOnly = true;
            dgvPadrones.SelectionMode = DataGridViewSelectionMode.FullRowSelect;
            dgvPadrones.MultiSelect = false;
            dgvPadrones.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.None;
        }

        private void ConfigurarBotones()
        {
            panelPrincipal.Controls.Add(btnCrear);
            panelPrincipal.Controls.Add(btnCerrar);

            btnCrear.Visible = true;
            btnCerrar.Visible = true;

            btnCrear.Text = "Crear padrón";
            btnCerrar.Text = "Cerrar";

            btnCrear.Location = new Point(390, 525);
            btnCrear.Size = new Size(220, 45);

            btnCerrar.Location = new Point(780, 525);
            btnCerrar.Size = new Size(220, 45);

            EstiloBoton(btnCrear);
            EstiloBotonCerrar(btnCerrar);

            btnCrear.BringToFront();
            btnCerrar.BringToFront();
        }

        private void ConfigurarLabel(Label label, string texto)
        {
            label.Text = texto;
            label.Font = new Font("Segoe UI", 10, FontStyle.Bold);
            label.ForeColor = Color.FromArgb(10, 38, 95);
            label.BackColor = Color.Transparent;
        }

        private void ConfigurarTextBox(TextBox textBox)
        {
            textBox.Font = new Font("Segoe UI", 10, FontStyle.Regular);
            textBox.BorderStyle = BorderStyle.FixedSingle;
            textBox.BackColor = Color.White;
            textBox.ForeColor = Color.Black;
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
                boton.BackColor = Color.FromArgb(25, 118, 210);
            };

            boton.MouseLeave += (s, e) =>
            {
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

        private void CargarCombos()
        {
            CargarNiveles();
            CargarGrados();
            CargarSecciones();
            CargarModalidades();

            if (cmbNivel.Items.Count > 0)
                cmbNivel.SelectedIndex = 0;

            if (cmbGrado.Items.Count > 0)
                cmbGrado.SelectedIndex = 0;

            if (cmbSeccion.Items.Count > 0)
                cmbSeccion.SelectedIndex = 0;
        }

        private void CargarNiveles()
        {
            cmbNivel.Items.Clear();
            cmbNivel.Items.Add("Primaria");
            cmbNivel.Items.Add("Secundaria");
        }

        private void CargarGrados()
        {
            cmbGrado.Items.Clear();
            cmbGrado.Items.Add("1ro");
            cmbGrado.Items.Add("2do");
            cmbGrado.Items.Add("3ro");
            cmbGrado.Items.Add("4to");
            cmbGrado.Items.Add("5to");
            cmbGrado.Items.Add("6to");
        }

        private void CargarSecciones()
        {
            cmbSeccion.Items.Clear();
            cmbSeccion.Items.Add("A");
            cmbSeccion.Items.Add("B");
            cmbSeccion.Items.Add("C");
        }

        private void CargarModalidades()
        {
            cmbModalidad.Items.Clear();

            if (cmbNivel.Text == "Primaria")
            {
                cmbModalidad.Items.Add("Académico");
                cmbModalidad.SelectedIndex = 0;
                cmbModalidad.Enabled = false;
            }
            else
            {
                cmbModalidad.Enabled = true;
                cmbModalidad.Items.Add("Académico");
                cmbModalidad.Items.Add("Informática");
                cmbModalidad.Items.Add("Gestión");
                cmbModalidad.Items.Add("Electrónica");
                cmbModalidad.Items.Add("Música");

                cmbModalidad.SelectedIndex = 0;
            }
        }

        private void CargarPadrones()
        {
            dgvPadrones.DataSource = bll.Listar();
            dgvPadrones.AllowUserToAddRows = false;

            AjustarColumnas();
        }

        private void AjustarColumnas()
        {
            if (dgvPadrones.Columns.Count == 0)
                return;

            if (dgvPadrones.Columns.Contains("IdPadron"))
                dgvPadrones.Columns["IdPadron"].Width = 80;

            if (dgvPadrones.Columns.Contains("NombrePadron"))
                dgvPadrones.Columns["NombrePadron"].Width = 220;

            if (dgvPadrones.Columns.Contains("Nivel"))
                dgvPadrones.Columns["Nivel"].Width = 110;

            if (dgvPadrones.Columns.Contains("Grado"))
                dgvPadrones.Columns["Grado"].Width = 90;

            if (dgvPadrones.Columns.Contains("Seccion"))
                dgvPadrones.Columns["Seccion"].Width = 90;

            if (dgvPadrones.Columns.Contains("Modalidad"))
                dgvPadrones.Columns["Modalidad"].Width = 150;
        }

        private void LimpiarCampos()
        {
            txtNombrePadron.Clear();

            if (cmbNivel.Items.Count > 0)
                cmbNivel.SelectedIndex = 0;

            if (cmbGrado.Items.Count > 0)
                cmbGrado.SelectedIndex = 0;

            if (cmbSeccion.Items.Count > 0)
                cmbSeccion.SelectedIndex = 0;

            CargarModalidades();

            txtNombrePadron.Focus();
        }

        private string GenerarNombrePadron()
        {
            return cmbNivel.Text.Trim() + " " +
                   cmbGrado.Text.Trim() + " " +
                   cmbSeccion.Text.Trim() + " " +
                   cmbModalidad.Text.Trim();
        }

        private void btnCrear_Click(object sender, EventArgs e)
        {
            if (string.IsNullOrWhiteSpace(txtNombrePadron.Text) ||
                string.IsNullOrWhiteSpace(cmbNivel.Text) ||
                string.IsNullOrWhiteSpace(cmbGrado.Text) ||
                string.IsNullOrWhiteSpace(cmbSeccion.Text) ||
                string.IsNullOrWhiteSpace(cmbModalidad.Text))
            {
                MessageBox.Show("Debe completar todos los campos.");
                return;
            }

            Padron padron = new Padron
            {
                NombrePadron = txtNombrePadron.Text.Trim(),
                Nivel = cmbNivel.Text.Trim(),
                Grado = cmbGrado.Text.Trim(),
                Seccion = cmbSeccion.Text.Trim(),
                Modalidad = cmbModalidad.Text.Trim()
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

        private void ActualizarNombrePadronAutomatico()
        {
            if (!string.IsNullOrWhiteSpace(cmbNivel.Text) &&
                !string.IsNullOrWhiteSpace(cmbGrado.Text) &&
                !string.IsNullOrWhiteSpace(cmbSeccion.Text) &&
                !string.IsNullOrWhiteSpace(cmbModalidad.Text))
            {
                txtNombrePadron.Text = GenerarNombrePadron();
            }
        }

        private void btnCerrar_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void cmbNivel_SelectedIndexChanged(object sender, EventArgs e)
        {
            CargarModalidades();
            ActualizarNombrePadronAutomatico();
        }

        private void cmbGrado_SelectedIndexChanged(object sender, EventArgs e)
        {
            ActualizarNombrePadronAutomatico();
        }

        private void cmbSeccion_SelectedIndexChanged(object sender, EventArgs e)
        {
            ActualizarNombrePadronAutomatico();
        }

        private void cmbModalidad_SelectedIndexChanged(object sender, EventArgs e)
        {
            ActualizarNombrePadronAutomatico();
        }

        private void dgvPadrones_CellContentClick(object sender, DataGridViewCellEventArgs e)
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