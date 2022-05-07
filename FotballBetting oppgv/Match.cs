using System;

namespace FotballBetting_oppgv
{
    public class Match
    {
        public int _homeGoals;
        public int _awayGoals;
        public string _bet;
        public  bool MatchIsRunning  { get; private set;}
        // public static bool matchRandom { get; set;}
        public Match(string bet)
        {
            _bet = bet; 
            MatchIsRunning = true;
        }
        public void Stop()
        { 
            MatchIsRunning = false;
        }

        public string GetScore()
        {
            return $"Stillingen er {_homeGoals}-{_awayGoals}";
            
        }
        public bool IsBetCorrect()
        {
            var result = _homeGoals == _awayGoals ? "U" : _homeGoals > _awayGoals ? "H" : "B";
            return _bet.Contains(result);
        }
        
        public void AddGoal(bool homeGoal)
        {
            if (homeGoal)
            {
                _homeGoals++;
            }
            else
            {
                _awayGoals++;
            }
        }

 
        private static void CommandInfo()
        {
            Console.Write(
                "Kommandoer: \r\n - H = scoring hjemmelag\r\n - B = scoring bortelag\r\n - X = kampen er ferdig\r\nAngi kommando: ");
        }

        private static void InfoText()
        {
            Console.Write(
                "Gyldig tips: \r\n - H, U, B\r\n - halvgardering: HU, HB, UB\r\n - helgardering: HUB\r\nHva har du tippet for denne kampen? ");
            
        }

        public static void OneMatch()
        {
            {
                InfoText();
                string bet = Console.ReadLine()?.ToUpper();
                Match match = new Match(bet);
                while (match.MatchIsRunning)
                {
                    CommandInfo();
                    var command = Console.ReadLine()?.ToUpper();
                    
                    if (command != null && (command == "H" || command == "B"))
                    {
                        match.AddGoal(command == "H");
                        Console.WriteLine($"Stillingen er {match.GetScore()}");
                    }else if (command== "X")
                    {
                     
                        var result = match._homeGoals == match._awayGoals ? "U" : match._homeGoals > match._awayGoals ? "H" : "B";
                        var isBetCorrectText = match._bet.Contains(result) ? "riktig" : "feil";
                        Console.WriteLine($"Du tippet {isBetCorrectText}");
                        Console.ReadKey();
                        match.Stop();
                        break;
                    }
                }
            }
        }
    }
    
    
}