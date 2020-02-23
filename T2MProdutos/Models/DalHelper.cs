using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Configuration;
using System.Data.SqlClient;

namespace T2MProdutos.Models
{
    public class DalHelper
    {

        protected static string GetStringConnection()
        {
            return ConfigurationManager.ConnectionStrings["ConnectionDB"].ConnectionString;
        }

        public static List<Product> GetAllProducts()
        {
            List<Product> products = new List<Product>();
            SqlConnection connection = new SqlConnection(GetStringConnection());
            connection.Open();
            SqlCommand command = new SqlCommand("EXEC GetAllProducts", connection);
            SqlDataReader reader = command.ExecuteReader();

            while (reader.Read())
            {
                Product product = new Product();

                product.Id = Convert.ToInt32(reader["Id"]);
                product.Name = reader["Name"].ToString();
                product.Price = Convert.ToDouble(reader["Price"]);
                product.Created = Convert.ToDateTime(reader["Created"]);

                products.Add(product);
            }
            connection.Close();
            return products;    
        }

        public static Product FindByName(string Name)
        {
            SqlConnection connection = new SqlConnection(GetStringConnection());
            connection.Open();
            SqlCommand command = new SqlCommand("EXEC FindByName @Name = '" + Name + "'", connection);
            SqlDataReader reader = command.ExecuteReader();

            Product product = new Product();

            while (reader.Read())
            {
                product.Id = Convert.ToInt32(reader["Id"]);
                product.Name = reader["Name"].ToString();
                product.Price = Convert.ToDouble(reader["Price"]);
                product.Created = Convert.ToDateTime(reader["Created"]);
            }

            connection.Close();
            return product;
        }

        public static void DeleteProduct(string Name)
        {
            SqlConnection connection = new SqlConnection(GetStringConnection());
            connection.Open();
            SqlCommand command = new SqlCommand("EXEC DeleteProduct @Name = '" + Name + "'", connection);
            SqlDataReader reader = command.ExecuteReader();
            connection.Close();
        }

        public static void InsertProduct(Product product)
        {
            SqlConnection connection = new SqlConnection(GetStringConnection());
            connection.Open();
            SqlCommand command = new SqlCommand("EXEC InsertProduct @Name = '" + product.Name + "', @Price = " + product.Price.ToString().Replace(',','.'), connection);
            SqlDataReader reader = command.ExecuteReader();
            connection.Close();
        }

    }
}