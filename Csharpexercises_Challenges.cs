// csharpexercises.com coding challenges - writen by kaiku

// Draw Triangle with * symbol
void DrawTriangle()
{
    for (int i = 0; i < 10; i++)
    {
        Console.WriteLine("");
        for (int j = 0; j < i; j++) { Console.Write(" *"); }
    }
    
    for (int i = 10; i > 0; i--)
    {
        Console.WriteLine("");
        for (int j = 0; j < i; j++) { Console.Write(" *"); }
    }

}
DrawTriangle();
Console.WriteLine();


// Replace two words with Given a string in which two words are separated by a char, write a method that replaces these two words.
string ReplaceWords(string sana, char seperator)
{
    var x = sana.Split(seperator);
    return x[1] + seperator + x[0];
}
Console.WriteLine(ReplaceWords("koira.kissa", '.'));

