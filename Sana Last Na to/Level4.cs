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
    public partial class Level4 : Form
    {

        bool goup, godown, goleft, goright, isGameOver;

        int keys, playerSpeed, ghost1Speed, ghost2Speed, ghost3Speed, ghost4Speed;
        public Level4()
        {
            InitializeComponent();

            resetgame();
        }

        private void gameTimer_Tick(object sender, EventArgs e)
        {
            txtScore.Text = "Keys:" + keys;


            if (goleft == true)
            {
                player.Left -= playerSpeed;
            }
            if (goright == true)
            {
                player.Left += playerSpeed;
            }
            if (godown == true)
            {
                player.Top += playerSpeed;
            }
            if (goup == true)
            {
                player.Top -= playerSpeed;
            }


            foreach (Control x in this.Controls)
            {
                if ((string)x.Tag == "coin" && x.Visible == true)
                {
                    if (player.Bounds.IntersectsWith(x.Bounds))
                    {
                        keys += 1;
                        x.Visible = false;
                    }

                }

                if ((string)x.Tag == "wall")
                {
                    if (player.Bounds.IntersectsWith(x.Bounds))
                    {
                        gameOver();
                    }
                }

                if ((string)x.Tag == "ghost")
                {
                    if (player.Bounds.IntersectsWith(x.Bounds))
                    {
                        gameOver();
                    }
                }

                if ((string)x.Tag == "door" && keys == 10)
                {
                    if (player.Bounds.IntersectsWith(x.Bounds))
                    {
                        keys = 0;
                        gameTimer.Stop();
                        Level5 newLevel = new Level5();
                        this.Hide();
                        newLevel.Show();

                    }
                }
             
            }


            ghost1.Left -= ghost1Speed;
            if (ghost1.Bounds.IntersectsWith(pictureBox3.Bounds) || (ghost1.Bounds.IntersectsWith(pictureBox7.Bounds)))
            {
                ghost1Speed = -ghost1Speed;
            }

            ghost2.Left -= ghost2Speed;
            if (ghost2.Bounds.IntersectsWith(pictureBox3.Bounds) || (ghost2.Bounds.IntersectsWith(pictureBox7.Bounds)))
            {
                ghost2Speed = -ghost2Speed;
            }

            ghost3.Top -= ghost3Speed;
            if (ghost3.Bounds.IntersectsWith(pictureBox17.Bounds) || (ghost3.Bounds.IntersectsWith(pictureBox19.Bounds)))
            {
                ghost3Speed = -ghost3Speed;
            }

        }

        private void keyisdown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.W)
            {
                goup = true;

            }
            if (e.KeyCode == Keys.S)
            {
                godown = true;

            }
            if (e.KeyCode == Keys.A)
            {
                goleft = true;

            }
            if (e.KeyCode == Keys.D)
            {
                goright = true;

            }
        }

        private void keyisup(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.W)
            {
                goup = false;
            }
            if (e.KeyCode == Keys.S)
            {
                godown = false;
            }
            if (e.KeyCode == Keys.A)
            {
                goleft = false;
            }
            if (e.KeyCode == Keys.D)
            {
                goright = false;
            }
        }


        private void resetgame()
        {

            txtScore.Text = "Keys: 0";
            keys = 0;

            ghost1Speed = 3;
            ghost2Speed = 3;
            ghost3Speed = 3;

            playerSpeed = 15;

            isGameOver = false;

            player.Left = 115;
            player.Top = 39;

            ghost1.Left = 335;
            ghost1.Top = 178;

            ghost2.Left = 201;
            ghost2.Top = 333;


            ghost3.Left = 509;
            ghost3.Top = 397;

            door.Left = 555;
            door.Top = 27;

            foreach (Control x in this.Controls)
            {
                if (x is PictureBox)
                {
                    x.Visible = true;

                }


            }

            gameTimer.Start();
        }


        private void gameOver()
        {

            isGameOver = true;

            gameTimer.Stop();

            GameOverScreen newLevel = new GameOverScreen();
            this.Hide();
            newLevel.Show();
        }




    }
}
