using System;
using System.Collections.Generic;
using System.Linq;

namespace food_express
{
    public class Cart
    {
        private CartItem[] _items = new CartItem[0];
        public CartItem[] Items
        {
            get { return _items; }
            set { _items = value; }
        }
        public int Count
        {
            get { return Items.Length; }
            set
            {
                if (value < 0) throw new IndexOutOfRangeException();
                Array.Resize<CartItem>(ref _items, value);
            }
        }
        public decimal Sum
        {
            get
            {
                decimal _sum = 0;
                foreach(CartItem item in _items)
                {
                    _sum += item.Dish.Cost * item.Count;
                }
                return _sum;
            }
        }
        public CartItem this[int i]
        {
            get { return Items[i]; }
            set 
            {
                if (i >= Count) Count = i + 1;
                Items[i] = value;
                CartChanged?.Invoke();
            }
        }
        public void Push(DBEntities.Dish dish, int count)
        {
            for (int i = 0; i < _items.Length; i++)
            {
                if (_items[i].Dish.Id == dish.Id)
                {
                    _items[i].Count += count;
                    return;
                }
            }
            this[Count] = new CartItem()
            {
                Dish = dish,
                Count = count
            };
            CartChanged?.Invoke();
        }
        public void EditItem(DBEntities.Dish dish, int count)
        {
            for (int i = 0; i < Count; i++)
            {
                if (this[i].Dish.Id == dish.Id)
                {
                    this[i].Count = count;
                    this[i].Dish = dish;
                    return;
                }
            }
            Push(dish, 1);
        }
        public int GetCount(DBEntities.Dish dish)
        {
            for (int i = 0; i < Count; i++)
            {
                if (this[i].Dish.Id == dish.Id)
                {
                    return this[i].Count;
                }
            }
            return 0;
        }
        public CartItem Find(DBEntities.Dish dish)
        {
            for (int i = 0; i < Count; i++)
            {
                if (this[i].Dish.Id == dish.Id)
                {
                    return this[i];
                }
            }
            return null;
        }
        public void Remove(DBEntities.Dish dish)
        {
            Remove(dish.Id);
        }
        public void Remove(int id)
        {
            bool move = false;
            for(int i = 0; i < Count; i++)
            {
                if (this[i].Dish.Id == id) move = true;
                if (move && i != Count - 1)
                {
                    this[i] = this[i + 1];
                }
            }
            if (move) Count--;
            CartChanged?.Invoke();
        }

        public Cart Clone()
        {
            Cart ret = MemberwiseClone() as Cart;
            ret.Items = _items;
            return ret;
        }

        public delegate void CartChangedDelegate();
        public event CartChangedDelegate CartChanged;
    }
    public class CartItem
    {
        private int _count = 1;
        public DBEntities.Dish Dish { get; set; }
        public int Count
        {
            get { return _count; }
            set
            {
                if (value < 0) throw new IndexOutOfRangeException();
                _count = value;
            }
        }
    }
}
