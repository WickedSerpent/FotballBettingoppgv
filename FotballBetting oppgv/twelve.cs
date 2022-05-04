using System;

namespace FotballBetting_oppgv
{
    public class Twelve
    {
        public static void TwelveMatches(){   
            Console.Write("Gyldig tips: \r\n - H, U, B\r\n - halvgardering: HU, HB, UB\r\n - helgardering: HUB\r\nSkriv inn dine 12 tips med komma mellom: ");
            var betsText = Console.ReadLine()?.ToUpper();
            if (betsText != null)
            {
                var bets = betsText.Split(',');
                var matches = new Match[12];
                for (var i = 0; i < 12; i++)
                {
                    matches[i] = new Match(bets[i]);
                }

                while (true)
                {
                    Console.Write("Skriv kampnr. 1-12 for scoring eller X for alle kampene er ferdige\r\nAngi kommando: ");
                    var command = Console.ReadLine()?.ToUpper();
                    if (command == "X") break;
                    var matchNo = Convert.ToInt32(command);
                    Console.Write($"Scoring i kamp {matchNo}. \r\nSkriv H for hjemmelag eller B for bortelag: ");
                    var team = Console.ReadLine()?.ToUpper();
                    var selectedIndex = matchNo - 1;
                    var selectedMatch = matches[selectedIndex];
                    selectedMatch.AddGoal(team == "H");
                    var correctCount = 0;
                    for (var index = 0; index < matches.Length; index++)
                    {
                        var match = matches[index];
                        matchNo = index + 1;
                        bool isBetCorrect = Match.IsBetCorrect();
                        var isBetCorrectText = isBetCorrect ? "riktig" : "feil";
                        if (isBetCorrect) correctCount++;
                        Console.WriteLine($"Kamp {matchNo}: {Match.GetScore()} - {isBetCorrectText}");
                    }

                    Console.WriteLine($"Du har {correctCount} rette.");
                }
            }
        }
    }
}