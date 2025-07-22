using AutoMapper;
using Bufferflow.database.Entities;
using Bufferflow.Shared.DTO;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Bufferflow.database.HelperFunction
{
    public class QuestionHelper
    {
        private BufferflowContext boc = new BufferflowContext();
        public bool AddQuestion(QuestionDTO questionDTO)
        {
            var config = new MapperConfiguration(cfg => cfg.CreateMap<QuestionDTO, Question>());
            var mapper = config.CreateMapper();
            Question question = mapper.Map<Question>(questionDTO);
            boc.Questions.Add(question);
            boc.SaveChanges();
            return true;
        }
        public void EditQuestion(QuestionDTO questiondto)
        {
            Question question = (from ques in boc.Questions
                                 where ques.ID == questiondto.ID
                                 select ques).FirstOrDefault();
            boc.Questions.Remove(question);
            question.Description = questiondto.Description;
            question.Title = questiondto.Title;
            question.ModifiedAt = DateTime.Now;
            boc.Questions.Add(question);
            boc.SaveChanges();
        }
        public List<QuestionDTO> GetAllQuestions()
        {
            List<QuestionDTO> questionDTOs = new List<QuestionDTO>();
            List<Question> questions;
            questions = ((from ques in boc.Questions
                          select ques).OrderByDescending(ques => ques.CreatedAt)).ToList();
            foreach (var question in questions)
            {
                var config = new MapperConfiguration(cfg => cfg.CreateMap<Question, QuestionDTO>());
                var mapper = config.CreateMapper();
                QuestionDTO questiondto = mapper.Map<QuestionDTO>(question);
                questionDTOs.Add(questiondto);
            }
            if (questionDTOs.Count == 0) return null;
            else
            return questionDTOs;
        }
    }
}
