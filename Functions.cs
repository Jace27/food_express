﻿using System;
using System.Collections.Generic;
using System.IO;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Media;
using System.Windows.Media.Imaging;

namespace food_express
{
    public static class Functions
    {
        public static string GenerateOrderNumber(int order_id)
        {
            char[] chars = new char[] {
                'A', 'B', 'C', 'D', 'E', 'F', 'G', 'H', 'I', 'J', 'K', 'L', 'M', 
                'N', 'O', 'P', 'Q', 'R', 'S', 'T', 'U', 'V', 'W', 'X', 'Y', 'Z',
                'a', 'b', 'c', 'd', 'e', 'f', 'g', 'h', 'i', 'j', 'k', 'l', 'm', 
                'n', 'o', 'p', 'q', 'r', 's', 't', 'u', 'v', 'w', 'x', 'y', 'z',
                '0', '1', '2', '3', '4', '5', '6', '7', '8', '9'
            };
            char[] code = new char[3];
            Random rand = new Random(1);
            int num = (order_id % (int)Math.Round(Math.Pow(chars.Length, 3))) * chars.Length;
            for (int i = 0; i < code.Length; i++)
            {
                num = num / chars.Length;
                int c = num % chars.Length;
                code[i] = chars[c];
            }
            return new string(code);
        }

        public static UIElement CreatePanelForGrid(BitmapImage bi, string label)
        {
            var Dock = new DockPanel()
            {
                Margin = new Thickness(10, 10, 10, 10),
                LastChildFill = true,
                Background = new SolidColorBrush(Colors.White)
            };
            var Border = new Border()
            {
                VerticalAlignment = VerticalAlignment.Bottom,
                Background = new SolidColorBrush(Colors.White),
                Margin = new Thickness(0, 0, 0, -10)
            };
            var Label = new Label()
            {
                Content = label,
                HorizontalAlignment = HorizontalAlignment.Center,
                FontSize = 20
            };
            var Image = new Image()
            {
                Source = bi
            };
            Border.Child = Label;
            Dock.Children.Add(Border);
            DockPanel.SetDock(Border, System.Windows.Controls.Dock.Bottom);
            Dock.Children.Add(Image);
            return Dock;
        }

        public static void LoadImage(Image image, string path)
        {
            byte[] bi = File.ReadAllBytes(path);
            image.Source = GetImage(bi);
        }
        public static void LoadImage(Image image, byte[] bi)
        {
            image.Source = GetImage(bi);
        }
        public static void LoadImage(Image image, BitmapImage bi)
        {
            image.Source = bi;
        }
        public static void LoadImage(ImageBrush image, string path)
        {
            byte[] bi = File.ReadAllBytes(path);
            image.ImageSource = GetImage(bi);
        }
        public static void LoadImage(ImageBrush image, byte[] bi)
        {
            image.ImageSource = GetImage(bi);
        }
        public static void LoadImage(ImageBrush image, BitmapImage bi)
        {
            image.ImageSource = bi;
        }
        public static BitmapImage GetImage(byte[] bi)
        {
            if (bi == null) return new BitmapImage();
            MemoryStream ms = new MemoryStream(bi);
            BitmapImage i = new BitmapImage();
            i.BeginInit();
            i.StreamSource = ms;
            i.EndInit();
            return i;
        }

        public static void Navigate(string path)
        {
            if (path == "back")
            {
                Settings.MainFrame.GoBack();
            }
            else
            {
                Settings.MainFrame.Navigate(new Uri("Pages/" + path + ".xaml", UriKind.Relative));
            }
        }
        public static void OpenCart()
        {
            Navigate("Order");
        }
    }
}
