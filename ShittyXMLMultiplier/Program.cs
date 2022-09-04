using System;
using System.IO;
public static class Program
{
    public static void Main(string[] args)
    {
        float multiplier = 0;
        if (args.Length==0)
        {
            Console.WriteLine("No file!");
            return;
        }
        if (args.Length==1)
        {
            Console.WriteLine("No multiplier, defaulting to 2!");
            multiplier = 2;
        }
        if (args.Length == 2)
        {
            if(float.TryParse(args[1], out multiplier))
            {
                Console.WriteLine("Multiplier set to: " + multiplier);
            }
            else
            {
                Console.WriteLine("No valid multiplier, defaulting to 2!");
                multiplier = 2;
            }
        }
        string[] file = File.ReadAllLines(args[0]);
        for(int i = 1;i<file.Length;i++)
        {
            int startIndex = file[i].IndexOfAny(new char[] { '0', '1', '2', '3', '4', '5', '6', '7', '8', '9' });
            int endIndex = file[i].LastIndexOfAny(new char[] { '0', '1', '2', '3', '4', '5', '6', '7', '8', '9' });
            string startString = file[i].Substring(0, startIndex);
            string stringNum = file[i].Substring(startIndex,endIndex-startIndex);
            string endString = file[i].Substring(endIndex+1);
            file[i] = startString + (float.Parse(stringNum) * multiplier) + endString;
        }
    }

}