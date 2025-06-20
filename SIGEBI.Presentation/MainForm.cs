using System;
using System.Windows.Forms;

namespace SIGEBI.Presentation.Forms
{
    public partial class MainForm : Form
    {
        public MainForm()
        {
            InitializeComponent();
        }

        private void btnLibros_Click(object sender, EventArgs e)
        {
            var form = new LibroForm();
            form.ShowDialog();
        }

        private void btnAutores_Click(object sender, EventArgs e)
        {
            var form = new AutorForm();
            form.ShowDialog();
        }

        private void btnEditoriales_Click(object sender, EventArgs e)
        {
            var form = new EditorialForm();
            form.ShowDialog();
        }
    }
}