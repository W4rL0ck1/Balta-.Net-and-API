using BaltaStore.Shared.Entities;
using FluentValidator;
using System;

namespace BaltaStore.Domain.StoreContext.Entities
{
    public class Product : Entity
    {
        public Product(string title, string description, string image, decimal price, decimal quatityOnHand)
        {
            Title = title;
            Description = description;
            Image = image;
            Price = price;
            QuatityOnHand = quatityOnHand;
        }

        public string Title { get; private set; }       
        public string Description { get; private set; }
        public string Image { get; private set; }
        public decimal Price { get; private set; }        
        public decimal QuatityOnHand { get; private set; }

        public override string ToString()
        {
            return Title;
        }
    }
}