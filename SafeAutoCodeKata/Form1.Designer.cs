﻿namespace SafeAutoCodeKata
{
    partial class CodeKata
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
            this.BtnUpload = new System.Windows.Forms.Button();
            this.openFileDialog1 = new System.Windows.Forms.OpenFileDialog();
            this.TxbProccess = new System.Windows.Forms.TextBox();
            this.BtnReport = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // BtnUpload
            // 
            this.BtnUpload.Location = new System.Drawing.Point(64, 56);
            this.BtnUpload.Name = "BtnUpload";
            this.BtnUpload.Size = new System.Drawing.Size(119, 23);
            this.BtnUpload.TabIndex = 0;
            this.BtnUpload.Text = "Upload File";
            this.BtnUpload.UseVisualStyleBackColor = true;
            this.BtnUpload.Click += new System.EventHandler(this.BtnUpload_Click);
            // 
            // TxbProccess
            // 
            this.TxbProccess.Location = new System.Drawing.Point(64, 123);
            this.TxbProccess.Multiline = true;
            this.TxbProccess.Name = "TxbProccess";
            this.TxbProccess.Size = new System.Drawing.Size(441, 412);
            this.TxbProccess.TabIndex = 1;
            // 
            // BtnReport
            // 
            this.BtnReport.Location = new System.Drawing.Point(64, 85);
            this.BtnReport.Name = "BtnReport";
            this.BtnReport.Size = new System.Drawing.Size(119, 23);
            this.BtnReport.TabIndex = 2;
            this.BtnReport.Text = "Show Report";
            this.BtnReport.UseVisualStyleBackColor = true;
            this.BtnReport.Click += new System.EventHandler(this.BtnReport_Click);
            // 
            // CodeKata
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(572, 591);
            this.Controls.Add(this.BtnReport);
            this.Controls.Add(this.TxbProccess);
            this.Controls.Add(this.BtnUpload);
            this.Name = "CodeKata";
            this.Text = "CodeKata Drivers and Trips";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button BtnUpload;
        private System.Windows.Forms.OpenFileDialog openFileDialog1;
        private System.Windows.Forms.TextBox TxbProccess;
        private System.Windows.Forms.Button BtnReport;
    }
}

