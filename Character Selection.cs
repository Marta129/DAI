using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace DAI
{
    public partial class Character_Selection : Form
    {
        Thread th;
        Bitmap bm = new Bitmap(new Bitmap("Assets/Cursor.png"), 32, 32);
        int player1 = -1;
        int player2 = -1;
        public Character_Selection()
        {
            InitializeComponent();
            this.Cursor = new Cursor(bm.GetHicon());
        }
        private void Start(object sender, EventArgs e)
        {
            bool okay = true;

            if(player1 == -1 && player2 == -1)
            {
                okay= false;
                label4.Text = "Both players must choose a character";
                panel7.Visible = true;
            }
            else
            {
                if(player1==-1)
                {
                    okay = false;
                    label4.Text = "Player 1 must choose a character";
                    panel7.Visible = true;
                }
                else
                {
                    if(player2==-1)
                    {
                        okay = false;
                        label4.Text = "Player 2 must choose a character";
                        panel7.Visible = true;
                    }
                }
            }

            if(okay)
            {
                this.Close();
                th = new Thread(Start);
                th.SetApartmentState(ApartmentState.STA);
                th.Start();
            }
        }
        private void Start(object? obj)
        {
            Application.Run(new Game_Window(player1,player2));
        }
        private void Back(object sender, EventArgs e)
        {
            this.Close();
            th = new Thread(Back);
            th.SetApartmentState(ApartmentState.STA);
            th.Start();
        }
        private void Back(object? obj)
        {
            Application.Run(new Form1());
        }

        private void Player1_Martial_Hero(object sender, EventArgs e)
        {
            if(player1==1)
            {
                panel2.BackColor = Color.Empty;
            }
            else
            {
                if(player1== 2)
                {
                    panel3.BackColor = Color.Empty;
                }
            }
            player1 = 0;
            panel1.BackColor = Color.OrangeRed;
        }

        private void Player1_Martial_Hero1(object sender, EventArgs e)
        {
            if (player1 == 0)
            {
                panel1.BackColor = Color.Empty;
            }
            else
            {
                if (player1 == 2)
                {
                    panel3.BackColor = Color.Empty;
                }
            }
            player1 = 1;
            panel2.BackColor = Color.OrangeRed;
        }

        private void Player1_Martial_Hero2(object sender, EventArgs e)
        {
            if (player1 == 0)
            {
                panel1.BackColor = Color.Empty;
            }
            else
            {
                if (player1 == 1)
                {
                    panel2.BackColor = Color.Empty;
                }
            }
            player1 = 2;
            panel3.BackColor = Color.OrangeRed;
        }

        private void Player2_Martial_Hero(object sender, EventArgs e)
        {
            if(player2==1)
            {
                panel5.BackColor = Color.Empty;
            }
            else
            {
                if(player2==2)
                {
                    panel4.BackColor=Color.Empty;
                }
            }
            player2 = 0;
            panel6.BackColor= Color.OrangeRed;
        }

        private void Player2_Martial_Hero1(object sender, EventArgs e)
        {
            if (player2 == 0)
            {
                panel6.BackColor = Color.Empty;
            }
            else
            {
                if (player2 == 2)
                {
                    panel4.BackColor = Color.Empty;
                }
            }
            player2 = 1;
            panel5.BackColor = Color.OrangeRed;
        }

        private void Player2_Martial_Hero2(object sender, EventArgs e)
        {
            if (player2 == 0)
            {
                panel6.BackColor = Color.Empty;
            }
            else
            {
                if (player2 == 1)
                {
                    panel5.BackColor = Color.Empty;
                }
            }
            player2 = 2;
            panel4.BackColor = Color.OrangeRed;
        }

        private void Close(object sender, EventArgs e)
        {
            panel7.Visible= false;
        }
    }
}
