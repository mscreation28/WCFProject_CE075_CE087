using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Runtime.Serialization;
using System.ServiceModel;
using System.Text;
using URLShortner.Model;

namespace URLShortner.DB
{
    // NOTE: You can use the "Rename" command on the "Refactor" menu to change the class name "UrlService" in both code and config file together.
    public class UrlService : IUrlService
    {
        public String GetUrl(String key)
        {
            SqlConnection sqlConnection = new SqlConnection(@"Data Source=(localdb)\MSSQLLocalDB;
                    Initial Catalog=UrlShortner;Integrated Security=True;
                    Connect Timeout=30;Encrypt=False;TrustServerCertificate=False;
                    ApplicationIntent=ReadWrite;MultiSubnetFailover=False");

            SqlCommand cmd = new SqlCommand();
            cmd.Connection = sqlConnection;
            cmd.CommandText = "SELECT * FROM ShortUrl WHERE ShortKey=@key";
            SqlParameter parameter = new SqlParameter("@key", key);
            cmd.Parameters.Add(parameter);
            String url="";
            try
            {
                sqlConnection.Open();
                SqlDataReader sqlDataReader = cmd.ExecuteReader();
             
                while (sqlDataReader.Read())
                    url = sqlDataReader.GetString(2);

                sqlDataReader.Close();
                sqlConnection.Close();
            }
            catch(Exception e)
            {
                Console.WriteLine(e);
            }
            return url;
        }
        public String CheckUrl(String orignalUrl)
        {
            SqlConnection sqlConnection = new SqlConnection(@"Data Source=(localdb)\MSSQLLocalDB;
                    Initial Catalog=UrlShortner;Integrated Security=True;
                    Connect Timeout=30;Encrypt=False;TrustServerCertificate=False;
                    ApplicationIntent=ReadWrite;MultiSubnetFailover=False");

            SqlCommand cmd = new SqlCommand();
            cmd.Connection = sqlConnection;
            cmd.CommandText = "SELECT * FROM ShortUrl WHERE Url=@orignalUrl";
            SqlParameter parameter = new SqlParameter("@orignalUrl", orignalUrl);
            cmd.Parameters.Add(parameter);
            String url = "";
            try
            {
                sqlConnection.Open();
                SqlDataReader sqlDataReader = cmd.ExecuteReader();
                while (sqlDataReader.Read())
                    url = sqlDataReader.GetString(1);                
                
                sqlDataReader.Close();
                sqlConnection.Close();
            }
            catch (Exception e)
            {
                Console.WriteLine(e);
            }
            return url;
        }
        public void SaveUrl(ShortUrl url)
        {
            SqlConnection sqlConnection = new SqlConnection(@"Data Source=(localdb)\MSSQLLocalDB;
                    Initial Catalog=UrlShortner;Integrated Security=True;
                    Connect Timeout=30;Encrypt=False;TrustServerCertificate=False;
                    ApplicationIntent=ReadWrite;MultiSubnetFailover=False");

            SqlCommand cmd = new SqlCommand();
            cmd.Connection = sqlConnection;
            cmd.CommandText = "INSERT INTO ShortUrl (Url,DateCreated,ShortKey) VALUES(@Url,@DateCreated,@ShortKey) ";
            SqlParameter Url = new SqlParameter("@Url", url.Url);
            SqlParameter DateCreated = new SqlParameter("@DateCreated", url.DateCreated);
            SqlParameter ShortKey = new SqlParameter("@ShortKey", url.ShortKey);
            cmd.Parameters.Add(Url);
            cmd.Parameters.Add(DateCreated);
            cmd.Parameters.Add(ShortKey);

            sqlConnection.Open();
            cmd.ExecuteNonQuery();
            sqlConnection.Close();
        }
    }
}
