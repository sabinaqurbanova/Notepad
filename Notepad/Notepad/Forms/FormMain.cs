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
    public partial class FormMain : Form
    {
        string OurFileName;



        #region Find
        private void findNextToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Form parent_form = Application.OpenForms[nameof(FormFind)];
            TextBox txtSearch = parent_form.Controls[nameof(txtSearch)] as TextBox;
            RadioButton rbtnDown = parent_form.Controls[nameof(rbtnDown)] as RadioButton;
            CheckBox cbMatchCase = parent_form.Controls[nameof(cbMatchCase)] as CheckBox;

            FormFindFuncs.DoFind(richTxt, txtSearch.Text, rbtnDown.Checked, cbMatchCase.Checked);
        }

        private void findToolStripMenuItem_Click(object sender, EventArgs e)
        {
            FormFind find = new FormFind();
            find.Show(this);
        }

        
        #endregion
        void DoSave(string filename)
        {
            OurFileName = filename;
            richTxt.SaveFile(filename);
        }

        void DoSaveAs()
        {
            SaveFileDialog saveFileDialog = new SaveFileDialog();
            if (saveFileDialog.ShowDialog() == DialogResult.OK)
            {
                DoSave(saveFileDialog.FileName);
            }
        }
        public FormMain()
        {
            InitializeComponent();
        }

        private void undoToolStripMenuItem_Click(object sender, EventArgs e)
        {
            richTxt.Undo();
        }

        private void cutToolStripMenuItem_Click(object sender, EventArgs e)
        {
            richTxt.Cut();
        }

        private void copyToolStripMenuItem_Click(object sender, EventArgs e)
        {
            richTxt.Copy();
        }

        private void pasteToolStripMenuItem_Click(object sender, EventArgs e)
        {
            richTxt.Paste();
        }

        private void deleteToolStripMenuItem_Click(object sender, EventArgs e)
        {
            richTxt.Clear();
        }


        bool CheckChanges()
        {
          return true;
        }
         private void openToolStripMenuItem_Click(object sender, EventArgs e)
        {
            OpenFileDialog openFileDialog = new OpenFileDialog();
            if (CheckChanges())
            {
                if(openFileDialog.ShowDialog()==DialogResult.OK)
                {
                    richTxt.LoadFile(openFileDialog.FileName); 
                }
            }
        }

        private void saveToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (string.IsNullOrEmpty(OurFileName))
            {
                DoSaveAs();
            }
            else
            {
                DoSave(OurFileName);
            }
        }

        private void exitToolStripMenuItem_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void aboutNotepadToolStripMenuItem_Click(object sender, EventArgs e)
        {
            MessageBox.Show("Program by Saby.");
        }

        private void FormMain_Load(object sender, EventArgs e)
        {
            FolderBrowserDialog folderDial = new FolderBrowserDialog();
            folderDial.ShowDialog();
            MessageBox.Show(folderDial.SelectedPath);
        }
    }
}
