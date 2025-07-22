using Bufferflow.database.HelperFunction;
using Bufferflow.Shared.DTO;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Bufferflow.BLL
{
   public class UserBLL
    {
        private UserHelper userHelper = new UserHelper();

        public UserDTO IsValidUser(LoginDTO loginDTO)
        {
            return userHelper.IsValidUser(loginDTO);
        }

        public bool AddUser(UserDTO userDTO)
        {
            
            bool IsAdded = userHelper.AddUser(userDTO);
            return IsAdded;
        }

        public UserDTO GetUserById(string id)
        {
            if (userHelper.UserExist(id) == true)
            {
                return userHelper.GetUserById(id);
            }
            else return null;
        }
    }
}
