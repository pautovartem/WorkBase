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

        public void Dispose()
        {
            Database.Dispose();
        }

        public async Task<OperationDetails> Registation(UserDTO userDTO)
        {
            var user = await DatabaseUsers.UserManager.FindByEmailAsync(userDTO.Email);
            if (user == null)
            {
                user = new ApplicationUser { Email = userDTO.Email, UserName = userDTO.Email };
                var result = await DatabaseUsers.UserManager.CreateAsync(user, userDTO.Password);

                if (result.Errors.Count() > 0)
                    return new OperationDetails(false, result.Errors.FirstOrDefault(), "");

                await DatabaseUsers.UserManager.AddToRoleAsync(user.Id, userDTO.Role);
                User clientProfile = new User { Id = user.Id, Name = userDTO.Name };
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
    }
}
