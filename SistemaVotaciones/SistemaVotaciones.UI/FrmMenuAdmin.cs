using System;
using System.Drawing;
using System.Drawing.Drawing2D;
using System.Windows.Forms;
using SistemaVotaciones.Entidades;

namespace SistemaVotaciones.UI
{
    public partial class FrmMenuAdmin : Form
    {
        private Usuario usuarioActual;

        private Panel panelPrincipal;
        private Label lblSistema;
        private Label lblRolUsuario;
        private Label lblDescripcion;

        public FrmMenuAdmin(Usuario usuario)
        {
            InitializeComponent();
            usuarioActual = usuario;
        }

        private void FrmMenuAdmin_Load(object sender, EventArgs e)
        {
            AplicarDiseno();
            ConfigurarMenuPorRol();
        }

        private void AplicarDiseno()
        {
            this.Text = "Panel Administrativo - Sistema de Votaciones";
            this.StartPosition = FormStartPosition.CenterScreen;
            this.Size = new Size(1080, 620);
            this.FormBorderStyle = FormBorderStyle.FixedSingle;
            this.MaximizeBox = false;
            this.BackColor = Color.FromArgb(8, 18, 55);

            this.Paint += FrmMenuAdmin_Paint;

            CrearPanelPrincipal();
            CrearEncabezado();
            CrearBotones();
        }

        private void FrmMenuAdmin_Paint(object sender, PaintEventArgs e)
        {
            using (LinearGradientBrush brush = new LinearGradientBrush(
                this.ClientRectangle,
                Color.FromArgb(8, 18, 55),
                Color.FromArgb(18, 65, 125),
                90F))
            {
                e.Graphics.FillRectangle(brush, this.ClientRectangle);
            }
        }

        private void CrearPanelPrincipal()
        {
            panelPrincipal = new Panel();
            panelPrincipal.BackColor = Color.FromArgb(245, 248, 255);
            panelPrincipal.Location = new Point(55, 45);
            panelPrincipal.Size = new Size(950, 500);
            panelPrincipal.BorderStyle = BorderStyle.None;
            this.Controls.Add(panelPrincipal);
            panelPrincipal.BringToFront();
        }

        private void CrearEncabezado()
        {
            Panel panelHeader = new Panel();
            panelHeader.BackColor = Color.FromArgb(10, 38, 95);
            panelHeader.Location = new Point(0, 0);
            panelHeader.Size = new Size(950, 145);
            panelPrincipal.Controls.Add(panelHeader);

            lblSistema = new Label();
            lblSistema.Text = "PANEL DE ADMINISTRACIÓN ELECTORAL";
            lblSistema.Font = new Font("Segoe UI", 11, FontStyle.Bold);
            lblSistema.ForeColor = Color.FromArgb(255, 215, 90);
            lblSistema.BackColor = Color.Transparent;
            lblSistema.AutoSize = false;
            lblSistema.TextAlign = ContentAlignment.MiddleCenter;
            lblSistema.Location = new Point(0, 15);
            lblSistema.Size = new Size(950, 25);
            panelHeader.Controls.Add(lblSistema);

            lblManuAdmin.AutoSize = false;
            lblManuAdmin.TextAlign = ContentAlignment.MiddleCenter;
            lblManuAdmin.Font = new Font("Segoe UI", 26, FontStyle.Bold);
            lblManuAdmin.ForeColor = Color.White;
            lblManuAdmin.BackColor = Color.Transparent;
            lblManuAdmin.Location = new Point(20, 45);
            lblManuAdmin.Size = new Size(910, 48);
            panelHeader.Controls.Add(lblManuAdmin);

            lblRolUsuario = new Label();
            lblRolUsuario.Font = new Font("Segoe UI", 11, FontStyle.Bold);
            lblRolUsuario.ForeColor = Color.FromArgb(220, 230, 255);
            lblRolUsuario.BackColor = Color.Transparent;
            lblRolUsuario.AutoSize = false;
            lblRolUsuario.TextAlign = ContentAlignment.MiddleCenter;
            lblRolUsuario.Location = new Point(20, 96);
            lblRolUsuario.Size = new Size(910, 25);
            panelHeader.Controls.Add(lblRolUsuario);

            lblDescripcion = new Label();
            lblDescripcion.Text = "Gestiona usuarios, padrones, planchas, votaciones, resultados y reportes del sistema.";
            lblDescripcion.Font = new Font("Segoe UI", 10, FontStyle.Regular);
            lblDescripcion.ForeColor = Color.FromArgb(80, 90, 110);
            lblDescripcion.BackColor = Color.Transparent;
            lblDescripcion.AutoSize = false;
            lblDescripcion.TextAlign = ContentAlignment.MiddleCenter;
            lblDescripcion.Location = new Point(80, 160);
            lblDescripcion.Size = new Size(790, 28);
            panelPrincipal.Controls.Add(lblDescripcion);
        }

