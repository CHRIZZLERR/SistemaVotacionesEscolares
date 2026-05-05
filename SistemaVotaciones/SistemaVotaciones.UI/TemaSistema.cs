using System.Drawing;
using System.Windows.Forms;

namespace SistemaVotaciones.UI
{
    public static class TemaSistema
    {
        public static Color AzulOscuro = Color.FromArgb(5, 10, 80);
        public static Color AzulPanel = Color.FromArgb(10, 20, 120);
        public static Color AzulBoton = Color.FromArgb(90, 145, 230);
        public static Color AzulBotonHover = Color.FromArgb(70, 120, 210);
        public static Color RojoCerrar = Color.FromArgb(170, 0, 0);
        public static Color RojoHover = Color.FromArgb(200, 20, 20);
        public static Color Blanco = Color.White;
        public static Color GrisClaro = Color.FromArgb(240, 240, 240);

        public static Font FuenteTitulo = new Font("Segoe UI", 28, FontStyle.Bold);
        public static Font FuenteSubtitulo = new Font("Segoe UI", 12, FontStyle.Bold);
        public static Font FuenteNormal = new Font("Segoe UI", 10, FontStyle.Regular);
        public static Font FuenteBoton = new Font("Segoe UI", 12, FontStyle.Bold);

        public static void AplicarFondo(Form form)
        {
            form.BackColor = AzulOscuro;
            form.StartPosition = FormStartPosition.CenterScreen;
        }

        public static void AplicarTitulo(Label label)
        {
            label.Font = FuenteTitulo;
            label.ForeColor = Blanco;
            label.BackColor = Color.Transparent;
            label.TextAlign = ContentAlignment.MiddleCenter;
        }

        public static void AplicarSubtitulo(Label label)
        {
            label.Font = FuenteSubtitulo;
            label.ForeColor = Blanco;
            label.BackColor = Color.Transparent;
        }

        public static void AplicarLabel(Label label)
        {
            label.Font = FuenteNormal;
            label.ForeColor = Blanco;
            label.BackColor = Color.Transparent;
        }

        public static void AplicarBoton(Button boton)
        {
            boton.FlatStyle = FlatStyle.Flat;
            boton.FlatAppearance.BorderSize = 1;
            boton.FlatAppearance.BorderColor = Blanco;
            boton.BackColor = AzulBoton;
            boton.ForeColor = Blanco;
            boton.Font = FuenteBoton;
            boton.Cursor = Cursors.Hand;

            boton.MouseEnter += (s, e) =>
            {
                boton.BackColor = AzulBotonHover;
            };

            boton.MouseLeave += (s, e) =>
            {
                boton.BackColor = AzulBoton;
            };
        }

        public static void AplicarBotonCerrar(Button boton)
        {
            boton.FlatStyle = FlatStyle.Flat;
            boton.FlatAppearance.BorderSize = 1;
            boton.FlatAppearance.BorderColor = Blanco;
            boton.BackColor = RojoCerrar;
            boton.ForeColor = Blanco;
            boton.Font = FuenteBoton;
            boton.Cursor = Cursors.Hand;

            boton.MouseEnter += (s, e) =>
            {
                boton.BackColor = RojoHover;
            };

            boton.MouseLeave += (s, e) =>
            {
                boton.BackColor = RojoCerrar;
            };
        }

        public static void AplicarTextBox(TextBox textBox)
        {
            textBox.Font = FuenteNormal;
            textBox.BackColor = Color.White;
            textBox.ForeColor = Color.Black;
            textBox.BorderStyle = BorderStyle.FixedSingle;
        }

        public static void AplicarComboBox(ComboBox comboBox)
        {
            comboBox.Font = FuenteNormal;
            comboBox.BackColor = Color.White;
            comboBox.ForeColor = Color.Black;
            comboBox.DropDownStyle = ComboBoxStyle.DropDownList;
        }

        public static void AplicarDataGridView(DataGridView dgv)
        {
            dgv.BackgroundColor = Color.FromArgb(220, 220, 220);
            dgv.BorderStyle = BorderStyle.None;
            dgv.GridColor = Color.LightGray;
            dgv.EnableHeadersVisualStyles = false;

            dgv.ColumnHeadersDefaultCellStyle.BackColor = AzulPanel;
            dgv.ColumnHeadersDefaultCellStyle.ForeColor = Blanco;
            dgv.ColumnHeadersDefaultCellStyle.Font = new Font("Segoe UI", 10, FontStyle.Bold);

            dgv.DefaultCellStyle.BackColor = Color.White;
            dgv.DefaultCellStyle.ForeColor = Color.Black;
            dgv.DefaultCellStyle.SelectionBackColor = AzulBoton;
            dgv.DefaultCellStyle.SelectionForeColor = Blanco;
            dgv.DefaultCellStyle.Font = FuenteNormal;

            dgv.RowHeadersDefaultCellStyle.BackColor = AzulPanel;
            dgv.RowHeadersDefaultCellStyle.ForeColor = Blanco;

            dgv.AllowUserToAddRows = false;
            dgv.ReadOnly = true;
            dgv.SelectionMode = DataGridViewSelectionMode.FullRowSelect;
            dgv.MultiSelect = false;
        }

        public static void AplicarPanel(Panel panel)
        {
            panel.BackColor = AzulPanel;
        }
    }
}