using Quiz;


var backend = new Backend();
// STWORZENIE LISTY WSZYSTKICH PYTAŃ => ZROBILIŚMY W KONSTUKTORZE KLASY BACKEND
// USTAWIENIE KATEGORII NA NAJNIŻSZĄ => ZROBILIŚMY W KONSTUKTORZE KLASY BACKEND

// WYŚWIETLANIE EKRANU POWITALNEGO
Frontend.PokazEkranPowitalny();

// LOSOWANIE PYTANIA Z AKTUALNEJ KATEGORII
backend.WylosujPytanieZAktualnejKategorii();

// WYŚWIETLANIE AKTUALNEGO PYTANIA  i pobranie odpowiedzi gracza (int => 1, 2, 3 lub 4)
var odpowiedzGracza = Frontend.WyswietlPytanie(backend.AktualnePytanie);

// WALIDACJA ODPOWIEDZI GRACZA









Console.ReadLine();