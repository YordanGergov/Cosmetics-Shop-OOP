

namespace Cosmetics.Products
{
    using Cosmetics.Common;
    using Cosmetics.Contracts;
    using System;
    using System.Linq;
    using System.Text;

    public abstract class Product : MyValidator, IProduct
    {
        private string name;
        private string brand;
        private decimal price;



        public Product(string name, string brand, decimal price, GenderType gender)
        {
            this.Name = name;
            this.Brand = brand;
            this.Price = price;
            this.Gender = gender;
        }

        public string Name
        {
            get { return this.name; }
            protected set
            {

                if (string.IsNullOrEmpty(value))
                {
                    throw new ArgumentNullException("value", "Product  name cannot be null or empty");
                }

                CheckIfStringLengthIsValid(value, 10, 3, "Product name must be between 3 and 10 symbols long!");

                this.name = value;
            }
        }

        public string Brand
        {
            get { return this.brand; }

            protected set
            {
                if (string.IsNullOrEmpty(value))
                {
                    throw new ArgumentNullException("value", "Product brand cannot be null or empty");
                }

                if (value.Length < 2 || 10 < value.Length)
                {
                    throw new IndexOutOfRangeException("Product brand must be between 2 and 10 symbols long!");
                }

                this.brand = value;
            }
        }

        public decimal Price
        {
            get { return this.price; }

            protected set
            {
                this.price = value;
            }
        }

        public Common.GenderType Gender
        {
            get;
            protected set;
        }

        public virtual string Print()
        {
            var output = new StringBuilder();
            output.AppendLine(string.Format("- {0} - {1}:", this.Brand, this.Name));
            output.AppendLine(string.Format("  * Price: ${0}", this.Price));
            output.AppendLine(string.Format("  * For gender: {0}", this.Gender));

            return output.ToString().TrimEnd();
        }

    }
}
