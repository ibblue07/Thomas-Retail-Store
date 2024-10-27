/*
    Name: Isaiah Thomas
    Date: 10/27/2024
    SDC320 Project Database Implementation
    Description: The Electronics class is derived from the IProduct interface class.
*/
public class Electronics : IProduct
{
    // Define the properties
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

    public Electronics(string name, double price, string type)
    {
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
        return $"Name: {ProductName}\nPrice: {Price}\nType: {Type}"; 
    }
}