﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace WebShop.Models
{
    public class Cart
    {
        private List<CartLine> lineCollection = new List<CartLine>();

        public void AddItem(Phone phone, int quantity)
        {
            CartLine line = lineCollection
                .Where(g => g.Phone.ID == phone.ID)
                .FirstOrDefault();

            if (line == null)
            {
                lineCollection.Add(new CartLine
                {
                    Phone = phone,
                    Quantity = quantity
                });
            }
            else
            {
                line.Quantity += quantity;
            }
        }

        public void RemoveLine(Phone phone)
        {
            lineCollection.RemoveAll(l => l.Phone.ID == phone.ID);
        }

        public decimal ComputeTotalValue()
        {
            return lineCollection.Sum(e => e.Phone.Price * e.Quantity);

        }
        public void Clear()
        {
            lineCollection.Clear();
        }

        public IEnumerable<CartLine> Lines
        {
            get { return lineCollection; }
        }
    }

    public class CartLine
    {
        public Phone Phone { get; set; }
        public int Quantity { get; set; }
    }
}