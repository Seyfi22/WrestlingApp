using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WrestlingApp.Domain.Entities
{
    public class Club
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Address { get; set; }

        public virtual ICollection<Wrestler> Wrestlers { get; set; } = new List<Wrestler>();
    }
}
