namespace MasterCoveControl
{
    partial class LoadIssues
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
            this.TextboxPath = new System.Windows.Forms.TextBox();
            this.ButtonGetIssues = new System.Windows.Forms.Button();
            this.ButtonGetExcel = new System.Windows.Forms.Button();
            this.label1 = new System.Windows.Forms.Label();
            this.ProgressBarFiles = new System.Windows.Forms.ProgressBar();
            this.backgroundWorker1 = new System.ComponentModel.BackgroundWorker();
            this.label3 = new System.Windows.Forms.Label();
            this.ComboboxYears = new System.Windows.Forms.ComboBox();
            this.SuspendLayout();
            // 
            // TextboxPath
            // 
            this.TextboxPath.Enabled = false;
            this.TextboxPath.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.TextboxPath.Location = new System.Drawing.Point(148, 29);
            this.TextboxPath.Name = "TextboxPath";
            this.TextboxPath.Size = new System.Drawing.Size(547, 21);
            this.TextboxPath.TabIndex = 2;
            this.TextboxPath.TabStop = false;
            // 
            // ButtonGetIssues
            // 
            this.ButtonGetIssues.AccessibleRole = System.Windows.Forms.AccessibleRole.None;
            this.ButtonGetIssues.Enabled = false;
            this.ButtonGetIssues.Location = new System.Drawing.Point(285, 124);
            this.ButtonGetIssues.Name = "ButtonGetIssues";
            this.ButtonGetIssues.Size = new System.Drawing.Size(141, 23);
            this.ButtonGetIssues.TabIndex = 3;
            this.ButtonGetIssues.Text = "Agregar Coves Muertos";
            this.ButtonGetIssues.UseVisualStyleBackColor = true;
            this.ButtonGetIssues.Click += new System.EventHandler(this.ButtonGetIssues_Click);
            // 
            // ButtonGetExcel
            // 
            this.ButtonGetExcel.AccessibleRole = System.Windows.Forms.AccessibleRole.None;
            this.ButtonGetExcel.Location = new System.Drawing.Point(3, 28);
            this.ButtonGetExcel.Name = "ButtonGetExcel";
            this.ButtonGetExcel.Size = new System.Drawing.Size(141, 23);
            this.ButtonGetExcel.TabIndex = 4;
            this.ButtonGetExcel.Text = "Buscar Coves Muertos";
            this.ButtonGetExcel.UseVisualStyleBackColor = true;
            this.ButtonGetExcel.Click += new System.EventHandler(this.ButtonGetExcel_Click);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(5, 156);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(99, 13);
            this.label1.TabIndex = 10;
            this.label1.Text = "Archivos Cargados:";
            // 
            // ProgressBarFiles
            // 
            this.ProgressBarFiles.Location = new System.Drawing.Point(104, 151);
            this.ProgressBarFiles.Name = "ProgressBarFiles";
            this.ProgressBarFiles.Size = new System.Drawing.Size(592, 23);
            this.ProgressBarFiles.TabIndex = 9;
            // 
            // backgroundWorker1
            // 
            this.backgroundWorker1.DoWork += new System.ComponentModel.DoWorkEventHandler(this.backgroundWorker1_DoWork);
            this.backgroundWorker1.ProgressChanged += new System.ComponentModel.ProgressChangedEventHandler(this.backgroundWorker1_ProgressChanged);
            this.backgroundWorker1.RunWorkerCompleted += new System.ComponentModel.RunWorkerCompletedEventHandler(this.backgroundWorker1_RunWorkerCompleted);
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(3, 8);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(88, 13);
            this.label3.TabIndex = 13;
            this.label3.Text = "Seleccionar Año:";
            // 
            // ComboboxYears
            // 
            this.ComboboxYears.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.ComboboxYears.FormattingEnabled = true;
            this.ComboboxYears.Location = new System.Drawing.Point(95, 4);
            this.ComboboxYears.Name = "ComboboxYears";
            this.ComboboxYears.Size = new System.Drawing.Size(152, 21);
            this.ComboboxYears.Sorted = true;
            this.ComboboxYears.TabIndex = 12;
            this.ComboboxYears.SelectedIndexChanged += new System.EventHandler(this.ComboboxYears_SelectedIndexChanged);
            // 
            // LoadIssues
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.SystemColors.InactiveCaption;
            this.Controls.Add(this.label3);
            this.Controls.Add(this.ComboboxYears);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.ProgressBarFiles);
            this.Controls.Add(this.ButtonGetExcel);
            this.Controls.Add(this.TextboxPath);
            this.Controls.Add(this.ButtonGetIssues);
            this.Name = "LoadIssues";
            this.Size = new System.Drawing.Size(700, 180);
            this.Load += new System.EventHandler(this.LoadIssues_Load);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.TextBox TextboxPath;
        private System.Windows.Forms.Button ButtonGetIssues;
        private System.Windows.Forms.Button ButtonGetExcel;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.ProgressBar ProgressBarFiles;
        private System.ComponentModel.BackgroundWorker backgroundWorker1;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.ComboBox ComboboxYears;
    }
}
