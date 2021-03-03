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

namespace food_express.Pages
{
    /// <summary>
    /// Логика взаимодействия для Order.xaml
    /// </summary>
    public partial class Order : Page
    {
        UIPanelCollection<DBEntities.Dish> Dishes;
        Cart Cart;

        public Order()
        {
            InitializeComponent();

            Cart = Settings.Cart.Clone();
            if (Cart.Count == 0)
            {
                CartLabel.Content = "Корзина пуста";
            } 
            else
            {
                CartLabel.Content = "Корзина    Всего: " + Cart.Sum + "руб.";
                Dishes = new UIPanelCollection<DBEntities.Dish>(GridDishes.ColumnDefinitions.Count, GridDishes.RowDefinitions.Count);
                foreach(CartItem item in Cart.Items)
                {
                    UIElement panel = Functions.CreatePanelForGrid(Functions.GetImage(item.Dish.Image), item.Dish.Name + " " + item.Count + "шт. (" + (item.Dish.Cost * item.Count) + "руб.)");
                    GridDishes.Children.Add(panel);
                    UIPanelSize coors = Dishes.Push(panel, item.Dish);
                    if (coors.X > -1 && coors.Y > -1)
                    {
                        Grid.SetColumn(panel, coors.X);
                        Grid.SetRow(panel, coors.Y);
                    }
                }
            }
        }

        private void BtnBack_Click(object sender, RoutedEventArgs e)
        {
            Functions.Navigate("back");
        }
    }
}
