namespace DA_2ENTREGA
{
    partial class Form1
    {
        /// <summary>
        /// Variable del diseñador necesaria.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Limpiar los recursos que se estén usando.
        /// </summary>
        /// <param name="disposing">true si los recursos administrados se deben desechar; false en caso contrario.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Código generado por el Diseñador de Windows Forms

        /// <summary>
        /// Método necesario para admitir el Diseñador. No se puede modificar
        /// el contenido de este método con el editor de código.
        /// </summary>
        private void InitializeComponent()
        {
            this.SaioaHasi = new System.Windows.Forms.Label();
            this.SaioaHasiButton = new System.Windows.Forms.Button();
            this.comboBox1 = new System.Windows.Forms.ComboBox();
            this.SuspendLayout();
            // 
            // SaioaHasi
            // 
            this.SaioaHasi.AutoSize = true;
            this.SaioaHasi.BackColor = System.Drawing.SystemColors.Control;
            this.SaioaHasi.Location = new System.Drawing.Point(59, 54);
            this.SaioaHasi.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.SaioaHasi.Name = "SaioaHasi";
            this.SaioaHasi.Size = new System.Drawing.Size(151, 13);
            this.SaioaHasi.TabIndex = 0;
            this.SaioaHasi.Text = "AUKERATU ERABILTZAILEA";
            this.SaioaHasi.Click += new System.EventHandler(this.label1_Click);
            // 
            // SaioaHasiButton
            // 
            this.SaioaHasiButton.BackColor = System.Drawing.SystemColors.ButtonShadow;
            this.SaioaHasiButton.Location = new System.Drawing.Point(86, 129);
            this.SaioaHasiButton.Margin = new System.Windows.Forms.Padding(2, 2, 2, 2);
            this.SaioaHasiButton.Name = "SaioaHasiButton";
            this.SaioaHasiButton.Size = new System.Drawing.Size(86, 43);
            this.SaioaHasiButton.TabIndex = 5;
            this.SaioaHasiButton.Text = "Saioa hasi";
            this.SaioaHasiButton.UseVisualStyleBackColor = false;
            this.SaioaHasiButton.Click += new System.EventHandler(this.SaioaHasiButton_Click);
            // 
            // comboBox1
            // 
            this.comboBox1.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.comboBox1.FormattingEnabled = true;
            this.comboBox1.Location = new System.Drawing.Point(72, 79);
            this.comboBox1.MaxDropDownItems = 32;
            this.comboBox1.Name = "comboBox1";
            this.comboBox1.Size = new System.Drawing.Size(121, 21);
            this.comboBox1.TabIndex = 6;
            this.comboBox1.SelectedIndexChanged += new System.EventHandler(this.comboBox1_SelectedIndexChanged);
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(262, 226);
            this.Controls.Add(this.comboBox1);
            this.Controls.Add(this.SaioaHasiButton);
            this.Controls.Add(this.SaioaHasi);
            this.Margin = new System.Windows.Forms.Padding(2, 2, 2, 2);
            this.Name = "Form1";
            this.Text = "SaioHasiera";
            this.Load += new System.EventHandler(this.Form1_Load);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label SaioaHasi;
        private System.Windows.Forms.Button SaioaHasiButton;
        private System.Windows.Forms.ComboBox comboBox1;
    }
}

