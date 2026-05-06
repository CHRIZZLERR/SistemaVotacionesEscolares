using System;
using System.Drawing;
using System.IO;
using System.Windows.Forms;
using Microsoft.Reporting.WinForms;
using SistemaVotaciones.BLL;

namespace SistemaVotaciones.UI
{
    public partial class FrmReportes : Form
    {
        private ReporteBLL bll = new ReporteBLL();

        private Panel panelPrincipal;
        private Label lblTituloNuevo;
        private Label lblSubtituloNuevo;

        private Button btnExportarPDF;
        private string nombreReporteActual = "";

        public FrmReportes()
        {
            InitializeComponent();
        }

        private void FrmReportes_Load(object sender, EventArgs e)
        {
            AplicarDiseno();
            CargarTiposReporte();
            reportViewer1.RefreshReport();
        }

        private void AplicarDiseno()
        {
            OcultarControlesViejos();

            this.Text = "Reportes - Sistema de Votaciones";
            this.StartPosition = FormStartPosition.CenterScreen;
            this.Size = new Size(1120, 720);
            this.FormBorderStyle = FormBorderStyle.FixedSingle;
            this.MaximizeBox = false;
            this.BackColor = Color.FromArgb(8, 18, 55);

            CrearPanelPrincipal();
            CrearEncabezado();
            ConfigurarControles();
            ConfigurarReportViewer();
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
            panelPrincipal.Size = new Size(1040, 625);
            panelPrincipal.BorderStyle = BorderStyle.None;
            this.Controls.Add(panelPrincipal);
            panelPrincipal.BringToFront();
        }

        private void CrearEncabezado()
        {
            Panel panelHeader = new Panel();
            panelHeader.BackColor = Color.FromArgb(10, 38, 95);
            panelHeader.Location = new Point(0, 0);
            panelHeader.Size = new Size(1040, 105);
            panelPrincipal.Controls.Add(panelHeader);

            lblTituloNuevo = new Label();
            lblTituloNuevo.Text = "Reportes del Sistema";
            lblTituloNuevo.Font = new Font("Segoe UI", 25, FontStyle.Bold);
            lblTituloNuevo.ForeColor = Color.White;
            lblTituloNuevo.BackColor = Color.Transparent;
            lblTituloNuevo.TextAlign = ContentAlignment.MiddleCenter;
            lblTituloNuevo.AutoSize = false;
            lblTituloNuevo.Location = new Point(20, 20);
            lblTituloNuevo.Size = new Size(1000, 45);
            panelHeader.Controls.Add(lblTituloNuevo);

            lblSubtituloNuevo = new Label();
            lblSubtituloNuevo.Text = "Genera y exporta reportes oficiales en formato PDF";
            lblSubtituloNuevo.Font = new Font("Segoe UI", 10, FontStyle.Bold);
            lblSubtituloNuevo.ForeColor = Color.FromArgb(255, 215, 90);
            lblSubtituloNuevo.BackColor = Color.Transparent;
            lblSubtituloNuevo.TextAlign = ContentAlignment.MiddleCenter;
            lblSubtituloNuevo.AutoSize = false;
            lblSubtituloNuevo.Location = new Point(20, 65);
            lblSubtituloNuevo.Size = new Size(1000, 25);
            panelHeader.Controls.Add(lblSubtituloNuevo);
        }

        private void ConfigurarControles()
        {
            panelPrincipal.Controls.Add(lblTipoReporte);
            panelPrincipal.Controls.Add(cmbTipoReporte);
            panelPrincipal.Controls.Add(btnGenerar);
            panelPrincipal.Controls.Add(btnCerrar);

            lblTipoReporte.Visible = true;
            cmbTipoReporte.Visible = true;
            btnGenerar.Visible = true;
            btnCerrar.Visible = true;

            lblTipoReporte.Text = "Tipo de reporte";
            lblTipoReporte.Font = new Font("Segoe UI", 11, FontStyle.Bold);
            lblTipoReporte.ForeColor = Color.FromArgb(10, 38, 95);
            lblTipoReporte.BackColor = Color.Transparent;
            lblTipoReporte.Location = new Point(35, 130);
            lblTipoReporte.Size = new Size(180, 28);

            cmbTipoReporte.Font = new Font("Segoe UI", 10, FontStyle.Regular);
            cmbTipoReporte.DropDownStyle = ComboBoxStyle.DropDownList;
            cmbTipoReporte.Location = new Point(35, 160);
            cmbTipoReporte.Size = new Size(360, 30);

            btnGenerar.Text = "Generar reporte";
            btnGenerar.Location = new Point(420, 153);
            btnGenerar.Size = new Size(170, 42);
            EstiloBoton(btnGenerar);

            btnExportarPDF = new Button();
            btnExportarPDF.Text = "Exportar PDF";
            btnExportarPDF.Location = new Point(610, 153);
            btnExportarPDF.Size = new Size(170, 42);
            btnExportarPDF.Enabled = false;
            btnExportarPDF.Click += btnExportarPDF_Click;
            EstiloBotonExportar(btnExportarPDF);
            panelPrincipal.Controls.Add(btnExportarPDF);

            btnCerrar.Text = "Cerrar";
            btnCerrar.Location = new Point(830, 153);
            btnCerrar.Size = new Size(170, 42);
            EstiloBotonCerrar(btnCerrar);
        }

