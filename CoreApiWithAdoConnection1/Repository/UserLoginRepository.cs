using CoreApiWithAdoConnection1.Models;
using CoreApiWithAdoConnection1.Repository;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Data.SqlClient;
using System.Data;
using static Microsoft.EntityFrameworkCore.DbLoggerCategory.Database;

namespace CoreApiWithAdoConnection1.Repository
{
    public class UserLoginRepository : IuserLoginRepository
    {
        public IConfiguration _configuration;
        public string ConnectionString;
        public UserLoginRepository(IConfiguration configuration)
        {
            this._configuration = configuration;
            ConnectionString = _configuration["ConnectionStrings:myconnection"];
        }
        [Route("GetUserById")]
        [HttpGet("{id}")]
        public async Task<List<UserLogin>> GetByid(int id)
        {
            List<UserLogin> users = new List<UserLogin>(); 
            try
            {
                using (SqlConnection con = new SqlConnection(ConnectionString))
                {
                    SqlCommand cmd = new SqlCommand("GetUserDetailsById", con);
                    cmd.CommandType = CommandType.StoredProcedure;
                    cmd.Parameters.AddWithValue("@id", id);
                    con.Open();
                   
                    SqlDataAdapter dr = new SqlDataAdapter(cmd);
                    DataTable da = new DataTable();
                    dr.Fill(da);
                    foreach (DataRow a in da.Rows)
                    {
                        users.Add(new UserLogin
                        {
                            userid = Convert.ToInt32(a["userid"]),
                            firstname = a["firstname"].ToString(),
                            lastname = a["lastname"].ToString(),
                            username = a["username"].ToString(),
                            password = a["password"].ToString(),
                            token = a["token"].ToString()
                        });
                    }
                    return await Task.FromResult(users);
                }
            }
            catch(Exception ex)
            {
                Console.WriteLine(ex.Message);
            }
            return users;   
        }
        [HttpGet]
        public async Task<List<UserLogin>> GetAlluser()
        {
            List<UserLogin> list = new List<UserLogin>();
            try
            {
                using(SqlConnection con = new SqlConnection(ConnectionString))
                {
                    SqlCommand cmd = new SqlCommand("GetallDetails", con);
                    cmd.CommandType = CommandType.StoredProcedure;
                    con.Open();
                    SqlDataAdapter dr = new SqlDataAdapter(cmd);
                    DataTable data = new DataTable();
                    dr.Fill(data);
                    foreach (DataRow row in data.Rows)
                    {
                        list.Add(new UserLogin
                        {
                            userid = Convert.ToInt32(row["userid"]),
                            firstname = row["firstname"].ToString(),
                            lastname = row["lastname"].ToString(),
                            username = row["username"].ToString(),
                            token = row["token"].ToString()
                        });
                    }
                    return await Task.FromResult(list);
                }
            }
            catch(Exception ex)
            {
               Console.WriteLine(ex.Message);   
            }
            return list;
           
        }
        [HttpPut]
        [Route("updateuser/{id}")]
        public async Task<List<UpdateUserDetails>> UpdateUserDetails(UpdateUserDetails user, int id)
        {
            try
            {
                using (SqlConnection con = new SqlConnection(ConnectionString))
                {
                    con.Open();

                    using (SqlCommand cmd = new SqlCommand("UpdateuserDetails", con))
                    {
                        cmd.CommandType = CommandType.StoredProcedure;
                        cmd.Parameters.AddWithValue("@id", id);
                        cmd.Parameters.AddWithValue("@fname", user.firstname);
                        cmd.Parameters.AddWithValue("@lname", user.lastname);
                        cmd.Parameters.AddWithValue("@uname", user.username);
                        cmd.Parameters.AddWithValue("@password", user.password);
                        cmd.Parameters.AddWithValue("@token", user.token);
                        int a = cmd.ExecuteNonQuery();
                    } 

                   // return await Task.FromResult(user);
                }
            }
            catch(Exception ex)
            {
                Console.WriteLine(ex.Message);
            }
            return null;
        }
        [HttpGet("GetUserIds")]
        public async Task<List<UserIds>> Ids()
        {
            List<UserIds> list = new List<UserIds>();
            try
            {
                using (SqlConnection con = new SqlConnection(ConnectionString))
                {
                    SqlCommand command = new SqlCommand("GetIds", con);
                    command.CommandType = CommandType.StoredProcedure;
                    con.Open();
                    SqlDataAdapter dr = new SqlDataAdapter(command);
                    DataTable data = new DataTable();
                    dr.Fill(data);
                    foreach (DataRow c in data.Rows)
                    {
                        list.Add(new UserIds
                        {
                            Userid = Convert.ToInt32(c["Userid"])
                        });
                    }
                    return await Task.FromResult(list);
                }
            }
            catch(Exception ex)
            { 
                Console.WriteLine(ex.Message);
            }
            return list;
        }
        [HttpPost]
        [Route("SaveUser")]
        public async Task<PostuserDetails> postpatientdata(PostuserDetails usre)
        {
            try
            {
                using (SqlConnection con = new SqlConnection(ConnectionString))
                {
                    SqlCommand command = new SqlCommand("UserSave", con);
                    command.CommandType = CommandType.StoredProcedure;
                    con.Open();
                    command.Parameters.AddWithValue("@fname", usre.firstname);
                    command.Parameters.AddWithValue("@lname", usre.lastname);
                    command.Parameters.AddWithValue("@uname", usre.username);
                    command.Parameters.AddWithValue("@password", usre.password);
                    command.Parameters.AddWithValue("@token", usre.token);
                    int a = command.ExecuteNonQuery();
                }
                return await Task.FromResult(usre);
            }
            catch(Exception ex)
            {
                Console.WriteLine(ex.Message);
                
            }
            return null;
        }
    }
}
