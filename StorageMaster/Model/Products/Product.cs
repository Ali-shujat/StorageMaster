using System;

namespace StorageMaster.Model.Products
{
    public abstract class Product
    {
        public double price { get; private set; }
        public double weight { get; private set; }
        protected Product(double price, double weight)
        {
            this.Price = price;
            this.Weight = weight;
        }

        public double Price
        {
            get
            {
                return this.price;
            }
            set
            {
                if (value < 0)
                {
                    throw new InvalidOperationException("Price cannot be negative");
                }
                this.price = value;
            }

        }
        public double Weight
        {
            get
            {
                return this.weight;
            }
            set
            {

                this.weight = value;
            }

        }
    }
}
