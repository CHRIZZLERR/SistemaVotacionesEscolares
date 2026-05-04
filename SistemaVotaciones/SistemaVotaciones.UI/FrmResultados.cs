using System;
using System.Windows.Forms;
using SistemaVotaciones.BLL;

namespace SistemaVotaciones.UI
{
    public partial class FrmResultados : Form
    {
        private ResultadoBLL bll = new ResultadoBLL();

        public FrmResultados()
        {
            InitializeComponent();
            CargarResultados();
        }

        private void CargarResultados()
        {
            int totalVotos = bll.TotalVotos();
            int votosNulos = bll.TotalVotosNulos();
            int totalVotantes = bll.TotalVotantes();

            decimal participacion = 0;

            if (totalVotantes > 0)
            {
                participacion = (totalVotos * 100m) / totalVotantes;
            }

            lblTotalVotos.Text = "Total de votos: " + totalVotos;
            lblVotosNulos.Text = "Votos nulos: " + votosNulos;
            lblParticipacion.Text = "Participación: " + participacion.ToString("0.00") + "%";
            lblGanadora.Text = "Plancha ganadora: " + bll.PlanchaGanadora();

            dgvResultados.DataSource = bll.ResultadosPorPlancha();
        }

        private void dgvResultados_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }

        private void btnActualizar_Click(object sender, EventArgs e)
        {
            CargarResultados();
        }

        private void btnCerrar_Click(object sender, EventArgs e)
        {
            this.Close();
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