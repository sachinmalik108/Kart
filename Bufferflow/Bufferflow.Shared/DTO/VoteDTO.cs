using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Bufferflow.Shared.DTO
{
    /// <summary>
    /// DTO to transfer vote data
    /// </summary>
    public class VoteDTO
    {
        public int ID { get; set; }

       
        public bool IsVoted { get; set; }

       
        public bool IsUpvoted { get; set; }

        
        public string UserEmailAddress { get; set; }

       
        public int AnswerID { get; set; }

       
    }
}
