using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AvukatProjectCore.Model
{
    public class Lawyers : BaseEntity
    {
        public string Name { get; set; }
        public string Mail { get; set; }
        public string About { get; set; }
        public string Photograph { get; set; }
        public string Password { get; set; }
        public int CategoryId { get; set; }
        public Category Category { get; set; }
        public ICollection<Questions> Questions { get; set; }

    }
}
