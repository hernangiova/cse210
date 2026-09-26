using System;

class Program
{
    static void Main(string[] args)
    {
        Address address1 = new Address("123 Main Street", "Orem", "Utah", "USA");
        Customer customer1 = new Customer("Joseph Smith", address1);

        Product product1 = new Product("Laptop", "L451", 1000, 2);
        Product product2 = new Product("PS5", "SM839893", 999, 1);
        Product product3 = new Product("iPhone 18 Pro Max", "P83829", 1200, 1);

        Order order1 = new Order(customer1);
        order1.AddProduct(product1);
        order1.AddProduct(product2);
        order1.AddProduct(product3);


        Address address2 = new Address("10 Ave. 15 Calle", "Guatemala City", "Guatemala", "Guatemala");
        Customer customer2 = new Customer("Giovani Hernandez", address2);

        Product product4 = new Product("AirPods 5", "Y7373", 500, 1);
        Product product5 = new Product("PS4", "MN63263", 600, 1);
        Product product6 = new Product("HDMI Cable", "J828", 20, 5);

        Order order2 = new Order(customer2);
        order2.AddProduct(product4);
        order2.AddProduct(product5);
        order2.AddProduct(product6);


        Console.WriteLine("===============================================");
        Console.WriteLine("ORDER 1");
        Console.WriteLine("===============================================");

        Console.WriteLine(order1.GetPackingLabel());
        Console.WriteLine(order1.GetShippingLabel());
        Console.WriteLine($"Total Cost: ${order1.GetTotal()}");

        Console.WriteLine();

        Console.WriteLine("===============================================");
        Console.WriteLine("ORDER 2");
        Console.WriteLine("===============================================");

        Console.WriteLine(order2.GetPackingLabel());
        Console.WriteLine(order2.GetShippingLabel());
        Console.WriteLine($"Total Cost: ${order2.GetTotal()}");

        Console.WriteLine();
    }
}