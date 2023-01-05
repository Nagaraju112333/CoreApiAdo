using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using CoreApiWithAdoConnection1.Models;
using CoreApiWithAdoConnection1.Repository;
namespace CoreApiWithAdoConnection1.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class RegisterController : ControllerBase
    {
        private readonly IUserSignUpRepository _repository;
        public RegisterController(IUserSignUpRepository repository)
        {
            _repository = repository;
        }   
        public async Task<List<UserSignUp>> Register(UserSignUp user)
        {
            return await _repository.UserSignup(user);
        }
    }
}
