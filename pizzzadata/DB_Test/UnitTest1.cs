using pizzzadata.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using Xunit;
using pizzzadata.Models;
using Microsoft.EntityFrameworkCore;
using System.Data.SqlClient;
using System.Collections;

namespace DB_Test
{

        

    public class UnitTest1
    {
       
        //The purpose of this unit test is to be able to get objects from the database based on the user input,
        //and to be able to get the values of the inputs from the database.
        [Fact]
        public void FindItem1()
        {
            
            List<MenuItem> MenuItems = new List<MenuItem>();
            using (SqlConnection connection = new SqlConnection("Server=tcp:sqlweek1-elijah.database.windows.net,1433;Initial Catalog=pizzzaDatabase;Persist Security Info=False;User ID=sqladmin_elijah;Password=8Vdh17boc8@;MultipleActiveResultSets=False;Encrypt=True;TrustServerCertificate=False;Connection Timeout=30;"))
            using (SqlCommand cmd = new SqlCommand("SELECT * from MenuItem", connection))
            {
                connection.Open();
                using (SqlDataReader reader = cmd.ExecuteReader())
                {
                    // Check is the reader has any rows at all before starting to read.
                    if (reader.HasRows)
                    {
                        // Read advances to the next row.
                        while (reader.Read())
                        {
                            MenuItem MI = new MenuItem();
                            // To avoid unexpected bugs access columns by name.
                            MI.MenuId = reader.GetInt32(reader.GetOrdinal("MenuId"));
                            MI.Item = reader.GetString(reader.GetOrdinal("Item"));
                            // int middleNameIndex = reader.GetOrdinal("MiddleName");
                            // If a column is nullable always check for DBNull...
                            
                            MenuItems.Add(MI);
                        }

                    foreach (var item in MenuItems)
                        {
                            Console.WriteLine(item);
                        }
                    }
                }
            }

        }
        [Fact]
        public void FindItem2()
        {

            List<ItemSize> ItemSizes = new List<ItemSize>();
            using (SqlConnection connection = new SqlConnection("Server=tcp:sqlweek1-elijah.database.windows.net,1433;Initial Catalog=pizzzaDatabase;Persist Security Info=False;User ID=sqladmin_elijah;Password=8Vdh17boc8@;MultipleActiveResultSets=False;Encrypt=True;TrustServerCertificate=False;Connection Timeout=30;"))
            using (SqlCommand cmd = new SqlCommand("SELECT * from ItemSize", connection))
            {
                connection.Open();
                using (SqlDataReader reader = cmd.ExecuteReader())
                {
                    // Check is the reader has any rows at all before starting to read.
                    if (reader.HasRows)
                    {
                        // Read advances to the next row.
                        while (reader.Read())
                        {
                            ItemSize IS = new ItemSize();
                            // To avoid unexpected bugs access columns by name.
                            IS.SizeId = reader.GetInt32(reader.GetOrdinal("SizeId"));
                            IS.Size = reader.GetString(reader.GetOrdinal("Size"));
                            // int middleNameIndex = reader.GetOrdinal("MiddleName");
                            // If a column is nullable always check for DBNull...

                            ItemSizes.Add(IS);
                        }

                        foreach (var item in ItemSizes)
                        {
                            Console.WriteLine(item);
                        }
                    }
                }
            }

        }

        [Fact]
        public void FindItem3()
        {

            List<MenuItemPrice> MenuItemPrices = new List<MenuItemPrice>();
            using (SqlConnection connection = new SqlConnection("Server=tcp:sqlweek1-elijah.database.windows.net,1433;Initial Catalog=pizzzaDatabase;Persist Security Info=False;User ID=sqladmin_elijah;Password=8Vdh17boc8@;MultipleActiveResultSets=False;Encrypt=True;TrustServerCertificate=False;Connection Timeout=30;"))
            using (SqlCommand cmd = new SqlCommand("SELECT * from MenuItemPrice", connection))
            {
                connection.Open();
                using (SqlDataReader reader = cmd.ExecuteReader())
                {
                    // Check is the reader has any rows at all before starting to read.
                    if (reader.HasRows)
                    {
                        // Read advances to the next row.
                        while (reader.Read())
                        {
                            MenuItemPrice MIP = new MenuItemPrice();
                            // To avoid unexpected bugs access columns by name.
                            MIP.Id = reader.GetInt32(reader.GetOrdinal("ID"));
                            MIP.MenuId = reader.GetInt32(reader.GetOrdinal("MenuID"));
                            MIP.SizeId = reader.GetInt32(reader.GetOrdinal("SizeID"));
                            // int middleNameIndex = reader.GetOrdinal("MiddleName");
                            // If a column is nullable always check for DBNull...

                            MenuItemPrices.Add(MIP);
                        }

                        foreach (var item in MenuItemPrices)
                        {
                            Console.WriteLine(item);
                        }
                    }
                }
            }

        }

        [Fact]
        public void TestSpecific1()
        {
            
                //List<MenuItemPrice> MenuItemPrices = new List<MenuItemPrice>();
                MenuItem Item = new MenuItem();
                SqlConnection connection = new SqlConnection("Server=tcp:sqlweek1-elijah.database.windows.net,1433;Initial Catalog=pizzzaDatabase;Persist Security Info=False;User ID=sqladmin_elijah;Password=8Vdh17boc8@;MultipleActiveResultSets=False;Encrypt=True;TrustServerCertificate=False;Connection Timeout=30;");

                connection.Open();
                MenuItem MI = new MenuItem();
                SqlCommand command = new SqlCommand("SELECT Item FROM MenuItem WHERE MenuID = 3;", connection);

               var reader = command.ExecuteReader();

                while (reader.Read())
                {
                    Console.WriteLine(reader[0]);
                }

            if (reader != null)
            {
                reader.Close();
            }
            if (connection != null)
            {
                connection.Close();
            }


        }

