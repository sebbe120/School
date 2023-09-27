using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace TSP_GUI
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private void Form1_Paint(object sender, PaintEventArgs e)
        {
            Graphics l = e.Graphics;
            Pen pen = new Pen(Color.Black, 2);

            PointF[] points = {
                 new PointF((float)16.8215*10, (float)16.6572*10),
                 new PointF((float)18.3529*10, (float)12.1304*10),
                 new PointF((float)14.9995*10, (float)13.9122*10),
                 new PointF((float)10.2841*10, (float)12.9196*10),
                 new PointF((float)4.2275*10, (float)11.9579*10),
                 new PointF((float)0.836446*10, (float)13.4498*10),
                 new PointF((float)10.4551*10, (float)0.885736*10),
                 new PointF((float)6.53566*10, (float)16.7396*10),
                 new PointF((float)16.6793*10, (float)17.9234*10),
                 new PointF((float)15.7796*10, (float)14.0669*10),
                 new PointF((float)3.90809*10, (float)7.93377*10),
                 new PointF((float)9.94376*10, (float)9.35403*10),
                 new PointF((float)7.08658*10, (float)11.2766*10),
                 new PointF((float)11.5908*10, (float)17.2236*10),
                 new PointF((float)12.0871*10, (float)17.3643*10),
                 new PointF((float)16.8215*10, (float)16.6572*10)
             };
            l.DrawLines(pen, points);
        }

        private void button1_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            return;
        }

        private void button2_Click(object sender, EventArgs e)
        {
            Traveling_Salesman_Problem.Program.Main();
        }
    }
}
