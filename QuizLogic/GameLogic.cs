using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.Json;
using System.Threading.Tasks;

namespace QuizLogic
{
    public class GameLogic
    {
        Random _random;

        public GameLogic()
        {
            StworzListePytan();
            Kategorie = ListaWszystkichPytan!
                .Select(p => p.Kategoria)
                .Distinct()
                .OrderBy(p => p)
                .ToList();

            AktualnaKategoria = Kategorie[AktualnyIndex];
            _random = new Random();
        }

        public int AktualnyIndex { get; set; }
        public List<int> Kategorie { get; set; }
        public List<Pytanie> ListaWszystkichPytan { get; set; }
        public int AktualnaKategoria { get; set; }
        public Pytanie AktualnePytanie { get; set; }

        public void StworzListePytan()
        {
            var path = $"{Directory.GetCurrentDirectory()}\\questions_pl.json";
            var text = File.ReadAllText(path);
            var jso = new JsonSerializerOptions { PropertyNameCaseInsensitive = true };
            ListaWszystkichPytan = JsonSerializer.Deserialize<List<Pytanie>>(text, jso)!;
        }

        public void WylosujPytanieZAktualnejKategorii()
        {
            var pytaniaZaktualnejKategorii = ListaWszystkichPytan.Where(p => p.Kategoria == AktualnaKategoria).ToList();
            var index = _random.Next(0, pytaniaZaktualnejKategorii.Count);
            var pytanie = pytaniaZaktualnejKategorii[index];
            pytanie.Odpowiedzi = pytanie.Odpowiedzi.OrderBy(p => _random.Next()).ToList();
            var id = 1;
            foreach (var odpowiedz in pytanie.Odpowiedzi)
            {
                odpowiedz.Id = id;
                id++;
            }
            AktualnePytanie = pytanie;
        }

        public bool SprawdzPoprawnoscOdpowiedzi(int userAnswer)
        {
            return AktualnePytanie.Odpowiedzi
                .FirstOrDefault(o => o.Id == userAnswer)!.CzyPoprawna;       
        }

        public bool SprawdzCzyOstatniaKategoria()
        {
            var najwyzszyIndex = Kategorie.Count - 1;
            return AktualnyIndex == najwyzszyIndex;         
        }

        public void PodniesKategorieNaNastepna()
        {
            AktualnyIndex++;
            AktualnaKategoria = Kategorie[AktualnyIndex];
        }
    }
}
