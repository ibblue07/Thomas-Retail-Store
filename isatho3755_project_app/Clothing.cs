/*
    Name: Isaiah Thomas
    Date: 10/19/2024
    SDC320 Project Class Implementation
    Description: The Clothing class is derived from the IProduct interface class.
*/
public class Clothing : IProduct
{
    // Define the properties
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

    public override string ToString()
    {
        return $"Name: {ProductName}\nPrice: {Price}\nType: {Type}" +
        $"Color: {Color}\nSize: {Size}"; 
    }
}