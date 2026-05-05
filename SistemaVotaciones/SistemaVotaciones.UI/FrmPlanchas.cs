using System;
using System.Drawing;
using System.Windows.Forms;
using SistemaVotaciones.BLL;
using SistemaVotaciones.Entidades;

namespace SistemaVotaciones.UI
{
    public partial class FrmPlanchas : Form
    {
        private PlanchaBLL bll = new PlanchaBLL();

        private Panel panelPrincipal;
        private Label lblTituloNuevo;
        private Label lblSubtituloNuevo;

        public FrmPlanchas()
        {
            InitializeComponent();
        }

        private void FrmPlanchas_Load(object sender, EventArgs e)
        {
            AplicarDiseno();
            CargarPadrones();
            CargarAdminsPlancha();
            CargarPlanchas();
        }

        private void AplicarDiseno()
        {
            OcultarTitulosViejos();

            this.Text = "Planchas - Sistema de Votaciones";
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
            lblTituloNuevo.Text = "Gestión de Planchas";
            lblTituloNuevo.Font = new Font("Segoe UI", 25, FontStyle.Bold);
            lblTituloNuevo.ForeColor = Color.White;
            lblTituloNuevo.BackColor = Color.Transparent;
            lblTituloNuevo.TextAlign = ContentAlignment.MiddleCenter;
            lblTituloNuevo.AutoSize = false;
            lblTituloNuevo.Location = new Point(20, 20);
            lblTituloNuevo.Size = new Size(1055, 45);
            panelHeader.Controls.Add(lblTituloNuevo);

            lblSubtituloNuevo = new Label();
            lblSubtituloNuevo.Text = "Crea y consulta las planchas electorales registradas en el sistema";
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
            panelPrincipal.Controls.Add(lblNombrePlancha);
            panelPrincipal.Controls.Add(txtNombrePlancha);

            panelPrincipal.Controls.Add(lblColor);
            panelPrincipal.Controls.Add(txtColor);

            panelPrincipal.Controls.Add(lblLema);
            panelPrincipal.Controls.Add(txtLema);

            panelPrincipal.Controls.Add(lblPadron);
            panelPrincipal.Controls.Add(cmbPadron);

            panelPrincipal.Controls.Add(lblAdminPlancha);
            panelPrincipal.Controls.Add(cmbAdminPlancha);

            lblNombrePlancha.Visible = true;
            txtNombrePlancha.Visible = true;

            lblColor.Visible = true;
            txtColor.Visible = true;

            lblLema.Visible = true;
            txtLema.Visible = true;

            lblPadron.Visible = true;
            cmbPadron.Visible = true;

            lblAdminPlancha.Visible = true;
            cmbAdminPlancha.Visible = true;

            int xLabel = 45;
            int xInput = 45;
            int y = 135;
            int espacio = 72;

            ConfigurarLabel(lblNombrePlancha, "Nombre de la plancha");
            lblNombrePlancha.Location = new Point(xLabel, y);
            lblNombrePlancha.Size = new Size(260, 25);

            txtNombrePlancha.Location = new Point(xInput, y + 28);
            txtNombrePlancha.Size = new Size(315, 30);
            ConfigurarTextBox(txtNombrePlancha);

            ConfigurarLabel(lblColor, "Color");
            lblColor.Location = new Point(xLabel, y + espacio);
            lblColor.Size = new Size(260, 25);

            txtColor.Location = new Point(xInput, y + espacio + 28);
            txtColor.Size = new Size(315, 30);
            ConfigurarTextBox(txtColor);

            ConfigurarLabel(lblLema, "Lema");
            lblLema.Location = new Point(xLabel, y + espacio * 2);
            lblLema.Size = new Size(260, 25);

            txtLema.Location = new Point(xInput, y + espacio * 2 + 28);
            txtLema.Size = new Size(315, 30);
            ConfigurarTextBox(txtLema);

            ConfigurarLabel(lblPadron, "Padrón");
            lblPadron.Location = new Point(xLabel, y + espacio * 3);
            lblPadron.Size = new Size(260, 25);

            cmbPadron.Location = new Point(xInput, y + espacio * 3 + 28);
            cmbPadron.Size = new Size(315, 30);
            ConfigurarComboBox(cmbPadron);

            ConfigurarLabel(lblAdminPlancha, "Administrador de plancha");
            lblAdminPlancha.Location = new Point(xLabel, y + espacio * 4);
            lblAdminPlancha.Size = new Size(260, 25);

            cmbAdminPlancha.Location = new Point(xInput, y + espacio * 4 + 28);
            cmbAdminPlancha.Size = new Size(315, 30);
            ConfigurarComboBox(cmbAdminPlancha);
        }

