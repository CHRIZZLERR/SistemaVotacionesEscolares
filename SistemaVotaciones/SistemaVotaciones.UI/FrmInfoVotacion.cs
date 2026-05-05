using System;
using System.Data;
using System.Drawing;
using System.Windows.Forms;
using SistemaVotaciones.BLL;
using SistemaVotaciones.Entidades;

namespace SistemaVotaciones.UI
{
    public partial class FrmInfoVotacion : Form
    {
        private Usuario usuarioActual;
        private InfoVotacionBLL bll = new InfoVotacionBLL();

        private Panel panelPrincipal;
        private Label lblTituloNuevo;
        private Label lblSubtituloNuevo;

        public FrmInfoVotacion()
        {
            InitializeComponent();
        }

        public FrmInfoVotacion(Usuario usuario)
        {
            InitializeComponent();
            usuarioActual = usuario;
        }

        private void FrmInfoVotacion_Load(object sender, EventArgs e)
        {
            AplicarDiseno();
            ConfigurarLabelsFijos();
            CargarInformacion();
        }

        private void AplicarDiseno()
        {
            OcultarTitulosViejos();

            this.Text = "Información de Votación - Sistema de Votaciones";
            this.StartPosition = FormStartPosition.CenterScreen;
            this.Size = new Size(900, 650);
            this.FormBorderStyle = FormBorderStyle.FixedSingle;
            this.MaximizeBox = false;
            this.BackColor = Color.FromArgb(8, 18, 55);

            CrearPanelPrincipal();
            CrearEncabezado();
            ConfigurarLabels();
            ConfigurarBoton();
        }

        private void OcultarTitulosViejos()
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
            panelPrincipal.Size = new Size(810, 555);
            panelPrincipal.BorderStyle = BorderStyle.None;
            this.Controls.Add(panelPrincipal);
            panelPrincipal.BringToFront();
        }

        private void CrearEncabezado()
        {
            Panel panelHeader = new Panel();
            panelHeader.BackColor = Color.FromArgb(10, 38, 95);
            panelHeader.Location = new Point(0, 0);
            panelHeader.Size = new Size(810, 105);
            panelPrincipal.Controls.Add(panelHeader);

            lblTituloNuevo = new Label();
            lblTituloNuevo.Text = "Información de Votación";
            lblTituloNuevo.Font = new Font("Segoe UI", 25, FontStyle.Bold);
            lblTituloNuevo.ForeColor = Color.White;
            lblTituloNuevo.BackColor = Color.Transparent;
            lblTituloNuevo.TextAlign = ContentAlignment.MiddleCenter;
            lblTituloNuevo.AutoSize = false;
            lblTituloNuevo.Location = new Point(20, 20);
            lblTituloNuevo.Size = new Size(770, 45);
            panelHeader.Controls.Add(lblTituloNuevo);

            lblSubtituloNuevo = new Label();
            lblSubtituloNuevo.Text = "Consulta el estado actual de tu proceso electoral";
            lblSubtituloNuevo.Font = new Font("Segoe UI", 10, FontStyle.Bold);
            lblSubtituloNuevo.ForeColor = Color.FromArgb(255, 215, 90);
            lblSubtituloNuevo.BackColor = Color.Transparent;
            lblSubtituloNuevo.TextAlign = ContentAlignment.MiddleCenter;
            lblSubtituloNuevo.AutoSize = false;
            lblSubtituloNuevo.Location = new Point(20, 65);
            lblSubtituloNuevo.Size = new Size(770, 25);
            panelHeader.Controls.Add(lblSubtituloNuevo);
        }

