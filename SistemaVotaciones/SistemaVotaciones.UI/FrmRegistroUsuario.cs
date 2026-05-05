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

            CargarCombosIniciales();
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

                // No ponemos IdRol aquí porque el DAL lo fuerza como Votante.
                // EstadoUsuario y YaVoto también se controlan en el DAL.
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

        private void FrmRegistroUsuario_Load(object sender, EventArgs e)
        {

        }
    }
}