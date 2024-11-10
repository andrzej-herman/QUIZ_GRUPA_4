using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Quiz
{
    public class Backend
    {
        public Backend()
        {
            AktualnaKategoria = 100;
            StworzListePytan();
        }


        public List<Pytanie> ListaWszystkichPytan { get; set; }
        public int AktualnaKategoria { get; set; }
        public Pytanie AktualnePytanie { get; set; }

        public void StworzListePytan()
        {
            ListaWszystkichPytan = new List<Pytanie>();

            Pytanie p1 = new Pytanie();
            p1.Id = 1;
            p1.Tresc = "Jak miał na imię Einstein?";
            p1.Kategoria = 100;
            p1.Odpowiedzi = new List<Odpowiedz>();
            var o1 = new Odpowiedz();
            o1.Id = 1;
            o1.Tresc = "Albert";
            o1.CzyPoprawna = true;    
            p1.Odpowiedzi.Add(o1);
            var o2 = new Odpowiedz();
            o2.Id = 2;
            o2.Tresc = "Aaron";
            p1.Odpowiedzi.Add(o2);
            var o3 = new Odpowiedz();
            o3.Id = 3;
            o3.Tresc = "Alfons";
            p1.Odpowiedzi.Add(o3);
            var o4 = new Odpowiedz();
            o4.Id = 4;
            o4.Tresc = "Andrew";
            p1.Odpowiedzi.Add(o4);
            ListaWszystkichPytan.Add(p1);

            Pytanie p2 = new Pytanie();
            p2.Id = 2;
            p2.Tresc = "W którym roku wybuchła II wojna światowa?";
            p2.Kategoria = 200;
            p2.Odpowiedzi = new List<Odpowiedz>();
            var o11 = new Odpowiedz();
            o11.Id = 1;
            o11.Tresc = "1939";
            o11.CzyPoprawna = true;
            p2.Odpowiedzi.Add(o11);
            var o22 = new Odpowiedz();
            o22.Id = 2;
            o22.Tresc = "1914";
            p2.Odpowiedzi.Add(o22);
            var o33 = new Odpowiedz();
            o33.Id = 3;
            o33.Tresc = "1918";
            p2.Odpowiedzi.Add(o33);
            var o44 = new Odpowiedz();
            o44.Id = 4;
            o44.Tresc = "1945";
            p2.Odpowiedzi.Add(o44);
            ListaWszystkichPytan.Add(p2);
        }

        public void WylosujPytanieZAktualnejKategorii()
        {
            // SYMULUJEMY LOSOWANIE
            AktualnePytanie = ListaWszystkichPytan[0];
        }
    }
}
