using System;
using AutoMapper;
using System.Collections.Generic;
using System.Linq;
using Bufferflow.Shared.DTO;
using System.Text;
using System.Threading.Tasks;
using Bufferflow.database.Entities;

namespace Bufferflow.database.HelperFunction
{
    public class AnswerHelper
    {
        BufferflowContext boc = new BufferflowContext();
        public List<AnswerDTO> GetAllAnswer(int questionID)
        {
            List<AnswerDTO> answerDTOs = new List<AnswerDTO>();
            List<Answer> answers;
           
                answers = (from p in boc.Answers
                           where p.QuestionID == questionID
                           select p).ToList();
            

            foreach (var ans in answers)
            {
                var config = new MapperConfiguration(cfg => cfg.CreateMap<Answer, AnswerDTO>());
                var mapper = config.CreateMapper();
                AnswerDTO answerDTO = mapper.Map<AnswerDTO>(ans);
                answerDTOs.Add(answerDTO);

            }
            return answerDTOs;
        }

        public bool AddAnswer(AnswerDTO answerdto)
        {
            var config = new MapperConfiguration(cfg => cfg.CreateMap<AnswerDTO, Answer>());
            var mapper = config.CreateMapper();
            Answer answer = mapper.Map<Answer>(answerdto);
            boc.Answers.Add(answer);
            boc.SaveChanges();
            return true;
        }
        public void DeleteAnswerByID(int id)
        {
            Answer answer = (from ans in boc.Answers
                             where ans.ID == id
                             select ans).FirstOrDefault();
            boc.Answers.Remove(answer);
            boc.SaveChanges();
        }
        public void EditAnswer(AnswerDTO answerdto)
        {
            Answer answer = (from ans in boc.Answers
                             where ans.ID == answerdto.ID
                             select ans).FirstOrDefault();
            boc.Answers.Remove(answer);
            answer.Ans = answerdto.Ans;
            answer.ModifiedAt = DateTime.Now;
            boc.Answers.Add(answer);
            boc.SaveChanges();
        }
        public int GetVotes(int id)
        {
            Answer answer = (from ans in boc.Answers
                             where ans.ID == id
                             select ans).FirstOrDefault();
            return answer.Netvotes;
        }
        public void AddVote(int id)
        {
            Answer answer = (from ans in boc.Answers
                             where ans.ID == id
                             select ans).FirstOrDefault();
            answer.Netvotes++;
            boc.SaveChanges();
        }
        public void RemoveVote(int id)
        {
            Answer answer = (from ans in boc.Answers
                             where ans.ID == id
                             select ans).FirstOrDefault();
            answer.Netvotes--;
            boc.SaveChanges();
        }
    }
}
