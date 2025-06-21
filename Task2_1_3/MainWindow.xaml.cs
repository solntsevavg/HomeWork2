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

namespace Task2_1_3
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        //        "Убегающая кнопка"
        //Создайте окно с одной кнопкой(элемент Button).
        //При попытке навести курсор на кнопку она должна перемещаться в случайное место внутри окна.
        public MainWindow()
        {
            InitializeComponent();
        }

        private void Text_MouseEnter(object sender, MouseEventArgs e)
        {

            Random rnd = new Random();

            int maxWidth = Convert.ToInt32(MainGrid.ActualWidth - ButtonCatch.ActualWidth);
            int maxHeight = Convert.ToInt32(MainGrid.ActualHeight - ButtonCatch.ActualHeight);

            int randomWidth = rnd.Next(0, maxWidth); //Рандомное положение по ширине в пределах окна

            int randomHeight = rnd.Next(0, maxHeight); //Рандомное значение по высотек в пределах окна

            ButtonCatch.Margin = new Thickness(randomWidth, randomHeight, 0, 0);
        }
    }
}