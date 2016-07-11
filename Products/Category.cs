


namespace Cosmetics.Products
{
    using Cosmetics.Contracts;
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Text;
    public class Category : MyValidator, ICategory
    {
        private string name;
        private ICollection<IProduct> cosmetics;

        public Category(string name)
        {

            this.Name = name;
            this.cosmetics = new List<IProduct>();
        }

        public string Name
        {
            get
            {
                return this.name;
            }

            private set
            {
                if (string.IsNullOrEmpty(value))
                {
                    throw new ArgumentNullException("value", "Category name cannot be null or empty");
                }

                CheckIfStringLengthIsValid(value, 15, 2, "Category name must be between 2 and 15 symbols long!");

                this.name = value;
            }
        }

        public IList<IProduct> Cosmetics
        {
            get;
            private set;
        }

        public void AddCosmetics(IProduct cosmetics)
        {
            this.cosmetics.Add(cosmetics);
        }

        public void RemoveCosmetics(IProduct cosmetics)
        {

            this.cosmetics.Remove(cosmetics);
        }

        public string Print()
        {

            var output = new StringBuilder();
            output.AppendLine(string.Format("{0} category - {1} {2} in total",
                this.Name,
                this.cosmetics.Count != 0 ? this.cosmetics.Count.ToString() : "0",
                this.cosmetics.Count != 1 ? "products" : "product"));
            //var sortedCosmetics = this.cosmetics.OrderBy(c => c.Brand).ThenByDescending(c => c.Price);
            foreach (var cosmetic in cosmetics)
            {
                output.AppendLine(cosmetic.Print());
            }

            return output.ToString().TrimEnd();
        }

    }
}
