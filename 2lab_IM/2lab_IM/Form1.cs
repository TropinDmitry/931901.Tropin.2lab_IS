using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace _2lab_IM
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }
        double euro, dollar;
        const double k = 0.01;
        int day;
        Random random = new Random();
        private void btPredict_Click(object sender, EventArgs e)
        {
            timer1.Start();
            euro = (double)edEuro.Value;
            dollar = (double)edDollar.Value;

            day = 0;
            chart1.Series[0].Points.Clear();
            chart1.Series[1].Points.Clear();

            chart1.Series[0].Points.AddXY(0, euro);
            chart1.Series[1].Points.AddXY(0, dollar);

        }

        private void btStop_Click(object sender, EventArgs e)
        {
            timer1.Stop();
        }

        private void timer1_Tick(object sender, EventArgs e)
        {
            euro = euro * (1 + k * (random.NextDouble() - 0.5));
            dollar = dollar * (1 + k * (random.NextDouble() - 0.5));
            chart1.Series[0].Points.AddXY(++day, euro);
            chart1.Series[1].Points.AddXY(day, dollar);

        }
    }
}
