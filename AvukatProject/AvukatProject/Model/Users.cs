using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AvukatProjectCore.Model
{
    public class Users : BaseEntity
    {
        public string UserName { get; set; }
        public string Password { get; set; }
        public ICollection<Questions> Questions { get; set; }
        public ICollection<Answers> Answers { get; set; }

    }
}
