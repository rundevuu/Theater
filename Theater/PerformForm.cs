using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Theater
{
    public partial class PerformForm : Form
    {
        public PerformForm()
        {
            InitializeComponent();
        }

        private void comboBox1_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

        private void PerformForm_Load(object sender, EventArgs e)
        {
            List<string> plays = SqlClass.Select("SELECT plays_name FROM PLAYS");
            comboBox1.Items.AddRange(plays.ToArray());
            List<string> name1 = SqlClass.Select("SELECT name FROM EMPLOYEES WHERE department_id = 15");
            List<string> surname1 = SqlClass.Select("SELECT surname FROM EMPLOYEES WHERE department_id = 15");
            comboBox4.Items.AddRange(name1.ToArray());
            comboBox5.Items.AddRange(surname1.ToArray());
            List<string> name2 = SqlClass.Select("SELECT name FROM EMPLOYEES WHERE department_id = 16");
            List<string> surname2 = SqlClass.Select("SELECT surname FROM EMPLOYEES WHERE department_id = 16");
            comboBox3.Items.AddRange(name2.ToArray());
            comboBox6.Items.AddRange(surname2.ToArray());
            List<string> name3 = SqlClass.Select("SELECT name FROM EMPLOYEES WHERE department_id = 17");
            List<string> surname3 = SqlClass.Select("SELECT surname FROM EMPLOYEES WHERE department_id = 17");
            comboBox2.Items.AddRange(name3.ToArray());
            comboBox7.Items.AddRange(surname3.ToArray());
        }

        private void button1_Click(object sender, EventArgs e)
        {
            string data = dateTimePicker1.Value.ToString("yyyy-MM-dd");
            string time = textBox1.Text;
            string playName = comboBox1.Text;
            string name1 = comboBox4.Text;
            string surname1 = comboBox5.Text;
            System.Collections.Generic.List<string> per1 = SqlClass.Select("SELECT employee_id FROM EMPLOYEES WHERE name = '" + name1 + "' and surname = '" + surname1 + "'");
            string name2 = comboBox3.Text;
            string surname2 = comboBox6.Text;
            System.Collections.Generic.List<string> per2 = SqlClass.Select("SELECT employee_id FROM EMPLOYEES WHERE name = '" + name2 + "' and surname = '" + surname2 + "'");
            string name3 = comboBox2.Text;
            string surname3 = comboBox7.Text;
            System.Collections.Generic.List<string> per3 = SqlClass.Select("SELECT employee_id FROM EMPLOYEES WHERE name = '" + name3 + "' and surname = '" + surname3 + "'");
            string cost = textBox2.Text;
            System.Collections.Generic.List<string> play_id = SqlClass.Select("SELECT play_id FROM plays WHERE plays_name = '" + playName + "'");
            string ready_data = data + " " + time;
            if(ready_data == "" || cost == "" || surname3 == "" || name3 == "" || surname2 == "" || name2 == "" || surname1 == ""  || name1 == ""  || playName == "" || time == "" || data == "")
            {
                MessageBox.Show("Все поля должны быть заполнены!");
            }
            else
            {
                SqlClass.Insert("INSERT INTO PERFORMANCE (date, plays_name, premiere, producer, conductor, art_director, base_cost) VALUES " +
"('" + ready_data + "', " + play_id[0] + ", TRUE, " + per1[0] + ", " + per2[0] + ", " + per3[0] + ", " + cost[0] + ")");
                MessageBox.Show("Постановка успешно назначена!");
            }
        
        }
    }
}
