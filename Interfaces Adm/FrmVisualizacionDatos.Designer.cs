namespace REPORTES.Interfaces
{
    partial class FrmVisualizacionDatos
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.label1 = new System.Windows.Forms.Label();
            this.btnVerClientes = new System.Windows.Forms.Button();
            this.btnVerPrestamos = new System.Windows.Forms.Button();
            this.btnVerPagos = new System.Windows.Forms.Button();
            this.dgvDatos = new System.Windows.Forms.DataGridView();
            ((System.ComponentModel.ISupportInitialize)(this.dgvDatos)).BeginInit();
            this.SuspendLayout();
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Bauhaus 93", 18F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.Location = new System.Drawing.Point(158, 25);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(454, 40);
            this.label1.TabIndex = 0;
            this.label1.Text = "INFORMACIÓN DEL SISTEMA";
            // 
            // btnVerClientes
            // 
            this.btnVerClientes.BackColor = System.Drawing.Color.LightBlue;
            this.btnVerClientes.ForeColor = System.Drawing.SystemColors.ControlText;
            this.btnVerClientes.Location = new System.Drawing.Point(12, 421);
            this.btnVerClientes.Name = "btnVerClientes";
            this.btnVerClientes.Size = new System.Drawing.Size(253, 31);
            this.btnVerClientes.TabIndex = 1;
            this.btnVerClientes.Text = "Ver Clientes";
            this.btnVerClientes.UseVisualStyleBackColor = false;
            this.btnVerClientes.Click += new System.EventHandler(this.btnVerClientes_Click);
            // 
            // btnVerPrestamos
            // 
            this.btnVerPrestamos.BackColor = System.Drawing.Color.LightGreen;
            this.btnVerPrestamos.ForeColor = System.Drawing.SystemColors.ControlText;
            this.btnVerPrestamos.Location = new System.Drawing.Point(271, 421);
            this.btnVerPrestamos.Name = "btnVerPrestamos";
            this.btnVerPrestamos.Size = new System.Drawing.Size(220, 31);
            this.btnVerPrestamos.TabIndex = 2;
            this.btnVerPrestamos.Text = "Ver Préstamos";
            this.btnVerPrestamos.UseVisualStyleBackColor = false;
            this.btnVerPrestamos.Click += new System.EventHandler(this.btnVerPrestamos_Click);
            // 
            // btnVerPagos
            // 
            this.btnVerPagos.BackColor = System.Drawing.Color.Beige;
            this.btnVerPagos.ForeColor = System.Drawing.SystemColors.ControlText;
            this.btnVerPagos.Location = new System.Drawing.Point(497, 421);
            this.btnVerPagos.Name = "btnVerPagos";
            this.btnVerPagos.Size = new System.Drawing.Size(269, 31);
            this.btnVerPagos.TabIndex = 3;
            this.btnVerPagos.Text = "Ver Pagos";
            this.btnVerPagos.UseVisualStyleBackColor = false;
            this.btnVerPagos.Click += new System.EventHandler(this.btnVerPagos_Click);
            // 
            // dgvDatos
            // 
            this.dgvDatos.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvDatos.Location = new System.Drawing.Point(12, 114);
            this.dgvDatos.Name = "dgvDatos";
            this.dgvDatos.RowHeadersWidth = 62;
            this.dgvDatos.RowTemplate.Height = 28;
            this.dgvDatos.Size = new System.Drawing.Size(754, 280);
            this.dgvDatos.TabIndex = 4;
            // 
            // FrmVisualizacionDatos
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(9F, 20F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.WhiteSmoke;
            this.ClientSize = new System.Drawing.Size(778, 464);
            this.Controls.Add(this.dgvDatos);
            this.Controls.Add(this.btnVerPagos);
            this.Controls.Add(this.btnVerPrestamos);
            this.Controls.Add(this.btnVerClientes);
            this.Controls.Add(this.label1);
            this.Name = "FrmVisualizacionDatos";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Visualización de Información";
            this.Load += new System.EventHandler(this.FrmVisualizacionDatos_Load);
            ((System.ComponentModel.ISupportInitialize)(this.dgvDatos)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Button btnVerClientes;
        private System.Windows.Forms.Button btnVerPrestamos;
        private System.Windows.Forms.Button btnVerPagos;
        private System.Windows.Forms.DataGridView dgvDatos;
    }
}