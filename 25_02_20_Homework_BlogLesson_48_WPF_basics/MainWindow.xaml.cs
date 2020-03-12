using System;
using System.Collections.Generic;
using System.IO;
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

namespace _25_02_20_Homework_BlogLesson_48_WPF_basics
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        private string[] _pathsToImagesArr;
        private string[] _fileNamesOfImages;

        public MainWindow()
        {
            InitializeComponent();
            Initialize();

        }
        private void Initialize()
        {
            _pathsToImagesArr = new DirectoryInfo(System.IO.Path.Combine(Directory.GetParent(Directory.GetParent(Directory.GetParent(Directory.GetCurrentDirectory()).FullName).FullName).FullName, "pictures")).GetFiles().Select(x => x.FullName).ToArray();            
            _fileNamesOfImages = new DirectoryInfo(System.IO.Path.Combine(Directory.GetParent(Directory.GetParent(Directory.GetParent(Directory.GetCurrentDirectory()).FullName).FullName).FullName, "pictures")).GetFiles().Select(x => x.Name).ToArray();

            foreach (var s in Statics.FindLogicalChildren<Button>(this))
            {
                if (Int32.TryParse(s.Name.Last().ToString(), out int num)) { s.Tag = _fileNamesOfImages[num].ToLower().FirstLetterToUpper().Substring(0, _fileNamesOfImages[num].LastIndexOf(".")).Replace("_", " "); }
            }
        }


        private void Button_Click(object sender, RoutedEventArgs e)
        {
            imgCoffeImage.Source = new BitmapImage(new Uri(_pathsToImagesArr[Int32.Parse((sender as Button).Name.Last().ToString())], UriKind.Absolute));            
        }
    }
}
