using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.IO;
using System.Drawing.Printing;


namespace Notepad
{
    public partial class Notepad : Form
    {
        private static string clipboard;
        private string _openFile;
        public Notepad()
        {
            InitializeComponent();
        }

        private void Notepad_Load(object sender, EventArgs e)
        {
        }
        private void menuStrip1_ItemClicked(object sender, ToolStripItemClickedEventArgs e)
        {

        }
        private void richTextBox1_TextChanged(object sender, EventArgs e)
        {

        }

        #region *Файл*
        private void CreateFile(object sender, EventArgs e)
        {
            richTextBox1.Text = "";
        }
        private void OpenFile(object sender, EventArgs e)
        {
            OpenFileDialog Fdialog = new OpenFileDialog();
            Fdialog.Filter = "all (*.*) |*.*";
            if (Fdialog.ShowDialog() == DialogResult.OK)
            {
                richTextBox1.Text = File.ReadAllText(Fdialog.FileName);
                _openFile = Fdialog.FileName;
            }
        }
        private void SaveFile(object sender, EventArgs e)
        {
            SaveFileDialog Sdialog = new SaveFileDialog();
            Sdialog.Filter = "all (*.*) |*.*";
            if (Sdialog.ShowDialog() == DialogResult.OK)
            {
                File.WriteAllText(Sdialog.FileName, richTextBox1.Text);
                _openFile = Sdialog.FileName;
            }
        }
        private void PrintFile(object sender, EventArgs e)
        {
            PrintDocument pDocument = new PrintDocument();
            pDocument.PrintPage += PrintPageH;
            PrintDialog pDialog = new PrintDialog();
            if (pDialog.ShowDialog() == DialogResult.OK)
            {
                pDialog.Document.Print();
            }
        }
        public void PrintPageH(object Sender, PrintPageEventArgs e)
        {
            e.Graphics.DrawString(richTextBox1.Text, richTextBox1.Font, Brushes.Black, 0, 0);
        }
        private void ExitNotepad(object sender, EventArgs e)
        {
            Application.Exit();
        }

        #endregion

        #region *Изменить*
        private void ChangeFont(object sender, EventArgs e)
        {
            FontDialog myFont = new FontDialog();
            if (myFont.ShowDialog() == DialogResult.OK)
            {
                richTextBox1.Font = myFont.Font;
            }
        }
        private void ChangeToRed(object sender, EventArgs e)
        {
            richTextBox1.BackColor = Color.Red;
            richTextBox1.ForeColor = Color.White;
            menuStrip1.BackColor = Color.Red;
            
        }
        private void ChangeToBlue(object sender, EventArgs e)
        {
            richTextBox1.BackColor = Color.Blue;
            richTextBox1.ForeColor = Color.White;
            menuStrip1.BackColor = Color.Blue;
        }

        private void ChangeToGreen(object sender, EventArgs e)
        {
            richTextBox1.BackColor = Color.Green;
            richTextBox1.ForeColor = Color.White;
            menuStrip1.BackColor = Color.Green;
        }
        #endregion

        #region *Справка*
        private void ProgramInfo(object sender, EventArgs e)
        {
            MessageBox.Show("Лучшая программа!");
        }
        #endregion

        #region *Правка* 
        private void Cut(object sender, EventArgs e)
        {
            clipboard = richTextBox1.Text;
            richTextBox1.Text = "";
        }
        private void Copy(object sender, EventArgs e)
        {
            clipboard = richTextBox1.Text; 
        }
        private void Paste(object sender, EventArgs e)
        {
            richTextBox1.Text += clipboard;
        }


        #endregion
    }
}
