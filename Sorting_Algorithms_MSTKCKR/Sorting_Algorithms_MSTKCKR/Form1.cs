using System;
using System.Collections;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Sorting_Algorithms_MSTKCKR
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        PictureBox[] pic;

        Random rand = new Random();

        private void button1_Click(object sender, EventArgs e)
        {
            int num = panel3.Controls.Count;
            for (int i = 0; i < num; i++)
            {
                panel3.Controls.RemoveAt(0);
            }
            num = 255;
            pic = new PictureBox[num];
            ArrayList heightList = new ArrayList();
            int width = this.Width / 255;
            for (int i = 0; i < num; i++)
            {
                heightList.Add(i + 1);
                pic[i] = new PictureBox();
                pic[i].Width = width;
                pic[i].TabStop = false;
                pic[i].Height = 5;
                pic[i].Top = 0;
                pic[i].Left = i * width + 10;
                pic[i].Text = "";
                panel3.Controls.Add(pic[i]);
                if ((i + 1) % 20 == 0)
                    panel3.Refresh();
            }
            for (int i = 0; i < num; i++)
            {
                int r = rand.Next(heightList.Count);
                pic[i].Height = int.Parse(heightList[r].ToString());
                pic[i].BackColor = Color.FromArgb(pic[i].Height, 0, 0);
                heightList.RemoveAt(r);
                pic[i].Left = i * width + 10;
                pic[i].Top = panel1.Top - pic[i].Height - 75;

            }

        }

        private void button2_Click(object sender, EventArgs e)
        {
            timer1.Start();
        }

        int x = 0, y = 0;

        private void timer1_Tick(object sender, EventArgs e)
        {
            #region
            if (x < pic.Length)
            {
                y = 0;
                while (y < pic.Length - 1)
                {
                    if (pic[x].Height < pic[y].Height)
                    {
                        int takas = pic[x].Left;
                        pic[x].Left = pic[y].Left;
                        pic[y].Left = takas;

                        PictureBox tak = pic[x];
                        pic[x] = pic[y];
                        pic[y] = tak;
                    }
                    y++;
                }
                x++;
            }
            else
            {
                label1.Text = " Finish";
                x = y = 0;
                timer1.Stop();
            }
            #endregion
            this.MinimumSize = new Size(542, 451);
        }
    }
}
