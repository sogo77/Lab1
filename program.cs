using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace WindowsFormsLR1._0
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private void Form1_Load(object sender, EventArgs e)
        { }


        public class CEmblem
        {
            private readonly Graphics canvas;
            private readonly float x;
            private readonly float y;
            private readonly float size;
            private readonly Pen outlinePen;

            public CEmblem(Graphics canvas, float x, float y, float size)
            {
                this.canvas = canvas;
                this.x = x;
                this.y = y;
                this.size = size;
                this.outlinePen = new Pen(Color.Black);
            }

            public void Display()
            {
                float spacing = size * 1.5f;  // Проміжок між фігурами

                // Розташування чотирикутника
                float squareX = x - spacing;
                float squareY = y;
                float squareSize = size;
                canvas.DrawRectangle(outlinePen, squareX - squareSize / 2, squareY - squareSize / 2, squareSize, squareSize);

                // Розташування кола
                float circleX = x;
                float circleY = y;
                float circleRadius = size / 2;
                canvas.DrawEllipse(outlinePen, circleX - circleRadius, circleY - circleRadius, 2 * circleRadius, 2 * circleRadius);

                // Розташування трикутника
                float triangleX = x + spacing;
                float triangleY = y;
                float triangleSide = size / (float)Math.Sqrt(3);
                PointF[] trianglePoints =
                {
            new PointF(triangleX, triangleY - (triangleSide / 2)),
            new PointF(triangleX - (triangleSide / 2), triangleY + (triangleSide / 2)),
            new PointF(triangleX + (triangleSide / 2), triangleY + (triangleSide / 2))
        };
                canvas.DrawPolygon(outlinePen, trianglePoints);
            }
        }

        public class EmblemApplication : Form
        {
            private CEmblem emblem;

            public EmblemApplication()
            {
                Text = "CEmblem Application";
                Size = new Size(800, 600);
                emblem = new CEmblem(CreateGraphics(), ClientSize.Width / 2, ClientSize.Height / 2, 100);
                emblem.Display();
            }

            protected override void OnPaint(PaintEventArgs e)
            {
                base.OnPaint(e);
                emblem.Display();
            }

            public static void Main()
            {
                Application.Run(new EmblemApplication());
            }
        }

    }
}
