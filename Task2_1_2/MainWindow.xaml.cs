using System.Drawing;
using System.Text;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Media.Media3D;
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace Task2_1_2
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        //        "Светофор"
        //Разместите вертикально три круга(элемент Ellipse со значениями ширины (Width) и высоты (Height), равными 100).
        //Добавьте кнопку(элемент Button) "Next". При каждом нажатии активный "сигнал" должен переключаться по порядку.
        //Например, верхний прямоугольник - красный, остальные в это время - серые.После следующего нажатия кнопки средний
        //прямоугольник становится желтым, остальные - серые и т.д.
        public MainWindow()
        {
            InitializeComponent();
        }

        private int _i = 0;

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            EllipseTop.Fill = Brushes.Gray;  // Все серые
            EllipseCenter.Fill = Brushes.Gray;
            EllipseDown.Fill = Brushes.Gray;
            if (_i < 3)
            {
                switch (_i)
                {
                    case 0:
                        EllipseDown.Fill = Brushes.Red;
                        break;
                    case 1:
                        EllipseTop.Fill = Brushes.Green;
                        break;
                    case 2:
                        EllipseCenter.Fill = Brushes.Yellow;
                        break;
                }
            }
            else
            {
                EllipseDown.Fill = Brushes.Red; //На четвертом клике красим красный и обнуляем счетчик
                _i = 0;
            }
            _i++;
        }
    }
}