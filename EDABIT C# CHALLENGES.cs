/*EDABIT CODING CHALLENGES, WRITEN BY KAIKU*/

using System;

void ReverseAndNot(int number)
{
    /*We reverse "123" to get "321" and then add "123" to the end, resulting in "321123".*/
    string word = "";
    char[] array = number.ToString().ToCharArray();
    for (int i = array.Length - 1; i >= 0; i--) { word += array[i]; }
    Console.WriteLine(word + number.ToString());
}
ReverseAndNot(123);


void ArrayOfMultiples(int number, int times)
{
    /*Create a function that takes two numbers as arguments (num, length) and returns an array of multiples of num until the array length reaches length.*/
    List<int> list = new List<int>() {number};
    int savednumber = number;
    for(int i = 0; i < times-1; i++)
    {
        number += savednumber;
        list.Add(number);
    }
    for(int i = 0; i < list.Count; i++)
    {
        Console.Write(list[i].ToString() + " ");
    }
    Console.WriteLine("");
}
ArrayOfMultiples(7, 5);


bool IsPalindrome(int number)
{
    /*A palindrome is a number that remains the same when reversed.*/


    /*IsPalindrome(838) ➞ true
    IsPalindrome(4433) ➞ false
    IsPalindrome(443344) ➞ true*/

    string word = "";
    char[] array = number.ToString().ToCharArray();
    for (int i = array.Length - 1; i >= 0; i--) { word += array[i]; }
    if(word == number.ToString())
    {
        return true;
    }
    return false;
}
Console.WriteLine(IsPalindrome(838));


/*Locate "Nemo" from the string*/
static string FindNemo(string nemo)
{
    string[] words = nemo.Split(' ');
    for (int i = 0; i < words.Length; i++)
    {
        if (words[i].Equals("nemo", StringComparison.OrdinalIgnoreCase))
        {
            return "I found Nemo at " + (i + 1);
        }
    }
    return "I can't find Nemo :(";
}
Console.WriteLine(FindNemo("yo where are you Nemo"));