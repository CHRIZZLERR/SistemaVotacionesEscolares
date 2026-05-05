using SistemaVotaciones.BLL;
using SistemaVotaciones.Entidades;
using System;
using System.Drawing;
using System.Drawing.Drawing2D;
using System.Windows.Forms;

namespace SistemaVotaciones.UI
{
    public partial class FrmLogin : Form
    {
        private Panel panelPrincipal;
        private Label lblTituloSistema;
        private Label lblSubtituloSistema;

        public FrmLogin()
        {
            InitializeComponent();
            txtPassword.PasswordChar = '*';
        }

        private void FrmLogin_Load(object sender, EventArgs e)
        {
            AplicarDiseno();
        }

        private void AplicarDiseno()
        {
            OcultarTituloViejo();

            this.Text = "Login - Sistema de Votaciones";
            this.StartPosition = FormStartPosition.CenterScreen;
            this.Size = new Size(760, 520);
            this.FormBorderStyle = FormBorderStyle.FixedSingle;
            this.MaximizeBox = false;
            this.BackColor = Color.FromArgb(8, 18, 55);

            this.Paint -= FrmLogin_Paint;
            this.Paint += FrmLogin_Paint;

            panelPrincipal = new Panel();
            panelPrincipal.BackColor = Color.FromArgb(245, 248, 255);
            panelPrincipal.Location = new Point(150, 50);
            panelPrincipal.Size = new Size(445, 390);
            panelPrincipal.BorderStyle = BorderStyle.None;
            this.Controls.Add(panelPrincipal);
            panelPrincipal.BringToFront();

            Panel panelHeader = new Panel();
            panelHeader.BackColor = Color.FromArgb(10, 38, 95);
            panelHeader.Location = new Point(0, 0);
            panelHeader.Size = new Size(445, 115);
            panelPrincipal.Controls.Add(panelHeader);

            lblTituloSistema = new Label();
            lblTituloSistema.Text = "SISTEMA DE VOTACIONES";
            lblTituloSistema.Font = new Font("Segoe UI", 20, FontStyle.Bold);
            lblTituloSistema.ForeColor = Color.White;
            lblTituloSistema.BackColor = Color.Transparent;
            lblTituloSistema.TextAlign = ContentAlignment.MiddleCenter;
            lblTituloSistema.AutoSize = false;
            lblTituloSistema.Location = new Point(10, 25);
            lblTituloSistema.Size = new Size(425, 38);
            panelHeader.Controls.Add(lblTituloSistema);

            lblSubtituloSistema = new Label();
            lblSubtituloSistema.Text = "Acceso seguro al sistema electoral";
            lblSubtituloSistema.Font = new Font("Segoe UI", 10, FontStyle.Bold);
            lblSubtituloSistema.ForeColor = Color.FromArgb(255, 215, 90);
            lblSubtituloSistema.BackColor = Color.Transparent;
            lblSubtituloSistema.TextAlign = ContentAlignment.MiddleCenter;
            lblSubtituloSistema.AutoSize = false;
            lblSubtituloSistema.Location = new Point(10, 65);
            lblSubtituloSistema.Size = new Size(425, 25);
            panelHeader.Controls.Add(lblSubtituloSistema);

            panelPrincipal.Controls.Add(lblUsuario);
            panelPrincipal.Controls.Add(lblContraseña);
            panelPrincipal.Controls.Add(txtUsuario);
            panelPrincipal.Controls.Add(txtPassword);
            panelPrincipal.Controls.Add(btnLogin);
            panelPrincipal.Controls.Add(btnRegistrar);

            lblUsuario.Visible = true;
            lblContraseña.Visible = true;
            txtUsuario.Visible = true;
            txtPassword.Visible = true;
            btnLogin.Visible = true;
            btnRegistrar.Visible = true;

            lblUsuario.Text = "Usuario";
            lblUsuario.Font = new Font("Segoe UI", 11, FontStyle.Bold);
            lblUsuario.ForeColor = Color.FromArgb(10, 38, 95);
            lblUsuario.BackColor = Color.Transparent;
            lblUsuario.Location = new Point(55, 145);
            lblUsuario.Size = new Size(150, 25);

            txtUsuario.Font = new Font("Segoe UI", 11, FontStyle.Regular);
            txtUsuario.Location = new Point(55, 172);
            txtUsuario.Size = new Size(335, 32);
            txtUsuario.BorderStyle = BorderStyle.FixedSingle;

            lblContraseña.Text = "Contraseña";
            lblContraseña.Font = new Font("Segoe UI", 11, FontStyle.Bold);
            lblContraseña.ForeColor = Color.FromArgb(10, 38, 95);
            lblContraseña.BackColor = Color.Transparent;
            lblContraseña.Location = new Point(55, 215);
            lblContraseña.Size = new Size(150, 25);

            txtPassword.Font = new Font("Segoe UI", 11, FontStyle.Regular);
            txtPassword.Location = new Point(55, 242);
            txtPassword.Size = new Size(335, 32);
            txtPassword.BorderStyle = BorderStyle.FixedSingle;
            txtPassword.PasswordChar = '*';

            btnLogin.Text = "Iniciar sesión";
            btnLogin.Location = new Point(55, 305);
            btnLogin.Size = new Size(160, 45);
            EstiloBotonPrincipal(btnLogin);

            btnRegistrar.Text = "Registrarse";
            btnRegistrar.Location = new Point(230, 305);
            btnRegistrar.Size = new Size(160, 45);
            EstiloBotonSecundario(btnRegistrar);
        }

