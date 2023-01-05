namespace CoreApiWithAdoConnection1.Models
{
    public class UserLogin
    {
       public int userid { get; set; }  
        public string firstname { get; set; }
        public string lastname { get; set; }
        public string username { get; set; }    
        public string password { get; set; }    
        public string token { get; set; }

    }
    public class UserIds
    {
        public int Userid { get; set;}

    }
    public class PostuserDetails
    {
        public string firstname { get; set; }
        public string lastname { get; set; }
        public string username { get; set; }
        public string password { get; set; }
        public string token { get; set; }
    }
    public class UpdateUserDetails
    {
        public string firstname { get; set; }
        public string lastname { get; set; }
        public string username { get; set; }
        public string password { get; set; }
        public string token { get; set; }
    }

}
