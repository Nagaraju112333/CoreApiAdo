using System.Text;

namespace CoreApiWithAdoConnection1.Models
{
    public class Register
    {
        /*public int RegisterId { get; set; } 
        public string? FirstName { get; set; }   
        public string? LastName { get; set; }
        public string? Email { get; set; }
        public string?  Password { get; set; }
        public bool IsEmailVerified { get; set; }
        public System.Guid ActivationCode { get; set; }
        public string? ResetpasswordCode { get; set; }
        public string? Phone_Number { get; set; }*/
    }
    public class UserSignUp
    {
        public int RegisterId { get; set; }
        public string? FirstName { get; set; }
        public string? LastName { get; set; }
        public string? Email { get; set; }
        public string? Password { get; set; }
        public bool IsEmailVerified { get; set; }
        public System.Guid ActivationCode { get; set; }
        public string? ResetpasswordCode { get; set; }
        public string? Phone_Number { get; set; }
    }
    public static class Crypto
    {

        public static string Hash(string value)
        {
            return Convert.ToBase64String(
                System.Security.Cryptography.SHA256.Create()
                .ComputeHash(Encoding.UTF8.GetBytes(value))
                );
        }
    }
    public class useremail
    {
        public string Email { get; set; }
    }
}
