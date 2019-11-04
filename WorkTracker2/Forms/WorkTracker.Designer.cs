namespace WorkTracker2.Core
{
    partial class WorkTracker
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
            this.txtEncorrNumber = new System.Windows.Forms.TextBox();
            this.label1 = new System.Windows.Forms.Label();
            this.listTypes = new System.Windows.Forms.ListBox();
            this.listClients = new System.Windows.Forms.ComboBox();
            this.groupBox2 = new System.Windows.Forms.GroupBox();
            this.textTracking = new System.Windows.Forms.TextBox();
            this.label3 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.textDCName = new System.Windows.Forms.TextBox();
            this.menu = new System.Windows.Forms.MenuStrip();
            this.toolUtilities = new System.Windows.Forms.ToolStripMenuItem();
            this.toolUser = new System.Windows.Forms.ToolStripMenuItem();
            this.toolClients = new System.Windows.Forms.ToolStripMenuItem();
            this.toolReportGenerator = new System.Windows.Forms.ToolStripMenuItem();
            this.toolAddTest = new System.Windows.Forms.ToolStripMenuItem();
            this.helpToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.toolExit = new System.Windows.Forms.ToolStripMenuItem();
            this.gbQ = new System.Windows.Forms.GroupBox();
            this.bAddQ = new System.Windows.Forms.Button();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.label6 = new System.Windows.Forms.Label();
            this.label5 = new System.Windows.Forms.Label();
            this.listRecent = new System.Windows.Forms.ListBox();
            this.groupBox3 = new System.Windows.Forms.GroupBox();
            this.updatesToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.groupBox2.SuspendLayout();
            this.menu.SuspendLayout();
            this.gbQ.SuspendLayout();
            this.groupBox1.SuspendLayout();
            this.groupBox3.SuspendLayout();
            this.SuspendLayout();
            // 
            // txtEncorrNumber
            // 
            this.txtEncorrNumber.Location = new System.Drawing.Point(6, 32);
            this.txtEncorrNumber.Name = "txtEncorrNumber";
            this.txtEncorrNumber.RightToLeft = System.Windows.Forms.RightToLeft.No;
            this.txtEncorrNumber.Size = new System.Drawing.Size(138, 20);
            this.txtEncorrNumber.TabIndex = 0;
            this.txtEncorrNumber.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.TxtEncorrNumber_KeyPress);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(3, 16);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(78, 13);
            this.label1.TabIndex = 1;
            this.label1.Text = "Encorr Number";
            // 
            // listTypes
            // 
            this.listTypes.FormattingEnabled = true;
            this.listTypes.Location = new System.Drawing.Point(6, 110);
            this.listTypes.Name = "listTypes";
            this.listTypes.Size = new System.Drawing.Size(138, 69);
            this.listTypes.TabIndex = 2;
            // 
            // listClients
            // 
            this.listClients.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.listClients.FormattingEnabled = true;
            this.listClients.Location = new System.Drawing.Point(6, 70);
            this.listClients.Name = "listClients";
            this.listClients.Size = new System.Drawing.Size(138, 21);
            this.listClients.TabIndex = 1;
            // 
            // groupBox2
            // 
            this.groupBox2.Controls.Add(this.textTracking);
            this.groupBox2.Controls.Add(this.label3);
            this.groupBox2.Controls.Add(this.label2);
            this.groupBox2.Controls.Add(this.textDCName);
            this.groupBox2.Location = new System.Drawing.Point(170, 27);
            this.groupBox2.Name = "groupBox2";
            this.groupBox2.Size = new System.Drawing.Size(167, 104);
            this.groupBox2.TabIndex = 10;
            this.groupBox2.TabStop = false;
            this.groupBox2.Text = "Additional Information";
            // 
            // textTracking
            // 
            this.textTracking.Location = new System.Drawing.Point(6, 71);
            this.textTracking.Name = "textTracking";
            this.textTracking.Size = new System.Drawing.Size(152, 20);
            this.textTracking.TabIndex = 4;
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(6, 55);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(89, 13);
            this.label3.TabIndex = 30;
            this.label3.Text = "Tracking Number";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(6, 16);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(53, 13);
            this.label2.TabIndex = 29;
            this.label2.Text = "DC Name";
            // 
            // textDCName
            // 
            this.textDCName.Location = new System.Drawing.Point(6, 32);
            this.textDCName.Name = "textDCName";
            this.textDCName.Size = new System.Drawing.Size(152, 20);
            this.textDCName.TabIndex = 3;
            // 
            // menu
            // 
            this.menu.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.toolUtilities,
            this.updatesToolStripMenuItem,
            this.helpToolStripMenuItem,
            this.toolExit});
            this.menu.Location = new System.Drawing.Point(0, 0);
            this.menu.Name = "menu";
            this.menu.Size = new System.Drawing.Size(351, 24);
            this.menu.TabIndex = 21;
            this.menu.Text = "menuStrip1";
            // 
            // toolUtilities
            // 
            this.toolUtilities.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.toolUser,
            this.toolClients,
            this.toolReportGenerator,
            this.toolAddTest});
            this.toolUtilities.Name = "toolUtilities";
            this.toolUtilities.Size = new System.Drawing.Size(58, 20);
            this.toolUtilities.Text = "Utilities";
            // 
            // toolUser
            // 
            this.toolUser.Name = "toolUser";
            this.toolUser.Size = new System.Drawing.Size(180, 22);
            this.toolUser.Text = "Change User";
            this.toolUser.Click += new System.EventHandler(this.ToolUser_Click);
            // 
            // toolClients
            // 
            this.toolClients.Name = "toolClients";
            this.toolClients.Size = new System.Drawing.Size(180, 22);
            this.toolClients.Text = "Clients";
            this.toolClients.Click += new System.EventHandler(this.ToolClients_Click_1);
            // 
            // toolReportGenerator
            // 
            this.toolReportGenerator.Name = "toolReportGenerator";
            this.toolReportGenerator.Size = new System.Drawing.Size(180, 22);
            this.toolReportGenerator.Text = "Report Generator";
            this.toolReportGenerator.Click += new System.EventHandler(this.ToolReportGenerator_Click);
            // 
            // toolAddTest
            // 
            this.toolAddTest.Name = "toolAddTest";
            this.toolAddTest.Size = new System.Drawing.Size(180, 22);
            this.toolAddTest.Text = "Add Test Letter";
            this.toolAddTest.Click += new System.EventHandler(this.ToolAddTest_Click);
            // 
            // helpToolStripMenuItem
            // 
            this.helpToolStripMenuItem.Name = "helpToolStripMenuItem";
            this.helpToolStripMenuItem.Size = new System.Drawing.Size(44, 20);
            this.helpToolStripMenuItem.Text = "Help";
            this.helpToolStripMenuItem.Click += new System.EventHandler(this.HelpToolStripMenuItem_Click);
            // 
            // toolExit
            // 
            this.toolExit.Name = "toolExit";
            this.toolExit.Size = new System.Drawing.Size(37, 20);
            this.toolExit.Text = "Exit";
            this.toolExit.Click += new System.EventHandler(this.ToolExit_Click);
            // 
            // gbQ
            // 
            this.gbQ.Controls.Add(this.bAddQ);
            this.gbQ.Location = new System.Drawing.Point(12, 216);
            this.gbQ.Name = "gbQ";
            this.gbQ.Size = new System.Drawing.Size(327, 78);
            this.gbQ.TabIndex = 11;
            this.gbQ.TabStop = false;
            this.gbQ.Text = "Complete Letter";
            // 
            // bAddQ
            // 
            this.bAddQ.Location = new System.Drawing.Point(6, 19);
            this.bAddQ.Name = "bAddQ";
            this.bAddQ.Size = new System.Drawing.Size(315, 53);
            this.bAddQ.TabIndex = 5;
            this.bAddQ.Text = "Print QC Sheet";
            this.bAddQ.UseVisualStyleBackColor = true;
            this.bAddQ.Click += new System.EventHandler(this.BAddQ_Click);
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.label6);
            this.groupBox1.Controls.Add(this.label5);
            this.groupBox1.Controls.Add(this.listTypes);
            this.groupBox1.Controls.Add(this.label1);
            this.groupBox1.Controls.Add(this.txtEncorrNumber);
            this.groupBox1.Controls.Add(this.listClients);
            this.groupBox1.Location = new System.Drawing.Point(12, 27);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(152, 188);
            this.groupBox1.TabIndex = 22;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "Correspondence Details";
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Location = new System.Drawing.Point(6, 54);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(33, 13);
            this.label6.TabIndex = 4;
            this.label6.Text = "Client";
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(6, 94);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(61, 13);
            this.label5.TabIndex = 3;
            this.label5.Text = "Letter Type";
            // 
            // listRecent
            // 
            this.listRecent.FormattingEnabled = true;
            this.listRecent.Location = new System.Drawing.Point(6, 15);
            this.listRecent.Name = "listRecent";
            this.listRecent.Size = new System.Drawing.Size(152, 56);
            this.listRecent.TabIndex = 23;
            this.listRecent.SelectedIndexChanged += new System.EventHandler(this.ListRecent_SelectedIndexChanged);
            // 
            // groupBox3
            // 
            this.groupBox3.Controls.Add(this.listRecent);
            this.groupBox3.Location = new System.Drawing.Point(170, 135);
            this.groupBox3.Name = "groupBox3";
            this.groupBox3.Size = new System.Drawing.Size(167, 80);
            this.groupBox3.TabIndex = 23;
            this.groupBox3.TabStop = false;
            this.groupBox3.Text = "Recent Letters";
            // 
            // updatesToolStripMenuItem
            // 
            this.updatesToolStripMenuItem.Name = "updatesToolStripMenuItem";
            this.updatesToolStripMenuItem.Size = new System.Drawing.Size(62, 20);
            this.updatesToolStripMenuItem.Text = "Updates";
            this.updatesToolStripMenuItem.Click += new System.EventHandler(this.UpdatesToolStripMenuItem_Click);
            // 
            // WorkTracker
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(351, 302);
            this.Controls.Add(this.groupBox3);
            this.Controls.Add(this.groupBox1);
            this.Controls.Add(this.gbQ);
            this.Controls.Add(this.groupBox2);
            this.Controls.Add(this.menu);
            this.MainMenuStrip = this.menu;
            this.Name = "WorkTracker";
            this.Text = "WorkTracker";
            this.groupBox2.ResumeLayout(false);
            this.groupBox2.PerformLayout();
            this.menu.ResumeLayout(false);
            this.menu.PerformLayout();
            this.gbQ.ResumeLayout(false);
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            this.groupBox3.ResumeLayout(false);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.TextBox txtEncorrNumber;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.GroupBox groupBox2;
        private System.Windows.Forms.MenuStrip menu;
        private System.Windows.Forms.ToolStripMenuItem toolUtilities;
        private System.Windows.Forms.ToolStripMenuItem toolUser;
        private System.Windows.Forms.ComboBox listClients;
        private System.Windows.Forms.TextBox textDCName;
        private System.Windows.Forms.TextBox textTracking;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.GroupBox gbQ;
        private System.Windows.Forms.Button bAddQ;
        private System.Windows.Forms.ListBox listTypes;
        private System.Windows.Forms.ToolStripMenuItem toolReportGenerator;
        private System.Windows.Forms.ToolStripMenuItem toolExit;
        private System.Windows.Forms.ToolStripMenuItem toolClients;
        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.ToolStripMenuItem helpToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem toolAddTest;
        private System.Windows.Forms.ListBox listRecent;
        private System.Windows.Forms.GroupBox groupBox3;
        private System.Windows.Forms.ToolStripMenuItem updatesToolStripMenuItem;
    }
}

