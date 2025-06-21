using System.Reflection;
using System.Text;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace Task2_1_1
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        //        "Счетчик кликов"
        //Добавьте кнопку(элемент Button) и текстовый блок(элемент TextBlock).
        //При каждом нажатии на кнопку число в текстовом блоке должно увеличиваться.
        private int _result = 0;

        public MainWindow()
        {
            InitializeComponent();
        }
        private void Button_Click(object sender, RoutedEventArgs e)
        {
            _result++;

            Text.Text = $"{_result}";
        }
    }
}