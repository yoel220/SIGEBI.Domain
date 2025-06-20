using System;
using System.Windows.Forms;

namespace SIGEBI.Presentation.Forms
{
    public partial class AutorForm : Form
    {
        public AutorForm()
        {
            InitializeComponent();
        }

        private void btnGuardar_Click(object sender, EventArgs e)
        {
            string nombre = txtNombre.Text.Trim();
            string nacionalidad = txtNacionalidad.Text.Trim();

            if (string.IsNullOrWhiteSpace(nombre) || string.IsNullOrWhiteSpace(nacionalidad))
            {
                MessageBox.Show("Debe completar todos los campos.", "Advertencia", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            // Aquí se podría llamar al repositorio para guardar en la base de datos

            MessageBox.Show("Autor guardado correctamente.", "Información", MessageBoxButtons.OK, MessageBoxIcon.Information);
            this.Close();
        }

        private void btnCancelar_Click(object sender, EventArgs e)
        {
            this.Close();
        }
    }
}