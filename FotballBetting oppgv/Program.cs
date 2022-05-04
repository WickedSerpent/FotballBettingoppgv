using System;


namespace FotballBetting_oppgv
{
    class Program
    {
        
        static void Main()
        {
            Console.WriteLine("skriv \"E\" for en match, eller \"T\" for tolv.");
            var menu = Console.ReadLine()?.ToLower();
            if (menu == "e")
                {
                    OneMatch(); 
                }else if(menu == "t")
                {
                    Twelve.TwelveMatches();
                }
            
        }

        private static void OneMatch()
        {
            InfoText();
            string bet = Console.ReadLine()?.ToUpper();
            Match match = new Match(bet);
            while (Match.MatchIsRunning)
            {
                CommandInfo();
                var command = Console.ReadLine()?.ToUpper();
                if (command == "X")
                {
                    Match.Stop();
                }
                else if (command == "H" || command == "B")
                {
                    match.AddGoal(command == "H");
                    Console.WriteLine($"Stillingen er {Match.GetScore()}");
                }
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
    }
}