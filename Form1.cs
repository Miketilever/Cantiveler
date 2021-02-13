using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.IO;
using System.Windows.Forms.DataVisualization.Charting;

namespace Pogoda_PR
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private void label1_Click(object sender, EventArgs e)
        {
            
        }

        private void Temp_TextChanged(object sender, EventArgs e)
        {
            
        }

        private void Form1_Load(object sender, EventArgs e)
        {

        }

        private void button1_Click(object sender, EventArgs e)
        {   string city0 = "https://www.weather-forecast.com/locations/";
            string city1 = textBox1.Text;
            HtmlAgilityPack.HtmlWeb temperature = new HtmlAgilityPack.HtmlWeb();
            HtmlAgilityPack.HtmlDocument document = temperature.Load(city0+city1+ "/forecasts/latest");

            var Tmp = document.DocumentNode.SelectNodes(("//span[@class='temp b-forecast__table-value']")).ToList();
            string DataTmp = "";
            foreach (var item in Tmp)
            {
                DataTmp += Environment.NewLine + item.InnerText;
            }
            richTextBox1.Text = DataTmp;

            HtmlAgilityPack.HtmlWeb description = new HtmlAgilityPack.HtmlWeb();
            HtmlAgilityPack.HtmlDocument document1 = description.Load(city0 + city1 + "/forecasts/latest");

            var Dsc = document1.DocumentNode.SelectNodes(("//text[@class='wind-icon-val']")).ToList();
            string DataDsc = "";
            foreach (var item in Dsc)
            {
                DataDsc += Environment.NewLine + item.InnerText;
            }
            richTextBox2.Text = DataDsc;

            HtmlAgilityPack.HtmlWeb pressure = new HtmlAgilityPack.HtmlWeb();
            HtmlAgilityPack.HtmlDocument document2 = pressure.Load(city0 + city1 + "/forecasts/latest");

            var Prs = document2.DocumentNode.SelectNodes(("//span[@class='rain b-forecast__table-value']")).ToList();
            string DataPrs = "";
            foreach (var item in Prs)
            {
                DataPrs += Environment.NewLine + item.InnerText;
            }
            richTextBox3.Text = DataPrs;

        }

        private void richTextBox1_TextChanged(object sender, EventArgs e)
        {

        }

        private void label1_Click_1(object sender, EventArgs e)
        {

        }

        private void label4_Click(object sender, EventArgs e)
        {

        }

        private void label5_Click(object sender, EventArgs e)
        {

        }

        private void richTextBox2_TextChanged(object sender, EventArgs e)
        {

        }

        private void button2_Click(object sender, EventArgs e)
        {
            string city1 = textBox1.Text;
            StreamWriter sw = new StreamWriter("C:\\Users\\Laptopious\\Desktop\\Dane_aplikacja\\" + "Temperatura "+city1+".csv ");
           
            sw.Write(richTextBox1.Text);
            sw.Close();

            StreamWriter sw1 = new StreamWriter("C:\\Users\\Laptopious\\Desktop\\Dane_aplikacja\\" + "Wiatr " +city1+ ".csv ");
            sw1.WriteLine(richTextBox2.Text);
            sw1.Close();

            StreamWriter sw2 = new StreamWriter("C:\\Users\\Laptopious\\Desktop\\Dane_aplikacja\\" + "Opady " +city1+ ".csv ");
            sw2.WriteLine(richTextBox3.Text);
            sw2.Close();
        }

        private void textBox1_TextChanged(object sender, EventArgs e)
        {

        }

        private void label3_Click(object sender, EventArgs e)
        {

        }

        private void button3_Click(object sender, EventArgs e)
        {
            string city1 = textBox1.Text;
            DataTable dt = new DataTable();
            dt.Columns.Add("X_Value", typeof(double));
            dt.Columns.Add("Y_Value", typeof(double));
            StreamReader sr = new StreamReader(@"C:\Users\Laptopious\Desktop\Dane_aplikacja\Temperatura " +city1+".csv");
            StreamReader nb = new StreamReader(@"C:\Users\Laptopious\Desktop\Dane_aplikacja\Numery14.csv");
            string line;
            string number;
            while ((line = sr.ReadLine()) != null &&(number = nb.ReadLine()) != null) 
            {
                string[] strarr = line.Split(';');
                string[] numb = number.Split(';');

                dt.Rows.Add(numb[0], strarr[0]);
            }
            chart1.DataSource = dt;
            chart1.Series["Series1"].XValueMember = "X_Value";
            chart1.Series["Series1"].YValueMembers = "Y_Value";
            chart1.Series["Series1"].ChartType = SeriesChartType.Line;
            chart1.ChartAreas[0].AxisY.LabelStyle.Format = "";
            if (sr != null) sr.Close();

            
            DataTable dt1 = new DataTable();
            dt1.Columns.Add("X_Value", typeof(double));
            dt1.Columns.Add("Y_Value", typeof(double));
            StreamReader sr1 = new StreamReader(@"C:\Users\Laptopious\Desktop\Dane_aplikacja\Wiatr " + city1 + ".csv");
            StreamReader nb1 = new StreamReader(@"C:\Users\Laptopious\Desktop\Dane_aplikacja\Numery14.csv");
            string line1;
            string number1;
            while ((line1 = sr1.ReadLine()) != null && (number1 = nb1.ReadLine()) != null)
            {
                string[] strarr1 = line1.Split(';');
                string[] numb1 = number1.Split(';');

                dt1.Rows.Add(numb1[0], strarr1[0]);
            }
            chart2.DataSource = dt1;
            chart2.Series["Series1"].XValueMember = "X_Value";
            chart2.Series["Series1"].YValueMembers = "Y_Value";
            chart2.Series["Series1"].ChartType = SeriesChartType.Line;
            chart2.ChartAreas[0].AxisY.LabelStyle.Format = "";
            if (sr != null) sr.Close();
            

        }

        private void chart1_Click(object sender, EventArgs e)
        {

        }

        private void label7_Click(object sender, EventArgs e)
        {

        }
    }
}
