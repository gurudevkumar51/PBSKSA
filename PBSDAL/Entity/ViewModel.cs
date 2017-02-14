using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PBSDAL.Entity
{
    public class ViewModel
    {
        public List<Portfolio> portfolios { get; set; }
        public List<Event> Events { get; set; }
        public List<Quotes> quote { get; set; }
        public List<Testimonial> testimonials { get; set; }
    }
}
