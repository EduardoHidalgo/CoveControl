namespace MasterCoveControl
{
    partial class Stats
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
            this.ComboboxRelations = new System.Windows.Forms.ComboBox();
            this.label1 = new System.Windows.Forms.Label();
            this.BoxReferencesTotal = new System.Windows.Forms.TextBox();
            this.BoxReferencesFull = new System.Windows.Forms.TextBox();
            this.BoxAcuseFull = new System.Windows.Forms.TextBox();
            this.BoxAcuseUnfull = new System.Windows.Forms.TextBox();
            this.label2 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.label5 = new System.Windows.Forms.Label();
            this.ComboboxClients = new System.Windows.Forms.ComboBox();
            this.label6 = new System.Windows.Forms.Label();
            this.label7 = new System.Windows.Forms.Label();
            this.label8 = new System.Windows.Forms.Label();
            this.BoxAcuseEmpty = new System.Windows.Forms.TextBox();
            this.BoxAcuseWrong = new System.Windows.Forms.TextBox();
            this.label9 = new System.Windows.Forms.Label();
            this.BoxReferencesWrong = new System.Windows.Forms.TextBox();
            this.label10 = new System.Windows.Forms.Label();
            this.BoxReferencesUnfull = new System.Windows.Forms.TextBox();
            this.label11 = new System.Windows.Forms.Label();
            this.label12 = new System.Windows.Forms.Label();
            this.BoxDetailEmpty = new System.Windows.Forms.TextBox();
            this.BoxDetailWrong = new System.Windows.Forms.TextBox();
            this.label13 = new System.Windows.Forms.Label();
            this.label14 = new System.Windows.Forms.Label();
            this.BoxDetailUnfull = new System.Windows.Forms.TextBox();
            this.BoxDetailFull = new System.Windows.Forms.TextBox();
            this.SuspendLayout();
            // 
            // ComboboxRelations
            // 
            this.ComboboxRelations.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.ComboboxRelations.FormattingEnabled = true;
            this.ComboboxRelations.Location = new System.Drawing.Point(122, 3);
            this.ComboboxRelations.MaxDropDownItems = 14;
            this.ComboboxRelations.Name = "ComboboxRelations";
            this.ComboboxRelations.Size = new System.Drawing.Size(120, 21);
            this.ComboboxRelations.Sorted = true;
            this.ComboboxRelations.TabIndex = 1;
            this.ComboboxRelations.SelectedIndexChanged += new System.EventHandler(this.ComboboxRelations_SelectedIndexChanged);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(9, 7);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(111, 13);
            this.label1.TabIndex = 1;
            this.label1.Text = "Seleccionar Relación:";
            // 
            // BoxReferencesTotal
            // 
            this.BoxReferencesTotal.Enabled = false;
            this.BoxReferencesTotal.Location = new System.Drawing.Point(137, 58);
            this.BoxReferencesTotal.Name = "BoxReferencesTotal";
            this.BoxReferencesTotal.Size = new System.Drawing.Size(100, 20);
            this.BoxReferencesTotal.TabIndex = 0;
            this.BoxReferencesTotal.TextChanged += new System.EventHandler(this.BoxReferenceTotal_TextChanged);
            // 
            // BoxReferencesFull
            // 
            this.BoxReferencesFull.Enabled = false;
            this.BoxReferencesFull.Location = new System.Drawing.Point(137, 88);
            this.BoxReferencesFull.Name = "BoxReferencesFull";
            this.BoxReferencesFull.Size = new System.Drawing.Size(100, 20);
            this.BoxReferencesFull.TabIndex = 0;
            // 
            // BoxAcuseFull
            // 
            this.BoxAcuseFull.Enabled = false;
            this.BoxAcuseFull.Location = new System.Drawing.Point(367, 59);
            this.BoxAcuseFull.Name = "BoxAcuseFull";
            this.BoxAcuseFull.Size = new System.Drawing.Size(100, 20);
            this.BoxAcuseFull.TabIndex = 0;
            // 
            // BoxAcuseUnfull
            // 
            this.BoxAcuseUnfull.Enabled = false;
            this.BoxAcuseUnfull.Location = new System.Drawing.Point(367, 88);
            this.BoxAcuseUnfull.Name = "BoxAcuseUnfull";
            this.BoxAcuseUnfull.Size = new System.Drawing.Size(100, 20);
            this.BoxAcuseUnfull.TabIndex = 0;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(9, 62);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(105, 13);
            this.label2.TabIndex = 0;
            this.label2.Text = "Referencias Totales:";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(9, 92);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(119, 13);
            this.label3.TabIndex = 0;
            this.label3.Text = "Referencias Completas:";
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(248, 62);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(97, 13);
            this.label4.TabIndex = 0;
            this.label4.Text = "Acuses Completos:";
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(249, 7);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(101, 13);
            this.label5.TabIndex = 10;
            this.label5.Text = "Seleccionar Cliente:";
            // 
            // ComboboxClients
            // 
            this.ComboboxClients.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.ComboboxClients.FormattingEnabled = true;
            this.ComboboxClients.Location = new System.Drawing.Point(353, 3);
            this.ComboboxClients.MaxDropDownItems = 14;
            this.ComboboxClients.Name = "ComboboxClients";
            this.ComboboxClients.Size = new System.Drawing.Size(344, 21);
            this.ComboboxClients.Sorted = true;
            this.ComboboxClients.TabIndex = 2;
            this.ComboboxClients.SelectedIndexChanged += new System.EventHandler(this.ComboboxClients_SelectedIndexChanged);
            this.ComboboxClients.TextChanged += new System.EventHandler(this.ComboboxClients_TextChanged);
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Location = new System.Drawing.Point(248, 92);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(105, 13);
            this.label6.TabIndex = 0;
            this.label6.Text = "Acuses Incompletos:";
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.Location = new System.Drawing.Point(248, 150);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(82, 13);
            this.label7.TabIndex = 0;
            this.label7.Text = "Acuses Vacíos:";
            // 
            // label8
            // 
            this.label8.AutoSize = true;
            this.label8.Location = new System.Drawing.Point(248, 122);
            this.label8.Name = "label8";
            this.label8.Size = new System.Drawing.Size(83, 13);
            this.label8.TabIndex = 0;
            this.label8.Text = "Acuses Fallidos:";
            // 
            // BoxAcuseEmpty
            // 
            this.BoxAcuseEmpty.Enabled = false;
            this.BoxAcuseEmpty.Location = new System.Drawing.Point(367, 148);
            this.BoxAcuseEmpty.Name = "BoxAcuseEmpty";
            this.BoxAcuseEmpty.Size = new System.Drawing.Size(100, 20);
            this.BoxAcuseEmpty.TabIndex = 0;
            // 
            // BoxAcuseWrong
            // 
            this.BoxAcuseWrong.Enabled = false;
            this.BoxAcuseWrong.Location = new System.Drawing.Point(367, 118);
            this.BoxAcuseWrong.Name = "BoxAcuseWrong";
            this.BoxAcuseWrong.Size = new System.Drawing.Size(100, 20);
            this.BoxAcuseWrong.TabIndex = 0;
            // 
            // label9
            // 
            this.label9.AutoSize = true;
            this.label9.Location = new System.Drawing.Point(9, 150);
            this.label9.Name = "label9";
            this.label9.Size = new System.Drawing.Size(105, 13);
            this.label9.TabIndex = 0;
            this.label9.Text = "Referencias Fallidas:";
            // 
            // BoxReferencesWrong
            // 
            this.BoxReferencesWrong.Enabled = false;
            this.BoxReferencesWrong.Location = new System.Drawing.Point(137, 148);
            this.BoxReferencesWrong.Name = "BoxReferencesWrong";
            this.BoxReferencesWrong.Size = new System.Drawing.Size(100, 20);
            this.BoxReferencesWrong.TabIndex = 0;
            // 
            // label10
            // 
            this.label10.AutoSize = true;
            this.label10.Location = new System.Drawing.Point(9, 122);
            this.label10.Name = "label10";
            this.label10.Size = new System.Drawing.Size(127, 13);
            this.label10.TabIndex = 0;
            this.label10.Text = "Referencias Incompletas:";
            // 
            // BoxReferencesUnfull
            // 
            this.BoxReferencesUnfull.Enabled = false;
            this.BoxReferencesUnfull.Location = new System.Drawing.Point(137, 118);
            this.BoxReferencesUnfull.Name = "BoxReferencesUnfull";
            this.BoxReferencesUnfull.Size = new System.Drawing.Size(100, 20);
            this.BoxReferencesUnfull.TabIndex = 0;
            // 
            // label11
            // 
            this.label11.AutoSize = true;
            this.label11.Location = new System.Drawing.Point(473, 150);
            this.label11.Name = "label11";
            this.label11.Size = new System.Drawing.Size(85, 13);
            this.label11.TabIndex = 11;
            this.label11.Text = "Detalles Vacíos:";
            // 
            // label12
            // 
            this.label12.AutoSize = true;
            this.label12.Location = new System.Drawing.Point(473, 122);
            this.label12.Name = "label12";
            this.label12.Size = new System.Drawing.Size(86, 13);
            this.label12.TabIndex = 12;
            this.label12.Text = "Detalles Fallidos:";
            // 
            // BoxDetailEmpty
            // 
            this.BoxDetailEmpty.Enabled = false;
            this.BoxDetailEmpty.Location = new System.Drawing.Point(592, 148);
            this.BoxDetailEmpty.Name = "BoxDetailEmpty";
            this.BoxDetailEmpty.Size = new System.Drawing.Size(100, 20);
            this.BoxDetailEmpty.TabIndex = 13;
            // 
            // BoxDetailWrong
            // 
            this.BoxDetailWrong.Enabled = false;
            this.BoxDetailWrong.Location = new System.Drawing.Point(592, 118);
            this.BoxDetailWrong.Name = "BoxDetailWrong";
            this.BoxDetailWrong.Size = new System.Drawing.Size(100, 20);
            this.BoxDetailWrong.TabIndex = 14;
            // 
            // label13
            // 
            this.label13.AutoSize = true;
            this.label13.Location = new System.Drawing.Point(473, 92);
            this.label13.Name = "label13";
            this.label13.Size = new System.Drawing.Size(108, 13);
            this.label13.TabIndex = 15;
            this.label13.Text = "Detalles Incompletos:";
            // 
            // label14
            // 
            this.label14.AutoSize = true;
            this.label14.Location = new System.Drawing.Point(473, 62);
            this.label14.Name = "label14";
            this.label14.Size = new System.Drawing.Size(100, 13);
            this.label14.TabIndex = 16;
            this.label14.Text = "Detalles Completos:";
            // 
            // BoxDetailUnfull
            // 
            this.BoxDetailUnfull.Enabled = false;
            this.BoxDetailUnfull.Location = new System.Drawing.Point(592, 88);
            this.BoxDetailUnfull.Name = "BoxDetailUnfull";
            this.BoxDetailUnfull.Size = new System.Drawing.Size(100, 20);
            this.BoxDetailUnfull.TabIndex = 17;
            // 
            // BoxDetailFull
            // 
            this.BoxDetailFull.Enabled = false;
            this.BoxDetailFull.Location = new System.Drawing.Point(592, 59);
            this.BoxDetailFull.Name = "BoxDetailFull";
            this.BoxDetailFull.Size = new System.Drawing.Size(100, 20);
            this.BoxDetailFull.TabIndex = 18;
            // 
            // Stats
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.SystemColors.InactiveCaption;
            this.Controls.Add(this.label11);
            this.Controls.Add(this.label12);
            this.Controls.Add(this.BoxDetailEmpty);
            this.Controls.Add(this.BoxDetailWrong);
            this.Controls.Add(this.label13);
            this.Controls.Add(this.label14);
            this.Controls.Add(this.BoxDetailUnfull);
            this.Controls.Add(this.BoxDetailFull);
            this.Controls.Add(this.label10);
            this.Controls.Add(this.BoxReferencesUnfull);
            this.Controls.Add(this.label9);
            this.Controls.Add(this.BoxReferencesWrong);
            this.Controls.Add(this.label7);
            this.Controls.Add(this.label8);
            this.Controls.Add(this.BoxAcuseEmpty);
            this.Controls.Add(this.BoxAcuseWrong);
            this.Controls.Add(this.label6);
            this.Controls.Add(this.label5);
            this.Controls.Add(this.ComboboxClients);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.BoxAcuseUnfull);
            this.Controls.Add(this.BoxAcuseFull);
            this.Controls.Add(this.BoxReferencesFull);
            this.Controls.Add(this.BoxReferencesTotal);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.ComboboxRelations);
            this.Name = "Stats";
            this.Size = new System.Drawing.Size(700, 180);
            this.Load += new System.EventHandler(this.Stats_Load);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.ComboBox ComboboxRelations;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.TextBox BoxReferencesTotal;
        private System.Windows.Forms.TextBox BoxReferencesFull;
        private System.Windows.Forms.TextBox BoxAcuseFull;
        private System.Windows.Forms.TextBox BoxAcuseUnfull;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.ComboBox ComboboxClients;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.Label label8;
        private System.Windows.Forms.TextBox BoxAcuseEmpty;
        private System.Windows.Forms.TextBox BoxAcuseWrong;
        private System.Windows.Forms.Label label9;
        private System.Windows.Forms.TextBox BoxReferencesWrong;
        private System.Windows.Forms.Label label10;
        private System.Windows.Forms.TextBox BoxReferencesUnfull;
        private System.Windows.Forms.Label label11;
        private System.Windows.Forms.Label label12;
        private System.Windows.Forms.TextBox BoxDetailEmpty;
        private System.Windows.Forms.TextBox BoxDetailWrong;
        private System.Windows.Forms.Label label13;
        private System.Windows.Forms.Label label14;
        private System.Windows.Forms.TextBox BoxDetailUnfull;
        private System.Windows.Forms.TextBox BoxDetailFull;
    }
}
