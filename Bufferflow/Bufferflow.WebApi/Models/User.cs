using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace Bufferflow.WebApi.Models
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