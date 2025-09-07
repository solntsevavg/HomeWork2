using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Data;
using System.Windows.Media;

namespace UserControlExample
{
    public class ProgressToColorConverter : IValueConverter
    {
        public object Convert(object value, Type targetType, object parameter, CultureInfo culture)
        {
            if (value is double progress)
            {
                return GetColorForProgress(progress);
            }
            return Colors.Black;
        }

        private Color GetColorForProgress(double progress)
        {
            // 0-20% - зеленый
            if (progress <= 0.2) return Color.FromRgb(76, 175, 80);    


            // 20-40% - желто-зеленый
            if (progress <= 0.4) return Color.FromRgb(173, 255, 47);


            // 40-60% - желтый
            if (progress <= 0.6) return Color.FromRgb(255, 255, 0);

            // 60-80% - оранжевый
            if (progress <= 0.8) return Color.FromRgb(255, 204, 51);   

            // 80-100% - красный
            return Color.FromRgb(244, 67, 54);                        
        }

        public object ConvertBack(object value, Type targetType, object parameter, CultureInfo culture)
        {
            throw new NotImplementedException();
        }
    }
}
