using Bufferflow.database.HelperFunction;
using Bufferflow.Shared.DTO;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Bufferflow.BLL
{
   public class VoteBLL
    {
        VoteHelper votehelper = new VoteHelper();
        UserHelper userHelper = new UserHelper();
        /// <summary>
        /// Calling database function for adding vote
        /// </summary>
        /// <param name="answerID"></param>
        /// <param name="UserID"></param>
        public void LikeVote(VoteDTO votedto)
        {
            if (userHelper.UserExist(votedto.UserEmailAddress))
            { 
                votehelper.LikeVote(votedto);
            }
        }
        /// <summary>
        /// Calling database function for removing vote
        /// </summary>
        /// <param name="answerID"></param>
        /// <param name="UserID"></param>
        public void DislikeVote(VoteDTO votedto)
        {
            if (userHelper.UserExist(votedto.UserEmailAddress))
            {
                votehelper.DislikeVote(votedto);
            }
        }

    }
}
