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
    public partial class Form1 : Form
    {
        // these are the variables that we will declare which
        // we need to start our game

        bool goup, godown, goleft, goright;
        int score, playerSpeed, beast1Speed, beast2Speed, beast3SpeedX, beast3SpeedY;

        private void Form1_Load(object sender, EventArgs e)
        {

        }



        /// this method will start the game 
        /// and the public method reset game will start <summary>
        public Form1()
        {
            InitializeComponent();

            resetGame();
        }

        // the keyisdown is the method event
        // that will occur when the keys are pressed
        // the W,A,S,and D are the keys pressent here
        // which we need to move the player in the game
        // and once pressed the booleans of goup,godown
        // goleft, goright will be true

        private void keyisdown(object sender, KeyEventArgs e)
        {
            
            if(e.KeyCode == Keys.W)
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

        // the keyisup is the method event
        // that will occur when the keys are not pressed
        // this will make the boolieans of goup,godown
        // goleft, goright will be false once the keys aren't press

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

        // this is the resetgame method
        // inside this method is we assign
        // the value of our variables that exists

        private void resetGame()
        {

            txtScore.Text = "Keys: 0";
            score = 0;

            beast1Speed = 5;
            beast2Speed = 5;
            beast3SpeedX = 5;
            beast3SpeedY = 5;
            playerSpeed = 15;

            // here is we assign the position
            // of the picture boxes in the game
            // which are the player, door, and beasts

            player.Left = 38;
            player.Top = 63;

            beast1.Left = 28;
            beast1.Top = 355;

            beast2.Left = 308;
            beast2.Top = 63;

            beast3.Left = 490;
            beast3.Top = 355;

            door.Left = 598;
            door.Top = 28;


            // this array method will make the keys
            // in the game be visible
            foreach (Control x in this.Controls)
            {
                if (x is PictureBox)
                {
                    x.Visible = true;

                }

            }

            // this will start the event main game timer
            gameTimer.Start();

        }

        // this is the maingametimer event, where the player
        // will performs action in the game
        private void mainGameTimer(object sender, EventArgs e)
        {
            
            txtScore.Text = "Keys:" + score;

            // inside in this if statements, the player
            // will move if the goup, goleft, goright, and godown
            // is true which will change the player's location
            if (goleft == true )
            {
                player.Left -= playerSpeed;
            }
            if (goright == true )
            {
                player.Left += playerSpeed;
            }
            if (godown == true )
            {
                player.Top += playerSpeed;
            }
            if (goup == true )
            {
                player.Top -= playerSpeed;
            }

            // this array method will consitst of
            // if statements wherein if the player and 
            // beasts intersect or collide with each other
            // and its consequences 
    

            foreach (Control x in this.Controls)
            {
                if(x is PictureBox)
                {
                    // here is if the player instersect with
                    // a key, the keys will be added by 1
                    // then the keys will be invisible once it itsersects it
                    if ((string)x.Tag == "keys" && x.Visible == true)
                    {
                        if (player.Bounds.IntersectsWith(x.Bounds))
                        {
                            score += 1;
                            x.Visible = false;
                        }

                    }
                    // here is if the player instersect with
                    // the hole, the gameover method will start
                    if ((string)x.Tag == "hole")
                    {
                        if (player.Bounds.IntersectsWith(x.Bounds))
                        {
                            gameOver();
                        }
                        // here is if the 3rd beast intersects with
                        // the hole, its X position will change
                        if (beast3.Bounds.IntersectsWith(x.Bounds))
                        {
                            beast3SpeedX = -beast3SpeedX;
                        }

                    }
                    // here is if the player instersect with
                    // the beast, the gameover method will start
                    if ((string)x.Tag == "beast")
                    {
                        if (player.Bounds.IntersectsWith(x.Bounds))
                        {
                            gameOver();
                        }
                    }

                    // here if the player intesects the door and 10 keys are present
                    // the current level will exit then the next level will start
                    if (door.Bounds.IntersectsWith(player.Bounds) && score == 10)
                    {
                        Level2 newLevel = new Level2();
                        this.Hide();
                        gameTimer.Stop();
                        score = 0;
                        newLevel.Show();
                    }
                }
            }

            // here is how does the beast will move
            // once the beast intersects with the holes,
            // it will change its direction
            beast1.Left += beast1Speed;

            if (beast1.Bounds.IntersectsWith(pictureBox2.Bounds) || beast1.Bounds.IntersectsWith(pictureBox5.Bounds))
            {
                beast1Speed = -beast1Speed;
            }

            beast2.Left -= beast2Speed;
            if (beast2.Bounds.IntersectsWith(pictureBox1.Bounds) || beast2.Bounds.IntersectsWith(pictureBox3.Bounds))
            {
                beast2Speed = -beast2Speed;
            }

            beast3.Left -= beast3SpeedX;
            beast3.Top -= beast3SpeedY;

            if(beast3.Top <0 || beast3.Top > 520)
            {
                beast3SpeedY = -beast3SpeedY;
            }

            if (beast3.Left < 0 || beast3.Left > 620)
            {
                beast3SpeedX = -beast3SpeedX;
            }
        }

        // this is the gameover method
        // if its exit the current level
        // and show the gameover screen
        private void gameOver()
        {
            gameTimer.Stop();
            GameOverScreen newLevel = new GameOverScreen();
            this.Hide();
            newLevel.Show();


        }

   
        }
    }

