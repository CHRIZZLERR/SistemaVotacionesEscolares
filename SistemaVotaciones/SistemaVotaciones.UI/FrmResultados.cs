using System;
using System.Data;
using System.Drawing;
using System.Windows.Forms;
using System.Windows.Forms.DataVisualization.Charting;
using SistemaVotaciones.BLL;
using SistemaVotaciones.Entidades;

namespace SistemaVotaciones.UI
{
    public partial class FrmResultados : Form
    {
        private ResultadoBLL bll = new ResultadoBLL();
        private Usuario usuarioActual;

        private Panel panelPrincipal;
        private Label lblTituloNuevo;
        private Label lblSubtitulo;

        private Panel cardTotal;
        private Panel cardNulos;
        private Panel cardParticipacion;
        private Panel cardGanadora;

        private Label lblCardTotalTitulo;
        private Label lblCardTotalValor;

        private Label lblCardNulosTitulo;
        private Label lblCardNulosValor;

        private Label lblCardParticipacionTitulo;
        private Label lblCardParticipacionValor;

        private Label lblCardGanadoraTitulo;
        private Label lblCardGanadoraValor;

        private Chart chartResultados;

        public FrmResultados()
        {
            InitializeComponent();
        }

        public FrmResultados(Usuario usuario)
        {
            InitializeComponent();
            usuarioActual = usuario;
        }

        private void FrmResultados_Load(object sender, EventArgs e)
        {
            AplicarDiseno();
            CargarResultados();
        }

        private void AplicarDiseno()
        {
            OcultarControlesViejos();

            this.Text = "Resultados - Sistema de Votaciones";
            this.StartPosition = FormStartPosition.CenterScreen;
            this.Size = new Size(1050, 670);
            this.FormBorderStyle = FormBorderStyle.FixedSingle;
            this.MaximizeBox = false;
            this.BackColor = Color.FromArgb(8, 18, 55);

            CrearPanelPrincipal();
            CrearEncabezado();
            CrearTarjetas();
            ConfigurarTabla();
            CrearGrafico();
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
            panelPrincipal.Size = new Size(960, 585);
            panelPrincipal.BorderStyle = BorderStyle.None;
            this.Controls.Add(panelPrincipal);
            panelPrincipal.BringToFront();
        }

        private void CrearEncabezado()
        {
            Panel panelHeader = new Panel();
            panelHeader.BackColor = Color.FromArgb(10, 38, 95);
            panelHeader.Location = new Point(0, 0);
            panelHeader.Size = new Size(960, 105);
            panelPrincipal.Controls.Add(panelHeader);

            lblTituloNuevo = new Label();
            lblTituloNuevo.Text = "Resultados Electorales";
            lblTituloNuevo.Font = new Font("Segoe UI", 25, FontStyle.Bold);
            lblTituloNuevo.ForeColor = Color.White;
            lblTituloNuevo.BackColor = Color.Transparent;
            lblTituloNuevo.TextAlign = ContentAlignment.MiddleCenter;
            lblTituloNuevo.AutoSize = false;
            lblTituloNuevo.Location = new Point(20, 20);
            lblTituloNuevo.Size = new Size(920, 45);
            panelHeader.Controls.Add(lblTituloNuevo);

            lblSubtitulo = new Label();
            lblSubtitulo.Text = "Resumen general de participación y votos por plancha";
            lblSubtitulo.Font = new Font("Segoe UI", 10, FontStyle.Bold);
            lblSubtitulo.ForeColor = Color.FromArgb(255, 215, 90);
            lblSubtitulo.BackColor = Color.Transparent;
            lblSubtitulo.TextAlign = ContentAlignment.MiddleCenter;
            lblSubtitulo.AutoSize = false;
            lblSubtitulo.Location = new Point(20, 65);
            lblSubtitulo.Size = new Size(920, 25);
            panelHeader.Controls.Add(lblSubtitulo);
        }

