using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Bufferflow.database.Entities
{
    public class User
    {
        [Key]
        public string EmailAddress { get; set; }

        [Required]
        public string Name { get; set; }

        public byte[] ProfilePic { get; set; }

        [Required]
        public DateTime CreatedAt { get; set; }

        [Required]
        public DateTime ModifiedAt { get; set; }

    }
}
