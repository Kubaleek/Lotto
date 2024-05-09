// Main Gry
static void Main()
{
    // Wywołujemy Funkcję Do wyboru gry
    WybierzRodzajGry();
}

// Funkcja WybierzRodzajGry
static void WybierzRodzajGry()
{
    bool wyborgry = false;
    Console.WriteLine("======= Menu Główne =======\n");
    Console.WriteLine("1. Standardowe Lotto (5 liczb)");
    Console.WriteLine("2. Duży Lotek (10 liczb)");
    Console.WriteLine("3. Historia Swoich Losowań");
    Console.WriteLine("4. Opcje");
    Console.WriteLine("5. Pomoc");
    Console.WriteLine("6. Wyjście");
    // Pętla Wyboru Rodzaju Gry
    while (!wyborgry)
    {
        int wybor = Convert.ToInt32(Console.ReadLine());

        switch (wybor)
        {
            case 1:
                Console.Clear();
                GrajWLotto(5);
                break;
            case 2:
                Console.Clear();
                GrajWLotto(10);
                break;
            case 3:
                Console.Clear();
                PokazHistoria();
                break;
            case 4:
                Console.Clear();
                OpcjeGry();
                break;
            case 5:
                Console.Clear();
                Pomoc();
                break;
            case 6:
                Console.Write("\nCzy na pewno chcesz zakończyć grę? (T/N) ");
                string odpowiedz = Console.ReadLine().ToUpper();
                if (odpowiedz == "T")
                {
                    wyborgry = true;
                    Console.WriteLine("\nDziękujemy za grę!");
                }
                else
                {
                    Console.Clear();
                    WybierzRodzajGry();
                }
                break;
            // Po wpisaniu nieprawidłowego wyboru to pokaże komunikat i będzie w pętli dopóki się nie wybierze 1 lub 2 
            default:
                Console.Clear();
                Console.WriteLine("\nNiepoprawny wybór. Spróbuj ponownie.\n");
                WybierzRodzajGry();
                break;
        }
        // Jeśli użytkownik wybrał opcję zakończenia gry, kończymy pętlę wybierania rodzaju gry
        if (wyborgry)
        {
            Environment.Exit(0);
        }

        Powrot(); // Po zakończeniu rundy, umożliwia użytkownikowi wybór powrotu do menu lub wyjścia z gry
    }
};

// Funkcja Gry Lotto
static void GrajWLotto(int liczbaLiczb)
{
    Console.WriteLine($"Wypisz {liczbaLiczb} liczb (0-45): ");
    int[] TabPlayer = new int[liczbaLiczb];
    for (int i = 0; i < liczbaLiczb; i++)
    {
        TabPlayer[i] = Convert.ToInt32(Console.ReadLine());
    }
    // Komputer
    /*
    Prosi Użytkownika o podanie ile wygenerować kuponów
    */
    Console.Write("\nIle kuponów chcesz wygenerować? ");
    int liczbaKuponow = Convert.ToInt32(Console.ReadLine());
    Random random = new Random();
    // Pętla Wykonania Kuponów
    for (int k = 0; k < liczbaKuponow; k++)
    {
        int[] TabComputer = new int[liczbaLiczb];
        for (int i = 0; i < liczbaLiczb; i++)
        {
            TabComputer[i] = random.Next(0, 45);
        }
        sprawdz(TabPlayer, TabComputer);
    }
}

// Funkcja Historia
static void PokazHistoria()
{
    Console.WriteLine("======= Opcje Gry =======\n");

    Console.WriteLine("Niedługo....");
}

// Funkcja OpcjeGry
static void OpcjeGry()
{
    Console.WriteLine("======= Opcje Gry =======\n");

    Console.WriteLine("Niedługo....");
}

// Funkcja Historia
static void Pomoc()
{
    Console.WriteLine("======= Pomoc =======\n");

    Console.WriteLine(
    "Witaj w grze Lotto!\n" +
    "\n* Celem Gry jest wybranie odpowiednich liczb oraz odgadnąć jakie komputer wylosował liczby\n" +
    "* Gra składa się z dwóch trybów: Standardowe Lotto (5 liczb) i Duży Lotek (10 liczb).\n" +
    "* Podczas gry zostaniesz poproszony o wypisywanie odpowiedniej liczby, a następnie komputer wylosuje 0 - 45 liczb.\n" +
    "* Po losowaniu, gra sprawdzi trafienia i poinformuje Cię o wyniku.\n" +
    "* Powodzenia!"
    );
}
// Funkcja Sprawdzająca 
static void sprawdz(int[] TabPlayer, int[] TabComputer)
{
    // Trafienia w Lotteri
    int traf = 0;

    Console.WriteLine("\nTabela trafień:\n");
    Console.WriteLine("Gracz\tKomputer");

    // Pętla Długości Liczb Tablicy TabPlayer
    for (int i = 0; i < TabPlayer.Length; i++)
    {
        // Domyślnie Ustawiamy 0 do Każdego Liczby
        string trafiony = "0";
        for (int j = 0; j < TabComputer.Length; j++)
        {
            // Sprawdzamy czy liczba z tablicy gracza jest równa konkretnej liczbie w tablicy komputera
            if (TabPlayer[i] == TabComputer[i])
            {
                traf++;
                trafiony = "X"; // Jeśli trafienie, ustawiamy na "X"
                break;
            }
        }
        Console.WriteLine($"{TabPlayer[i]} \t {TabComputer[i]} \t {trafiony}");
    }

    Console.WriteLine("\nLiczba trafionych liczb: " + traf);

    // Sprawdź czy liczba trafień jest równa długości tablicy komputera
    string komunikat = traf == TabComputer.Length ? "Gratulacje! Wygrałeś!" : "Niestety, nie udało Ci się wygrać.";
    Console.WriteLine(komunikat);
}

// Funkcja Powrotu do Menu
static void Powrot()
{
    Console.WriteLine("\nCo chcesz zrobić?");
    Console.WriteLine("1. Wróć do menu");
    Console.WriteLine("2. Wyjdź z gry");

    int wybor = Convert.ToInt32(Console.ReadLine());

    switch (wybor)
    {
        case 1:
            // Po Wybraniu Powróci do Menu Gry
            Console.Clear();
            WybierzRodzajGry();
            break;
        case 2:
            // Po Wybraniu Zakończy program gry
            Console.WriteLine("\nDziękujemy za grę!");
            Environment.Exit(0);
            break;
        default:
            Console.Clear();
            Console.WriteLine("Niepoprawny wybór. Spróbuj ponownie.");
            Powrot(); // wywołanie funkcji, aby ponownie zapytać użytkownika
            break;
    }
}

// Uruchomienie na Starcie Funkcji Main ( Program Gry )
Main();