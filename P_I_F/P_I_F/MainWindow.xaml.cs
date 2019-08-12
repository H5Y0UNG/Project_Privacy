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
using System.Windows.Forms;

namespace P_I_F
{
    /// <summary>
    /// MainWindow.xaml에 대한 상호 작용 논리
    /// </summary>
    public partial class MainWindow : Window
    {
        public string selectfolder;
        public MainWindow()
        {
            InitializeComponent();
        }

        public string Read(string path)
        {
            return File.ReadAllText(path);

        }

        private void ListView_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {

        }

        private void Open__Click(object sender, RoutedEventArgs e)
        {
            FolderBrowserDialog folderopen = new FolderBrowserDialog();
            folderopen.Description = "검색할 폴더";
            folderopen.ShowDialog();

            selectfolder = folderopen.SelectedPath;
            string[] filelist = Directory.GetFiles(selectfolder);
            string h = filelist[0].Substring((filelist[0].Length - 3), 3);
            list.Items.Add(h);
            Console.WriteLine();
        }
    }
}
