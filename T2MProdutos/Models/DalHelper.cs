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

        public static List<Product> GetAllProductsPage(int Page, int totalItens)
        {
            List<Product> products = new List<Product>();
            SqlConnection connection = new SqlConnection(GetStringConnection());

            connection.Open();
            SqlCommand command = new SqlCommand("GetAllProductsPage", connection);
            command.CommandType = System.Data.CommandType.StoredProcedure;
            command.Parameters.AddWithValue("@Page", Page);
            command.Parameters.AddWithValue("@TotalPages", totalItens);
            SqlDataReader reader = command.ExecuteReader();

            while (reader.Read())
            {
                Product product = new Product();

                product.Id      = Convert.ToInt32(reader["Id"]);
                product.Name    = reader["Name"].ToString();
                product.Price   = Convert.ToDouble(reader["Price"]);
                product.Created = Convert.ToDateTime(reader["Created"]).ToString("yyyy/MM/dd");

                products.Add(product);
            }
            connection.Close();

            return products;
        }

        public static List<Product> GetAllProducts()
        {
            List<Product> products = new List<Product>();
            SqlConnection connection = new SqlConnection(GetStringConnection());

            connection.Open();
            SqlCommand command = new SqlCommand("GetAllProducts", connection);
            command.CommandType = System.Data.CommandType.StoredProcedure;
            SqlDataReader reader = command.ExecuteReader();

            while (reader.Read())
            {
                Product product = new Product();

                product.Id = Convert.ToInt32(reader["Id"]);
                product.Name = reader["Name"].ToString();
                product.Price = Convert.ToDouble(reader["Price"]);
                product.Created = Convert.ToDateTime(reader["Created"]).ToString("yyyy/MM/dd");

                products.Add(product);
            }
            connection.Close();

            return products;
        }

        public static int GetTotalPages(int totalItens)
        {
            SqlConnection connection = new SqlConnection(GetStringConnection());
            connection.Open();

            SqlCommand command = new SqlCommand("GetTotalProducts", connection);
            command.CommandType = System.Data.CommandType.StoredProcedure;

            SqlDataReader reader = command.ExecuteReader();
            reader.Read();

            return Convert.ToInt32(Math.Ceiling(Convert.ToDecimal(reader["Return"]) / totalItens));
        }

        public static Product FindProductByName(string Name)
        {

            SqlConnection connection = new SqlConnection(GetStringConnection());
            connection.Open();

            SqlCommand command = new SqlCommand("FindProductByName", connection);
            command.CommandType = System.Data.CommandType.StoredProcedure;
            command.Parameters.AddWithValue("@Name", Name);

            SqlDataReader reader = command.ExecuteReader();

            Product product = null;

            while (reader.Read())
            {
                product = new Product();

                product.Id = Convert.ToInt32(reader["Id"]);
                product.Name = reader["Name"].ToString();
                product.Price = Convert.ToDouble(reader["Price"]);
                product.Created = Convert.ToDateTime(reader["Created"]).ToString("yyyy/MM/dd");
            }

            connection.Close();
            return product;
        }

        public static bool DeleteProductByName(string Name)
        {
            SqlConnection connection = new SqlConnection(GetStringConnection());
            connection.Open();

            SqlCommand command = new SqlCommand("DeleteProductByName", connection);
            command.CommandType = System.Data.CommandType.StoredProcedure;
            command.Parameters.AddWithValue("@Name", Name);

            SqlDataReader reader = command.ExecuteReader();
            reader.Read();
            bool Return = Convert.ToBoolean(reader["Return"]);

            connection.Close();

            return Return;
        }

        public static bool InsertProduct(Product product)
        {
            SqlConnection connection = new SqlConnection(GetStringConnection());
            connection.Open();

            SqlCommand command = new SqlCommand("InsertProduct", connection);
            command.CommandType = System.Data.CommandType.StoredProcedure;
            command.Parameters.AddWithValue("@Name", product.Name);
            command.Parameters.AddWithValue("@Price", product.Price);

            SqlDataReader reader = command.ExecuteReader();
            reader.Read();
            bool Return = Convert.ToBoolean(reader["Return"]);

            connection.Close();

            return Return;
        }

    }
}