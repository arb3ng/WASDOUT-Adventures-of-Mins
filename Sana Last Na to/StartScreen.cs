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
    public partial class StartScreen : Form
    {
        public StartScreen()
        {
            InitializeComponent();
        }

        //Once the Start Button was clicked,the startscreen will exit itself
        //level 1 will appear which makes the game start

        private void button1_Click(object sender, EventArgs e)
        {
            Form1 newLevel = new Form1();
            this.Hide();
            newLevel.Show();

        }

        //Once the Help Button was clicked, the startscreen will exit itself itself
        //then the help screen will appear 
        private void button2_Click(object sender, EventArgs e)
        {
            Help helpScreen = new Help();
            this.Hide();
            helpScreen.Show();
        }
        //Once the Quit game was clicked, the startscreen will exit itself
        private void button3_Click(object sender, EventArgs e)
        {
            this.Hide();
        }

 
    }
}
