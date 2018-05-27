﻿using LogicLayer.DTO;
using LogicLayer.Infrastructure;
using System;
using System.Collections.Generic;
using System.Security.Claims;
using System.Threading.Tasks;

namespace LogicLayer.Interfaces
{
    public interface IUserService
    {
        Task<OperationDetails> Create(UserDTO userDto);
        Task<ClaimsIdentity> Authenticate(UserDTO userDto);
        UserDTO GetUserById(string id);
        IEnumerable<UserDTO> GetUsers();

        Task<Tuple<ClaimsIdentity, ClaimsIdentity>> FindAsync(string username, string password);
        Task<UserDTO> FindByIdAsync(string id);

        IEnumerable<CareerDTO> GetUserCareers(string id);
        IEnumerable<ResumeDTO> GetUserResumes(string id);
    }
}
