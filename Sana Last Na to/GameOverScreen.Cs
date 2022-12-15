using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Sana_Last_Na_to
{
    public partial class GameOverScreen : Form
    {
        public GameOverScreen()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            Form1 newLevel = new Form1();
            this.Hide();
            newLevel.Show();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            StartScreen StartScreen = new StartScreen();
            this.Hide();
            StartScreen.Show();
        }
    }
}
