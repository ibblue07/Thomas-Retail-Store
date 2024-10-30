/*
    Name: Isaiah Thomas
    Date: 10/29/2024
    SDC320 Project Course Project
    Description: The IProduct class is an interface whose properties and methods are inherited by the Electronics, Food, and Clothing classes.
*/
public interface IProduct
{
    int ProductID { get; set; }
    string ProductName { get; set; }
    double Price { get; set; }
    string Type { get; set; }
    double GetPrice();
}