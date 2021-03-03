using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Media;
using System.Windows.Media.Imaging;

namespace food_express.Pages
{
    public partial class Main : Page
    {
        public UIPanelCollection<DBEntities.DishCategory> DishCategories;

        public Main()
        {
            InitializeComponent();

            DishCategories = new UIPanelCollection<DBEntities.DishCategory>(GridCategories.ColumnDefinitions.Count, GridCategories.RowDefinitions.Count);
            using (MainModel context = new MainModel())
            {
                foreach(var cat in context.DishesCategories)
                {
                    UIElement Panel = Functions.CreatePanelForGrid(Functions.GetImage(cat.Image), cat.Name);
                    Panel.MouseLeftButtonUp += Panel_MouseLeftButtonUp;
                    GridCategories.Children.Add(Panel);
                    UIPanelSize coors = DishCategories.Push(Panel, cat);
                    if (coors.X > -1 && coors.Y > -1)
                    {
                        Grid.SetColumn(DishCategories[coors].Element, coors.X);
                        Grid.SetRow(DishCategories[coors].Element, coors.Y);
                    } 
                    else
                    {
                        break;
                    }
                }
            }
        }

        private void Panel_MouseLeftButtonUp(object sender, System.Windows.Input.MouseButtonEventArgs e)
        {
            UIElement elem = sender as UIElement;
            int x, y;
            x = Grid.GetColumn(elem);
            y = Grid.GetRow(elem);
            Settings.CurrentPageArguments = new dynamic[]
            {
                DishCategories[x, y].DataObject
            };
            Functions.Navigate("Dish");
        }

        private void ButtonCartOpen_Click(object sender, RoutedEventArgs e)
        {
            Functions.OpenCart();
        }
    }
}
