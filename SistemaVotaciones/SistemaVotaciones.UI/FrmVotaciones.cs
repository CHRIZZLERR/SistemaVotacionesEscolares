using System;
using System.Drawing;
using System.Windows.Forms;
using SistemaVotaciones.BLL;
using SistemaVotaciones.Entidades;

namespace SistemaVotaciones.UI
{
    public partial class FrmVotaciones : Form
    {
        private VotacionBLL bll = new VotacionBLL();

        private Panel panelPrincipal;
        private Label lblTituloNuevo;
        private Label lblSubtituloNuevo;

        public FrmVotaciones()
        {
            InitializeComponent();
        }

        private void FrmVotaciones_Load(object sender, EventArgs e)
        {
            AplicarDiseno();
            CargarEstados();
            CargarPadrones();
            CargarVotaciones();
        }

        private void AplicarDiseno()
        {
            OcultarTitulosViejos();

            this.Text = "Votaciones - Sistema de Votaciones";
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
            lblTituloNuevo.Text = "Gestión de Votaciones";
            lblTituloNuevo.Font = new Font("Segoe UI", 25, FontStyle.Bold);
            lblTituloNuevo.ForeColor = Color.White;
            lblTituloNuevo.BackColor = Color.Transparent;
            lblTituloNuevo.TextAlign = ContentAlignment.MiddleCenter;
            lblTituloNuevo.AutoSize = false;
            lblTituloNuevo.Location = new Point(20, 20);
            lblTituloNuevo.Size = new Size(1055, 45);
            panelHeader.Controls.Add(lblTituloNuevo);

            lblSubtituloNuevo = new Label();
            lblSubtituloNuevo.Text = "Crea y consulta los períodos de votación asociados a cada padrón";
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
            panelPrincipal.Controls.Add(lblNombre);
            panelPrincipal.Controls.Add(txtNombre);

            panelPrincipal.Controls.Add(lblPadron);
            panelPrincipal.Controls.Add(cmbPadron);

            panelPrincipal.Controls.Add(lblInicio);
            panelPrincipal.Controls.Add(dtInicio);

            panelPrincipal.Controls.Add(lblFin);
            panelPrincipal.Controls.Add(dtFin);

            panelPrincipal.Controls.Add(lblEstado);
            panelPrincipal.Controls.Add(cmbEstado);

            lblNombre.Visible = true;
            txtNombre.Visible = true;

            lblPadron.Visible = true;
            cmbPadron.Visible = true;

            lblInicio.Visible = true;
            dtInicio.Visible = true;

            lblFin.Visible = true;
            dtFin.Visible = true;

            lblEstado.Visible = true;
            cmbEstado.Visible = true;

            int xLabel = 45;
            int xInput = 45;
            int y = 135;
            int espacio = 72;

            ConfigurarLabel(lblNombre, "Nombre de la votación");
            lblNombre.Location = new Point(xLabel, y);
            lblNombre.Size = new Size(260, 25);

            txtNombre.Location = new Point(xInput, y + 28);
            txtNombre.Size = new Size(315, 30);
            ConfigurarTextBox(txtNombre);

            ConfigurarLabel(lblPadron, "Padrón");
            lblPadron.Location = new Point(xLabel, y + espacio);
            lblPadron.Size = new Size(260, 25);

            cmbPadron.Location = new Point(xInput, y + espacio + 28);
            cmbPadron.Size = new Size(315, 30);
            ConfigurarComboBox(cmbPadron);

            ConfigurarLabel(lblInicio, "Fecha de inicio");
            lblInicio.Location = new Point(xLabel, y + espacio * 2);
            lblInicio.Size = new Size(260, 25);

            dtInicio.Location = new Point(xInput, y + espacio * 2 + 28);
            dtInicio.Size = new Size(315, 30);
            dtInicio.Font = new Font("Segoe UI", 10, FontStyle.Regular);
            dtInicio.Format = DateTimePickerFormat.Custom;
            dtInicio.CustomFormat = "dd/MM/yyyy hh:mm tt";

            ConfigurarLabel(lblFin, "Fecha de fin");
            lblFin.Location = new Point(xLabel, y + espacio * 3);
            lblFin.Size = new Size(260, 25);

            dtFin.Location = new Point(xInput, y + espacio * 3 + 28);
            dtFin.Size = new Size(315, 30);
            dtFin.Font = new Font("Segoe UI", 10, FontStyle.Regular);
            dtFin.Format = DateTimePickerFormat.Custom;
            dtFin.CustomFormat = "dd/MM/yyyy hh:mm tt";

            ConfigurarLabel(lblEstado, "Estado");
            lblEstado.Location = new Point(xLabel, y + espacio * 4);
            lblEstado.Size = new Size(260, 25);

            cmbEstado.Location = new Point(xInput, y + espacio * 4 + 28);
            cmbEstado.Size = new Size(315, 30);
            ConfigurarComboBox(cmbEstado);
        }

