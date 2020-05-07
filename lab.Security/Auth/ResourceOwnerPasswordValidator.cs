using IdentityModel;
using IdentityServer4.Validation;
using lab.Data.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Claims;
using System.Threading.Tasks;

namespace lab.Security.Auth
{
    public class ResourceOwnerPasswordValidator : IResourceOwnerPasswordValidator
    {
        public IEmployeeRepository EmployeeRepository { get; set; }
        public ResourceOwnerPasswordValidator(IEmployeeRepository employeeRepository)
        {
            EmployeeRepository = employeeRepository;
        }
        public Task ValidateAsync(ResourceOwnerPasswordValidationContext context)
        {
            var employee = EmployeeRepository.GetEmployees()
                .FirstOrDefault(x => x.UserName == context.UserName
                        && x.Password == context.Password
                );
            if (employee == null)
            {
                context.Result.IsError = true;
                context.Result.ErrorDescription = "Email or Password Incorrect";
                return Task.FromResult(false);
            }
            else
            {

                context.Result.IsError = false;

                var claim = new Claim[]
                {
                    new Claim(JwtClaimTypes.Id,employee.Id.ToString()),
                    new Claim(JwtClaimTypes.Subject,employee.Id.ToString()),
                    new Claim(JwtClaimTypes.IdentityProvider,"IS"),
                    new Claim(JwtClaimTypes.Name,employee.Name.ToString()),
                    new Claim(JwtClaimTypes.Email,employee.Name.ToString()),
                    new Claim(JwtClaimTypes.FamilyName,employee.LastName.ToString()),
                    new Claim(JwtClaimTypes.AuthenticationTime, DateTime.UtcNow.ToEpochTime().ToString() ),
                };

                context.Result.Subject = new ClaimsPrincipal(
                    new ClaimsIdentity(claim, ClaimTypes.Authentication, ClaimTypes.Name, ClaimTypes.Role));
                context.Result.CustomResponse = new Dictionary<string, object>();
                context.Result.CustomResponse.Add("Name", employee.Name.ToString());


                return Task.FromResult(context.Result);
            }
        }
    }
}
