using System;
using System.Collections.Generic;
using System.IO;
using System.Windows.Controls;
using System.Windows.Media.Imaging;

namespace food_express
{
    public static class Functions
    {
        public static void LoadImage(Image image, string path)
        {
            byte[] bi = File.ReadAllBytes(path);
            MemoryStream ms = new MemoryStream(bi);
            BitmapImage i = new BitmapImage();
            i.BeginInit();
            i.StreamSource = ms;
            i.EndInit();
            image.Source = i;
        }
        public static void LoadImage(Image image, byte[] bi)
        {
            MemoryStream ms = new MemoryStream(bi);
            BitmapImage i = new BitmapImage();
            i.BeginInit();
            i.StreamSource = ms;
            i.EndInit();
            image.Source = i;
        }
    }
}
