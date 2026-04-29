using SistemaVotaciones.BLL;
using SistemaVotaciones.Entidades;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace SistemaVotaciones.UI
{
    public partial class FrmLogin : Form
    {
        public FrmLogin()
        {
            InitializeComponent();
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

            MessageBox.Show("Bienvenido " + usuario.Username);

            if (usuario.IdRol == 1)
            {
                // Luego abriremos el menú administrador
                MessageBox.Show("Entrando como administrador.");
            }
            else if (usuario.IdRol == 2)
            {
                // Luego abriremos el menú votante
                MessageBox.Show("Entrando como votante.");
            }
        }
    }
}
