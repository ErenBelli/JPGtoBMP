using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;
using System.IO;
using Microsoft.Win32;
using System.Drawing;
using _201913709039_YusufErenBelli_MyJpegToBpm.Models;
using _201913709039_YusufErenBelli_MyJpegToBpm.Providers;

namespace _201913709039_YusufErenBelli_MyJpegToBpm
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();
            foreach (var x in help.LogGet())
            {
                lbxOncekiIslemler.Items.Add(x.path.Split('\\').Last()+" - "+x.datetime);
            }
        }

        Helper help = new Helper();

        /// <summary>
        /// Bu bölümde OpenFileDialog Kullanılarak fotoğraf seçtirdik.
        /// </summary>
        private void Button_Click(object sender, RoutedEventArgs e)
        {
           OpenFileDialog openFileDialog = new OpenFileDialog();
            if (openFileDialog.ShowDialog() == true)
                tbxPath.Text = openFileDialog.FileName;
        }

        Database database = new Database();


        ///<summary>
        /// Bu eventımız ile beraber resmimiz bitmap formatına dönüştürülüyor.
        /// Hemen ardından log olarak Sqlite veritabanımıza kaydı tamamlanıyor.
        /// Sonrasında listemiz temizlenerek databasedeki veriler tekrar çekiliyor.
        /// </summary>
        private void Donustur_Click(object sender, RoutedEventArgs e)
        {
            Bitmap bitmap = new Bitmap(tbxPath.Text);
            bitmap.Save(Environment.GetFolderPath(Environment.SpecialFolder.Desktop)+$@"\\{tbxPath.Text.Split('\\').Last().Split('.').First()}.bmp");
            // Log türündeki nesnemizi doldurduk
            Logs log = new Logs(tbxPath.Text,DateTime.Now.ToString());
            // İnsert işlemimiz başlatalım.
            database.InsertLog(log);


            lbxOncekiIslemler.Items.Clear();
            foreach (var x in help.LogGet())
            {
                lbxOncekiIslemler.Items.Add(x.path.Split('\\').Last() + " - " + x.datetime);
            }
        }
    }
}
