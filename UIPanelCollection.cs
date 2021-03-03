using System;
using System.Collections.Generic;
using System.Linq;
using System.Windows;
using System.Windows.Controls;

namespace food_express
{
    public class UIPanelCollection<T>
    {
        public UIPanelCollection(int x, int y)
        {
            if (x < 0 || y < 0) throw new IndexOutOfRangeException();
            Size = new UIPanelSize(x, y);
            ElementsArray = new UIPanel<T>[Size.X, Size.Y];
        }
        public UIPanelCollection(UIPanelSize size)
        {
            if (size.X < 0 || size.Y < 0) throw new IndexOutOfRangeException();
            Size = new UIPanelSize(size.X, size.Y);
            ElementsArray = new UIPanel<T>[Size.X, Size.Y];
        }
        public UIPanelSize Size { get; set; }
        public UIPanel<T>[,] ElementsArray { get; set; }
        public UIPanel<T> this[int x, int y]
        {
            get
            {
                if (x < 0 || y < 0 || x > Size.X || y > Size.Y) throw new IndexOutOfRangeException(); 
                return ElementsArray[x, y];
            }
            set
            {
                if (x < 0 || y < 0 || x > Size.X || y > Size.Y) throw new IndexOutOfRangeException(); 
                ElementsArray[x, y] = value;
            }
        }
        public UIPanel<T> this[UIPanelSize coors]
        {
            get
            {
                if (coors.X < 0 || coors.Y < 0 || coors.X > Size.X || coors.Y > Size.Y) throw new IndexOutOfRangeException();
                return ElementsArray[coors.X, coors.Y];
            }
            set
            {
                if (coors.X < 0 || coors.Y < 0 || coors.X > Size.X || coors.Y > Size.Y) throw new IndexOutOfRangeException();
                ElementsArray[coors.X, coors.Y] = value;
            }
        }
        public UIPanelSize Push(UIElement element, T data)
        {
            for (int y = 0; y < Size.Y; y++)
            {
                for (int x = 0; x < Size.X; x++)
                {
                    if (this[x, y] == null)
                    {
                        this[x, y] = new UIPanel<T>()
                        {
                            Element = element,
                            DataObject = data
                        };
                        return new UIPanelSize(x, y);
                    }
                }
            }
            return UIPanelSize.Empty;
        }
    }

    public class UIPanel<T>
    {
        public UIElement Element { get; set; }
        public T DataObject { get; set; }
    }

    public struct UIPanelSize
    {
        public UIPanelSize(int x, int y)
        {
            if (x < -1 || y < -1) throw new IndexOutOfRangeException();
            _x = x;
            _y = y;
        }
        private int _x;
        private int _y;
        public int X
        {
            get { return _x; }
            set
            {
                if (value < -1) throw new IndexOutOfRangeException();
                _x = value;
            }
        }
        public int Y
        {
            get { return _y; }
            set
            {
                if (value < -1) throw new IndexOutOfRangeException();
                _y = value;
            }
        }
        public static UIPanelSize Empty = new UIPanelSize(-1, -1);
    }
}
