// CUPSWAB CHALLENGE WRITE BY KAIKU (KADDI GZ)

// cupSwapping(["AB", "CA", "AB"]) ➞ "C"
// Ball begins at position B.
// Cups A and B swap, so the ball is at position A.
// Cups C and A swap, so the ball is at position C.
// Cups A and B swap, but the ball is at position C, so it doesn't move.

string cupSwapping(List<string> Cups)
{
    string start_pos = "B";
    for (int i = 0; i < Cups.Count; i++)
    {
        var x = Cups[i].ToCharArray();
        if (Cups[i].Contains(start_pos))
        {
            bool vastaus = false;
            if( x[0].ToString() == start_pos && !vastaus)
            {
                start_pos = x[1].ToString();
                vastaus = true;
            }
            if (x[1].ToString() == start_pos && !vastaus)
            {
                start_pos = x[0].ToString();
            }
        }
        else
        {
            Console.Write(start_pos);
            return start_pos;
        }
    }
    Console.Write(start_pos);
    return start_pos;
}
cupSwapping(new List<string>{"BA", "AC", "CA", "BC"});
