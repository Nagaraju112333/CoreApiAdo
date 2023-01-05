using CoreApiWithAdoConnection1.Models;
namespace CoreApiWithAdoConnection1.Repository
{
    public interface IuserLoginRepository
    {
        Task<List<UserLogin>> GetAlluser();
        //postpatientdata
        //Task<UserLogin> PostData(UserLogin userLogin);
        //getdoctordetails
        Task<List<UserLogin>> GetByid(int id);
        Task<List<UserIds>> Ids();

        Task<List<UpdateUserDetails>> UpdateUserDetails(UpdateUserDetails user,int id);

        Task<PostuserDetails> postpatientdata(PostuserDetails usre);
    }
}
