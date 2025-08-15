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

namespace Task2_9_1
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();
        }

        // Коллекция для хранения последовательности цветов
        private Stack<Brush> _colorHistory = new Stack<Brush>();

        private Brush _currentColor = Brushes.LightGray; //Исходный цвет
        private Brush _undoColor = Brushes.LightGray;

        // Текущий цвет
        public Brush CurrentColor
        {
            get => _currentColor;
            set
            {
                _undoColor = _currentColor; //Сохраняем предыдущий цвет
                _currentColor = value;

                // Добавляем новый цвет в стек, если предыдущий цвет не такой же
                // (либо стек пустой) 
                if (_colorHistory.Count == 0 || _colorHistory.Peek() != value)
                {
                    _colorHistory.Push(value);
                }
                // Dock - это имя (x:Name) контейнера компоновки, для которого меняем цвет

                Dock.Background = _currentColor;
                UndoDock.Background = _undoColor; //Запись предыдущего цвета в нижнюю часть окна
            }
        }

        private void ChangeColorExecuted(object sender, ExecutedRoutedEventArgs e)
        {
            var random = new Random();
            // CurrentColor - это свойство для хранения текущего цвета
            // ниже описано, как оно устроено
            CurrentColor = new SolidColorBrush(Color.FromRgb(
                (byte)random.Next(256),
                (byte)random.Next(256),
                (byte)random.Next(256)));
        }

        private void UndoExecuted(object sender, ExecutedRoutedEventArgs e)
        {
            if (_colorHistory.Count > 1)
            {
                _colorHistory.Pop(); // Удаляем текущий цвет
                CurrentColor = _colorHistory.Pop(); // Берём предыдущий
            }
        }
    }
}