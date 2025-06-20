namespace SIGEBI.Presentation.Forms
{
    partial class LibroForm
    {
        private System.ComponentModel.IContainer components = null;
        private System.Windows.Forms.Label lblTitulo;
        private System.Windows.Forms.TextBox txtTitulo;
        private System.Windows.Forms.Label lblISBN;
        private System.Windows.Forms.TextBox txtISBN;
        private System.Windows.Forms.Label lblCantidad;
        private System.Windows.Forms.NumericUpDown numCantidad;
        private System.Windows.Forms.Label lblEditorial;
        private System.Windows.Forms.ComboBox cbEditorial;
        private System.Windows.Forms.Button btnGuardar;
        private System.Windows.Forms.Button btnCancelar;
        private System.Windows.Forms.Panel panelTop;
        private System.Windows.Forms.Label lblEncabezado;

        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
                components.Dispose();
            base.Dispose(disposing);
        }

        private void InitializeComponent()
        {
            lblTitulo = new Label();
            txtTitulo = new TextBox();
            lblISBN = new Label();
            txtISBN = new TextBox();
            lblCantidad = new Label();
            numCantidad = new NumericUpDown();
            lblEditorial = new Label();
            cbEditorial = new ComboBox();
            btnGuardar = new Button();
            btnCancelar = new Button();
            panelTop = new Panel();
            lblEncabezado = new Label();
            ((System.ComponentModel.ISupportInitialize)numCantidad).BeginInit();
            panelTop.SuspendLayout();
            SuspendLayout();
            // 
            // lblTitulo
            // 
            lblTitulo.AutoSize = true;
            lblTitulo.Location = new Point(30, 80);
            lblTitulo.Name = "lblTitulo";
            lblTitulo.Size = new Size(60, 25);
            lblTitulo.TabIndex = 1;
            lblTitulo.Text = "Título:";
            // 
            // txtTitulo
            // 
            txtTitulo.Location = new Point(140, 78);
            txtTitulo.Name = "txtTitulo";
            txtTitulo.Size = new Size(250, 31);
            txtTitulo.TabIndex = 2;
            // 
            // lblISBN
            // 
            lblISBN.AutoSize = true;
            lblISBN.Location = new Point(30, 120);
            lblISBN.Name = "lblISBN";
            lblISBN.Size = new Size(54, 25);
            lblISBN.TabIndex = 3;
            lblISBN.Text = "ISBN:";
            // 
            // txtISBN
            // 
            txtISBN.Location = new Point(140, 118);
            txtISBN.Name = "txtISBN";
            txtISBN.Size = new Size(250, 31);
            txtISBN.TabIndex = 4;
            // 
            // lblCantidad
            // 
            lblCantidad.AutoSize = true;
            lblCantidad.Location = new Point(30, 160);
            lblCantidad.Name = "lblCantidad";
            lblCantidad.Size = new Size(87, 25);
            lblCantidad.TabIndex = 5;
            lblCantidad.Text = "Cantidad:";
            // 
            // numCantidad
            // 
            numCantidad.Location = new Point(140, 158);
            numCantidad.Name = "numCantidad";
            numCantidad.Size = new Size(250, 31);
            numCantidad.TabIndex = 6;
            // 
            // lblEditorial
            // 
            lblEditorial.AutoSize = true;
            lblEditorial.Location = new Point(30, 200);
            lblEditorial.Name = "lblEditorial";
            lblEditorial.Size = new Size(80, 25);
            lblEditorial.TabIndex = 7;
            lblEditorial.Text = "Editorial:";
            // 
            // cbEditorial
            // 
            cbEditorial.DropDownStyle = ComboBoxStyle.DropDownList;
            cbEditorial.Location = new Point(140, 198);
            cbEditorial.Name = "cbEditorial";
            cbEditorial.Size = new Size(250, 33);
            cbEditorial.TabIndex = 8;
            // 
            // btnGuardar
            // 
            btnGuardar.BackColor = Color.MediumSeaGreen;
            btnGuardar.FlatStyle = FlatStyle.Flat;
            btnGuardar.ForeColor = Color.White;
            btnGuardar.Location = new Point(100, 260);
            btnGuardar.Name = "btnGuardar";
            btnGuardar.Size = new Size(100, 35);
            btnGuardar.TabIndex = 9;
            btnGuardar.Text = "Guardar";
            btnGuardar.UseVisualStyleBackColor = false;
            btnGuardar.Click += btnGuardar_Click;
            // 
            // btnCancelar
            // 
            btnCancelar.BackColor = Color.IndianRed;
            btnCancelar.FlatStyle = FlatStyle.Flat;
            btnCancelar.ForeColor = Color.White;
            btnCancelar.Location = new Point(220, 260);
            btnCancelar.Name = "btnCancelar";
            btnCancelar.Size = new Size(100, 35);
            btnCancelar.TabIndex = 10;
            btnCancelar.Text = "Cancelar";
            btnCancelar.UseVisualStyleBackColor = false;
            btnCancelar.Click += btnCancelar_Click;
            // 
            // panelTop
            // 
            panelTop.BackColor = Color.MidnightBlue;
            panelTop.Controls.Add(lblEncabezado);
            panelTop.Dock = DockStyle.Top;
            panelTop.Location = new Point(0, 0);
            panelTop.Name = "panelTop";
            panelTop.Size = new Size(450, 60);
            panelTop.TabIndex = 0;
            // 
            // lblEncabezado
            // 
            lblEncabezado.AutoSize = true;
            lblEncabezado.Font = new Font("Segoe UI", 14F, FontStyle.Bold);
            lblEncabezado.ForeColor = Color.White;
            lblEncabezado.Location = new Point(20, 15);
            lblEncabezado.Name = "lblEncabezado";
            lblEncabezado.Size = new Size(209, 38);
            lblEncabezado.TabIndex = 0;
            lblEncabezado.Text = "Registrar Libro";
            // 
            // LibroForm
            // 
            ClientSize = new Size(450, 354);
            Controls.Add(panelTop);
            Controls.Add(lblTitulo);
            Controls.Add(txtTitulo);
            Controls.Add(lblISBN);
            Controls.Add(txtISBN);
            Controls.Add(lblCantidad);
            Controls.Add(numCantidad);
            Controls.Add(lblEditorial);
            Controls.Add(cbEditorial);
            Controls.Add(btnGuardar);
            Controls.Add(btnCancelar);
            FormBorderStyle = FormBorderStyle.FixedDialog;
            MaximizeBox = false;
            Name = "LibroForm";
            Text = "Formulario de Libro";
            ((System.ComponentModel.ISupportInitialize)numCantidad).EndInit();
            panelTop.ResumeLayout(false);
            panelTop.PerformLayout();
            ResumeLayout(false);
            PerformLayout();
        }
    }
}