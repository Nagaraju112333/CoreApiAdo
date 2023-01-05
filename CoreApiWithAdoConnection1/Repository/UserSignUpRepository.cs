/*using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Mail;
using System.Net;
using System.Web;
using System.Data;
using System.Threading.Tasks;
using CoreApiWithAdoConnection1.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Data.SqlClient;
using static Microsoft.EntityFrameworkCore.DbLoggerCategory.Database;
using Azure;

namespace CoreApiWithAdoConnection1.Repository
{
    public class UserSignUpRepository : IUserSignUpRepository
    {
        private IConfiguration _configuration;
        public string Connnectionstring;

        public UserSignUpRepository(IConfiguration configuration)
        {
            this._configuration = configuration;
            Connnectionstring = _configuration["ConnectionStrings:myconnection"];
        }
        [HttpPost]
        public async Task<List<UserSignUp>> UserSignup([Bind() = "IsEmailVerified,ActivationCode"] UserSignUp user)
        {


            var isExist = IsEmailExist(user.Email);
            if (isExist)
            {
               ;
            }


            #region Generate Activation Code 
            user.ActivationCode = Guid.NewGuid();
            #endregion
            #region  Password Hashing 
            user.Password = Crypto.Hash(user.Password);
            //   user.ConfirmPassword = Crypto.Hash(user.ConfirmPassword); //
            #endregion
            user.IsEmailVerified = false;

            #region Save to Database
            using (SqlConnection con = new SqlConnection(Connnectionstring))
            {
                SqlCommand command = new SqlCommand("userRegister", con);
                command.CommandType = CommandType.StoredProcedure;
                con.Open();
                command.Parameters.AddWithValue("@fname", user.FirstName);
                command.Parameters.AddWithValue("@lname", user.LastName);
                command.Parameters.AddWithValue("@email", user.Email);
                command.Parameters.AddWithValue("@password", user.Password);
                command.Parameters.AddWithValue("@phone", user.Phone_Number);
                int a = command.ExecuteNonQuery();

            }

            throw new NotImplementedException();
        }
        [NonAction]
        public bool IsEmailExist(string emailID)
        {
            List<useremail> email = new List<useremail>();
            using (SqlConnection comn = new SqlConnection(Connnectionstring))
            {
                SqlCommand cmd = new SqlCommand("select * from Register where Email=" + emailID, comn);
                cmd.CommandType = CommandType.Text;
                comn.Open();
                SqlDataAdapter dr = new SqlDataAdapter(cmd);
                DataTable data = new DataTable();
                dr.Fill(data);
                foreach (DataRow c in data.Rows)
                {
                    email.Add(new useremail
                    {
                        Email = c["Email"].ToString()
                    });
                }
                return email != null;
            }
        }

    }
}
*/