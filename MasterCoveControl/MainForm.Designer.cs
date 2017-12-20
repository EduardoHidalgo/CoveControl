namespace MasterCoveControl
{
    partial class MainForm
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(MainForm));
            this.RichTextBoxDebug = new System.Windows.Forms.RichTextBox();
            this.ButtonCreateConfig = new System.Windows.Forms.Button();
            this.ButtonLoadFiles = new System.Windows.Forms.Button();
            this.ButtonExit = new System.Windows.Forms.Button();
            this.ButtonGenerateReports = new System.Windows.Forms.Button();
            this.ButtonReissues = new System.Windows.Forms.Button();
            this.ButtonImport = new System.Windows.Forms.Button();
            this.ButtonExportClient = new System.Windows.Forms.Button();
            this.ButtonLoadToSystem = new System.Windows.Forms.Button();
            this.PanelContainer = new System.Windows.Forms.Panel();
            this.ButtonStats = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // RichTextBoxDebug
            // 
            this.RichTextBoxDebug.Location = new System.Drawing.Point(197, 187);
            this.RichTextBoxDebug.Name = "RichTextBoxDebug";
            this.RichTextBoxDebug.ScrollBars = System.Windows.Forms.RichTextBoxScrollBars.ForcedVertical;
            this.RichTextBoxDebug.Size = new System.Drawing.Size(700, 108);
            this.RichTextBoxDebug.TabIndex = 0;
            this.RichTextBoxDebug.Text = "";
            // 
            // ButtonCreateConfig
            // 
            this.ButtonCreateConfig.FlatStyle = System.Windows.Forms.FlatStyle.System;
            this.ButtonCreateConfig.Location = new System.Drawing.Point(4, 6);
            this.ButtonCreateConfig.Name = "ButtonCreateConfig";
            this.ButtonCreateConfig.Size = new System.Drawing.Size(188, 23);
            this.ButtonCreateConfig.TabIndex = 1;
            this.ButtonCreateConfig.Text = "Crear Nueva Configuración General";
            this.ButtonCreateConfig.UseVisualStyleBackColor = true;
            this.ButtonCreateConfig.Click += new System.EventHandler(this.ButtonCreateConfig_Click);
            // 
            // ButtonLoadFiles
            // 
            this.ButtonLoadFiles.Location = new System.Drawing.Point(4, 64);
            this.ButtonLoadFiles.Name = "ButtonLoadFiles";
            this.ButtonLoadFiles.Size = new System.Drawing.Size(188, 23);
            this.ButtonLoadFiles.TabIndex = 3;
            this.ButtonLoadFiles.Text = "Cargar Acuses y Detalles";
            this.ButtonLoadFiles.UseVisualStyleBackColor = true;
            this.ButtonLoadFiles.Click += new System.EventHandler(this.ButtonLoadFiles_Click);
            // 
            // ButtonExit
            // 
            this.ButtonExit.BackColor = System.Drawing.SystemColors.ControlLight;
            this.ButtonExit.FlatStyle = System.Windows.Forms.FlatStyle.System;
            this.ButtonExit.Location = new System.Drawing.Point(35, 272);
            this.ButtonExit.Name = "ButtonExit";
            this.ButtonExit.Size = new System.Drawing.Size(120, 23);
            this.ButtonExit.TabIndex = 9;
            this.ButtonExit.Text = "Salir de la Aplicación";
            this.ButtonExit.UseVisualStyleBackColor = false;
            this.ButtonExit.Click += new System.EventHandler(this.ButtonExit_Click);
            // 
            // ButtonGenerateReports
            // 
            this.ButtonGenerateReports.Enabled = false;
            this.ButtonGenerateReports.Location = new System.Drawing.Point(4, 122);
            this.ButtonGenerateReports.Name = "ButtonGenerateReports";
            this.ButtonGenerateReports.Size = new System.Drawing.Size(188, 23);
            this.ButtonGenerateReports.TabIndex = 5;
            this.ButtonGenerateReports.Text = "Generar Reportes";
            this.ButtonGenerateReports.UseVisualStyleBackColor = true;
            this.ButtonGenerateReports.Click += new System.EventHandler(this.ButtonGenerateReports_Click);
            // 
            // ButtonReissues
            // 
            this.ButtonReissues.Location = new System.Drawing.Point(4, 93);
            this.ButtonReissues.Name = "ButtonReissues";
            this.ButtonReissues.Size = new System.Drawing.Size(188, 23);
            this.ButtonReissues.TabIndex = 4;
            this.ButtonReissues.Text = "Cargar Coves Muertos";
            this.ButtonReissues.UseVisualStyleBackColor = true;
            this.ButtonReissues.Click += new System.EventHandler(this.ButtonReissues_Click);
            // 
            // ButtonImport
            // 
            this.ButtonImport.Location = new System.Drawing.Point(4, 35);
            this.ButtonImport.Name = "ButtonImport";
            this.ButtonImport.Size = new System.Drawing.Size(188, 23);
            this.ButtonImport.TabIndex = 2;
            this.ButtonImport.Text = "Importar Relación Excel";
            this.ButtonImport.UseVisualStyleBackColor = true;
            this.ButtonImport.Click += new System.EventHandler(this.ButtonImport_Click);
            // 
            // ButtonExportClient
            // 
            this.ButtonExportClient.Enabled = false;
            this.ButtonExportClient.Location = new System.Drawing.Point(4, 151);
            this.ButtonExportClient.Name = "ButtonExportClient";
            this.ButtonExportClient.Size = new System.Drawing.Size(188, 23);
            this.ButtonExportClient.TabIndex = 6;
            this.ButtonExportClient.Text = "Exportar Cliente";
            this.ButtonExportClient.UseVisualStyleBackColor = true;
            this.ButtonExportClient.Click += new System.EventHandler(this.ButtonExportClient_Click);
            // 
            // ButtonLoadToSystem
            // 
            this.ButtonLoadToSystem.Enabled = false;
            this.ButtonLoadToSystem.Location = new System.Drawing.Point(4, 180);
            this.ButtonLoadToSystem.Name = "ButtonLoadToSystem";
            this.ButtonLoadToSystem.Size = new System.Drawing.Size(188, 23);
            this.ButtonLoadToSystem.TabIndex = 7;
            this.ButtonLoadToSystem.Text = "Crear Carpeta de Carga";
            this.ButtonLoadToSystem.UseVisualStyleBackColor = true;
            this.ButtonLoadToSystem.Click += new System.EventHandler(this.ButtonLoadToSystem_Click);
            // 
            // PanelContainer
            // 
            this.PanelContainer.BackColor = System.Drawing.Color.White;
            this.PanelContainer.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("PanelContainer.BackgroundImage")));
            this.PanelContainer.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Zoom;
            this.PanelContainer.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            this.PanelContainer.Location = new System.Drawing.Point(197, 3);
            this.PanelContainer.Name = "PanelContainer";
            this.PanelContainer.Size = new System.Drawing.Size(700, 180);
            this.PanelContainer.TabIndex = 10;
            // 
            // ButtonStats
            // 
            this.ButtonStats.Location = new System.Drawing.Point(4, 209);
            this.ButtonStats.Name = "ButtonStats";
            this.ButtonStats.Size = new System.Drawing.Size(188, 23);
            this.ButtonStats.TabIndex = 8;
            this.ButtonStats.Text = "Ver Estadísticas";
            this.ButtonStats.UseVisualStyleBackColor = true;
            this.ButtonStats.Click += new System.EventHandler(this.ButtonStats_Click);
            // 
            // MainForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.SystemColors.InactiveCaption;
            this.ClientSize = new System.Drawing.Size(900, 300);
            this.Controls.Add(this.ButtonStats);
            this.Controls.Add(this.PanelContainer);
            this.Controls.Add(this.ButtonLoadToSystem);
            this.Controls.Add(this.ButtonExportClient);
            this.Controls.Add(this.ButtonImport);
            this.Controls.Add(this.ButtonReissues);
            this.Controls.Add(this.ButtonGenerateReports);
            this.Controls.Add(this.ButtonExit);
            this.Controls.Add(this.ButtonLoadFiles);
            this.Controls.Add(this.ButtonCreateConfig);
            this.Controls.Add(this.RichTextBoxDebug);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.Name = "MainForm";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "MasterCoveControl";
            this.Load += new System.EventHandler(this.MainForm_Load);
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.RichTextBox RichTextBoxDebug;
        private System.Windows.Forms.Button ButtonCreateConfig;
        private System.Windows.Forms.Button ButtonLoadFiles;
        private System.Windows.Forms.Button ButtonExit;
        private System.Windows.Forms.Button ButtonGenerateReports;
        private System.Windows.Forms.Button ButtonReissues;
        private System.Windows.Forms.Button ButtonImport;
        private System.Windows.Forms.Button ButtonExportClient;
        private System.Windows.Forms.Button ButtonLoadToSystem;
        private System.Windows.Forms.Panel PanelContainer;
        private System.Windows.Forms.Button ButtonStats;
    }
}

