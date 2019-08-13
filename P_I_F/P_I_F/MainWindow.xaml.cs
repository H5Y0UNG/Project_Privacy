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

        private void ListView_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {

        }

        private void Open__Click(object sender, RoutedEventArgs e)
        {
            FolderBrowserDialog folderopen = new FolderBrowserDialog();
            folderopen.Description = "검색할 폴더"; 
            folderopen.ShowDialog();

            selectfolder = folderopen.SelectedPath;
            
            
        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            string[] filelist = Directory.GetFiles(selectfolder);
            foreach (string file in filelist)
            {
                string h = file.Substring((file.Length - 3), 3);
                string filetext = File.ReadAllText(file);
                string values = "";
                int a = DetectPhoneNumber(filetext, ref values);
                if (h == "txt" && a > 0)
                {
                    list.Items.Add(file);
                }
            }
        }

        private void List_MouseDoubleClick(object sender, MouseButtonEventArgs e)
        {
            string path = list.SelectedItem.ToString();
            string text = File.ReadAllText(path);
            TextBox.Text = text;
        }

        public int DetectPhoneNumber(String input, ref String values)
        {
            String[] patterns =
            {
                @"(^|\W)01[01]\d{7,8}(\W|$)",
                @"(^|\W)01[01]-\d{3,4}-\d{4}(\W|$)"
            };
            int count = 0;

            foreach (String pattern in patterns)
            {
                System.Text.RegularExpressions.MatchCollection matches = System.Text.RegularExpressions.Regex.Matches(input, pattern);

                foreach(System.Text.RegularExpressions.Match m in matches)
                {
                    ++count;
                    values += m + "\n";
                }
            }
            return count;
        }
    }
}
