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

        public FrmInfoVotacion()
        {
            InitializeComponent();
        }

        public FrmInfoVotacion(Usuario usuario)
        {
            InitializeComponent();
            usuarioActual = usuario;

            ConfigurarLabelsFijos();
            CargarInformacion();

            // Esto se ejecuta cuando el formulario ya se mostró,
            // así los valores se colocan bien después de los dos puntos.
            this.Shown += FrmInfoVotacion_Shown;
        }

        private void FrmInfoVotacion_Shown(object sender, EventArgs e)
        {
            AlinearValores();
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

            lblNombreVotacion.AutoSize = true;
            lblPadron.AutoSize = true;
            lblEstado.AutoSize = true;
            lblFechaInicio.AutoSize = true;
            lblFechaFin.AutoSize = true;
            lblTiempoRestante.AutoSize = true;
            lblCantidadPlanchas.AutoSize = true;
            lblEstadoVoto.AutoSize = true;

            lblValorVotacion.AutoSize = true;
            lblValorPadron.AutoSize = true;
            lblValorEstado.AutoSize = true;
            lblValorFechaInicio.AutoSize = true;
            lblValorFechaFin.AutoSize = true;
            lblValorTiempoRestante.AutoSize = true;
            lblValorCantidadPlanchas.AutoSize = true;
            lblValorEstadoVoto.AutoSize = true;

            lblNombreVotacion.Font = new Font(lblNombreVotacion.Font, FontStyle.Bold);
            lblPadron.Font = new Font(lblPadron.Font, FontStyle.Bold);
            lblEstado.Font = new Font(lblEstado.Font, FontStyle.Bold);
            lblFechaInicio.Font = new Font(lblFechaInicio.Font, FontStyle.Bold);
            lblFechaFin.Font = new Font(lblFechaFin.Font, FontStyle.Bold);
            lblTiempoRestante.Font = new Font(lblTiempoRestante.Font, FontStyle.Bold);
            lblCantidadPlanchas.Font = new Font(lblCantidadPlanchas.Font, FontStyle.Bold);
            lblEstadoVoto.Font = new Font(lblEstadoVoto.Font, FontStyle.Bold);
        }

        private void AlinearValores()
        {
            int espacio = 8;

            lblValorVotacion.Left = lblNombreVotacion.Right + espacio;
            lblValorVotacion.Top = lblNombreVotacion.Top;

            lblValorPadron.Left = lblPadron.Right + espacio;
            lblValorPadron.Top = lblPadron.Top;

            lblValorEstado.Left = lblEstado.Right + espacio;
            lblValorEstado.Top = lblEstado.Top;

            lblValorFechaInicio.Left = lblFechaInicio.Right + espacio;
            lblValorFechaInicio.Top = lblFechaInicio.Top;

            lblValorFechaFin.Left = lblFechaFin.Right + espacio;
            lblValorFechaFin.Top = lblFechaFin.Top;

            lblValorTiempoRestante.Left = lblTiempoRestante.Right + espacio;
            lblValorTiempoRestante.Top = lblTiempoRestante.Top;

            lblValorCantidadPlanchas.Left = lblCantidadPlanchas.Right + espacio;
            lblValorCantidadPlanchas.Top = lblCantidadPlanchas.Top;

            lblValorEstadoVoto.Left = lblEstadoVoto.Right + espacio;
            lblValorEstadoVoto.Top = lblEstadoVoto.Top;
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

                lblValorTiempoRestante.Text = "La votación aún no inicia. Faltan " +
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

        private void lblNombreVotacion_Click(object sender, EventArgs e)
        {

        }

        private void lblEstadoVoto_Click(object sender, EventArgs e)
        {

        }

        private void lblCantidadPlanchas_Click(object sender, EventArgs e)
        {

        }

        private void lblTiempoRestante_Click(object sender, EventArgs e)
        {

        }

        private void lblFechaFin_Click(object sender, EventArgs e)
        {

        }

        private void lblFechaInicio_Click(object sender, EventArgs e)
        {

        }

        private void lblEstado_Click(object sender, EventArgs e)
        {

        }

        private void lblPadron_Click(object sender, EventArgs e)
        {

        }

        private void lblTitulo_Click(object sender, EventArgs e)
        {

        }

        private void lblValorCantidadPlanchas_Click(object sender, EventArgs e)
        {

        }

        private void lblValorTiempoRestante_Click(object sender, EventArgs e)
        {

        }

        private void lblValorFechaFin_Click(object sender, EventArgs e)
        {

        }

        private void lblValorFechaInicio_Click(object sender, EventArgs e)
        {

        }

        private void lblValorEstado_Click(object sender, EventArgs e)
        {

        }

        private void lblValorPadron_Click(object sender, EventArgs e)
        {

        }

        private void lblValorVotacion_Click(object sender, EventArgs e)
        {

        }

        private void lblValorEstadoVoto_Click(object sender, EventArgs e)
        {

        }
    }
}