using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Othello_AI_Player
{
    public partial class OnePlayerChooseLevel : Form
    {
        public OnePlayerChooseLevel()
        {
            InitializeComponent();
            label3.Visible = false;
            comboBox1.Items.Add("0");
            comboBox1.Items.Add("1");
            comboBox1.Items.Add("2");
            comboBox1.Items.Add("3");
        }


        private void button1_Click_1(object sender, EventArgs e)
        {
            if (string.IsNullOrEmpty(comboBox1.Text))
            {
                label3.Visible = true;
            }
            else
            {
                OnePlayerWindow w = new OnePlayerWindow(Int32.Parse(comboBox1.Text));
                this.Hide();
                w.ShowDialog();
                this.Close();
            }
        }

        private void button2_Click(object sender, EventArgs e)
        {
            Application.Restart();
        }
    }
}
