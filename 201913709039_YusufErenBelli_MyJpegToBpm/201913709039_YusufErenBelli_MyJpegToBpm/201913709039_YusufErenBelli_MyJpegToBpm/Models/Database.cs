using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.SQLite;

namespace _201913709039_YusufErenBelli_MyJpegToBpm.Models
{
    class Database
    {
        public SQLiteConnection connect = new SQLiteConnection($@"Data Source='{Environment.CurrentDirectory}\\database.db3'");
     
        /// <summary>
        /// SmartConnect sayesinde bağlantı sadece kapalıyken açılacak.
        /// </summary>
        public void SmartConnect()
        {
            if (connect.State == System.Data.ConnectionState.Closed)
            {
                connect.Open();
            }
        }

        /// <summary>
        /// Database'e logs sınıf türünden bir nesne eklemek için method.
        /// </summary>
        /// <param name="log"></param>
        public void InsertLog(Logs log)
        {
            SmartConnect();
            SQLiteCommand command = new SQLiteCommand("insert into Logs (path,datetime) VALUES (@path,@datetime)",connect);
            command.Parameters.AddWithValue("@path",log.path);
            command.Parameters.AddWithValue("@datetime",log.datetime);
            command.ExecuteNonQuery();
        }
    }
}
