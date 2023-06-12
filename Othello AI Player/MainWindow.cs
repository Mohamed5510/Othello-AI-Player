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
    public partial class MainWindow : Form
    {
        public MainWindow()
        {
            InitializeComponent();
        }

        // 2 Players Button
        private void button1_Click(object sender, EventArgs e)
        {
            TwoPlayersWindow w = new TwoPlayersWindow();
            this.Hide();
            w.ShowDialog();
            this.Close();
        }

        // 1 Player Button
        private void button2_Click(object sender, EventArgs e)
        {
            OnePlayerChooseLevel w = new OnePlayerChooseLevel();
            this.Hide();
            w.ShowDialog();
            this.Close();
        }

        // 0 Players Button
        private void button3_Click(object sender, EventArgs e)
        {
            ZeroPlayersChooseLevel w = new ZeroPlayersChooseLevel();
            this.Hide();
            w.ShowDialog();
            this.Close();
        }

    }
}
