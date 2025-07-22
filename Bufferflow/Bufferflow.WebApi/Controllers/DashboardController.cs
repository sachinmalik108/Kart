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
    public class DashboardController : ApiController
    {
        QuestionBLL quesBLL = new QuestionBLL();

        /// <summary>
        /// Request to get all Questions on dashboard
        /// </summary>
        /// <returns></returns>
        [Route("api/dashboard")]
        [HttpGet]
        public HttpResponseMessage GetAllQuestion()
        {

            List<QuestionDTO> questions = new List<QuestionDTO>();
            questions = quesBLL.GetAllQuestions();
            HttpResponseMessage response = new HttpResponseMessage();
            response = Request.CreateResponse(HttpStatusCode.OK,questions);
            return response;
        }

        /// <summary>
        /// Request to Edit Question
        /// </summary>
        /// <param name="questionDTO"></param>
        /// <returns></returns>
        [Route("Question/Put/{id}")]
        [HttpPut]
        public IHttpActionResult EditQuestion(QuestionDTO questionDTO)
        {
            return Ok(quesBLL.EditQuestion(questionDTO));
        }

        /// <summary>
        /// Request to add question to the database
        /// </summary>
        /// <param name="questionDTO"></param>
        /// <returns></returns>
        [Route("api/Question/Add")]
        [HttpPost]
        public IHttpActionResult AddQuestion(QuestionDTO questionDTO)
        { 
            if(!quesBLL.AddQuestion(questionDTO))
                return Content(HttpStatusCode.BadRequest, "Question Not added");
            else return Content(HttpStatusCode.OK, "Added");
        }
        /// <summary>
        /// api service to get details of a question
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        [Route("Question/GetDetails/{id}")]
        [HttpGet]
        public HttpResponseMessage GetDetails(int id)
        {
            
            QuestionDTO question = quesBLL.GetDetail(id);
            return Request.CreateResponse<QuestionDTO>(HttpStatusCode.OK,question); 
        }
        /// <summary>
        /// Api service to delete any Question
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        [Route("Question/Delete/{id}")]
        [HttpDelete]
        public IHttpActionResult Delete(int id)
        {
           bool response= quesBLL.Delete(id);
            return Content(HttpStatusCode.OK, "Added");
        }
    }
}
