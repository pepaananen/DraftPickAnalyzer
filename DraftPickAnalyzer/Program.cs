using System.Text.RegularExpressions;
using DraftPickAnalyzer;

public class Program
{
    private static void Main(string[] args)
    {
        Console.WriteLine("Please input the number of teams in the league.");
        string userInput = Console.ReadLine();
        int numTeamsInLeague = 12;
        if (!int.TryParse(userInput, out numTeamsInLeague))
        {
            Console.WriteLine("Invalid input. Defaulting to 12 teams.");
        }
        else
        {
            Console.WriteLine("Number of teams in league: " + numTeamsInLeague);
        }

        Console.WriteLine(
            "Please input the picks traded away as a comma seperated list with each pick in the format '<RoundNumber>.<2DigitPickNumber>' for example round 3 pick 2 would be '3.02'");

        userInput = Console.ReadLine();

        string picksTradedAway = "";

        if (!string.IsNullOrEmpty(userInput))
        {
            while (!Regex.IsMatch(userInput, @"^[0-9.,]*$"))
            {
                Console.WriteLine(
                    "Invalid input. Please input in the format '<RoundNumber>.<2DigitPickNumber>' for example round 3 pick 2 and round 5 pick 11 would be '3.02,5.11'.");
                userInput = Console.ReadLine();
            }

            picksTradedAway = userInput;
        }
        else
        {
            Console.WriteLine("No picks traded away. Exiting.");
            return;
        }

        Console.WriteLine(
            "Please input the picks gained as a comma seperated list with each pick in the format '<RoundNumber>.<2DigitPickNumber>' for example round 3 pick 2 would be '3.02'");
        userInput = Console.ReadLine();

        string picksGained = "";

        if (!string.IsNullOrEmpty(userInput))
        {
            while (!Regex.IsMatch(userInput, @"^[0-9.,]*$"))
            {
                Console.WriteLine(
                    "Invalid input. Please input in the format '<RoundNumber>.<2DigitPickNumber>' for example round 3 pick 2 and round 5 pick 11 would be '3.02,5.11'.");
                userInput = Console.ReadLine();
            }

            picksGained = userInput;
        }
        else
        {
            Console.WriteLine("No picks gained. Exiting.");
            return;
        }


        List<Pick> pickSetGive = new List<Pick>();
        List<Pick> pickSetGet = new List<Pick>();

        var pickListGive = picksTradedAway.Split(",");
        var pickListGet = picksGained.Split(",");

        PickNumCalculator calc = new PickNumCalculator(numTeamsInLeague);

        decimal roundPick;
        int pickNum;

        foreach (var pick in pickListGive)
        {
            roundPick = Decimal.Parse(pick);
            pickNum = calc.GetPickNum(roundPick);
            pickSetGive.Add(new Pick(pickNum));
        }

        foreach (var pick in pickListGet)
        {
            roundPick = Decimal.Parse(pick);
            pickNum = calc.GetPickNum(roundPick);
            pickSetGet.Add(new Pick(pickNum));
        }


        double valGive = pickSetGive.Select(x => x.Value).Sum();
        double valGet = pickSetGet.Select(x => x.Value).Sum();

        Console.WriteLine("The % value gained is " + (((valGet - valGive) / valGive)) * 100);
    }
}