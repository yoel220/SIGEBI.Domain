namespace SIGEBI.Presentation.Forms
{
    partial class AutorForm
    {
        private System.ComponentModel.IContainer components = null;
        private System.Windows.Forms.Label lblTitulo;
        private System.Windows.Forms.Label lblNombre;
        private System.Windows.Forms.TextBox txtNombre;
        private System.Windows.Forms.Label lblNacionalidad;
        private System.Windows.Forms.TextBox txtNacionalidad;
        private System.Windows.Forms.Button btnGuardar;
        private System.Windows.Forms.Button btnCancelar;
        private System.Windows.Forms.Panel panelButtons;

        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
                components.Dispose();
            base.Dispose(disposing);
        }

        private void InitializeComponent()
        {
            lblTitulo = new Label();
            lblNombre = new Label();
            txtNombre = new TextBox();
            lblNacionalidad = new Label();
            txtNacionalidad = new TextBox();
            btnGuardar = new Button();
            btnCancelar = new Button();
            panelButtons = new Panel();
            panelButtons.SuspendLayout();
            SuspendLayout();
            // 
            // lblTitulo
            // 
            lblTitulo.AutoSize = true;
            lblTitulo.Font = new Font("Segoe UI", 14F, FontStyle.Bold);
            lblTitulo.ForeColor = Color.DarkSlateGray;
            lblTitulo.Location = new Point(171, 34);
            lblTitulo.Margin = new Padding(4, 0, 4, 0);
            lblTitulo.Name = "lblTitulo";
            lblTitulo.Size = new Size(249, 38);
            lblTitulo.TabIndex = 0;
            lblTitulo.Text = "Registro de Autor";
            // 
            // lblNombre
            // 
            lblNombre.AutoSize = true;
            lblNombre.Location = new Point(43, 117);
            lblNombre.Margin = new Padding(4, 0, 4, 0);
            lblNombre.Name = "lblNombre";
            lblNombre.Size = new Size(82, 25);
            lblNombre.TabIndex = 1;
            lblNombre.Text = "Nombre:";
            // 
            // txtNombre
            // 
            txtNombre.Location = new Point(171, 112);
            txtNombre.Margin = new Padding(4, 5, 4, 5);
            txtNombre.Name = "txtNombre";
            txtNombre.PlaceholderText = "Ej. Mario Vargas Llosa";
            txtNombre.Size = new Size(313, 31);
            txtNombre.TabIndex = 2;
            // 
            // lblNacionalidad
            // 
            lblNacionalidad.AutoSize = true;
            lblNacionalidad.Location = new Point(43, 183);
            lblNacionalidad.Margin = new Padding(4, 0, 4, 0);
            lblNacionalidad.Name = "lblNacionalidad";
            lblNacionalidad.Size = new Size(119, 25);
            lblNacionalidad.TabIndex = 3;
            lblNacionalidad.Text = "Nacionalidad:";
            // 
            // txtNacionalidad
            // 
            txtNacionalidad.Location = new Point(171, 178);
            txtNacionalidad.Margin = new Padding(4, 5, 4, 5);
            txtNacionalidad.Name = "txtNacionalidad";
            txtNacionalidad.PlaceholderText = "Ej. Peruana";
            txtNacionalidad.Size = new Size(313, 31);
            txtNacionalidad.TabIndex = 4;
            // 
            // btnGuardar
            // 
            btnGuardar.BackColor = Color.Teal;
            btnGuardar.FlatStyle = FlatStyle.Flat;
            btnGuardar.ForeColor = Color.White;
            btnGuardar.Location = new Point(0, 8);
            btnGuardar.Margin = new Padding(4, 5, 4, 5);
            btnGuardar.Name = "btnGuardar";
            btnGuardar.Size = new Size(171, 50);
            btnGuardar.TabIndex = 0;
            btnGuardar.Text = "✔ Guardar";
            btnGuardar.UseVisualStyleBackColor = false;
            btnGuardar.Click += btnGuardar_Click;
            // 
            // btnCancelar
            // 
            btnCancelar.BackColor = Color.Gray;
            btnCancelar.FlatStyle = FlatStyle.Flat;
            btnCancelar.ForeColor = Color.White;
            btnCancelar.Location = new Point(229, 8);
            btnCancelar.Margin = new Padding(4, 5, 4, 5);
            btnCancelar.Name = "btnCancelar";
            btnCancelar.Size = new Size(171, 50);
            btnCancelar.TabIndex = 1;
            btnCancelar.Text = "✖ Cancelar";
            btnCancelar.UseVisualStyleBackColor = false;
            btnCancelar.Click += btnCancelar_Click;
            // 
            // panelButtons
            // 
            panelButtons.Controls.Add(btnGuardar);
            panelButtons.Controls.Add(btnCancelar);
            panelButtons.Location = new Point(71, 258);
            panelButtons.Margin = new Padding(4, 5, 4, 5);
            panelButtons.Name = "panelButtons";
            panelButtons.Size = new Size(429, 67);
            panelButtons.TabIndex = 5;
            // 
            // AutorForm
            // 
            AutoScaleDimensions = new SizeF(10F, 25F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(571, 367);
            Controls.Add(lblTitulo);
            Controls.Add(lblNombre);
            Controls.Add(txtNombre);
            Controls.Add(lblNacionalidad);
            Controls.Add(txtNacionalidad);
            Controls.Add(panelButtons);
            FormBorderStyle = FormBorderStyle.FixedDialog;
            Margin = new Padding(4, 5, 4, 5);
            Name = "AutorForm";
            StartPosition = FormStartPosition.CenterParent;
            Text = "Agregar Autor";
            panelButtons.ResumeLayout(false);
            ResumeLayout(false);
            PerformLayout();
        }
    }
}