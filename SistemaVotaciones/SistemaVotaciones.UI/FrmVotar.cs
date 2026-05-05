using System;
using System.Data;
using System.Drawing;
using System.IO;
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
        private int idPlanchaSeleccionada = 0;

        private Panel panelPrincipal;
        private Label lblTituloNuevo;
        private Label lblSubtitulo;
        private FlowLayoutPanel panelPlanchas;
        private Label lblIntegrantesTitulo;

        public FrmVotar()
        {
            InitializeComponent();
        }

        public FrmVotar(Usuario usuario)
        {
            InitializeComponent();
            usuarioActual = usuario;
        }

        private void FrmVotar_Load(object sender, EventArgs e)
        {
            AplicarDiseno();
            CargarDatosVotacion();
        }

        private void AplicarDiseno()
        {
            this.Text = "Emitir Voto - Sistema de Votaciones";
            this.StartPosition = FormStartPosition.CenterScreen;
            this.Size = new Size(1080, 700);
            this.FormBorderStyle = FormBorderStyle.FixedSingle;
            this.MaximizeBox = false;
            this.BackColor = Color.FromArgb(8, 18, 55);

            panelPrincipal = new Panel();
            panelPrincipal.BackColor = Color.FromArgb(245, 248, 255);
            panelPrincipal.Location = new Point(35, 30);
            panelPrincipal.Size = new Size(990, 610);
            panelPrincipal.BorderStyle = BorderStyle.None;
            this.Controls.Add(panelPrincipal);
            panelPrincipal.BringToFront();

            Panel panelHeader = new Panel();
            panelHeader.BackColor = Color.FromArgb(10, 38, 95);
            panelHeader.Location = new Point(0, 0);
            panelHeader.Size = new Size(990, 115);
            panelPrincipal.Controls.Add(panelHeader);

            lblTituloNuevo = new Label();
            lblTituloNuevo.Text = "Votación Estudiantil";
            lblTituloNuevo.Font = new Font("Segoe UI", 27, FontStyle.Bold);
            lblTituloNuevo.ForeColor = Color.White;
            lblTituloNuevo.BackColor = Color.Transparent;
            lblTituloNuevo.TextAlign = ContentAlignment.MiddleCenter;
            lblTituloNuevo.AutoSize = false;
            lblTituloNuevo.Location = new Point(20, 20);
            lblTituloNuevo.Size = new Size(950, 48);
            panelHeader.Controls.Add(lblTituloNuevo);

            lblSubtitulo = new Label();
            lblSubtitulo.Text = "Selecciona una plancha para emitir tu voto";
            lblSubtitulo.Font = new Font("Segoe UI", 10, FontStyle.Bold);
            lblSubtitulo.ForeColor = Color.FromArgb(255, 215, 90);
            lblSubtitulo.BackColor = Color.Transparent;
            lblSubtitulo.TextAlign = ContentAlignment.MiddleCenter;
            lblSubtitulo.AutoSize = false;
            lblSubtitulo.Location = new Point(20, 70);
            lblSubtitulo.Size = new Size(950, 25);
            panelHeader.Controls.Add(lblSubtitulo);

            lblEstado.Text = "Estado:";
            lblEstado.Font = new Font("Segoe UI", 11, FontStyle.Bold);
            lblEstado.ForeColor = Color.FromArgb(10, 38, 95);
            lblEstado.BackColor = Color.Transparent;
            lblEstado.Location = new Point(35, 135);
            lblEstado.Size = new Size(75, 28);
            panelPrincipal.Controls.Add(lblEstado);

            lblEstadoVotacion.Font = new Font("Segoe UI", 11, FontStyle.Bold);
            lblEstadoVotacion.ForeColor = Color.FromArgb(20, 130, 60);
            lblEstadoVotacion.BackColor = Color.Transparent;
            lblEstadoVotacion.Location = new Point(110, 135);
            lblEstadoVotacion.Size = new Size(500, 28);
            panelPrincipal.Controls.Add(lblEstadoVotacion);

            lblPlancha.Visible = false;
            cmbPlanchas.Visible = false;

            panelPlanchas = new FlowLayoutPanel();
            panelPlanchas.Location = new Point(35, 175);
            panelPlanchas.Size = new Size(920, 210);
            panelPlanchas.BackColor = Color.Transparent;
            panelPlanchas.AutoScroll = true;
            panelPlanchas.FlowDirection = FlowDirection.LeftToRight;
            panelPlanchas.WrapContents = false;
            panelPrincipal.Controls.Add(panelPlanchas);

            lblIntegrantesTitulo = new Label();
            lblIntegrantesTitulo.Text = "Integrantes de la plancha seleccionada";
            lblIntegrantesTitulo.Font = new Font("Segoe UI", 12, FontStyle.Bold);
            lblIntegrantesTitulo.ForeColor = Color.FromArgb(10, 38, 95);
            lblIntegrantesTitulo.BackColor = Color.Transparent;
            lblIntegrantesTitulo.Location = new Point(35, 400);
            lblIntegrantesTitulo.Size = new Size(500, 28);
            panelPrincipal.Controls.Add(lblIntegrantesTitulo);

            panelPrincipal.Controls.Add(dgvIntegrantes);
            dgvIntegrantes.Location = new Point(35, 430);
            dgvIntegrantes.Size = new Size(610, 120);
            dgvIntegrantes.BackgroundColor = Color.White;
            dgvIntegrantes.BorderStyle = BorderStyle.FixedSingle;
            dgvIntegrantes.EnableHeadersVisualStyles = false;
            dgvIntegrantes.ColumnHeadersDefaultCellStyle.BackColor = Color.FromArgb(10, 38, 95);
            dgvIntegrantes.ColumnHeadersDefaultCellStyle.ForeColor = Color.White;
            dgvIntegrantes.ColumnHeadersDefaultCellStyle.Font = new Font("Segoe UI", 10, FontStyle.Bold);
            dgvIntegrantes.DefaultCellStyle.Font = new Font("Segoe UI", 10, FontStyle.Regular);
            dgvIntegrantes.DefaultCellStyle.SelectionBackColor = Color.FromArgb(21, 101, 192);
            dgvIntegrantes.DefaultCellStyle.SelectionForeColor = Color.White;
            dgvIntegrantes.AllowUserToAddRows = false;
            dgvIntegrantes.ReadOnly = true;
            dgvIntegrantes.SelectionMode = DataGridViewSelectionMode.FullRowSelect;
            dgvIntegrantes.MultiSelect = false;
            dgvIntegrantes.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;

            panelPrincipal.Controls.Add(btnVotar);
            panelPrincipal.Controls.Add(btnVotoNulo);
            panelPrincipal.Controls.Add(btnCerrar);

            btnVotar.Text = "Votar por plancha";
            btnVotoNulo.Text = "Voto nulo";
            btnCerrar.Text = "Cerrar";

            EstiloBoton(btnVotar);
            EstiloBotonSecundario(btnVotoNulo);
            EstiloBotonCerrar(btnCerrar);

            btnVotar.Location = new Point(685, 430);
            btnVotar.Size = new Size(240, 45);

            btnVotoNulo.Location = new Point(685, 490);
            btnVotoNulo.Size = new Size(240, 45);

            btnCerrar.Location = new Point(685, 550);
            btnCerrar.Size = new Size(240, 45);
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
            boton.Font = new Font("Segoe UI", 11, FontStyle.Bold);
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
                DesactivarVotacion();
                return;
            }

            DataTable votacion = bll.ObtenerVotacionAbiertaPorPadron(usuarioActual.IdPadron);

            if (votacion.Rows.Count == 0)
            {
                lblEstadoVotacion.Text = "No hay votación abierta para su padrón";
                lblEstadoVotacion.ForeColor = Color.FromArgb(185, 28, 28);
                DesactivarVotacion();
                return;
            }

            idVotacionActual = Convert.ToInt32(votacion.Rows[0]["IdVotacion"]);
            lblEstadoVotacion.Text = "Abierta";
            lblEstadoVotacion.ForeColor = Color.FromArgb(20, 130, 60);

            CargarPlanchas();
        }

        private void DesactivarVotacion()
        {
            btnVotar.Enabled = false;
            btnVotoNulo.Enabled = false;
            btnVotar.BackColor = Color.Gray;
            btnVotoNulo.BackColor = Color.Gray;
            panelPlanchas.Enabled = false;
        }

        private void CargarPlanchas()
        {
            DataTable planchas = bll.ListarPlanchasPorPadron(usuarioActual.IdPadron);

            panelPlanchas.Controls.Clear();
            idPlanchaSeleccionada = 0;

            if (planchas.Rows.Count == 0)
            {
                MessageBox.Show("No hay planchas disponibles para su padrón.");
                btnVotar.Enabled = false;
                return;
            }

            foreach (DataRow row in planchas.Rows)
            {
                Panel card = CrearTarjetaPlancha(row);
                panelPlanchas.Controls.Add(card);
            }

            if (planchas.Rows.Count > 0)
            {
                SeleccionarPlancha(Convert.ToInt32(planchas.Rows[0]["IdPlancha"]));
            }
        }

        private Panel CrearTarjetaPlancha(DataRow row)
        {
            int idPlancha = Convert.ToInt32(row["IdPlancha"]);
            string nombre = row["NombrePlancha"].ToString();
            string color = row["Color"].ToString();
            string lema = row["Lema"].ToString();
            string imagenPath = row["ImagenPath"].ToString();

            Panel card = new Panel();
            card.Width = 260;
            card.Height = 175;
            card.Margin = new Padding(0, 0, 18, 0);
            card.BackColor = Color.White;
            card.BorderStyle = BorderStyle.FixedSingle;
            card.Tag = idPlancha;
            card.Cursor = Cursors.Hand;

            PictureBox picture = new PictureBox();
            picture.Location = new Point(15, 15);
            picture.Size = new Size(70, 70);
            picture.SizeMode = PictureBoxSizeMode.Zoom;
            picture.BackColor = Color.FromArgb(235, 240, 250);

            if (!string.IsNullOrWhiteSpace(imagenPath) && File.Exists(imagenPath))
            {
                picture.Image = Image.FromFile(imagenPath);
            }
            else
            {
                Bitmap bmp = new Bitmap(70, 70);
                using (Graphics g = Graphics.FromImage(bmp))
                {
                    g.Clear(Color.FromArgb(21, 101, 192));
                    using (Font font = new Font("Segoe UI", 24, FontStyle.Bold))
                    using (Brush brush = new SolidBrush(Color.White))
                    {
                        string inicial = nombre.Length > 0 ? nombre.Substring(0, 1).ToUpper() : "P";
                        SizeF size = g.MeasureString(inicial, font);
                        g.DrawString(inicial, font, brush, (70 - size.Width) / 2, (70 - size.Height) / 2);
                    }
                }

                picture.Image = bmp;
            }

            Label lblNombre = new Label();
            lblNombre.Text = nombre;
            lblNombre.Font = new Font("Segoe UI", 12, FontStyle.Bold);
            lblNombre.ForeColor = Color.FromArgb(10, 38, 95);
            lblNombre.BackColor = Color.Transparent;
            lblNombre.Location = new Point(95, 15);
            lblNombre.Size = new Size(150, 45);

            Label lblColor = new Label();
            lblColor.Text = "Color: " + (string.IsNullOrWhiteSpace(color) ? "N/A" : color);
            lblColor.Font = new Font("Segoe UI", 9, FontStyle.Bold);
            lblColor.ForeColor = Color.FromArgb(80, 90, 110);
            lblColor.BackColor = Color.Transparent;
            lblColor.Location = new Point(95, 62);
            lblColor.Size = new Size(150, 22);

            Label lblLema = new Label();
            lblLema.Text = string.IsNullOrWhiteSpace(lema) ? "Sin lema registrado" : lema;
            lblLema.Font = new Font("Segoe UI", 9, FontStyle.Regular);
            lblLema.ForeColor = Color.FromArgb(70, 80, 100);
            lblLema.BackColor = Color.Transparent;
            lblLema.Location = new Point(15, 98);
            lblLema.Size = new Size(230, 48);

            Label lblSeleccion = new Label();
            lblSeleccion.Text = "Seleccionar";
            lblSeleccion.Font = new Font("Segoe UI", 9, FontStyle.Bold);
            lblSeleccion.ForeColor = Color.White;
            lblSeleccion.BackColor = Color.FromArgb(21, 101, 192);
            lblSeleccion.TextAlign = ContentAlignment.MiddleCenter;
            lblSeleccion.Location = new Point(15, 145);
            lblSeleccion.Size = new Size(230, 25);

            card.Controls.Add(picture);
            card.Controls.Add(lblNombre);
            card.Controls.Add(lblColor);
            card.Controls.Add(lblLema);
            card.Controls.Add(lblSeleccion);

            AsociarClickTarjeta(card, idPlancha);

            return card;
        }

        private void AsociarClickTarjeta(Control control, int idPlancha)
        {
            control.Click += (s, e) =>
            {
                SeleccionarPlancha(idPlancha);
            };

            foreach (Control hijo in control.Controls)
            {
                AsociarClickTarjeta(hijo, idPlancha);
            }
        }

        private void SeleccionarPlancha(int idPlancha)
        {
            idPlanchaSeleccionada = idPlancha;

            foreach (Control control in panelPlanchas.Controls)
            {
                if (control is Panel card)
                {
                    int id = Convert.ToInt32(card.Tag);

                    if (id == idPlanchaSeleccionada)
                    {
                        card.BackColor = Color.FromArgb(225, 238, 255);
                    }
                    else
                    {
                        card.BackColor = Color.White;
                    }
                }
            }

            CargarIntegrantesPlancha(idPlanchaSeleccionada);
        }

        private void CargarIntegrantesPlancha(int idPlancha)
        {
            dgvIntegrantes.DataSource = bll.ListarIntegrantesPorPlancha(idPlancha);
        }

        private void btnVotar_Click(object sender, EventArgs e)
        {
            if (idVotacionActual == 0)
            {
                MessageBox.Show("No hay votación activa.");
                return;
            }

            if (idPlanchaSeleccionada == 0)
            {
                MessageBox.Show("Debe seleccionar una plancha.");
                return;
            }

            DialogResult respuesta = MessageBox.Show(
                "¿Está seguro de votar por la plancha seleccionada? Esta acción no se puede deshacer.",
                "Confirmar voto",
                MessageBoxButtons.YesNo,
                MessageBoxIcon.Question);

            if (respuesta != DialogResult.Yes)
                return;

            Voto voto = new Voto
            {
                IdUsuario = usuarioActual.IdUsuario,
                IdVotacion = idVotacionActual,
                IdPlancha = idPlanchaSeleccionada,
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