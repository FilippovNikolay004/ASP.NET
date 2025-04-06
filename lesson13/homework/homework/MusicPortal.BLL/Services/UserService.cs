using MusicPortal.BLL.DTO;
using MusicPortal.BLL.Interfaces;
using MusicPortal.DAL.Entities;
using MusicPortal.DAL.Interfaces;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Numerics;
using System.Text;
using System.Threading.Tasks;

namespace MusicPortal.BLL.Services {
    class UserService : IUserService {
        IUnitOfWork Database { get; set; }

        public UserService(IUnitOfWork uow) {
            Database = uow;
        }


        public async Task CreateUser(UserDTO userDTO) {
            var user = new User {
                Id = userDTO.Id,
                Login = userDTO.Login,
                Password = userDTO.Password,
                Email = userDTO.Email,
                NumberPhone = userDTO.NumberPhone,
                DateOfBirthday = userDTO.DateOfBirthday,
                Status = (DAL.Entities.UserStatus)userDTO.Status
            };
            await Database.Users.Create(user);
            await Database.Save();
        }
        public async Task UpdateUser(UserDTO userDTO) {
            var user = new User {
                Id = userDTO.Id,
                Login = userDTO.Login,
                Password = userDTO.Password,
                Email = userDTO.Email,
                NumberPhone = userDTO.NumberPhone,
                DateOfBirthday = userDTO.DateOfBirthday,
                Status = (DAL.Entities.UserStatus)userDTO.Status
            };
            Database.Users.Update(user);
            await Database.Save();
        }
        public async Task DeleteUser(int id) {
            await Database.Users.Delete(id);
            await Database.Save();
        }
        public async Task<UserDTO> GetUser(int id) {
            var user = await Database.Users.GetById(id);
            if (user == null)
                throw new ValidationException("Genre not found");

            return new UserDTO {
                Id = user.Id,
                Login = user.Login,
                Password = user.Password,
                Email = user.Email,
                NumberPhone = user.NumberPhone,
                DateOfBirthday = user.DateOfBirthday,
                Status = (DTO.UserStatus)user.Status
            };
        }
        public async Task<IEnumerable<UserDTO>> GetAllUsers() {
            var users = await Database.Users.GetAll();
            return users.Select(user => new UserDTO {
                Id = user.Id,
                Login = user.Login,
                Password = user.Password,
                Email = user.Email,
                NumberPhone = user.NumberPhone,
                DateOfBirthday = user.DateOfBirthday,
                Status = (DTO.UserStatus)user.Status
            });
        }
    }
}
