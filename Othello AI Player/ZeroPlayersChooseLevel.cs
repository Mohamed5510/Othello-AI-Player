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
        }

        private void button1_Click(object sender, EventArgs e)
        {
            ZeroPlayersWindow w = new ZeroPlayersWindow();
            this.Hide();
            w.ShowDialog();
            this.Close();
        }
    }
}
