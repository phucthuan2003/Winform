namespace GUI_QuanLy
{
    partial class Report_DoanhThu
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
            this.reportViewer_DoanhThu = new Microsoft.Reporting.WinForms.ReportViewer();
            this.SuspendLayout();
            // 
            // reportViewer_DoanhThu
            // 
            this.reportViewer_DoanhThu.Dock = System.Windows.Forms.DockStyle.Fill;
            this.reportViewer_DoanhThu.Location = new System.Drawing.Point(0, 0);
            this.reportViewer_DoanhThu.Name = "reportViewer_DoanhThu";
            this.reportViewer_DoanhThu.ServerReport.BearerToken = null;
            this.reportViewer_DoanhThu.Size = new System.Drawing.Size(1159, 791);
            this.reportViewer_DoanhThu.TabIndex = 0;
            // 
            // Report_DoanhThu
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1159, 791);
            this.Controls.Add(this.reportViewer_DoanhThu);
            this.Name = "Report_DoanhThu";
            this.Text = "Report_DoanhThu";
            this.Load += new System.EventHandler(this.Report_DoanhThu_Load);
            this.ResumeLayout(false);

        }

        #endregion

        private Microsoft.Reporting.WinForms.ReportViewer reportViewer_DoanhThu;
    }
}