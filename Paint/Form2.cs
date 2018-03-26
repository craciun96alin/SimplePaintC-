using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Paint
{
    public partial class Form2 : Form
    {
        Paint paint;
        public Form2( Paint p)
        {
            paint = p;
            InitializeComponent();
        }

        bool click=false;

        private void Form2_Load(object sender, EventArgs e)
        {

        }

        private void colors_MouseDown(object sender, MouseEventArgs e)
        {
            click = true;
        }

        private void colors_MouseUp(object sender, MouseEventArgs e)
        {
            if (click && e.Y < 240 && e.X < 240 && e.Y > 0 && e.X > 0)
            {
                Bitmap bitmap = (Bitmap)colors.Image.Clone();
                Color color = bitmap.GetPixel(e.X, e.Y);

                RedTrack.Value = color.R;
                RedUpDown.Value = color.R;

                BlueTrack.Value = color.B;
                BlueUpDown.Value = color.B;

                GreenTrack.Value = color.G;
                GreenUpDown.Value = color.G;

                AlphaTrack.Value = color.A;
                AlphaUpDown.Value = color.A;

                pictureBox2.BackColor = color;
            }
            click = false;
        }

        private void colors_MouseMove(object sender, MouseEventArgs e)
        {
            if(click && e.Y<240 && e.X<240 && e.Y>0 && e.X>0)
            {
                Bitmap bitmap = (Bitmap)colors.Image.Clone();
                Color color = bitmap.GetPixel(e.X,e.Y);

                RedTrack.Value = color.R;
                RedUpDown.Value = color.R;

                BlueTrack.Value = color.B;
                BlueUpDown.Value = color.B;

                GreenTrack.Value = color.G;
                GreenUpDown.Value = color.G;

                AlphaTrack.Value = color.A;
                AlphaUpDown.Value = color.A;

                pictureBox2.BackColor = color;
            }
        }

        private void colors_MouseLeave(object sender, EventArgs e)
        {
            click = false;
        }

        private Color changeTracks()
        {
            Color color = Color.Black;
            AlphaUpDown.Value = AlphaTrack.Value;
            RedUpDown.Value = RedTrack.Value;
            GreenUpDown.Value = GreenTrack.Value;
            BlueUpDown.Value = BlueTrack.Value;
            color = Color.FromArgb(AlphaTrack.Value, RedTrack.Value, GreenTrack.Value, BlueTrack.Value);
            return color;
        }

        private Color changeUpDowns()
        {
            Color color = Color.Black;
            AlphaTrack.Value = (int)AlphaUpDown.Value;
            RedTrack.Value = (int)RedUpDown.Value;
            GreenTrack.Value = (int)GreenUpDown.Value;
            BlueTrack.Value = (int)BlueUpDown.Value ;
            color = Color.FromArgb(AlphaTrack.Value, RedTrack.Value, GreenTrack.Value, BlueTrack.Value);
            return color;
        }

        private void BlueTrack_ValueChanged(object sender, EventArgs e)
        {
            pictureBox2.BackColor = changeTracks();
        }

        private void GreenTrack_Scroll(object sender, EventArgs e)
        {
            pictureBox2.BackColor = changeTracks();
        }

        private void RedTrack_Scroll(object sender, EventArgs e)
        {
            pictureBox2.BackColor = changeTracks();
        }

        private void AlphaTrack_Scroll(object sender, EventArgs e)
        {
            pictureBox2.BackColor = changeTracks();
        }

        private void AlphaUpDown_ValueChanged(object sender, EventArgs e)
        {
            pictureBox2.BackColor = changeUpDowns();
        }

        private void RedUpDown_ValueChanged(object sender, EventArgs e)
        {
            pictureBox2.BackColor = changeUpDowns();
        }

        private void GreenUpDown_ValueChanged(object sender, EventArgs e)
        {
            pictureBox2.BackColor = changeUpDowns();
        }

        private void BlueUpDown_ValueChanged(object sender, EventArgs e)
        {
            pictureBox2.BackColor = changeUpDowns();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            
            paint.setColor(pictureBox2.BackColor);
            this.Close();
            
        }

    }
}
