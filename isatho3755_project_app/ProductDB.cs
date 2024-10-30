/*
    Name: Isaiah Thomas
    Date: 10/29/2024
    SDC320 Project Course Project
    Description: The ProductDB class creates the Products table.
*/
using System.Data.SQLite;

public class ProductDB
{
    public static void CreateTable(SQLiteConnection conn)
    {
        // SQL statement for creating a new table
        string sql =
        "CREATE TABLE IF NOT EXISTS Products (\n"
        + " ProductID integer PRIMARY KEY\n"
        + " ,ProductName varchar(40)\n"
        + " ,Price REAL\n"
        + " ,Type varchar(20)\n"
        + " ,Color varchar(20) NULL\n"
        + " ,Size varchar(20) NULL\n"
        + ");";
        SQLiteCommand cmd = conn.CreateCommand();
        cmd.CommandText = sql;
        cmd.ExecuteNonQuery();
    }

    public static void AddProduct(SQLiteConnection conn, IProduct p)
    {
        string sql;
        using (SQLiteCommand cmd = conn.CreateCommand())
        {
            if (p is Clothing clothing)
            {
                sql = "INSERT INTO Products(ProductName, Price, Type, Color, Size) " +
                    "VALUES(@productName, @price, @type, @color, @size)";
                
                cmd.Parameters.AddWithValue("@color", clothing.Color);
                cmd.Parameters.AddWithValue("@size", clothing.Size);
            }
            else
            {
                sql = "INSERT INTO Products(ProductName, Price, Type) " +
                "VALUES(@productName, @price, @type)";
            }

            // Common parameters
            cmd.Parameters.AddWithValue("@productName", p.ProductName);
            cmd.Parameters.AddWithValue("@price", p.Price);
            cmd.Parameters.AddWithValue("@type", p.Type);

            cmd.CommandText = sql;
            cmd.ExecuteNonQuery();
        }
    }

    public static void UpdateProduct(SQLiteConnection conn, IProduct p)
    {
        string sql;
        SQLiteCommand cmd = conn.CreateCommand();
        if (p is Clothing clothing)
        {
            sql = string.Format(
            "UPDATE Products SET ProductName='{0}', Price={1}, Type='{2}', Color='{3}', Size='{4}'"
            + " WHERE ProductID={5}", clothing.ProductName, clothing.Price, clothing.Type, 
            clothing.Color, clothing.Size, clothing.ProductID);
        }
        else
        {
            sql = string.Format(
            "UPDATE Products SET ProductName='{0}', Price={1}, Type='{2}'"
            + " WHERE ProductID={3}", p.ProductName, p.Price, p.Type, p.ProductID);
        }

        cmd.CommandText = sql;
        cmd.ExecuteNonQuery();
    }

    public static void DeleteProduct(SQLiteConnection conn, int id)
    {
        string sql = string.Format("DELETE from Products WHERE ProductID = {0}", id);
        SQLiteCommand cmd = conn.CreateCommand();
        cmd.CommandText = sql;
        cmd.ExecuteNonQuery();
    }
}