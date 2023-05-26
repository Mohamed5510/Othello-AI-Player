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
        }

        private void button1_Click(object sender, EventArgs e)
        {
            OnePlayerWindow w = new OnePlayerWindow();
            this.Hide();
            w.ShowDialog();
            this.Close();
        }
    }
}
