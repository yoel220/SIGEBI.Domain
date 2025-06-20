using System;
using System.Windows.Forms;

namespace SIGEBI.Presentation.Forms
{
    public partial class EditorialForm : Form
    {
        public EditorialForm()
        {
            InitializeComponent();
        }

        private void btnGuardar_Click(object sender, EventArgs e)
        {
            // Lógica para guardar la editorial
            MessageBox.Show("Editorial guardada exitosamente.");
        }

        private void btnCancelar_Click(object sender, EventArgs e)
        {
            this.Close();
        }
    }
}