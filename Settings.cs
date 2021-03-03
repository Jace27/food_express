using System;
using System.Collections.Generic;
using System.Windows.Controls;
using System.Windows.Media;

namespace food_express
{
    public static class Settings
    {
        public struct Colors
        {
            public static Color Yellow = Color.FromRgb(240, 190, 50);
            public static Color Black = Color.FromRgb(0, 0, 0);
            public static Color Grey = Color.FromRgb(208, 200, 186);
            public static Color Red = Color.FromRgb(179, 23, 54);
        }

        public static MainWindow MainWindow;
        public static Frame MainFrame;

        public static dynamic[] CurrentPageArguments;
    }
}
