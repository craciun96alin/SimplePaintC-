using System;
using System.Collections.Generic;
using System.Drawing;
using System.Windows.Forms;

namespace Paint
{
    public partial class Paint : Form
    {
        public Paint()
        {
            InitializeComponent();
            
        }

        int i = 1;
        Color _paintColor=Color.Black;
        Bitmap bmp;
        Item _currItem=Item.pencil;
        Point SLoc = Point.Empty;
        Point CPoint = Point.Empty;
        Point endP = Point.Empty;
        bool _draw = false, _save = false, _pencil = false;
        int _paintWidth = 8;
        StringFormat str = new StringFormat();
        FontStyle fontstyle = new FontStyle();
        

        public void setColor(Color c)
        {
            _paintColor = c;
            MainColor.BackColor = c;
        }


        private static bool MatchColor(Color a, Color b, int tolerance)
        {
            bool isAlike = false;
            if (b.R >= (a.R - tolerance) && b.R <= (a.R + tolerance))
            {
                if (b.G >= (a.G - tolerance) && b.G <= (a.G + tolerance))
                {
                    if (b.B >= (a.B - tolerance) && b.B <= (a.B + tolerance))
                    {
                        if (b.A >= (a.A - tolerance) && b.A <= (a.A + tolerance))
                        {
                            isAlike = true;
                        }
                    }
                }
            }
            return isAlike;
        }

        public void FloodFill(Graphics g, Point p1, Color color1, Color color2, int tolerace)
        {
                Queue<Point> q = new Queue<Point>();
                q.Enqueue(p1);

                while (q.Count > 0)
                {
                    Point p2 = q.Dequeue();

                    if (!MatchColor(bmp.GetPixel(p2.X, p2.Y), color1, tolerace)) continue;
                    if (MatchColor(bmp.GetPixel(p2.X, p2.Y), color2, 0)) continue;

                    Point p3 = p2, p4 = new Point(p2.X + 1, p2.Y);

                    while ((p3.X > 0) && MatchColor(bmp.GetPixel(p3.X, p3.Y), color1, tolerace))
                    {
                        bmp.SetPixel(p3.X, p3.Y, color2);


                        if ((p3.Y > 0) && MatchColor(bmp.GetPixel(p3.X, p3.Y - 1), color1, tolerace))
                            q.Enqueue(new Point(p3.X, p3.Y - 1));

                        if ((p3.Y < bmp.Height - 1) && MatchColor(bmp.GetPixel(p3.X, p3.Y + 1), color1, tolerace))
                            q.Enqueue(new Point(p3.X, p3.Y + 1));

                        p3.X--;
                    }

                    while ((p4.X < bmp.Width - 1) && MatchColor(bmp.GetPixel(p4.X, p4.Y), color1, tolerace))
                    {
                        bmp.SetPixel(p4.X, p4.Y, color2);

                        if ((p4.Y > 0) && MatchColor(bmp.GetPixel(p4.X, p4.Y - 1), color1, tolerace))
                            q.Enqueue(new Point(p4.X, p4.Y - 1));

                        if ((p4.Y < bmp.Height - 1) && MatchColor(bmp.GetPixel(p4.X, p4.Y + 1), color1, tolerace))
                            q.Enqueue(new Point(p4.X, p4.Y + 1));

                        p4.X++;
                    }
                }
                g.DrawImage(bmp, 0, 0);
        }

        public enum Item
        {
            line, rectangle, ellipse, pencil, brush, fill, text, pick, eraser 
        }
        

