using SistemaVotaciones.BLL;
using SistemaVotaciones.Entidades;
using System;
using System.Windows.Forms;

namespace SistemaVotaciones.UI
{
    public partial class FrmLogin : Form
    {
        public FrmLogin()
        {
            InitializeComponent();
            txtPassword.PasswordChar = '*';
        }

        private void btnLogin_Click(object sender, EventArgs e)
        {
            if (string.IsNullOrWhiteSpace(txtUsuario.Text) || string.IsNullOrWhiteSpace(txtPassword.Text))
            {
                MessageBox.Show("Debe completar usuario y contraseña.");
                return;
            }

            UsuarioBLL usuarioBLL = new UsuarioBLL();

            Usuario usuario = usuarioBLL.Login(txtUsuario.Text.Trim(), txtPassword.Text.Trim());

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
            else
            {
                MessageBox.Show("El usuario no tiene un rol válido.");
            }
        }

        private void lblUsuario_Click(object sender, EventArgs e)
        {
        }

        private void lblContraseña_Click(object sender, EventArgs e)
        {
        }

        private void txtPassword_TextChanged(object sender, EventArgs e)
        {
        }

        private void txtUsuario_TextChanged(object sender, EventArgs e)
        {
        }

        private void btnRegistrar_Click(object sender, EventArgs e)
        {
            FrmRegistroUsuario frm = new FrmRegistroUsuario();
            frm.ShowDialog();
        }
    }
}