/* 
Alkeellinen 200 linen console "peli", jossa tavoitteena kerätä Pisteitä. 
Koodannut: KaikuGz 
 */

// Pelaajien, Vihollisten ja Kolikkojen merkit.
string Player = "[►]";
string Enemy = "[-]";
string Coins = "[X]";

// Eri valuet.
int EnemySpawnAmount = 50;
int Player_HP = 100;
int suunta = 0;
int points = 0;

// Pelaajan Eri suunta-, ja Vihollisten Posiitiolistat.
List<string> Suunnat = new List<string>() { "[►]", "[▼]", "[◄]", "[▲]" };
List<int> enemyPosList = new List<int>() { };

// Määrittää gridin koon ja rivit.
int map_size = 500;
int row_size = map_size / 20;


// Antaa pelaajalle random position.
var r = new Random();
int player_pos = r.Next(0, map_size);

// Mapin ja Collision listat.
List<int> VasenRajaPossit = new List<int>() {0};
List<int> OikeaRajaPossit = new List<int>() {row_size};
List<string> MapVisual = new List<string>();

// Gridin ja Kolikoiden Luonti
for (int i  = 0; i < map_size; i++)
{
    MapVisual.Add("[ ]");
    if (r.Next(0, 4) == 1) { MapVisual[i] = Coins; }
}

// Vihollisten Generointi ja lisääminen posiitiolistaan
for (int i = 0; i < EnemySpawnAmount; i++)
{
    var EnemyPos = r.Next(0, MapVisual.Count);
    MapVisual[EnemyPos] = Enemy;
    enemyPosList.Add(EnemyPos);
}

// Jos Pelaajan HP loppuu, peli pysähtyy.
while (Player_HP >= 0)
{
    Console.Clear();

    // Pelaajan Lisäys
    MapVisual[player_pos] = Player;

    int laskin = 0;
    bool PlayerMarket = false;
    for (int i = 0; i < MapVisual.Count; i++)
    {
        laskin++;
        Console.Write(MapVisual[i]);

        // Pelaajan Väritys
        if (!PlayerMarket) 
        {
            if (MapVisual[i + 1] == Player)
            {
                Console.ForegroundColor = ConsoleColor.Green;
                PlayerMarket = true;
            }
        } else
        {
            Console.ForegroundColor = ConsoleColor.White;
        }
        
        // Kolikkojen ja Vihollisten Väritys
        try
        {
            if (MapVisual[i + 1] == Coins)
            {
                Console.ForegroundColor = ConsoleColor.Yellow;
            }
            if (MapVisual[i + 1] == Enemy)
            {
                Console.ForegroundColor = ConsoleColor.Red;
            }

            else if (MapVisual[i + 1] == "[ ]")
            {
                Console.ForegroundColor = ConsoleColor.White;
            }
        }
        catch { }


        // Jos Gridia Printattu tiettymäärä, aloita uusi rivi.
        if (laskin == row_size)
        {
            Console.WriteLine();


            // Lisää positioita, jottei tule erroria kun koittaa mennä rajan yli ja ettei teleporttaa toiselle puolelle.
            OikeaRajaPossit.Add(i);
            VasenRajaPossit.Add(i+1);
            laskin = 0;
        }
    }

    try 
    {
        // MAIN


        // Näyttää Pelaajalle Pisteet ja Health Arvon
        Console.WriteLine($"Points:{points}");
        Console.WriteLine($"Player HP:{Player_HP}");

        // Ottaa komentoja, ja antaa mekaniikan että voi liikku esim vasen,500 (500kertaa vasemmalle)
        var Komento = Console.ReadLine();
        var Komennot = Komento.Split(",");

        // Katsoo onko pelaajan antamasssa komennossa 2 juttua vai vaan se esim "vasen"
        bool exist = Komennot.Length > 1;
        
        // Katsoo osuuko Pelaaja viholliseen.
        bool osuma = enemyPosList.Contains(player_pos);

        if(exist)
        {
            // Toistaa komentoa halutun määrän
            for (int i = 0; i < int.Parse(Komennot[1]); i++)
            {
                Suunta(Player, Komennot[0]);
                Player = Suunnat[suunta];
                EnemyMove();
            }
        } else
        {
            // Toistaa komentoa vain kerran
            Suunta(Player, Komennot[0]);
            Player = Suunnat[suunta];
            EnemyMove();
        }
        if (osuma)
        {
            // Osuessa viholliseen, pelaajan healt arvo laskee
            Player_HP -= 50;
        }
    }
    catch { }
}
void EnemyMove()
{
    // Liikuttaa vihollista vasemmalle tai oikealle.
    for (int i = 0; i < enemyPosList.Count; i++)
    {
        MapVisual[enemyPosList[i]] = "[ ]";
        int luku = r.Next(1, 2);
        Console.WriteLine(enemyPosList[i]);
        if (luku == 1)
        {
            MapVisual[enemyPosList[i] -= 1] = Enemy;
        } else
        {
            MapVisual[enemyPosList[i] += 1] = Enemy;
        }
    }
}

// Määrittää pelaajan suunnan ja liikkeen
void Suunta(string Player, string Minne)
{
    // Kääntää pelaajan vasemmalle 90 astetta.
    if (Minne == "vasen")
    {
        if(suunta == 0)
        {
            suunta = 3;
        } else
        {
            suunta -= 1;
        }
    }
    // Kääntää pelaajan oikealle 90 astetta.
    if (Minne == "oikea")
    {
        if (suunta == 3)
        {
            suunta = 0;
        }
        else
        {
            suunta += 1;
        }
    }
    if(Minne == "eteen")
    {
        // Tarkistaa "Colliisiot"
        bool alaraja = player_pos > MapVisual.Count - row_size-1 && suunta == 1;
        bool ylaraja = player_pos < row_size && suunta == 3;
        bool oikeasivuraja = OikeaRajaPossit.Contains(player_pos) && suunta == 0;
        bool vasensivuraja = VasenRajaPossit.Contains(player_pos) && suunta == 2;

        Console.WriteLine(player_pos);

        // Jos ei osu seinään etc, suorittaa liikkeen toivottuun suuntaan.
        if (!alaraja && !ylaraja && !vasensivuraja && !oikeasivuraja)
        {
            MapVisual[player_pos] = "[ ]";
            if (suunta == 0)
            {
                player_pos++;
            }
            if (suunta == 1)
            {
                player_pos += row_size;
            }
            if (suunta == 2)
            {
                player_pos--;
            }
            if (suunta == 3)
            {
                player_pos -= row_size;
            }
            
            // Jos ottaa kolikon, saa pisteitä.
            if (MapVisual[player_pos] == "[X]")
            {
                points += 100;
            }
        }
    }
}
