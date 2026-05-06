using System;
using System.Data;
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

        private Button btnCrearAdminPlancha;

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
            this.Size = new Size(1180, 700);
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
            panelPrincipal.Size = new Size(1095, 610);
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

            btnCrearAdminPlancha = new Button();
            btnCrearAdminPlancha.Text = "Crear admin plancha";
            btnCrearAdminPlancha.Click += btnCrearAdminPlancha_Click;
            panelPrincipal.Controls.Add(btnCrearAdminPlancha);

            btnActualizar.Visible = true;
            btnActivar.Visible = true;
            btnDesactivar.Visible = true;
            btnReiniciarVoto.Visible = true;
            btnCerrar.Visible = true;
            btnCrearAdminPlancha.Visible = true;

            btnActualizar.Text = "Actualizar";
            btnActivar.Text = "Activar";
            btnDesactivar.Text = "Desactivar";
            btnReiniciarVoto.Text = "Reiniciar voto";
            btnCerrar.Text = "Cerrar";

            EstiloBoton(btnActualizar);
            EstiloBoton(btnActivar);
            EstiloBoton(btnCrearAdminPlancha);
            EstiloBotonSecundario(btnDesactivar);
            EstiloBotonSecundario(btnReiniciarVoto);
            EstiloBotonCerrar(btnCerrar);

            btnActualizar.Location = new Point(35, 500);
            btnActualizar.Size = new Size(150, 45);

            btnActivar.Location = new Point(205, 500);
            btnActivar.Size = new Size(150, 45);

            btnDesactivar.Location = new Point(375, 500);
            btnDesactivar.Size = new Size(150, 45);

            btnReiniciarVoto.Location = new Point(545, 500);
            btnReiniciarVoto.Size = new Size(170, 45);

            btnCrearAdminPlancha.Location = new Point(735, 500);
            btnCrearAdminPlancha.Size = new Size(170, 45);

            btnCerrar.Location = new Point(925, 500);
            btnCerrar.Size = new Size(135, 45);

            btnActualizar.BringToFront();
            btnActivar.BringToFront();
            btnDesactivar.BringToFront();
            btnReiniciarVoto.BringToFront();
            btnCrearAdminPlancha.BringToFront();
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
                if (boton.Enabled)
                    boton.BackColor = Color.FromArgb(25, 118, 210);
            };

            boton.MouseLeave += (s, e) =>
            {
                if (boton.Enabled)
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
                if (boton.Enabled)
                    boton.BackColor = Color.FromArgb(115, 115, 135);
            };

            boton.MouseLeave += (s, e) =>
            {
                if (boton.Enabled)
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

                btnCrearAdminPlancha.Visible = false;
            }
            else
            {
                lblTituloNuevo.Text = "Administración de Usuarios";
                lblSubtituloNuevo.Text = "Consulta, activa, desactiva y administra el estado de votación de los usuarios.";

                btnCrearAdminPlancha.Visible = true;
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

        private void MostrarFormularioCrearAdminPlancha()
        {
            Form frm = new Form();
            frm.Text = "Crear administrador de plancha";
            frm.StartPosition = FormStartPosition.CenterParent;
            frm.Size = new Size(500, 460);
            frm.FormBorderStyle = FormBorderStyle.FixedDialog;
            frm.MaximizeBox = false;
            frm.MinimizeBox = false;
            frm.BackColor = Color.FromArgb(245, 248, 255);

            Label lblTitulo = new Label();
            lblTitulo.Text = "Nuevo administrador de plancha";
            lblTitulo.Font = new Font("Segoe UI", 16, FontStyle.Bold);
            lblTitulo.ForeColor = Color.FromArgb(10, 38, 95);
            lblTitulo.TextAlign = ContentAlignment.MiddleCenter;
            lblTitulo.Location = new Point(20, 20);
            lblTitulo.Size = new Size(440, 35);
            frm.Controls.Add(lblTitulo);

            Label lblNombre = CrearLabelDialogo("Nombre completo", 45, 75);
            TextBox txtNombre = CrearTextBoxDialogo(45, 100);

            Label lblUsuario = CrearLabelDialogo("Usuario", 45, 135);
            TextBox txtUsuario = CrearTextBoxDialogo(45, 160);

            Label lblPassword = CrearLabelDialogo("Contraseña", 45, 195);
            TextBox txtPassword = CrearTextBoxDialogo(45, 220);
            txtPassword.PasswordChar = '*';

            Label lblMatricula = CrearLabelDialogo("Matrícula / Código", 45, 255);
            TextBox txtMatricula = CrearTextBoxDialogo(45, 280);

            Label lblPadron = CrearLabelDialogo("Padrón de referencia", 45, 315);
            ComboBox cmbPadron = new ComboBox();
            cmbPadron.Location = new Point(45, 340);
            cmbPadron.Size = new Size(395, 30);
            cmbPadron.Font = new Font("Segoe UI", 10, FontStyle.Regular);
            cmbPadron.DropDownStyle = ComboBoxStyle.DropDownList;
            cmbPadron.DataSource = bll.ListarPadrones();
            cmbPadron.DisplayMember = "NombrePadron";
            cmbPadron.ValueMember = "IdPadron";

            Button btnGuardar = new Button();
            btnGuardar.Text = "Crear admin";
            btnGuardar.Location = new Point(45, 385);
            btnGuardar.Size = new Size(180, 40);
            EstiloBoton(btnGuardar);

            Button btnCancelar = new Button();
            btnCancelar.Text = "Cancelar";
            btnCancelar.Location = new Point(260, 385);
            btnCancelar.Size = new Size(180, 40);
            EstiloBotonCerrar(btnCancelar);

            btnCancelar.Click += (s, e) =>
            {
                frm.Close();
            };

            btnGuardar.Click += (s, e) =>
            {
                if (string.IsNullOrWhiteSpace(txtNombre.Text) ||
                    string.IsNullOrWhiteSpace(txtUsuario.Text) ||
                    string.IsNullOrWhiteSpace(txtPassword.Text) ||
                    string.IsNullOrWhiteSpace(txtMatricula.Text) ||
                    cmbPadron.SelectedValue == null)
                {
                    MessageBox.Show("Debe completar todos los campos.");
                    return;
                }

                if (cmbPadron.SelectedValue is DataRowView)
                {
                    return;
                }

                Usuario nuevoAdmin = new Usuario
                {
                    Matricula = txtMatricula.Text.Trim(),
                    NombreCompleto = txtNombre.Text.Trim(),
                    Username = txtUsuario.Text.Trim(),
                    Password = txtPassword.Text.Trim(),

                    Nivel = "Administrativo",
                    Grado = "N/A",
                    Seccion = "N/A",
                    Modalidad = "Administración",

                    IdRol = 3,
                    IdPadron = Convert.ToInt32(cmbPadron.SelectedValue),
                    EstadoUsuario = true,
                    YaVoto = false
                };

                if (bll.CrearAdministradorPlancha(nuevoAdmin))
                {
                    MessageBox.Show("Administrador de plancha creado correctamente.");
                    frm.Close();
                    CargarUsuarios();
                }
                else
                {
                    MessageBox.Show("No se pudo crear el administrador. Puede que el usuario o la matrícula ya existan.");
                }
            };

            frm.Controls.Add(lblNombre);
            frm.Controls.Add(txtNombre);
            frm.Controls.Add(lblUsuario);
            frm.Controls.Add(txtUsuario);
            frm.Controls.Add(lblPassword);
            frm.Controls.Add(txtPassword);
            frm.Controls.Add(lblMatricula);
            frm.Controls.Add(txtMatricula);
            frm.Controls.Add(lblPadron);
            frm.Controls.Add(cmbPadron);
            frm.Controls.Add(btnGuardar);
            frm.Controls.Add(btnCancelar);

            frm.ShowDialog();
        }

        private Label CrearLabelDialogo(string texto, int x, int y)
        {
            Label label = new Label();
            label.Text = texto;
            label.Location = new Point(x, y);
            label.Size = new Size(300, 22);
            label.Font = new Font("Segoe UI", 10, FontStyle.Bold);
            label.ForeColor = Color.FromArgb(10, 38, 95);
            label.BackColor = Color.Transparent;
            return label;
        }

        private TextBox CrearTextBoxDialogo(int x, int y)
        {
            TextBox textBox = new TextBox();
            textBox.Location = new Point(x, y);
            textBox.Size = new Size(395, 30);
            textBox.Font = new Font("Segoe UI", 10, FontStyle.Regular);
            textBox.BorderStyle = BorderStyle.FixedSingle;
            return textBox;
        }

        private void btnCrearAdminPlancha_Click(object sender, EventArgs e)
        {
            if (usuarioActual == null || usuarioActual.IdRol != 1)
            {
                MessageBox.Show("Solo el administrador general puede crear administradores de plancha.");
                return;
            }

            MostrarFormularioCrearAdminPlancha();
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