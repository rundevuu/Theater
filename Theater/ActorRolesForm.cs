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
    public partial class ActorRolesForm : Form
    {
        public ActorRolesForm()
        {
            InitializeComponent();
        }

        private void ActorRolesForm_Load(object sender, EventArgs e)
        {
            List<string> names = SqlClass.Select("SELECT EMPLOYEES.name FROM ACTORS JOIN EMPLOYEES ON ACTORS.employee = EMPLOYEES.employee_id");
            comboBox4.Items.AddRange(names.ToArray());
            List<string> surnames = SqlClass.Select("SELECT EMPLOYEES.surname FROM ACTORS JOIN EMPLOYEES ON ACTORS.employee = EMPLOYEES.employee_id");
            comboBox5.Items.AddRange(surnames.ToArray());
            List<string> genres = SqlClass.Select("SELECT genre_name FROM GENRE");
            comboBox3.Items.AddRange(genres.ToArray());
        }

        private void button1_Click(object sender, EventArgs e)
        {
            panel1.Controls.Clear();
            string name = comboBox4.Text;
            string surname = comboBox5.Text;
            int y = 30;
            System.Collections.Generic.List<string> roles = SqlClass.Select("SELECT DISTINCT chr.characters_name AS role_name FROM ROLES r JOIN CHARACTERS chr ON r.characters = chr.characters_id WHERE r.actor = (SELECT actor_id FROM ACTORS WHERE employee = ( SELECT employee_id FROM EMPLOYEES WHERE name = '" + name + "' AND surname = '" + surname + "'))");
            for (int i = 0; i < roles.Count; i += 1)
            {
                Label lbl = new Label();
                lbl.Location = new Point(20, y);
                lbl.Size = new Size(300, 30);
                lbl.Text = roles[i];
                panel1.Controls.Add(lbl);
                y += 30;
            }
        }

        private void button2_Click(object sender, EventArgs e)
        {
            string data = dateTimePicker1.Value.ToString("yyyy-MM-dd");
            string data1 = dateTimePicker2.Value.ToString("yyyy-MM-dd");
            string name = comboBox4.Text;
            string surname = comboBox5.Text;
            panel1.Controls.Clear();
            int y = 30;
            System.Collections.Generic.List<string> roles = SqlClass.Select("SELECT DISTINCT chr.characters_name AS role_name FROM ROLES r JOIN CHARACTERS chr ON r.characters = chr.characters_id JOIN PERFORMANCE perf ON r.performance_name = perf.performance_id WHERE r.actor = ( SELECT actor_id FROM ACTORS WHERE employee = ( SELECT employee_id FROM EMPLOYEES WHERE name = '" + name + "' AND surname = '" + surname + "')) AND perf.date >= '" + data + "' AND perf.date <= '" + data1 + "'");
            for (int i = 0; i < roles.Count; i += 1)
            {
                Label lbl = new Label();
                lbl.Location = new Point(20, y);
                lbl.Size = new Size(300, 30);
                lbl.Text = roles[i];
                panel1.Controls.Add(lbl);
                y += 30;
            }
        }

        private void button3_Click(object sender, EventArgs e)
        {
            string name = comboBox4.Text;
            string surname = comboBox5.Text;
            string genre = comboBox3.Text;
            panel1.Controls.Clear();
            int y = 30;
            System.Collections.Generic.List<string> roles = SqlClass.Select("SELECT DISTINCT chr.characters_name AS role_name FROM ROLES r JOIN CHARACTERS chr ON r.characters = chr.characters_id JOIN PERFORMANCE perf ON r.performance_name = perf.performance_id JOIN PLAYS ply ON perf.plays_name = ply.play_id JOIN GENRE gen ON ply.plays_genre = gen.genre_id WHERE r.actor = ( SELECT actor_id FROM ACTORS WHERE employee = ( SELECT employee_id FROM EMPLOYEES WHERE name = '" + name + "' AND surname = '" + surname + "' )) AND gen.genre_name = '" + genre + "'");
            for (int i = 0; i < roles.Count; i += 1)
            {
                Label lbl = new Label();
                lbl.Location = new Point(20, y);
                lbl.Size = new Size(300, 30);
                lbl.Text = roles[i];
                panel1.Controls.Add(lbl);
                y += 30;
            }
        }
    }
}
