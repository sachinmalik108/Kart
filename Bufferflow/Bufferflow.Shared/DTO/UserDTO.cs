using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Bufferflow.Shared.DTO
{
    /// <summary>
    /// DTO to transfer User data
    /// </summary>
    public class UserDTO
    {
       
        public string EmailAddress { get; set; }

       
        public string Name { get; set; }

        public byte[] ProfilePic { get; set; }

        public string Password { get; set; }

        public DateTime CreatedAt { get; set; }
        

    }
}
