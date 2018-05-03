using System;
using LogicLayer.DTO;
using LogicLayer.Interfaces;
using Data.Interfaces;
using AutoMapper;
using Data.Entities;

namespace LogicLayer.Services
{
    public class UserService : IUserService
    {
        IUnitOfWork Database { get; set; }

        public UserService(IUnitOfWork unitOfWork)
        {
            Database = unitOfWork ?? throw new ArgumentNullException(nameof(unitOfWork));
        }

        public void CreateUser(UserDTO userDTO)
        {
            Database.Users.Create(Mapper.Map<UserDTO, User>(userDTO));
            Database.Save();
        }

        public void Dispose()
        {
            Database.Dispose();
        }

        public void EditUser(UserDTO userDTO)
        {
            Database.Users.Update(Mapper.Map<UserDTO, User>(userDTO));
            Database.Save();
        }

        public void RemoveUser(UserDTO userDTO)
        {
            User user = Mapper.Map<UserDTO, User>(userDTO);
            Database.Users.Delete(user.Id);
            Database.Save();
        }
    }
}
