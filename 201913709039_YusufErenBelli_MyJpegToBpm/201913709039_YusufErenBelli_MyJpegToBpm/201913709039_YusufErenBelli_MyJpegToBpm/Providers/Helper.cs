using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using _201913709039_YusufErenBelli_MyJpegToBpm.Models;
using System.Data.SQLite;

namespace _201913709039_YusufErenBelli_MyJpegToBpm.Providers
{
    class Helper
    {
        /// <summary>
        /// Tüm logları listboxa yazdırmak için list türünden bir log döndürülür.
        /// System.Data.CommandBehavior.CloseConnection kod parçası reader kullanıldıktan sonra kapatılmasına yarar.
        /// </summary>
        /// <returns>List<Logs></returns>
        public List<Logs> LogGet()
        {
            List<Logs> logs = new List<Logs>();
            Database database = new Database();
            database.SmartConnect();
            SQLiteCommand command = new SQLiteCommand("Select * from Logs",database.connect);
            SQLiteDataReader reader = command.ExecuteReader(System.Data.CommandBehavior.CloseConnection);
            while (reader.Read())
            {
                Logs log = new Logs(reader["path"].ToString(),reader["datetime"].ToString());
                logs.Add(log);
            }
            return logs;
        }
    }
}
