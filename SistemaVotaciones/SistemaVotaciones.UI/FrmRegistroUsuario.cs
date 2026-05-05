using System;
using System.Drawing;
using System.Drawing.Drawing2D;
using System.Windows.Forms;
using SistemaVotaciones.BLL;
using SistemaVotaciones.Entidades;

namespace SistemaVotaciones.UI
{
    public partial class FrmRegistroUsuario : Form
    {
        private Panel panelPrincipal;
        private Label lblTituloNuevo;
        private Label lblSubtituloNuevo;

        public FrmRegistroUsuario()
        {
            InitializeComponent();
            txtPassword.PasswordChar = '*';
            CargarCombosIniciales();
        }

        private void FrmRegistroUsuario_Load(object sender, EventArgs e)
        {
            AplicarDiseno();
        }

        private void AplicarDiseno()
        {
            this.Text = "Registro de Usuario - Sistema de Votaciones";
            this.StartPosition = FormStartPosition.CenterScreen;
            this.Size = new Size(850, 650);
            this.FormBorderStyle = FormBorderStyle.FixedSingle;
            this.MaximizeBox = false;
            this.BackColor = Color.FromArgb(8, 18, 55);

            this.Paint += FrmRegistroUsuario_Paint;

            panelPrincipal = new Panel();
            panelPrincipal.BackColor = Color.FromArgb(245, 248, 255);
            panelPrincipal.Location = new Point(70, 35);
            panelPrincipal.Size = new Size(690, 555);
            panelPrincipal.BorderStyle = BorderStyle.None;
            this.Controls.Add(panelPrincipal);
            panelPrincipal.BringToFront();

            Panel panelHeader = new Panel();
            panelHeader.BackColor = Color.FromArgb(10, 38, 95);
            panelHeader.Location = new Point(0, 0);
            panelHeader.Size = new Size(690, 105);
            panelPrincipal.Controls.Add(panelHeader);

            lblTituloNuevo = new Label();
            lblTituloNuevo.Text = "Registro de Votante";
            lblTituloNuevo.Font = new Font("Segoe UI", 24, FontStyle.Bold);
            lblTituloNuevo.ForeColor = Color.White;
            lblTituloNuevo.BackColor = Color.Transparent;
            lblTituloNuevo.TextAlign = ContentAlignment.MiddleCenter;
            lblTituloNuevo.AutoSize = false;
            lblTituloNuevo.Location = new Point(10, 20);
            lblTituloNuevo.Size = new Size(670, 45);
            panelHeader.Controls.Add(lblTituloNuevo);

            lblSubtituloNuevo = new Label();
            lblSubtituloNuevo.Text = "Completa tus datos para acceder al sistema electoral";
            lblSubtituloNuevo.Font = new Font("Segoe UI", 10, FontStyle.Bold);
            lblSubtituloNuevo.ForeColor = Color.FromArgb(255, 215, 90);
            lblSubtituloNuevo.BackColor = Color.Transparent;
            lblSubtituloNuevo.TextAlign = ContentAlignment.MiddleCenter;
            lblSubtituloNuevo.AutoSize = false;
            lblSubtituloNuevo.Location = new Point(10, 65);
            lblSubtituloNuevo.Size = new Size(670, 25);
            panelHeader.Controls.Add(lblSubtituloNuevo);

            AgregarControlesAlPanel();
            OrganizarCampos();
            EstilizarControles();
        }

        private void FrmRegistroUsuario_Paint(object sender, PaintEventArgs e)
        {
            using (LinearGradientBrush brush = new LinearGradientBrush(
                this.ClientRectangle,
                Color.FromArgb(8, 18, 55),
                Color.FromArgb(16, 60, 120),
                90F))
            {
                e.Graphics.FillRectangle(brush, this.ClientRectangle);
            }
        }

        private void AgregarControlesAlPanel()
        {
            panelPrincipal.Controls.Add(lblNivel);
            panelPrincipal.Controls.Add(cmbNivel);

            panelPrincipal.Controls.Add(lblMatricula);
            panelPrincipal.Controls.Add(txtMatricula);

            panelPrincipal.Controls.Add(lblGrado);
            panelPrincipal.Controls.Add(cmbGrado);

            panelPrincipal.Controls.Add(lblNombre);
            panelPrincipal.Controls.Add(txtNombre);

            panelPrincipal.Controls.Add(lblSeccion);
            panelPrincipal.Controls.Add(cmbSeccion);

            panelPrincipal.Controls.Add(lblUsuario);
            panelPrincipal.Controls.Add(txtUsuario);

            panelPrincipal.Controls.Add(lblModalidad);
            panelPrincipal.Controls.Add(cmbModalidad);

            panelPrincipal.Controls.Add(lblPassword);
            panelPrincipal.Controls.Add(txtPassword);

            panelPrincipal.Controls.Add(btnRegistrar);
        }

