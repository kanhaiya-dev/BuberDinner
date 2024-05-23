using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using BuberDinner.Application.Services.Authentication.Common;

namespace BuberDinner.Application.Services.Authentication
{
    public interface IAuthenticationQueryService
    {
        AuthenticationResult Login(string Email, string Password);
    }

    
}
