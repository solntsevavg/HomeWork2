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

namespace UserControlExample
{
    /// <summary>
    /// Логика взаимодействия для CircularProgressBar.xaml
    /// </summary>
    public partial class CircularProgressBar : UserControl
    {
        public static readonly DependencyProperty ValueProperty =
            DependencyProperty.Register(
                nameof(Value),
                typeof(double),
                typeof(CircularProgressBar),
                new PropertyMetadata(0.0, OnValueChanged));

        public static readonly DependencyProperty MaximumProperty =
            DependencyProperty.Register(
                nameof(Maximum),
                typeof(double),
                typeof(CircularProgressBar),
                new PropertyMetadata(100.0, OnValueChanged));

        //// Read-only Dependency Properties
        //private static readonly DependencyPropertyKey ProgressAnglePropertyKey =
        //    DependencyProperty.RegisterReadOnly(
        //        nameof(ProgressAngle),
        //        typeof(double),
        //        typeof(CircularProgressBar),
        //        new PropertyMetadata(0.0));

        //public static readonly DependencyProperty ProgressAngleProperty = ProgressAnglePropertyKey.DependencyProperty;

        private static readonly DependencyPropertyKey PercentageTextPropertyKey =
            DependencyProperty.RegisterReadOnly(
                nameof(PercentageText),
                typeof(string),
                typeof(CircularProgressBar),
                new PropertyMetadata("0%"));

        public static readonly DependencyProperty PercentageTextProperty = PercentageTextPropertyKey.DependencyProperty;

        private ArcSegment _progressArc;
        public double Value
        {
            get => (double)GetValue(ValueProperty);
            set => SetValue(ValueProperty, value);
        }

        public double Maximum
        {
            get => (double)GetValue(MaximumProperty);
            set => SetValue(MaximumProperty, value);
        }

        //public double ProgressAngle
        //{
        //    get => (double)GetValue(ProgressAngleProperty);
        //    private set => SetValue(ProgressAnglePropertyKey, value);
        //}

        public string PercentageText
        {
            get => (string)GetValue(PercentageTextProperty);
            private set => SetValue(PercentageTextPropertyKey, value);
        }

        public CircularProgressBar()
        {
            InitializeComponent();
            //UpdateProgress();
            Loaded += OnLoaded;
        }

        private void OnLoaded(object sender, RoutedEventArgs e)
        {
            // Инициализация после загрузки
            _progressArc = this.FindName("progressArc") as ArcSegment;
            UpdateProgress();
        }

        
        private static void OnValueChanged(DependencyObject d, DependencyPropertyChangedEventArgs e)
        {
            var progressBar = (CircularProgressBar)d;
            progressBar.UpdateProgress();
        }

        private void UpdateProgress()
        {
            // Ограничиваем значения
            if (Value < 0) Value = 0;
            if (Value > Maximum) Value = Maximum;
            if (Maximum <= 0) Maximum = 100;

            // Вычисляем прогресс
            double percentage = Maximum == 0 ? 0 : (Value / Maximum);
            ProgressPercentage = percentage;
            double angle = 360 * percentage;

            UpdateArcGeometry(angle);
            PercentageText = $"{(percentage * 100):F0}%";
        }

        
        private void UpdateArcGeometry(double angle)
        {
            if (_progressArc == null) return;
            // Ограничиваем угол от 0 до 360
            angle = Math.Max(0, Math.Min(360, angle));

            // Для угла 0 скрываем дугу
            if (angle == 0)
            {
                _progressArc.Point = new Point(50, 5); // Начальная точка
                _progressArc.IsLargeArc = false;
                return;
            }
            // Преобразуем угол в радианы
            double radians = angle * Math.PI / 180;

            // Вычисляем конечную точку дуги
            double endX = 50 + 45 * Math.Sin(radians);
            double endY = 50 - 45 * Math.Cos(radians);

            _progressArc.Point = new Point(endX, endY);
            _progressArc.IsLargeArc = angle > 180;
        }

        private static readonly DependencyPropertyKey ProgressPercentagePropertyKey =
        DependencyProperty.RegisterReadOnly(
            nameof(ProgressPercentage),
            typeof(double),
            typeof(CircularProgressBar),
            new PropertyMetadata(0.0));

        public static readonly DependencyProperty ProgressPercentageProperty = ProgressPercentagePropertyKey.DependencyProperty;

        public double ProgressPercentage
        {
            get => (double)GetValue(ProgressPercentageProperty);
            private set => SetValue(ProgressPercentagePropertyKey, value);
        }
    }
}
