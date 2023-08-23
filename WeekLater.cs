/* 
WeekLater("12/03/2020") ➞ "19/03/2020"

WeekLater("21/12/1989") ➞ "28/12/1989"

WeekLater("01/01/2000") ➞ "08/01/2000"

 
 WRITEN BY KAIKU
 */

void WeekLater(string PaivaMaara){
    
    var x = PaivaMaara.Split("/");
    int week = int.Parse(x[0]) + 7;
    x[0] = week.ToString();
    if(week > 30)
    {
        int how_mutch_more = week / 30;
        for (int i = 0; i < how_mutch_more; i++)
        {
            x[0] = (week - 30).ToString();
            week -= 30;
            x[1] = (int.Parse(x[1]) + 1).ToString();
        }
    }
    if (int.Parse(x[1]) > 12)
    {
        x[1] = (int.Parse(x[1]) - 12).ToString();
        x[2] = (int.Parse(x[2]) + 1).ToString();
    }

    if(week < 10)
    {
        x[0] = "0" + week;
    }

    for(int i = 0; i < 2; i++)
    {
        if (int.Parse(x[0]) < 10 && !x[0].Contains("0"))
        {
            x[0] = "0" + x[0];
        }
        if (int.Parse(x[1]) < 10 && !x[1].Contains("0"))
        {
            x[1] = "0" + x[1];
        }
    }

    for (int i = 0; i < x.Length; i++)
    {
        Console.WriteLine(x[i]);
    }
}
WeekLater("08/01/2000");