using System;
using System.Collections.Generic;

class Program
{
    static void Main(string[] args)
    {
        // 顧客1とその住所を作成
        Customer customer1 = new Customer("Alice", new Address("123 Main St", "CityA", "StateA", "USA"));
        // 顧客2とその住所を作成
        Customer customer2 = new Customer("Bob", new Address("456 Elm St", "CityB", "StateB", "Canada"));

        // 製品を作成
        Product product1 = new Product("Product1", "P001", 10.0m, 2);
        Product product2 = new Product("Product2", "P002", 20.0m, 1);
        Product product3 = new Product("Product3", "P003", 5.0m, 5);

        // 注文1を作成し、製品を追加
        Order order1 = new Order(customer1);
        order1.AddProduct(product1);
        order1.AddProduct(product2);

        // 注文2を作成し、製品を追加
        Order order2 = new Order(customer2);
        order2.AddProduct(product2);
        order2.AddProduct(product3);

        // 注文1の情報を表示
        Console.WriteLine("Order 1:");
        Console.WriteLine(order1.GetPackingLabel());
        Console.WriteLine(order1.GetShippingLabel());
        Console.WriteLine($"Total Price: ${order1.GetTotalPrice()}\n");

        // 注文2の情報を表示
        Console.WriteLine("Order 2:");
        Console.WriteLine(order2.GetPackingLabel());
        Console.WriteLine(order2.GetShippingLabel());
        Console.WriteLine($"Total Price: ${order2.GetTotalPrice()}\n");
    }
}

// 製品クラス
class Product
{
    private string name;
    private string productId;
    private decimal price;
    private int quantity;

    // コンストラクタ：製品の名前、ID、価格、数量を設定
    public Product(string name, string productId, decimal price, int quantity)
    {
        this.name = name;
        this.productId = productId;
        this.price = price;
        this.quantity = quantity;
    }

    // 総価格を計算するメソッド
    public decimal GetTotalPrice()
    {
        return price * quantity;
    }

    // 名前のプロパティ
    public string Name
    {
        get { return name; }
    }

    // 製品IDのプロパティ
    public string ProductId
    {
        get { return productId; }
    }
}

// 顧客クラス
class Customer
{
    private string name;
    private Address address;

    // コンストラクタ：顧客の名前と住所を設定
    public Customer(string name, Address address)
    {
        this.name = name;
        this.address = address;
    }

    // 顧客がアメリカ在住かどうかを確認するメソッド
    public bool IsInUSA()
    {
        return address.IsInUSA();
    }

    // 名前のプロパティ
    public string Name
    {
        get { return name; }
    }

    // 住所のプロパティ
    public Address Address
    {
        get { return address; }
    }
}

// 住所クラス
class Address
{
    private string street;
    private string city;
    private string state;
    private string country;

    // コンストラクタ：住所の各フィールドを設定
    public Address(string street, string city, string state, string country)
    {
        this.street = street;
        this.city = city;
        this.state = state;
        this.country = country;
    }

    // 住所がアメリカにあるかどうかを確認するメソッド
    public bool IsInUSA()
    {
        return country == "USA";
    }

    // 住所を文字列として取得するメソッド
    public override string ToString()
    {
        return $"{street}\n{city}, {state}\n{country}";
    }
}

// 注文クラス
class Order
{
    private List<Product> products;
    private Customer customer;

    // コンストラクタ：顧客を設定し、製品リストを初期化
    public Order(Customer customer)
    {
        this.products = new List<Product>();
        this.customer = customer;
    }

    // 製品を追加するメソッド
    public void AddProduct(Product product)
    {
        products.Add(product);
    }

    // 総価格を計算するメソッド
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

    // パッキングラベルを取得するメソッド
    public string GetPackingLabel()
    {
        string label = "Packing Label:\n";
        foreach (var product in products)
        {
            label += $"{product.Name} ({product.ProductId})\n";
        }
        return label;
    }

    // 配送ラベルを取得するメソッド
    public string GetShippingLabel()
    {
        return $"Shipping Label:\n{customer.Name}\n{customer.Address}";
    }
}
