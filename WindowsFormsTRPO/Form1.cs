using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Windows.Forms.DataVisualization.Charting;

namespace WindowsFormsTRPO
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
            
            chart1.Series.Clear(); // Очистка чарта
            dataGridView1.Columns.Add("_index", "Index"); // Создание колонок списка значений
            dataGridView1.Columns.Add("_value", "Value");
            chart1.Series.Clear(); // Очистка чарта
            dataGridView2.Columns.Add("_index", "Index"); // Создание колонок списка значений
            dataGridView2.Columns.Add("_value", "Value");
        }
        
        private void Main1(object sender, EventArgs e)
        {
         //   try
         //   {
                double[] mas = new double[100];
                double[] mass = new double[100];
                Posledov1(mass);
                NevPos(mas, mass);
                vShowData(mas);
                vFillChart(mas);
          //  }
           // catch(Exception)
          //  {
                //vReset();
               // Main1(sender, e);
           // }
            
        }
        void vReset()
        {
      
            chart1.Series.Clear();
            dataGridView1.Rows.Clear();
            dataGridView2.Rows.Clear();
        }
        static double[] Posledov1(double[] mass)
        {
           
            double x;
            
            Random rnd = new Random();
            for (int i = 0; i < 100; i++)
            {

                x = rnd.Next(1, 100);
                //Console.WriteLine(x);
                //elim = Math.Pow((x - 5), 2);
                mass[i] = ((1 / (2 * Math.Sqrt(2 * 3.14))) * (-2.718 *(-Math.Pow((x - 5), 2) / (2 * Math.Pow(2, 2)))))/200;
                if (mass[i] == 0)
                {
                    i--;
                    continue;
                }
             
                // Console.WriteLine(mass[i]);
            }
            return mass;
           
        }
        void vShowData(double[] mas)
        {
            dataGridView1.Rows.Clear();
            int i = 1;
            foreach (var num in mas)
            {
                
                    dataGridView1.Rows.Add(i, num); // Вывод значений на экран
                    i++;
                
            }
        }
        void vFillChart(double[] mas)
        {
            double[] mass = new double[10];
            int j = 0;
            for (int i = 0; i < 100; i++)
            {
                if ((i % 10) == 0 && i != 0) { j++; }
                mass[j] = (mass[j] + mas[i])/1.1;
                
            }
            label4.Text = Convert.ToString(Math.Round(mass[0], 5));
            label5.Text = Convert.ToString(Math.Round(mass[1], 5));
            label6.Text = Convert.ToString(Math.Round(mass[2], 5));
            label7.Text = Convert.ToString(Math.Round(mass[3], 5));
            label8.Text = Convert.ToString(Math.Round(mass[4], 5));
            label9.Text = Convert.ToString(Math.Round(mass[5], 5));
            label10.Text = Convert.ToString(Math.Round(mass[6], 5));
            label11.Text = Convert.ToString(Math.Round(mass[7], 5));
            label12.Text = Convert.ToString(Math.Round(mass[8], 5));
            label13.Text = Convert.ToString(Math.Round(mass[9], 5));
            chart1.Series.Clear();
            chart1.Series.Add("Exp");
            chart1.Series["Exp"].Points.DataBindY(mass);
            dataGridView2.Rows.Clear();
            int k = 1;
            foreach (var num in mass)
            {

                dataGridView2.Rows.Add(k, num); // Вывод значений на экран
                k++;

            }
        }
         double[] NevPos(double[] mas, double[] mass)
        {
            
            double disp = 0;
            double n = 0;
            double x_ = 0;
            double dispersiya = 0;
            mas[0] = mass[0] + mass[99];
            for (int i = 1; i < 100; i++)
            {

                mas[i] = mass[i - 1] + mass[i];
                
            }
            

            for (int i = 0; i < mas.Length; i++)
            {

                disp = disp + mas[i];

            }
            n = mas.Length;
            x_ = disp / n;
            for (int i = 0; i < mas.Length; i++)
            {

                dispersiya = (Math.Pow((mas[i] - x_), 2)) + dispersiya;

            }
            dispersiya = dispersiya / (n - 1);
            label3.Text = $"Среднее значение: {x_} Дисперсия: {dispersiya}";

            return mas;
            //Console.WriteLine(dispersiya);
           
        }

        private void label1_Click(object sender, EventArgs e)
        {

        }

        private void label2_Click(object sender, EventArgs e)
        {

        }

        private void label3_Click(object sender, EventArgs e)
        {

        }
    }
}
