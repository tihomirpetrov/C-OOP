namespace P06.FootballTeamGenerator
{
    using System;
    using System.Collections.Generic;
    using System.Linq;

    public class Startup
    {
        public static void Main()
        {
            string commands = Console.ReadLine();
            List<FootballTeam> footballTeams = new List<FootballTeam>();

            while (commands != "END")
            {
                string[] tokens = commands.Split(';', StringSplitOptions.RemoveEmptyEntries);
                string command = tokens[0];
                switch (command)
                {
                    case "Team":
                        footballTeams.Add(new FootballTeam(tokens[1]));
                        break;
                    case "Add":
                        string teamName = tokens[1];
                        string playerName = tokens[2];
                        int endurance = int.Parse(tokens[3]);
                        int sprint = int.Parse(tokens[4]);
                        int dribble = int.Parse(tokens[5]);
                        int passing = int.Parse(tokens[6]);
                        int shooting = int.Parse(tokens[7]);

                        bool footballTeamExist = footballTeams.Any(x => x.Name == teamName);
                        FootballTeam footballTeam;

                        if (!footballTeamExist)
                        {
                            Console.WriteLine($"{teamName} does not exist.");
                        }
                        else
                        {
                            try
                            {
                                footballTeam = footballTeams.Where(x => x.Name == teamName).FirstOrDefault();
                                Player player = new Player(playerName, endurance, sprint, dribble, passing, shooting);
                                footballTeam.AddPlayer(player);
                            }
                            catch (Exception ex)
                            {
                                Console.WriteLine(ex.Message);
                            }
                        }
                        break;
                    case "Remove":
                        teamName = tokens[1];
                        footballTeam = footballTeams.Where(x => x.Name == teamName).FirstOrDefault();
                        playerName = tokens[2];
                        try
                        {
                            footballTeam.RemovePlayer(playerName);
                        }
                        catch (Exception ex)
                        {
                            Console.WriteLine(ex.Message);
                        }
                        break;
                    case "Rating":
                        teamName = tokens[1];
                        footballTeamExist = footballTeams.Any(x => x.Name == teamName);
                        if (!footballTeamExist)
                        {
                            Console.WriteLine($"{teamName} does not exist.");
                        }
                        else
                        {
                            footballTeam = footballTeams.Where(x => x.Name == teamName).FirstOrDefault();
                            Console.WriteLine($"{teamName} - {footballTeam.Rating()}");
                        }

                        break;
                }
                
                commands = Console.ReadLine();
            }
        }
    }
}