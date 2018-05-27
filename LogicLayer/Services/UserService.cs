using System;
using LogicLayer.DTO;
using LogicLayer.Interfaces;
using Data.Interfaces;
using AutoMapper;
using Data.Entities;
using LogicLayer.Infrastructure;
using System.Security.Claims;
using System.Threading.Tasks;
using Data.Identity.Entities;
using Data.Identity.Interfaces;
using System.Linq;
using Microsoft.AspNet.Identity;
using Microsoft.Owin.Security.Cookies;
using Microsoft.Owin.Security.OAuth;
using System.Collections.Generic;

namespace LogicLayer.Services
{
    public class UserService : IUserService
    {
        IUnitOfWork Database { get; set; }
        IUnitOfWorkIdentity DatabaseUsers { get; set; }

        public UserService(IUnitOfWorkIdentity uowi, IUnitOfWork uow)
        {
            DatabaseUsers = uowi;
            Database = uow;
        }

        public async Task<OperationDetails> Create(UserDTO userDto)
        {
            var user = await DatabaseUsers.UserManager.FindByEmailAsync(userDto.Email);
            if (user == null)
            {
                user = new ApplicationUser { Email = userDto.Email, UserName = userDto.Email };
                var result = await DatabaseUsers.UserManager.CreateAsync(user, userDto.Password);

                if (result.Errors.Count() > 0)
                    return new OperationDetails(false, result.Errors.FirstOrDefault(), "");

                await DatabaseUsers.UserManager.AddToRoleAsync(user.Id, userDto.Role);
                User clientProfile = new User { Id = user.Id, Surname = userDto.Surname, Name = userDto.Name };
                DatabaseUsers.ClientManager.Create(clientProfile);
                await DatabaseUsers.SaveAsync();
                return new OperationDetails(true, "Регистрация успешно пройдена", "");
            }
            else
            {
                return new OperationDetails(false, "Пользователь с таким логином уже существует", "Email");
            }
        }

        public async Task<ClaimsIdentity> Authenticate(UserDTO userDto)
        {
            ClaimsIdentity claim = null;
            ApplicationUser user = await DatabaseUsers.UserManager.FindAsync(userDto.Email, userDto.Password);

            if (user != null)
                claim = await DatabaseUsers.UserManager.CreateIdentityAsync(user, DefaultAuthenticationTypes.ApplicationCookie);
            return claim;
        }

        public UserDTO GetUserById(string id)
        {
            var user = Database.Users.Get(id);
            return Mapper.Map<User, UserDTO>(user);
        }

        public IEnumerable<UserDTO> GetUsers()
        {
            return Database.Users.GetAll().Select(x => new UserDTO
            {
                Id = x.Id,
                Surname = x.Surname,
                Name = x.Name,
                Email = x.ApplicationUser.Email,
                UserName = x.ApplicationUser.UserName,
                Careers = Mapper.Map<IEnumerable<Career>, List<CareerDTO>>(x.Careers),
                Resumes = Mapper.Map<IEnumerable<Resume>, List<ResumeDTO>>(x.Resumes)
            });
        }

        public void Dispose()
        {
            Database.Dispose();
        }

        public async Task<Tuple<ClaimsIdentity, ClaimsIdentity>> FindAsync(string username, string password)
        {
            var appUser = await DatabaseUsers.UserManager.FindAsync(username, password);

            //if (appUser == null)
            //throw new AuthException("invalid_grant", "The user name or password is incorrect.");

            ClaimsIdentity oAuthIdentity = await DatabaseUsers.UserManager.CreateIdentityAsync(appUser, OAuthDefaults.AuthenticationType);
            ClaimsIdentity cookiesIdentity = await DatabaseUsers.UserManager.CreateIdentityAsync(appUser, CookieAuthenticationDefaults.AuthenticationType);

            return new Tuple<ClaimsIdentity, ClaimsIdentity>(oAuthIdentity, cookiesIdentity);
        }

        public async Task<UserDTO> FindByIdAsync(string id)
        {
            var appUser = await DatabaseUsers.UserManager.FindByIdAsync(id);
            return Mapper.Map<ApplicationUser, UserDTO>(appUser);
        }
    }
}
