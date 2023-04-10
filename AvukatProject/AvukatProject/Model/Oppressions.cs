using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AvukatProjectCore.Model
{
    public class Oppressions:BaseEntity
    {
        public int Oppression { get; set; }
        public int QuestionsId { get; set; }
        public Questions Questions { get; set; }
    }
}