        private void CrearBotones()
        {
            panelPrincipal.Controls.Add(btnUsuarios);
            panelPrincipal.Controls.Add(btnPadrones);
            panelPrincipal.Controls.Add(btnVotaciones);
            panelPrincipal.Controls.Add(btnPlanchas);
            panelPrincipal.Controls.Add(btnIntegrantesPlancha);
            panelPrincipal.Controls.Add(btnResultados);
            panelPrincipal.Controls.Add(btnReportes);
            panelPrincipal.Controls.Add(btnCerrarSesion);

            EstiloBotonModulo(btnUsuarios);
            EstiloBotonModulo(btnPadrones);
            EstiloBotonModulo(btnVotaciones);
            EstiloBotonModulo(btnPlanchas);
            EstiloBotonModulo(btnIntegrantesPlancha);
            EstiloBotonModulo(btnResultados);
            EstiloBotonModulo(btnReportes);
            EstiloBotonCerrar(btnCerrarSesion);

            btnUsuarios.Text = "Usuarios";
            btnPadrones.Text = "Padrones";
            btnVotaciones.Text = "Votaciones";
            btnPlanchas.Text = "Planchas";
            btnIntegrantesPlancha.Text = "Integrantes de Plancha";
            btnResultados.Text = "Resultados";
            btnReportes.Text = "Reportes";
            btnCerrarSesion.Text = "Cerrar sesión";

            OrganizarBotonesAdminGeneral();
        }

