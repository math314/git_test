using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace git_test
{
    public partial class Form1 : Form
    {

        private mineController ctl = new mineController();

        public Form1()
        {
            InitializeComponent();
        }

        /// <summary>
        /// クリックされた
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void pictureBox1_Click(object sender, EventArgs e)
        {

        }

        /// <summary>
        /// 描画時
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void pictureBox1_Paint(object sender, PaintEventArgs e)
        {
            ctl.OnPaint(pictureBox1.Size, e.Graphics);
        }

        private void pictureBox1_Resize(object sender, EventArgs e)
        {
            pictureBox1.Refresh();
        }
    }
}