        private void CrearTarjetas()
        {
            cardTotal = CrearCard(new Point(30, 125), new Size(205, 85));
            cardNulos = CrearCard(new Point(260, 125), new Size(205, 85));
            cardParticipacion = CrearCard(new Point(490, 125), new Size(205, 85));
            cardGanadora = CrearCard(new Point(720, 125), new Size(205, 85));

            lblCardTotalTitulo = CrearLabelCardTitulo("Total de votos");
            lblCardTotalValor = CrearLabelCardValor("0");

            lblCardNulosTitulo = CrearLabelCardTitulo("Votos nulos");
            lblCardNulosValor = CrearLabelCardValor("0");

            lblCardParticipacionTitulo = CrearLabelCardTitulo("Participación");
            lblCardParticipacionValor = CrearLabelCardValor("0.00%");

            lblCardGanadoraTitulo = CrearLabelCardTitulo("Ganadora");
            lblCardGanadoraValor = CrearLabelCardValor("Ninguna");

            cardTotal.Controls.Add(lblCardTotalTitulo);
            cardTotal.Controls.Add(lblCardTotalValor);

            cardNulos.Controls.Add(lblCardNulosTitulo);
            cardNulos.Controls.Add(lblCardNulosValor);

            cardParticipacion.Controls.Add(lblCardParticipacionTitulo);
            cardParticipacion.Controls.Add(lblCardParticipacionValor);

            cardGanadora.Controls.Add(lblCardGanadoraTitulo);
            cardGanadora.Controls.Add(lblCardGanadoraValor);
        }

        private Panel CrearCard(Point location, Size size)
        {
            Panel panel = new Panel();
            panel.BackColor = Color.White;
            panel.Location = location;
            panel.Size = size;
            panel.BorderStyle = BorderStyle.FixedSingle;
            panelPrincipal.Controls.Add(panel);
            return panel;
        }

        private Label CrearLabelCardTitulo(string texto)
        {
            Label label = new Label();
            label.Text = texto;
            label.Font = new Font("Segoe UI", 10, FontStyle.Bold);
            label.ForeColor = Color.FromArgb(80, 90, 110);
            label.TextAlign = ContentAlignment.MiddleCenter;
            label.AutoSize = false;
            label.Location = new Point(5, 10);
            label.Size = new Size(190, 25);
            return label;
        }

        private Label CrearLabelCardValor(string texto)
        {
            Label label = new Label();
            label.Text = texto;
            label.Font = new Font("Segoe UI", 15, FontStyle.Bold);
            label.ForeColor = Color.FromArgb(10, 38, 95);
            label.TextAlign = ContentAlignment.MiddleCenter;
            label.AutoSize = false;
            label.Location = new Point(5, 35);
            label.Size = new Size(190, 42);
            return label;
        }

        private void ConfigurarTabla()
        {
            panelPrincipal.Controls.Add(dgvResultados);

            dgvResultados.Visible = true;
            dgvResultados.Location = new Point(30, 235);
            dgvResultados.Size = new Size(430, 255);
            dgvResultados.BackgroundColor = Color.White;
            dgvResultados.BorderStyle = BorderStyle.FixedSingle;

            dgvResultados.EnableHeadersVisualStyles = false;
            dgvResultados.ColumnHeadersDefaultCellStyle.BackColor = Color.FromArgb(10, 38, 95);
            dgvResultados.ColumnHeadersDefaultCellStyle.ForeColor = Color.White;
            dgvResultados.ColumnHeadersDefaultCellStyle.Font = new Font("Segoe UI", 10, FontStyle.Bold);

            dgvResultados.DefaultCellStyle.Font = new Font("Segoe UI", 10, FontStyle.Regular);
            dgvResultados.DefaultCellStyle.SelectionBackColor = Color.FromArgb(21, 101, 192);
            dgvResultados.DefaultCellStyle.SelectionForeColor = Color.White;

            dgvResultados.AllowUserToAddRows = false;
            dgvResultados.ReadOnly = true;
            dgvResultados.SelectionMode = DataGridViewSelectionMode.FullRowSelect;
            dgvResultados.MultiSelect = false;
            dgvResultados.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;
        }

