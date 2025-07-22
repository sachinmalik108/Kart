using Bufferflow.BLL;
using Bufferflow.Shared.DTO;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;


namespace Bufferflow.WebApi.Controllers
{
    public class VoteController : ApiController
    {
        AnswerBLL ansbll = new AnswerBLL();
        VoteBLL votebll = new VoteBLL();
        /// <summary>
        /// 
        /// </summary>
        /// <param name="answerid"></param>
        /// <param name="userid"></param>
        /// <returns></returns>
        [Route("api/Vote/Likevote")]
        [HttpPost]
        public IHttpActionResult LikeVote(VoteDTO votedto)
        {
            HttpResponseMessage message = new HttpResponseMessage(HttpStatusCode.PartialContent);
            //if (votedto.UserEmailAddress == null || ansbll.AnswerExist(votedto.AnswerID)) return Content(HttpStatusCode.BadRequest, "Vote Not added");

            votebll.LikeVote(votedto);
            return Content(HttpStatusCode.Accepted, "Liked");
        }
        /// <summary>
        /// Api to dislike the vote
        /// </summary>
        /// <param name="votedto"></param>
        /// <returns></returns>
        [Route("api/Vote/Dislikevote")]
        [HttpPost]
        public IHttpActionResult DisLikeVote(VoteDTO votedto)
        {

            HttpResponseMessage message = new HttpResponseMessage(HttpStatusCode.PartialContent);
           

            votebll.DislikeVote(votedto);
            return Content(HttpStatusCode.Accepted, "Disliked");
        }
    }
}
