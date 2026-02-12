using System.Runtime.Intrinsics.X86;

namespace KalkulatorBMI
{
    public partial class MainPage : ContentPage
    {
        double BMI;

        public MainPage()
        {
            InitializeComponent();
        }
        private void OnCounterClicked(object? sender, EventArgs e)
        {
            KategoriaWagowa.IsVisible = true;
            if (!string.IsNullOrEmpty(WagaEntry.Text) || !string.IsNullOrEmpty(WzrostEntry.Text))
            {
                if (!double.TryParse(WagaEntry.Text, out double WagaInt)) return;
                if (!double.TryParse(WzrostEntry.Text, out double WzrostInt)) return;

                if (WagaInt > 0 && WzrostInt > 0)
                {
                    BMI = WagaInt / ((WzrostInt / 100) * (WzrostInt / 100));

                    Wynik.Text = $"Twoje BMI: {Math.Round(BMI, 2)}";
                }
                else Wynik.Text = "Do formularza wprowadzono wartosc 0!!"; KategoriaWagowa.IsVisible = false;
            }
            else { Wynik.Text = "Podaj poprawne dane liczbowe";  KategoriaWagowa.IsVisible = false; }

            Kategoria();
        }

        private void Kategoria()
        {
            if (BMI < 18.5 && BMI > 0)
            {
                KategoriaWagowa.Text = "Niedowaga";
                Wynik.TextColor = Colors.Blue;
            }
            else if (BMI >= 18.5 && BMI < 25)
            {
                KategoriaWagowa.Text = "Waga Prawidlowa";
                Wynik.TextColor = Colors.Green;
            }
            else if (BMI >= 25 && BMI < 30)
            {
                KategoriaWagowa.Text = "Nadwaga";
                Wynik.TextColor = Colors.Orange;
            }
            else if (BMI >= 30)
            {
                KategoriaWagowa.Text = "Otylosc";
                Wynik.TextColor = Colors.Red;
            }
            else { return; }
        }
    }
}

/* ***********************************************
nazwa funkcji:         < OnCounterClicked >
opis funkcji:          < Pobiera Wartosci z pol entry, na ich podstawie oblicza BMI, wyswietla wynik albo zwraca blad i uruchamia funkcje kategoria()>
parametry:             < brak >
zwracany typ i opis:   < Zwraca Komunikat z wartoscia BMI i uruchamia funkcje Kategoria()>
autor:                 < Karol S >
**************************************************

**************************************************
nazwa funkcji:         < Kategoria >
opis funkcji:          < Funkcja sprawdza w jakiej kategorii wagowej miesci sie BMI i wyswietla odpowiedni komunikat>
parametry:             < brak >
zwracany typ i opis:   < zwraca komunikat o kategorii wagowej>
autor:                 < Karol S >
*********************************************** */