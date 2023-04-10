using AutoMapper;
using AvukatProjectCore.DTOs;
using AvukatProjectCore.Model;
using AvukatProjectCore.Services;
using AvukatProjectRepository;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace AvukatProject.API.Controllers
{
    public class AnswersController : CustomBaseController
    {
        private readonly AppDbContext _context;


        public AnswersController(AppDbContext context)
        {
            _context = context;

        }

        [HttpPost]
        public IActionResult PostAnswers(AnswersDto answersDto)
        {

            var answer = new Answers
            {
                Answer = answersDto.Answer,
                QuestionsId = answersDto.QuestionsId,
                UsersId = answersDto.UsersId,
                
            };

            // Avukat seçildiyse avukat nesnesi oluşturulması ve soruya atanması
            //if (answer.LawyersIdd.HasValue)
            //{
            //    var lawyer = _context.Lawyers.Find(answer.LawyersIdd.Value);
            //    if (lawyer == null)
            //    {
            //        return NotFound("Avukat bulunamadı");
            //    }
            //    answer.Lawyers = lawyer;
            //}
            var question = _context.Questions.Find(answer.QuestionsId);
            if (question == null)
            {
                return NotFound("Soru bulunamadı");
            }
            answer.Questions = question;
            // Kullanıcı nesnesinin veritabanından alınması ve soruya atanması
            var user = _context.Users.Find(answer.UsersId);
            if (user == null)
            {
                return NotFound("Kullanıcı bulunamadı");
            }
            answer.Users = user;

            _context.Answers.Add(answer);
            _context.SaveChanges();

            return Ok(answer);
        }
        [HttpGet("{userId}")]
        public IActionResult Get(int userId)
        {
            var answers = _context.Answers.Where(q => q.UsersId == userId).ToList();
            return Ok(answers);
        }

    }
}
