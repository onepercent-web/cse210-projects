using System;
using System.Collections.Generic;

class Program
{
    static void Main(string[] args)
    {
        // Create Customer and Product objects.

        // Create customer 1 and their address
        Customer customer1 = new Customer("Logan White", new Address("108 Blue St", "Sacramento", "CA", "USA"));
        // Create customer 2 and their address
        Customer customer2 = new Customer("Daniel Green", new Address("321  Spring St", "Greenwich", "LON", "UK"));
        // Create customer 3 and their address
        Customer customer3 = new Customer("Lucas Taylor", new Address("456 Silver St", "Frankfort", "KY", "USA"));
        // Create customer 4 and their address
        Customer customer4 = new Customer("Ruby King", new Address("113  Stone St", "Salt Lake", "UT", "USA"));
         // Create customer 5 and their address
        Customer customer5 = new Customer("Yamada toyota", new Address("710 Haru St", "Fussa", "TOKYO", "JAPAN"));

        // Create Product
        Product product1 = new Product("Notebook", "371A", 3.24m, 2);
        Product product2 = new Product("Earphone", "810N", 129.50m, 1);
        Product product3 = new Product("Jacket", "569Z", 43.17m, 1);
        Product product4 = new Product("Hoodie", "550J", 47.48m, 1);
        Product product5 = new Product("Ballpoint Pen", "186Y", 1.29m, 3);

        // Create Order objects, adding products and setting customers.

        // Create Order 1 and add product
        Order order1 = new Order(customer1);
        order1.AddProduct(product1);
        order1.AddProduct(product2);
        order1.AddProduct(product5);

        // Create Order 2 and add product
        Order order2 = new Order(customer2);
        order2.AddProduct(product2);
        order2.AddProduct(product4);

        // Create Order 3 and add product
        Order order3 = new Order(customer3);
        order3.AddProduct(product1);
        order3.AddProduct(product3);
        order3.AddProduct(product4);

        // Create Order 4 and add product
        Order order4 = new Order(customer4);
        order4.AddProduct(product1);
        order4.AddProduct(product2);
        order4.AddProduct(product4);
        order4.AddProduct(product5);

        // Create Order 5 and add product
        Order order5 = new Order(customer5);
        order5.AddProduct(product2);
        order5.AddProduct(product3);
        order5.AddProduct(product4);


        // Display packing label, shipping label, and total price for each order.

        // Display Order 1 information
        Console.WriteLine("Order 1:");
        Console.WriteLine($"Order 1 Total Cost: ${order1.GetTotalPrice()}");
        Console.WriteLine(order1.GetPackingLabel());
        Console.WriteLine(order1.GetShippingLabel());
        Console.WriteLine();

        // Display Order 2 information
        Console.WriteLine("Order 2:");
        Console.WriteLine($"Order 2 Total Cost: ${order2.GetTotalPrice()}");
        Console.WriteLine(order2.GetPackingLabel());
        Console.WriteLine(order2.GetShippingLabel());
        Console.WriteLine();

        // Display Order 3 information
        Console.WriteLine("Order 3:");
        Console.WriteLine($"Order 3 Total Cost: ${order3.GetTotalPrice()}");
        Console.WriteLine(order3.GetPackingLabel());
        Console.WriteLine(order3.GetShippingLabel());
        Console.WriteLine();

        // Display Order 4 information
        Console.WriteLine("Order 4:");
        Console.WriteLine($"Order 4 Total Cost: ${order4.GetTotalPrice()}");
        Console.WriteLine(order4.GetPackingLabel());
        Console.WriteLine(order4.GetShippingLabel());
        Console.WriteLine();

        // Display Order 5 information
        Console.WriteLine("Order 5:");
        Console.WriteLine($"Order 5 Total Cost: ${order5.GetTotalPrice()}");
        Console.WriteLine(order5.GetPackingLabel());
        Console.WriteLine(order5.GetShippingLabel());
        Console.WriteLine();
    }
}

// Product: class
class Product
{
    // Attributes: Name (string), ProductId (string), Price (decimal), Quantity (int)
    private string name;
    private string productId;
    private decimal price;
    private int quantity;

    // Method: Product(string name, string productId, decimal price, int quantity)
    // Constructor: Set product name, ID, price, quantity
    public Product(string name, string productId, decimal price, int quantity)
    {
        this.name = name;
        this.productId = productId;
        this.price = price;
        this.quantity = quantity;
    }

    // Method: GetTotalPrice() decimal
    // Method to calculate total price
    public decimal GetTotalPrice()
    {
        return price * quantity;
    }

    // Name Property
    public string Name
    {
        get { return name; }
    }

    // Product ID Property
    public string ProductId
    {
        get { return productId; }
    }
}

// Customer: class
class Customer
{
    // Attributes: Name (string), Address (Address)
    private string name;
    private Address address;

    // Method: Customer(string name, Address address)
    // Constructor: Set customer name and address
    public Customer(string name, Address address)
    {
        this.name = name;
        this.address = address;
    }

    // Method: IsInUSA() bool
    // Methods to check if a customer resides in the United States
    public bool IsInUSA()
    {
        return address.IsInUSA();
    }

    // Name Property
    public string Name
    {
        get { return name; }
    }

    // Address Property
    public Address Address
    {
        get { return address; }
    }
}

// Address: class
class Address
{
    // Attributes: Street (string), City (string), State (string), Country (string)
    private string street;
    private string city;
    private string state;
    private string country;

    // Method: Address(string street, string city, string state, string country)
    // Constructor: Set each field of the address
    public Address(string street, string city, string state, string country)
    {
        this.street = street;
        this.city = city;
        this.state = state;
        this.country = country;
    }

    // Method: IsInUSA() bool
    // Methods to check if a customer resides in the United States
    public bool IsInUSA()
    {
        return country == "USA";
    }

    // Method: ToString() string
    // Method to get an address as a string
    public override string ToString()
    {
        return $"{street}\n{city}, {state}\n{country}";
    }
}

// Order: class
class Order
{
    // Attributes: Products (List<Product>), Customer (Customer)
    private List<Product> products;
    private Customer customer;

    // Method: Order(Customer customer)
    // Constructor: Sets customer and initializes product list
    public Order(Customer customer)
    {
        this.products = new List<Product>();
        this.customer = customer;
    }

    // Method: AddProduct(Product product) void
    // Methods to add products
    public void AddProduct(Product product)
    {
        products.Add(product);
    }

    // Method: GetTotalPrice() decimal
    // Method to calculate total price
    public decimal GetTotalPrice()
    {
        decimal total = 0;
        foreach (var product in products)
        {
            total += product.GetTotalPrice();
        }
        total += customer.IsInUSA() ? 5 : 35;
        return total;
    }

    // Method: GetPackingLabel() string
    // Method to get packing labels
    public string GetPackingLabel()
    {
        string label = "Packing Label\n================\n";
        foreach (var product in products)
        {
            label += $"{product.ProductId} - {product.Name}\n";
        }
        return label;
    }

    // Method: GetShippingLabel() string
    // Methods to get shipping labels
    public string GetShippingLabel()
    {
        return $"Shipping Label\n================\n{customer.Name}\n{customer.Address}";
    }
}
