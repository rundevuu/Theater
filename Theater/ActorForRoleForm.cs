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
    public partial class ActorForRoleForm : Form
    {
        public ActorForRoleForm()
        {
            InitializeComponent();
        }

        private void ActorForRoleForm_Load(object sender, EventArgs e)
        {
            List<string> character = SqlClass.Select("SELECT characters_name FROM CHARACTERS");
            comboBox1.Items.AddRange(character.ToArray());
        }

        private void button1_Click(object sender, EventArgs e)
        {
            panel1.Controls.Clear();
            string charecter = comboBox1.Text;
            int y = 30;
            System.Collections.Generic.List<string> charecters = SqlClass.Select("SELECT DISTINCT e.name, e.surname FROM ACTORS a INNER JOIN EMPLOYEES e ON a.employee = e.employee_id INNER JOIN CHARACTERS c ON a.species = c.characters_speice AND a.voice = c.characters_voice AND a.height BETWEEN c.characters_height_min AND c.characters_height_max WHERE c.characters_name = '" + charecter + "' AND e.employees_gender = c.characters_gender");
            for (int i = 0; i < charecters.Count; i += 2)
            {
                Label lbl = new Label();
                lbl.Location = new Point(20, y);
                lbl.Size = new Size(300, 30);
                lbl.Text = charecters[i] + charecters[i+1];
                panel1.Controls.Add(lbl);
                y += 30;
            }
        }
    }
}
