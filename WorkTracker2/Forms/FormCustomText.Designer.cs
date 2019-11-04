namespace WorkTracker2.Core
{
    partial class FormNewUser
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
            this.textInput = new System.Windows.Forms.TextBox();
            this.bSubmit = new System.Windows.Forms.Button();
            this.labelMain = new System.Windows.Forms.Label();
            this.SuspendLayout();
            // 
            // textInput
            // 
            this.textInput.Location = new System.Drawing.Point(72, 72);
            this.textInput.MaxLength = 3;
            this.textInput.Name = "textInput";
            this.textInput.Size = new System.Drawing.Size(98, 20);
            this.textInput.TabIndex = 0;
            this.textInput.TextChanged += new System.EventHandler(this.TextInput_TextChanged);
            // 
            // bSubmit
            // 
            this.bSubmit.DialogResult = System.Windows.Forms.DialogResult.OK;
            this.bSubmit.Location = new System.Drawing.Point(72, 98);
            this.bSubmit.Name = "bSubmit";
            this.bSubmit.Size = new System.Drawing.Size(99, 23);
            this.bSubmit.TabIndex = 1;
            this.bSubmit.Text = "Submit";
            this.bSubmit.UseVisualStyleBackColor = true;
            // 
            // labelMain
            // 
            this.labelMain.AutoSize = true;
            this.labelMain.Location = new System.Drawing.Point(12, 9);
            this.labelMain.Name = "labelMain";
            this.labelMain.Size = new System.Drawing.Size(227, 52);
            this.labelMain.TabIndex = 2;
            this.labelMain.Text = "Welcome to the Deferred Output WorkTracker\r\n\r\nTo begin, enter your initials \r\n(3 " +
    "character max)";
            this.labelMain.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // FormNewUser
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(247, 133);
            this.Controls.Add(this.labelMain);
            this.Controls.Add(this.bSubmit);
            this.Controls.Add(this.textInput);
            this.Name = "FormNewUser";
            this.Text = "New User";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.TextBox textInput;
        private System.Windows.Forms.Button bSubmit;
        private System.Windows.Forms.Label labelMain;
    }
}