        private void paintZone_MouseDown(object sender, MouseEventArgs e)
        {
            _paintColor = MainColor.BackColor;
            _pencil = false;
            i = 1;
            SLoc = new Point(Convert.ToInt32(e.X), Convert.ToInt32(e.Y));
            _draw = true;
            textBox1.Text = "";
        }
        Point first = Point.Empty;
        Point second=Point.Empty;
        private void paintZone_MouseMove(object sender, MouseEventArgs e)
        {
            if (_draw)
            {
                if (i == 1)
                {  
                    first = new Point(e.X, e.Y);
                    i = 2;
                }
                else
                {
                    second = new Point(e.X, e.Y);
                    i = 1;
                    _pencil = true;
                }

                paintZone.Refresh();
                CPoint = new Point(e.X, e.Y);
                Graphics g = paintZone.CreateGraphics();

                switch (_currItem)
                {
                    case Item.pencil:
                        using (Graphics gg = Graphics.FromImage(bmp))
                        {
                            if (_pencil)
                                gg.DrawLine(new Pen(_paintColor, 1), first.X, first.Y, second.X, second.Y);

                        }
                        break;
                    case Item.rectangle:
                        g.DrawRectangle(new Pen(_paintColor, _paintWidth), e.X, e.Y, SLoc.X - e.X, SLoc.Y - e.Y);
                        g.DrawRectangle(new Pen(_paintColor, _paintWidth), SLoc.X, SLoc.Y, e.X - SLoc.X, e.Y - SLoc.Y);
                        g.DrawRectangle(new Pen(_paintColor, _paintWidth), SLoc.X, e.Y, e.X - SLoc.X, SLoc.Y - e.Y);
                        g.DrawRectangle(new Pen(_paintColor, _paintWidth), e.X, SLoc.Y, SLoc.X - e.X, e.Y - SLoc.Y);
                        break;
                    case Item.line:
                        g.DrawLine(new Pen(_paintColor,_paintWidth), SLoc.X, SLoc.Y, e.X, e.Y);
                        break;
                    case Item.ellipse:
                        g.DrawEllipse(new Pen(_paintColor,_paintWidth), SLoc.X, SLoc.Y, e.X - SLoc.X, e.Y - SLoc.Y);
                        break;
                    case Item.eraser:
                        using (Graphics gg = Graphics.FromImage(bmp))
                        {
                            gg.FillEllipse(Brushes.White, CPoint.X, CPoint.Y, _paintWidth,_paintWidth);
                        }
                        break;
                    case Item.brush:
                        using (Graphics gg = Graphics.FromImage(bmp))
                        {
                            gg.FillEllipse(new SolidBrush(_paintColor), CPoint.X, CPoint.Y, _paintWidth, _paintWidth);
                        }
                        break;
                    case Item.text:
                        float[] dashValues = { 5, 2, 4, 4 };
                        Pen blackPen = new Pen(Color.Silver, 1);
                        blackPen.DashPattern = dashValues;
                        g.DrawRectangle(blackPen, SLoc.X, SLoc.Y, e.X - SLoc.X, e.Y - SLoc.Y);

                        break;
                }
                g.Dispose();
            }
        }
            
        private void paintZone_Paint(object sender, PaintEventArgs e)
        {            
            Graphics g = e.Graphics;
            e.Graphics.DrawImage(bmp, 0, 0);
        }

        private void paintZone_MouseUp(object sender, MouseEventArgs e)
        {
            _draw = false;
            i = 1;
            _save = false;
            _pencil = false;
            endP.X = e.X;
            endP.Y = e.Y;


            using (Graphics g = Graphics.FromImage(bmp))
            {
                switch (_currItem)
                {
                    case Item.rectangle:
                        g.DrawRectangle(new Pen(_paintColor, _paintWidth), e.X, e.Y, SLoc.X - e.X, SLoc.Y - e.Y);
                        g.DrawRectangle(new Pen(_paintColor, _paintWidth), SLoc.X, SLoc.Y, e.X - SLoc.X, e.Y - SLoc.Y);
                        g.DrawRectangle(new Pen(_paintColor, _paintWidth), SLoc.X, e.Y, e.X - SLoc.X, SLoc.Y - e.Y);
                        g.DrawRectangle(new Pen(_paintColor, _paintWidth), e.X, SLoc.Y, SLoc.X - e.X, e.Y - SLoc.Y);
                        break;
                    case Item.line:
                        g.DrawLine(new Pen(_paintColor, _paintWidth), SLoc.X, SLoc.Y, e.X, e.Y);
                        break;
                    case Item.ellipse:
                        g.DrawEllipse(new Pen(_paintColor,_paintWidth), SLoc.X, SLoc.Y, endP.X - SLoc.X, endP.Y - SLoc.Y);
                        break;
                    case Item.fill:
                        FloodFill(g, new Point(endP.X, endP.Y), bmp.GetPixel(endP.X, endP.Y), _paintColor, 2);
                        break;
                    case Item.pick:
                        MainColor.BackColor = bmp.GetPixel(e.X, e.Y);
                        _paintColor = bmp.GetPixel(e.X, e.Y);
                        break;
                    case Item.text:
                        // g.DrawString( FontComboBox.Text, new Font(FontComboBox.Text, _paintWidth, fontstyle),new SolidBrush(_paintColor), new RectangleF(SLoc.X, SLoc.Y, e.X - SLoc.X, e.Y - SLoc.Y), str);
                        textBox1.Location = new Point(1000, 1000);
                        textBox1.Visible = true;
                        textBox1.Focus();
                        break;
                }
            }
            paintZone.Invalidate();
        }

