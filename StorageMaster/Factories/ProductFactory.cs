using StorageMaster.Model.Products;
using System;

namespace StorageMaster.Factories
{
    public class ProductFactory
    {
        public Product CreateProduct(string type, double price)
        {
            switch (type)
            {
                case "Gpu":
                    return new Gpu(price);
                case "HardDrive":
                    return new HardDrive(price);
                case "Ram":
                    return new Ram(price);
                case "SolidStateDrive":
                    return new SolidStateDrive(price);
                default: throw new InvalidOperationException("Invalid Product Type!");
            }
            /*var productType = Assembly
                .GetCallingAssembly()
                .GetTypes()
                .Where(x => !x.IsAbstract && x.Name == type)
                .FirstOrDefault();

            if (productType == null)
            {
                throw new InvalidOperationException("Invalid produvt type!");

            }
            Product product = null;

            try
            {
                product = (Product)Activator.CreateInstance(productType, price);
            }
            catch (TargetInvocationException tie)
            {
                throw new InvalidOperationException(tie.InnerException.Message);
            }
            return product;*/
        }

    }
}
