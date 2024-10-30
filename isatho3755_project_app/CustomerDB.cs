/*
    Name: Isaiah Thomas
    Date: 10/29/2024
    SDC320 Project Course Project
    Description:
*/
using System.Data.SQLite;

public class CustomerDB
{
    public static void CreateTable(SQLiteConnection conn)
    {
        // SQL statement for creating a new table
        string sql =
        "CREATE TABLE IF NOT EXISTS Customers (\n"
        + " CustomerID integer PRIMARY KEY\n"
        + " ,FirstName varchar(20)\n"
        + " ,LastName varchar(40)\n"
        + " ,Address varchar(50)\n"
        + " ,Email varchar(40)\n"
        + " ,PhoneNumber INTEGER"
        + ");";
        SQLiteCommand cmd = conn.CreateCommand();
        cmd.CommandText = sql;
        cmd.ExecuteNonQuery();
    }

    public static void AddCustomer(SQLiteConnection conn, Customer c)
    {
        string sql = string.Format(
        "INSERT INTO Customers(FirstName, LastName, Address, Email, PhoneNumber) "
        + "VALUES('{0}','{1}','{2}','{3}',{4})",
        c.FirstName, c.LastName, c.Address, c.Email, c.PhoneNumber);
        SQLiteCommand cmd = conn.CreateCommand();
        
        cmd.CommandText = sql;
        cmd.ExecuteNonQuery();
    }

    public static void UpdateCustomer(SQLiteConnection conn, Customer c)
    {
        string sql = string.Format(
        "UPDATE Customers SET FirstName='{0}', LastName='{1}', Address='{2}', Email='{3}', PhoneNumber={4}"
        , c.FirstName, c.LastName, c.Address, c.Email, c.PhoneNumber);
        SQLiteCommand cmd = conn.CreateCommand();
        cmd.CommandText = sql;
        cmd.ExecuteNonQuery();
    }

    public static List<Customer> GetAllCustomers(SQLiteConnection conn)
    {
        List<Customer> customers = new List<Customer>();
        string sql = "SELECT * FROM Customers";
        SQLiteCommand cmd = conn.CreateCommand();
        cmd.CommandText = sql;
        SQLiteDataReader rdr = cmd.ExecuteReader();
        while (rdr.Read())
        {
            customers.Add(new Customer(
                rdr.GetInt32(0),
                rdr.GetString(1),
                rdr.GetString(2),
                rdr.GetString(3),
                rdr.GetString(4),
                rdr.GetInt64(5)
            ));
        }
        return customers;
    }
}