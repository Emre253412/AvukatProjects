using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AvukatProjectCore.DTOs
{
    public class OppressionDto:BaseDto
    {
        public double Oppression { get; set; }
        public int OppressionQuestionId { get; set; }
        public int QuestionId { get; set; }
    }
}
