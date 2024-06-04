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
    public partial class RolesForm : Form
    {
        public RolesForm()
        {
            InitializeComponent();
        }

        private void RolesForm_Load(object sender, EventArgs e)
        {
            List<string> plays = SqlClass.Select("SELECT plays_name FROM PLAYS");
            comboBox4.Items.AddRange(plays.ToArray());
            List<string> charac = SqlClass.Select("SELECT characters_name  FROM CHARACTERS");
            comboBox1.Items.AddRange(charac.ToArray());
            List<string> name1 = SqlClass.Select("SELECT name FROM EMPLOYEES WHERE department_id = 5");
            List<string> surname1 = SqlClass.Select("SELECT surname FROM EMPLOYEES WHERE department_id = 5");
            comboBox2.Items.AddRange(name1.ToArray());
            comboBox3.Items.AddRange(surname1.ToArray());
           
        }

        private void button1_Click(object sender, EventArgs e)
        {
            string doubler;
            if (checkBox1.Checked == true)
            {
                doubler = "TRUE";
            }
            else
            {
                doubler = "FALSE";
            }
            string data = dateTimePicker1.Value.ToString("yyyy-MM-dd");
            string time = textBox1.Text;
            string character = comboBox1.Text;
            System.Collections.Generic.List<string> char_id = SqlClass.Select("SELECT characters_id  FROM CHARACTERS WHERE characters_name  = '" + character + "'");
            string playName = comboBox4.Text;
            string name1 = comboBox2.Text;
            string surname1 = comboBox3.Text;
            System.Collections.Generic.List<string> per1 = SqlClass.Select("SELECT actor_id FROM ACTORS WHERE employee = (SELECT employee_id FROM EMPLOYEES WHERE name = '" + name1 + "' and surname = '" + surname1 + "')");
            System.Collections.Generic.List<string> play_id = SqlClass.Select("SELECT play_id FROM plays WHERE plays_name = '" + playName + "'");
            string ready_data = data + " " + time;
            if(playName == "" || ready_data == "")
            {
                MessageBox.Show("Все поля должны быть заполнены!");
            }
            else
            {
                System.Collections.Generic.List<string> perf_id = SqlClass.Select("SELECT performance_id FROM PERFORMANCE WHERE plays_name = " + play_id[0] + " and date = '" + ready_data + "'");

                if (ready_data == "" || surname1 == "" || name1 == "" || playName == "" || time == "" || character == "" || data == "")
                {
                    MessageBox.Show("Все поля должны быть заполнены!");
                }
                else
                {
                    if (perf_id.Count == 0)
                    {
                        MessageBox.Show("Такой постановки не существует!");
                    }
                    else
                    {
                        SqlClass.Insert("INSERT INTO ROLES (characters, actor, double, performance_name) VALUES " +
        "(" + char_id[0] + ", " + per1[0] + ",'" + doubler + "', " + perf_id[0] + ")");
                        MessageBox.Show("Актер успешно назначен!");
                    }
                }
            }
            
        }
    }
}
