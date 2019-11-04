using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace WorkTracker2.Core
{
    public partial class FormNewUser : Form
    {
        private int _min = 2;

        public FormNewUser(string labelText, string windowName)
        {
            InitializeComponent();

            bSubmit.Enabled = false;
            textInput.MaxLength = 3;
            this.Text = windowName;
            labelMain.Text = labelText;
            labelMain.Location = GetCenter(labelMain, this, 7);
            textInput.Location = GetCenter(textInput, this, 72);
            bSubmit.Location = GetCenter(bSubmit, this, 98);
        }

        static Point GetCenter(Control control, Form form, int y)
        {
            return new Point(form.Size.Width / 2 - (control.Size.Width / 2), y);
        }

        public string UserName { get => textInput.Text; }

        public void SetMinAndMax(int min, int max)
        {
            _min = min;
            textInput.MaxLength = max;
        }

        private void TextInput_TextChanged(object sender, EventArgs e)
        {
            if (textInput.Text.Length < _min) bSubmit.Enabled = false;
            else bSubmit.Enabled = true;
        }
    }
}
