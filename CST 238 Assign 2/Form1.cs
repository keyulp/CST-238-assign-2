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

namespace CST_238_Assign_2
{
    public partial class Form1 : Form
    {
        private string fileName = null;
        Point start;
        bool dirty = false;

        public Form1()
        {
            InitializeComponent();
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            pictureBox.Image = new Bitmap(pictureBox.Width, pictureBox.Height);
        }

        private void openhToolStripMenuItem_Click(object sender, EventArgs e)
        {
            try
            {
                OpenFileDialog ofd = new OpenFileDialog();
                ofd.Filter = "bmp (*.bmp)|*.bmp";
                ofd.FileName = "";
                ofd.Title = "Open";

                if (ofd.ShowDialog() == DialogResult.OK && ofd.FileName.Length > 0)
                {
                    pictureBox.Image = Bitmap.FromFile(ofd.FileName);
                    pictureBox.ClientSize = new Size(pictureBox.Image.Width, pictureBox.Image.Height);
                    this.Text = string.Format("CST 238 Assign2 - {0}", Path.GetFileName(ofd.FileName));
                }
            }
            catch (Exception exception)
            {
                MessageBox.Show(exception.Message, "File name not found");

            }
        }

        private void saveToolStripMenuItem_Click(object sender, EventArgs e)
        {

        }

        private void saveAsToolStripMenuItem_Click(object sender, EventArgs e)
        {
            try
            {
                SaveFileDialog sfd = new SaveFileDialog();
                sfd.Filter = "bmp (*.bmp)|*.bmp";

                if (sfd.ShowDialog() == DialogResult.OK && sfd.FileName.Length > 0)
                {
                    pictureBox.Image.Save(sfd.FileName);
                }
            }
            catch (Exception exception)
            {
                MessageBox.Show(exception.Message, "Enter a Filename");

            }
        }


        private void exitToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }

        private void lineToolStripMenuItem_Click(object sender, EventArgs e)
        {
            lineToolStripMenuItem.Checked = true;
            rectangleToolStripMenuItem.Checked = false;
            eclipseToolStripMenuItem.Checked = false;
        }

        private void rectangleToolStripMenuItem_Click(object sender, EventArgs e)
        {
            lineToolStripMenuItem.Checked = false;
            rectangleToolStripMenuItem.Checked = true;
            eclipseToolStripMenuItem.Checked = false;
        }

        private void eclipseToolStripMenuItem_Click(object sender, EventArgs e)
        {
            lineToolStripMenuItem.Checked = false;
            rectangleToolStripMenuItem.Checked = false;
            eclipseToolStripMenuItem.Checked = true;
        }

        private void blackToolStripMenuItem_Click(object sender, EventArgs e)
        {
            blackToolStripMenuItem.Checked = true;
            whiteToolStripMenuItem.Checked = false;
            redToolStripMenuItem.Checked = false;
            blueToolStripMenuItem.Checked = false;
            greenToolStripMenuItem.Checked = false;
        }

        private void whiteToolStripMenuItem_Click(object sender, EventArgs e)
        {
            blackToolStripMenuItem.Checked = false;
            whiteToolStripMenuItem.Checked = true;
            redToolStripMenuItem.Checked = false;
            blueToolStripMenuItem.Checked = false;
            greenToolStripMenuItem.Checked = false;
        }

        private void redToolStripMenuItem_Click(object sender, EventArgs e)
        {
            blackToolStripMenuItem.Checked = false;
            whiteToolStripMenuItem.Checked = false;
            redToolStripMenuItem.Checked = true;
            blueToolStripMenuItem.Checked = false;
            greenToolStripMenuItem.Checked = false;
        }

        private void blueToolStripMenuItem_Click(object sender, EventArgs e)
        {
            blackToolStripMenuItem.Checked = false;
            whiteToolStripMenuItem.Checked = false;
            redToolStripMenuItem.Checked = false;
            blueToolStripMenuItem.Checked = true;
            greenToolStripMenuItem.Checked = false;
        }

        private void greenToolStripMenuItem_Click(object sender, EventArgs e)
        {
            blackToolStripMenuItem.Checked = false;
            whiteToolStripMenuItem.Checked = false;
            redToolStripMenuItem.Checked = false;
            blueToolStripMenuItem.Checked = false;
            greenToolStripMenuItem.Checked = true;
        }

        private void Form1_FormClosing(object sender, FormClosingEventArgs e)
        {
            DialogResult result = MessageBox.Show("You have unsaved work. Would you like to return to the project?", "Save",
                MessageBoxButtons.YesNoCancel);

            if (result == System.Windows.Forms.DialogResult.Yes)
            {
                e.Cancel = true;
            }
            if (result == System.Windows.Forms.DialogResult.No)
            { 
                return;
            }
            if (result == System.Windows.Forms.DialogResult.Cancel)
            {
                e.Cancel = true;
            }

        }

        private void pictureBox_MouseDown(object sender, MouseEventArgs e)
        {
            if (e.Button == MouseButtons.Left)
            {
                start = new Point(e.X, e.Y);
                dirty = true;
            }
        }

        private void pictureBox_MouseUp(object sender, MouseEventArgs e)
        {
            if (dirty)
            {
                if (lineToolStripMenuItem.Checked == true && blackToolStripMenuItem.Checked == true)
                {
                    Graphics g = Graphics.FromImage(pictureBox.Image);
                    g.DrawLine(Pens.Black, start, new Point(e.X, e.Y));
                    pictureBox.Refresh();
                }
                //rectangle
                //Rectangle r = new Rectangle(Math.Min(e.x, start.X), Math.Min(e.y, start.Y), Math.Abs(start.X-e.X), Math.Abs(start.Y - e.Y)
                //Graphics g = Graphics.FromImage(pictureBox.Image);
                //g.DrawRectangle(Pens.Black, r);
                //pictureBox.Refresh()

                //elipse
                //Rectangle ellipse = new Rectangle(Math.Min(e.x, start.X), Math.Min(e.y, start.Y), Math.Abs(start.X-e.X), Math.Abs(start.Y - e.Y)
                //Graphics g = Graphics.FromImage(pictureBox.Image);
                //g.DrawEllipse(Pens.Black, ellipse);
                //pictureBox.Refresh()
            }
        }

        private void pictureBox_Click(object sender, EventArgs e)
        {

        }

    }
}
