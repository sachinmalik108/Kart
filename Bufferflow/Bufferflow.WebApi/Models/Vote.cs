using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace Bufferflow.WebApi.Models
{
    public class Vote
    {
        public int ID { get; set; }

        [Required]
        public bool IsVoted { get; set; }

        [Required]
        public bool IsUpvoted { get; set; }

        [Required]
        [System.ComponentModel.DataAnnotations.Schema.ForeignKey("User")]
        public string UserEmailAddress { get; set; }

        [Required]
        public int AnswerID { get; set; }
    }
}