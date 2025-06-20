using System;
using System.Windows.Forms;

namespace SIGEBI.Presentation.Forms
{
    public partial class LibroForm : Form
    {
        public LibroForm()
        {
            InitializeComponent();
        }

        private void btnGuardar_Click(object sender, EventArgs e)
        {
            // Aquí podrías guardar los datos del libro
            MessageBox.Show("Libro guardado correctamente.", "Información", MessageBoxButtons.OK, MessageBoxIcon.Information);
        }

        private void btnCancelar_Click(object sender, EventArgs e)
        {
            this.Close();
        }
    }
}