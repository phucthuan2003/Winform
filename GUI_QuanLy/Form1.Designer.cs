namespace GUI_QuanLy
{
    partial class Form1
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(Form1));
            this.panelAll = new Bunifu.UI.WinForms.BunifuPanel();
            this.headerControl1 = new GUI_QuanLy.HeaderControl();
            this.sidebarControl1 = new GUI_QuanLy.SidebarControl();
            this.SuspendLayout();
            // 
            // panelAll
            // 
            this.panelAll.BackgroundColor = System.Drawing.Color.Transparent;
            this.panelAll.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("panelAll.BackgroundImage")));
            this.panelAll.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.panelAll.BorderColor = System.Drawing.Color.Transparent;
            this.panelAll.BorderRadius = 3;
            this.panelAll.BorderThickness = 1;
            this.panelAll.Location = new System.Drawing.Point(206, 60);
            this.panelAll.Margin = new System.Windows.Forms.Padding(2);
            this.panelAll.Name = "panelAll";
            this.panelAll.ShowBorders = true;
            this.panelAll.Size = new System.Drawing.Size(1234, 853);
            this.panelAll.TabIndex = 2;
            // 
            // headerControl1
            // 
            this.headerControl1.Dock = System.Windows.Forms.DockStyle.Top;
            this.headerControl1.Location = new System.Drawing.Point(270, 0);
            this.headerControl1.Margin = new System.Windows.Forms.Padding(2, 3, 2, 3);
            this.headerControl1.Name = "headerControl1";
            this.headerControl1.Size = new System.Drawing.Size(1170, 62);
            this.headerControl1.TabIndex = 1;
            // 
            // sidebarControl1
            // 
            this.sidebarControl1.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(83)))), ((int)(((byte)(64)))), ((int)(((byte)(118)))));
            this.sidebarControl1.Dock = System.Windows.Forms.DockStyle.Left;
            this.sidebarControl1.Location = new System.Drawing.Point(0, 0);
            this.sidebarControl1.Margin = new System.Windows.Forms.Padding(2, 3, 2, 3);
            this.sidebarControl1.Name = "sidebarControl1";
            this.sidebarControl1.Size = new System.Drawing.Size(270, 913);
            this.sidebarControl1.TabIndex = 0;
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(96F, 96F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Dpi;
            this.ClientSize = new System.Drawing.Size(1440, 913);
            this.Controls.Add(this.panelAll);
            this.Controls.Add(this.headerControl1);
            this.Controls.Add(this.sidebarControl1);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.Margin = new System.Windows.Forms.Padding(2, 3, 2, 3);
            this.Name = "Form1";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Form1";
            this.ResumeLayout(false);

        }

        #endregion

        private SidebarControl sidebarControl1;
        private HeaderControl headerControl1;
        private Bunifu.UI.WinForms.BunifuPanel panelAll;
    }
}

