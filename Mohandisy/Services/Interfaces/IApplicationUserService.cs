using System;
using System.Collections.Generic;
using Mohandisy.Models;

namespace Mohandisy.Services
{
    public interface IApplicationUserService
    {
        IEnumerable<ApplicationUser> GetApplicationUsers();
        IEnumerable<ApplicationUser> GetApplicationUsersByType(string type);
        ApplicationUser GetApplicationUser(string id);
        ApplicationUser UpdatelicationUser(ApplicationUser applicationUser);
        ApplicationUser AddApplicationUser(ApplicationUser applicationUser);
        ApplicationUser DeleteApplicationUser(string id);
        IEnumerable<ApplicationUser> SearchForUsers(string data);
        string GetCurrentUser();
    }
}
