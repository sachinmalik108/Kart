﻿using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace Bufferflow.WebApi.Models
{
    public class Tag
    {
        public int ID { get; set; }

        [Required]
        public string TagName { get; set; }
    }
}