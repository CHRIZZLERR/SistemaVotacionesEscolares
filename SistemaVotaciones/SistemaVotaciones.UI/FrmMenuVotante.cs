using System;
using System.Drawing;
using System.Drawing.Drawing2D;
using System.Windows.Forms;
using SistemaVotaciones.Entidades;

namespace SistemaVotaciones.UI
{
    public partial class FrmMenuVotante : Form
    {
        private Usuario usuarioActual;

        private Panel panelPrincipal;
        private Label lblSistema;
        private Label lblBienvenida;
        private Label lblRolUsuario;
        private Label lblEstadoVoto;
        private Label lblDescripcion;

        public FrmMenuVotante(Usuario usuario)
        {
            InitializeComponent();
            usuarioActual = usuario;
        }

        private void FrmMenuVotante_Load(object sender, EventArgs e)
        {
            AplicarDiseno();
            CargarDatosUsuario();
        }

        private void AplicarDiseno()
        {
            this.Text = "Menú del Votante - Sistema de Votaciones";
            this.StartPosition = FormStartPosition.CenterScreen;
            this.Size = new Size(820, 560);
            this.FormBorderStyle = FormBorderStyle.FixedSingle;
            this.MaximizeBox = false;
            this.BackColor = Color.FromArgb(8, 18, 55);

            this.Paint += FrmMenuVotante_Paint;

            CrearPanelPrincipal();
            CrearEncabezado();
            CrearBotones();
        }

        private void FrmMenuVotante_Paint(object sender, PaintEventArgs e)
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

        private void CrearPanelPrincipal()
        {
            panelPrincipal = new Panel();
            panelPrincipal.BackColor = Color.FromArgb(245, 248, 255);
            panelPrincipal.Location = new Point(80, 55);
            panelPrincipal.Size = new Size(650, 430);
            panelPrincipal.BorderStyle = BorderStyle.None;
            this.Controls.Add(panelPrincipal);
            panelPrincipal.BringToFront();
        }

        private void CrearEncabezado()
        {
            Panel panelHeader = new Panel();
            panelHeader.BackColor = Color.FromArgb(10, 38, 95);
            panelHeader.Location = new Point(0, 0);
            panelHeader.Size = new Size(650, 145);
            panelPrincipal.Controls.Add(panelHeader);

            lblSistema = new Label();
            lblSistema.Text = "SISTEMA DE VOTACIONES ESCOLARES";
            lblSistema.Font = new Font("Segoe UI", 11, FontStyle.Bold);
            lblSistema.ForeColor = Color.FromArgb(255, 215, 90);
            lblSistema.BackColor = Color.Transparent;
            lblSistema.AutoSize = false;
            lblSistema.TextAlign = ContentAlignment.MiddleCenter;
            lblSistema.Location = new Point(0, 15);
            lblSistema.Size = new Size(650, 25);
            panelHeader.Controls.Add(lblSistema);

            lblBienvenida = new Label();
            lblBienvenida.Font = new Font("Segoe UI", 25, FontStyle.Bold);
            lblBienvenida.ForeColor = Color.White;
            lblBienvenida.BackColor = Color.Transparent;
            lblBienvenida.AutoSize = false;
            lblBienvenida.TextAlign = ContentAlignment.MiddleCenter;
            lblBienvenida.Location = new Point(20, 45);
            lblBienvenida.Size = new Size(610, 48);
            panelHeader.Controls.Add(lblBienvenida);

            lblRolUsuario = new Label();
            lblRolUsuario.Font = new Font("Segoe UI", 11, FontStyle.Bold);
            lblRolUsuario.ForeColor = Color.FromArgb(220, 230, 255);
            lblRolUsuario.BackColor = Color.Transparent;
            lblRolUsuario.AutoSize = false;
            lblRolUsuario.TextAlign = ContentAlignment.MiddleCenter;
            lblRolUsuario.Location = new Point(20, 95);
            lblRolUsuario.Size = new Size(610, 25);
            panelHeader.Controls.Add(lblRolUsuario);

            lblEstadoVoto = new Label();
            lblEstadoVoto.Font = new Font("Segoe UI", 11, FontStyle.Bold);
            lblEstadoVoto.BackColor = Color.Transparent;
            lblEstadoVoto.AutoSize = false;
            lblEstadoVoto.TextAlign = ContentAlignment.MiddleCenter;
            lblEstadoVoto.Location = new Point(20, 118);
            lblEstadoVoto.Size = new Size(610, 22);
            panelHeader.Controls.Add(lblEstadoVoto);

            lblDescripcion = new Label();
            lblDescripcion.Text = "Consulta la información de la votación o emite tu voto de forma segura.";
            lblDescripcion.Font = new Font("Segoe UI", 10, FontStyle.Regular);
            lblDescripcion.ForeColor = Color.FromArgb(80, 90, 110);
            lblDescripcion.BackColor = Color.Transparent;
            lblDescripcion.AutoSize = false;
            lblDescripcion.TextAlign = ContentAlignment.MiddleCenter;
            lblDescripcion.Location = new Point(50, 165);
            lblDescripcion.Size = new Size(550, 30);
            panelPrincipal.Controls.Add(lblDescripcion);
        }

