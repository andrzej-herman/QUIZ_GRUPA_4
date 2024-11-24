using Quiz;


var backend = new Backend();
// STWORZENIE LISTY WSZYSTKICH PYTAŃ => ZROBILIŚMY W KONSTUKTORZE KLASY BACKEND
// USTAWIENIE KATEGORII NA NAJNIŻSZĄ => ZROBILIŚMY W KONSTUKTORZE KLASY BACKEND

// WYŚWIETLANIE EKRANU POWITALNEGO
Frontend.PokazEkranPowitalny();

// LOSOWANIE PYTANIA Z AKTUALNEJ KATEGORII
backend.WylosujPytanieZAktualnejKategorii();

// WYŚWIETLANIE AKTUALNEGO PYTANIA  i pobranie odpowiedzi gracza (int => 1, 2, 3 lub 4)
var odpowiedzGracza = Frontend.WyswietlPytanieIPobierzOdpowiedz(backend.AktualnePytanie);

// WALIDACJA ODPOWIEDZI GRACZA
var czyOdpowiedzPrawidlowa = backend.SprawdzPoprawnoscOdpowiedzi(odpowiedzGracza);

if (czyOdpowiedzPrawidlowa)
{

    Frontend.OdpowiedzOk(backend.AktualnaKategoria);
}
else
{
    Frontend.KoniecGry();
}








Console.ReadLine();