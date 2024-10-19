public class Food : IProduct
{
    public int ProductID { get; set; }
    public string ProductName { get; set; }
    public double Price { get; set; }
    public string Type { get; set; }

    public Food(int id, string name, double price, string type)
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

    public override string ToString()
    {
        return $"Name: {ProductName}, Price: {Price}, Type: {Type}"; 
    }
}