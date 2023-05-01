using AutoMapper;
using AvukatProjectCore.DTOs;
using AvukatProjectCore.Model;
using AvukatProjectCore.Services;
using AvukatProjectRepository;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Newtonsoft.Json;

namespace AvukatProject.API.Controllers
{
    public class QuestionsController : CustomBaseController
    {
        private readonly AppDbContext _context;
      

        public QuestionsController(AppDbContext context)
        {
            _context = context;
            
        }
        [HttpPost]
        public async Task<ActionResult> AddQuestion(QuestionsDto questionDto)
        {
            // Convert DTO to entity object
            var question = new Questions()
            {
                Question = questionDto.Question,
                LawyersId = questionDto.LawyersId,
                UsersId = questionDto.UsersId
            };
            //Avukat seçildiyse avukat nesnesi oluşturulması ve soruya atanması
                if (question.LawyersId.HasValue)
            {
                var lawyer = _context.Lawyers.Find(question.LawyersId.Value);
                if (lawyer == null)
                {
                    return NotFound("Avukat bulunamadı");
                }
                question.Lawyers = lawyer;
            }

            // Kullanıcı nesnesinin veritabanından alınması ve soruya atanması
            var user = _context.Users.Find(question.UsersId);
            if (user == null)
            {
                return NotFound("Kullanıcı bulunamadı");
            }
            PythonCode model = new PythonCode();
            var result = model.CallPyFunction(question);
            _context.Questions.Add(question);
            _context.Oppressions.Add(result);

            //var similarQuestion = await _context.Oppressions.FirstOrDefaultAsync(s => s.Question.Id == question.Id);

            //if (similarQuestion != null)
            //{
            //    // Retrieve the answer for the similar question
            //    var similarAnswer = await _context.Answers.FirstOrDefaultAsync(a => a.QuestionsId == similarQuestion.OppressionQuestionId);

            //    // Save the answer for the new question
            //    var answer = new Answers()
            //    {
            //        Answer = similarAnswer.Answer,
            //        QuestionsId = question.Id,
            //        UsersId = questionDto.UsersId
            //    };

            //    _context.Answers.Add(answer);
            //}


            await _context.SaveChangesAsync();

            return Ok();
        }
        
        [HttpGet("{lawyerId}")]
        public IActionResult Get(int lawyerId)
        {
            var questions = _context.Questions.Where(q => q.LawyersId == lawyerId).ToList();
            return Ok(questions);
        }
       
    }
}