        private void ConfigurarReportViewer()
        {
            panelPrincipal.Controls.Add(reportViewer1);

            reportViewer1.Visible = true;
            reportViewer1.Location = new Point(35, 220);
            reportViewer1.Size = new Size(965, 370);
            reportViewer1.BorderStyle = BorderStyle.FixedSingle;
            reportViewer1.BackColor = Color.White;

            reportViewer1.BringToFront();
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

        private void EstiloBotonExportar(Button boton)
        {
            boton.FlatStyle = FlatStyle.Flat;
            boton.FlatAppearance.BorderSize = 0;
            boton.BackColor = Color.FromArgb(22, 163, 74);
            boton.ForeColor = Color.White;
            boton.Font = new Font("Segoe UI", 10, FontStyle.Bold);
            boton.Cursor = Cursors.Hand;

            boton.MouseEnter += (s, e) =>
            {
                if (boton.Enabled)
                    boton.BackColor = Color.FromArgb(34, 197, 94);
            };

            boton.MouseLeave += (s, e) =>
            {
                if (boton.Enabled)
                    boton.BackColor = Color.FromArgb(22, 163, 74);
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

        private void CargarTiposReporte()
        {
            cmbTipoReporte.Items.Clear();
            cmbTipoReporte.Items.Add("Reporte general de votos");
            cmbTipoReporte.Items.Add("Reporte integrantes de plancha");
            cmbTipoReporte.Items.Add("Reporte plancha ganadora");
            cmbTipoReporte.Items.Add("Reporte general de usuarios");
            cmbTipoReporte.SelectedIndex = 0;
        }

        private void GenerarReporteGeneralVotos()
        {
            try
            {
                reportViewer1.Reset();
                reportViewer1.ProcessingMode = ProcessingMode.Local;

                string rutaReporte = Path.Combine(
                    Application.StartupPath,
                    "Reportes",
                    "ReporteGeneralVotos.rdlc"
                );

                if (!File.Exists(rutaReporte))
                {
                    MessageBox.Show("No se encontró el archivo del reporte:\n" + rutaReporte);
                    return;
                }

                reportViewer1.LocalReport.ReportPath = rutaReporte;

                ReportDataSource dataSource = new ReportDataSource(
                    "DataSetGeneralVotos",
                    bll.ReporteGeneralVotos()
                );

                reportViewer1.LocalReport.DataSources.Clear();
                reportViewer1.LocalReport.DataSources.Add(dataSource);

                reportViewer1.RefreshReport();

                nombreReporteActual = "ReporteGeneralVotos";
                btnExportarPDF.Enabled = true;
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error al generar el reporte general de votos:\n" + ex.Message);
            }
        }

        private void GenerarReporteIntegrantesPlancha()
        {
            try
            {
                reportViewer1.Reset();
                reportViewer1.ProcessingMode = ProcessingMode.Local;

                string rutaReporte = Path.Combine(
                    Application.StartupPath,
                    "Reportes",
                    "ReporteIntegrantesPlancha.rdlc"
                );

                if (!File.Exists(rutaReporte))
                {
                    MessageBox.Show("No se encontró el archivo del reporte:\n" + rutaReporte);
                    return;
                }

                reportViewer1.LocalReport.ReportPath = rutaReporte;

                ReportDataSource dataSource = new ReportDataSource(
                    "DataSetIntegrantesPlancha",
                    bll.ReporteIntegrantesPlancha()
                );

                reportViewer1.LocalReport.DataSources.Clear();
                reportViewer1.LocalReport.DataSources.Add(dataSource);

                reportViewer1.RefreshReport();

                nombreReporteActual = "ReporteIntegrantesPlancha";
                btnExportarPDF.Enabled = true;
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error al generar el reporte de integrantes de plancha:\n" + ex.Message);
            }
        }

        private void GenerarReportePlanchaGanadora()
        {
            try
            {
                reportViewer1.Reset();
                reportViewer1.ProcessingMode = ProcessingMode.Local;

                string rutaReporte = Path.Combine(
                    Application.StartupPath,
                    "Reportes",
                    "ReportePlanchaGanadora.rdlc"
                );

                if (!File.Exists(rutaReporte))
                {
                    MessageBox.Show("No se encontró el archivo del reporte:\n" + rutaReporte);
                    return;
                }

                reportViewer1.LocalReport.ReportPath = rutaReporte;

                ReportDataSource dataSource = new ReportDataSource(
                    "DataSetPlanchaGanadora",
                    bll.ReportePlanchaGanadora()
                );

                reportViewer1.LocalReport.DataSources.Clear();
                reportViewer1.LocalReport.DataSources.Add(dataSource);

                reportViewer1.RefreshReport();

                nombreReporteActual = "ReportePlanchaGanadora";
                btnExportarPDF.Enabled = true;
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error al generar el reporte de plancha ganadora:\n" + ex.Message);
            }
        }

        private void GenerarReporteUsuarios()
        {
            try
            {
                reportViewer1.Reset();
                reportViewer1.ProcessingMode = ProcessingMode.Local;

                string rutaReporte = Path.Combine(
                    Application.StartupPath,
                    "Reportes",
                    "ReporteUsuarios.rdlc"
                );

                if (!File.Exists(rutaReporte))
                {
                    MessageBox.Show("No se encontró el archivo del reporte:\n" + rutaReporte);
                    return;
                }

                reportViewer1.LocalReport.ReportPath = rutaReporte;

                ReportDataSource dataSource = new ReportDataSource(
                    "DataSetUsuarios",
                    bll.ReporteUsuarios()
                );

                reportViewer1.LocalReport.DataSources.Clear();
                reportViewer1.LocalReport.DataSources.Add(dataSource);

                reportViewer1.RefreshReport();

                nombreReporteActual = "ReporteGeneralUsuarios";
                btnExportarPDF.Enabled = true;
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error al generar el reporte general de usuarios:\n" + ex.Message);
            }
        }

        private void ExportarReportePDF()
        {
            try
            {
                if (string.IsNullOrWhiteSpace(nombreReporteActual))
                {
                    MessageBox.Show("Primero debe generar un reporte antes de exportarlo.");
                    return;
                }

                SaveFileDialog saveFileDialog = new SaveFileDialog();
                saveFileDialog.Filter = "Archivo PDF (*.pdf)|*.pdf";
                saveFileDialog.Title = "Guardar reporte como PDF";
                saveFileDialog.FileName = nombreReporteActual + "_" + DateTime.Now.ToString("yyyyMMdd_HHmmss") + ".pdf";

                if (saveFileDialog.ShowDialog() != DialogResult.OK)
                    return;

                string mimeType;
                string encoding;
                string fileNameExtension;
                string[] streams;
                Warning[] warnings;

                byte[] bytes = reportViewer1.LocalReport.Render(
                    "PDF",
                    null,
                    out mimeType,
                    out encoding,
                    out fileNameExtension,
                    out streams,
                    out warnings
                );

                File.WriteAllBytes(saveFileDialog.FileName, bytes);

                MessageBox.Show("Reporte exportado correctamente en PDF.");
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error al exportar el reporte a PDF:\n" + ex.Message);
            }
        }

        private void btnGenerar_Click(object sender, EventArgs e)
        {
            btnExportarPDF.Enabled = false;
            nombreReporteActual = "";

            if (cmbTipoReporte.Text == "Reporte general de votos")
            {
                GenerarReporteGeneralVotos();
            }
            else if (cmbTipoReporte.Text == "Reporte integrantes de plancha")
            {
                GenerarReporteIntegrantesPlancha();
            }
            else if (cmbTipoReporte.Text == "Reporte plancha ganadora")
            {
                GenerarReportePlanchaGanadora();
            }
            else if (cmbTipoReporte.Text == "Reporte general de usuarios")
            {
                GenerarReporteUsuarios();
            }
            else
            {
                MessageBox.Show("Debe seleccionar un tipo de reporte.");
            }
        }

        private void btnExportarPDF_Click(object sender, EventArgs e)
        {
            ExportarReportePDF();
        }

        private void btnCerrar_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void reportViewer1_Load(object sender, EventArgs e)
        {

        }

        private void cmbTipoReporte_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

        private void lblTipoReporte_Click(object sender, EventArgs e)
        {

        }

        private void lblTituloReporte_Click(object sender, EventArgs e)
        {

        }
    }
}