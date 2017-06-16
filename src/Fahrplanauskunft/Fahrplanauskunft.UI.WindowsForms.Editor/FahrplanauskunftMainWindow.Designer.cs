namespace Fahrplanauskunft.UI.WindowsForms.Editor
{
    partial class FahrplanauskunftMainWindow
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
            if(disposing && (components != null))
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
            this.tabPageLinie = new System.Windows.Forms.TabPage();
            this.tabControlObjekte = new System.Windows.Forms.TabControl();
            this.tabControlObjekte.SuspendLayout();
            this.SuspendLayout();
            // 
            // tabPageLinie
            // 
            this.tabPageLinie.Location = new System.Drawing.Point(4, 22);
            this.tabPageLinie.Name = "tabPageLinie";
            this.tabPageLinie.Padding = new System.Windows.Forms.Padding(3);
            this.tabPageLinie.Size = new System.Drawing.Size(1000, 703);
            this.tabPageLinie.TabIndex = 0;
            this.tabPageLinie.Text = "Linie";
            this.tabPageLinie.UseVisualStyleBackColor = true;
            // 
            // tabControlObjekte
            // 
            this.tabControlObjekte.Controls.Add(this.tabPageLinie);
            this.tabControlObjekte.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tabControlObjekte.Location = new System.Drawing.Point(0, 0);
            this.tabControlObjekte.Name = "tabControlObjekte";
            this.tabControlObjekte.SelectedIndex = 0;
            this.tabControlObjekte.Size = new System.Drawing.Size(1008, 729);
            this.tabControlObjekte.TabIndex = 0;
            // 
            // FahrplanauskunftMainWindow
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1008, 729);
            this.Controls.Add(this.tabControlObjekte);
            this.Name = "FahrplanauskunftMainWindow";
            this.Text = "Fahrplanauskunft.Editor";
            this.tabControlObjekte.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.TabPage tabPageLinie;
        private System.Windows.Forms.TabControl tabControlObjekte;
    }
}