        private void OrganizarCampos()
        {
            int labelW = 150;
            int inputW = 220;
            int inputH = 32;

            int x1Label = 55;
            int x1Input = 55;

            int x2Label = 385;
            int x2Input = 385;

            int y1 = 140;
            int espacioY = 78;

            lblNivel.Location = new Point(x1Label, y1);
            cmbNivel.Location = new Point(x1Input, y1 + 28);

            lblMatricula.Location = new Point(x2Label, y1);
            txtMatricula.Location = new Point(x2Input, y1 + 28);

            lblGrado.Location = new Point(x1Label, y1 + espacioY);
            cmbGrado.Location = new Point(x1Input, y1 + espacioY + 28);

            lblNombre.Location = new Point(x2Label, y1 + espacioY);
            txtNombre.Location = new Point(x2Input, y1 + espacioY + 28);

            lblSeccion.Location = new Point(x1Label, y1 + espacioY * 2);
            cmbSeccion.Location = new Point(x1Input, y1 + espacioY * 2 + 28);

            lblUsuario.Location = new Point(x2Label, y1 + espacioY * 2);
            txtUsuario.Location = new Point(x2Input, y1 + espacioY * 2 + 28);

            lblModalidad.Location = new Point(x1Label, y1 + espacioY * 3);
            cmbModalidad.Location = new Point(x1Input, y1 + espacioY * 3 + 28);

            lblPassword.Location = new Point(x2Label, y1 + espacioY * 3);
            txtPassword.Location = new Point(x2Input, y1 + espacioY * 3 + 28);

            lblNivel.Size = new Size(labelW, 25);
            lblMatricula.Size = new Size(labelW, 25);
            lblGrado.Size = new Size(labelW, 25);
            lblNombre.Size = new Size(labelW, 25);
            lblSeccion.Size = new Size(labelW, 25);
            lblUsuario.Size = new Size(labelW, 25);
            lblModalidad.Size = new Size(labelW, 25);
            lblPassword.Size = new Size(labelW, 25);

            cmbNivel.Size = new Size(inputW, inputH);
            txtMatricula.Size = new Size(inputW, inputH);
            cmbGrado.Size = new Size(inputW, inputH);
            txtNombre.Size = new Size(inputW, inputH);
            cmbSeccion.Size = new Size(inputW, inputH);
            txtUsuario.Size = new Size(inputW, inputH);
            cmbModalidad.Size = new Size(inputW, inputH);
            txtPassword.Size = new Size(inputW, inputH);

            btnRegistrar.Location = new Point(200, 480);
            btnRegistrar.Size = new Size(290, 45);
        }

        private void EstilizarControles()
        {
            EstiloLabel(lblNivel, "Nivel");
            EstiloLabel(lblMatricula, "Matrícula");
            EstiloLabel(lblGrado, "Grado");
            EstiloLabel(lblNombre, "Nombre completo");
            EstiloLabel(lblSeccion, "Sección");
            EstiloLabel(lblUsuario, "Usuario");
            EstiloLabel(lblModalidad, "Modalidad");
            EstiloLabel(lblPassword, "Contraseña");

            EstiloCombo(cmbNivel);
            EstiloCombo(cmbGrado);
            EstiloCombo(cmbSeccion);
            EstiloCombo(cmbModalidad);

            EstiloTextBox(txtMatricula);
            EstiloTextBox(txtNombre);
            EstiloTextBox(txtUsuario);
            EstiloTextBox(txtPassword);

            txtPassword.PasswordChar = '*';

            btnRegistrar.Text = "Registrar votante";
            EstiloBotonPrincipal(btnRegistrar);
        }

        private void EstiloLabel(Label label, string texto)
        {
            label.Text = texto;
            label.Font = new Font("Segoe UI", 10, FontStyle.Bold);
            label.ForeColor = Color.FromArgb(10, 38, 95);
            label.BackColor = Color.Transparent;
        }

        private void EstiloTextBox(TextBox textBox)
        {
            textBox.Font = new Font("Segoe UI", 10, FontStyle.Regular);
            textBox.BorderStyle = BorderStyle.FixedSingle;
            textBox.BackColor = Color.White;
            textBox.ForeColor = Color.Black;
        }

        private void EstiloCombo(ComboBox comboBox)
        {
            comboBox.Font = new Font("Segoe UI", 10, FontStyle.Regular);
            comboBox.BackColor = Color.White;
            comboBox.ForeColor = Color.Black;
            comboBox.DropDownStyle = ComboBoxStyle.DropDownList;
        }

