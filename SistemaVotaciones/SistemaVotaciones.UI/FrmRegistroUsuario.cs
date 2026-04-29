using System;
using System.Windows.Forms;
using SistemaVotaciones.BLL;
using SistemaVotaciones.Entidades;

namespace SistemaVotaciones.UI
{
    public partial class FrmRegistroUsuario : Form
    {
        public FrmRegistroUsuario()
        {
            InitializeComponent();

            txtPassword.PasswordChar = '*';

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

            int idPadron = bll.ObtenerIdPadron(
                cmbNivel.Text,
                cmbGrado.Text,
                cmbSeccion.Text,
                cmbModalidad.Text
            );

            if (idPadron == 0)
            {
                MessageBox.Show("No existe un padrón electoral para esa selección.");
                return;
            }

            Usuario usuario = new Usuario
            {
                Matricula = txtMatricula.Text.Trim(),
                NombreCompleto = txtNombre.Text.Trim(),
                Username = txtUsuario.Text.Trim(),
                Password = txtPassword.Text.Trim(),

                Nivel = cmbNivel.Text,
                Grado = cmbGrado.Text,
                Seccion = cmbSeccion.Text,
                Modalidad = cmbModalidad.Text,

                IdPadron = idPadron
            };

            if (bll.RegistrarUsuario(usuario))
            {
                MessageBox.Show("Usuario registrado correctamente.");
                this.Close();
            }
            else
            {
                MessageBox.Show("Error al registrar usuario.");
            }
        }

        // 🔹 EVENTOS VACÍOS (para que no te den errores del Designer)

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

        private void cmbNivel_SelectedIndexChanged(object sender, EventArgs e) { }
        private void cmbGrado_SelectedIndexChanged(object sender, EventArgs e) { }
        private void cmbSeccion_SelectedIndexChanged(object sender, EventArgs e) { }
        private void cmbModalidad_SelectedIndexChanged(object sender, EventArgs e) { }
    }
}