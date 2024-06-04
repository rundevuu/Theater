using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Data.SQLite;


namespace Theater
{
    public partial class FuturePerForm : Form
    {
        static SQLiteConnection connection;
        public FuturePerForm()
        {
            InitializeComponent();
            
            int y = 0;
            System.Collections.Generic.List<string> employees = SqlClass.Select("SELECT PLAYS.plays_name, PERFORMANCE.date FROM PLAYS INNER JOIN PERFORMANCE ON PLAYS.play_id = PERFORMANCE.plays_name WHERE PERFORMANCE.date >= DATE('now') ");
            for (int i = 0; i <employees.Count; i += 2) 
            {
                Label lbl = new Label();
                lbl.Location = new Point(0, y);
                lbl.Size = new Size(300, 30);
                lbl.Text = employees[i] + " " + employees[i + 1];
                Controls.Add(lbl);
                y += 30;
            }

        }

        private void RegistrationForm_Load(object sender, EventArgs e)
        {

        }
    }
}
