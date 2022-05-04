using System;

namespace FotballBetting_oppgv
{
    class Match
    {
        private static int _homeGoals;
        private static int _awayGoals;
        private static string _bet;
        public static bool MatchIsRunning  { get; set;}
        // public static bool matchRandom { get; set;}
        public Match(string bet)
        {
            _bet = bet; 
            MatchIsRunning = true;
        }


        public static void Stop()
        {
            IsBetCorrect();
            MatchIsRunning = false;
        }

        public static string GetScore()
        {
            return $"Stillingen er {_homeGoals}-{_awayGoals}";
        }

        public static bool IsBetCorrect()
        {
            var result = _homeGoals == _awayGoals ? "U" : _homeGoals > _awayGoals ? "H" : "B";
            var isBetCorrectText = _bet.Contains(result) ? "riktig" : "feil";
            Console.WriteLine($"Du tippet {isBetCorrectText}");
            return false;
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
    }
    
    
}