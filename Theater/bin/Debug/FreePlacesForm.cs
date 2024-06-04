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
    public partial class FreePlacesForm : Form
    {
        public FreePlacesForm(string playsName, string datas, string data1)
        {
            string playName;
            string data;
            string datas1;
            playName = playsName;
            data = datas;
            datas1 = data1;
            InitializeComponent( );

            int y = 0;
            System.Collections.Generic.List<string> res = new List<string>();
            System.Collections.Generic.List<string> places = SqlClass.Select(
                "SELECT pl.plays_name, p.date, pl.places_id " +
                "FROM PERFORMANCE p " +
                "JOIN PLAYS pl ON p.plays_name = pl.play_id CROSS " +
                "JOIN PLACES pl " +
                "WHERE pl.plays_name = '" + playName + "' " +
                "AND p.date >= '" + data + "' " +
                "AND p.date <= '" + datas1 + "' " +
                "EXCEPT " +
                "SELECT pl.plays_name, p.date, t.ticket_place FROM TICKETS t JOIN PERFORMANCE p ON t.ticket_performance = p.performance_id JOIN PLAYS pl ON p.plays_name = pl.play_id WHERE pl.plays_name = '" + playName + "' AND p.date >= '" + data + "' AND p.date <= '" + datas1 + "'");
            for (int i = 0; i < places.Count; i += 3)
            {
                Label lbl = new Label();
                lbl.Location = new Point(0, y);
                lbl.Size = new Size(300, 30);
                System.Collections.Generic.List<string> placeWithRow = SqlClass.Select("SELECT number_place, number_row, (SELECT location_name FROM LOCATION WHERE id_location = place_location)" +
                    "FROM places WHERE places_id = " + places[i+2]);
                lbl.Text = places[i] + " " + places[i + 1] + " " + placeWithRow[0] + " " + placeWithRow[1] + " " + placeWithRow[2];
                System.Collections.Generic.List<string> id_perf = SqlClass.Select("SELECT performance_id " +
                    "FROM PERFORMANCE " +
                    "WHERE date = '" + places[i + 1] + "' " +
                    "and plays_name = (SELECT play_id FROM PLAYS WHERE plays_name = '" + places[i] + "')");
                res.Add(places[i + 2]);
                res.Add(id_perf[0]);
                //string res1 = String.Join(", ", res.ToArray());
                lbl.Tag = res;
                lbl.Click += new EventHandler(PlasecClick);
                Controls.Add(lbl);
                y += 30;
            }
            InitializeComponent();
        }

        private void EntranceForm_Load(object sender, EventArgs e)
        {
        }

        private void PlasecClick(object sender, EventArgs e)
        {
            Label lbl = (Label)sender;
            BuyTicForm rf = new BuyTicForm((List<string>)lbl.Tag);
            //rf.ShowDialog();
            //OrderCarriageForm of = new OrderCarriageForm(lbl.Tag.ToString(), CityFrom, CityTo); 
            //Form1.Controls.Clear();
            //MainForm.mainPanel.Controls.Add(of);
        }

        private void comboBox1_SelectedIndexChanged(object sender, EventArgs e)
        {

        }
    }
}
