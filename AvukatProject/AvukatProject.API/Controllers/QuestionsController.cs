using AutoMapper;
using AvukatProjectCore.DTOs;
using AvukatProjectCore.Model;
using AvukatProjectCore.Services;
using AvukatProjectRepository;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

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
        public IActionResult PostQuestion(QuestionsDto questionDto)
        {
            // SoruDto sınıfından soru nesnesi oluşturulması
            var question = new Questions
            {
                Question = questionDto.Question,
                UsersId = questionDto.UsersId,
                LawyersId = questionDto.LawyersId
            };

            // Avukat seçildiyse avukat nesnesi oluşturulması ve soruya atanması
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
            question.Users = user;

            // Sorunun veritabanına kaydedilmesi
            _context.Questions.Add(question);
            _context.SaveChanges();

            return Ok(question);
        }
        [HttpGet("{lawyerId}")]
        public IActionResult Get(int lawyerId)
        {
            var questions = _context.Questions.Where(q => q.LawyersId == lawyerId).ToList();
            return Ok(questions);
        }
       
    }
}
