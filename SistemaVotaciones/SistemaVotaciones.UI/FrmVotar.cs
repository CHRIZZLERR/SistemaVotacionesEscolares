using System;
using System.Data;
using System.Windows.Forms;
using SistemaVotaciones.BLL;
using SistemaVotaciones.Entidades;

namespace SistemaVotaciones.UI
{
    public partial class FrmVotar : Form
    {
        private Usuario usuarioActual;
        private VotoBLL bll = new VotoBLL();
        private int idVotacionActual = 0;

        public FrmVotar()
        {
            InitializeComponent();
        }

        public FrmVotar(Usuario usuario)
        {
            InitializeComponent();
            usuarioActual = usuario;

            CargarDatosVotacion();
        }

        private void CargarDatosVotacion()
        {
            if (usuarioActual == null)
            {
                MessageBox.Show("No se recibió información del usuario.");
                this.Close();
                return;
            }

            if (usuarioActual.YaVoto)
            {
                lblEstadoVotacion.Text = "Ya usted votó";
                cmbPlanchas.Enabled = false;
                btnVotar.Enabled = false;
                btnVotoNulo.Enabled = false;
                return;
            }

            DataTable votacion = bll.ObtenerVotacionAbiertaPorPadron(usuarioActual.IdPadron);

            if (votacion.Rows.Count == 0)
            {
                lblEstadoVotacion.Text = "No hay votación abierta para su padrón";
                cmbPlanchas.Enabled = false;
                btnVotar.Enabled = false;
                btnVotoNulo.Enabled = false;
                return;
            }

            idVotacionActual = Convert.ToInt32(votacion.Rows[0]["IdVotacion"]);
            lblEstadoVotacion.Text = "Abierta";

            CargarPlanchas();
        }

        private void CargarPlanchas()
        {
            DataTable planchas = bll.ListarPlanchasPorPadron(usuarioActual.IdPadron);

            cmbPlanchas.DataSource = planchas;
            cmbPlanchas.DisplayMember = "NombrePlancha";
            cmbPlanchas.ValueMember = "IdPlancha";

            if (planchas.Rows.Count == 0)
            {
                MessageBox.Show("No hay planchas disponibles para su padrón.");
                btnVotar.Enabled = false;
            }
        }

        private void CargarIntegrantesPlancha()
        {
            if (cmbPlanchas.SelectedValue == null)
                return;

            if (cmbPlanchas.SelectedValue is DataRowView)
                return;

            int idPlancha = Convert.ToInt32(cmbPlanchas.SelectedValue);

            dgvIntegrantes.DataSource = bll.ListarIntegrantesPorPlancha(idPlancha);
        }

        private void btnVotar_Click(object sender, EventArgs e)
        {
            if (idVotacionActual == 0)
            {
                MessageBox.Show("No hay votación activa.");
                return;
            }

            if (cmbPlanchas.SelectedValue == null || cmbPlanchas.SelectedValue is DataRowView)
            {
                MessageBox.Show("Debe seleccionar una plancha.");
                return;
            }

            DialogResult respuesta = MessageBox.Show(
                "¿Está seguro de votar por esta plancha? Esta acción no se puede deshacer.",
                "Confirmar voto",
                MessageBoxButtons.YesNo,
                MessageBoxIcon.Question);

            if (respuesta != DialogResult.Yes)
                return;

            Voto voto = new Voto
            {
                IdUsuario = usuarioActual.IdUsuario,
                IdVotacion = idVotacionActual,
                IdPlancha = Convert.ToInt32(cmbPlanchas.SelectedValue),
                EsNulo = false,
                FechaVoto = DateTime.Now
            };

            if (bll.RegistrarVoto(voto))
            {
                MessageBox.Show("Su voto fue registrado correctamente.");
                usuarioActual.YaVoto = true;
                this.Close();
            }
            else
            {
                MessageBox.Show("Ocurrió un error al registrar el voto.");
            }
        }

        private void btnVotoNulo_Click(object sender, EventArgs e)
        {
            if (idVotacionActual == 0)
            {
                MessageBox.Show("No hay votación activa.");
                return;
            }

            DialogResult respuesta = MessageBox.Show(
                "¿Está seguro de emitir un voto nulo? Esta acción no se puede deshacer.",
                "Confirmar voto nulo",
                MessageBoxButtons.YesNo,
                MessageBoxIcon.Warning);

            if (respuesta != DialogResult.Yes)
                return;

            Voto voto = new Voto
            {
                IdUsuario = usuarioActual.IdUsuario,
                IdVotacion = idVotacionActual,
                IdPlancha = null,
                EsNulo = true,
                FechaVoto = DateTime.Now
            };

            if (bll.RegistrarVoto(voto))
            {
                MessageBox.Show("Su voto nulo fue registrado correctamente.");
                usuarioActual.YaVoto = true;
                this.Close();
            }
            else
            {
                MessageBox.Show("Ocurrió un error al registrar el voto nulo.");
            }
        }

        private void btnCerrar_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void cmbPlanchas_SelectedIndexChanged(object sender, EventArgs e)
        {
            CargarIntegrantesPlancha();
        }

        private void dgvIntegrantes_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }

        private void lblEstadoVotacion_Click(object sender, EventArgs e)
        {

        }

        private void lblPlancha_Click(object sender, EventArgs e)
        {

        }

        private void lblEstado_Click(object sender, EventArgs e)
        {

        }

        private void lblTitulo_Click(object sender, EventArgs e)
        {

        }
    }
}