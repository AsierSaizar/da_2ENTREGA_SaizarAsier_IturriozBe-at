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
            this.ErabiltzaieaTextBox = new System.Windows.Forms.TextBox();
            this.PasahitzaTextBox = new System.Windows.Forms.TextBox();
            this.Erabiltzailea = new System.Windows.Forms.Label();
            this.PasahitzaLabel = new System.Windows.Forms.Label();
            this.SaioaHasiButton = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // SaioaHasi
            // 
            this.SaioaHasi.AutoSize = true;
            this.SaioaHasi.Location = new System.Drawing.Point(214, 47);
            this.SaioaHasi.Name = "SaioaHasi";
            this.SaioaHasi.Size = new System.Drawing.Size(129, 25);
            this.SaioaHasi.TabIndex = 0;
            this.SaioaHasi.Text = "SAIOA HASI\r\n";
            this.SaioaHasi.Click += new System.EventHandler(this.label1_Click);
            // 
            // ErabiltzaieaTextBox
            // 
            this.ErabiltzaieaTextBox.Location = new System.Drawing.Point(199, 132);
            this.ErabiltzaieaTextBox.Name = "ErabiltzaieaTextBox";
            this.ErabiltzaieaTextBox.Size = new System.Drawing.Size(168, 31);
            this.ErabiltzaieaTextBox.TabIndex = 1;
            this.ErabiltzaieaTextBox.TextChanged += new System.EventHandler(this.Erabiltzaiea_TextChanged);
            // 
            // PasahitzaTextBox
            // 
            this.PasahitzaTextBox.Location = new System.Drawing.Point(199, 195);
            this.PasahitzaTextBox.Name = "PasahitzaTextBox";
            this.PasahitzaTextBox.Size = new System.Drawing.Size(168, 31);
            this.PasahitzaTextBox.TabIndex = 2;
            // 
            // Erabiltzailea
            // 
            this.Erabiltzailea.AutoSize = true;
            this.Erabiltzailea.Location = new System.Drawing.Point(51, 138);
            this.Erabiltzailea.Name = "Erabiltzailea";
            this.Erabiltzailea.Size = new System.Drawing.Size(142, 25);
            this.Erabiltzailea.TabIndex = 3;
            this.Erabiltzailea.Text = "Erabiltzailea: ";
            // 
            // PasahitzaLabel
            // 
            this.PasahitzaLabel.AutoSize = true;
            this.PasahitzaLabel.Location = new System.Drawing.Point(74, 201);
            this.PasahitzaLabel.Name = "PasahitzaLabel";
            this.PasahitzaLabel.Size = new System.Drawing.Size(119, 25);
            this.PasahitzaLabel.TabIndex = 4;
            this.PasahitzaLabel.Text = "Pasahitza: \r\n";
            // 
            // SaioaHasiButton
            // 
            this.SaioaHasiButton.Location = new System.Drawing.Point(199, 297);
            this.SaioaHasiButton.Name = "SaioaHasiButton";
            this.SaioaHasiButton.Size = new System.Drawing.Size(144, 72);
            this.SaioaHasiButton.TabIndex = 5;
            this.SaioaHasiButton.Text = "Saioa hasi";
            this.SaioaHasiButton.UseVisualStyleBackColor = true;
            this.SaioaHasiButton.Click += new System.EventHandler(this.SaioaHasiButton_Click);
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(12F, 25F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(525, 435);
            this.Controls.Add(this.SaioaHasiButton);
            this.Controls.Add(this.PasahitzaLabel);
            this.Controls.Add(this.Erabiltzailea);
            this.Controls.Add(this.PasahitzaTextBox);
            this.Controls.Add(this.ErabiltzaieaTextBox);
            this.Controls.Add(this.SaioaHasi);
            this.Name = "Form1";
            this.Text = "SaioHasiera";
            this.Load += new System.EventHandler(this.Form1_Load);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label SaioaHasi;
        private System.Windows.Forms.TextBox ErabiltzaieaTextBox;
        private System.Windows.Forms.TextBox PasahitzaTextBox;
        private System.Windows.Forms.Label Erabiltzailea;
        private System.Windows.Forms.Label PasahitzaLabel;
        private System.Windows.Forms.Button SaioaHasiButton;
    }
}

