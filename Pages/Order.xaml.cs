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

            DisplayCart();
            Settings.Cart.CartChanged += Cart_CartChanged;
        }

        private void Cart_CartChanged()
        {
            DisplayCart();
        }

        private void DisplayCart()
        {
            GridDishes.Children.Clear();
            Cart = Settings.Cart.Clone();
            if (Cart.Count == 0)
            {
                CartLabel.Content = "Корзина пуста";
            }
            else
            {
                CartLabel.Content = "Корзина    Всего: " + Cart.Sum + "руб.";
                Dishes = new UIPanelCollection<DBEntities.Dish>(GridDishes.ColumnDefinitions.Count, GridDishes.RowDefinitions.Count);
                foreach (CartItem item in Cart.Items)
                {
                    UIElement panel = Functions.CreatePanelForGrid(Functions.GetImage(item.Dish.Image), item.Dish.Name + " " + item.Count + "шт. (" + (item.Dish.Cost * item.Count) + "руб.)");
                    panel.MouseLeftButtonUp += Panel_MouseLeftButtonUp;
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

        private void Panel_MouseLeftButtonUp(object sender, System.Windows.Input.MouseButtonEventArgs e)
        {
            UIElement panel = sender as UIElement;
            int x, y;
            x = Grid.GetColumn(panel);
            y = Grid.GetRow(panel);
            EditDish dialog = new EditDish(Cart.Find(Dishes[x, y].DataObject));
            dialog.ShowDialog();
            DisplayCart();
        }

        private void BtnOrder_Click(object sender, RoutedEventArgs e)
        {
            using (MainModel context = new MainModel())
            {
                DBEntities.Order order = context.Orders.Create();
                order.DateTime = DateTime.Now;
                order.Status = context.OrderStatuses.Where(s => s.Name == "Готовится").ToArray()[0];
                order.Dishes = context.OrderDishes.ToList();
                order.Number = "   ";
                for (int i = 0; i < Cart.Count; i++)
                {
                    DBEntities.OrderDish link = new DBEntities.OrderDish()
                    {
                        Dish = Cart[i].Dish,
                        Count = Cart[i].Count,
                        Order = order
                    };
                    order.Dishes.Add(link);
                }
                context.Orders.Add(order);
                context.SaveChanges();
                order.Number = Functions.GenerateOrderNumber(order.Id);
                context.SaveChanges();
                MessageBox.Show("Спасибо за заказ, мы уже начали его готовить. Номер заказа " + order.Number, "Заказ", MessageBoxButton.OK, MessageBoxImage.Information);
                Functions.Navigate("back");
            }
        }

        private void BtnBack_Click(object sender, RoutedEventArgs e)
        {
            Functions.Navigate("back");
        }
    }
}
