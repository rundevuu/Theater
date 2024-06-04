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
    public partial class InfoForm : Form
    {
        public InfoForm()
        {
            InitializeComponent();
        }

        private void InfoForm_Load(object sender, EventArgs e)
        {
            List<string> plays = SqlClass.Select("SELECT plays_name FROM PLAYS");
            comboBox1.Items.AddRange(plays.ToArray());
        }

        private void button1_Click(object sender, EventArgs e)
        {
            panel1.Controls.Clear();
            string playName = comboBox1.Text;
            int y = 30;
            int x = 30;
            System.Collections.Generic.List<string> plays = SqlClass.Select(
                "SELECT DISTINCT " +
                "emp_act.name AS actor_name, " +
                "emp_act.surname AS actor_surname, " +
                "CASE WHEN emp_dbl.name IS NULL THEN 'No doubler' ELSE emp_dbl.name END AS doubler_name, " +
                "CASE WHEN emp_dbl.surname IS NULL THEN 'No doubler' ELSE emp_dbl.surname END AS doubler_surname, " +
                "emp_prod.name AS producer_name, " +
                "emp_prod.surname AS producer_surname, " +
                "emp_cond.name AS conductor_name, " +
                "emp_cond.surname AS conductor_surname, " +
                "emp_art.name AS art_director_name, " +
                "emp_art.surname AS art_director_surname, " +
                "aut.authors_name AS author_name, " +
                "aut.authors_surname AS author_surname, " +
                "perf.date " +
                "FROM PERFORMANCE perf " +
                "JOIN PLAYS ply ON perf.plays_name = ply.play_id " +
                "JOIN ROLES role_act ON role_act.performance_name = perf.performance_id AND role_act.double = FALSE " +
                "JOIN CHARACTERS chr_act ON role_act.characters = chr_act.characters_id " +
                "JOIN ACTORS act_act ON act_act.actor_id = role_act.actor " +
                "JOIN EMPLOYEES emp_act ON emp_act.employee_id = act_act.employee " +
                "JOIN EMPLOYEES emp_prod ON emp_prod.employee_id = perf.producer " +
                "JOIN EMPLOYEES emp_cond ON emp_cond.employee_id = perf.conductor " +
                "JOIN EMPLOYEES emp_art ON emp_art.employee_id = perf.art_director " +
                "JOIN AUTHORS aut ON ply.author_name = aut.authors_id " +
                "LEFT JOIN( " +
                "SELECT emp_dbl.name, emp_dbl.surname, chr_dbl.characters_id, role_dbl.performance_name " +
                "FROM EMPLOYEES emp_dbl " +
                "JOIN ACTORS act_dbl ON act_dbl.employee = emp_dbl.employee_id " +
                "JOIN ROLES role_dbl ON role_dbl.actor = act_dbl.actor_id " +
                "JOIN CHARACTERS chr_dbl ON chr_dbl.characters_id = role_dbl.characters " +
                "WHERE role_dbl.double = TRUE " +
                " ) emp_dbl ON chr_act.characters_id = emp_dbl.characters_id AND role_act.performance_name = emp_dbl.performance_name " +
                "WHERE ply.plays_name = '" +playName + "'");
            for (int i = 0; i < plays.Count; i += 11)
            {
                Label lbl = new Label();
                
                lbl.Text = "Актер: " + plays[i] + plays[i + 1] + Environment.NewLine +
                    "Режиссер: " + plays[i + 2] + " " + plays[i + 3] + Environment.NewLine +
                    "Хужожник: " + plays[i + 4] + " " + plays[i + 5] + Environment.NewLine +
                    "Дирижер: " + plays[i + 6] + " " + plays[i + 7] + Environment.NewLine +
                    "Автор: " + plays[i + 8] + " " + plays[i + 9] + Environment.NewLine +
                    "Дата: " + plays[i + 10];
                lbl.Location = new Point(x, y);
                lbl.Size = new Size(250, 100);
                panel1.Controls.Add(lbl);
                x += 300;
                if(x+250 > Width)
                {
                    x = 30;
                    y += 120;
                }
            }
        }

        private void panel1_Paint(object sender, PaintEventArgs e)
        {

        }
    }
}
