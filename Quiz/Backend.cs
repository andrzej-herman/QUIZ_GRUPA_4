using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.Json;
using System.Threading.Tasks;

namespace Quiz
{
    public class Backend
    {
        Random _random;

        public Backend()
        {
            AktualnaKategoria = 100;
            StworzListePytan();
            _random = new Random();
        }

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
            var pytanie = ListaWszystkichPytan[index];
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
    }
}
