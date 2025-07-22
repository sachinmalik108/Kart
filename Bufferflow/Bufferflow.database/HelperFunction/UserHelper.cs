using AutoMapper;
using Bufferflow.database.Entities;
using Bufferflow.Shared.DTO;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Bufferflow.database.HelperFunction
{
    public class UserHelper
    {
        BufferflowContext bof = new BufferflowContext();
        public bool AddUser(UserDTO userdto)
        {
            var config = new MapperConfiguration(cfg => cfg.CreateMap<UserDTO, User>());
            var Mapper = config.CreateMapper();
            User user = Mapper.Map<User>(userdto);
            if (bof.Users.Any(u => u.EmailAddress == user.EmailAddress))
            {
                return false;
            }
            else
            {
                bof.Users.Add(user);
                bof.SaveChanges();
                return true;
            }
        }
        public UserDTO GetUserById(string id)
        {
            var config = new MapperConfiguration(cfg => cfg.CreateMap<User, UserDTO>());
            var mapper = config.CreateMapper();
            var user = bof.Users.Find(id);
            UserDTO userDTO = new UserDTO();
            userDTO.Name = user.Name;
            userDTO.ProfilePic = user.ProfilePic;
            userDTO.ModifiedAt = user.ModifiedAt;
            userDTO.CreatedAt = user.CreatedAt;
            userDTO.EmailAddress = user.EmailAddress;
            return userDTO;
        }
        public bool IsValidUser(LoginDTO logindto)
        {
            return bof.Logins.Any(u => u.EmailAddress == logindto.EmailAddress
                                    && u.Password == logindto.Password);
        }
        public bool UserExist(string id)
        {
            return bof.Logins.Any(u => u.EmailAddress == id);
        }
    }
}
