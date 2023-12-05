using System.Numerics;
bool IBAN_Tarkistin(string IBAN) {

    List<char> Ibanlist = new List<char>() { };
    string LeikattuIbanni = "";

    for (int i = 0; i < IBAN.Length; i++)
    {
        var x = IBAN.ToCharArray();
        if (x[i].ToString() != " ")
        {
            if (i > 4)
            {
                LeikattuIbanni += x[i];
            }
            Ibanlist.Add(x[i]);
        }
    }

    if (Ibanlist.Count != 18)
    {
        return false;
    }

    char[] alpha = "ABCDEFGHIJKLMNOPQRSTUVWXYZ".ToCharArray();
    char[] maaTunnus = { Ibanlist[0], Ibanlist[1] };
    string tarkisteNumerot = Ibanlist[2].ToString() + Ibanlist[3].ToString();

    int FirstNumber = 0;
    int SecondNumber = 0;

    for (int i = 0; i < alpha.Length; i++)
    {
        if (alpha[i] == maaTunnus[0])
        {
            FirstNumber = i + 10;
        }
        if (alpha[i] == maaTunnus[1])
        {
            SecondNumber = i + 10;
        }
    }

    string Numero = FirstNumber.ToString();
    Numero += SecondNumber;
    Numero += tarkisteNumerot;
    LeikattuIbanni += Numero;

    BigInteger LeikattuIbanni1 = BigInteger.Parse(LeikattuIbanni);
    if(BigInteger.Remainder(LeikattuIbanni1, 97) == 1)
    {
        return true;
    } else
    {
        return false;
    }
}
Console.WriteLine(IBAN_Tarkistin("FI42 5000 1510 0000 23"));