        private void CrearGrafico()
        {
            chartResultados = new Chart();
            chartResultados.Location = new Point(490, 235);
            chartResultados.Size = new Size(435, 255);
            chartResultados.BackColor = Color.White;
            chartResultados.BorderlineColor = Color.LightGray;
            chartResultados.BorderlineDashStyle = ChartDashStyle.Solid;
            chartResultados.BorderlineWidth = 1;

            ChartArea area = new ChartArea("AreaResultados");
            area.BackColor = Color.White;
            area.AxisX.LabelStyle.Font = new Font("Segoe UI", 8, FontStyle.Regular);
            area.AxisY.LabelStyle.Font = new Font("Segoe UI", 8, FontStyle.Regular);
            area.AxisX.MajorGrid.Enabled = false;
            area.AxisY.MajorGrid.LineColor = Color.LightGray;
            area.AxisY.Title = "Votos";
            area.AxisY.TitleFont = new Font("Segoe UI", 9, FontStyle.Bold);

            chartResultados.ChartAreas.Add(area);

            Series serie = new Series("Votos por plancha");
            serie.ChartType = SeriesChartType.Column;
            serie.ChartArea = "AreaResultados";
            serie.IsValueShownAsLabel = true;
            serie.Font = new Font("Segoe UI", 9, FontStyle.Bold);
            serie.Color = Color.FromArgb(21, 101, 192);

            chartResultados.Series.Add(serie);

            Title titulo = new Title("Votos por plancha");
            titulo.Font = new Font("Segoe UI", 12, FontStyle.Bold);
            titulo.ForeColor = Color.FromArgb(10, 38, 95);

            chartResultados.Titles.Add(titulo);

            panelPrincipal.Controls.Add(chartResultados);
        }

        private void ConfigurarBotones()
        {
            panelPrincipal.Controls.Add(btnActualizar);
            panelPrincipal.Controls.Add(btnCerrar);

            btnActualizar.Visible = true;
            btnCerrar.Visible = true;

            btnActualizar.Text = "Actualizar";
            btnCerrar.Text = "Cerrar";

            EstiloBoton(btnActualizar);
            EstiloBotonCerrar(btnCerrar);

            btnActualizar.Location = new Point(30, 515);
            btnActualizar.Size = new Size(180, 45);

            btnCerrar.Location = new Point(745, 515);
            btnCerrar.Size = new Size(180, 45);

            btnActualizar.BringToFront();
            btnCerrar.BringToFront();
        }

        private void EstiloBoton(Button boton)
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

        private void CargarResultados()
        {
            int totalVotos = bll.TotalVotos(usuarioActual);
            int votosNulos = bll.TotalVotosNulos(usuarioActual);
            int totalVotantes = bll.TotalVotantes();

            decimal participacion = 0;

            if (totalVotantes > 0)
            {
                participacion = (totalVotos * 100m) / totalVotantes;
            }

            string ganadora = bll.PlanchaGanadora(usuarioActual);

            lblCardTotalValor.Text = totalVotos.ToString();
            lblCardNulosValor.Text = votosNulos.ToString();
            lblCardParticipacionValor.Text = participacion.ToString("0.00") + "%";
            lblCardGanadoraValor.Text = ganadora;

            DataTable tabla = bll.ResultadosPorPlancha(usuarioActual);
            dgvResultados.DataSource = tabla;

            CargarGrafico(tabla);
        }

        private void CargarGrafico(DataTable tabla)
        {
            chartResultados.Series["Votos por plancha"].Points.Clear();

            foreach (DataRow row in tabla.Rows)
            {
                string plancha = row["Plancha"].ToString();
                int votos = Convert.ToInt32(row["Votos"]);

                int punto = chartResultados.Series["Votos por plancha"].Points.AddXY(plancha, votos);

                chartResultados.Series["Votos por plancha"].Points[punto].AxisLabel = AcortarTexto(plancha, 18);
            }
        }

        private string AcortarTexto(string texto, int limite)
        {
            if (string.IsNullOrWhiteSpace(texto))
                return "";

            if (texto.Length <= limite)
                return texto;

            return texto.Substring(0, limite) + "...";
        }

        private void btnActualizar_Click(object sender, EventArgs e)
        {
            CargarResultados();
        }

        private void btnCerrar_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void dgvResultados_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }

        private void lblGanadora_Click(object sender, EventArgs e)
        {

        }

        private void lblParticipacion_Click(object sender, EventArgs e)
        {

        }

        private void lblVotosNulos_Click(object sender, EventArgs e)
        {

        }

        private void lblTotalVotos_Click(object sender, EventArgs e)
        {

        }
    }
}