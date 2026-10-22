namespace WindowsFormsApp2
{
    partial class FrmMenuPrincipal
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
            this.menuStrip1 = new System.Windows.Forms.MenuStrip();
            this.pOINTToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.lIEToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.sTARToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.aREAToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.distanciaMinimaToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.triangulacionToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.menuStrip1.SuspendLayout();
            this.SuspendLayout();
            // 
            // menuStrip1
            // 
            this.menuStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.pOINTToolStripMenuItem,
            this.lIEToolStripMenuItem,
            this.sTARToolStripMenuItem,
            this.aREAToolStripMenuItem,
            this.distanciaMinimaToolStripMenuItem,
            this.triangulacionToolStripMenuItem});
            this.menuStrip1.Location = new System.Drawing.Point(0, 0);
            this.menuStrip1.Name = "menuStrip1";
            this.menuStrip1.Size = new System.Drawing.Size(800, 24);
            this.menuStrip1.TabIndex = 0;
            this.menuStrip1.Text = "menuStrip1";
            // 
            // pOINTToolStripMenuItem
            // 
            this.pOINTToolStripMenuItem.Name = "pOINTToolStripMenuItem";
            this.pOINTToolStripMenuItem.Size = new System.Drawing.Size(54, 20);
            this.pOINTToolStripMenuItem.Text = "POINT";
            this.pOINTToolStripMenuItem.Click += new System.EventHandler(this.pOINTToolStripMenuItem_Click);
            // 
            // lIEToolStripMenuItem
            // 
            this.lIEToolStripMenuItem.Name = "lIEToolStripMenuItem";
            this.lIEToolStripMenuItem.Size = new System.Drawing.Size(43, 20);
            this.lIEToolStripMenuItem.Text = "LINE";
            this.lIEToolStripMenuItem.Click += new System.EventHandler(this.lIEToolStripMenuItem_Click);
            // 
            // sTARToolStripMenuItem
            // 
            this.sTARToolStripMenuItem.Name = "sTARToolStripMenuItem";
            this.sTARToolStripMenuItem.Size = new System.Drawing.Size(46, 20);
            this.sTARToolStripMenuItem.Text = "STAR";
            this.sTARToolStripMenuItem.Click += new System.EventHandler(this.sTARToolStripMenuItem_Click);
            // 
            // aREAToolStripMenuItem
            // 
            this.aREAToolStripMenuItem.Name = "aREAToolStripMenuItem";
            this.aREAToolStripMenuItem.Size = new System.Drawing.Size(46, 20);
            this.aREAToolStripMenuItem.Text = "AREA";
            this.aREAToolStripMenuItem.Click += new System.EventHandler(this.aREAToolStripMenuItem_Click);
            // 
            // distanciaMinimaToolStripMenuItem
            // 
            this.distanciaMinimaToolStripMenuItem.Name = "distanciaMinimaToolStripMenuItem";
            this.distanciaMinimaToolStripMenuItem.Size = new System.Drawing.Size(124, 20);
            this.distanciaMinimaToolStripMenuItem.Text = "DISTANCIA MINIMA";
            this.distanciaMinimaToolStripMenuItem.Click += new System.EventHandler(this.distanciaMinimaToolStripMenuItem_Click);
            // 
            // triangulacionToolStripMenuItem
            // 
            this.triangulacionToolStripMenuItem.Name = "triangulacionToolStripMenuItem";
            this.triangulacionToolStripMenuItem.Size = new System.Drawing.Size(185, 20);
            this.triangulacionToolStripMenuItem.Text = "TRIANGULACION DE POLIGONOS";
            this.triangulacionToolStripMenuItem.Click += new System.EventHandler(this.triangulacionToolStripMenuItem_Click);
            // 
            // Home
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(800, 450);
            this.Controls.Add(this.menuStrip1);
            this.IsMdiContainer = true;
            this.MainMenuStrip = this.menuStrip1;
            this.Name = "FrmMenuPrincipal";
            this.Text = "Home";
            this.menuStrip1.ResumeLayout(false);
            this.menuStrip1.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.MenuStrip menuStrip1;
        private System.Windows.Forms.ToolStripMenuItem pOINTToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem lIEToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem sTARToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem aREAToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem distanciaMinimaToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem triangulacionToolStripMenuItem;
    }
}
