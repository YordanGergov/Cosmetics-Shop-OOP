

namespace Cosmetics.Products
{
    using Cosmetics.Common;
    using Cosmetics.Contracts;
    using System;
    using System.Linq;
    using System.Text;

    public class Shampoo : Product, IShampoo
    {
        private uint milliliters;
        private UsageType usage;


        public Shampoo(string name, string brand, decimal price, GenderType gender, uint milliliters, UsageType usage)
            : base(name, brand, price, gender)
        {
            this.Price = price * milliliters;
            this.Milliliters = milliliters;
            this.Usage = usage;
        }


        public uint Milliliters
        {
            get { return this.milliliters; }

            private set
            {
                this.milliliters = value;
            }
        }

        public Common.UsageType Usage
        {
            get { return this.usage; }

            private set
            {
                this.usage = value;
            }
        }

        public override string Print()
        {

            var output = new StringBuilder();
            output.AppendLine(base.Print());
            output.AppendLine(string.Format("  * Quantity: {0} ml", this.Milliliters));
            output.AppendLine(string.Format("  * Usage: {0}", this.Usage));

            return output.ToString().TrimEnd();

        }
    }
}
