using Bufferflow.database.HelperFunction;
using Bufferflow.Shared.DTO;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Bufferflow.BLL
{
   public class AnswerBLL
    {
      private  AnswerHelper answerHelper = new AnswerHelper();
        private QuestionHelper questionHelper = new QuestionHelper();
        /// <summary>
        /// Calling DAL function to get list of all answer to particular id
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        public List<AnswerDTO> GetAllAnswer(int id)
        {
            if (!questionHelper.QuestionExist(id))
                return null;
            return answerHelper.GetAllAnswer(id);
        }
        /// <summary>
        /// Adding answer to DAL by calling AddAnswer function 
        /// </summary>
        /// <param name="answerDTO"></param>
        /// <returns></returns>
        public bool AddAnswer(AnswerDTO answerDTO)
        {
            answerDTO.CreatedAt = DateTime.Now;
            answerDTO.ModifiedAt = DateTime.Now;
            return answerHelper.AddAnswer(answerDTO);
        }
        /// <summary>
        /// Delete the answer 
        /// </summary>
        /// <param name="id"></param>
        public bool DeleteAnswerByID(int id)
        {
           return answerHelper.DeleteAnswerByID(id);
        }
        /// <summary>
        /// 
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        public int GetVotes(int id)
        {
            return answerHelper.GetVotes(id);
        }
        /// <summary>
        /// 
        /// </summary>
        /// <param name="id"></param>
        public void AddVote(int id)
        {
            answerHelper.AddVote(id);
        }
        /// <summary>
        /// 
        /// </summary>
        /// <param name="id"></param>
        public void RemoveVote(int id)
        {
            answerHelper.RemoveVote(id);
        }
        /// <summary>
        /// Editing of answer
        /// </summary>
        /// <param name="answerDTO"></param>
        /// <returns></returns>
       public bool EditAnswer(AnswerDTO answerDTO)
        {
            answerDTO.ModifiedAt = DateTime.Now;
            return answerHelper.EditAnswer(answerDTO);
        }
        public bool AnswerExist(int id)
        {
            return answerHelper.AnswerExist(id);
        }
    }
}
