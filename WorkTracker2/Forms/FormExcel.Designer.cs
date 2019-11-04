namespace WorkTracker2.Forms
{
    partial class FormExcel
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
            this.textDirectory = new System.Windows.Forms.TextBox();
            this.bBrowse = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // textDirectory
            // 
            this.textDirectory.Location = new System.Drawing.Point(13, 13);
            this.textDirectory.Name = "textDirectory";
            this.textDirectory.Size = new System.Drawing.Size(100, 20);
            this.textDirectory.TabIndex = 0;
            // 
            // bBrowse
            // 
            this.bBrowse.Location = new System.Drawing.Point(120, 13);
            this.bBrowse.Name = "bBrowse";
            this.bBrowse.Size = new System.Drawing.Size(75, 23);
            this.bBrowse.TabIndex = 1;
            this.bBrowse.Text = "button1";
            this.bBrowse.UseVisualStyleBackColor = true;
            // 
            // FormExcel
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(800, 450);
            this.Controls.Add(this.bBrowse);
            this.Controls.Add(this.textDirectory);
            this.Name = "FormExcel";
            this.Text = "FormExcel";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.TextBox textDirectory;
        private System.Windows.Forms.Button bBrowse;
    }
}