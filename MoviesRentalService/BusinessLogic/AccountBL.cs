using MoviesRentalService.DAL;
using System;
using System.Collections.Generic;
using System.Data;
using System.Dynamic;
using System.Linq;
using System.Security.Cryptography;
using System.Text;
using System.Web;

namespace MoviesRentalService.BusinessLogic
{
    public class AccountBL
    {
        private readonly DataAccess _dataAccess;

        public AccountBL()
        {
            _dataAccess = new DataAccess();
        }

        public object LoginUser(string email, string password)
        {
            var hashedPassword = ConvertStringtoHash(password);
            string query = String.Format("SELECT UserId,Name,Email,IsAdmin FROM dbo.[User] WHERE email = {0} AND Password = '{1}'", email, hashedPassword);
            var datatable = _dataAccess.ExecuteReadQuery(query);

            if (datatable.Rows.Count < 1)
                return null;

            DataRow row = datatable.Rows[0];
            dynamic obj = new ExpandoObject();

            obj.UserId = Convert.ToInt32(row["UserId"]);
            obj.Name = Convert.ToSingle(row["name"]);
            obj.IsAdmin = Convert.ToBoolean(row["IsAdmin"]);
            obj.IsSuccess = true;
            obj.Message = "Login Successfull";

            return obj; 
        }

        public bool RegisterUser(string name, string email, string password)
        {
            var hashedPassword = ConvertStringtoHash(password);
            String query = "INSERT INTO dbo.[User] (Name,Email,Password,IsAdmin,DateCreated) VALUES (@name,@email,@password,@isadmin,@datecreated)";

            var param = new Dictionary<string, object>()
            {
                { "@name", name},
                { "@email", email},
                { "@password", hashedPassword},
                { "@isadmin", false },
                { "@datecreated", DateTime.Now }
            };

            return _dataAccess.ExecuteWriteQuery(query, param);
        }

        private string ConvertStringtoHash(string value)
        {
            var crypt = new SHA256Managed();
            string hash = String.Empty;
            byte[] crypto = crypt.ComputeHash(Encoding.ASCII.GetBytes(value));
            foreach (byte theByte in crypto)
            {
                hash += theByte.ToString("x2");
            }
            return hash;
        }
    }
}