        private void ConfigurarLabels()
        {
            AgregarLabelsAlPanel();

            int xLabel = 70;
            int xValor = 315;
            int y = 140;
            int espacio = 45;

            ConfigurarLabelTitulo(lblNombreVotacion, "Votación:");
            ConfigurarLabelValor(lblValorVotacion);

            ConfigurarLabelTitulo(lblPadron, "Padrón:");
            ConfigurarLabelValor(lblValorPadron);

            ConfigurarLabelTitulo(lblEstado, "Estado:");
            ConfigurarLabelValor(lblValorEstado);

            ConfigurarLabelTitulo(lblFechaInicio, "Fecha inicio:");
            ConfigurarLabelValor(lblValorFechaInicio);

            ConfigurarLabelTitulo(lblFechaFin, "Fecha fin:");
            ConfigurarLabelValor(lblValorFechaFin);

            ConfigurarLabelTitulo(lblTiempoRestante, "Tiempo restante:");
            ConfigurarLabelValor(lblValorTiempoRestante);

            ConfigurarLabelTitulo(lblCantidadPlanchas, "Planchas disponibles:");
            ConfigurarLabelValor(lblValorCantidadPlanchas);

            ConfigurarLabelTitulo(lblEstadoVoto, "Estado de voto:");
            ConfigurarLabelValor(lblValorEstadoVoto);

            PosicionarFila(lblNombreVotacion, lblValorVotacion, xLabel, xValor, y);
            PosicionarFila(lblPadron, lblValorPadron, xLabel, xValor, y + espacio);
            PosicionarFila(lblEstado, lblValorEstado, xLabel, xValor, y + espacio * 2);
            PosicionarFila(lblFechaInicio, lblValorFechaInicio, xLabel, xValor, y + espacio * 3);
            PosicionarFila(lblFechaFin, lblValorFechaFin, xLabel, xValor, y + espacio * 4);
            PosicionarFila(lblTiempoRestante, lblValorTiempoRestante, xLabel, xValor, y + espacio * 5);
            PosicionarFila(lblCantidadPlanchas, lblValorCantidadPlanchas, xLabel, xValor, y + espacio * 6);
            PosicionarFila(lblEstadoVoto, lblValorEstadoVoto, xLabel, xValor, y + espacio * 7);
        }

        private void AgregarLabelsAlPanel()
        {
            panelPrincipal.Controls.Add(lblNombreVotacion);
            panelPrincipal.Controls.Add(lblValorVotacion);

            panelPrincipal.Controls.Add(lblPadron);
            panelPrincipal.Controls.Add(lblValorPadron);

            panelPrincipal.Controls.Add(lblEstado);
            panelPrincipal.Controls.Add(lblValorEstado);

            panelPrincipal.Controls.Add(lblFechaInicio);
            panelPrincipal.Controls.Add(lblValorFechaInicio);

            panelPrincipal.Controls.Add(lblFechaFin);
            panelPrincipal.Controls.Add(lblValorFechaFin);

            panelPrincipal.Controls.Add(lblTiempoRestante);
            panelPrincipal.Controls.Add(lblValorTiempoRestante);

            panelPrincipal.Controls.Add(lblCantidadPlanchas);
            panelPrincipal.Controls.Add(lblValorCantidadPlanchas);

            panelPrincipal.Controls.Add(lblEstadoVoto);
            panelPrincipal.Controls.Add(lblValorEstadoVoto);
        }

        private void PosicionarFila(Label titulo, Label valor, int xLabel, int xValor, int y)
        {
            titulo.Visible = true;
            valor.Visible = true;

            titulo.Location = new Point(xLabel, y);
            titulo.Size = new Size(230, 30);

            valor.Location = new Point(xValor, y);
            valor.Size = new Size(430, 30);
        }

        private void ConfigurarLabelTitulo(Label label, string texto)
        {
            label.Text = texto;
            label.Font = new Font("Segoe UI", 11, FontStyle.Bold);
            label.ForeColor = Color.FromArgb(10, 38, 95);
            label.BackColor = Color.Transparent;
            label.TextAlign = ContentAlignment.MiddleLeft;
            label.AutoSize = false;
        }

        private void ConfigurarLabelValor(Label label)
        {
            label.Font = new Font("Segoe UI", 11, FontStyle.Regular);
            label.ForeColor = Color.FromArgb(40, 50, 70);
            label.BackColor = Color.Transparent;
            label.TextAlign = ContentAlignment.MiddleLeft;
            label.AutoSize = false;
        }

