using Microsoft.AspNetCore.Identity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Claims;
using Mohandisy.Models;

namespace Mohandisy.Services
{
    public class ApplicationUserService : IApplicationUserService
    {
        private readonly UserManager<ApplicationUser> _userManager;
        private readonly ApplicationDbContext _context;
        public ApplicationUserService(UserManager<ApplicationUser> userManager, ApplicationDbContext context)
        {
            _userManager = userManager;
            _context = context;
        }

        /*public static string GetCurrentUser(this ClaimsPrincipal user)
        {
            ClaimsPrincipal currentUser = user;
            return currentUser.FindFirst(ClaimTypes.NameIdentifier).Value;
        }*/
        public ApplicationUser AddApplicationUser(ApplicationUser applicationUser)
        {
            _context.ApplicationUsers.Add(applicationUser);
            _context.SaveChanges();

            return applicationUser;
        }

        public ApplicationUser DeleteApplicationUser(string id)
        {
            var user = _context.ApplicationUsers.Find(id);
            
            _context.ApplicationUsers.Remove(user);
            _context.SaveChanges();

            return user;
        }

        public ApplicationUser GetApplicationUser(string id)
        {
            return _context.ApplicationUsers.FirstOrDefault(x=>x.Id == id);
        }

        public IEnumerable<ApplicationUser> GetApplicationUsers()
        {
            var applicationUsers = _userManager.Users;
            
            return applicationUsers;
        }
        public IEnumerable<ApplicationUser> GetApplicationUsersByType(string type)
        {

            var applicationUsers = _userManager.GetUsersInRoleAsync(type).Result;
            return applicationUsers;
        }

        public string GetCurrentUser()
        {
            throw new NotImplementedException();
        }

        public IEnumerable<ApplicationUser> SearchForUsers(string data)
        {
            var users = _context.ApplicationUsers.Where(q =>
            q.UserName.Contains(data) ||
            q.Email.Contains(data)

            ).ToList();
            return users;
        }

        public ApplicationUser UpdatelicationUser(ApplicationUser applicationUser)
        {
            throw new NotImplementedException();
        }

    }
}
