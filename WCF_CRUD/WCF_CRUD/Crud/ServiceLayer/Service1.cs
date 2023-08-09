using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Runtime.Serialization;
using System.ServiceModel;
using System.Text;

namespace ServiceLayer
{
    
    public class Service1 : IService1
    {
        public Service1()
        {
            ConnectToDb();
        }

        SqlConnection conn;
        SqlCommand comm;

        SqlConnectionStringBuilder connStringBuilder;

        void ConnectToDb()
        {
            connStringBuilder = new SqlConnectionStringBuilder();
            connStringBuilder.DataSource = "CASPER_NIRVANA\\SQLEXPRESS";
            connStringBuilder.InitialCatalog = "CRMDb";
            connStringBuilder.Encrypt = true;
            connStringBuilder.TrustServerCertificate = true;
            connStringBuilder.ConnectTimeout = 30;
            connStringBuilder.AsynchronousProcessing = true;
            connStringBuilder.MultipleActiveResultSets = true;
            connStringBuilder.IntegratedSecurity = true;

            conn = new SqlConnection(connStringBuilder.ToString());
            comm = conn.CreateCommand();
        }
        public int InsertProduct(Product p)
        {
            using (SqlConnection _conn = new SqlConnection(conn.ConnectionString))
            {
                if (_conn.State == ConnectionState.Closed)
                    _conn.Open();
                using (SqlCommand _command = new SqlCommand("SP_Insert", _conn))
                {
                    //_command.Parameters.AddWithValue("@Id", textBox1.Text);
                    _command.Parameters.AddWithValue("@name", p.Name);
                    _command.Parameters.AddWithValue("@price", p.Price);
                    _command.Parameters.AddWithValue("@stock", p.Stock);
                    _command.CommandType = CommandType.StoredProcedure;
                   return _command.ExecuteNonQuery();
                    
                }
            }

        }
        public int UpdateProduct(Product p)
        {
            using (SqlConnection _conn = new SqlConnection(conn.ConnectionString))
            {
                if (_conn.State == ConnectionState.Closed)
                    _conn.Open();
                using (SqlCommand _command = new SqlCommand("SP_Update", _conn))
                {
                    _command.Parameters.AddWithValue("@id", p.Id);
                    _command.Parameters.AddWithValue("@name", p.Name);
                    _command.Parameters.AddWithValue("@price", p.Price);
                    _command.Parameters.AddWithValue("@stock", p.Stock);
                    _command.CommandType = CommandType.StoredProcedure;
                    return _command.ExecuteNonQuery();

                }
            }
 
        }
        public int DeleteProduct(Product p)
        {
            using (SqlConnection _conn = new SqlConnection(conn.ConnectionString))
            {
                if (_conn.State == ConnectionState.Closed)
                    _conn.Open();
                using (SqlCommand _command = new SqlCommand("SP_Delete", _conn))
                {
                    _command.Parameters.AddWithValue("@id", p.Id);  
                    _command.CommandType = CommandType.StoredProcedure;
                    return _command.ExecuteNonQuery();

                }
            }

        }
       

        public List<Product> GetAllProduct()
        {
            List<Product> productL = new List<Product>();
            try
            {
                comm.CommandText = "Select * from Products";
                comm.CommandType = CommandType.Text;
                conn.Open();

                SqlDataReader reader = comm.ExecuteReader();
                while (reader.Read())
                {
                    Product product = new Product()
                    {
                        Id = Convert.ToInt32(reader[0]),
                        Name = reader[1].ToString(),
                        Price = reader[2].ToString(),
                        Stock = Convert.ToInt32(reader[3])
                    };
                    productL.Add(product);
                }
                return productL;
            }
            catch (Exception)
            {

                throw;
            }
            finally
            {
                if (conn != null)
                {
                    conn.Close();
                }
            }
        }
    }
}
