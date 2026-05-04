using System;
using System.Windows.Forms;
using SistemaVotaciones.BLL;

namespace SistemaVotaciones.UI
{
    public partial class FrmUsuarios : Form
    {
        private UsuarioAdminBLL bll = new UsuarioAdminBLL();

        public FrmUsuarios()
        {
            InitializeComponent();
            CargarUsuarios();
        }

        private void CargarUsuarios()
        {
            dgvUsuarios.DataSource = bll.ListarUsuarios();
            dgvUsuarios.AllowUserToAddRows = false;
            dgvUsuarios.ReadOnly = true;
            dgvUsuarios.SelectionMode = DataGridViewSelectionMode.FullRowSelect;
            dgvUsuarios.MultiSelect = false;
            dgvUsuarios.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;
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

        private void dgvUsuarios_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

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

        private void lblTitulo_Click(object sender, EventArgs e)
        {

        }
    }
}