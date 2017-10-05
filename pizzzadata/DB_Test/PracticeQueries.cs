using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Text;
using pizzzadata.Models;

namespace DB_Test
{
    class PracticeQueries
    {
        //static void Main(string[] args)
        //{
        //    List<MenuItemPrice> MenuItemPrices = new List<MenuItemPrice>();
        //    using (SqlConnection connection = new SqlConnection("Server=tcp:sqlweek1-elijah.database.windows.net,1433;Initial Catalog=pizzzaDatabase;Persist Security Info=False;User ID=sqladmin_elijah;Password=8Vdh17boc8@;MultipleActiveResultSets=False;Encrypt=True;TrustServerCertificate=False;Connection Timeout=30;"))
        //    using (SqlCommand cmd = new SqlCommand("SELECT * from MenuItemPrice", connection))
        //    {
        //        connection.Open();
        //        using (SqlDataReader reader = cmd.ExecuteReader())
        //        {
        //            // Check is the reader has any rows at all before starting to read.
        //            if (reader.HasRows)
        //            {
        //                // Read advances to the next row.
        //                while (reader.Read())
        //                {
        //                    MenuItemPrice MIP = new MenuItemPrice();
        //                    // To avoid unexpected bugs access columns by name.
        //                    MIP.Id = reader.GetInt32(reader.GetOrdinal("ID"));
        //                    MIP.MenuId = reader.GetInt32(reader.GetOrdinal("MenuID"));
        //                    MIP.SizeId = reader.GetInt32(reader.GetOrdinal("SizeID"));
        //                    // int middleNameIndex = reader.GetOrdinal("MiddleName");
        //                    // If a column is nullable always check for DBNull...
        //                    MenuItemPrices.Add(MIP);


        //                }
        //                foreach (var item in MenuItemPrices)
        //                {
        //                    Console.WriteLine(item);
        //                }
        //            }
        //        }
        //    }

        //}
    }
}
