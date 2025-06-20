namespace SIGEBI.Presentation.Forms
{
    partial class EditorialForm
    {
        private System.ComponentModel.IContainer components = null;
        private System.Windows.Forms.Label lblTitulo;
        private System.Windows.Forms.Label lblNombre;
        private System.Windows.Forms.TextBox txtNombre;
        private System.Windows.Forms.Label lblPais;
        private System.Windows.Forms.TextBox txtPais;
        private System.Windows.Forms.Button btnGuardar;
        private System.Windows.Forms.Button btnCancelar;
        private System.Windows.Forms.Panel panel;

        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        private void InitializeComponent()
        {
            this.panel = new System.Windows.Forms.Panel();
            this.lblTitulo = new System.Windows.Forms.Label();
            this.lblNombre = new System.Windows.Forms.Label();
            this.txtNombre = new System.Windows.Forms.TextBox();
            this.lblPais = new System.Windows.Forms.Label();
            this.txtPais = new System.Windows.Forms.TextBox();
            this.btnGuardar = new System.Windows.Forms.Button();
            this.btnCancelar = new System.Windows.Forms.Button();
            this.panel.SuspendLayout();
            this.SuspendLayout();
            // 
            // panel
            // 
            this.panel.BackColor = System.Drawing.Color.WhiteSmoke;
            this.panel.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.panel.Controls.Add(this.lblTitulo);
            this.panel.Controls.Add(this.lblNombre);
            this.panel.Controls.Add(this.txtNombre);
            this.panel.Controls.Add(this.lblPais);
            this.panel.Controls.Add(this.txtPais);
            this.panel.Controls.Add(this.btnGuardar);
            this.panel.Controls.Add(this.btnCancelar);
            this.panel.Location = new System.Drawing.Point(20, 20);
            this.panel.Name = "panel";
            this.panel.Size = new System.Drawing.Size(400, 230);
            this.panel.TabIndex = 0;
            // 
            // lblTitulo
            // 
            this.lblTitulo.Text = "Registro de Editorial";
            this.lblTitulo.Font = new System.Drawing.Font("Segoe UI", 14F, System.Drawing.FontStyle.Bold);
            this.lblTitulo.ForeColor = System.Drawing.Color.Teal;
            this.lblTitulo.AutoSize = true;
            this.lblTitulo.Location = new System.Drawing.Point(100, 10);
            // 
            // lblNombre
            // 
            this.lblNombre.Text = "Nombre:";
            this.lblNombre.Font = new System.Drawing.Font("Segoe UI", 10F);
            this.lblNombre.Location = new System.Drawing.Point(30, 60);
            this.lblNombre.AutoSize = true;
            // 
            // txtNombre
            // 
            this.txtNombre.Location = new System.Drawing.Point(120, 58);
            this.txtNombre.Size = new System.Drawing.Size(230, 22);
            this.txtNombre.Font = new System.Drawing.Font("Segoe UI", 10F);
            // 
            // lblPais
            // 
            this.lblPais.Text = "País:";
            this.lblPais.Font = new System.Drawing.Font("Segoe UI", 10F);
            this.lblPais.Location = new System.Drawing.Point(30, 100);
            this.lblPais.AutoSize = true;
            // 
            // txtPais
            // 
            this.txtPais.Location = new System.Drawing.Point(120, 98);
            this.txtPais.Size = new System.Drawing.Size(230, 22);
            this.txtPais.Font = new System.Drawing.Font("Segoe UI", 10F);
            // 
            // btnGuardar
            // 
            this.btnGuardar.Text = "Guardar";
            this.btnGuardar.BackColor = System.Drawing.Color.MediumSeaGreen;
            this.btnGuardar.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnGuardar.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Bold);
            this.btnGuardar.ForeColor = System.Drawing.Color.White;
            this.btnGuardar.Location = new System.Drawing.Point(80, 160);
            this.btnGuardar.Size = new System.Drawing.Size(100, 35);
            this.btnGuardar.Click += new System.EventHandler(this.btnGuardar_Click);
            // 
            // btnCancelar
            // 
            this.btnCancelar.Text = "Cancelar";
            this.btnCancelar.BackColor = System.Drawing.Color.IndianRed;
            this.btnCancelar.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnCancelar.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Bold);
            this.btnCancelar.ForeColor = System.Drawing.Color.White;
            this.btnCancelar.Location = new System.Drawing.Point(210, 160);
            this.btnCancelar.Size = new System.Drawing.Size(100, 35);
            this.btnCancelar.Click += new System.EventHandler(this.btnCancelar_Click);
            // 
            // EditorialForm
            // 
            this.BackColor = System.Drawing.Color.White;
            this.ClientSize = new System.Drawing.Size(440, 270);
            this.Controls.Add(this.panel);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.Name = "EditorialForm";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent;
            this.Text = "Gestión de Editorial";
            this.panel.ResumeLayout(false);
            this.panel.PerformLayout();
            this.ResumeLayout(false);
        }
    }
}