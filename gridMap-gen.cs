// WRITEN BY KADDI
// SIMPLE GRID MAP "GENERATOR"

List<string> Lista = new List<string>();
int maara = 2000;
int printaus = 50;

for (int i = 0; i < maara; i++)
{
    Lista.Add("[ ]");
}

void Printaus()
{
    int laskin = 0;
    for (int i = 0; i < maara; i++)
    {
        if(laskin != printaus)
        {
            Console.Write(Lista[i]);
            laskin++;
        }
        if (laskin == printaus)
        {
            laskin = 0;
            Console.WriteLine();
        }
    }
    for (int i = 0; i < maara; i++)
    {
        Lista[i] = "[ ]";
    }
}

void RamdomGeneraatio()
{
    var x = Console.ReadLine();
    var random = new Random();

    for (int i = 0; i < maara; i++)
    {
        if (random.Next(0, 3) == 1)
        {
            Lista[i] = "[X]";
        }
    }
}

while(true)
{
    RamdomGeneraatio();
    Printaus();
}