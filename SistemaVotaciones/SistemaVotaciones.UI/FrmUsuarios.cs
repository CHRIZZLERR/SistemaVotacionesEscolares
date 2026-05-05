using System;
using System.Windows.Forms;
using SistemaVotaciones.BLL;
using SistemaVotaciones.Entidades;

namespace SistemaVotaciones.UI
{
    public partial class FrmUsuarios : Form
    {
        private UsuarioAdminBLL bll = new UsuarioAdminBLL();
        private Usuario usuarioActual;

        public FrmUsuarios()
        {
            InitializeComponent();
        }

        public FrmUsuarios(Usuario usuario)
        {
            InitializeComponent();
            usuarioActual = usuario;
        }

        private void FrmUsuarios_Load(object sender, EventArgs e)
        {
            CargarUsuarios();
            ConfigurarPermisos();
        }

        private void ConfigurarPermisos()
        {
            if (usuarioActual == null)
                return;

            if (usuarioActual.IdRol == 3)
            {
                lblTitulo.Text = "Usuarios de mi Plancha";
            }
            else
            {
                lblTitulo.Text = "Usuarios";
            }
        }

        private void CargarUsuarios()
        {
            try
            {
                dgvUsuarios.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.None;
                dgvUsuarios.DataSource = null;

                dgvUsuarios.DataSource = bll.ListarUsuarios(usuarioActual);

                dgvUsuarios.AllowUserToAddRows = false;
                dgvUsuarios.ReadOnly = true;
                dgvUsuarios.SelectionMode = DataGridViewSelectionMode.FullRowSelect;
                dgvUsuarios.MultiSelect = false;

                AjustarColumnas();
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error al cargar los usuarios:\n" + ex.Message);
            }
        }

        private void AjustarColumnas()
        {
            if (dgvUsuarios.Columns.Count == 0)
                return;

            if (dgvUsuarios.Columns.Contains("IdUsuario"))
                dgvUsuarios.Columns["IdUsuario"].Width = 80;

            if (dgvUsuarios.Columns.Contains("Matricula"))
                dgvUsuarios.Columns["Matricula"].Width = 100;

            if (dgvUsuarios.Columns.Contains("NombreCompleto"))
                dgvUsuarios.Columns["NombreCompleto"].Width = 180;

            if (dgvUsuarios.Columns.Contains("Username"))
                dgvUsuarios.Columns["Username"].Width = 120;

            if (dgvUsuarios.Columns.Contains("Rol"))
                dgvUsuarios.Columns["Rol"].Width = 160;

            if (dgvUsuarios.Columns.Contains("Padron"))
                dgvUsuarios.Columns["Padron"].Width = 220;

            if (dgvUsuarios.Columns.Contains("Plancha"))
                dgvUsuarios.Columns["Plancha"].Width = 160;

            if (dgvUsuarios.Columns.Contains("Cargo"))
                dgvUsuarios.Columns["Cargo"].Width = 150;

            if (dgvUsuarios.Columns.Contains("Estado"))
                dgvUsuarios.Columns["Estado"].Width = 100;

            if (dgvUsuarios.Columns.Contains("YaVoto"))
                dgvUsuarios.Columns["YaVoto"].Width = 90;
        }

        private int ObtenerIdUsuarioSeleccionado()
        {
            if (dgvUsuarios.CurrentRow == null)
            {
                MessageBox.Show("Debe seleccionar un usuario.");
                return 0;
            }

            if (dgvUsuarios.CurrentRow.Cells["IdUsuario"].Value == null)
            {
                MessageBox.Show("No se pudo obtener el ID del usuario seleccionado.");
                return 0;
            }

            return Convert.ToInt32(dgvUsuarios.CurrentRow.Cells["IdUsuario"].Value);
        }

        private string ObtenerNombreUsuarioSeleccionado()
        {
            if (dgvUsuarios.CurrentRow == null)
                return "";

            if (dgvUsuarios.CurrentRow.Cells["NombreCompleto"].Value == null)
                return "";

            return dgvUsuarios.CurrentRow.Cells["NombreCompleto"].Value.ToString();
        }

        private void btnActualizar_Click(object sender, EventArgs e)
        {
            CargarUsuarios();
            MessageBox.Show("Lista de usuarios actualizada.");
        }

        private void btnActivar_Click(object sender, EventArgs e)
        {
            int idUsuario = ObtenerIdUsuarioSeleccionado();

            if (idUsuario == 0)
                return;

            string nombre = ObtenerNombreUsuarioSeleccionado();

            DialogResult respuesta = MessageBox.Show(
                "¿Está seguro de activar este usuario?\n\nUsuario: " + nombre,
                "Confirmar activación",
                MessageBoxButtons.YesNo,
                MessageBoxIcon.Question
            );

            if (respuesta != DialogResult.Yes)
                return;

            bool resultado = bll.ActivarUsuario(idUsuario);

            if (resultado)
            {
                MessageBox.Show("Usuario activado correctamente.");
                CargarUsuarios();
            }
            else
            {
                MessageBox.Show("No se pudo activar el usuario.");
            }
        }

        private void btnDesactivar_Click(object sender, EventArgs e)
        {
            int idUsuario = ObtenerIdUsuarioSeleccionado();

            if (idUsuario == 0)
                return;

            if (usuarioActual != null && idUsuario == usuarioActual.IdUsuario)
            {
                MessageBox.Show("No puedes desactivar tu propio usuario mientras estás en sesión.");
                return;
            }

            string nombre = ObtenerNombreUsuarioSeleccionado();

            DialogResult respuesta = MessageBox.Show(
                "¿Está seguro de desactivar este usuario?\n\nUsuario: " + nombre,
                "Confirmar desactivación",
                MessageBoxButtons.YesNo,
                MessageBoxIcon.Warning
            );

            if (respuesta != DialogResult.Yes)
                return;

            bool resultado = bll.DesactivarUsuario(idUsuario);

            if (resultado)
            {
                MessageBox.Show("Usuario desactivado correctamente.");
                CargarUsuarios();
            }
            else
            {
                MessageBox.Show("No se pudo desactivar el usuario.");
            }
        }

        private void btnReiniciarVoto_Click(object sender, EventArgs e)
        {
            int idUsuario = ObtenerIdUsuarioSeleccionado();

            if (idUsuario == 0)
                return;

            string nombre = ObtenerNombreUsuarioSeleccionado();

            DialogResult respuesta = MessageBox.Show(
                "¿Está seguro de reiniciar el voto de este usuario?\n\nUsuario: " + nombre + "\n\nEsto cambiará YaVoto a 'No'.",
                "Confirmar reinicio de voto",
                MessageBoxButtons.YesNo,
                MessageBoxIcon.Warning
            );

            if (respuesta != DialogResult.Yes)
                return;

            bool resultado = bll.ReiniciarVoto(idUsuario);

            if (resultado)
            {
                MessageBox.Show("Voto reiniciado correctamente.");
                CargarUsuarios();
            }
            else
            {
                MessageBox.Show("No se pudo reiniciar el voto.");
            }
        }

        private void btnCerrar_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void dgvUsuarios_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }

        private void lblTitulo_Click(object sender, EventArgs e)
        {

        }
    }
}