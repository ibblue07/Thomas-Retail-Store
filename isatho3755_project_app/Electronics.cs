public class Electronics : IProduct
{
    public int ProductID { get; set; }
    public string ProductName { get; set; }
    public double Price { get; set; }
    public string Type { get; set; }

    public Electronics(int id, string name, double price, string type)
    {
        ProductID = id;
        ProductName = name;
        Price = price;
        Type = type;
    }

    public double GetPrice()
    {
        return Price;
    }
}