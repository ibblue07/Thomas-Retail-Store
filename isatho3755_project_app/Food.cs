/*
    Name: Isaiah Thomas
    Date: 10/29/2024
    SDC320 Project Course Project
    Description: The Food class is derived from the IProduct interface class.
*/
public class Food : IProduct
{
    // Define the properties
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

    public Food(string name, double price, string type)
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