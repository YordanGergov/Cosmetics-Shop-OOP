namespace Cosmetics.Products
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Text;
    using Cosmetics.Common;
    using Cosmetics.Contracts;

    public class Toothpaste : Product, IToothpaste
    {
        private readonly IList<string> ingredients;
        private const int MinLengthIngredient = 4;
        private const int MaxLengthIngredient = 12;

        public Toothpaste(string name, string brand, decimal price, GenderType gender, IList<string> ingredients)
            : base(name, brand, price, gender)
        {
            this.ValidateIngredients(ingredients);
            this.ingredients = ingredients;
        }

        public string Ingredients
        {
            get
            {
                return string.Join(", ", this.ingredients);
            }
        }

        public override string Print()
        {
            var output = new StringBuilder();
            output.AppendLine(base.Print());

            output.AppendLine(string.Format("  * Ingredients: {0}", this.Ingredients));

            return output.ToString().TrimEnd();
        }

        private void ValidateIngredients(IList<string> ingredients)
        {
            if (ingredients.Any(i => i.Length < MinLengthIngredient || i.Length > MaxLengthIngredient))
            {
                throw new IndexOutOfRangeException(string.Format(GlobalErrorMessages.InvalidStringLength, "Each ingredient", MinLengthIngredient, MaxLengthIngredient));
            }
        }
    }
}

