using CoreApiWithAdoConnection1.Models;

namespace CoreApiWithAdoConnection1.Repository
{
    public interface IUserSignUpRepository
    {
         Task<List<UserSignUp>> UserSignup(UserSignUp user);
    }
}
