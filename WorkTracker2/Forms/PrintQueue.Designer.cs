namespace WorkTracker2.Core
{
    partial class PrintQueue
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
            this.listPrintJobs = new System.Windows.Forms.ListBox();
            this.backgroundWorker1 = new System.ComponentModel.BackgroundWorker();
            this.SuspendLayout();
            // 
            // listPrintJobs
            // 
            this.listPrintJobs.FormattingEnabled = true;
            this.listPrintJobs.Location = new System.Drawing.Point(13, 13);
            this.listPrintJobs.Name = "listPrintJobs";
            this.listPrintJobs.Size = new System.Drawing.Size(221, 251);
            this.listPrintJobs.TabIndex = 0;
            // 
            // backgroundWorker1
            // 
            this.backgroundWorker1.DoWork += new System.ComponentModel.DoWorkEventHandler(this.BackgroundWorker1_DoWork);
            this.backgroundWorker1.RunWorkerCompleted += new System.ComponentModel.RunWorkerCompletedEventHandler(this.BackgroundWorker1_RunWorkerCompleted);
            // 
            // PrintQueue
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(248, 277);
            this.Controls.Add(this.listPrintJobs);
            this.Name = "PrintQueue";
            this.Text = "Print Queue";
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.ListBox listPrintJobs;
        private System.ComponentModel.BackgroundWorker backgroundWorker1;
    }
}