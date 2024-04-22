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
            set {
                if (value < 0)
                {
                    throw new ArgumentException("Id cannot be negative");
                }
                id = value;
            }
        }


        private DateTime date;
        public DateTime Date {
            get { return date; }
            set { 
                if (value < DateTime.Now)
                {
                    throw new ArgumentException("Date cannot be in the past");
                }
                date = value;
            }
        
        }

        private string name;
        public string Name {
            get { return name; }
            set {
                if (string.IsNullOrWhiteSpace(value) || value.Length > 128) // 128 is the maximum length of the column in the database
                {
                    throw new ArgumentException("Name cannot be empty");
                }
                name = value;
            }
        }

        private int attendees;
        public int Attendees {
            get { return attendees; }
            set {
                if (value < -1)
                {
                    throw new ArgumentException("Attendees can not be negative");
                }
                attendees = value;
            }
        }

        private string description;
        public string Description { 
            get { return description; }
            set {
                description = value;
            }
        }
    }
}
