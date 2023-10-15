using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using Notepad.Funcs;

namespace Notepad.Forms
{
    public partial class FormFind : Form
    {
        public FormFind()
        {
            InitializeComponent();
        }

        private void btnFindNext_Click(object sender, EventArgs e)
        {
            Form parent_form = Application.OpenForms[nameof(FormMain)];
            RichTextBox richTxt = parent_form.Controls[nameof(richTxt)] as RichTextBox;

            FormFindFuncs.DoFind(richTxt, txtSearch.Text, rbtnDown.Checked, cbMatchCase.Checked);
        }

        private void FormFind_Load(object sender, EventArgs e)
        {

        }
    }
}