        private void ellipseButton_Click(object sender, EventArgs e)
        {
            _currItem = Item.ellipse;
        }

        private void lineButton_Click(object sender, EventArgs e)
        {
            _currItem = Item.line;
        }

        private void rectangleButton_Click(object sender, EventArgs e)
        {
            _currItem = Item.rectangle;
        }

        private void TextButton_Click(object sender, EventArgs e)
        {
            _currItem = Item.text;
        }

        private void pencilButtom_Click(object sender, EventArgs e)
        {
            _currItem = Item.pencil;
        }

        private void eraserButton_Click(object sender, EventArgs e)
        {
            _currItem = Item.eraser;
        }

        private void fillColorButton_Click(object sender, EventArgs e)
        {
            _currItem = Item.fill;
        }

        private void brushButton_Click(object sender, EventArgs e)
        {
            _currItem = Item.brush;
        }

        private void colorPickerButton_Click(object sender, EventArgs e)
        {
            _currItem = Item.pick;
        }

        private void pictureBox2_Click(object sender, EventArgs e)
        {
            MainColor.BackColor = pictureBox2.BackColor;
        }

        private void pictureBox4_Click(object sender, EventArgs e)
        {
            MainColor.BackColor = pictureBox4.BackColor;
        }

        private void pictureBox3_Click(object sender, EventArgs e)
        {
            MainColor.BackColor = pictureBox3.BackColor;
        }

        private void pictureBox7_Click(object sender, EventArgs e)
        {
            MainColor.BackColor = pictureBox7.BackColor;
        }

        private void pictureBox5_Click(object sender, EventArgs e)
        {
            MainColor.BackColor = pictureBox5.BackColor;
        }

        private void pictureBox6_Click(object sender, EventArgs e)
        {
            MainColor.BackColor = pictureBox6.BackColor;
        }

        private void pictureBox10_Click(object sender, EventArgs e)
        {
            MainColor.BackColor = pictureBox10.BackColor;
        }

        private void pictureBox8_Click(object sender, EventArgs e)
        {
            MainColor.BackColor = pictureBox8.BackColor;
        }

        private void pictureBox9_Click(object sender, EventArgs e)
        {
            MainColor.BackColor = pictureBox9.BackColor;
        }

        private void pictureBox13_Click(object sender, EventArgs e)
        {
            MainColor.BackColor = pictureBox13.BackColor;
        }

        private void pictureBox11_Click(object sender, EventArgs e)
        {
            MainColor.BackColor = pictureBox11.BackColor;
        }

        private void pictureBox12_Click(object sender, EventArgs e)
        {
            MainColor.BackColor = pictureBox12.BackColor;
        }

        private void pictureBox16_Click(object sender, EventArgs e)
        {
            MainColor.BackColor = pictureBox16.BackColor;
        }

        private void pictureBox14_Click(object sender, EventArgs e)
        {
            MainColor.BackColor = pictureBox14.BackColor;
        }

        private void pictureBox15_Click(object sender, EventArgs e)
        {
            MainColor.BackColor = pictureBox15.BackColor;
        }

        private void pictureBox19_Click(object sender, EventArgs e)
        {
            MainColor.BackColor = pictureBox19.BackColor;
        }

        private void pictureBox17_Click(object sender, EventArgs e)
        {
            MainColor.BackColor = pictureBox17.BackColor;
        }

        private void pictureBox18_Click(object sender, EventArgs e)
        {
            MainColor.BackColor = pictureBox18.BackColor;
        }

        private void panel1_MouseUp(object sender, MouseEventArgs e)
        {
            _paintColor = MainColor.BackColor;
        }

        private void EditButton_Click(object sender, EventArgs e)
        {
            Form2 form2 = new Form2(this);
            form2.Show();

        }

        private void tableLayoutPanel1_Paint(object sender, PaintEventArgs e)
        {

        }

        private void SizeUpDown_ValueChanged(object sender, EventArgs e)
        {
            _paintWidth = (int)SizeUpDown.Value;
            
            
        }

        private void SizeUpDown_KeyDown(object sender, KeyEventArgs e)
        {
            if(e.KeyCode == Keys.Enter)
                _paintWidth = (int)SizeUpDown.Value;
        }

