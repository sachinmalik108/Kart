using Bufferflow.database.HelperFunction;
using Bufferflow.Shared.DTO;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Bufferflow.BLL
{
   public class QuestionBLL
    {
        QuestionHelper questionhelper = new QuestionHelper();
        /// <summary>
        /// calling DAL function for question Adding
        /// </summary>
        /// <param name="questionDTO"></param>
        /// <returns></returns>
        public bool AddQuestion(QuestionDTO questionDTO)
        {
            questionDTO.ModifiedAt = DateTime.Now;
            questionDTO.CreatedAt = DateTime.Now;
            return questionhelper.AddQuestion(questionDTO);
        }
        /// <summary>
        /// Editing Question Information calling database function
        /// </summary>
        /// <param name="questionDTO"></param>
        public bool EditQuestion(QuestionDTO questionDTO)
        {
            questionDTO.ModifiedAt = DateTime.Now;
           
            return  questionhelper.EditQuestion(questionDTO);
        }
        /// <summary>
        /// Calling DAL function to get list of all questions
        /// 
        /// </summary>
        /// <returns></returns>
        public List<QuestionDTO> GetAllQuestions()
        {

            return questionhelper.GetAllQuestions();
        }
        
        public QuestionDTO GetDetail(int id)
        {
           return questionhelper.GetDetails(id);
        }
        public bool Delete(int id)
        {
            return questionhelper.Delete(id);

        }
    }
}
