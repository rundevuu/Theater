using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Data.SQLite;

namespace Theater
{
    static class Program
    {
        /// <summary>
        /// Главная точка входа для приложения.
        /// </summary>
        [STAThread]
        static void Main()
        {
            Application.EnableVisualStyles();
            Application.SetCompatibleTextRenderingDefault(false);
            SqlClass.connection = new SQLiteConnection("Data Source=C:/Users/Elizaveta/Theater.sqlite");
            SqlClass.connection.Open();
            Application.Run(new UserChooserForm());

            SqlClass.connection.Close();
        }
    }
}
