using Quiz;
using QuizLogic;


var backend = new GameLogic();
// STWORZENIE LISTY WSZYSTKICH PYTAŃ => ZROBILIŚMY W KONSTUKTORZE KLASY BACKEND
// USTAWIENIE KATEGORII NA NAJNIŻSZĄ => ZROBILIŚMY W KONSTUKTORZE KLASY BACKEND

// WYŚWIETLANIE EKRANU POWITALNEGO
Display.PokazEkranPowitalny();

while (true)
{
    // LOSOWANIE PYTANIA Z AKTUALNEJ KATEGORII
    backend.WylosujPytanieZAktualnejKategorii();

    // WYŚWIETLANIE AKTUALNEGO PYTANIA  i pobranie odpowiedzi gracza (int => 1, 2, 3 lub 4)
    var odpowiedzGracza = Display.WyswietlPytanieIPobierzOdpowiedz(backend.AktualnePytanie);

    // WALIDACJA ODPOWIEDZI GRACZA
    var czyOdpowiedzPrawidlowa = backend.SprawdzPoprawnoscOdpowiedzi(odpowiedzGracza);

    if (czyOdpowiedzPrawidlowa)
    {
        // SPRAWDZENIE CZY TO BYŁA OSTATNIA KATEGORIA
        var ostatniePytanie = backend.SprawdzCzyOstatniaKategoria();
        if (ostatniePytanie)
        {
            Display.Wygrana();
            break;
        }
        else
        {
            Display.OdpowiedzOk(backend.AktualnaKategoria);
            // PODNIESIENIE KATEGORII NA NAJWYŻSZĄ
            backend.PodniesKategorieNaNastepna();
        }
    }
    else
    {
        Display.KoniecGry();
        break;
    }
}

Console.ReadLine();