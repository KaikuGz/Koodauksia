// LottoSim in Csharp - Writen by Kaiku

List<int> Arvatut_Numerot = new List<int>();
List<int> Oikeat_Numerot = new List<int>();
int MaxMaara = 42;
int Arvattavat_Maara = 7;
int OikeinMenneet = 0;
int laskin = 1;

while(Arvatut_Numerot.Count != 7)
{
    Console.WriteLine("Numero " + laskin + "/" + Arvattavat_Maara);
   
    var x = int.Parse(Console.ReadLine());
    while(Arvatut_Numerot.Contains(x) || x > MaxMaara || x < 0) 
    { 
        Console.WriteLine("DUBLICATE OR TOO SMALL/LARGE"); 
        x = int.Parse(Console.ReadLine());
    }
    Arvatut_Numerot.Add(x);
    laskin++;
}
while(Oikeat_Numerot.Count != 7)
{
    var x = new Random().Next(0, MaxMaara);
    while (Oikeat_Numerot.Contains(x))
    {
        x = new Random().Next(0, MaxMaara);
    }
    Oikeat_Numerot.Add(x);
}
for(int i = 0; i < Oikeat_Numerot.Count; i++)
{
    if(Oikeat_Numerot.Contains(Arvatut_Numerot[i]))
    {
        OikeinMenneet++;
    }
}
Console.WriteLine("Sait " + OikeinMenneet + " numeroa oikein");