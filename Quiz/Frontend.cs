using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Quiz
{
    public static class Frontend
    {
        private static List<string> acceptedKeys = ["1", "2", "3", "4"];

        public static void PokazEkranPowitalny()
        {
            Console.ForegroundColor = ConsoleColor.White;
            Console.WriteLine(" WITAJ W QUIZIE");
            Console.WriteLine(" Spróbuj odpowiedzieć na 7 pytań");
            Console.WriteLine(" POWODZENIA !!!");
            Console.WriteLine();
            Console.ForegroundColor = ConsoleColor.Yellow;
            Console.Write(" Naciśnij ENTER - aby rozpocząć grę ...");
            Console.ForegroundColor = ConsoleColor.White;
            Console.ReadLine();
        }

        public static int WyswietlPytanieIPobierzOdpowiedz(Pytanie pytanie)
        {
            var userAnswer = WyswietlPytanie(pytanie);
            while (!CzyDopuszczalnaOdpowiedz(userAnswer))
            {
                userAnswer = WyswietlPytanie(pytanie);
            }

            return int.Parse(userAnswer!);
        }

        private static bool CzyDopuszczalnaOdpowiedz(string? answer)
        {
            var result = false;
            if (answer != null)
            {
                if (acceptedKeys.Contains(answer))
                    return true;
            }

            return result;
        }

        private static string? WyswietlPytanie(Pytanie pytanie)
        {
            Console.Clear();
            Console.WriteLine();
            Console.WriteLine($" Pytanie za {pytanie.Kategoria} pkt.");
            Console.WriteLine();
            Console.WriteLine(" " + pytanie.Tresc);
            Console.WriteLine();
            foreach (var odpowiedz in pytanie.Odpowiedzi)
            {
                Console.WriteLine($" {odpowiedz.Id}. {odpowiedz.Tresc}");
            }

            Console.WriteLine();
            Console.ForegroundColor = ConsoleColor.Yellow;
            Console.Write(" Naciśnij 1, 2, 3 lub 4 aby wybrać odpowiedź ... ");
            Console.ForegroundColor = ConsoleColor.White;
            return Console.ReadLine();
        }

        public static void KoniecGry()
        {
            Console.Clear();
            Console.WriteLine();
            Console.ForegroundColor = ConsoleColor.Red;
            Console.WriteLine(" Niestety to nie jest prawidłowa odpowiedź");
            Console.WriteLine();
            Console.WriteLine(" KONIEC GRY");
        }

        public static void OdpowiedzOk(int punkty)
        {
            Console.Clear();
            Console.WriteLine();
            Console.ForegroundColor = ConsoleColor.Green;
            Console.WriteLine(" Brawo,  to jest prawidłowa odpowiedź !!!");
            Console.WriteLine($" Zdobyłaś/eś {punkty} pkt.");
            Console.WriteLine();
            Console.ForegroundColor = ConsoleColor.Yellow;
            Console.Write(" Naciśnij ENTER - aby zobaczyć następne pytanie ...");
            Console.ForegroundColor = ConsoleColor.White;
            Console.ReadLine();
        }

    }
}
