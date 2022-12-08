using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DAI
{
    internal class Player
    {
        public int gravity = 37;
        public int force;
        int character;
        public int count = 1;

        public Image player;

        public int posX { get; set; }
        public int posY { get; set; }
        public int height { get; }
        public int width { get; }

        public int health { get; set; }

        public bool gameOver;

        public bool dead;
        public bool idle = true;
        public bool reversed;
        public bool left;
        public bool right;
        public bool jump;
        public bool hit;
        public bool attack;

        int deathFrames;
        int idleFrames;
        int runFrames;
        int jumpFrames;
        int fallFrames;
        int hitFrames;
        int attackFrames;

        public Player(int character,int posX,bool reversed)
        {
            this.reversed = reversed;
            this.posX= posX;
            posY = 239;
            height = 350;
            width = 300;
            health = 100;
            this.character = character;
            Frames(this.character);
            player = Image.FromFile("Assets/Martial Hero" + this.character + "/Idle/tile000.png");
            switch(reversed)
            {
                case true:
                    player.RotateFlip(RotateFlipType.Rotate180FlipY);
                    break;
            }
        }
        private void Frames(int character)
        {
            switch (character)
            {
                case 0:
                    deathFrames = 5;
                    idleFrames = 7;
                    runFrames = 7;
                    jumpFrames = 1;
                    fallFrames = 1;
                    hitFrames = 3;
                    attackFrames = 5;
                    break;
                case 1:
                    deathFrames = 6;
                    idleFrames = 3;
                    runFrames = 7;
                    jumpFrames = 1;
                    fallFrames = 1;
                    hitFrames = 2;
                    attackFrames = 2;
                    break;
                case 2:
                    deathFrames = 10;
                    idleFrames = 9;
                    runFrames = 7;
                    jumpFrames = 2;
                    fallFrames = 2;
                    hitFrames = 2;
                    attackFrames = 6;
                    break;
            }
        }
        public void Animation()
        {
            if (dead)
            {
                if (count <= deathFrames)
                {
                    player = Image.FromFile("Assets/Martial Hero" + character + "/Death/tile00" + count + ".png");
                    switch (reversed)
                    {
                        case true:
                            player.RotateFlip(RotateFlipType.Rotate180FlipY);
                            break;
                    }
                    count++;
                }
                else
                {
                    posY = 239;
                    gameOver = true;
                }
            }
            else
            {
                if (idle)
                {
                    if (count <= idleFrames)
                    {
                        player = Image.FromFile("Assets/Martial Hero" + character + "/Idle/tile00" + count + ".png");
                        switch (reversed)
                        {
                            case true:
                                player.RotateFlip(RotateFlipType.Rotate180FlipY);
                                break;
                        }
                        count++;
                    }
                    else
                    {
                        count = 0;
                    }
                }
                else
                {
                    if (right)
                    {
                        if (count <= runFrames)
                        {
                            if (jump == false && attack == false && hit == false)
                            {
                                player = Image.FromFile("Assets/Martial Hero" + character + "/Run/tile00" + count + ".png");
                                count++;
                            }
                            if (posX + 215 < 1200)
                            {
                                posX += 17;
                            }
                        }
                        else
                        {
                            count = 0;
                        }
                    }
                    if (left)
                    {
                        if (count <= runFrames)
                        {
                            if (jump == false && attack == false && hit == false)
                            {
                                player = Image.FromFile("Assets/Martial Hero" + character + "/Run/tile00" + count + ".png");
                                player.RotateFlip(RotateFlipType.Rotate180FlipY);
                                count++;
                            }
                            if (posX > -100)
                            {
                                posX -= 17;
                            }
                        }
                        else
                        {
                            count = 0;
                        }
                    }
                    if (jump)
                    {
                        posY -= force;
                        force -= 2;
                        if (attack == false && hit == false)
                        {
                            if (force > 0)
                            {
                                if (count <= jumpFrames)
                                {
                                    player = Image.FromFile("Assets/Martial Hero" + character + "/Jump/tile00" + count + ".png");
                                    switch (reversed)
                                    {
                                        case true:
                                            player.RotateFlip(RotateFlipType.Rotate180FlipY);
                                            break;
                                    }
                                    count++;
                                }
                                else
                                {
                                    count = 0;
                                }
                            }
                            else
                            {
                                if (force < 0)
                                {
                                    if (count <= fallFrames)
                                    {
                                        player = Image.FromFile("Assets/Martial Hero" + character + "/Fall/tile00" + count + ".png");
                                        switch (reversed)
                                        {
                                            case true:
                                                player.RotateFlip(RotateFlipType.Rotate180FlipY);
                                                break;
                                        }
                                        count++;
                                    }
                                    else
                                    {
                                        count = 0;
                                    }
                                }
                            }
                        }
                        if (posY + height >= 589)
                        {
                            posY = 589 - height;
                            jump = false;
                            if (left == false && right == false && attack == false && hit == false)
                            {
                                idle = true;
                            }
                        }
                        else
                        {
                            posY += 5;
                        }
                    }
                    if (hit)
                    {
                        if (count <= hitFrames)
                        {
                            player = Image.FromFile("Assets/Martial Hero" + character + "/Take Hit/tile00" + count + ".png");
                            switch (reversed)
                            {
                                case true:
                                    player.RotateFlip(RotateFlipType.Rotate180FlipY);
                                    break;
                            }
                            count++;
                        }
                        else
                        {
                            hit = false;
                            if (attack == false && left == false && right == false && jump == false)
                            {
                                idle = true;
                            }
                            count = 0;
                        }
                    }
                    if (attack)
                    {
                        if (count <= attackFrames)
                        {
                            player = Image.FromFile("Assets/Martial Hero" + character + "/Attack/tile00" + count + ".png");
                            switch (reversed)
                            {
                                case true:
                                    player.RotateFlip(RotateFlipType.Rotate180FlipY);
                                    break;
                            }
                            count++;
                        }
                        else
                        {
                            attack = false;
                            if (hit == false && left == false && right == false && jump == false)
                            {
                                idle = true;
                            }
                            count = 0;
                        }
                    }
                }
            }
        }
    }
}
