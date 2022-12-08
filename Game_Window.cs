using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Media;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Windows.Forms.VisualStyles;
using WMPLib;

namespace DAI
{
    public partial class Game_Window : Form
    {
        int ticks = 70;
        Thread th;
        Image shop = Image.FromFile("Assets/Background/Shop/tile000.png");
        SoundPlayer soundPlayer = new SoundPlayer("Assets/Background Song.wav");
        Bitmap bm = new Bitmap(new Bitmap("Assets/Cursor.png"),32,32);
        int shop_Frames = 1;
        bool play = true;
        Player player1;
        Player player2;
        public Game_Window(int player1, int player2)
        {
            InitializeComponent();
            this.Cursor = new Cursor(bm.GetHicon());
            Cursor.Hide();
            this.player1 = new Player(player1,0,false);
            this.player2 = new Player(player2,900,true);
            progressBar1.Value = this.player1.health;
            progressBar2.Value = this.player2.health;
            PlaySong(play);
        }
        private void Character_Animations(object sender, EventArgs e)
        {
            this.Invalidate();
            if(player1.gameOver!=true)
            {
                player1.Animation();
            }
            if(player2.gameOver!=true)
            {
                player2.Animation();
            }

        }
        private void Time(object sender, EventArgs e)
        {
            if(ticks> 0)
            {
                ticks--;
                label1.Text=ticks.ToString();
                if(ticks==0)
                {
                    if (player1.health > player2.health)
                    {
                        label8.Text = "Player 1 won";
                        Cursor.Show();
                        Shop.Stop();
                        Animation.Stop();
                        Time_Left.Stop();
                        soundPlayer.Stop();
                        panel1.Visible = true;
                    }
                    else
                    {
                        if (player1.health < player2.health)
                        {
                            label8.Text = "Player 2 won";
                            Cursor.Show();
                            Shop.Stop();
                            Animation.Stop();
                            Time_Left.Stop();
                            soundPlayer.Stop();
                            panel1.Visible = true;
                        }
                        else
                        {
                            if (player1.health == player2.health)
                            {
                                label8.Text = "It is a tie";
                                Cursor.Show();
                                Shop.Stop();
                                Animation.Stop();
                                Time_Left.Stop();
                                soundPlayer.Stop();
                                panel1.Visible = true;
                            }
                        }
                    }
                }
                else
                {
                    if (player1.gameOver == true && player2.gameOver == true)
                    {
                        label8.Text = "It is a tie";
                        Cursor.Show();
                        Shop.Stop();
                        Animation.Stop();
                        Time_Left.Stop();
                        soundPlayer.Stop();
                        panel1.Visible = true;
                    }
                    else
                    {
                        if (player1.gameOver == true)
                        {
                            label8.Text = "Player 2 won";
                            Cursor.Show();
                            Shop.Stop();
                            Animation.Stop();
                            Time_Left.Stop();
                            soundPlayer.Stop();
                            panel1.Visible = true;
                        }
                        else
                        {
                            if (player2.gameOver == true)
                            {
                                label8.Text = "Player 1 won";
                                Cursor.Show();
                                Shop.Stop();
                                Animation.Stop();
                                Time_Left.Stop();
                                soundPlayer.Stop();
                                panel1.Visible = true;
                            }
                        }
                    }
                }
            }
        }
        private void Game_Window_KeyUp(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.D)
            {
                player1.right = false;
                if(player1.left==false && player1.attack==false && player1.hit==false && player1.jump==false)
                {
                    player1.idle = true;
                }
            }
            if (e.KeyCode == Keys.A)
            {
                player1.left = false;
                if (player1.right == false && player1.attack == false && player1.hit == false && player1.jump == false)
                {
                    player1.idle = true;
                }
            }
            if(e.KeyCode==Keys.Right)
            {
                player2.right=false;
                if(player2.left==false && player2.attack==false && player2.hit==false && player2.jump==false)
                {
                    player2.idle = true;
                }
            }
            if(e.KeyCode==Keys.Left)
            {
                player2.left=false;
                if (player2.right == false && player2.attack == false && player2.hit == false && player2.jump == false)
                {
                    player2.idle = true;
                }
            }
        }

