public class Clothing : IProduct
{
    public int ProductID { get; set; }
    public string ProductName { get; set; }
    public double Price { get; set; }
    public string Type { get; set; }
    public string Color { get; set; }
    public string Size { get; set; }

    public Clothing(int id, string name, double price, string type, string color, string size)
    {
        ProductID = id;
        ProductName = name;
        Price = price;
        Type = type;
        Color = color;
        Size = size;
    }

    public double GetPrice()
    {
        return Price;
    }
}