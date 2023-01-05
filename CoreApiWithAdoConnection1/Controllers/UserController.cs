using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using CoreApiWithAdoConnection1.Models;
using CoreApiWithAdoConnection1.Repository;
namespace CoreApiWithAdoConnection1.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class UserController : ControllerBase
    {
        private readonly IuserLoginRepository _repo;
        public UserController(IuserLoginRepository userarepo)
        {
            _repo = userarepo;
        }
        [HttpGet("GetAllUsers")]
       
        public async Task<List<UserLogin>> Getall()
        {
            return await _repo.GetAlluser();
        }
        [HttpGet]
        [Route("GetUserIds")]
        public async Task<List<UserIds>> GetIds()
        {
            return await _repo.Ids();
        }
        [Route("GetUserById/{id}")]
        [HttpGet]
        public async Task<List<UserLogin>> GetuserbyID(int id)
        {
            return await _repo.GetByid(id);
        }
        [HttpPost]
        [Route("SaveUser")]
        public async Task<PostuserDetails> Savedata(PostuserDetails details)
        {
            return await _repo.postpatientdata(details);
        }
        [HttpPut]
        [Route("updateuser/{id}")]
        public async Task<List<UpdateUserDetails>> UopdateUser(UpdateUserDetails user,int id)
        {
            return await _repo.UpdateUserDetails(user, id);
        }

    }
}
