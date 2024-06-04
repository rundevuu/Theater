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
    public partial class PlaysGenreForm : Form
    {
        public PlaysGenreForm()
        {
            InitializeComponent();
        }

        private void PlaysGenreForm_Load(object sender, EventArgs e)
        {
            List<string> genres = SqlClass.Select("SELECT genre_name FROM GENRE");
            comboBox1.Items.AddRange(genres.ToArray());
            List<string> authors = SqlClass.Select("SELECT authors_surname  FROM AUTHORS");
            comboBox2.Items.AddRange(authors.ToArray());
            List<string> countries = SqlClass.Select("SELECT country  FROM AUTHORS");
            comboBox3.Items.AddRange(countries.ToArray());
        }

        private void button1_Click(object sender, EventArgs e)
        {
            panel1.Controls.Clear();
            string playName = comboBox1.Text;
            int y = 30;
            System.Collections.Generic.List<string> plays = SqlClass.Select("SELECT plays_name FROM PLAYS INNER JOIN GENRE ON PLAYS.plays_genre = GENRE.genre_id WHERE GENRE.genre_name = '" + playName + "'");
            for (int i = 0; i < plays.Count; i += 1)
            {
                Label lbl = new Label();
                lbl.Location = new Point(20, y);
                lbl.Size = new Size(300, 30);
                lbl.Text = plays[i];
                panel1.Controls.Add(lbl);
                y += 30;
            }
        }

        private void comboBox2_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

        private void button2_Click(object sender, EventArgs e)
        {
            panel1.Controls.Clear();
            string author = comboBox2.Text;
            int y = 30;
            System.Collections.Generic.List<string> authors = SqlClass.Select("SELECT plays_name FROM PLAYS INNER JOIN AUTHORS ON PLAYS.author_name = AUTHORS.authors_id WHERE AUTHORS.authors_surname = '" + author + "'");
            for (int i = 0; i < authors.Count; i += 1)
            {
                Label lbl = new Label();
                lbl.Location = new Point(20, y);
                lbl.Size = new Size(300, 30);
                lbl.Text = authors[i];
                panel1.Controls.Add(lbl);
                y += 30;
            }
        }

        private void button3_Click(object sender, EventArgs e)
        {
            panel1.Controls.Clear();
            string country = comboBox3.Text;
            int y = 30;
            System.Collections.Generic.List<string> countrys = SqlClass.Select("SELECT plays_name FROM PLAYS INNER JOIN AUTHORS ON PLAYS.author_name = AUTHORS.authors_id WHERE AUTHORS.country = '" + country + "'");
            for (int i = 0; i < countrys.Count; i += 1)
            {
                Label lbl = new Label();
                lbl.Location = new Point(20, y);
                lbl.Size = new Size(300, 30);
                lbl.Text = countrys[i];
                panel1.Controls.Add(lbl);
                y += 30;
            }
        }
    }
}
