using DraftPickAnalyzer;

public class Program {
    private static void Main(string[] args) {
        int teams = 16;
        
        string picksGiven = "4.01,6.06,7.11";
        string picksGained = "5.05,5.09,5.14";

        List<Pick> pickSetGive = new List<Pick>();
        List<Pick> pickSetGet = new List<Pick>();
        
        var pickListGive = picksGiven.Split(",");
        var pickListGet = picksGained.Split(",");

        PickNumCalculator calc = new PickNumCalculator(teams);

        decimal roundPick;
        int pickNum;

        foreach (var pick in pickListGive) {
            roundPick = Decimal.Parse(pick);
            pickNum = calc.GetPickNum(roundPick);
            pickSetGive.Add(new Pick(pickNum));
        }
        foreach (var pick in pickListGet) {
            roundPick = Decimal.Parse(pick);
            pickNum = calc.GetPickNum(roundPick);
            pickSetGet.Add(new Pick(pickNum));
        }


        double valGive = pickSetGive.Select(x => x.Value).Sum();
        double valGet = pickSetGet.Select(x => x.Value).Sum();

        Console.WriteLine("The % value gained is "+(((valGet - valGive)/valGive))*100);
    }
}