        private void ConfigurarTabla()
        {
            panelPrincipal.Controls.Add(dgvPlanchas);

            dgvPlanchas.Visible = true;
            dgvPlanchas.Location = new Point(405, 135);
            dgvPlanchas.Size = new Size(645, 365);
            dgvPlanchas.BackgroundColor = Color.White;
            dgvPlanchas.BorderStyle = BorderStyle.FixedSingle;

            dgvPlanchas.EnableHeadersVisualStyles = false;
            dgvPlanchas.ColumnHeadersDefaultCellStyle.BackColor = Color.FromArgb(10, 38, 95);
            dgvPlanchas.ColumnHeadersDefaultCellStyle.ForeColor = Color.White;
            dgvPlanchas.ColumnHeadersDefaultCellStyle.Font = new Font("Segoe UI", 10, FontStyle.Bold);

            dgvPlanchas.DefaultCellStyle.Font = new Font("Segoe UI", 10, FontStyle.Regular);
            dgvPlanchas.DefaultCellStyle.SelectionBackColor = Color.FromArgb(21, 101, 192);
            dgvPlanchas.DefaultCellStyle.SelectionForeColor = Color.White;

            dgvPlanchas.RowHeadersDefaultCellStyle.BackColor = Color.FromArgb(10, 38, 95);
            dgvPlanchas.RowHeadersDefaultCellStyle.ForeColor = Color.White;

            dgvPlanchas.AllowUserToAddRows = false;
            dgvPlanchas.ReadOnly = true;
            dgvPlanchas.SelectionMode = DataGridViewSelectionMode.FullRowSelect;
            dgvPlanchas.MultiSelect = false;
            dgvPlanchas.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.None;
        }

        private void ConfigurarBotones()
        {
            panelPrincipal.Controls.Add(btnCrearPlancha);
            panelPrincipal.Controls.Add(btnCerrar);

            btnCrearPlancha.Visible = true;
            btnCerrar.Visible = true;

            btnCrearPlancha.Text = "Crear plancha";
            btnCerrar.Text = "Cerrar";

            btnCrearPlancha.Location = new Point(405, 525);
            btnCrearPlancha.Size = new Size(220, 45);

            btnCerrar.Location = new Point(830, 525);
            btnCerrar.Size = new Size(220, 45);

            EstiloBoton(btnCrearPlancha);
            EstiloBotonCerrar(btnCerrar);

            btnCrearPlancha.BringToFront();
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
            AjustarColumnas();
        }

        private void AjustarColumnas()
        {
            if (dgvPlanchas.Columns.Count == 0)
                return;

            if (dgvPlanchas.Columns.Contains("IdPlancha"))
                dgvPlanchas.Columns["IdPlancha"].Width = 80;

            if (dgvPlanchas.Columns.Contains("NombrePlancha"))
                dgvPlanchas.Columns["NombrePlancha"].Width = 160;

            if (dgvPlanchas.Columns.Contains("Color"))
                dgvPlanchas.Columns["Color"].Width = 90;

            if (dgvPlanchas.Columns.Contains("Lema"))
                dgvPlanchas.Columns["Lema"].Width = 190;

            if (dgvPlanchas.Columns.Contains("NombrePadron"))
                dgvPlanchas.Columns["NombrePadron"].Width = 190;

            if (dgvPlanchas.Columns.Contains("AdminPlancha"))
                dgvPlanchas.Columns["AdminPlancha"].Width = 170;

            if (dgvPlanchas.Columns.Contains("EstadoPlancha"))
                dgvPlanchas.Columns["EstadoPlancha"].Width = 110;
        }

        private void LimpiarCampos()
        {
            txtNombrePlancha.Clear();
            txtColor.Clear();
            txtLema.Clear();

            if (cmbPadron.Items.Count > 0)
                cmbPadron.SelectedIndex = 0;

            if (cmbAdminPlancha.Items.Count > 0)
                cmbAdminPlancha.SelectedIndex = 0;

            txtNombrePlancha.Focus();
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
                LimpiarCampos();
                CargarPlanchas();
            }
            else
            {
                MessageBox.Show("Error al crear plancha.");
            }
        }

        private void btnCerrar_Click(object sender, EventArgs e)
        {
            this.Close();
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