interface IProduct
{
    int ProductID { get; set; }
    string ProductName { get; set; }
    double Price { get; set; }
    string Type { get; set; }
    double GetPrice();
}