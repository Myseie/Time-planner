using Meeting_app;

class Program
{
    static void Main()
    {
        MeetingManager manager = new MeetingManager();

        string filePath = "meetings.txt";

        manager.LoadFromFile(filePath);

        bool exit = false;

        while (!exit)
        {
            Console.WriteLine("\nVälj ett alternativ :");
            Console.WriteLine("1. Lägg till ett möte");
            Console.WriteLine("2. Ta bort möte");
            Console.WriteLine("3. Visa alla möten");
            Console.WriteLine("4. Sök efter möten");
            Console.WriteLine("5. Påminn om dom kommande möten");
            Console.WriteLine("6.Spara möten till fil");
            Console.WriteLine("7.Avsluta ");
            

            string choice = Console.ReadLine();

            switch (choice)
            {
                case "1":
                    Console.Write("Ange datum och tid (yyyy-mm-dd hh:mm): ");
                    DateTime date = DateTime.Parse(Console.ReadLine());

                    Console.Write("Ange beskrivning : ");
                    string description = Console.ReadLine();

                    Meeting newMeeting = new Meeting(date, description);

                    manager.AddMeeting(newMeeting);
                    break;

                case "2":
                    Console.Write("Ange datum och tid för mötet (yyyy-mm-dd hh:mm): ");
                    DateTime dateToRemove = DateTime.Parse(Console.ReadLine());

                    Console.Write("Ange mötesbeskrivning :");
                    string descriptionToRemove = Console.ReadLine();

                    manager.RemoveMeeting(dateToRemove, descriptionToRemove);

                    break;

                case "3":
                    manager.ShowMeeting();
                    break;

                case "4":
                    Console.Write("Ange datum (yyyy-mm-dd): ");
                    DateTime searchDate = DateTime.Parse(Console.ReadLine());
                    manager.SearchMeeting(searchDate);

                    break;

                case "5":
                    Console.Write("Hur många timmar framåt vill du få en påminnelse för? : ");
                    int hoursAhead = int.Parse(Console.ReadLine());

                    manager.RemindUpcominMeetings(hoursAhead);
                    break;

                case "6":
                    manager.SaveToFile(filePath);
                    break;

                case "7":
                    manager.SaveToFile(filePath);
                    exit = true;
                    break;

                default:
                    Console.WriteLine("Ogiltligt val, försök igen");
                    break;
            }
        }
    }
}