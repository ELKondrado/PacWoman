using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace PacWoman
{
    public partial class Form2 : Form
    {
        public Form2()
        {
            InitializeComponent();
        }

        private void Form2_Load(object sender, EventArgs e)
        {

        }

        private void button3_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            MessageBox.Show("-Apăsând W, se va merge în sus." + "\n" + "-Apăsând S , se va merge în jos." + "\n" + "-Apăsând A, se va merge în stânga."
                + "\n" + "-Apăsând D , se va merge în dreapta." + "\n" + "-Scopul jocului este de a colecta toți bănuții." + "n" + "-Coliziunea cu pereții sau cu fantomele roșii duce la pierderea jocului."
                + "\n" + "-După finalizarea jocului, indiferent de rezultat, pentru a iesi, apasati Esc.");
        }

        private void button1_Click(object sender, EventArgs e)
        {
            Form1 f1 = new Form1();
            f1.ShowDialog();
        }
    }
}
