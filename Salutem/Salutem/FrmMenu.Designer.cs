namespace Salutem
{
    partial class FrmMenu
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
            this.cadsToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.cadastroDeClientesToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.cadastroDeVendedorToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.exportaçãoToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.exportaçãDeClientesToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.exportaçãoDeVendedoresToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.executarToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.executarDistribuiçãoDeClientesToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.sairToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.menuStrip1.SuspendLayout();
            this.SuspendLayout();
            // 
            // menuStrip1
            // 
            this.menuStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.cadsToolStripMenuItem,
            this.exportaçãoToolStripMenuItem,
            this.executarToolStripMenuItem,
            this.sairToolStripMenuItem});
            this.menuStrip1.Location = new System.Drawing.Point(0, 0);
            this.menuStrip1.Name = "menuStrip1";
            this.menuStrip1.Size = new System.Drawing.Size(879, 24);
            this.menuStrip1.TabIndex = 0;
            this.menuStrip1.Text = "menuStrip1";
            // 
            // cadsToolStripMenuItem
            // 
            this.cadsToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.cadastroDeClientesToolStripMenuItem,
            this.cadastroDeVendedorToolStripMenuItem});
            this.cadsToolStripMenuItem.Name = "cadsToolStripMenuItem";
            this.cadsToolStripMenuItem.Size = new System.Drawing.Size(71, 20);
            this.cadsToolStripMenuItem.Text = "Cadastros";
            // 
            // cadastroDeClientesToolStripMenuItem
            // 
            this.cadastroDeClientesToolStripMenuItem.Name = "cadastroDeClientesToolStripMenuItem";
            this.cadastroDeClientesToolStripMenuItem.Size = new System.Drawing.Size(190, 22);
            this.cadastroDeClientesToolStripMenuItem.Text = "Cadastro de Clientes";
            this.cadastroDeClientesToolStripMenuItem.Click += new System.EventHandler(this.cadastroDeClientesToolStripMenuItem_Click);
            // 
            // cadastroDeVendedorToolStripMenuItem
            // 
            this.cadastroDeVendedorToolStripMenuItem.Name = "cadastroDeVendedorToolStripMenuItem";
            this.cadastroDeVendedorToolStripMenuItem.Size = new System.Drawing.Size(190, 22);
            this.cadastroDeVendedorToolStripMenuItem.Text = "Cadastro de Vendedor";
            this.cadastroDeVendedorToolStripMenuItem.Click += new System.EventHandler(this.cadastroDeVendedorToolStripMenuItem_Click);
            // 
            // exportaçãoToolStripMenuItem
            // 
            this.exportaçãoToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.exportaçãDeClientesToolStripMenuItem,
            this.exportaçãoDeVendedoresToolStripMenuItem});
            this.exportaçãoToolStripMenuItem.Name = "exportaçãoToolStripMenuItem";
            this.exportaçãoToolStripMenuItem.Size = new System.Drawing.Size(78, 20);
            this.exportaçãoToolStripMenuItem.Text = "Exportação";
            // 
            // exportaçãDeClientesToolStripMenuItem
            // 
            this.exportaçãDeClientesToolStripMenuItem.Name = "exportaçãDeClientesToolStripMenuItem";
            this.exportaçãDeClientesToolStripMenuItem.Size = new System.Drawing.Size(213, 22);
            this.exportaçãDeClientesToolStripMenuItem.Text = "Exportação de Clientes";
            this.exportaçãDeClientesToolStripMenuItem.Click += new System.EventHandler(this.exportaçãDeClientesToolStripMenuItem_Click);
            // 
            // exportaçãoDeVendedoresToolStripMenuItem
            // 
            this.exportaçãoDeVendedoresToolStripMenuItem.Name = "exportaçãoDeVendedoresToolStripMenuItem";
            this.exportaçãoDeVendedoresToolStripMenuItem.Size = new System.Drawing.Size(213, 22);
            this.exportaçãoDeVendedoresToolStripMenuItem.Text = "Exportação de Vendedores";
            // 
            // executarToolStripMenuItem
            // 
            this.executarToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.executarDistribuiçãoDeClientesToolStripMenuItem});
            this.executarToolStripMenuItem.Name = "executarToolStripMenuItem";
            this.executarToolStripMenuItem.Size = new System.Drawing.Size(64, 20);
            this.executarToolStripMenuItem.Text = "Executar";
            // 
            // executarDistribuiçãoDeClientesToolStripMenuItem
            // 
            this.executarDistribuiçãoDeClientesToolStripMenuItem.Name = "executarDistribuiçãoDeClientesToolStripMenuItem";
            this.executarDistribuiçãoDeClientesToolStripMenuItem.Size = new System.Drawing.Size(246, 22);
            this.executarDistribuiçãoDeClientesToolStripMenuItem.Text = "Executar Distribuição de Clientes";
            // 
            // sairToolStripMenuItem
            // 
            this.sairToolStripMenuItem.Name = "sairToolStripMenuItem";
            this.sairToolStripMenuItem.Size = new System.Drawing.Size(38, 20);
            this.sairToolStripMenuItem.Text = "Sair";
            // 
            // FrmMenu
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(879, 514);
            this.Controls.Add(this.menuStrip1);
            this.MainMenuStrip = this.menuStrip1;
            this.Name = "FrmMenu";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Distribuidora de Bebidas";
            this.WindowState = System.Windows.Forms.FormWindowState.Maximized;
            this.menuStrip1.ResumeLayout(false);
            this.menuStrip1.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.MenuStrip menuStrip1;
        private System.Windows.Forms.ToolStripMenuItem cadsToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem cadastroDeClientesToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem cadastroDeVendedorToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem exportaçãoToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem exportaçãDeClientesToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem exportaçãoDeVendedoresToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem executarToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem executarDistribuiçãoDeClientesToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem sairToolStripMenuItem;
    }
}

