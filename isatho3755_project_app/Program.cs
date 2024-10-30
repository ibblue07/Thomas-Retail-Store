/*
    Name: Isaiah Thomas
    Date: 10/29/2024
    SDC320 Project Course Project
    Description: The main Program class.
*/
using System.Data.SQLite;

public class Program : ShoppingCart
{
    public const string dbName = "IsaiahThomas.db";
    public static SQLiteConnection conn;
    public static Customer customer;

    public static void Main()
    {
        conn = SQLiteDatabase.Connect(dbName);
        if (conn != null)
        {
            ProductDB.CreateTable(conn);
            CustomerDB.CreateTable(conn);
            CustomerDB.AddCustomer(conn, new Customer("Isaiah", "Thomas", "123 Main Street", "isatho3755@students.ecpi.edu", 7026952744));
        }
        customer = new Customer(1, "Isaiah", "Thomas", "123 Main Street", "isatho3755@students.ecpi.edu", 7026952744);
        ShoppingCart cart = new ShoppingCart();
        
        
        int choice;
        do 
        {
            Console.WriteLine("Welcome to Isaiah's Retail Store System");
            Console.WriteLine
            (
                "\n1. Add Product" +
                "\n2. View Products" +
                "\n3. Update Product" +
                "\n4. Delete Product" +
                "\n5. View Customer Info" +
                "\n6. Update Customer Info" +
                "\n7. Checkout" +
                "\n8. Exit"
            );

            if (int.TryParse(Console.ReadLine(), out choice))
            {
                switch (choice)
                {
                    case 1:
                        cart.AddProduct();
                        break;
                    case 2:
                        cart.GetProducts();
                        break;
                    case 3:
                        cart.UpdateProduct();
                        break;
                    case 4:
                        cart.RemoveProduct();
                        break;
                    case 5:
                        customer.GetCustomerInfo();
                        break;
                    case 6:
                        customer.UpdateCustomerInfo(customer);
                        break;
                    case 7:
                        cart.Checkout();
                        break;
                    case 8:
                        Console.WriteLine("Exiting program.");
                        break;
                    default:
                        Console.WriteLine("Invalid option. Try again");
                        break;
                }
            }
            else
            {
                Console.WriteLine("Invalid input. Please enter a number.");
                choice = 0;
            }
        } while (choice != 8);
    }
    
    public static void PrintProducts(List<IProduct> products)
    {
        foreach (IProduct p in products)
        {
            PrintProduct(p);
        }
    }

    public static void PrintProduct(IProduct p)
    {
        if (p is Clothing clothing)
        {
            Console.WriteLine("Product " + clothing.ProductID + ": ");
            Console.WriteLine("Name: " + clothing.ProductName + "\nPrice: " + clothing.Price
            + "\nType: " + clothing.Type + "\nColor: " + clothing.Color + "\n");
        }
        else
        {
            Console.WriteLine("Product " + p.ProductID + ": ");
            Console.WriteLine("Name: " + p.ProductName + "\nPrice: " + p.Price
            + "\nType: " + p.Type + "\n");
        }
    }

    public static void PrintCustomers(List<Customer> customers)
    {
        foreach (Customer c in customers)
        {
            PrintCustomer(c);
        }
    }

    public static void PrintCustomer(Customer c)
    {
        Console.WriteLine("Customer " + c.CustomerID + ": ");
        Console.WriteLine("Name: " + c.FirstName + " " + c.LastName);
        Console.WriteLine("Address: " + c.Address);
        Console.WriteLine("Email: " + c.Email);
        Console.WriteLine("Phone Number: " + c.PhoneNumber);
    }
}