        [Fact]
        public void TestSpecific2()
        {

            
            MenuItem Item = new MenuItem();
            SqlConnection connection = new SqlConnection("Server=tcp:sqlweek1-elijah.database.windows.net,1433;Initial Catalog=pizzzaDatabase;Persist Security Info=False;User ID=sqladmin_elijah;Password=8Vdh17boc8@;MultipleActiveResultSets=False;Encrypt=True;TrustServerCertificate=False;Connection Timeout=30;");

            connection.Open();
            MenuItem MI = new MenuItem();
            SqlCommand command1 = new SqlCommand("SELECT Price FROM MenuItemPrice WHERE MenuID = 10 AND  SizeID = 2;", connection);
           
            var reader1 = command1.ExecuteReader();

            while (reader1.Read())
            {
                Console.WriteLine(reader1[0]);
            }

            if (reader1 != null)
            {
                reader1.Close();
            }

            SqlCommand command2 = new SqlCommand("SELECT Item FROM MenuItem where MenuID = 10;", connection);

            var reader2 = command2.ExecuteReader();

            while (reader2.Read())
            {
                Console.WriteLine(reader2[0]);
            }

            if (reader2 != null)
            {
                reader2.Close();
            }

            SqlCommand command3 = new SqlCommand("SELECT Size FROM ItemSize where SizeID = 2;", connection);

            var reader3 = command3.ExecuteReader();

            while (reader3.Read())
            {
                Console.WriteLine(reader3[0]);
            }

            if (reader3 != null)
            {
                reader3.Close();
            }

            if (connection != null)
            {
                connection.Close();
            }


        }

        [Fact]
        public void TestSpecific3()
        {


            MenuItem Item = new MenuItem();
            SqlConnection connection = new SqlConnection("Server=tcp:sqlweek1-elijah.database.windows.net,1433;Initial Catalog=pizzzaDatabase;Persist Security Info=False;User ID=sqladmin_elijah;Password=8Vdh17boc8@;MultipleActiveResultSets=False;Encrypt=True;TrustServerCertificate=False;Connection Timeout=30;");

            connection.Open();
            MenuItem MI = new MenuItem();
            SqlCommand command1 = new SqlCommand("SELECT MenuID FROM MenuItemPrice WHERE Price > 5;", connection);

            var reader1 = command1.ExecuteReader();

            while (reader1.Read())
            {
                Console.WriteLine(reader1[0]);
            }

            if (reader1 != null)
            {
                reader1.Close();
            }

            SqlCommand command2 = new SqlCommand("SELECT FName FROM PizzzaAdmin WHERE AdminID = 2;", connection);

            var reader2 = command2.ExecuteReader();

            while (reader2.Read())
            {
                Console.WriteLine(reader2[0]);
            }

            if (reader2 != null)
            {
                reader2.Close();
            }

            SqlCommand command3 = new SqlCommand("SELECT MenuID FROM MenuItemPrice WHERE MenuID = 10;", connection);

            var reader3 = command3.ExecuteReader();

            while (reader3.Read())
            {
                Console.WriteLine(reader3[0]);
            }

            if (reader3 != null)
            {
                reader3.Close();
            }

            if (connection != null)
            {
                connection.Close();
            }

        }

        [Fact]
        public void TestInput1()
        {

            int input1 = 1;
            int input2 = 1;
            decimal Price = 0;
            MenuItem Item = new MenuItem();
            SqlConnection connection = new SqlConnection("Server=tcp:sqlweek1-elijah.database.windows.net,1433;Initial Catalog=pizzzaDatabase;Persist Security Info=False;User ID=sqladmin_elijah;Password=8Vdh17boc8@;MultipleActiveResultSets=False;Encrypt=True;TrustServerCertificate=False;Connection Timeout=30;");

            connection.Open();
            MenuItem MI = new MenuItem();
            SqlCommand command1 = new SqlCommand("SELECT Price FROM MenuItemPrice WHERE MenuID = " + input1 + " AND  SizeID = " + input2 + ";", connection);

            var reader1 = command1.ExecuteReader();

            while (reader1.Read())
            {
                Price = reader1.GetDecimal(0);
            }

            if (reader1 != null)
            {
                reader1.Close();
            }


            if (connection != null)
            {
                connection.Close();
            }

        }

        [Fact]
        public void TestInput2()
        {

            int input1 = 1;
            int input2 = 1;
            int ID = 0;
            MenuItem Item = new MenuItem();
            SqlConnection connection = new SqlConnection("Server=tcp:sqlweek1-elijah.database.windows.net,1433;Initial Catalog=pizzzaDatabase;Persist Security Info=False;User ID=sqladmin_elijah;Password=8Vdh17boc8@;MultipleActiveResultSets=False;Encrypt=True;TrustServerCertificate=False;Connection Timeout=30;");

            connection.Open();
            MenuItem MI = new MenuItem();
            SqlCommand command1 = new SqlCommand("SELECT ID FROM MenuItemPrice WHERE MenuID = " + input1 + " AND  SizeID = " + input2 + ";", connection);

            var reader1 = command1.ExecuteReader();

            while (reader1.Read())
            {
                ID = reader1.GetInt32(0);
            }

            if (reader1 != null)
            {
                reader1.Close();
            }


            if (connection != null)
            {
                connection.Close();
            }

        }


    }
}


    


