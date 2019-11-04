namespace WorkTracker2.Core
{
    partial class FormReportGenerator
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
            this.groupOptions = new System.Windows.Forms.GroupBox();
            this.bSearchAll = new System.Windows.Forms.Button();
            this.textSearch = new System.Windows.Forms.TextBox();
            this.listProfiles = new System.Windows.Forms.ComboBox();
            this.bGenerate = new System.Windows.Forms.Button();
            this.treeReport = new System.Windows.Forms.TreeView();
            this.bRemoved = new System.Windows.Forms.Button();
            this.bApprove = new System.Windows.Forms.Button();
            this.bDeny = new System.Windows.Forms.Button();
            this.label1 = new System.Windows.Forms.Label();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.textComments = new System.Windows.Forms.ComboBox();
            this.dtStart = new System.Windows.Forms.DateTimePicker();
            this.dtEnd = new System.Windows.Forms.DateTimePicker();
            this.label2 = new System.Windows.Forms.Label();
            this.groupBox2 = new System.Windows.Forms.GroupBox();
            this.label6 = new System.Windows.Forms.Label();
            this.listTables = new System.Windows.Forms.ComboBox();
            this.label4 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.label5 = new System.Windows.Forms.Label();
            this.bRefresh = new System.Windows.Forms.Button();
            this.bgQuery = new System.ComponentModel.BackgroundWorker();
            this.groupOptions.SuspendLayout();
            this.groupBox1.SuspendLayout();
            this.groupBox2.SuspendLayout();
            this.SuspendLayout();
            // 
            // groupOptions
            // 
            this.groupOptions.Controls.Add(this.bSearchAll);
            this.groupOptions.Controls.Add(this.textSearch);
            this.groupOptions.Location = new System.Drawing.Point(257, 13);
            this.groupOptions.Name = "groupOptions";
            this.groupOptions.Size = new System.Drawing.Size(198, 80);
            this.groupOptions.TabIndex = 16;
            this.groupOptions.TabStop = false;
            this.groupOptions.Text = "Search";
            // 
            // bSearchAll
            // 
            this.bSearchAll.Location = new System.Drawing.Point(7, 47);
            this.bSearchAll.Name = "bSearchAll";
            this.bSearchAll.Size = new System.Drawing.Size(185, 23);
            this.bSearchAll.TabIndex = 9;
            this.bSearchAll.Text = "Search";
            this.bSearchAll.UseVisualStyleBackColor = true;
            this.bSearchAll.Click += new System.EventHandler(this.BSearchAll_Click);
            // 
            // textSearch
            // 
            this.textSearch.Location = new System.Drawing.Point(7, 20);
            this.textSearch.Name = "textSearch";
            this.textSearch.Size = new System.Drawing.Size(185, 20);
            this.textSearch.TabIndex = 8;
            // 
            // listProfiles
            // 
            this.listProfiles.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.listProfiles.FormattingEnabled = true;
            this.listProfiles.Location = new System.Drawing.Point(113, 115);
            this.listProfiles.Name = "listProfiles";
            this.listProfiles.Size = new System.Drawing.Size(114, 21);
            this.listProfiles.TabIndex = 2;
            // 
            // bGenerate
            // 
            this.bGenerate.Location = new System.Drawing.Point(7, 150);
            this.bGenerate.Name = "bGenerate";
            this.bGenerate.Size = new System.Drawing.Size(220, 38);
            this.bGenerate.TabIndex = 3;
            this.bGenerate.Text = "Generate Report";
            this.bGenerate.UseVisualStyleBackColor = true;
            this.bGenerate.Click += new System.EventHandler(this.BGenerate_Click);
            // 
            // treeReport
            // 
            this.treeReport.Location = new System.Drawing.Point(257, 116);
            this.treeReport.Name = "treeReport";
            this.treeReport.Size = new System.Drawing.Size(198, 162);
            this.treeReport.TabIndex = 9;
            // 
            // bRemoved
            // 
            this.bRemoved.Location = new System.Drawing.Point(6, 19);
            this.bRemoved.Name = "bRemoved";
            this.bRemoved.Size = new System.Drawing.Size(62, 23);
            this.bRemoved.TabIndex = 7;
            this.bRemoved.Text = "Remove";
            this.bRemoved.UseVisualStyleBackColor = true;
            this.bRemoved.Click += new System.EventHandler(this.BRemoved_Click);
            // 
            // bApprove
            // 
            this.bApprove.Location = new System.Drawing.Point(74, 19);
            this.bApprove.Name = "bApprove";
            this.bApprove.Size = new System.Drawing.Size(72, 23);
            this.bApprove.TabIndex = 4;
            this.bApprove.Text = "Approve";
            this.bApprove.UseVisualStyleBackColor = true;
            this.bApprove.Click += new System.EventHandler(this.BApprove_Click);
            // 
            // bDeny
            // 
            this.bDeny.Location = new System.Drawing.Point(152, 19);
            this.bDeny.Name = "bDeny";
            this.bDeny.Size = new System.Drawing.Size(75, 23);
            this.bDeny.TabIndex = 6;
            this.bDeny.Text = "Deny";
            this.bDeny.UseVisualStyleBackColor = true;
            this.bDeny.Click += new System.EventHandler(this.BDeny_Click);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(6, 45);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(74, 13);
            this.label1.TabIndex = 15;
            this.label1.Text = "QC Comments";
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.textComments);
            this.groupBox1.Controls.Add(this.bRemoved);
            this.groupBox1.Controls.Add(this.label1);
            this.groupBox1.Controls.Add(this.bApprove);
            this.groupBox1.Controls.Add(this.bDeny);
            this.groupBox1.Location = new System.Drawing.Point(12, 213);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(233, 94);
            this.groupBox1.TabIndex = 14;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "QC Controls";
            // 
            // textComments
            // 
            this.textComments.FormattingEnabled = true;
            this.textComments.Location = new System.Drawing.Point(7, 62);
            this.textComments.Name = "textComments";
            this.textComments.Size = new System.Drawing.Size(220, 21);
            this.textComments.TabIndex = 16;
            // 
            // dtStart
            // 
            this.dtStart.Location = new System.Drawing.Point(6, 32);
            this.dtStart.Name = "dtStart";
            this.dtStart.Size = new System.Drawing.Size(221, 20);
            this.dtStart.TabIndex = 0;
            this.dtStart.ValueChanged += new System.EventHandler(this.DtStart_ValueChanged);
            // 
            // dtEnd
            // 
            this.dtEnd.Location = new System.Drawing.Point(6, 72);
            this.dtEnd.Name = "dtEnd";
            this.dtEnd.Size = new System.Drawing.Size(221, 20);
            this.dtEnd.TabIndex = 1;
            this.dtEnd.ValueChanged += new System.EventHandler(this.DtEnd_ValueChanged);
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(6, 16);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(55, 13);
            this.label2.TabIndex = 11;
            this.label2.Text = "Start Date";
            // 
            // groupBox2
            // 
            this.groupBox2.Controls.Add(this.label6);
            this.groupBox2.Controls.Add(this.listTables);
            this.groupBox2.Controls.Add(this.label4);
            this.groupBox2.Controls.Add(this.label3);
            this.groupBox2.Controls.Add(this.dtStart);
            this.groupBox2.Controls.Add(this.bGenerate);
            this.groupBox2.Controls.Add(this.label2);
            this.groupBox2.Controls.Add(this.dtEnd);
            this.groupBox2.Controls.Add(this.listProfiles);
            this.groupBox2.Location = new System.Drawing.Point(12, 13);
            this.groupBox2.Name = "groupBox2";
            this.groupBox2.Size = new System.Drawing.Size(233, 194);
            this.groupBox2.TabIndex = 10;
            this.groupBox2.TabStop = false;
            this.groupBox2.Text = "Report Details";
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Location = new System.Drawing.Point(3, 95);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(34, 13);
            this.label6.TabIndex = 15;
            this.label6.Text = "Table";
            // 
            // listTables
            // 
            this.listTables.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.listTables.FormattingEnabled = true;
            this.listTables.Location = new System.Drawing.Point(6, 115);
            this.listTables.Name = "listTables";
            this.listTables.Size = new System.Drawing.Size(101, 21);
            this.listTables.TabIndex = 14;
            this.listTables.SelectedIndexChanged += new System.EventHandler(this.ListTables_SelectedIndexChanged);
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(110, 95);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(85, 13);
            this.label4.TabIndex = 13;
            this.label4.Text = "Reporting Profile";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(6, 55);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(52, 13);
            this.label3.TabIndex = 12;
            this.label3.Text = "End Date";
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(257, 100);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(64, 13);
            this.label5.TabIndex = 17;
            this.label5.Text = "Report Tree";
            // 
            // bRefresh
            // 
            this.bRefresh.Location = new System.Drawing.Point(257, 284);
            this.bRefresh.Name = "bRefresh";
            this.bRefresh.Size = new System.Drawing.Size(198, 23);
            this.bRefresh.TabIndex = 18;
            this.bRefresh.Text = "Refresh";
            this.bRefresh.UseVisualStyleBackColor = true;
            this.bRefresh.Click += new System.EventHandler(this.BGenerate_Click);
            // 
            // bgQuery
            // 
            this.bgQuery.WorkerReportsProgress = true;
            // 
            // FormReportGenerator
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(465, 316);
            this.Controls.Add(this.treeReport);
            this.Controls.Add(this.bRefresh);
            this.Controls.Add(this.label5);
            this.Controls.Add(this.groupBox2);
            this.Controls.Add(this.groupBox1);
            this.Controls.Add(this.groupOptions);
            this.Name = "FormReportGenerator";
            this.Text = "FormReportGenerator";
            this.groupOptions.ResumeLayout(false);
            this.groupOptions.PerformLayout();
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            this.groupBox2.ResumeLayout(false);
            this.groupBox2.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion
        private System.Windows.Forms.GroupBox groupOptions;
        private System.Windows.Forms.Button bGenerate;
        private System.Windows.Forms.TextBox textSearch;
        private System.Windows.Forms.ComboBox listProfiles;
        private System.Windows.Forms.Button bSearchAll;
        private System.Windows.Forms.TreeView treeReport;
        private System.Windows.Forms.Button bRemoved;
        private System.Windows.Forms.Button bApprove;
        private System.Windows.Forms.Button bDeny;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.DateTimePicker dtStart;
        private System.Windows.Forms.DateTimePicker dtEnd;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.GroupBox groupBox2;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.ComboBox listTables;
        private System.Windows.Forms.Button bRefresh;
        private System.Windows.Forms.ComboBox textComments;
        private System.ComponentModel.BackgroundWorker bgQuery;
    }
}