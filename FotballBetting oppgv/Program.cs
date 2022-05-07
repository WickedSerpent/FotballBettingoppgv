using System;


namespace FotballBetting_oppgv
{
    class Program
    {

        
        static void Main()
        {
            Menu();
            Console.WriteLine("");
        }

        private static void Menu()
        {
            Console.WriteLine("skriv \"E\" for en match, eller \"T\" for tolv.");
            var menu = Console.ReadLine()?.ToLower();
            if (menu == "e")
            {
                Match.OneMatch();
            }
            else if (menu == "t")
            {
                {
                    Twelve.RunTwelve();
                }
            }
        }
    }
}