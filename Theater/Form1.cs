using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using Microsoft.Data.Sqlite;
using System.Data.SQLite;

namespace Theater
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            FuturePerForm rf = new FuturePerForm();
            rf.ShowDialog();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            
        }

        private void splitContainer1_Panel1_Paint(object sender, PaintEventArgs e)
        {

        }

        private void splitContainer1_Panel2_Paint(object sender, PaintEventArgs e)
        {

        }

        private void button5_Click(object sender, EventArgs e)
        {
            string data = dateTimePicker1.Value.ToString("yyyy-MM-dd");
            string data1 = dateTimePicker2.Value.ToString("yyyy-MM-dd");
            //nsole.WriteLine(data1);
            List<string> results = new List<string>();
            SQLiteCommand command = new SQLiteCommand("SELECT COUNT(tickets_id) AS tickets_sold FROM TICKETS JOIN PERFORMANCE ON TICKETS.ticket_performance = PERFORMANCE.performance_id WHERE PERFORMANCE.date >= '" + data + "' AND PERFORMANCE.date <= '" + data1 + "'", SqlClass.connection);
            object count = command.ExecuteScalar();
            string counts = count.ToString();
            Label lbl = new Label();
            lbl.Location = new Point(135, 400);
            lbl.Size = new Size(50, 18);
            lbl.Text = counts;
            Controls.Add(lbl);

            command.Dispose();

        }

        private void label1_Click(object sender, EventArgs e)
        {

        }

        
        private void comboBox2_SelectedIndexChanged(object sender, EventArgs e)
        {
           
        }

        private void dateTimePicker5_ValueChanged(object sender, EventArgs e)
        {

        }

        private void label4_Click(object sender, EventArgs e)
        {

        }

       
        private void button4_Click(object sender, EventArgs e)
        {
            string data = dateTimePicker6.Value.ToString("yyyy-MM-dd");
            string data1 = dateTimePicker6.Value.AddDays(1).ToString("yyyy-MM-dd");
            string playName = comboBox2.Text;
            //Console.WriteLine(playName);
            FreePlacesForm rf = new FreePlacesForm(playName, data, data1);
            rf.ShowDialog();
            
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            List<string> genres = SqlClass.Select("SELECT plays_name FROM PLAYS");
            comboBox2.Items.AddRange(genres.ToArray());
        }

        private void button3_Click(object sender, EventArgs e)
        {
            string data = dateTimePicker3.Value.ToString("yyyy-MM-dd");
            string data1 = dateTimePicker4.Value.ToString("yyyy-MM-dd");
            int y = 0;
            List<string> results = new List<string>();
            SQLiteCommand command = new SQLiteCommand("SELECT SUM(TICKETS.cost) AS total_revenue FROM TICKETS JOIN PERFORMANCE ON TICKETS.ticket_performance = PERFORMANCE.performance_id WHERE PERFORMANCE.date >= '" + data + "' AND PERFORMANCE.date <= '" + data1 + "'", SqlClass.connection);
            object sum = command.ExecuteScalar();
            string sums = sum.ToString();
            Label lbl = new Label();
            lbl.Location = new Point(135, 250);
            lbl.Size = new Size(50, 18);
            lbl.Text = sums;
            Controls.Add(lbl);

            command.Dispose();
        }

        private void label12_Click(object sender, EventArgs e)
        {

        }

        private void label2_Click(object sender, EventArgs e)
        {

        }

        private void button2_Click_1(object sender, EventArgs e)
        {
            //BuyTicForm rf = new BuyTicForm();
            //rf.ShowDialog();
        }
    }
}
