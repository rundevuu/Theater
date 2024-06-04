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
    public partial class TicketsSoldForm : Form
    {
        public TicketsSoldForm(string datas, string data1)
        {
            string data;
            string datas1;
            data = datas;
            datas1 = data1;
            InitializeComponent();
            int y = 0;
            List<string> results = new List<string>();
            SQLiteCommand command = new SQLiteCommand("SELECT COUNT(tickets_id) AS tickets_sold FROM TICKETS JOIN PERFORMANCE ON TICKETS.ticket_performance = PERFORMANCE.performance_id WHERE PERFORMANCE.date >= '" + data + "' AND PERFORMANCE.date <= '" + datas1 + "'", SqlClass.connection);
            object count = command.ExecuteScalar();
            string counts = count.ToString(); 
            Label lbl = new Label();
            lbl.Location = new Point(0, y);
            lbl.Size = new Size(400, 40);
            lbl.Text = counts;
            Controls.Add(lbl);
            
            command.Dispose();
            InitializeComponent();
        }

        private void TicketsSoldForm_Load(object sender, EventArgs e)
        {

        }
    }
}
