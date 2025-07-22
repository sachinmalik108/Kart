﻿using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Bufferflow.database.Entities
{
    public class Login
    {
        [ForeignKey("User")]
        [Key]
        public string EmailAddress { get; set; }

        [Required]
        public string Password { get; set; }

        public virtual User User { get; set; }
    }
}
