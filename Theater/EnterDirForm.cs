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
    public partial class EnterDirForm : Form
    {
        public EnterDirForm()
        {
            InitializeComponent();
        }

        private void EnterDirForm_Load(object sender, EventArgs e)
        {

        }

        private void button1_Click(object sender, EventArgs e)
        {
            string login = textBox1.Text;
            string pasword = textBox2.Text;
            System.Collections.Generic.List<string> users = SqlClass.Select("SELECT login, password FROM USERS WHERE login = '" + login + "' and password = '" + pasword + "'");
            System.Collections.Generic.List<string> job = SqlClass.Select("SELECT role FROM USERS WHERE login = '" + login + "' and password = '" + pasword + "'");
            if (users.Count == 0)
            {
                MessageBox.Show("Неверно введены имя пользователя или пароль");
            }
            else
            {
                if(job.Count == 1)
                {
                    if (job[0].Equals("cassir"))
                    {
                        MessageBox.Show("Вы не являетесь художественным руководителем");
                    }
                    else
                    {
                        this.Hide();
                        ArtistDirForm fr = new ArtistDirForm();
                        fr.ShowDialog();
                    }
                }
               
            }
            
        }

        private void button2_Click(object sender, EventArgs e)
        {
            string login = textBox1.Text;
            string pasword = textBox2.Text;
            System.Collections.Generic.List<string> users = SqlClass.Select("SELECT login, password FROM USERS WHERE login = '" + login + "' and password = '" + pasword + "'");
            if (users.Count != 0)
            {
                MessageBox.Show("Вы уже зарегестрированы");
            }
            else
            {
                SqlClass.Insert("INSERT INTO USERS(login,password, role) VALUES('" + login + "', '" + pasword + "', 'organisatore')");
                MessageBox.Show("Вы успешно зарегестрирвоны!");
                this.Hide();
                ArtistDirForm fr = new ArtistDirForm();
                fr.ShowDialog();
            }
        }
    }
}