        private void OcultarTituloViejo()
        {
            foreach (Control control in this.Controls)
            {
                if (control is Label label)
                {
                    string texto = label.Text.Trim().ToLower();

                    if (texto.Contains("sistema de votaciones") ||
                        texto.Contains("login") ||
                        texto.Contains("iniciar sesión"))
                    {
                        label.Visible = false;
                    }
                }
            }
        }

        private void FrmLogin_Paint(object sender, PaintEventArgs e)
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

        private void EstiloBotonPrincipal(Button boton)
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

        private void EstiloBotonSecundario(Button boton)
        {
            boton.FlatStyle = FlatStyle.Flat;
            boton.FlatAppearance.BorderSize = 1;
            boton.FlatAppearance.BorderColor = Color.FromArgb(21, 101, 192);
            boton.BackColor = Color.White;
            boton.ForeColor = Color.FromArgb(21, 101, 192);
            boton.Font = new Font("Segoe UI", 10, FontStyle.Bold);
            boton.Cursor = Cursors.Hand;

            boton.MouseEnter += (s, e) =>
            {
                boton.BackColor = Color.FromArgb(225, 238, 255);
            };

            boton.MouseLeave += (s, e) =>
            {
                boton.BackColor = Color.White;
            };
        }

        private void btnLogin_Click(object sender, EventArgs e)
        {
            if (string.IsNullOrWhiteSpace(txtUsuario.Text) || string.IsNullOrWhiteSpace(txtPassword.Text))
            {
                MessageBox.Show("Debe completar usuario y contraseña.");
                return;
            }

            UsuarioBLL usuarioBLL = new UsuarioBLL();

            Usuario usuario = usuarioBLL.Login(
                txtUsuario.Text.Trim(),
                txtPassword.Text.Trim()
            );

            if (usuario == null)
            {
                MessageBox.Show("Usuario o contraseña incorrectos, o usuario inactivo.");
                return;
            }

            if (usuario.IdRol == 1)
            {
                FrmMenuAdmin menuAdmin = new FrmMenuAdmin(usuario);
                menuAdmin.Show();
                this.Hide();
            }
            else if (usuario.IdRol == 2)
            {
                FrmMenuVotante menuVotante = new FrmMenuVotante(usuario);
                menuVotante.Show();
                this.Hide();
            }
            else if (usuario.IdRol == 3)
            {
                FrmMenuAdmin menuAdmin = new FrmMenuAdmin(usuario);
                menuAdmin.Show();
                this.Hide();
            }
            else if (usuario.IdRol == 4)
            {
                MessageBox.Show("Este usuario pertenece a una plancha como candidato, por lo tanto no puede emitir votos.");
                return;
            }
            else
            {
                MessageBox.Show("El usuario no tiene un rol válido.");
            }
        }

        private void btnRegistrar_Click(object sender, EventArgs e)
        {
            FrmRegistroUsuario frm = new FrmRegistroUsuario();
            frm.ShowDialog();
        }

        private void lblUsuario_Click(object sender, EventArgs e) { }

        private void lblContraseña_Click(object sender, EventArgs e) { }

        private void txtPassword_TextChanged(object sender, EventArgs e) { }

        private void txtUsuario_TextChanged(object sender, EventArgs e) { }

        private void lblTitulo_Click(object sender, EventArgs e)
        {

        }
    }
}