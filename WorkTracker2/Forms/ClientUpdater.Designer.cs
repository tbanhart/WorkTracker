namespace WorkTracker2.Core
{
    partial class ClientUpdater
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
            this.listAllClients = new System.Windows.Forms.ListBox();
            this.listSelectedClients = new System.Windows.Forms.ListBox();
            this.bRemoveClient = new System.Windows.Forms.Button();
            this.bAddClient = new System.Windows.Forms.Button();
            this.bDone = new System.Windows.Forms.Button();
            this.listProds = new System.Windows.Forms.ComboBox();
            this.SuspendLayout();
            // 
            // listAllClients
            // 
            this.listAllClients.FormattingEnabled = true;
            this.listAllClients.Location = new System.Drawing.Point(13, 35);
            this.listAllClients.Name = "listAllClients";
            this.listAllClients.Size = new System.Drawing.Size(147, 147);
            this.listAllClients.TabIndex = 1;
            // 
            // listSelectedClients
            // 
            this.listSelectedClients.FormattingEnabled = true;
            this.listSelectedClients.Location = new System.Drawing.Point(166, 35);
            this.listSelectedClients.Name = "listSelectedClients";
            this.listSelectedClients.Size = new System.Drawing.Size(151, 147);
            this.listSelectedClients.TabIndex = 3;
            // 
            // bRemoveClient
            // 
            this.bRemoveClient.Location = new System.Drawing.Point(166, 188);
            this.bRemoveClient.Name = "bRemoveClient";
            this.bRemoveClient.Size = new System.Drawing.Size(151, 25);
            this.bRemoveClient.TabIndex = 4;
            this.bRemoveClient.Text = "<";
            this.bRemoveClient.UseVisualStyleBackColor = true;
            this.bRemoveClient.Click += new System.EventHandler(this.BRemoveClient_Click);
            // 
            // bAddClient
            // 
            this.bAddClient.Location = new System.Drawing.Point(12, 188);
            this.bAddClient.Name = "bAddClient";
            this.bAddClient.Size = new System.Drawing.Size(147, 25);
            this.bAddClient.TabIndex = 2;
            this.bAddClient.Text = ">";
            this.bAddClient.UseVisualStyleBackColor = true;
            this.bAddClient.Click += new System.EventHandler(this.BAddClient_Click);
            // 
            // bDone
            // 
            this.bDone.DialogResult = System.Windows.Forms.DialogResult.OK;
            this.bDone.Location = new System.Drawing.Point(166, 8);
            this.bDone.Name = "bDone";
            this.bDone.Size = new System.Drawing.Size(151, 23);
            this.bDone.TabIndex = 5;
            this.bDone.Text = "Done";
            this.bDone.UseVisualStyleBackColor = true;
            this.bDone.Click += new System.EventHandler(this.BDone_Click);
            // 
            // listProds
            // 
            this.listProds.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.listProds.FormattingEnabled = true;
            this.listProds.Location = new System.Drawing.Point(13, 8);
            this.listProds.Name = "listProds";
            this.listProds.Size = new System.Drawing.Size(147, 21);
            this.listProds.TabIndex = 0;
            this.listProds.SelectedIndexChanged += new System.EventHandler(this.ListProds_SelectedIndexChanged);
            // 
            // ClientUpdater
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(330, 226);
            this.Controls.Add(this.listProds);
            this.Controls.Add(this.bDone);
            this.Controls.Add(this.bAddClient);
            this.Controls.Add(this.bRemoveClient);
            this.Controls.Add(this.listSelectedClients);
            this.Controls.Add(this.listAllClients);
            this.Name = "ClientUpdater";
            this.Text = "Client Updater";
            this.ResumeLayout(false);

        }

        #endregion
        private System.Windows.Forms.ListBox listAllClients;
        private System.Windows.Forms.ListBox listSelectedClients;
        private System.Windows.Forms.Button bRemoveClient;
        private System.Windows.Forms.Button bAddClient;
        private System.Windows.Forms.Button bDone;
        private System.Windows.Forms.ComboBox listProds;
    }
}