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
    /// <summary>
    /// Логика взаимодействия для Main.xaml
    /// </summary>
    public partial class Main : Page
    {
        public Main()
        {
            InitializeComponent();
            using (MainModel context = new MainModel())
            {
                int x = 0, y = 0;
                foreach(var cat in context.DishesCategories)
                {
                    UIElement Panel = Functions.CreatePanelForGrid(Functions.GetImage(cat.Image), cat.Name);
                    Panel.MouseLeftButtonUp += DockPanel_MouseLeftButtonUp;
                    GridCategories.Children.Add(Panel);
                    Grid.SetColumn(Panel, x);
                    Grid.SetRow(Panel, y);
                    x++;
                    if (x == GridCategories.ColumnDefinitions.Count)
                    {
                        x = 0;
                        y++;
                        if (y == GridCategories.RowDefinitions.Count)
                            break;
                    }
                }
            }
        }

        private void DockPanel_MouseLeftButtonUp(object sender, System.Windows.Input.MouseButtonEventArgs e)
        {

        }
    }
}
