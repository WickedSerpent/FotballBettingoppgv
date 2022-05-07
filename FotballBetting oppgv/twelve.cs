using System;


namespace FotballBetting_oppgv
{
    public class Twelve
    {
        // public string[] Bets { get; private set; }
        private Match[] _matches;

        public Twelve(string betsText)
    {
        var bets = betsText.Split(',');
        _matches = new Match[12];
        for (var i = 0; i < 12; i++)
        {
            _matches[i] = new Match(bets[i]);
        }
    }
        
        public static void RunTwelve()
        {
            Console.Write(
                "Gyldig tips: \r\n - H, U, B\r\n - halvgardering: HU, HB, UB\r\n - helgardering: HUB\r\nSkriv inn dine 12 tips med komma mellom: ");
            var betsText = Console.ReadLine()?.ToUpper();
            var matches = new Twelve(betsText);
            while (true)
            {
                Console.Write(
                    "Skriv kampnr. 1-12 for scoring\n S for alle kampers stillinger\n X for ferdig\r\nAngi kommando: ");
                var command = Console.ReadLine()?.ToUpper();
                if (command != null && command == "X")
                {
                    break;
                }
                else if (command == "S")
                {
                    matches.ShowAllScores();
                    matches.ShowCorrectCount();
                    Console.ReadKey();
                }
                else
                {
                    var matchNo = Convert.ToInt32(command);
                    Console.Write($"Scoring i kamp {matchNo}. \r\nSkriv H for hjemmelag eller B for bortelag: ");
                    var team = Console.ReadLine()?.ToUpper();
                    matches.AddGoal(matchNo, team == "H");
                }
            }

            matches.ShowCorrectCount();
        }
 
        public void ShowCorrectCount()
        
            {
                var correctCount = 0;
                foreach (var match in _matches)
                {
                    if (match.IsBetCorrect()) correctCount++;
                }
                Console.WriteLine($"Du har {correctCount} rette.");
            }
        

        public void ShowAllScores()
        {
            for (var index = 0; index < _matches.Length; index++)
            {
                var match = _matches[index];
                var matchNo = index + 1;
                var isBetCorrect = match.IsBetCorrect();
                var isBetCorrectText = isBetCorrect ? "riktig" : "feil";
                Console.WriteLine($"Kamp {matchNo}: {match.GetScore()} - {isBetCorrectText}");
            }
        }

        public void AddGoal(int matchNo, bool isHomeTeam)
        {
            var selectedIndex = matchNo - 1;
            var selectedMatch = _matches[selectedIndex];
            selectedMatch.AddGoal(isHomeTeam);
        }
    }


}