/*
    Name: Isaiah Thomas
    Date: 10/29/2024
    SDC320 Project Course Project
    Description: The SQLiteDatabase class will connect to a SQLite database.
*/
using System.Data.SQLite;

public class SQLiteDatabase
{
    public static SQLiteConnection Connect(string database)
    {
        string cs = @"Data Source=" + database;
        SQLiteConnection conn = new SQLiteConnection(cs);
        try
        {
            conn.Open();
        }
        catch (Exception e)
        {
            Console.WriteLine(e.Message);
        }
        return conn;
    }
}