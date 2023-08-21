//Kirjoita haluamallasi koodikielellä funktio, jonka argumenttina on lista.

//Funktio sekoittaa listan elementit niin, että jokainen elementti vaihtaa kerran paikkaa satunnaisen elementin kanssa.
//Funktio palauta sekoitetun listan.
//Kerro paljonko aikaa kului tehtävään. 

//Writen By Kaiku

void sekoita(List<int> lista2)
{
    for (int i = 0; i < lista2.Count; i++)
    {
        var x = new Random().Next(0, lista2.Count);
        
        var saved = lista2[i];
        lista2[i] = lista2[x];
        lista2[x] = saved;

        Console.WriteLine(lista2[i] + " <-> " + lista2[x]);
    }

    Console.WriteLine();
    for (int i = 0;i < lista2.Count; i++)
    {
        Console.WriteLine(lista2[i]);
    }
}
sekoita(new List<int> {1,2,3,4,5,6,7,8,9,10});

//Kului 20min

