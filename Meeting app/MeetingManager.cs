using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Meeting_app
{
    class MeetingManager
    {
        private List<Meeting> meetings = new List<Meeting>();


        public void AddMeeting(Meeting meeting)
        {
            meetings.Add(meeting);
            Console.WriteLine($"Mötet '{meeting.Description}' har lagts till.");
        } 

        public void RemoveMeeting(DateTime date, string description)
        {
            Meeting meetingToRemove = meetings.Find(m => m.Date == date && m.Description.ToLower() == description.ToLower() );
            meetings.Remove(meetingToRemove);
            Console.WriteLine($"Mötet '{meetingToRemove.Description}' har tagits bort.");
        }

        public void ShowMeeting()
        {
            if (meetings.Count == 0)
            {
                Console.WriteLine("Inga möten inlagda.");
            }
            else
            {
                Console.WriteLine("Schemalagda möten :");
                foreach (var meeting in meetings)
                {
                    Console.WriteLine(meeting);
                }
            }
        }

        public void SearchMeeting(DateTime date)
        {
            List<Meeting> foundMeetings = meetings.FindAll(m => m.Date.Date == date.Date);

            if(foundMeetings.Count >0)
            {
                Console.WriteLine("Möten hittade: ");
                foreach(var meeting in foundMeetings)
                {
                    Console.WriteLine(meeting);
                }
            }
            else
            {
                Console.WriteLine($"Ingen möten hittades för datum {date.ToShortDateString()}.");

            }
            
        }

        public void RemindUpcominMeetings(int hoursAhead)
        {
            DateTime currentTime = DateTime.Now;

            DateTime reminderTime = currentTime.AddHours(hoursAhead);

            List<Meeting> upcominMeetings = meetings.FindAll(m=>m.Date > currentTime && m.Date <= reminderTime);

            if (upcominMeetings.Count > 0)
            {
                Console.WriteLine($"Kommande möten inom närmaste {hoursAhead} timmarna : ");
                foreach (var meeting in upcominMeetings)
                {
                    Console.WriteLine(meeting);
                }

            }
            else
            {
                Console.WriteLine($"Inga möten inom de närmaste {hoursAhead} timmarna");
            }
        }

        public void SaveToFile(string filePath)
        {
            using (StreamWriter writer = new StreamWriter(filePath))
            {
                foreach (var meeting in meetings)
                {
                    writer.WriteLine($"{meeting.Date},{meeting.Description}");

                }

            }
            Console.WriteLine("Möten har sparats till fil.");
        }

        public void LoadFromFile(string filePath)
        {
            if (File.Exists(filePath))
            {
                using (StreamReader reader = new StreamReader(filePath))
                {
                    string line;

                    while ((line = Console.ReadLine()) != null)
                    {
                        string[] parts = line.Split(',');
                        DateTime date = DateTime.Parse(parts[0]);
                        string description = parts[1];

                        Meeting loadedMeeting = new Meeting(date, description);

                        meetings.Add(loadedMeeting);
                    }

                }
                Console.WriteLine("Möten har laddats från fil.");
               
            }
            else
            {
                Console.WriteLine("Ingen sparad fil hittades.");
            }
        }
    }
}
