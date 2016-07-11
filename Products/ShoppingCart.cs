
namespace Cosmetics.Products
{
    using Cosmetics.Contracts;
    using System;
    using System.Collections.Generic;
    using System.Linq;

    public class ShoppingCart : IShoppingCart
    {
        private readonly List<IProduct> products;

        public ShoppingCart()
        {
            this.products = new List<IProduct>();
        }

         public void AddProduct(IProduct product)
        {

            this.products.Add(product);
        }

        public void RemoveProduct(IProduct product)
        {
            this.products.Remove(product);
        }

        public bool ContainsProduct(IProduct product)
        {
            bool containsChecker = this.products.Contains(product);
            return containsChecker;
        }

        public decimal TotalPrice()
        {
            return products.Sum(pr => pr.Price);
        }
    }
}
