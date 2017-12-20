namespace MasterCoveControl
{
    partial class ExportClient
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

        #region Código generado por el Diseñador de componentes

        /// <summary> 
        /// Método necesario para admitir el Diseñador. No se puede modificar
        /// el contenido de este método con el editor de código.
        /// </summary>
        private void InitializeComponent()
        {
            this.label5 = new System.Windows.Forms.Label();
            this.ComboboxClient = new System.Windows.Forms.ComboBox();
            this.ButtonExportClient = new System.Windows.Forms.Button();
            this.label1 = new System.Windows.Forms.Label();
            this.ComboboxYear = new System.Windows.Forms.ComboBox();
            this.ProgressBarUpdate = new System.Windows.Forms.ProgressBar();
            this.backgroundWorker1 = new System.ComponentModel.BackgroundWorker();
            this.SuspendLayout();
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(3, 41);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(101, 13);
            this.label5.TabIndex = 12;
            this.label5.Text = "Seleccionar Cliente:";
            // 
            // ComboboxClient
            // 
            this.ComboboxClient.FormattingEnabled = true;
            this.ComboboxClient.Location = new System.Drawing.Point(107, 37);
            this.ComboboxClient.Name = "ComboboxClient";
            this.ComboboxClient.Size = new System.Drawing.Size(481, 21);
            this.ComboboxClient.Sorted = true;
            this.ComboboxClient.TabIndex = 11;
            this.ComboboxClient.SelectedIndexChanged += new System.EventHandler(this.ComboboxClient_SelectedIndexChanged);
            // 
            // ButtonExportClient
            // 
            this.ButtonExportClient.Location = new System.Drawing.Point(594, 36);
            this.ButtonExportClient.Name = "ButtonExportClient";
            this.ButtonExportClient.Size = new System.Drawing.Size(99, 23);
            this.ButtonExportClient.TabIndex = 13;
            this.ButtonExportClient.Text = "Exportar Cliente";
            this.ButtonExportClient.UseVisualStyleBackColor = true;
            this.ButtonExportClient.Click += new System.EventHandler(this.ButtonExportClient_Click);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(3, 11);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(88, 13);
            this.label1.TabIndex = 14;
            this.label1.Text = "Seleccionar Año:";
            // 
            // ComboboxYear
            // 
            this.ComboboxYear.FormattingEnabled = true;
            this.ComboboxYear.Location = new System.Drawing.Point(107, 6);
            this.ComboboxYear.Name = "ComboboxYear";
            this.ComboboxYear.Size = new System.Drawing.Size(481, 21);
            this.ComboboxYear.Sorted = true;
            this.ComboboxYear.TabIndex = 15;
            this.ComboboxYear.SelectedIndexChanged += new System.EventHandler(this.ComboboxYear_SelectedIndexChanged);
            // 
            // ProgressBarUpdate
            // 
            this.ProgressBarUpdate.Location = new System.Drawing.Point(6, 152);
            this.ProgressBarUpdate.Name = "ProgressBarUpdate";
            this.ProgressBarUpdate.Size = new System.Drawing.Size(687, 23);
            this.ProgressBarUpdate.TabIndex = 16;
            // 
            // backgroundWorker1
            // 
            this.backgroundWorker1.DoWork += new System.ComponentModel.DoWorkEventHandler(this.backgroundWorker1_DoWork);
            this.backgroundWorker1.ProgressChanged += new System.ComponentModel.ProgressChangedEventHandler(this.backgroundWorker1_ProgressChanged);
            this.backgroundWorker1.RunWorkerCompleted += new System.ComponentModel.RunWorkerCompletedEventHandler(this.backgroundWorker1_RunWorkerCompleted);
            // 
            // ExportClient
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.SystemColors.InactiveCaption;
            this.Controls.Add(this.ProgressBarUpdate);
            this.Controls.Add(this.ComboboxYear);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.ButtonExportClient);
            this.Controls.Add(this.label5);
            this.Controls.Add(this.ComboboxClient);
            this.Name = "ExportClient";
            this.Size = new System.Drawing.Size(700, 180);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.ComboBox ComboboxClient;
        private System.Windows.Forms.Button ButtonExportClient;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.ComboBox ComboboxYear;
        private System.Windows.Forms.ProgressBar ProgressBarUpdate;
        private System.ComponentModel.BackgroundWorker backgroundWorker1;
    }
}
