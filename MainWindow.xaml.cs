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

            Settings.MainWindow = this;
            Settings.MainFrame = MainFrame;
            Functions.Navigate("Main.xaml");
        }
    }
}
