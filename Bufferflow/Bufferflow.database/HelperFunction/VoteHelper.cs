using Bufferflow.database.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Bufferflow.database.HelperFunction
{
    public class VoteHelper
    {
        BufferflowContext boc = new BufferflowContext();
        public void AddVote(int answerId, string UserId)
        {
            Vote vote = (from v in boc.Votes
                         where v.UserEmailAddress == UserId && v.AnswerID == answerId
                         select v).FirstOrDefault();
            if (vote == null)
            {
                vote.IsVoted = true;
                vote.IsUpvoted = true;
                AnswerHelper ah = new AnswerHelper();
                ah.AddVote(answerId);
                boc.Votes.Add(vote);
            }
            if (vote != null)
            {
                if (vote.IsVoted == true)
                {
                    vote.IsUpvoted = true;
                    AnswerHelper ah = new AnswerHelper();
                    ah.AddVote(answerId);

                    ah.AddVote(answerId);
                }
            }
        }

    }
}
