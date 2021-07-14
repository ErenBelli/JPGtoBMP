using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _201913709039_YusufErenBelli_MyJpegToBpm
{
    class Logs
    {
        /// <summary>
        ///  Databasedeki tabloya göre oluşturulan Logs Sınıfı
        /// </summary>
        public int ID { get; set; }
        public string path { get; set; }
        public string datetime { get; set; }

        public Logs(string path, string datetime)
        {
            this.path = path;
            this.datetime = datetime;
        }
    }
}
