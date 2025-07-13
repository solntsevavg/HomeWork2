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

namespace Task2_4_1
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>

    //Создайте кнопку, которая:
    //Хранит своё состояние(включена/выключена) в DependencyProperty IsToggled.
    //Меняет цвет фона(зелёный — включено, красный — выключено) при каждом клике.
    //Отображает текущее состояние в тексте("ON" или "OFF").
    public class OnOffButton : Button

    {
        // Регистрируем DependencyProperty
        public static readonly DependencyProperty IsToggledProperty =
        DependencyProperty.Register(
        nameof(IsToggled),
        typeof(bool),
        typeof(OnOffButton),
        new FrameworkPropertyMetadata(
        false,
        ClickChanged));

        public bool IsToggled
        {
            get => (bool)GetValue(IsToggledProperty);
            set => SetValue(IsToggledProperty, value);
        }

        // Переключение состояния при нажатии
        private void OnClick(object sender, RoutedEventArgs e)
        {
            IsToggled = !IsToggled;
        }

        // Конструктор
        public OnOffButton()
        {
            // Инициализация
            Content = "OFF";
            Background = Brushes.Red;
            Click += OnClick;
        }

        // Колбэк при изменении состояния
        private static void ClickChanged(DependencyObject d, DependencyPropertyChangedEventArgs e)
        {
            var button = (OnOffButton)d;
            if (button.IsToggled)
            {
                button.Content = "ON";
                button.Background = Brushes.Green;
            }
            else
            {
                button.Content = "OFF";
                button.Background = Brushes.Red;
            }
        }
    }
}