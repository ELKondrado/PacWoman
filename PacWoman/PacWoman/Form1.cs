using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using WMPLib;

namespace PacWoman
{
    public partial class Form1 : Form
    {
        WindowsMediaPlayer player = new WindowsMediaPlayer();
        bool goup;
        bool godown;
        bool goleft;
        bool goright;

        //viteza jucatorului
        int speed = 5;

        //vitezele fantomelor
        int ghost1 = 6;
        int ghost2 = 6;
        int ghost3 = 6;
        int ghost4 = 6;
        int ghost5 = 6;
        int ghost6 = 6;

        int scor = 0;
        public Form1()
        {
            InitializeComponent();
            label2.Visible = false;
            player.URL = "Attack on Titan Season 2 Opening - Shinzou wo Sasageyo [8-bit VRC6].mp3";
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            player.controls.play();
        }

        private void pictureBox2_Click(object sender, EventArgs e)
        {

        }

        private void pictureBox9_Click(object sender, EventArgs e)
        {

        }

        private void pictureBox11_Click(object sender, EventArgs e)
        {

        }

        private void pictureBox15_Click(object sender, EventArgs e)
        {

        }

        private void pictureBox19_Click(object sender, EventArgs e)
        {

        }

        private void pictureBox14_Click(object sender, EventArgs e)
        {

        }

        private void pictureBox32_Click(object sender, EventArgs e)
        {

        }

        private void pictureBox18_Click(object sender, EventArgs e)
        {

        }

        private void pictureBox1_Click(object sender, EventArgs e)
        {

        }

        private void pictureBox22_Click(object sender, EventArgs e)
        {

        }

        private void pictureBox23_Click(object sender, EventArgs e)
        {

        }

        private void pictureBox17_Click(object sender, EventArgs e)
        {

        }

        private void pictureBox30_Click(object sender, EventArgs e)
        {

        }

        private void pictureBox13_Click(object sender, EventArgs e)
        {

        }

        private void pictureBox12_Click(object sender, EventArgs e)
        {

        }

        private void pictureBox16_Click(object sender, EventArgs e)
        {

        }

        private void pictureBox29_Click(object sender, EventArgs e)
        {

        }

        private void pictureBox24_Click(object sender, EventArgs e)
        {

        }

        private void pictureBox26_Click(object sender, EventArgs e)
        {

        }

        private void keyisdown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.W)
            {
                goup = true;
                pacman.Image = Properties.Resources.Up;
            }
            if (e.KeyCode == Keys.A)
            {
                goleft = true;
                pacman.Image = Properties.Resources.Right;
            }
            if (e.KeyCode == Keys.S)
            {
                godown = true;
                pacman.Image = Properties.Resources.down;
            }
            if (e.KeyCode == Keys.D)
            {
                goright = true;
                pacman.Image = Properties.Resources.Left;
            }
            if (e.KeyCode == Keys.Escape)
            {
                player.controls.stop();
                Application.Exit();
            }
            //schimbarea pozitiei jucatorului
        }

        private void keyisup(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.A)
            {
                goleft = false;
            }
            if (e.KeyCode == Keys.D)
            {
                goright = false;
            }
            if (e.KeyCode == Keys.W)
            {
                goup = false;
            }
            if (e.KeyCode == Keys.S)
            {
                godown = false;
            }
        }

        private void timer1_Tick(object sender, EventArgs e)
        {
            label1.Text = "Scor: " + scor;
            //afisarea scorului pe ecran
            //miscarile jucatorului:
            if (goleft)
            {
                pacman.Left -= speed;
                //miscam jucatorul spre stanga
            }
            if (goright)
            {
                pacman.Left += speed;
                //miscam jucatorul spre dreapta
            }
            if (goup)
            {
                pacman.Top -= speed;
                //miscam jucatorul in sus
            }
            if (godown)
            {
                pacman.Top += speed;
                //miscam jucatorul in jos
            }
            //sfarsit miscari jucator

            //miscarile fantomelor 
            redGhost1.Left += ghost1;
            redGhost2.Left += ghost2;
            redGhost3.Left += ghost3;
            redGhost4.Top += ghost4;
            redGhost5.Top += ghost5;
            redGhost6.Left += ghost6;
            if (redGhost1.Bounds.IntersectsWith(pictureBox25.Bounds))
            {
                ghost1 = -ghost1;
            }
            else if (redGhost1.Bounds.IntersectsWith(pictureBox11.Bounds))
            {
                ghost1 = -ghost1;
            }

            if (redGhost2.Bounds.IntersectsWith(pictureBox14.Bounds))
            {
                ghost2 = -ghost2;
            }
            else if (redGhost2.Bounds.IntersectsWith(pictureBox13.Bounds))
            {
                ghost2 = -ghost2;
            }

            if (redGhost3.Bounds.IntersectsWith(pictureBox24.Bounds))
            {
                ghost3 = -ghost3;
            }
            else if (redGhost3.Bounds.IntersectsWith(pictureBox10.Bounds))
            {
                ghost3 = -ghost3;
            }

            if (redGhost4.Bounds.IntersectsWith(pictureBox1.Bounds))
            {
                ghost4 = -ghost4;
            }
            else if (redGhost4.Bounds.IntersectsWith(pictureBox9.Bounds))
            {
                ghost4 = -ghost4;
            }

            if (redGhost5.Bounds.IntersectsWith(pictureBox9.Bounds))
            {
                ghost5 = -ghost5;
            }
            else if (redGhost5.Bounds.IntersectsWith(pictureBox1.Bounds))
            {
                ghost5 = -ghost5;
            }

            if (redGhost6.Bounds.IntersectsWith(pictureBox12.Bounds))
            {
                ghost6 = -ghost6;
            }
            else if (redGhost6.Bounds.IntersectsWith(pictureBox15.Bounds))
            {
                ghost6 = -ghost6;
            }
            //final miscarile fantomelor 


            foreach (Control x in this.Controls)
            {
                if (x is PictureBox && (string)x.Tag == "wall")
                {
                    //verificam daca jucatorul se loveste de ziduri sau fantome , atunci e game over
                    if (((PictureBox)x).Bounds.IntersectsWith(pacman.Bounds))
                    {
                        label2.Visible = true;
                        label2.Text = "YOU LOST!";
                        timer1.Stop();
                        player.controls.stop();
                    }
                }
                if (x is PictureBox && (string)x.Tag == "ghost")
                {
                    //verificam daca jucatorul se loveste de ziduri sau fantome , atunci e game over
                    if (((PictureBox)x).Bounds.IntersectsWith(pacman.Bounds))
                    {
                        label2.Visible = true;
                        label2.Text = "YOU LOST!";
                        timer1.Stop();
                        player.controls.stop();
                    }
                }
                if (x is PictureBox && (string)x.Tag == "coin")
                {
                    //verificam daca jucatorul atinge bănuții , atunci schimbam scorul
                    if (((PictureBox)x).Bounds.IntersectsWith(pacman.Bounds))
                    {
                        this.Controls.Remove(x); //stergem banul
                        scor++;
                    }
                }
                //daca jucatorul culege toti bănuții atunci a castigat
                if (scor == 56)
                {
                    label2.Visible = true;
                    label2.Text = "YOU WON!";
                    timer1.Stop();
                    player.controls.stop();
                }
            }
        }
    }
}
