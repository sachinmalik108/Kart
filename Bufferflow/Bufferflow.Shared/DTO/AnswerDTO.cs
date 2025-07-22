using System;

using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Bufferflow.Shared.DTO
{
    /// <summary>
    /// DTO to transfer answer data
    /// </summary>
    public class AnswerDTO
    {
        public int ID { get; set; }

        public string Ans { get; set; }

        public int Netvotes { get; set; }


        public DateTime CreatedAt { get; set; }


        public DateTime ModifiedAt { get; set; }


        public int QuestionID { get; set; }


        public string UserEmailAddress { get; set; }
    }
}