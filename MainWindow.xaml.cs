using System;
using System.Collections.Generic;
using System.Windows;
using System.IO;

namespace food_express
{
    /// <summary>
    /// Логика взаимодействия для MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();

            Functions.LoadImage(MainImg, Environment.CurrentDirectory + "/../../Images/DishCategories/burgers.png");
            using (MainModel context = new MainModel())
            {
                DBEntities.DishCategories newdc = new DBEntities.DishCategories();
                newdc.Name = "Соусы";
                newdc.Image = File.ReadAllBytes(Environment.CurrentDirectory + "/../../Images/DishCategories/sauses.png");
                context.DishesCategories.Add(newdc);
                context.SaveChanges();
            }
        }
    }
}
