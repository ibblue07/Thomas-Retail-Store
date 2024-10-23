/*
    Name: Isaiah Thomas
    Date: 10/19/2024
    SDC320 Project Class Implementation
    Description: The ShoppingCart class stores a list of all the Products in the Customer's cart.
*/
public class ShoppingCart : ShoppingCartBase
{
    // Define the properties
    private List<IProduct> products;   
    private int nextProductID = 1;
    
    public ShoppingCart()
    {
        products = new List<IProduct>();
    }

    public override void AddProduct()
    {
        // Product category selection
        Console.WriteLine("Select a category.");
        Console.WriteLine
        (
            "\n1. Electronics" +
            "\n2. Food" +
            "\n3. Clothing"
        );

        int category = Convert.ToInt32(Console.ReadLine());
        
        //Define user input variables
        string productName;
        double price;
        string type;
        string color;
        string size;
        
        // Input validation for product information
        switch (category)
        {
            case 1: // Electronics
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
                Console.WriteLine();

                nextProductID++;
                break;
            case 2: // Food
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
                Console.WriteLine();

                nextProductID++;
                break;
            case 3: // Clothing
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
                Console.WriteLine();

                nextProductID++;
                break;
            default:
                Console.WriteLine("Invalid choice. Try again.");
                break;
        }
    }

    public override void GetProducts()
    {
        // Checks if there are any products in the cart
        if (products.Any())
        {
            foreach (var product in products)
            {
                Console.WriteLine(product.ToString());
                Console.WriteLine();
            }
        }
        else
        {
            Console.WriteLine("Your cart is empty.");
        }
    }

    public void Checkout()
    {
        // Checks if there are products in the cart
        if (products.Count == 0)
        {
            Console.WriteLine("Your cart is empty");
        }
        else // Calculate the total price of all products
        {
            double totalPrice = products.Sum(product => product.GetPrice());

            foreach (var product in products)
            {
                Console.WriteLine(product.ToString());
                Console.WriteLine();
            }
            Console.WriteLine($"Total price: {totalPrice}");
            Console.WriteLine();
            
            Console.WriteLine("Would you like to purchase the following item(s)? (Y/N)");
            string choice = Console.ReadLine();
            if (choice == "Y")
            {
                Console.WriteLine("Thank you for your purchase!");
            }
            else if (choice == "N")
            {
                Console.WriteLine("Your purchase has been cancelled.");
            }
        }
    }

    public override void UpdateProduct()
    {
        if (products.Count == 0)
        {
            Console.WriteLine("Thare are no products in your cart to update.");
            return;
        }

        // Displays the current products in cart
        Console.WriteLine("Current products in cart:");
        foreach (var product in products)
        {
            Console.WriteLine(product.ToString());
            Console.WriteLine();
        }

        // Prompts the user to enter the name of the product they want to update
        Console.Write("Enter the name of the product you want to update: ");
        string productNameToUpdate = Console.ReadLine().Trim().ToLower();

        IProduct productToUpdate = products.FirstOrDefault(p => p.ProductName.Equals(productNameToUpdate, StringComparison.OrdinalIgnoreCase));

        //Check if product is found.
        var matchingProducts = products.Where(p => p.ProductName.ToLower().Contains(productNameToUpdate)).ToList();

        if (matchingProducts.Count == 0)
        {
            Console.WriteLine("No products found matching your search.");
            return;
        }
        else if (matchingProducts.Count > 1)
        {
            Console.WriteLine("Multiple products found. Please choose one:");
            for (int i = 0; i < matchingProducts.Count; i++)
            {
                Console.WriteLine($"{i + 1}. {matchingProducts[i].ProductName}");
            }
            Console.Write("Enter the number of the product you want to update: ");
            if (!int.TryParse(Console.ReadLine(), out int choice) || choice < 1 || choice > matchingProducts.Count)
            {
                Console.WriteLine("Invalid choice. Update cancelled.");
                return;
            }
            productToUpdate = matchingProducts[choice - 1];
        }
        else
        {
            productToUpdate = matchingProducts[0];
        }
        
        // Input validation for updated product information
        if (productToUpdate != null)
        {
            Console.Write("Enter the new Product Name (leave blank to keep current): ");
            string newProductName = Console.ReadLine();
            if (!string.IsNullOrWhiteSpace(newProductName))
            {
                productToUpdate.ProductName = newProductName;
            }
            else
            {
                Console.WriteLine("Invalid input.");
            }

            Console.Write("Enter the new Price (leave blank to keep current): ");
            string newPriceString = Console.ReadLine();
            double newPrice;
            if (double.TryParse(newPriceString, out newPrice) && newPrice > 0)
            {
                productToUpdate.Price = newPrice;
            }
            else
            {
                Console.WriteLine("Invalid input.");
            }
            

            Console.WriteLine("Enter the new Type (leave blank to keep current): ");
            string newType = Console.ReadLine();
            if (!string.IsNullOrWhiteSpace(newType))
            {
                productToUpdate.Type = newType;
            }
            else
            {
                Console.WriteLine("Invalid input.");
            }

            if (productToUpdate is Clothing clothing)
            {
                Console.Write("Enter the new Color (leave blank to keep current): ");
                string newColor = Console.ReadLine();
                if (!string.IsNullOrWhiteSpace(newColor))
                {
                    clothing.Color = newColor;
                }
                else
                {
                    Console.WriteLine("Invalid input.");
                }   

                Console.WriteLine("Enter the new Size (leave blank to keep current): ");
                string newSize = Console.ReadLine();
                if (!string.IsNullOrWhiteSpace(newSize))
                {
                    clothing.Size = newSize;
                }
                else
                {
                    Console.WriteLine("Invalid input.");
                }
            }

            Console.WriteLine("\nProduct has been successfully updated.");
            // Print updated product info
            Console.WriteLine("\nUpdated Product Details:");
            Console.WriteLine(productToUpdate.ToString());
            Console.WriteLine();
        }
        else
        {
            Console.WriteLine("There are no products in your cart to update");
        }
    }

    public override void RemoveProduct()
    {
        // Check if the cart has any products
        if (products.Count == 0)
        {
            Console.WriteLine("There are no products in your cart to remove.");
            return;
        }

        // Display product list
        Console.WriteLine("Products in cart:");
        GetProducts();
        Console.WriteLine();

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