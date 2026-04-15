namespace REPORTES.Interfaces
{
    partial class FrmMoras
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
            this.label2 = new System.Windows.Forms.Label();
            this.cmbPrestamo = new System.Windows.Forms.ComboBox();
            this.label3 = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.txtCuotaMensual = new System.Windows.Forms.TextBox();
            this.txtMora = new System.Windows.Forms.TextBox();
            this.btnCalcularMora = new System.Windows.Forms.Button();
            this.btnRegistrarMora = new System.Windows.Forms.Button();
            this.dgvMoras = new System.Windows.Forms.DataGridView();
            ((System.ComponentModel.ISupportInitialize)(this.dgvMoras)).BeginInit();
            this.SuspendLayout();
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Bauhaus 93", 18F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.Location = new System.Drawing.Point(214, 21);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(112, 40);
            this.label1.TabIndex = 0;
            this.label1.Text = "Moras";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("Comic Sans MS", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label2.Location = new System.Drawing.Point(13, 122);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(183, 28);
            this.label2.TabIndex = 1;
            this.label2.Text = "Cliente / Prestamo";
            // 
            // cmbPrestamo
            // 
            this.cmbPrestamo.FormattingEnabled = true;
            this.cmbPrestamo.Location = new System.Drawing.Point(226, 125);
            this.cmbPrestamo.Name = "cmbPrestamo";
            this.cmbPrestamo.Size = new System.Drawing.Size(392, 28);
            this.cmbPrestamo.TabIndex = 2;
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Font = new System.Drawing.Font("Comic Sans MS", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label3.Location = new System.Drawing.Point(17, 188);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(149, 28);
            this.label3.TabIndex = 3;
            this.label3.Text = "Cuota Mensual:";
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Font = new System.Drawing.Font("Comic Sans MS", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label4.Location = new System.Drawing.Point(17, 240);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(210, 28);
            this.label4.TabIndex = 4;
            this.label4.Text = "Cantidad Mora (10%):";
            // 
            // txtCuotaMensual
            // 
            this.txtCuotaMensual.Location = new System.Drawing.Point(182, 191);
            this.txtCuotaMensual.Name = "txtCuotaMensual";
            this.txtCuotaMensual.Size = new System.Drawing.Size(436, 26);
            this.txtCuotaMensual.TabIndex = 5;
            // 
            // txtMora
            // 
            this.txtMora.Location = new System.Drawing.Point(226, 240);
            this.txtMora.Name = "txtMora";
            this.txtMora.Size = new System.Drawing.Size(392, 26);
            this.txtMora.TabIndex = 6;
            // 
            // btnCalcularMora
            // 
            this.btnCalcularMora.BackColor = System.Drawing.Color.LightBlue;
            this.btnCalcularMora.Location = new System.Drawing.Point(21, 303);
            this.btnCalcularMora.Name = "btnCalcularMora";
            this.btnCalcularMora.Size = new System.Drawing.Size(305, 34);
            this.btnCalcularMora.TabIndex = 7;
            this.btnCalcularMora.Text = "Calcular";
            this.btnCalcularMora.UseVisualStyleBackColor = false;
            this.btnCalcularMora.Click += new System.EventHandler(this.btnCalcularMora_Click);
            // 
            // btnRegistrarMora
            // 
            this.btnRegistrarMora.BackColor = System.Drawing.Color.LightGreen;
            this.btnRegistrarMora.Location = new System.Drawing.Point(332, 303);
            this.btnRegistrarMora.Name = "btnRegistrarMora";
            this.btnRegistrarMora.Size = new System.Drawing.Size(305, 34);
            this.btnRegistrarMora.TabIndex = 8;
            this.btnRegistrarMora.Text = "Registrar";
            this.btnRegistrarMora.UseVisualStyleBackColor = false;
            this.btnRegistrarMora.Click += new System.EventHandler(this.btnRegistrarMora_Click);
            // 
            // dgvMoras
            // 
            this.dgvMoras.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvMoras.Location = new System.Drawing.Point(22, 375);
            this.dgvMoras.Name = "dgvMoras";
            this.dgvMoras.RowHeadersWidth = 62;
            this.dgvMoras.RowTemplate.Height = 28;
            this.dgvMoras.Size = new System.Drawing.Size(615, 241);
            this.dgvMoras.TabIndex = 9;
            // 
            // FrmMoras
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(9F, 20F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(675, 628);
            this.Controls.Add(this.dgvMoras);
            this.Controls.Add(this.btnRegistrarMora);
            this.Controls.Add(this.btnCalcularMora);
            this.Controls.Add(this.txtMora);
            this.Controls.Add(this.txtCuotaMensual);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.cmbPrestamo);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.label1);
            this.Name = "FrmMoras";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "FrmMoras";
            this.Load += new System.EventHandler(this.FrmMoras_Load);
            ((System.ComponentModel.ISupportInitialize)(this.dgvMoras)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.ComboBox cmbPrestamo;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.TextBox txtCuotaMensual;
        private System.Windows.Forms.TextBox txtMora;
        private System.Windows.Forms.Button btnCalcularMora;
        private System.Windows.Forms.Button btnRegistrarMora;
        private System.Windows.Forms.DataGridView dgvMoras;
    }
}