        private void EstiloBotonPrincipal(Button boton)
        {
            boton.FlatStyle = FlatStyle.Flat;
            boton.FlatAppearance.BorderSize = 0;
            boton.BackColor = Color.FromArgb(21, 101, 192);
            boton.ForeColor = Color.White;
            boton.Font = new Font("Segoe UI", 11, FontStyle.Bold);
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

        private void CargarCombosIniciales()
        {
            cmbNivel.Items.Clear();
            cmbGrado.Items.Clear();
            cmbSeccion.Items.Clear();
            cmbModalidad.Items.Clear();

            cmbNivel.Items.Add("Primaria");
            cmbNivel.Items.Add("Secundaria");

            cmbGrado.Items.AddRange(new string[]
            {
                "1ro", "2do", "3ro", "4to", "5to", "6to"
            });

            cmbSeccion.Items.AddRange(new string[]
            {
                "A", "B", "C"
            });

            cmbModalidad.Items.AddRange(new string[]
            {
                "Académico",
                "Informática",
                "Gestión",
                "Electrónica",
                "Música"
            });
        }

        private void ConfigurarModalidadPorNivel()
        {
            if (cmbNivel.Text == "Primaria")
            {
                cmbModalidad.Items.Clear();
                cmbModalidad.Items.Add("Académico");
                cmbModalidad.SelectedIndex = 0;
                cmbModalidad.Enabled = false;
            }
            else if (cmbNivel.Text == "Secundaria")
            {
                cmbModalidad.Enabled = true;
                cmbModalidad.Items.Clear();

                cmbModalidad.Items.AddRange(new string[]
                {
                    "Académico",
                    "Informática",
                    "Gestión",
                    "Electrónica",
                    "Música"
                });

                cmbModalidad.SelectedIndex = -1;
            }
        }

        private void btnRegistrar_Click(object sender, EventArgs e)
        {
            if (string.IsNullOrWhiteSpace(txtMatricula.Text) ||
                string.IsNullOrWhiteSpace(txtNombre.Text) ||
                string.IsNullOrWhiteSpace(txtUsuario.Text) ||
                string.IsNullOrWhiteSpace(txtPassword.Text) ||
                string.IsNullOrWhiteSpace(cmbNivel.Text) ||
                string.IsNullOrWhiteSpace(cmbGrado.Text) ||
                string.IsNullOrWhiteSpace(cmbSeccion.Text) ||
                string.IsNullOrWhiteSpace(cmbModalidad.Text))
            {
                MessageBox.Show("Debe completar todos los campos.");
                return;
            }

            UsuarioBLL bll = new UsuarioBLL();

            string matricula = txtMatricula.Text.Trim();
            string username = txtUsuario.Text.Trim();
            string nombre = txtNombre.Text.Trim();
            string password = txtPassword.Text.Trim();

            string nivel = cmbNivel.Text.Trim();
            string grado = cmbGrado.Text.Trim();
            string seccion = cmbSeccion.Text.Trim();
            string modalidad = cmbModalidad.Text.Trim();

            if (bll.ExisteUsuario(username, matricula))
            {
                MessageBox.Show("Ya existe un usuario con esa matrícula o nombre de usuario.");
                return;
            }

            int idPadron = bll.ObtenerIdPadron(
                nivel,
                grado,
                seccion,
                modalidad
            );

            if (idPadron == 0)
            {
                MessageBox.Show("No existe un padrón electoral para esa selección.");
                return;
            }

            Usuario usuario = new Usuario
            {
                Matricula = matricula,
                NombreCompleto = nombre,
                Username = username,
                Password = password,
                Nivel = nivel,
                Grado = grado,
                Seccion = seccion,
                Modalidad = modalidad,
                IdPadron = idPadron
            };

            if (bll.RegistrarUsuario(usuario))
            {
                MessageBox.Show("Usuario registrado correctamente como votante.");
                this.Close();
            }
            else
            {
                MessageBox.Show("Error al registrar usuario.");
            }
        }

        private void cmbNivel_SelectedIndexChanged(object sender, EventArgs e)
        {
            ConfigurarModalidadPorNivel();
        }

        private void lblUsuario_Click(object sender, EventArgs e) { }
        private void lblPassword_Click(object sender, EventArgs e) { }
        private void lblNombre_Click(object sender, EventArgs e) { }
        private void lblMatricula_Click(object sender, EventArgs e) { }
        private void lblNivel_Click(object sender, EventArgs e) { }
        private void lblGrado_Click(object sender, EventArgs e) { }
        private void lblSeccion_Click(object sender, EventArgs e) { }
        private void lblModalidad_Click(object sender, EventArgs e) { }

        private void textBox3_TextChanged(object sender, EventArgs e) { }
        private void textBox4_TextChanged(object sender, EventArgs e) { }
        private void txtNombre_TextChanged(object sender, EventArgs e) { }
        private void txtMatricula_TextChanged(object sender, EventArgs e) { }

        private void cmbGrado_SelectedIndexChanged(object sender, EventArgs e) { }
        private void cmbSeccion_SelectedIndexChanged(object sender, EventArgs e) { }
        private void cmbModalidad_SelectedIndexChanged(object sender, EventArgs e) { }
    }
}