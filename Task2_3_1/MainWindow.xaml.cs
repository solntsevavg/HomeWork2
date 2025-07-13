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

namespace Task2_3_1
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

        private void SaveButton_Click(object sender, RoutedEventArgs e)
        {
            // Проверка согласия на рассылку
            if (!PersonalCheckBox.IsChecked ?? false)
            {
                MessageBox.Show("Ошибка: необходимо дать согласие на обработку персональных данных!", "Ошибка",
                MessageBoxButton.OK, MessageBoxImage.Error);
                return;
            }

            // Получаем выбранные данные

            var selectedCourse = CourseListBox.SelectedItems
                .Cast<string>()
                .ToList();

            // Данные отправлены
            string message = $"Данные отправлены!\n\n" +
            $"Студент: {NameTextBox.Text}\n" +
            $"Факультет: {FacultyComboBox.Text}\n" +
            $"Курсы: {string.Join(", ", selectedCourse)}\n" +
            $"Форма обучения: {(FullForm.IsChecked == true ? "Очно" : "Заочно")}\n" +
            $"Количество часов в неделю: {HoursSlider.Value}\n" +
            $"Согласие на обработку персональных данных: {(PersonalCheckBox.IsChecked == true ? "Да" : "Нет")}";
            MessageBox.Show(message, "Успешно", MessageBoxButton.OK, MessageBoxImage.Information);
        }
        private void MadeButton_Click(object sender, RoutedEventArgs e)
        {
            CourseListBox.Items.Clear(); //Очистка списка, если курс меняется

            List<string> courses = new List<string>();

            if (FacultyComboBox.Text == "Программирование")
            {
                courses.Add("С#");
                courses.Add("WPF");
                courses.Add("Базы данных");
            }
            else
            {
                if (FacultyComboBox.Text == "Дизайн")
                {
                    courses.Add("Графический дизайн");
                    courses.Add("Веб-дизайн");
                    courses.Add("3д моделирование");
                }

                else
                {
                    courses.Add("Менеджер по проектам");
                    courses.Add("Менеджер по подбору персонала");
                    courses.Add("Маркетинг");
                }
            }
            // Добавляем курсы в ListBox

            foreach (var course in courses)
            {
                CourseListBox.Items.Add(course);
            }
        }
    }
}
