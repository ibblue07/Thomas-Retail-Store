/*
    Name: Isaiah Thomas
    Date: 10/19/2024
    SDC320 Project Class Implementation
    Description: The Customer class stores all of the customer properties and get & update methods.
*/
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

    public string GetCustomerInfo()
    {
        return $"Name: {FirstName} {LastName}" +
        $"\nAddress: {Address}" +
        $"\nEmail: {Email}" +
        $"\nPhone Number: {PhoneNumber}";
    }

    public void UpdateCustomerInfo()
    {   
        Console.Write("Enter new First Name (leave blank to keep current): ");
        string newFName = Console.ReadLine();
        if (!string.IsNullOrWhiteSpace(newFName))
        {
            FirstName = newFName;
        }

        Console.Write("Enter new Last Name (leave blank to keep current): ");
        string newLName = Console.ReadLine();
        if (!string.IsNullOrWhiteSpace(newLName))
        {
            LastName = newLName;
        }

        Console.Write("Enter new Address (leave blank to keep current): ");
        string newAddress = Console.ReadLine();
        if (!string.IsNullOrWhiteSpace(newAddress))
        {
            Address = newAddress;
        }

        Console.Write("Enter new Email (leave blank to keep current): ");
        string newEmail = Console.ReadLine();
        if (!string.IsNullOrWhiteSpace(newEmail))
        {
            Email = newEmail;
        }

        Console.Write("Enter new Phone Number (leave blank to keep current): ");
        string newPhoneString = Console.ReadLine();
        if (!string.IsNullOrWhiteSpace(newPhoneString) && long.TryParse(newPhoneString, out long newPhoneNumber))
        {
            PhoneNumber = newPhoneNumber;
        }

        Console.WriteLine("Customer information updated successfully.");
        Console.WriteLine("\nUpdated customer info:");
        GetCustomerInfo();
    }
}