        private void EstiloBotonModulo(Button boton)
        {
            boton.FlatStyle = FlatStyle.Flat;
            boton.FlatAppearance.BorderSize = 0;
            boton.BackColor = Color.FromArgb(21, 101, 192);
            boton.ForeColor = Color.White;
            boton.Font = new Font("Segoe UI", 11, FontStyle.Bold);
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
            boton.Font = new Font("Segoe UI", 11, FontStyle.Bold);
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

        private void OrganizarBotonesAdminGeneral()
        {
            int ancho = 245;
            int alto = 58;
            int espacioX = 35;
            int espacioY = 22;
            int inicioX = 80;
            int inicioY = 215;

            btnUsuarios.Location = new Point(inicioX, inicioY);
            btnUsuarios.Size = new Size(ancho, alto);

            btnPadrones.Location = new Point(inicioX + ancho + espacioX, inicioY);
            btnPadrones.Size = new Size(ancho, alto);

            btnVotaciones.Location = new Point(inicioX + (ancho + espacioX) * 2, inicioY);
            btnVotaciones.Size = new Size(ancho, alto);

            btnPlanchas.Location = new Point(inicioX, inicioY + alto + espacioY);
            btnPlanchas.Size = new Size(ancho, alto);

            btnIntegrantesPlancha.Location = new Point(inicioX + ancho + espacioX, inicioY + alto + espacioY);
            btnIntegrantesPlancha.Size = new Size(ancho, alto);

            btnResultados.Location = new Point(inicioX + (ancho + espacioX) * 2, inicioY + alto + espacioY);
            btnResultados.Size = new Size(ancho, alto);

            btnReportes.Location = new Point(inicioX, inicioY + (alto + espacioY) * 2);
            btnReportes.Size = new Size(ancho, alto);

            btnCerrarSesion.Location = new Point(770, 445);
            btnCerrarSesion.Size = new Size(160, 42);
        }

        private void OrganizarBotonesAdminPlancha()
        {
            int ancho = 340;
            int alto = 55;
            int x = 305;
            int y = 200;
            int espacio = 20;

            btnUsuarios.Location = new Point(x, y);
            btnUsuarios.Size = new Size(ancho, alto);

            btnIntegrantesPlancha.Location = new Point(x, y + alto + espacio);
            btnIntegrantesPlancha.Size = new Size(ancho, alto);

            btnResultados.Location = new Point(x, y + (alto + espacio) * 2);
            btnResultados.Size = new Size(ancho, alto);

            btnCerrarSesion.Location = new Point(x, y + (alto + espacio) * 3 + 10);
            btnCerrarSesion.Size = new Size(ancho, 50);

            btnCerrarSesion.BringToFront();
        }

        private void ConfigurarMenuPorRol()
        {
            if (usuarioActual == null)
                return;

            string nombre = usuarioActual.NombreCompleto;

            if (usuarioActual.IdRol == 1)
            {
                lblManuAdmin.Text = "Bienvenido, " + nombre;
                lblRolUsuario.Text = "Rol: Administrador General";
                lblDescripcion.Text = "Panel general para administrar usuarios, padrones, planchas, votaciones, resultados y reportes.";

                btnUsuarios.Visible = true;
                btnPadrones.Visible = true;
                btnVotaciones.Visible = true;
                btnPlanchas.Visible = true;
                btnResultados.Visible = true;
                btnReportes.Visible = true;
                btnIntegrantesPlancha.Visible = true;

                OrganizarBotonesAdminGeneral();
            }
            else if (usuarioActual.IdRol == 3)
            {
                lblManuAdmin.Text = "Bienvenido, " + nombre;
                lblRolUsuario.Text = "Rol: Administrador de Plancha";
                lblDescripcion.Text = "Panel limitado para consultar y administrar únicamente la información de tu plancha.";

                btnUsuarios.Text = "Usuarios de mi Plancha";
                btnIntegrantesPlancha.Text = "Integrantes de mi Plancha";
                btnResultados.Text = "Resultados";
                btnCerrarSesion.Text = "Cerrar sesión";

                btnUsuarios.Visible = true;
                btnResultados.Visible = true;
                btnIntegrantesPlancha.Visible = true;

                btnPadrones.Visible = false;
                btnVotaciones.Visible = false;
                btnPlanchas.Visible = false;
                btnReportes.Visible = false;

                OrganizarBotonesAdminPlancha();
            }
        }

        private void btnPlanchas_Click(object sender, EventArgs e)
        {
            FrmPlanchas frm = new FrmPlanchas();
            frm.ShowDialog();
        }

        private void btnCerrarSesion_Click(object sender, EventArgs e)
        {
            FrmLogin login = new FrmLogin();
            login.Show();
            this.Close();
        }

        private void btnReportes_Click(object sender, EventArgs e)
        {
            FrmReportes frm = new FrmReportes();
            frm.ShowDialog();
        }

        private void btnResultados_Click(object sender, EventArgs e)
        {
            FrmResultados frm = new FrmResultados();
            frm.ShowDialog();
        }

        private void btnVotaciones_Click(object sender, EventArgs e)
        {
            FrmVotaciones frm = new FrmVotaciones();
            frm.ShowDialog();
        }

        private void btnPadrones_Click(object sender, EventArgs e)
        {
            FrmPadrones frm = new FrmPadrones();
            frm.ShowDialog();
        }

        private void btnUsuarios_Click(object sender, EventArgs e)
        {
            FrmUsuarios frm = new FrmUsuarios(usuarioActual);
            frm.ShowDialog();
        }

        private void btnIntegrantesPlancha_Click(object sender, EventArgs e)
        {
            FrmIntegrantesPlancha frm = new FrmIntegrantesPlancha(usuarioActual);
            frm.ShowDialog();
        }

        private void lblManuAdmin_Click(object sender, EventArgs e)
        {

        }
    }
}