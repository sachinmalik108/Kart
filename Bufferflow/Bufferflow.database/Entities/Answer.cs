using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Bufferflow.database.Entities
{
  
        public class Answer
        {
            public int ID { get; set; }

            [Required]
            public string Ans { get; set; }

            [Required]
            public int Netvotes { get; set; }

            [Required]
            public DateTime CreatedAt { get; set; }

            [Required]
            public DateTime ModifiedAt { get; set; }

            [Required]
            public int QuestionID { get; set; }

            [Required]
            [ForeignKey("User")]
            public string UserEmailAddress { get; set; }

            public virtual User User { get; set; }

            public virtual Question Question { get; set; }
        }
    
}
