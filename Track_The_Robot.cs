/* Track the Robot (Part 3)
A robot moves around a 2D grid. At the start, it is at [0, 0], facing east. It is controlled by a sequence of instructions:

. means take one step forwards in the current direction.
< means turn 90 degrees anticlockwise.
> means turn 90 degrees clockwise.
Your job is to process the instructions and return the final position of the robot.

Example
For example, if the robot is given the sequence of instructions ..<.<., then:

Step 1: . It still faces east, and is at [1, 0].
Step 2: . It still faces east, and is at [2, 0].
Step 3: < It now faces north, and is still at [2, 0].
Step 4: . It still faces north, and is at [2, 1].
Step 5: < It now faces west, and is still at [2, 1].
Step 6: . It still faces west, and is now at [1, 1].
So, TrackRobot("..<.<.") returns[1, 1].

Notes
The instruction strings will only contain the three valid characters ., < or >.
You will always be passed a string (but the string might be empty). */


//* Kirjoittanut Kaiku (Kaddi Gz)
List<int> Move_Robot(string Characterit)
{
    var x = Characterit.ToCharArray();
    List<int> RobotPos = new List<int>() { 0, 0 };
    //* faces 0 == "east", faces 1 == "north" faces 2 == "west"
    var faces = 0;

    for (int i = 0; i < x.Length; i++)
    {
        if (x[i].ToString() == ".")
        {
            if(faces == 0){RobotPos[0] += 1;}
            if(faces == 1){RobotPos[1] += 1;}
            if(faces == 2){RobotPos[0] -= 1;}
        }
        if (x[i].ToString() == "<")
        {
            bool VastausSaatu = Check(0, false, "+");
            VastausSaatu = Check(1, VastausSaatu, "+");
            VastausSaatu = Check(2, VastausSaatu, "+");
        }
        if (x[i].ToString() == ">")
        {
            bool VastausSaatu = Check(0, false, "-");
            VastausSaatu = Check(1, VastausSaatu, "-");
            VastausSaatu = Check(2, VastausSaatu, "-");
        }
        if(i != x.Length - 1)
        {
            Console.WriteLine("["+RobotPos[0]+","+RobotPos[1]+"] [LIIKE NUMERO "+i+"]");
        }
        else
        {
            Console.WriteLine("[" + RobotPos[0] + "," + RobotPos[1] + "] [  LOPPUTULOS  ]");
        }
    }
    return RobotPos;
    
    bool Check(int number, bool VastausSaatu, string minusOrPlus)
    {
        if (faces == number && !VastausSaatu)
        {
            if(number == 0 && minusOrPlus == "-"){faces += 2;}
            if (number == 2 && minusOrPlus == "+"){faces -= 2;}

            else
            {
                if(minusOrPlus == "+"){faces += 1;}
                if(minusOrPlus == "-"){faces -= 1;}
            }
            return true;
        }
        return false;
    }
}

Move_Robot("..<.<.");