        private void Game_Window_KeyDown(object sender, KeyEventArgs e)
        {
            if(e.KeyCode==Keys.Escape)
            {
                Pause.Visible = true;
                Shop.Stop();
                Animation.Stop();
                Time_Left.Stop();
                Cursor.Show();
            }
            if(Pause.Visible==false)
            {
                //Player 1
                if (e.KeyCode == Keys.D)
                {
                    player1.right = true;
                    player1.reversed = false;
                    player1.idle = false;
                }
                if (e.KeyCode == Keys.A)
                {
                    player1.left = true;
                    player1.reversed = true;
                    player1.idle = false;
                }
                if (player1.jump != true)
                {
                    if (e.KeyCode == Keys.W)
                    {
                        player1.jump = true;
                        player1.force = player1.gravity;
                        player1.idle = false;
                    }
                }
                if (player1.hit != true && player1.attack != true)
                {
                    if (e.KeyCode == Keys.Space)
                    {
                        player1.attack = true;
                        player1.idle = false;
                        player1.count = 0;
                        if(player1.posY+200>player2.posY && player2.posY+200>player1.posY && player1.posX + 160 > player2.posX && player2.posX + 160 > player1.posX)
                        {
                            if(player2.dead!=true)
                            {
                                if(player2.health-5==0)
                                {
                                    player2.health = 0;
                                    player2.dead = true;
                                }
                                else
                                {
                                    player2.health -= 5;
                                    player2.hit = true;
                                    player2.idle= false;
                                }
                                player2.count = 0;
                            }
                        }
                        progressBar2.Value = player2.health;
                    }
                }
                //Player 2
                if (e.KeyCode == Keys.Right)
                {
                    player2.right = true;
                    player2.reversed = false;
                    player2.idle = false;
                }
                if (e.KeyCode == Keys.Left)
                {
                    player2.left = true;
                    player2.reversed = true;
                    player2.idle = false;
                }
                if (player2.jump != true)
                {
                    if (e.KeyCode == Keys.Up)
                    {
                        player2.jump = true;
                        player2.force = player2.gravity;
                        player2.idle = false;
                    }
                }
                if (player2.hit != true && player2.attack != true)
                {
                    if (e.KeyCode == Keys.Enter)
                    {
                        player2.attack = true;
                        player2.idle = false;
                        player2.count = 0;
                        if (player1.posY + 200 > player2.posY && player2.posY + 200 > player1.posY && player1.posX + 160 > player2.posX && player2.posX + 160 > player1.posX)
                        {
                            if(player1.dead!=true)
                            {
                                if(player1.health-5==0)
                                {
                                    player1.health=0;
                                    player1.dead = true;
                                }
                                else
                                {
                                    player1.health -= 5;
                                    player1.hit = true;
                                    player1.idle = false;
                                }
                                player1.count = 0;
                            }
                        }
                        progressBar1.Value = player1.health;
                    }
                }
            }
        }

        private void Game_Window_Paint(object sender, PaintEventArgs e)
        {
            e.Graphics.DrawImage(shop, 700, 157, 400, 425);
            e.Graphics.DrawImage(player1.player,player1.posX,player1.posY,player1.width,player1.height);
            e.Graphics.DrawImage(player2.player,player2.posX,player2.posY,player2.width,player2.height);
        }

        private void Shop_Tick(object sender, EventArgs e)
        {
            if(shop_Frames<=5)
            {
                shop = Image.FromFile("Assets/Background/Shop/tile00" + shop_Frames + ".png");
                shop_Frames++;
            }
            else
            {
                shop_Frames = 0;
            }
        }

        private void radioButton2_CheckedChanged(object sender, EventArgs e)
        {
            play = false;
            PlaySong(play);
        }

        private void radioButton1_CheckedChanged(object sender, EventArgs e)
        {
            play = true;
            PlaySong(play);
        }

        private void Menu(object sender, EventArgs e)
        {
            soundPlayer.Stop();
            this.Close();
            th = new Thread(OpenNewForm);
            th.SetApartmentState(ApartmentState.STA);
            th.Start();
        }

        private void Close(object sender, EventArgs e)
        {
            Cursor.Hide();
            Pause.Visible = false;
            Shop.Start();
            Animation.Start();
            Time_Left.Start();
        }
        private void OpenNewForm(object? obj)
        {
            Application.Run(new Form1());
        }

        private void button3_Click(object sender, EventArgs e)
        {
            this.Close();
            th = new Thread(OpenNewForm);
            th.SetApartmentState(ApartmentState.STA);
            th.Start();
        }
        private void PlaySong(bool play)
        {
            if(play)
            {
                soundPlayer.PlayLooping();
            }
            else
            {
                soundPlayer.Stop();
            }
        }
    }
}
