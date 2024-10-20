/*
    Name: Isaiah Thomas
    Date: 10/19/2024
    SDC320 Project Class Implementation
    Description: The ShoppingCart class stores a list of all the Products in the Customer's cart.
*/
public class ShoppingCart
{
    private List<IProduct> products;   
    private int nextProductID = 1;
    
    public ShoppingCart()
    {
        products = new List<IProduct>();
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
        
        //Define user input
        string productName;
        double price;
        string type;
        string color;
        string size;
        
        //Prompt the user to enter product information
        switch (category)
        {
            case 1:
                Console.WriteLine("Enter the name:");
                productName = Console.ReadLine();

                Console.WriteLine("Enter the price:");
                price = Convert.ToDouble(Console.ReadLine());

                Console.WriteLine("Enter the type:");
                type = Console.ReadLine();

                products.Add(new Electronics(nextProductID, productName, price, type));
                
                Console.WriteLine("Product added");
                Console.WriteLine("\nProduct Details:");
                GetProducts();
                nextProductID++;
                break;
            case 2:
                Console.WriteLine("Enter the name:");
                productName = Console.ReadLine();

                Console.WriteLine("Enter the price:");
                price = Convert.ToDouble(Console.ReadLine());

                Console.WriteLine("Enter the type:");
                type = Console.ReadLine();
                
                products.Add(new Food(nextProductID, productName, price, type));
                
                Console.WriteLine("Product added");
                Console.WriteLine("\nProduct Details:");
                GetProducts();
                nextProductID++;
                break;
            case 3:
                Console.WriteLine("Enter the name:");
                productName = Console.ReadLine();

                Console.WriteLine("Enter the price:");
                price = Convert.ToDouble(Console.ReadLine());

                Console.WriteLine("Enter the type:");
                type = Console.ReadLine();

                Console.WriteLine("Enter the color:");
                color = Console.ReadLine();

                Console.WriteLine("Enter the size:");
                size = Console.ReadLine();
                
                products.Add(new Clothing(nextProductID, productName, price, type, color, size));
                
                Console.WriteLine("Product added");
                Console.WriteLine("\nProduct Details:");
                GetProducts();
                nextProductID++;
                break;
            default:
                Console.WriteLine("Invalid choice. Try again.");
                break;
        }
    }

    public void GetProducts()
    {
        Console.WriteLine("Products in cart:");

        // Using a foreach loop to handle the case when the list is empty
        if (products.Any())
        {
            foreach (var product in products)
            {
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
        if (products.Count == 0)
        {
            Console.WriteLine("Thare are no products in your cart to update.");
            return;
        }

        // Display current products
        Console.WriteLine("Current products in cart:");
        foreach (var product in products)
        {
            Console.WriteLine(product.ToString());
        }

        Console.Write("Enter the name of the product you want to update: ");
        string productNameToUpdate = Console.ReadLine();

        IProduct productToUpdate = products.FirstOrDefault(p => p.ProductName.Equals(productNameToUpdate, StringComparison.OrdinalIgnoreCase));
        if (productToUpdate != null)
        {
            Console.Write("Enter the new Product Name (leave blank to keep current): ");
            string newProductName = Console.ReadLine();
            if (!string.IsNullOrWhiteSpace(newProductName))
            {
                productToUpdate.ProductName = newProductName;
            }

            Console.Write("Enter the new Price (leave blank to keep current): ");
            double newPrice = Convert.ToDouble(Console.ReadLine());
            if (newPrice > 0)
            {
                productToUpdate.Price = newPrice;
            }

            Console.WriteLine("Enter the new Type (leave blank to keep current): ");
            string newType = Console.ReadLine();
            if (!string.IsNullOrWhiteSpace(newType))
            {
                productToUpdate.Type = newType;
            }

            if (productToUpdate is Clothing clothing)
            {
                Console.Write("Enter the new Color (leave blank to keep current): ");
                string newColor = Console.ReadLine();
                if (!string.IsNullOrWhiteSpace(newColor))
                {
                    clothing.Color = newColor;
                }

                Console.WriteLine("Enter the new Size (leave blank to keep current): ");
                string newSize = Console.ReadLine();
                if (!string.IsNullOrWhiteSpace(newSize))
                {
                    clothing.Size = newSize;
                }
            }
            Console.WriteLine("\nProduct has been successfully updated.");
            Console.WriteLine("\nUpdated Product Details:");
            GetProducts();
        }
        else
        {
            Console.WriteLine("There are no products in your cart to update");
        }
    }
    public void RemoveProduct()
    {
        if (products.Count == 0)
        {
            Console.WriteLine("There are no products in your cart to remove.");
            return;
        }

        Console.WriteLine("Products in cart:");
        for (int i = 0; i < products.Count; i++)
        {
            Console.WriteLine($"{i + 1}. {products[i].ProductName} - ${products[i].Price}");
        }

        Console.WriteLine("\nEnter the number of the product you want to remove (or 0 to cancel):");
        if (int.TryParse(Console.ReadLine(), out int choice) && choice > 0 && choice <= products.Count)
        {
            IProduct removedProduct = products[choice - 1];
            products.RemoveAt(choice - 1);
            Console.WriteLine($"Removed {removedProduct.ProductName} from your cart.");
        }
        else if (choice == 0)
        {
            Console.WriteLine("Removal cancelled.");
        }
        else
        {
            Console.WriteLine("Invalid choice. No products were removed.");
        }
    }   
}