        private void ConfigurarBoton()
        {
            panelPrincipal.Controls.Add(btnCerrar);

            btnCerrar.Visible = true;
            btnCerrar.Text = "Cerrar";
            btnCerrar.Location = new Point(560, 485);
            btnCerrar.Size = new Size(180, 45);

            EstiloBotonCerrar(btnCerrar);
            btnCerrar.BringToFront();
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

        private void ConfigurarLabelsFijos()
        {
            lblNombreVotacion.Text = "Votación:";
            lblPadron.Text = "Padrón:";
            lblEstado.Text = "Estado:";
            lblFechaInicio.Text = "Fecha inicio:";
            lblFechaFin.Text = "Fecha fin:";
            lblTiempoRestante.Text = "Tiempo restante:";
            lblCantidadPlanchas.Text = "Planchas disponibles:";
            lblEstadoVoto.Text = "Estado de voto:";
        }

        private void CargarInformacion()
        {
            if (usuarioActual == null)
            {
                MessageBox.Show("No se recibió información del usuario.");
                this.Close();
                return;
            }

            DataTable info = bll.ObtenerInfoVotacionPorPadron(usuarioActual.IdPadron);

            if (info.Rows.Count == 0)
            {
                lblValorVotacion.Text = "No hay votación registrada";
                lblValorPadron.Text = "No disponible";
                lblValorEstado.Text = "No disponible";
                lblValorFechaInicio.Text = "No disponible";
                lblValorFechaFin.Text = "No disponible";
                lblValorTiempoRestante.Text = "No disponible";
                lblValorCantidadPlanchas.Text = "0";
                lblValorEstadoVoto.Text = usuarioActual.YaVoto ? "Ya votó" : "No ha votado";

                CambiarColorEstado("No disponible");
                CambiarColorEstadoVoto();
                return;
            }

            DataRow row = info.Rows[0];

            string nombreVotacion = row["NombreVotacion"].ToString();
            string nombrePadron = row["NombrePadron"].ToString();
            string estado = row["EstadoVotacion"].ToString();
            DateTime fechaInicio = Convert.ToDateTime(row["FechaInicio"]);
            DateTime fechaFin = Convert.ToDateTime(row["FechaFin"]);
            int cantidadPlanchas = Convert.ToInt32(row["CantidadPlanchas"]);

            lblValorVotacion.Text = nombreVotacion;
            lblValorPadron.Text = nombrePadron;
            lblValorEstado.Text = estado;
            lblValorFechaInicio.Text = fechaInicio.ToString("dd/MM/yyyy hh:mm tt");
            lblValorFechaFin.Text = fechaFin.ToString("dd/MM/yyyy hh:mm tt");
            lblValorCantidadPlanchas.Text = cantidadPlanchas.ToString();

            if (DateTime.Now < fechaInicio)
            {
                TimeSpan falta = fechaInicio - DateTime.Now;

                lblValorTiempoRestante.Text = "Aún no inicia. Faltan " +
                                               falta.Hours + " horas y " +
                                               falta.Minutes + " minutos";
            }
            else if (DateTime.Now > fechaFin)
            {
                lblValorTiempoRestante.Text = "La votación ya terminó";
            }
            else
            {
                TimeSpan restante = fechaFin - DateTime.Now;

                lblValorTiempoRestante.Text = restante.Hours + " horas y " +
                                               restante.Minutes + " minutos";
            }

            lblValorEstadoVoto.Text = usuarioActual.YaVoto ? "Ya votó" : "No ha votado";

            CambiarColorEstado(estado);
            CambiarColorEstadoVoto();
        }

        private void CambiarColorEstado(string estado)
        {
            if (estado == "Abierta")
            {
                lblValorEstado.ForeColor = Color.Green;
            }
            else if (estado == "Cerrada")
            {
                lblValorEstado.ForeColor = Color.Red;
            }
            else if (estado == "Pendiente")
            {
                lblValorEstado.ForeColor = Color.DarkOrange;
            }
            else
            {
                lblValorEstado.ForeColor = Color.Black;
            }
        }

        private void CambiarColorEstadoVoto()
        {
            if (usuarioActual != null && usuarioActual.YaVoto)
            {
                lblValorEstadoVoto.ForeColor = Color.Green;
            }
            else
            {
                lblValorEstadoVoto.ForeColor = Color.Red;
            }
        }

        private void btnCerrar_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void lblNombreVotacion_Click(object sender, EventArgs e) { }

        private void lblEstadoVoto_Click(object sender, EventArgs e) { }

        private void lblCantidadPlanchas_Click(object sender, EventArgs e) { }

        private void lblTiempoRestante_Click(object sender, EventArgs e) { }

        private void lblFechaFin_Click(object sender, EventArgs e) { }

        private void lblFechaInicio_Click(object sender, EventArgs e) { }

        private void lblEstado_Click(object sender, EventArgs e) { }

        private void lblPadron_Click(object sender, EventArgs e) { }

        private void lblTitulo_Click(object sender, EventArgs e) { }

        private void lblValorCantidadPlanchas_Click(object sender, EventArgs e) { }

        private void lblValorTiempoRestante_Click(object sender, EventArgs e) { }

        private void lblValorFechaFin_Click(object sender, EventArgs e) { }

        private void lblValorFechaInicio_Click(object sender, EventArgs e) { }

        private void lblValorEstado_Click(object sender, EventArgs e) { }

        private void lblValorPadron_Click(object sender, EventArgs e) { }

        private void lblValorVotacion_Click(object sender, EventArgs e) { }

        private void lblValorEstadoVoto_Click(object sender, EventArgs e) { }
    }
}