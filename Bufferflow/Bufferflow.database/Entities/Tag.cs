using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Bufferflow.database.Entities
{
    public class Tag
    {
        public int ID { get; set; }

        [Required]
        public string TagName { get; set; }

        public virtual ICollection<Question> Questions { get; set; }
    }
}
