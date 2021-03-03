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
using System.Windows.Shapes;

namespace food_express
{
    /// <summary>
    /// Логика взаимодействия для AddDish.xaml
    /// </summary>
    public partial class AddDish : Window
    {
        public AddDish(DBEntities.Dish dish)
        {
            InitializeComponent();

            if (dish != null)
            {
                CurrentDish = dish;
                LabelDishName.Content = "Добавить к заказу блюдо " + CurrentDish.Name + "?";
                LabelDishCost.Content = "Цена: " + CurrentDish.Cost + "руб.";
                TextBoxDishCount.Text = "1";
            } 
            else
            {
                Close();
            }
        }

        private DBEntities.Dish CurrentDish;

        private void ButtonCountIncrement_Click(object sender, RoutedEventArgs e)
        {
            int parsed = Convert.ToInt32(TextBoxDishCount.Text);
            parsed++;
            TextBoxDishCount.Text = parsed.ToString();
        }

        private void ButtonCountDecrement_Click(object sender, RoutedEventArgs e)
        {
            int parsed = Convert.ToInt32(TextBoxDishCount.Text);
            parsed--;
            if(parsed > 0)
                TextBoxDishCount.Text = parsed.ToString();
        }

        private void TextBoxDishCount_PreviewTextInput(object sender, TextCompositionEventArgs e)
        {
            int parsed1, parsed2;
            if (!int.TryParse(e.Text, out parsed1) || !int.TryParse(TextBoxDishCount.Text + e.Text, out parsed2))
            {
                e.Handled = true;
            }
        }

        private void DialogResultCancel_Click(object sender, RoutedEventArgs e)
        {
            Close();
        }

        private void DialogResultConfirm_Click(object sender, RoutedEventArgs e)
        {
            Settings.Cart.Push(CurrentDish, Convert.ToInt32(TextBoxDishCount.Text));
            Close();
        }
    }
}
