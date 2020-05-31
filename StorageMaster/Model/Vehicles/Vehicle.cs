using StorageMaster.Model.Products;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace StorageMaster.Model.Vehicles
{
    public abstract class Vehicle
    {


        private readonly List<Product> trunk;

        protected Vehicle(int capacity)
        {
            this.Capacity = capacity;
            this.trunk = new List<Product>();

        }
        public int Capacity { get; private set; }

        public IReadOnlyCollection<Product> Trunk
            => this.trunk.AsReadOnly();

        public bool IsFull
        {
            get
            {
                return this.Trunk.Sum(p => p.Weight) >= this.Capacity;
            }
        }

        public bool IsEmpty
        {
            get
            {
                return this.trunk.Count == 0;
            }
        }

        public void LoadProduct(Product product)
        {
            if (this.IsFull)
            {
                throw new ArgumentException(" vehicle is full!");
            }

            this.trunk.Add(product);
        }

        public Product Unload()
        {
            if (this.IsEmpty)
            {
                throw new ArgumentException(" No products left in vehicle");
            }
            var lastProductIndex = this.trunk.Count - 1;
            var product = this.trunk[lastProductIndex];
            this.trunk.RemoveAt(lastProductIndex);
            return product;
        }

    }

}


