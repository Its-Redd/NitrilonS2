using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Nitrilon.Entities
{
    public class Event
    {
        private int id;
        public int Id {
            get { return id; }
            set { }
        }
        public DateTime Date { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }
        public int Attendees { get; set; }
    }
}
