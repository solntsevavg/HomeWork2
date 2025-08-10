using System.Collections.ObjectModel;
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

namespace Task2_8_1
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        public ObservableCollection<Product> products = new ObservableCollection<Product>();
        public MainWindow()
        {
            InitializeComponent();
            products.Add(new Product()
            {
                ProductName = "Яблоки",
                Cost = 229.99m,
                ImageWay = "_avatar/_apple.jpg",
                ProductType = ProductTypes.Food
            });
            products.Add(new Product()
            {
                ProductName = "Принтер",
                Cost = 10999.99m,
                ImageWay = "_avatar/_printer.jpg",
                ProductType = ProductTypes.Technic
            });
            products.Add(new Product()
            {
                ProductName = "Бананы",
                Cost = 199.49m,
                ImageWay = "_avatar/_banana.jpg",
                ProductType = ProductTypes.Food
            });
            lstBox.ItemsSource = products;
        }
    }
}
