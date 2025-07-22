using Bufferflow.BLL;
using Bufferflow.Shared.DTO;
using Bufferflow.WebApi.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;

namespace Bufferflow.WebApi.Controllers
{     
    
    public class AnswerController : ApiController   
    {
        AnswerBLL answerBLL = new AnswerBLL();
        /// <summary>
        /// Api service to add answer to the database
        /// </summary>
        /// <param name="answerDTO"></param>
        /// <returns></returns>
        [Route("api/Answer/add/{id}")]
        [HttpPost]
        public IHttpActionResult AddAnswer(AnswerDTO answerDTO)
        {
            if (answerDTO.Ans == null)
            {
                return Content(HttpStatusCode.BadRequest, "Answer Not added");
            }
            if (!answerBLL.AddAnswer(answerDTO))
                return Content(HttpStatusCode.BadRequest, "Answer Not added");
            else return Content(HttpStatusCode.Accepted,"Added");
        }

        /// <summary>
        /// Get service to get list of all answer
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        [Route("api/Answer/Get/{id}")]
        [HttpGet]
        public HttpResponseMessage GetAllAnswer(int id)
        {
            List<AnswerDTO> answerDTOs = answerBLL.GetAllAnswer( id);
            HttpResponseMessage response = new HttpResponseMessage();
            response = Request.CreateResponse(HttpStatusCode.OK, answerDTOs);
            return response;
        }
        /// <summary>
        /// Delete api service to delete answer
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        [Route("Answer/Delete/{id}")]
        [HttpDelete]
        public IHttpActionResult DeleteAnswer(int id)
        {
            return Ok(answerBLL.DeleteAnswerByID(id));
        }
        /// <summary>
        /// Request to Edit answer with given id
        /// </summary>
        /// <param name="answerDTO"></param>
        /// <returns></returns>
        [Route("Answer/Edit/{id}")]
        [HttpPut]
        public IHttpActionResult EditAnswer(AnswerDTO answerDTO)
        {
            return Ok(answerBLL.EditAnswer(answerDTO));
        }
        /// <summary>
        /// Api service to get net votes on a answer
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        [Route("Answer/Vote/{id}")]
        [HttpGet]

        public IHttpActionResult GetVotes(int id)
        {
            return Ok(answerBLL.GetVotes(id));
        }
      
    }
}
