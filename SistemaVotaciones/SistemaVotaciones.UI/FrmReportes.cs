using System;
using System.IO;
using System.Windows.Forms;
using Microsoft.Reporting.WinForms;
using SistemaVotaciones.BLL;

namespace SistemaVotaciones.UI
{
    public partial class FrmReportes : Form
    {
        private ReporteBLL bll = new ReporteBLL();

        public FrmReportes()
        {
            InitializeComponent();
        }

        private void FrmReportes_Load(object sender, EventArgs e)
        {
            CargarTiposReporte();
            reportViewer1.RefreshReport();
        }

        private void CargarTiposReporte()
        {
            cmbTipoReporte.Items.Clear();
            cmbTipoReporte.Items.Add("Reporte general de votos");
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
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error al generar el reporte:\n" + ex.Message);
            }
        }

        private void reportViewer1_Load(object sender, EventArgs e)
        {

        }

        private void btnGenerar_Click(object sender, EventArgs e)
        {
            if (cmbTipoReporte.Text == "Reporte general de votos")
            {
                GenerarReporteGeneralVotos();
            }
            else
            {
                MessageBox.Show("Debe seleccionar un tipo de reporte.");
            }
        }

        private void btnCerrar_Click(object sender, EventArgs e)
        {
            this.Close();
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