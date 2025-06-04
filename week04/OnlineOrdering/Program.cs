using System;

namespace OnlineOrdering
{
    class Program
    {
        static void Main(string[] args)
        {
           
            var address1 = new Address("Maria Teresa 19", "Santa Lucia", "San Juan", "Argentina");
            var customer1 = new Customer("Yair Fonzalida", address1);

            var order1 = new Order(customer1);
            order1.AddProduct(new Product("Widget A", "W123", 3.50m, 5));    
            order1.AddProduct(new Product("Gadget B", "G789", 12.00m, 2));   
            order1.AddProduct(new Product("Thingamajig", "T555", 5.25m, 1)); 

            
            var address2 = new Address("Pellegrini 7500 Este", "Rivadavia", "XX", "Brasil");
            var customer2 = new Customer("Maxima Duran", address2);

            var order2 = new Order(customer2);
            order2.AddProduct(new Product("Book X", "B321", 15.00m, 1));    
            order2.AddProduct(new Product("Pen Set", "P111", 2.00m, 10));   

            
            PrintOrderSummary(order1);
            Console.WriteLine();

            
            PrintOrderSummary(order2);

            Console.WriteLine("\nPress any key to exit...");
            Console.ReadKey();
        }

        static void PrintOrderSummary(Order order)
        {
            Console.WriteLine("======================================");
            Console.WriteLine($"Customer: {order.Customer.Name}");
            Console.WriteLine("----- Shipping Label -----");
            Console.WriteLine(order.GetShippingLabel());
            Console.WriteLine();
            Console.WriteLine("----- Packing Label -----");
            Console.Write(order.GetPackingLabel());
            Console.WriteLine($"Total (including shipping): ${order.CalculateTotalCost():0.00}");
        }
    }
}
