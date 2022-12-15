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
    public partial class Level5 : Form
    {

        bool goup, godown, goleft, goright, isGameOver;

        int keys, playerSpeed, ghost1Speed, ghost2Speed, ghost3Speed, ghost4x, ghost4y;

  
        public Level5()
        {
            InitializeComponent();

            resetgame();
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

                    if (ghost4.Bounds.IntersectsWith(x.Bounds))
                    {
                        ghost4y = -ghost4y;
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
                        gameTimer.Stop();
                        TheEnd newLevel = new TheEnd();
                        this.Hide();
                        newLevel.Show();


                    }
                }
                
            }

            ghost1.Top -= ghost1Speed;
            if (ghost1.Bounds.IntersectsWith(pictureBox1.Bounds) || (ghost1.Bounds.IntersectsWith(pictureBox18.Bounds)))
            {

                ghost1Speed = -ghost1Speed;

            }

            ghost2.Top -= ghost2Speed;
            if (ghost2.Bounds.IntersectsWith(pictureBox1.Bounds) || (ghost2.Bounds.IntersectsWith(pictureBox18.Bounds)))
            {

                ghost2Speed = -ghost2Speed;

            }

            ghost3.Top -= ghost3Speed;
            if (ghost3.Bounds.IntersectsWith(pictureBox1.Bounds) || (ghost3.Bounds.IntersectsWith(pictureBox18.Bounds)))
            {

                ghost3Speed = -ghost3Speed;
            }

            ghost4.Left -= ghost4x;
            ghost4.Top -= ghost4y;

            if (ghost4.Top < 230 || ghost4.Top > 420)
            {
                ghost4y = -ghost4y;
            }

            if (ghost4.Left < 30 || ghost4.Left > 320)
            {
                ghost4x = -ghost4x;
            }
       
        }

        private void resetgame()
        {

            txtScore.Text = "Keys: 0";
            keys = 0;

            ghost1Speed = 3;
            ghost2Speed = 3;
            ghost3Speed = 5;
            ghost4x = 7;
            ghost4y = 7;
            playerSpeed = 15;

            isGameOver = false;

            player.Left = 30;
            player.Top = 70;

            ghost1.Left = 129;
            ghost1.Top = 15;

            ghost2.Left = 299;
            ghost2.Top = 138;

            ghost3.Left = 468;
            ghost3.Top = 12;

            ghost4.Left = 103;
            ghost4.Top = 330;


            door.Left = 599;
            door.Top = 439;

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
