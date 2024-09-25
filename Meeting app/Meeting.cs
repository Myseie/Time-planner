using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Meeting_app
{
    class Meeting
    {
        public DateTime Date {  get; set; }

        public string Description { get; set; }


        public Meeting(DateTime date, string description)
        {
            Date = date;

            Description = description;
        }

        public override string ToString()
        {
            return $"Datum {Date}, Beskrivning : {Description}";
        }
    }
}
