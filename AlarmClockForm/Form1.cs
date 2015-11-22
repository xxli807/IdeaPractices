using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace AlarmClockForm
{
    public partial class Form1 : Form
    {
        Timer timer = new Timer();

        private readonly int WIDTH = 300, HEIGHT = 300, secHand = 140, minHand = 110, hrHand = 80;

        //define the center coorderate
        int cx, cy;

       

        Bitmap bmp;
        Graphics graph;

        public Form1()
        {
            InitializeComponent();
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            //create bitmap
            bmp = new Bitmap(WIDTH + 1, HEIGHT + 1);

            //center
            cx = WIDTH / 2;
            cy = Height / 2;

            this.BackColor = Color.White;

            //timer
            timer.Interval = 1000; //in millisecnd
            timer.Tick += new EventHandler(this.t_Tick);
            timer.Start();

        }

        private void t_Tick(object sender, EventArgs e)
        {
            //create graphics
            graph = Graphics.FromImage(bmp);

            int ss = DateTime.Now.Second;
            int mm = DateTime.Now.Minute;
            int hh = DateTime.Now.Hour;

            int[] handCoord = new int[2];

            //clear
            graph.Clear(Color.White);

            //draw circle
            graph.DrawEllipse(new Pen(Color.Black, 1f), 0, 0, WIDTH, HEIGHT);

            //draw figure
            graph.DrawString("12", new Font("Arial", 12), Brushes.Black, new PointF(140, 2));
            graph.DrawString("3", new Font("Arial", 12), Brushes.Black, new PointF(286, 140));
            graph.DrawString("6", new Font("Arial", 12), Brushes.Black, new PointF(142, 282));
            graph.DrawString("9", new Font("Arial", 12), Brushes.Black, new PointF(0, 140));

            //second hand
            handCoord = msCoord(ss, secHand);
            graph.DrawLine(new Pen(Color.Red, 1f), new Point(cx, cy), new Point(handCoord[0], handCoord[1]));


            //minute;
            handCoord = msCoord(mm, minHand);
            graph.DrawLine(new Pen(Color.Black, 2f), new Point(cx, cy), new Point(handCoord[0], handCoord[1]));

            //hour
            handCoord = hrCoord(hh%12, mm, hrHand);
            graph.DrawLine(new Pen(Color.Gray, 3f), new Point(cx, cy), new Point(handCoord[0], handCoord[1]));


            //load bmp in picturebox1
            pictureBox1.Image = bmp;

            //display time
            this.Text = "Analog Clock - " + hh + ":" + mm + ":" + ss;

            graph.Dispose();
           

        }

        //coord for minute and second hand
        private int[] msCoord(int val, int hlen)
        {
            int[] coord = new int[2];
            val *= 6;  //each minute and second make 6 degree 

            if (val >= 0 && val <= 180)
            {
                coord[0] = cx + (int)(hlen * Math.Sin(Math.PI * val / 180));
                coord[1] = cy - (int)(hlen * Math.Cos(Math.PI * val / 180));
            }
            else
            {
                coord[0] = cx - (int)(hlen * -Math.Sin(Math.PI * val / 180));
                coord[1] = cy - (int)(hlen * Math.Cos(Math.PI * val / 180));
            }

            return coord;
        }


        //coord for minute and second hand
        private int[] hrCoord(int hval, int mval, int hlen)
        {
            int[] coord = new int[2];

            //each hour makes 30 degree, and each min makes 0.5 degress
            int val = (int)((hval * 30) + (mval * 0.5));

            if (val >= 0 && val <= 180)
            {
                coord[0] = cx + (int)(hlen * Math.Sin(Math.PI * val / 180));
                coord[1] = cy - (int)(hlen * Math.Cos(Math.PI * val / 180));
            }
            else
            {
                coord[0] = cx - (int)(hlen * -Math.Sin(Math.PI * val / 180));
                coord[1] = cy - (int)(hlen * Math.Cos(Math.PI * val / 180));
            }

            return coord;

        }



        private void pictureBox1_Click(object sender, EventArgs e)
        {

        }
    }
}
