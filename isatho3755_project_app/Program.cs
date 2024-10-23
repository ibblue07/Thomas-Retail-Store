/*
    Name: Isaiah Thomas
    Date: 10/19/2024
    SDC320 Project Class Implementation
    Description: The main Program class.
*/
public abstract class Program : ShoppingCart
{
    
    public static void Main()
    {
        Customer customer = new Customer(1, "Isaiah", "Thomas", "123 Main Street", "isatho3755@students.ecpi.edu", 7026952744);
        ShoppingCart cart = new ShoppingCart();
        
        int choice;
        do 
        {
            Console.WriteLine
            (
                "1. Add Product" +
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
                        customer.UpdateCustomerInfo();
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
}
