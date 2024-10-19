public class Customer
{
    public int CustomerID { get; set; }
    public string FirstName { get; set; }
    public string LastName { get; set; }
    public string Address { get; set; }
    public string Email { get; set; }
    public long PhoneNumber { get; set; }
    
    public Customer(int ID, string firstName, string lastName, 
    string address, string email, long phoneNumber)
    {
        CustomerID = ID;
        FirstName = firstName;
        LastName = lastName;
        Address = address;
        Email = email;
        PhoneNumber = phoneNumber;
    }

    public void GetCustomerInfo()
    {
        Console.WriteLine(
        $"Name: {FirstName} {LastName}" +
        $"\nAddress: {Address}" +
        $"\nEmail: {Email}" +
        $"\nPhone Number: {PhoneNumber}"
        );
    }

    public void UpdateCustomerInfo()
    { 
        Console.WriteLine("Update Customer Information");
        
        Console.Write("Enter new First Name (leave blank to keep current): ");
        string firstNameInput = Console.ReadLine();
        if (!string.IsNullOrWhiteSpace(firstNameInput))
        {
            FirstName = firstNameInput;
        }

        Console.Write("Enter new Last Name (leave blank to keep current): ");
        string lastNameInput = Console.ReadLine();
        if (!string.IsNullOrWhiteSpace(lastNameInput))
        {
            LastName = lastNameInput;
        }

        Console.Write("Enter new Address (leave blank to keep current): ");
        string addressInput = Console.ReadLine();
        if (!string.IsNullOrWhiteSpace(addressInput))
        {
            Address = addressInput;
        }

        Console.Write("Enter new Email (leave blank to keep current): ");
        string emailInput = Console.ReadLine();
        if (!string.IsNullOrWhiteSpace(emailInput))
        {
            Email = emailInput;
        }

        Console.Write("Enter new Phone Number (leave blank to keep current): ");
        string phoneInput = Console.ReadLine();
        if (!string.IsNullOrWhiteSpace(phoneInput) && long.TryParse(phoneInput, out long phoneNumber))
        {
            PhoneNumber = phoneNumber;
        }

        Console.WriteLine("Customer information updated successfully.");
    }
}