using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AvukatProjectCore.DTOs
{
    public class AnswersDto : BaseDto
    {
        public string Answer { get; set; }
        public int QuestionsId { get; set; }
    }
}
