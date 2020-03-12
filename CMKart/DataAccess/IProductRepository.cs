using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Threading.Tasks;
using CMKart.Models;
using Oracle.ManagedDataAccess.Client;

namespace CMKart.DataAccess
{
    public interface IProductRepository
    {
        public IEnumerable<ProductCategory> GetProductCatergory();
        public IEnumerable<Product> GetProducts();

    }


    public class ProductRepository : IProductRepository
    {

        string sqlConnectionString = "Server=tcp:dev87.database.windows.net,1433;Initial Catalog=AdventureWorks;Persist Security Info=False;User ID=chethan.marideva;Password=23sahana23@;MultipleActiveResultSets=False;Encrypt=True;TrustServerCertificate=False;Connection Timeout=30;";
        public IEnumerable<ProductCategory> GetProductCatergory()
        {
            string sql = "SELECT ProductCategoryID,Name FROM SalesLT.ProductCategory where ParentProductCategoryID is null;";

            List<ProductCategory> pcList = new List<ProductCategory>();
            using (SqlConnection sqlConnection = new SqlConnection(sqlConnectionString)) 
            {
                sqlConnection.Open();

                using(SqlCommand cmd=new SqlCommand(sql, sqlConnection)) {

                    //SqlDataAdapter adapter = new SqlDataAdapter(cmd);

                   // DataTable dt = new DataTable();
                    // adapter.Fill(dt);


                    var productCategory = cmd.ExecuteReader();

                    while (productCategory.Read()) 
                    {

                        ProductCategory pCat = new ProductCategory() { ProductCategoryID = (int)productCategory["ProductCategoryID"], Name = (string)productCategory["Name"] };
                        pcList.Add(pCat);
                    }

                    

                }
            
            }

            


            return pcList;
            
        }

        public IEnumerable<Product> GetProducts()
        {
            throw new NotImplementedException();
        }
    }
}
