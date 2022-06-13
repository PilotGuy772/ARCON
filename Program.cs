//main class

global using System;
global using System.Data.SQLite;
global using System.Windows.Forms;

class Program
{

    private static string? LastCommand;

    public static void Main()
    {        
        /*
        This function is the startup function that only runs one time on startup

        - initialize the database
        - set CWD to /files
        - call command function
        */
    }

    private static void Command()
    {
        /*
        a self looping function that gets the user's input
        - take input
        - split into array with each argument
        - call the function corresponding to the initial command
        - throw exception if there's an error
        */

        //give  ~cool colors~ and get user input while immediately splitting into an array
        Console.ForegroundColor = ConsoleColor.Blue;
        Console.Write("ARCON SHELL V1.0 -- # ");
        Console.ForegroundColor = ConsoleColor.Green;
        string[] args = Console.ReadLine().Split(' ');
        Console.ForegroundColor = ConsoleColor.White;

        //switch case to move thread to another .cs file
        switch(args)
        {
            default:
                
                break;
        }

    }
}