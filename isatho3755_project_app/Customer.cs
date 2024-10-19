public class Customer
{
    public int CustomerID { get; set; }
    public string FirstName { get; set; }
    public string LastName { get; set; }
    public string Address { get; set; }
    public string Email { get; set; }
    public long PhoneNumber { get; set; }
    
    public Customer(int ID, string fname, string lname, 
    string address, string email, long phone)
    {
        CustomerID = ID;
        FirstName = fname;
        LastName = lname;
        Address = address;
        Email = email;
        PhoneNumber = phone;
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
        Console.Write("Enter first name: ");
        string newFName = Console.ReadLine();
        Console.Write("Enter last name: ");
        string newLName = Console.ReadLine();
        Console.Write("Enter address: ");
        string newAddress = Console.ReadLine();
        Console.Write("Enter email: ");
        string newEmail = Console.ReadLine();
        Console.Write("Enter phone number: ");
        long newPhone = Convert.ToInt64(Console.ReadLine());

        FirstName = newFName;
        LastName = newLName;
        Address = newAddress;
        Email = newEmail;
        PhoneNumber = newPhone;

        Console.WriteLine
        (
            $"\nName: {newFName} {newLName}" +
            $"\nAddress: {newAddress}" +
            $"\nEmail: {newEmail}" +
            $"\nPhone Number: {newPhone}"
        );

        Console.WriteLine("Would you like to save your changes? (Y/N)");
        string answer = Console.ReadLine();
        if (answer == "Y")
        {
            Console.WriteLine("Customer information has successfully been updated!");
        }
        else if (answer == "N")
        {
            UpdateCustomerInfo();
        }
    }
}