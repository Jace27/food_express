using System;
using System.Collections.Generic;
using System.Linq;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using food_express.DBEntities;

namespace food_express.Pages
{
    public partial class Dish : Page
    {
        public Dish()
        {
            InitializeComponent();

            if (Settings.CurrentPageArguments != null)
            {
                foreach(var arg in Settings.CurrentPageArguments)
                {
                    if (arg is DishCategory)
                    {
                        CurrentCategory = arg;
                        break;
                    }
                }
            } 
            else
            {
                Functions.Navigate("Main");
            }
            if (CurrentCategory != null)
            {
                CategoryLabel.Content = CurrentCategory.Name;
                Dishes = new UIPanelCollection<DBEntities.Dish>(GridDishes.ColumnDefinitions.Count, GridDishes.RowDefinitions.Count);
                using (MainModel context = new MainModel())
                {
                    ICollection<DBEntities.Dish> dishes = context.Dishes.Where(d => d.CategoryId == CurrentCategory.Id).ToList();
                    if (dishes != null && dishes.Count > 0)
                    {
                        foreach (DBEntities.Dish dish in dishes)
                        {
                            UIElement panel = Functions.CreatePanelForGrid(Functions.GetImage(dish.Image), dish.Name);
                            GridDishes.Children.Add(panel);
                            UIPanelSize coors = Dishes.Push(panel, dish);
                            if (coors.X > -1 && coors.Y > -1)
                            {
                                Grid.SetColumn(Dishes[coors].Element, coors.X);
                                Grid.SetRow(Dishes[coors].Element, coors.Y);
                            }
                        }
                    } 
                    else
                    {
                        CategoryLabel.Content = CategoryLabel.Content + " - Нет блюд";
                    }
                }
            }
            else
            {
                Functions.Navigate("Main");
            }
        }

        private DishCategory CurrentCategory;
        private UIPanelCollection<DBEntities.Dish> Dishes;

        private void BtnBack_Click(object sender, RoutedEventArgs e)
        {
            Functions.Navigate("back");
        }
    }
}
