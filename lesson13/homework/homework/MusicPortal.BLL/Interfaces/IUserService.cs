﻿using MusicPortal.BLL.DTO;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MusicPortal.BLL.Interfaces {
    public interface IUserService {
        Task CreateUser(UserDTO userDTO);
        Task UpdateUser(UserDTO userDTO);
        Task DeleteUser(int id);
        Task<UserDTO> GetUserId(int id);
        Task<UserDTO> GetUserName(string login);
        Task<IEnumerable<UserDTO>> GetAllUsers();
    }
}