        private void Paint_Load(object sender, EventArgs e)
        {
            bmp = new Bitmap(paintZone.Width,paintZone.Height);
            foreach (FontFamily font in System.Drawing.FontFamily.Families)
            {
                FontComboBox.Items.Add(font.Name);
            }
            str.Alignment = StringAlignment.Center;
            AllignComboBox.Items.Add("Center");
            AllignComboBox.Items.Add("Far");
            AllignComboBox.Items.Add("Near");
            fontstyle = FontStyle.Regular;

        }

        private void FontComboBox_SelectedIndexChanged(object sender, EventArgs e)
        {
            
        }

        private void AllignComboBox_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (AllignComboBox.Text == "Center")
                str.Alignment = StringAlignment.Center;
            else if (AllignComboBox.Text == "Far")
                str.Alignment = StringAlignment.Far;
            else
                str.Alignment = StringAlignment.Near;

        }
        
        private void Boldbutton_Click(object sender, EventArgs e)
        {
            
            fontstyle = FontStyle.Bold;
        }

        private void ItalicButton_Click(object sender, EventArgs e)
        {
            fontstyle = FontStyle.Italic;
        }

        private void UnderButtton_Click(object sender, EventArgs e)
        {
            fontstyle = FontStyle.Underline;
        }

        private void Reset_Click(object sender, EventArgs e)
        {
            FontComboBox.SelectedValue = "Arial";
            FontComboBox.Text = "Arial";
            SizeUpDown.Value = 8; 
            AllignComboBox.SelectedValue = "Center";
            AllignComboBox.Text = "Center";
            fontstyle = FontStyle.Regular;
        }



        private void textBox1_KeyDown(object sender, KeyEventArgs e)
        {
            paintZone.Refresh();


            if (e.KeyCode == Keys.Enter)
            {
                using (Graphics g = Graphics.FromImage(bmp))
                {
                    g.DrawString(textBox1.Text, new Font(FontComboBox.Text, _paintWidth, fontstyle), new SolidBrush(_paintColor), new RectangleF(SLoc.X, SLoc.Y, endP.X - SLoc.X, endP.Y - SLoc.Y), str);
                }
                paintZone.Focus();
            }

            Graphics gg = paintZone.CreateGraphics();
            gg.DrawString(textBox1.Text, new Font(FontComboBox.Text, _paintWidth, fontstyle), new SolidBrush(_paintColor), new RectangleF(SLoc.X, SLoc.Y, endP.X - SLoc.X, endP.Y - SLoc.Y), str);
    
        }

        private void textBox1_KeyPress(object sender, KeyPressEventArgs e)
        {

        }

        private void toolStripButton2_Click(object sender, EventArgs e)
        {
            OpenFileDialog o = new OpenFileDialog();
            o.Filter = "Png files|*.png|jpeg files|*.jpg|bitmaps|*.bmp";
            Image i; 
            if(o.ShowDialog() == DialogResult.OK)
            {
                i = (Image)Image.FromFile(o.FileName).Clone();
                using (Graphics g = Graphics.FromImage(bmp))
                {
                    g.FillRectangle(new SolidBrush(Color.White), new Rectangle(0, 0, paintZone.Width, paintZone.Height));
                    g.DrawImageUnscaledAndClipped(i, new Rectangle(0, 0, paintZone.Width, paintZone.Height));
                }
                paintZone.Refresh();

            }
        }

        private void toolStripButton3_Click(object sender, EventArgs e)
        {
            SaveFileDialog s = new SaveFileDialog();
            s.Filter = "Png filse|*.png|jpeg files|*.jpg|bitmaps|*.bmp";
            if (s.ShowDialog() == DialogResult.OK)
            {
                bmp.Save(s.FileName);
            }
            _save = true;
        }

        private void paintZone_SizeChanged(object sender, EventArgs e)
        {
            
            bmp = new Bitmap(paintZone.Width,paintZone.Height);
            paintZone.Refresh();
        }

        private void toolStripButton1_Click(object sender, EventArgs e)
        {
            DialogResult f;
            if (_save == false)
            {
                f = MessageBox.Show("You did not save!\n You want a new file anyway?", "Warning!", MessageBoxButtons.OKCancel, MessageBoxIcon.Exclamation);
            }
            else
            {
                f = DialogResult.OK;
            }

            if (f == DialogResult.OK)
            {
                using (Graphics g = Graphics.FromImage(bmp))
                {
                    g.FillRectangle(new SolidBrush(Color.White), new Rectangle(0, 0, paintZone.Width, paintZone.Height));
                }
                paintZone.Refresh();
            }
        }

        private void paintZone_Click(object sender, EventArgs e)
        {
        }
    }
}
