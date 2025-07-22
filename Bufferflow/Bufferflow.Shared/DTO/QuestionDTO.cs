using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Bufferflow.Shared.DTO
{
    /// <summary>
    /// DTO to transfer Question data
    /// </summary>
    public class QuestionDTO
    {
        public int ID { get; set; }

       
        public string Title { get; set; }

        
        public string Description { get; set; }

        
        public DateTime CreatedAt { get; set; }

        
        public DateTime ModifiedAt { get; set; }

       
        public string UserEmailAddress { get; set; }

        
    }
}
