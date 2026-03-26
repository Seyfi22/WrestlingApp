using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WrestlingApp.Domain.Entities
{
    public class Wrestler
    {
        public int Id { get; set; }
        public string FullName { get; set; }
        public int WeightClass { get; set; } // Məsələn: 74kg, 86kg
        public string Style { get; set; } // Freestyle (Sərbəst) və ya Greco-Roman
        
        public int ClubId { get; set; }
        public virtual Club Club { get; set; }
    }
}
