/* 

Cons([5, 1, 4, 3, 2]) ➞ true
// Can be re-arranged to form [1, 2, 3, 4, 5]

Cons([5, 1, 4, 3, 2, 8]) ➞ false

Cons([5, 6, 7, 8, 9, 9]) ➞ false
// 9 appears twice 

*/

bool cons(int[] Lista)
{
    int pieninListasta = Lista.Min();
    int Count = 0;

    for(int i = 0; i < Lista.Length; i++)
    {
        if(Lista.Contains(pieninListasta + i))
        {
            Count++;
        }
    }

    if(Count == Lista.Length)
    {
        return true;
    } else
    {
        return false;
    }
}

bool Vastaus = cons([5, 1, 4, 3, 3]);
Console.WriteLine(Vastaus);