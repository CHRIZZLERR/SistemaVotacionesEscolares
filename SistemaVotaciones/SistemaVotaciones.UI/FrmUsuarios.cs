using System;
using System.Drawing;
using System.Windows.Forms;
using SistemaVotaciones.BLL;
using SistemaVotaciones.Entidades;

namespace SistemaVotaciones.UI
{
    public partial class FrmUsuarios : Form
    {
        private UsuarioAdminBLL bll = new UsuarioAdminBLL();
        private Usuario usuarioActual;

        private Panel panelPrincipal;
        private Label lblTituloNuevo;
        private Label lblSubtituloNuevo;

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
            AplicarDiseno();
            CargarUsuarios();
            ConfigurarPermisos();
        }

        private void AplicarDiseno()
        {
            OcultarControlesViejos();

            this.Text = "Usuarios - Sistema de Votaciones";
            this.StartPosition = FormStartPosition.CenterScreen;
            this.Size = new Size(1180, 680);
            this.FormBorderStyle = FormBorderStyle.FixedSingle;
            this.MaximizeBox = false;
            this.BackColor = Color.FromArgb(8, 18, 55);

            CrearPanelPrincipal();
            CrearEncabezado();
            ConfigurarTabla();
            ConfigurarBotones();
        }

        private void OcultarControlesViejos()
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
            panelPrincipal.Size = new Size(1095, 590);
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
            lblTituloNuevo.Text = "Administración de Usuarios";
            lblTituloNuevo.Font = new Font("Segoe UI", 25, FontStyle.Bold);
            lblTituloNuevo.ForeColor = Color.White;
            lblTituloNuevo.BackColor = Color.Transparent;
            lblTituloNuevo.TextAlign = ContentAlignment.MiddleCenter;
            lblTituloNuevo.AutoSize = false;
            lblTituloNuevo.Location = new Point(20, 20);
            lblTituloNuevo.Size = new Size(1055, 45);
            panelHeader.Controls.Add(lblTituloNuevo);

            lblSubtituloNuevo = new Label();
            lblSubtituloNuevo.Text = "Consulta, activa, desactiva y administra el estado de votación de los usuarios";
            lblSubtituloNuevo.Font = new Font("Segoe UI", 10, FontStyle.Bold);
            lblSubtituloNuevo.ForeColor = Color.FromArgb(255, 215, 90);
            lblSubtituloNuevo.BackColor = Color.Transparent;
            lblSubtituloNuevo.TextAlign = ContentAlignment.MiddleCenter;
            lblSubtituloNuevo.AutoSize = false;
            lblSubtituloNuevo.Location = new Point(20, 65);
            lblSubtituloNuevo.Size = new Size(1055, 25);
            panelHeader.Controls.Add(lblSubtituloNuevo);
        }

        private void ConfigurarTabla()
        {
            panelPrincipal.Controls.Add(dgvUsuarios);

            dgvUsuarios.Visible = true;
            dgvUsuarios.Location = new Point(35, 135);
            dgvUsuarios.Size = new Size(1025, 340);
            dgvUsuarios.BackgroundColor = Color.White;
            dgvUsuarios.BorderStyle = BorderStyle.FixedSingle;

            dgvUsuarios.EnableHeadersVisualStyles = false;
            dgvUsuarios.ColumnHeadersDefaultCellStyle.BackColor = Color.FromArgb(10, 38, 95);
            dgvUsuarios.ColumnHeadersDefaultCellStyle.ForeColor = Color.White;
            dgvUsuarios.ColumnHeadersDefaultCellStyle.Font = new Font("Segoe UI", 10, FontStyle.Bold);

            dgvUsuarios.DefaultCellStyle.Font = new Font("Segoe UI", 10, FontStyle.Regular);
            dgvUsuarios.DefaultCellStyle.SelectionBackColor = Color.FromArgb(21, 101, 192);
            dgvUsuarios.DefaultCellStyle.SelectionForeColor = Color.White;

            dgvUsuarios.RowHeadersDefaultCellStyle.BackColor = Color.FromArgb(10, 38, 95);
            dgvUsuarios.RowHeadersDefaultCellStyle.ForeColor = Color.White;

            dgvUsuarios.AllowUserToAddRows = false;
            dgvUsuarios.ReadOnly = true;
            dgvUsuarios.SelectionMode = DataGridViewSelectionMode.FullRowSelect;
            dgvUsuarios.MultiSelect = false;
            dgvUsuarios.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.None;
        }

        private void ConfigurarBotones()
        {
            panelPrincipal.Controls.Add(btnActualizar);
            panelPrincipal.Controls.Add(btnActivar);
            panelPrincipal.Controls.Add(btnDesactivar);
            panelPrincipal.Controls.Add(btnReiniciarVoto);
            panelPrincipal.Controls.Add(btnCerrar);

            btnActualizar.Visible = true;
            btnActivar.Visible = true;
            btnDesactivar.Visible = true;
            btnReiniciarVoto.Visible = true;
            btnCerrar.Visible = true;

            btnActualizar.Text = "Actualizar";
            btnActivar.Text = "Activar";
            btnDesactivar.Text = "Desactivar";
            btnReiniciarVoto.Text = "Reiniciar voto";
            btnCerrar.Text = "Cerrar";

            EstiloBoton(btnActualizar);
            EstiloBoton(btnActivar);
            EstiloBotonSecundario(btnDesactivar);
            EstiloBotonSecundario(btnReiniciarVoto);
            EstiloBotonCerrar(btnCerrar);

            btnActualizar.Location = new Point(35, 505);
            btnActualizar.Size = new Size(170, 45);

            btnActivar.Location = new Point(225, 505);
            btnActivar.Size = new Size(170, 45);

            btnDesactivar.Location = new Point(415, 505);
            btnDesactivar.Size = new Size(170, 45);

            btnReiniciarVoto.Location = new Point(605, 505);
            btnReiniciarVoto.Size = new Size(200, 45);

            btnCerrar.Location = new Point(890, 505);
            btnCerrar.Size = new Size(170, 45);

            btnActualizar.BringToFront();
            btnActivar.BringToFront();
            btnDesactivar.BringToFront();
            btnReiniciarVoto.BringToFront();
            btnCerrar.BringToFront();
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

        private void EstiloBotonSecundario(Button boton)
        {
            boton.FlatStyle = FlatStyle.Flat;
            boton.FlatAppearance.BorderSize = 0;
            boton.BackColor = Color.FromArgb(90, 90, 110);
            boton.ForeColor = Color.White;
            boton.Font = new Font("Segoe UI", 10, FontStyle.Bold);
            boton.Cursor = Cursors.Hand;

            boton.MouseEnter += (s, e) =>
            {
                boton.BackColor = Color.FromArgb(115, 115, 135);
            };

            boton.MouseLeave += (s, e) =>
            {
                boton.BackColor = Color.FromArgb(90, 90, 110);
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

        private void ConfigurarPermisos()
        {
            if (usuarioActual == null)
                return;

            if (usuarioActual.IdRol == 3)
            {
                lblTituloNuevo.Text = "Usuarios de mi Plancha";
                lblSubtituloNuevo.Text = "Consulta y administra únicamente los integrantes asociados a tu plancha.";
            }
            else
            {
                lblTituloNuevo.Text = "Administración de Usuarios";
                lblSubtituloNuevo.Text = "Consulta, activa, desactiva y administra el estado de votación de los usuarios.";
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