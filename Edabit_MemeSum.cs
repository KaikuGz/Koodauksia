/*
Examples

MemeSum(26, 39) ➞ 515
// 2+3 = 5, 6+9 = 15
// 26 + 39 = 515

MemeSum(122, 81) ➞ 1103
// 1+0 = 1, 2+8 = 10, 2+1 = 3
// 122 + 81 = 1103

MemeSum(1222, 30277) ➞ 31499
*/

void MemeSum(int X, int B)
{
    string Len_Change(int _1Input, int _2Input)
    {
        if (_1Input.ToString().Length < _2Input.ToString().Length)
        {
            string X_string = "";
            for (int i = 0; i < (_2Input.ToString().Length - _1Input.ToString().Length); i++)
            {
                X_string += "0";
            }
            return X_string + _1Input;
        }
        return _1Input.ToString();
    }

    string MuunnettuA = Len_Change(X, B);
    string MuunettuB = Len_Change(B, X);

    var x_Lista = MuunnettuA.ToString().ToArray();
    var b_Lista = MuunettuB.ToString().ToArray();

    string vastaus = "";
    for(int i = 0; i < x_Lista.Length; i++)
    {
        vastaus += int.Parse(x_Lista[i].ToString()) + int.Parse(b_Lista[i].ToString());
    }
    Console.WriteLine(vastaus);
}
MemeSum(30277, 1222);
