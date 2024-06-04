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
    public partial class BuyTicForm : Form
    {
        List<string> ress;
        public BuyTicForm(List<string> res)
        {
            //ress = String.Join(", ", res.ToArray());
            //ress.ToString();
            ress = res;
            //Console.WriteLine(res[3]);
            InitializeComponent();
            string PerfCost = SqlClass.Select("SELECT base_cost FROM PERFORMANCE WHERE performance_id = '" + ress[0] + "'")[0];
            SqlClass.Insert("INSERT INTO TICKETS(ticket_place, ticket_performance, cost) VALUES ('" + ress[0] + "', '" + ress[1] + "', " + PerfCost + ")");
            MessageBox.Show("Место успешно куплено!");
            /*this.Hide();
            Form1 fr = new Form1();
            fr.ShowDialog();*/
        }

        private void BuyTicForm_Load(object sender, EventArgs e)
        {

        }
    }
}
