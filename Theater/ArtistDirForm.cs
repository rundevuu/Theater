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
    public partial class ArtistDirForm : Form
    {
        public ArtistDirForm()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            panel1.Controls.Clear();
            int y = 30;
            System.Collections.Generic.List<string> actors = SqlClass.Select("SELECT EMPLOYEES.name, EMPLOYEES.surname FROM ACTORS JOIN EMPLOYEES ON ACTORS.employee = EMPLOYEES.employee_id; ");
            for (int i = 0; i < actors.Count; i += 2)
            {
                Label lbl = new Label();
                lbl.Location = new Point(20, y);
                lbl.Size = new Size(300, 30);
                lbl.Text = actors[i] + " " + actors[i + 1];
                panel1.Controls.Add(lbl);
                y += 30;
            }
        }

        private void button2_Click(object sender, EventArgs e)
        {
            panel1.Controls.Clear();
            int y = 30;
            System.Collections.Generic.List<string> musics = SqlClass.Select("SELECT name, surname FROM EMPLOYEES WHERE department_id IN(SELECT department_id FROM DEPARTMENTS WHERE department_name = 'Sound Design')");
            for (int i = 0; i < musics.Count; i += 2)
            {
                Label lbl = new Label();
                lbl.Location = new Point(20, y);
                lbl.Size = new Size(300, 30);
                lbl.Text = musics[i] + " " + musics[i + 1];
                panel1.Controls.Add(lbl);
                y += 30;
            }
        }

        private void button3_Click(object sender, EventArgs e)
        {
            PlaysGenreForm rf = new PlaysGenreForm();
            rf.ShowDialog();
        }

        private void button4_Click(object sender, EventArgs e)
        {
            ActorForRoleForm rf = new ActorForRoleForm();
            rf.ShowDialog();
        }

        private void button5_Click(object sender, EventArgs e)
        {
            InfoForm rf = new InfoForm();
            rf.ShowDialog();
        }

        private void button6_Click(object sender, EventArgs e)
        {
            ActorRolesForm rf = new ActorRolesForm();
            rf.ShowDialog();
        }

        private void ArtistDirForm_Load(object sender, EventArgs e)
        {

        }

        private void button7_Click(object sender, EventArgs e)
        {
            PerformForm rf = new PerformForm();
            rf.ShowDialog();
        }

        private void button8_Click(object sender, EventArgs e)
        {
            RolesForm fr = new RolesForm();
            fr.ShowDialog();
        }
    }
}
