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
    public partial class ZeroPlayersChooseLevel : Form
    {
        public ZeroPlayersChooseLevel()
        {
            InitializeComponent();
            label3.Visible = false;
            comboBox1.Items.Add("0");
            comboBox1.Items.Add("1");
            comboBox1.Items.Add("2");
            comboBox1.Items.Add("3");
            comboBox2.Items.Add("0");
            comboBox2.Items.Add("1");
            comboBox2.Items.Add("2");
            comboBox2.Items.Add("3");
        }

        private void button1_Click(object sender, EventArgs e)
        {
            if (string.IsNullOrEmpty(comboBox1.Text) || string.IsNullOrEmpty(comboBox2.Text))
            {
                label3.Visible = true;
            }
            else
            {
                label3.Visible = false;
                ZeroPlayersWindow w = new ZeroPlayersWindow(Int32.Parse(comboBox1.Text), Int32.Parse(comboBox2.Text));
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
