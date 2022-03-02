using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace Bryzon.Models
{
    public class Basket
    {
        public List<BasketLineItem> Items { get; set; } = new List<BasketLineItem>();

        public virtual void AddItem (Book bo, int qty)
        {
            BasketLineItem line = Items
                .Where(p => p.Book.BookId == bo.BookId)
                .FirstOrDefault();
            if (line == null)
            {
                Items.Add(new BasketLineItem
                {
                    Book = bo,
                    Quantity = qty
                });
            }
            else
            {
                line.Quantity += qty;
            }
        }

        public virtual void RemoveItem (Book Bo)
        {
            Items.RemoveAll(p => p.Book.BookId == Bo.BookId);
        }

        public virtual void ClearBasket()
        {
            Items.Clear();
        }
        public double CalculateTotal()
        {
            double sum = Items.Sum(x => x.Quantity * x.Book.Price);

            return sum;
        }
    }



    public class BasketLineItem
    {
        [Key]
        public int LineID { get; set; }
        public Book Book { get; set; }
        public int Quantity { get; set;}
        public int Price { get; set; }
    }
}
