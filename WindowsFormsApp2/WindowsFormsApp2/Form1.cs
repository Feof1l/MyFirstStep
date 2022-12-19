using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Drawing.Drawing2D;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace WindowsFormsApp2
{
    public partial class Form1 : Form
    {

        bool first = true;
        int[,] m = new int[5, 5];
        bool flag = false;
        int dx;
        int dy;
        bool emblem = false;
        
        TextureBrush texture1;
        TextureBrush texture2;
        private List<Button> listButtons = new List<Button>();

        static void DrawEmblem(Graphics g,Button But)
        {
            //Graphics g = Graphics.FromHwnd(But.Handle);
            int width = But.Width;
            int height = But.Height;
            g.FillEllipse(new SolidBrush(Color.Gold), width / 3 +10 , height / 3 - 10 , width / 2  , height / 2 );
            g.FillRectangle(new SolidBrush(Color.White), width / 3 + 24, height / 3 , width / 3  + 4, height / 3 - 17);
            g.FillRectangle(new SolidBrush(Color.Blue), width / 3 + 24, height / 3 +5, width / 3 + 4, height / 3 - 17 );
            g.FillRectangle(new SolidBrush(Color.Red), width / 3 + 24, height / 3 + 9, width / 3 + 4, height / 3 - 17);
        }
        public Form1()
        {
            InitializeComponent();
            listButtons.Add(button1);
            listButtons.Add(button2);
            listButtons.Add(button3);
            
        }

        private void Form1_Load(object sender, EventArgs e)
        {

        }

        private void button1_Paint(object sender, PaintEventArgs e)
        {

            if (emblem)
            {
                DrawEmblem(e.Graphics, button2);
            }
            /* Graphics g = Graphics.FromHwnd(button1.Handle);
             int width = button1.Width;
             int height = button1.Height;
             g.FillEllipse(new SolidBrush(Color.Gold), width / 3 + 10, height / 3 - 10, width / 2, height / 2);
             g.FillRectangle(new SolidBrush(Color.White), width / 3 + 24, height / 3, width / 3 + 4, height / 3 - 17);
             g.FillRectangle(new SolidBrush(Color.Blue), width / 3 + 24, height / 3 + 5, width / 3 + 4, height / 3 - 17);
             g.FillRectangle(new SolidBrush(Color.Red), width / 3 + 24, height / 3 + 9, width / 3 + 4, height / 3 - 17);*/
        }

        private void Form1_Paint(object sender, PaintEventArgs e)
        { 
            //foreach (Button x in listButtons)
            //    DrawEmblem(x);
            if (flag)
            {
                e.Graphics.DrawEllipse(new Pen(Color.Blue, 3), 550, 250, 50, 50);
                e.Graphics.DrawEllipse(new Pen(Color.Yellow, 3), 580, 270, 50, 50);
                e.Graphics.DrawEllipse(new Pen(Color.Black, 3), 610, 250, 50, 50);
                e.Graphics.DrawEllipse(new Pen(Color.Green, 3), 640, 270, 50, 50);
                e.Graphics.DrawEllipse(new Pen(Color.Red, 3), 670, 250, 50, 50);
                e.Graphics.DrawLine(new Pen(Color.Blue, 3), 600, 279, 600, 275);
                e.Graphics.DrawLine(new Pen(Color.Black, 3), 660, 269, 660, 275);
                e.Graphics.DrawLine(new Pen(Color.Green, 3), 669, 270, 673, 270);
                e.Graphics.DrawLine(new Pen(Color.Yellow, 3), 608, 269, 613, 272);
            }
            
        }

        private void button1_Click(object sender, EventArgs e)
        {
            Invalidate();
            flag = false;
        }

        private void button3_Paint(object sender, PaintEventArgs e)
        {
            if (emblem)
            {
                DrawEmblem(e.Graphics, button2);
            }
        }

        private void pictureBox1_Paint(object sender, PaintEventArgs e)

        {
            Image myimage = Image.FromFile("D:\\Sistym Prog\\LR6_1\\LR6\\WindowsFormsApp2\\WindowsFormsApp2\\im.bmp");
            TextureBrush myTextureBrush = new TextureBrush(myimage);
            Color newcolor = Color.FromArgb(150, Color.MediumAquamarine);
            SolidBrush brush = new SolidBrush(newcolor);

            int width = pictureBox1.Width;
            int height = pictureBox1.Height;
           



            dx = width / 5 ;
            dy = height / 5 ;
            
            Pen p = new Pen(Color.Black, 1);
            e.Graphics.FillRectangle(myTextureBrush, 0, 0, width, height);
            e.Graphics.FillRectangle(brush, 0, 0, width, height);
            
            e.Graphics.DrawLine(p, 0, 0, 0, height);
            e.Graphics.DrawLine(p, 0, 0, width , 0);
            for (int i = 1; i < 6; ++i)
            {
                e.Graphics.DrawLine(p, dx * i -1, 0, dx * i-1, height -1);
                e.Graphics.DrawLine(p, 0, dy * i -1, width -1, dy * i -1);
            }
            
        }
        public static bool IsFull(int[,] m)
        {
            for (int i = 0; i <= m.GetUpperBound(0); i++)
                for (int j = 0; j <= m.GetUpperBound(1); j++)
                    if (m[i, j] == 0)
                        return false;
            return true;
        }
        private int Winner()
        {
            for (int i = 0; i < 5; i++)
                for (int j = 0; j < 2; j++)
                    if (m[i, j] > 0)
                    {
                        for (int k = j + 1; k < 5; k++)
                        {
                            if (m[i, k] != m[i, j])
                                break;
                            else if (k - j == 3)
                                if (m[i, j] == 1)
                                    return 1;
                                else
                                    return 2;
                        }
                    }
            for (int i = 0; i < 2; i++)
                for (int j = 0; j < 5; j++)
                    if (m[i, j] > 0)
                    {
                        for (int k = i + 1; k < 5; k++)
                        {
                            if (m[k, j] != m[i, j])
                                break;
                            else
                            if (k - i == 3)
                                if (m[i, j] == 1)
                                    return 1;
                                else
                                    return 2;
                        }
                    }
            return 0;
        } 

        private void pictureBox1_MouseClick_1(object sender, MouseEventArgs e)
        {
                int x = e.X / (dx+1);
                int y = e.Y / (dy+1);

            if (m[x, y] == 0)
            {
                if (radioButton1.Checked == true)
                {
                    Image image1 = Image.FromFile("D:\\Sistym Prog\\LR6_1\\LR6\\WindowsFormsApp2\\WindowsFormsApp2\\1.png");
                    texture1 = new TextureBrush(image1);
                    Image image2 = Image.FromFile("D:\\Sistym Prog\\LR6_1\\LR6\\WindowsFormsApp2\\WindowsFormsApp2\\2.png");
                    texture2 = new TextureBrush(image2);
                }
                else
                {
                    Image image1 = Image.FromFile("D:\\Sistym Prog\\LR6_1\\LR6\\WindowsFormsApp2\\WindowsFormsApp2\\2.png");
                    texture1 = new TextureBrush(image1);
                    Image image2 = Image.FromFile("D:\\Sistym Prog\\LR6_1\\LR6\\WindowsFormsApp2\\WindowsFormsApp2\\1.png");
                    texture2 = new TextureBrush(image2);
                }
                Graphics gr = pictureBox1.CreateGraphics();
                Rectangle r = new Rectangle(x * dx, y * dy, dx, dy);
                if (first)
                {
                    LinearGradientBrush br = new LinearGradientBrush(r, Color.PowderBlue, Color.Lime, LinearGradientMode.Vertical);
                    gr.FillRectangle(br, r);
                    gr.FillRectangle(texture1, r);
                    m[x, y] = 1;
                }
                else
                {
                    LinearGradientBrush br = new LinearGradientBrush(r, Color.Indigo, Color.HotPink, LinearGradientMode.Vertical);
                    gr.FillRectangle(br, r);
                    gr.FillRectangle(texture2, r);
                    m[x, y] = 2;
                }

                int winner = Winner();
                if (winner != 0)
                {
                    label1.Text = "Победил " + (winner == 1 ? "первый " : "второй ") + "игрок.";
                    radioButton1.Enabled = true;
                    radioButton2.Enabled = true;
                    Refresh();
                    for (int i = 0; i <= m.GetUpperBound(0); i++)
                        for (int j = 0; j <= m.GetUpperBound(1); j++)
                            m[i, j] = 0;
                    first = true;
                }
                else if (IsFull(m))
                {
                    label1.Text = "Боевая ничья";
                    radioButton1.Enabled = true;
                    radioButton2.Enabled = true;
                    Refresh();
                    for (int i = 0; i <= m.GetUpperBound(0); i++)
                        for (int j = 0; j <= m.GetUpperBound(1); j++)
                            m[i, j] = 0;
                    first = true;
                    
                     
                    
                    
                }
                else
                {
                    first = !first;
                    radioButton1.Enabled = false;
                    radioButton2.Enabled = false;



                }
                
            }
        }

        private void radioButton2_CheckedChanged(object sender, EventArgs e)
        {

        }

        private void button3_Click(object sender, EventArgs e)
        {
            //var hWnd = this.Handle;
            Invalidate();
            flag = true;
        }

        private void button4_Click(object sender, EventArgs e)
        {
           // flag = true;
        }

        private void groupBox1_Enter(object sender, EventArgs e)
        {

        }

        private void radioButton1_CheckedChanged(object sender, EventArgs e)
        {
           
        }

        private void button2_Paint(object sender, PaintEventArgs e)
        {
            if (emblem)
            {
                DrawEmblem(e.Graphics,button2);
            }
        }

        private void button2_Click(object sender, EventArgs e)
        {
            emblem = !emblem;
            foreach (Button x in listButtons)
                x.Refresh();
        }
    }
}
