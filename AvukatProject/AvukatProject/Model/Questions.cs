using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AvukatProjectCore.Model
{
    public class Questions : BaseEntity
    {
        public string Question { get; set; }
        public int LawyersId { get; set; }
        public Lawyers Lawyers { get; set; }
        public ICollection<Users> Users { get; set; }
        public ICollection<Answers> Answers { get; set; }
    }
}
