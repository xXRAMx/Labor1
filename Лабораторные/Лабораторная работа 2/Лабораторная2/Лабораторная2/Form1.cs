using System;
using System.Drawing;
using System.Drawing.Drawing2D;
using System.Windows.Forms;

namespace Lab5_Graphics
{
    public partial class Form1 : Form
    {
        Color drawColor = Color.DarkBlue;
        Font drawFont = new Font("Times New Romans", 13);
        Bitmap loadedImage;
        Point clickPoint = new Point(100, 100);

        public Form1()
        {
            InitializeComponent();
            this.DoubleBuffered = true; // двойная буферизация
        }

        // ===== ЧАСТЬ I =====
        private void Form1_Paint(object sender, PaintEventArgs e)
        {
            Graphics g = e.Graphics;

            // --- Перо с CompoundArray ---
            Pen pen = new Pen(drawColor, 6);
            pen.CompoundArray = new float[] { 0.0f, 0.3f, 0.6f, 1.0f };

            // --- Набор прямоугольников ---
            Rectangle[] rects =
            {
                new Rectangle(20, 20, 80, 50),
                new Rectangle(110, 20, 80, 50),
                new Rectangle(200, 20, 80, 50)
            };

            LinearGradientBrush gradBrush =
                new LinearGradientBrush(this.ClientRectangle,
                Color.LightBlue, Color.White, 45);

            g.FillRectangles(gradBrush, rects);
            g.DrawRectangles(pen, rects);

            // --- Сектор ---
            g.FillPie(Brushes.LightGreen, 20, 100, 120, 120, 30, 200);
            g.DrawPie(pen, 20, 100, 120, 120, 30, 200);

            // --- Линия ---
            g.DrawLine(pen, 200, 120, 350, 200);

            // --- Многострочный текст ---
            string text = "Лабораторная работа №5\nВариант 3\nWindows Forms";
            g.DrawString(text, drawFont, Brushes.Black,
                new RectangleF(200, 220, 200, 100));

            // --- Вывод изображения через DrawImage ---
            if (loadedImage != null)
            {
                g.DrawImage(loadedImage, 400, 20, 150, 100);
            }

            // --- GraphicsPath (Часть III, п.1) ---
            GraphicsPath path = new GraphicsPath();
            path.AddEllipse(clickPoint.X, clickPoint.Y, 60, 40);
            path.AddLine(clickPoint.X, clickPoint.Y + 20,
                         clickPoint.X + 60, clickPoint.Y + 20);

            g.FillPath(Brushes.Orange, path);
            g.DrawPath(Pens.Black, path);
        }

        // ===== ЧАСТЬ II =====
        private void buttonColor_Click(object sender, EventArgs e)
        {
            ColorDialog cd = new ColorDialog();
            if (cd.ShowDialog() == DialogResult.OK)
            {
                drawColor = cd.Color;
                this.Invalidate();
            }
        }

        private void buttonFont_Click(object sender, EventArgs e)
        {
            FontDialog fd = new FontDialog();
            if (fd.ShowDialog() == DialogResult.OK)
            {
                drawFont = fd.Font;
                this.Invalidate();
            }
        }

        private void buttonLoadImage_Click(object sender, EventArgs e)
        {
            OpenFileDialog ofd = new OpenFileDialog();
            ofd.Filter = "Image files|*.bmp;*.jpg;*.png";

            if (ofd.ShowDialog() == DialogResult.OK)
            {
                loadedImage = new Bitmap(ofd.FileName);
                pictureBox1.Image = loadedImage;
            }
        }

        private void radioNormal_CheckedChanged(object sender, EventArgs e)
        {
            pictureBox1.SizeMode = PictureBoxSizeMode.Normal;
        }

        private void radioStretch_CheckedChanged(object sender, EventArgs e)
        {
            pictureBox1.SizeMode = PictureBoxSizeMode.StretchImage;
        }

        private void radioZoom_CheckedChanged(object sender, EventArgs e)
        {
            pictureBox1.SizeMode = PictureBoxSizeMode.Zoom;
        }

        // ===== ЧАСТЬ III =====
        private void Form1_MouseClick(object sender, MouseEventArgs e)
        {
            clickPoint = e.Location;
            this.Invalidate();
        }
    }
}