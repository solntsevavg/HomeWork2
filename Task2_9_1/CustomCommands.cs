using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;

namespace Task2_9_1
{
    internal class CustomCommands
    {
        public static RoutedUICommand ChangeColor { get; set; }
        static CustomCommands()
        {
            //Первый параметр в конструкторе - это текст (для него кириллица подходит), а второй - Name (лучше использовать латиницу)
            InputGestureCollection inputGestureCollection = new InputGestureCollection();
            inputGestureCollection.Add(new KeyGesture(Key.T, ModifierKeys.Control, "Ctrl+C"));
            ChangeColor = new RoutedUICommand("Изменить цвет", "Изменить цвет", typeof(CustomCommands), inputGestureCollection);
        }
    }
}
