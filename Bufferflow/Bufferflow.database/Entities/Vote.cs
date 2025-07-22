using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Bufferflow.database.Entities
{
    public class Vote
    {
        public int ID { get; set; }

        [Required]
        public bool IsVoted { get; set; }

        [Required]
        public bool IsUpvoted { get; set; }

        [Required]
        [ForeignKey("User")]
        public string UserEmailAddress { get; set; }

        [Required]
        public int AnswerID { get; set; }

        public virtual User User { get; set; }

        public virtual Answer Answer { get; set; }

    }
}
