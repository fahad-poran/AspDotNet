using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Web;
using Product.Models.Entity;

namespace Product.Models.Tables
{
    public class Products
    {
        SqlConnection conn;
        public Products(SqlConnection conn)
        {
            this.conn = conn;
        }
        public void Add(ProductStructure p)
        {
            string query = String.Format("Insert into ProductList values ('{0}','{1}','{2}','{3}')", p.Name, p.Price, p.Quantity, p.Description);
            SqlCommand cmd = new SqlCommand(query, conn);
            conn.Open();
            int r = cmd.ExecuteNonQuery();
            conn.Close();
        }
        public ProductStructure Get(int id)
        {
            return null;
        }
        public List<ProductStructure> GetAll()
        {
            string query = "select * from ProductList";
            SqlCommand cmd = new SqlCommand(query, conn);
            conn.Open();
            SqlDataReader reader = cmd.ExecuteReader();
            List<ProductStructure> products = new List<ProductStructure>();
            while (reader.Read())
            {
                ProductStructure s = new ProductStructure()
                {
                    Id = reader.GetInt32(reader.GetOrdinal("Id")),
                    Name = reader.GetString(reader.GetOrdinal("Name")),
                    Price = reader.GetInt32(reader.GetOrdinal("Price")),
                    Quantity = reader.GetInt32(reader.GetOrdinal("Quantity")),
                    Description = reader.GetString(reader.GetOrdinal("Description"))
                };
                products.Add(s);
            }
            conn.Close();
            return products;
        }

        public ProductStructure AddToCart (int Id)
        {
            string query = String.Format("select * from ProductList where Id = {0}",Id);
            SqlCommand cmd = new SqlCommand(query, conn);
            conn.Open();
            SqlDataReader reader = cmd.ExecuteReader();
            ProductStructure product= null;
            while (reader.Read())
            {
                 product = new ProductStructure()
                 {
                    Id = reader.GetInt32(reader.GetOrdinal("Id")),
                    Name = reader.GetString(reader.GetOrdinal("Name")),
                    Price = reader.GetInt32(reader.GetOrdinal("Price")),
                    Quantity = reader.GetInt32(reader.GetOrdinal("Quantity")),
                    Description = reader.GetString(reader.GetOrdinal("Description"))
                 };
            }
            conn.Close();
            return product;
        }
    }
}