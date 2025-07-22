using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Bufferflow.database.Entities
{
    public class Question
    {
        public int ID { get; set; }

        [Required]
        public string Title { get; set; }

        [Required]
        public string Description { get; set; }

        [Required]
        public DateTime CreatedAt { get; set; }

        [Required]
        public DateTime ModifiedAt { get; set; }

        [Required]
        [ForeignKey("User")]
        public string UserEmailAddress { get; set; }

        public virtual User User { get; set; }

        public virtual ICollection<Answer> Answers { get; set; }

        public virtual ICollection<Tag> Tags { get; set; }
    }
}
