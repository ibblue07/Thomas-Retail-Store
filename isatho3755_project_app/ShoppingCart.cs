public class ShoppingCart
{
    private List<IProduct> products = new List<IProduct>();   
    
    public ShoppingCart()
    {
    }

    public void AddProduct()
    {
        Console.WriteLine("Select a category.");
        Console.WriteLine
        (
            "\n1. Electronics" +
            "\n2. Food" +
            "\n3. Clothing"
        );

        int category = Convert.ToInt32(Console.ReadLine());
        
        switch (category)
        {
            case 1:
                products.Add(new Electronics(1, "Alienware M18", 599.99, "Laptop"));
                Console.WriteLine("Product added");
                break;
            case 2:
                products.Add(new Food(1, "Apple", 4.99, "Fruit"));
                Console.WriteLine("Product added");
                break;
            case 3:
                products.Add(new Clothing(1, "Cambridge Vee", 99.99, "Shirt", "Blue", "Large"));
                Console.WriteLine("Product added");
                break;
            default:
                Console.WriteLine("Invalid choice. Try again.");
                break;
        }
        Program.Main();
    }

    public void GetProducts()
    {
        Console.WriteLine("Your shopping cart:");

        // Using a foreach loop to handle the case when the list is empty
        if (products.Any())
        {
            foreach (var product in products)
            {
                Console.WriteLine("\nProduct Details:");
                Console.WriteLine(product.ToString());
            }
        }
        else
        {
            Console.WriteLine("Your cart is empty.");
        }
    }
    public void UpdateProduct()
    {
        Console.WriteLine("There is only one product here. This functionality will be implemented later so that the user can update each of their products accordingly.");
    }
    public void RemoveProduct()
    {
        Console.WriteLine("This functionality will be implemented later.");
    }   
}