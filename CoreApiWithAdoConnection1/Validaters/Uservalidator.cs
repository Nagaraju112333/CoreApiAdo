using FluentValidation;
using CoreApiWithAdoConnection1.Models;
namespace CoreApiWithAdoConnection1.Validaters
{
    public class Uservalidator:AbstractValidator<UserLogin>
    {
        public Uservalidator() 
        { 
            RuleFor(x=>x.firstname).NotEmpty();
            RuleFor(x=>x.lastname).NotEmpty();
            RuleFor(x=>x.username).NotEmpty();
            RuleFor(x=>x.password).NotEmpty();  
        }
    }
}
