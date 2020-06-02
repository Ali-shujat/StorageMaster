using StorageMaster.IO.Contracts;
using System;
using System.Collections.Generic;

namespace StorageMaster.Core
{
    public class Engine
    {
        private const string EndCommand = "END";
        private readonly StorageMaster storageMaster;
        private readonly IReader dataReader;
        private readonly IWriter dataWriter;

        public Engine(IReader dataReader, IWriter dataWriter)
        {
            this.storageMaster = new StorageMaster();
            this.dataReader = dataReader;
            this.dataWriter = dataWriter;
        }

        public void Run()
        {
            // var commands = new List<string>();
            var input = this.dataReader.ReadLine();
            var command = input.Split();
            do
            {
                if (command[0] == "RegisterStorage")
                {
                    var product = this.storageMaster.RegisterStorage(command[1], (command[2]));
                    this.dataWriter.WriteLine(product);
                    break;
                }
                if (command[0] == "AddProduct")
                {
                    var product = this.storageMaster.AddProduct(command[1], double.Parse(command[2]));
                    this.dataWriter.WriteLine(product);
                }
                if (command[0] == "SelectVehicle")
                {
                    var product = this.storageMaster.SelectVehicle(command[1], int.Parse(command[2]));
                    this.dataWriter.WriteLine(product);
                }
                if (command[0] == "SendVehicleTo")
                {
                    var product = this.storageMaster.SendVehicleTo(command[1], int.Parse(command[2]), command[3]);
                    this.dataWriter.WriteLine(product);
                }
                if (command[0] == "UnloadVehicle")
                {
                    var product = this.storageMaster.UnloadVehicle(command[1], int.Parse(command[2]));
                    this.dataWriter.WriteLine(product);
                }
                if (command[0] == "LoadVehicle")
                {
                    var products = new List<String>();
                    for (int i = 1; i < command.Length; i++)
                    {
                        products.Add(command[i]);
                    }
                    var product = this.storageMaster.LoadVehicle(products);
                    this.dataWriter.WriteLine(product);
                }
            } while (command[0] != EndCommand);
        }
    }
}
