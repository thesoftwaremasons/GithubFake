using System.Diagnostics;

internal class Program
{
    private static void Main(string[] args)
    {
        Console.WriteLine("Hello, World!");
        GetInput();



    }

    static void GetInput()
    {
        int commits = 10;
        // int results = 0;
        bool skipWeekends = true;
        int numberOfYearsToCommit = 2;
        var rand=new Random();


        Console.WriteLine("Maximum Number Of Commit Per Day");
        bool checkCommitPerDayIsNumeric = int.TryParse(Console.ReadLine(), out int results);
        if (checkCommitPerDayIsNumeric)
        {
            commits = results;
        }
        Console.WriteLine("Skip Weekends: Y or N (Default)");

        string readSkipWeekends = Console.ReadLine()??"";
        if (readSkipWeekends.ToLower() == "y")
        {
            skipWeekends = true;
     
        }
        Console.WriteLine("Number of Commit Year ");
        bool checkNumberOfYearsIsNumeric = int.TryParse(Console.ReadLine(),out results);
        if (checkNumberOfYearsIsNumeric)
        {
            numberOfYearsToCommit = results;
        }

        DateTime endDate= DateTime.Now;
        DateTime startDate = new DateTime(endDate.Year-numberOfYearsToCommit, endDate.Month, endDate.Day);


    

    

        for (DateTime i=startDate;i< endDate;i=i.AddDays(1))
        {
            if (skipWeekends)
            {
                if (i.DayOfWeek== DayOfWeek.Saturday || i.DayOfWeek == DayOfWeek.Sunday)
                {
                    continue;
                }

            }
            int commit= rand.Next(1, commits);




            for (int j = 0; j < commit; j++)
            {
                string command = $"git commit --allow-empty --date='{i.ToString("ddd MMM dd HH:mm:ss zzz yyyy")}' -m='testing'";

                Process cmd = new Process();
                cmd.StartInfo.FileName = "cmd.exe";
                cmd.StartInfo.RedirectStandardInput = true;
                cmd.StartInfo.RedirectStandardOutput = true;
                cmd.StartInfo.CreateNoWindow = true;
                cmd.StartInfo.UseShellExecute = false;
                cmd.Start();
                cmd.StandardInput.WriteLine(command);
                cmd.StandardInput.Flush();
                cmd.StandardInput.Close();
                cmd.WaitForExit();
                Console.WriteLine(cmd.StandardOutput.ReadToEnd());
                // new Process() { StartInfo = new ProcessStartInfo("cmd.exe", command) }.Start();
            }
        }
    


    //    for(int startDate=)



    }
}