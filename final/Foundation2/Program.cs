using System;

namespace ProductOrderingSystem
{
    class Program
    {
        static void Main(string[] args)
        {
            // Create customers
            Customer customer1 = new Customer("John Doe", new Address("123 Main St", "Campton", "NY", "USA"));
            Customer customer2 = new Customer("Jane Smith", new Address("456 Elm St", "Millenial", "CA", "USA"));
            Customer customer3 = new Customer("Racheal Leitz", new Address("2 Hope St", "Bridget", "EG", "EU"));
            Customer customer4 = new Customer("Alex Kim", new Address("789 Oak St, Apt. 4B", "Seoul", "", "South Korea"));
            Customer customer5 = new Customer("Maria Garcia", new Address("555 Maple Ave", "Ciudad de Mexico", "Mexico City", "Mexico"));

            // Create products
            Product[] products = {
                new Product("Stain Free Markers", "WID001", 2.50, 3),
                new Product("iPhone14", "GIZ001", 5.00, 2),
                new Product("PlayStation", "THG001", 10.00, 1),
                new Product("Laptop Bag", "ACC001", 20.00, 2),
                new Product("Wireless Headphones", "ACC002", 30.00, 1),
                new Product("Waterproof Camera", "CAM001", 40.00, 1),
                new Product("Drone", "GIZ002", 50.00, 1),
                new Product("Smart Watch", "ACC003", 60.00, 1),
                new Product("Gaming Mouse", "THG002", 70.00, 1)
            };

            // Create orders
            Order[] orders = {
                new Order(customer1, products[0], products[1], products[2]),
                new Order(customer2, products[1], products[2], products[3]),
                new Order(customer3, products[2], products[3], products[4]),
                new Order(customer4, products[3], products[4], products[5]),
                new Order(customer5, products[4], products[5], products[6])
            };

            // Display details for each order
            foreach (var order in orders)
            {
                Console.WriteLine(order.GetPackingLabel());
                Console.WriteLine(order.GetShippingLabel());
                Console.WriteLine("Total price: $" + order.CalculateTotalPrice());
                Console.WriteLine("----------");
                Console.WriteLine();
            }
        }
    }
}