        private void ConfigurarTabla()
        {
            panelPrincipal.Controls.Add(dgvVotaciones);

            dgvVotaciones.Visible = true;
            dgvVotaciones.Location = new Point(405, 135);
            dgvVotaciones.Size = new Size(645, 365);
            dgvVotaciones.BackgroundColor = Color.White;
            dgvVotaciones.BorderStyle = BorderStyle.FixedSingle;

            dgvVotaciones.EnableHeadersVisualStyles = false;
            dgvVotaciones.ColumnHeadersDefaultCellStyle.BackColor = Color.FromArgb(10, 38, 95);
            dgvVotaciones.ColumnHeadersDefaultCellStyle.ForeColor = Color.White;
            dgvVotaciones.ColumnHeadersDefaultCellStyle.Font = new Font("Segoe UI", 10, FontStyle.Bold);

            dgvVotaciones.DefaultCellStyle.Font = new Font("Segoe UI", 10, FontStyle.Regular);
            dgvVotaciones.DefaultCellStyle.SelectionBackColor = Color.FromArgb(21, 101, 192);
            dgvVotaciones.DefaultCellStyle.SelectionForeColor = Color.White;

            dgvVotaciones.RowHeadersDefaultCellStyle.BackColor = Color.FromArgb(10, 38, 95);
            dgvVotaciones.RowHeadersDefaultCellStyle.ForeColor = Color.White;

            dgvVotaciones.AllowUserToAddRows = false;
            dgvVotaciones.ReadOnly = true;
            dgvVotaciones.SelectionMode = DataGridViewSelectionMode.FullRowSelect;
            dgvVotaciones.MultiSelect = false;
            dgvVotaciones.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.None;
        }

        private void ConfigurarBotones()
        {
            panelPrincipal.Controls.Add(btnCrear);
            panelPrincipal.Controls.Add(btnCerrar);

            btnCrear.Visible = true;
            btnCerrar.Visible = true;

            btnCrear.Text = "Crear votación";
            btnCerrar.Text = "Cerrar";

            btnCrear.Location = new Point(405, 525);
            btnCrear.Size = new Size(220, 45);

            btnCerrar.Location = new Point(830, 525);
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

        private void CargarEstados()
        {
            cmbEstado.Items.Clear();
            cmbEstado.Items.Add("Pendiente");
            cmbEstado.Items.Add("Abierta");
            cmbEstado.Items.Add("Cerrada");

            if (cmbEstado.Items.Count > 0)
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
            AjustarColumnas();
        }

        private void AjustarColumnas()
        {
            if (dgvVotaciones.Columns.Count == 0)
                return;

            if (dgvVotaciones.Columns.Contains("IdVotacion"))
                dgvVotaciones.Columns["IdVotacion"].Width = 90;

            if (dgvVotaciones.Columns.Contains("NombreVotacion"))
                dgvVotaciones.Columns["NombreVotacion"].Width = 170;

            if (dgvVotaciones.Columns.Contains("NombrePadron"))
                dgvVotaciones.Columns["NombrePadron"].Width = 220;

            if (dgvVotaciones.Columns.Contains("FechaInicio"))
                dgvVotaciones.Columns["FechaInicio"].Width = 150;

            if (dgvVotaciones.Columns.Contains("FechaFin"))
                dgvVotaciones.Columns["FechaFin"].Width = 150;

            if (dgvVotaciones.Columns.Contains("EstadoVotacion"))
                dgvVotaciones.Columns["EstadoVotacion"].Width = 130;
        }

        private void LimpiarCampos()
        {
            txtNombre.Clear();

            if (cmbPadron.Items.Count > 0)
                cmbPadron.SelectedIndex = 0;

            if (cmbEstado.Items.Count > 0)
                cmbEstado.SelectedIndex = 0;

            dtInicio.Value = DateTime.Now;
            dtFin.Value = DateTime.Now.AddHours(3);

            txtNombre.Focus();
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
                LimpiarCampos();
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

        private void btnCerrar_Click(object sender, EventArgs e)
        {
            this.Close();
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
    }
}