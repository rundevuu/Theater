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
    public partial class SumForPeriod : Form
    {
        public SumForPeriod(string datas, string data1)
        {
            string data;
            string datas1;
            data = datas;
            datas1 = data1;
            InitializeComponent();
            int y = 0;
            List<string> results = new List<string>();
            SQLiteCommand command = new SQLiteCommand("SELECT SUM(TICKETS.cost) AS total_revenue FROM TICKETS JOIN PERFORMANCE ON TICKETS.ticket_performance = PERFORMANCE.performance_id WHERE PERFORMANCE.date >= '" + data + "' AND PERFORMANCE.date <= '" + datas1 + "'", SqlClass.connection);
            object sum = command.ExecuteScalar();
            string sums = sum.ToString();
            Label lbl = new Label();
            lbl.Location = new Point(0, y);
            lbl.Size = new Size(400, 40);
            lbl.Text = sums;
            Controls.Add(lbl);

            command.Dispose();
            InitializeComponent();
        }

        private void SumForPeriod_Load(object sender, EventArgs e)
        {

        }
    }
}
