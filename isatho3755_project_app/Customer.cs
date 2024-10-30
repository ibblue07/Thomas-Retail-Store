/*
    Name: Isaiah Thomas
    Date: 10/29/2024
    SDC320 Course Project
    Description: The Customer class stores all of the customer properties and get & update methods.
*/
public class Customer
{
    // Define the properties
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

    public Customer(string firstName, string lastName, 
    string address, string email, long phoneNumber)
    {
        FirstName = firstName;
        LastName = lastName;
        Address = address;
        Email = email;
        PhoneNumber = phoneNumber;
    }

    public void GetCustomerInfo()
    {
        Console.WriteLine
        (
        $"Name: {FirstName} {LastName}" +
        $"\nAddress: {Address}" +
        $"\nEmail: {Email}" +
        $"\nPhone Number: {PhoneNumber}"
        );
        Console.WriteLine();
        
        Console.WriteLine("Customers printed from Customer table:");
        //Print from Customers table
        if (Program.conn != null)
        {
            Program.PrintCustomers(CustomerDB.GetAllCustomers(Program.conn));
        }
    }

    public void UpdateCustomerInfo(Customer c)
    {   
        Console.Write("Enter new First Name (leave blank to keep current): ");
        string? newFName = Console.ReadLine();
        if (!string.IsNullOrWhiteSpace(newFName))
        {
            FirstName = newFName;
            c.FirstName = newFName;
        }

        Console.Write("Enter new Last Name (leave blank to keep current): ");
        string? newLName = Console.ReadLine();
        if (!string.IsNullOrWhiteSpace(newLName))
        {
            LastName = newLName;
            c.LastName = newLName;
        }

        Console.Write("Enter new Address (leave blank to keep current): ");
        string? newAddress = Console.ReadLine();
        if (!string.IsNullOrWhiteSpace(newAddress))
        {
            Address = newAddress;
            c.Address = newAddress;
        }

        Console.Write("Enter new Email (leave blank to keep current): ");
        string? newEmail = Console.ReadLine();
        if (!string.IsNullOrWhiteSpace(newEmail))
        {
            Email = newEmail;
            c.Email = newEmail;
        }

        Console.Write("Enter new Phone Number (leave blank to keep current): ");
        string? newPhoneString = Console.ReadLine();
        if (!string.IsNullOrWhiteSpace(newPhoneString) && long.TryParse(newPhoneString, out long newPhoneNumber))
        {
            PhoneNumber = newPhoneNumber;
            c.PhoneNumber = newPhoneNumber;
        }
        // Update Customer table
        if (Program.conn != null)
        {
            CustomerDB.UpdateCustomer(Program.conn, c);
        }

        Console.WriteLine("Customer information updated successfully.");
        // Print updated customer info
        Console.WriteLine("\nUpdated customer info:");
        GetCustomerInfo();
        Console.WriteLine();
    }
}