        private void CrearBotones()
        {
            panelPrincipal.Controls.Add(btnInfoVotacion);
            panelPrincipal.Controls.Add(btnVotar);
            panelPrincipal.Controls.Add(btnCerrarSesion);

            btnInfoVotacion.Text = "Información de votación";
            btnVotar.Text = "Votar";
            btnCerrarSesion.Text = "Cerrar sesión";

            EstiloBotonPrincipal(btnInfoVotacion);
            EstiloBotonPrincipal(btnVotar);
            EstiloBotonCerrar(btnCerrarSesion);

            btnInfoVotacion.Location = new Point(145, 215);
            btnInfoVotacion.Size = new Size(360, 58);

            btnVotar.Location = new Point(145, 290);
            btnVotar.Size = new Size(360, 58);

            btnCerrarSesion.Location = new Point(145, 365);
            btnCerrarSesion.Size = new Size(360, 52);

            btnInfoVotacion.BringToFront();
            btnVotar.BringToFront();
            btnCerrarSesion.BringToFront();
        }

        private void EstiloBotonPrincipal(Button boton)
        {
            boton.FlatStyle = FlatStyle.Flat;
            boton.FlatAppearance.BorderSize = 0;
            boton.BackColor = Color.FromArgb(21, 101, 192);
            boton.ForeColor = Color.White;
            boton.Font = new Font("Segoe UI", 12, FontStyle.Bold);
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

        private void EstiloBotonCerrar(Button boton)
        {
            boton.FlatStyle = FlatStyle.Flat;
            boton.FlatAppearance.BorderSize = 0;
            boton.BackColor = Color.FromArgb(185, 28, 28);
            boton.ForeColor = Color.White;
            boton.Font = new Font("Segoe UI", 12, FontStyle.Bold);
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

        private void CargarDatosUsuario()
        {
            if (usuarioActual == null)
                return;

            lblBienvenida.Text = "Bienvenido, " + usuarioActual.NombreCompleto;
            lblRolUsuario.Text = "Rol: Votante";

            if (usuarioActual.YaVoto)
            {
                lblEstadoVoto.Text = "Estado: Ya votó";
                lblEstadoVoto.ForeColor = Color.LightGreen;

                btnVotar.Enabled = false;
                btnVotar.Text = "Ya votaste";
                btnVotar.BackColor = Color.Gray;
            }
            else
            {
                lblEstadoVoto.Text = "Estado: Pendiente de votar";
                lblEstadoVoto.ForeColor = Color.FromArgb(255, 215, 90);

                btnVotar.Enabled = true;
                btnVotar.Text = "Votar";
            }
        }

        private void btnVotar_Click(object sender, EventArgs e)
        {
            if (usuarioActual == null)
            {
                MessageBox.Show("No se recibió información del usuario.");
                return;
            }

            if (usuarioActual.YaVoto)
            {
                MessageBox.Show("Ya usted realizó su voto. No puede votar nuevamente.");
                return;
            }

            FrmVotar frm = new FrmVotar(usuarioActual);
            frm.ShowDialog();

            if (usuarioActual.YaVoto)
            {
                MessageBox.Show("Su estado de votación fue actualizado. Ya no podrá votar nuevamente.");
                CargarDatosUsuario();
            }
        }

        private void btnInfoVotacion_Click(object sender, EventArgs e)
        {
            if (usuarioActual == null)
            {
                MessageBox.Show("No se recibió información del usuario.");
                return;
            }

            FrmInfoVotacion frm = new FrmInfoVotacion(usuarioActual);
            frm.ShowDialog();
        }

        private void btnCerrarSesion_Click(object sender, EventArgs e)
        {
            FrmLogin login = new FrmLogin();
            login.Show();
            this.Close();
        }
    }
}